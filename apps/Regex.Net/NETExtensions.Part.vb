Imports System.Runtime.CompilerServices
Imports System.Threading

'Namespace RegexDotNet

Module NETExtensions

    Public Function Rand(Max As Integer, Optional Min As Integer = 0) As Integer
        Dim getSeed =
            Function(value As String) As Integer
                Dim result As Integer = 0

                For i = 1 To value.Length
                    Dim iValue = Val(Mid(value, i, 1))
                    If Not iValue = 0 Then
                        result += iValue * 2 * i
                    End If
                Next

                Return result
            End Function

        Dim r As New Random(getSeed(Guid.NewGuid().ToString))
        Return r.Next(Math.Min(Min, Max), Math.Max(Min, Max) + 1)
    End Function

    Private mSimpleThreadsList As New List(Of Threading.Thread)
    Public ReadOnly Property SimpleThreadsList As List(Of Threading.Thread)
        Get
            Return mSimpleThreadsList
        End Get
    End Property
    Private ThreadTimersList As New List(Of Threading.Timer)

    <Extension()>
    Public Function SetIfNullOrEmpty(value As String, newValue As String) As String
        Return If(String.IsNullOrEmpty(value), newValue, value)
    End Function

    <Extension()>
    Public Function ToStream(value As String) As IO.Stream
        Dim stream = New IO.StreamWriter(New IO.MemoryStream(value))
        Return stream.BaseStream
    End Function

    Public Function GetFileContentStream(filepath As String) As IO.Stream
        If Not IO.File.Exists(filepath) Then
            Return Nothing
        End If

        Dim fileContent = IO.File.ReadAllBytes(filepath)
        Dim stream = New IO.StreamWriter(New IO.MemoryStream(fileContent))
        Return stream.BaseStream
    End Function

	Public Sub GetFileContentStreamByUri(uri as string, callback as action(of IO.Stream))
		GetFileContentStreamByUri(new uri(uri), callback)
	End Sub

	Public Sub GetFileContentStreamByUri(uri as uri, callback as action(of IO.Stream))
		Threading.ThreadPool.QueueUserWorkItem(
			Sub()
				dim webclient as new system.net.webclient()
				dim result as string = webclient.DownloadString(uri)
				
				msgbox(result.Length)

				try
					Dim stream as New IO.StreamWriter(New IO.MemoryStream(System.Text.Encoding.Default.GetBytes(result)))
					callback(stream.BaseStream)
				catch ex as exception
					'msgbox("error : " & ex.message)
					'callback(nothing)
				end try
			end Sub
		)
	end sub

	Public Sub GetImageByUri(uri as string, callback as action(of image))
		GetFileContentStreamByUri(new uri(uri),
			sub(stream as io.stream)
				callback(System.Drawing.Bitmap.FromStream(stream))
			end sub
		)
	end sub

	Public Sub GetIconByUri(uri as string, callback as action(of icon))
		GetFileContentStreamByUri(new uri(uri),
			sub(stream as io.stream)
				callback(new System.Drawing.Icon(stream))
			end sub
		)
	end sub

	Public Sub TryInvoke(invoker As System.Windows.Forms.Control, action As Action)
        If invoker.InvokeRequired Then
            Try
                invoker.Invoke(action)
            Catch ex As InvalidOperationException
                Debug.Print("[TryInvoke] Failing invoke action on " & invoker.Name)
            End Try
        Else
            Try
                action()
            Catch ex As InvalidOperationException
                Debug.Print("[TryInvoke] Failing call action on " & invoker.Name)
            End Try
        End If
    End Sub

    Public Function GetFileNameByBaseFileName(baseFileName As String,
                                              extensions As String,
                                              Optional extensionsSperator As String = "|") As String

        For Each extension In extensions.Split(extensionsSperator)
            If IO.File.Exists(baseFileName & "." & extension) Then
                Return baseFileName & "." & extension
            End If
        Next

        Return Nothing
    End Function

    Public Function GetTimeStamp() As Long
        Return DateDiff(DateInterval.Second, New Date(1970, 1, 1, 0, 0, 0, 1), Date.UtcNow)
    End Function

    <DebuggerHidden()>
    Public Sub SimpleThreadExecute(WorkInstructions As [Delegate],
                                       Optional OnCompleted As [Delegate] = Nothing,
                                       Optional OnIteration As [Delegate] = Nothing,
                                       Optional Arguments As Object = Nothing,
                                       Optional MillisecondStartDecal As Integer = 0,
                                       Optional MillisecondPeriodInterval As Integer = 0,
                                       Optional MillisecondLifeTime As Integer = 0,
                                       Optional RunOnCompletedOnAborted As Boolean = True,
                                       Optional ThreadName As String = Nothing,
                                       Optional ThreadPriority As Threading.ThreadPriority = ThreadPriority.Normal,
                                       Optional IsBackgroundThread As Boolean = False,
                                       Optional AllowMultiPeriodThreads As Boolean = True,
                                       Optional Invoker As Object = Nothing)

        If Not IsNothing(ThreadName) Then
            For i = 0 To SimpleThreadsList.Count - 1
                Try
                    Dim thread = SimpleThreadsList(i)
                    If thread.Name = ThreadName Then
                        mSimpleThreadsList.Remove(thread)

                        If thread.IsAlive Then
                            thread.Abort()
                        End If
                    End If
                Catch
                End Try
            Next
        End If

        ThreadName = ThreadName.SetIfNullOrEmpty("SimpleThread n°" & GetTimeStamp() & mSimpleThreadsList.Count & Date.Now.Millisecond)

        Dim TimerThreads As New List(Of Threading.Thread) ' contains started threads by da thread timer

        Dim ThreadsAborted As Boolean = False
        Dim periodThread = Not (MillisecondStartDecal.Equals(0) And MillisecondPeriodInterval.Equals(0))

        ' Bridge to abort all started threads by da thread timer
        Dim abortThreads =
            Sub()
                ThreadsAborted = True

                Threading.Thread.Sleep(20)
                Application.DoEvents()

                TimerThreads.ForEach(
                    Sub(iThread As Threading.Thread)
                        Try
                            If TimerThreads.Contains(iThread) Then
                                TimerThreads.Remove(iThread)
                            End If
                            If mSimpleThreadsList.Contains(iThread) Then
                                mSimpleThreadsList.Remove(iThread)
                            End If
                            iThread.Abort()
                        Catch
                        End Try
                    End Sub
                )
            End Sub

        ' FormatArg bridge
        Dim formatArg =
            Function(value As Object) As Object
                If IsNothing(value) Then
                    Return {}
                ElseIf Not IsArray(value) Then
                    Return {value}
                Else
                    Return value
                End If
            End Function

        ' OnCompleted bridge
        Dim procThreadCompleted =
            Sub(oArguments As Object)
                OnCompleted.TryCallDelegate(Invoker, formatArg(oArguments))
            End Sub

        'OnIteration bridge
        Dim procThreadIteration =
            Sub(oArguments As Object)
                OnIteration.TryCallDelegate(Invoker, formatArg(oArguments))
            End Sub

        ' WorkInstructrions bridge + OnCompleted's bridge call
        Dim procThread =
            Sub(oThread As Threading.Thread, oArguments As Object)
                Dim result As Object = Nothing '<-- ???? check this.. why is it set to nothing.. Oo

                result = WorkInstructions.TryCallDelegate(Invoker, oThread, oArguments)

                If periodThread And Not IsNothing(OnIteration) Then
                    procThreadIteration(formatArg(result))
                End If

                If Not periodThread And Not IsNothing(OnCompleted) Then
                    procThreadCompleted(formatArg(result))
                End If
            End Sub

        ' New WorkInstructions's bridge threading bridge for timored use
        Dim genThread =
            Function() As Threading.Thread
                Dim nThread As Threading.Thread = Nothing ' let's this trick if u want to point da object in da next code line..
                nThread = New Threading.Thread(
                    Sub(parameters As Object)
                        Try
                            procThread(parameters.thread, parameters.Arguments)
                        Catch ex As Threading.ThreadAbortException ' catch case when thread.abort() happenin in procThread().
                            abortThreads()
                        Catch
                        End Try

                        ' let's make free space (index) in da list (and let's thread to be killed by VS'GC)... xD
                        TimerThreads.Remove(nThread)
                        mSimpleThreadsList.Remove(nThread)
                    End Sub
                )
                With nThread
                    .Name = ThreadName
                    .IsBackground = IsBackgroundThread
                    .Priority = ThreadPriority
                End With

                TimerThreads.Add(nThread)
                mSimpleThreadsList.Add(nThread)

                Return nThread
            End Function

        ' Start Thread's LifeTimer
        If Not MillisecondLifeTime.Equals(0) Then
            Dim timerEnd As New Threading.Timer(
                Sub()
                    abortThreads()

                    If RunOnCompletedOnAborted Then
                        RunOnCompletedOnAborted = False
                        procThreadCompleted(Nothing)
                    End If
                End Sub,
                Nothing,
                MillisecondLifeTime,
                Threading.Timeout.Infinite
            )
            ThreadTimersList.Add(timerEnd)
        End If

        If Not periodThread Then
            Dim thread = genThread()
            'Debug.Print("Start thread : [" & DateTime.Now.Hour & ":" & DateTime.Now.Minute & ":" & DateTime.Now.Second & "." & DateTime.Now.Millisecond & "]")
            thread.Start(New With {.thread = thread, .Arguments = Arguments})
        Else
            Dim timerStart As Threading.Timer = Nothing ' let's this trick if u want to point da object in da next code line..
            timerStart = New Threading.Timer(
                Sub()
                    If ThreadsAborted Then
                        If RunOnCompletedOnAborted Then
                            RunOnCompletedOnAborted = False
                            procThreadCompleted(Nothing)
                        End If

                        timerStart.Dispose()
                        Exit Sub
                    End If

                    If Not AllowMultiPeriodThreads And Not TimerThreads.Count.Equals(0) Then
                        If TimerThreads.Item(TimerThreads.Count - 1).IsAlive Then
                            Exit Sub
                        End If
                    End If

                    Dim nThread = genThread()
                    nThread.Start(New With {.thread = nThread, .Arguments = Arguments})
                End Sub,
                Nothing,
                MillisecondStartDecal,
                MillisecondPeriodInterval
            )
            ThreadTimersList.Add(timerStart)
        End If
    End Sub

    <Extension()>
    <DebuggerHidden()>
    Public Function TryCallDelegate(dDelegate As [Delegate], Invoker As Object, ParamArray Arguments() As Object) As Object
        If IsNothing(dDelegate) Then
            Return Nothing
        End If

        Dim result As Object = Nothing
        Dim IsFunction = Not dDelegate.Method.ReturnType.Name.ToLower = "void"

        Dim compilatedArgs As New List(Of Object)

        For Each arginfo In dDelegate.Method.GetParameters()
            Dim argvalue = arginfo.DefaultValue

            Try
                If Not IsNothing(Arguments(arginfo.Position)) Then
                    argvalue = Arguments(arginfo.Position)
                End If
            Catch
            End Try

            compilatedArgs.Add(argvalue)
        Next
        Try
            If IsNothing(Invoker) OrElse Not Invoker.InvokeRequired Then
                If IsFunction Then
                    result = dDelegate.DynamicInvoke(compilatedArgs.ToArray)
                Else
                    dDelegate.DynamicInvoke(compilatedArgs.ToArray)
                End If
            Else
                If IsFunction Then
                    Dim IAsyncResult As IAsyncResult = Invoker.BeginInvoke(
                        Function() As Object
                            Return dDelegate.DynamicInvoke(compilatedArgs.ToArray)
                        End Function
                    )

                    While Not IAsyncResult.IsCompleted
                        Application.DoEvents()
                        Threading.Thread.Sleep(20)
                    End While

                    result = Invoker.EndInvoke(IAsyncResult)
                Else
                    Invoker.Invoke(dDelegate, compilatedArgs.ToArray)
                End If
            End If
        Catch
        End Try

        Return result
    End Function

    Private VariableColumnsList As New Dictionary(Of String, System.Windows.Forms.ColumnHeader)

    <Extension()>
    Public Function SetVariableColumnWidth(value As ListView,
                                               VariableColPropertyIdentification As String,
                                               ByVal VariableColProvertyValueFilter As String,
                                               Optional CaseSensitive As Boolean = True) As ListView

        If Not CaseSensitive Then
            VariableColProvertyValueFilter = VariableColProvertyValueFilter.ToLower
        End If

        For Each col As System.Windows.Forms.ColumnHeader In value.Columns
            Dim propValue = ObjectPropertyValue(col, VariableColPropertyIdentification, "").ToString

            If Not CaseSensitive Then
                propValue = propValue.ToLower
            End If

            If propValue Like VariableColProvertyValueFilter Then
                If VariableColumnsList.ContainsKey(value.Name) Then
                    VariableColumnsList(value.Name) = col
                Else
                    VariableColumnsList.Add(value.Name, col)
                End If
                Exit For
            End If
        Next

        Dim proc =
             Sub(sender As Object, e As EventArgs)
                 VariableColumnsList(sender.name).Width = -2
             End Sub

        If VariableColumnsList.ContainsKey(value.Name) Then
            AddHandler value.SizeChanged, proc
        End If

        proc(value, Nothing)

        Return value
    End Function

    Public Function ObjectPropertyValue(obj As Object,
                                            PropertyName As String,
                                            Optional DefaultValue As Object = Nothing,
                                            Optional ReturnDefaultValueIfResultIsNothing As Boolean = True) As Object

        If IsNothing(obj) Then
            Return DefaultValue
        End If

        Dim props = ObjectProperties(obj)

        If props.ContainsKey(PropertyName) Then
            If IsNothing(props(PropertyName)) And ReturnDefaultValueIfResultIsNothing Then
                Return DefaultValue
            Else
                Return props(PropertyName)
            End If
        Else
            Return DefaultValue
        End If
    End Function

    <DebuggerHidden()>
    Public Function ObjectProperties(obj As Object) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)

        If IsNothing(obj) Then
            Return result
        End If

        For Each tmpProperty As System.Reflection.PropertyInfo In obj.GetType().GetProperties()
            Try
                result.Add(tmpProperty.Name, DirectCast(tmpProperty.GetValue(obj, Nothing), Object))
            Catch
                Try
                    result.Add(tmpProperty.Name, Nothing)
                Catch
                    ' The property already exists in the dictionnary Oo
                End Try
            End Try
        Next

        Return result
    End Function
End Module

'End Namespace
