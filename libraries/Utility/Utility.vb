Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public NotInheritable Class Utility
  Private Sub New()
  End Sub

  <DebuggerHidden()>
  Public Shared Function TryInvoke(invoker As Control, action As [Delegate], Optional ByRef e As Exception = Nothing) As Object
    If Not IsNothing(invoker) AndAlso invoker.InvokeRequired Then
      Try
        Return invoker.Invoke(action)
      Catch ex As Exception
        ' +1 extra life try (also called "Try off ze n00b")
        Try
          Return action.DynamicInvoke()
        Catch ex2 As Exception
          e = ex
        End Try
      End Try
    Else
      Try
        Return action.DynamicInvoke()
      Catch ex As Exception
        ' +1 extra life try (also called "Try off ze n00b")
        Try
          Return invoker.Invoke(action)
        Catch ex2 As Exception
          e = ex
        End Try
      End Try
    End If

    Return Nothing
  End Function

  Public Shared Sub WhoIsNull(values As Dictionary(Of String, Object), callback As Action(Of String))
    If Not IsNothing(values) Then
      For Each item In values
        If IsNothing(item.Value) Then
          callback(item.Key)
        End If
      Next
    Else
      callback("args(0)")
    End If
  End Sub

  Public Shared Function IsNull(ParamArray values As Object()) As Boolean
    For Each value In values
      If IsNothing(value) Then
        Return True
      End If
    Next

    Return False
  End Function

  <DebuggerHidden()>
  Public Shared Function ObjectProperties(obj As Object, Optional bindingAttr As System.Reflection.BindingFlags? = Nothing) As Dictionary(Of String, Object)
    Dim result As New Dictionary(Of String, Object)

    If IsNothing(obj) Then
      Return result
    End If

    Dim properties As New List(Of System.Reflection.PropertyInfo)

    If bindingAttr.HasValue Then
      properties = obj.GetType().GetProperties(bindingAttr.Value).ToList()
    Else
      properties = obj.GetType().GetProperties().ToList()
    End If

    For Each tmpProperty In properties
      If tmpProperty.CanRead AndAlso Not result.ContainsKey(tmpProperty.Name) AndAlso tmpProperty.GetIndexParameters().Count = 0 Then
        Try
          If TypeOf obj Is Control Then
            Dim t_tmpProperty = tmpProperty

            TryInvoke(obj,
              Sub()
                result.Add(t_tmpProperty.Name, TryCast(t_tmpProperty.GetValue(obj, Nothing), Object))
              End Sub
            )
          Else
            result.Add(tmpProperty.Name, TryCast(tmpProperty.GetValue(obj, Nothing), Object))
          End If
        Catch
          Try
            result.Add(tmpProperty.Name, Nothing)
          Catch
            ' The property already exists in the dictionnary Oo
          End Try
        End Try
      End If
    Next

    Return result
  End Function

  <DebuggerHidden()>
  Public Shared Sub ObjectChangeProperty(obj As Object, PropertyName As String, NewValue As Object)
    Dim tmpProperty As System.Reflection.PropertyInfo = Nothing

    If NewValue Is DBNull.Value Then
      NewValue = Nothing
    End If

    For Each tmpProperty In obj.GetType().GetProperties()
      If tmpProperty.Name = PropertyName Then
        Try
          If TypeOf NewValue Is String AndAlso (
            tmpProperty.PropertyType Is GetType(DateTime) OrElse tmpProperty.PropertyType Is GetType(Date)
          ) Then

            NewValue = Date.Parse(NewValue)
          End If
        Catch
        End Try

        Try
          Try
            tmpProperty.SetValue(obj, CTypeDynamic(NewValue, tmpProperty.PropertyType), Nothing)
          Catch
            tmpProperty.SetValue(obj, NewValue, Nothing)
          End Try
        Catch
          Try
            Try
              obj.Invoke(Sub() tmpProperty.SetValue(obj, CTypeDynamic(NewValue, tmpProperty.PropertyType), Nothing))
            Catch
              obj.Invoke(Sub() tmpProperty.SetValue(obj, NewValue, Nothing))
            End Try

          Catch
          End Try
        End Try
      End If
    Next
  End Sub

  Public Shared Function StrBetween(value As String, Optional strBefore As String = "", Optional strAfter As String = "", Optional InclureDelimiters As Boolean = False) As String
    If String.IsNullOrEmpty(value) Then Return ""

    If strBefore <> "" AndAlso value.Contains(strBefore) Then
      value = Mid(value, value.IndexOf(strBefore) + strBefore.Length + 1)
    End If
    If strAfter <> "" AndAlso value.Contains(strAfter) Then
      value = Mid(value, 1, value.IndexOf(strAfter))
    End If

    If InclureDelimiters Then
      value = strBefore & value & strAfter
    End If

    Return value
  End Function

  Public Shared Function ReplaceMultiple(value As String, newValue As String, ParamArray oldValues() As String) As String
    If Not String.IsNullOrEmpty(value) Then
      For Each oldValue As String In oldValues
        value = value.Replace(oldValue, newValue)
      Next
    End If

    Return value
  End Function

  Public Shared Function Repeat(value As String, count As Integer) As String
    If count <= 0 Then
      Return ""
    ElseIf value.Length = 1 Then
      Return New String(value, count)
    Else
      Dim result As String = ""

      For i = 1 To count
        result &= value
      Next

      Return result
    End If
  End Function

  Public Shared Function ToHexDump(value As String,
                                Optional charsPerLine As Integer = 19,
                                Optional RowSeparatorLength As Integer = 2) As String

    Dim result As String = ""

    For i = 1 To value.Length Step charsPerLine
      For j = 0 To charsPerLine - 1
        Dim c As String = Mid(value, i + j, 1)

        result &= If(c.Length = 1, ToHex(c), "  ") & " "
      Next

      result &= New String(" ", RowSeparatorLength - 1)

      For j = 0 To charsPerLine - 1
        Dim c As String = Mid(value, i + j, 1)

        If c.Length = 0 Then
          result &= " "
        ElseIf Asc(c) < 32 Then
          result &= "."
        Else
          result &= Mid(value, i + j, 1)
        End If
      Next

      result &= vbCrLf
    Next

    Return result.TrimEnd(vbCrLf)
  End Function

  Public Shared Function ToHex(value As String, Optional strBefore As String = "", Optional strAfter As String = "") As String
    Dim result As String = ""

    For i = 1 To value.Length
      Dim hexValue As String = Hex(Asc(Mid(value, i, 1)))
      result &= strBefore & If(hexValue.Length = 1, "0" & hexValue, hexValue) & strAfter
    Next

    Return result
  End Function

  Public Shared Function invertAlign(align As HorizontalAlignment) As HorizontalAlignment
    If align = HorizontalAlignment.Left Then
      Return HorizontalAlignment.Right
    ElseIf align = HorizontalAlignment.Right Then
      Return HorizontalAlignment.Left
    Else
      Return HorizontalAlignment.Center
    End If
  End Function

  Public Shared Function fill(value As String, fillString As String, length As Integer, Optional side As HorizontalAlignment = HorizontalAlignment.Left) As String
    For i As Integer = value.Length To length - 1 Step fillString.Length
      If side = HorizontalAlignment.Left Then
        value = fillString & value
      ElseIf side = HorizontalAlignment.Right Then
        value &= fillString
      ElseIf side = HorizontalAlignment.Center AndAlso i + fillString.Length < length Then
        value = fillString & value & fillString
        i += fillString.Length
      ElseIf side = HorizontalAlignment.Center AndAlso i + fillString.Length >= length Then
        value &= fillString
      End If
    Next

    Return value
  End Function

  Public Shared Function getXmlNodesArgs(content As String) As Dictionary(Of String, List(Of Arguments))
    Dim result As New Dictionary(Of String, List(Of Arguments))

    Dim nodesMatches = Regex.Matches(content, "<([a-zA-Z0-9]+)\s[^>]*>")

    For Each nodeMatch As Match In nodesMatches
      Dim nodeName = nodeMatch.Groups(1).Value
      If Not result.ContainsKey(nodeName) Then
        result.Add(nodeName, getXmlNodesArgs(content, nodeName))
      End If
    Next

    Return result
  End Function

  Public Shared Function ParseXml(xml As String) As XMLNodeLight
    Return XMLNodeLight.ParseXml(xml).FirstOrDefault()
  End Function

  Public Shared Function getXmlNodesArgs(content As String, nodeName As String) As List(Of Arguments)
    Dim result As New List(Of Arguments)
    If String.IsNullOrEmpty(content) Then Return result

    Dim argsMatches = Regex.Matches(content, "<" & nodeName & "\s([^>]*)>")

    For Each argsMatch As Match In argsMatches
      Dim args As New Arguments()

      Dim argMatches2 = Regex.Matches(argsMatch.Groups(0).Value, "([a-zA-Z0-9]+)=(['""])?((?(2)[^""']*|[^""'\s]*))(?(2)['""])")

      '/<([a-zA-Z0-9]+)(\s+([^/>]*))?(/)?>(?(4)|(.*?)</\1>)/msi
      '$1 : node name
      '$3 : arguments
      '$5 : content

      For Each argMatch As Match In argMatches2
        args.AddValue(argMatch.Groups(1).Value, argMatch.Groups(3).Value)
      Next

      result.Add(args)
    Next

    Return result
  End Function

  Public Shared Function GetFileContentStream(filepath As String) As IO.Stream
    If Not My.Computer.FileSystem.FileExists(filepath) Then
      Return Nothing
    End If

    Dim fileContent = My.Computer.FileSystem.ReadAllBytes(filepath)
    Dim stream = New IO.StreamWriter(New IO.MemoryStream(fileContent))
    Return stream.BaseStream
  End Function

  Public Shared Sub DictionaryCopy(Of TKey, TValue)(ByRef source As Dictionary(Of TKey, TValue),
                                                     ByRef destination As Dictionary(Of TKey, TValue),
                                                     Optional clearDestination As Boolean = True)

    If clearDestination Then
      destination.Clear()
    End If

    For Each pair In source
      If destination.ContainsKey(pair.Key) Then
        destination(pair.Key) = pair.Value
      Else
        destination.Add(pair.Key, pair.Value)
      End If
    Next
  End Sub

  Private Shared Function Increment(value As Byte, Optional decrement As Boolean = False) As Byte
    If value = Byte.MinValue AndAlso decrement Then
      Return Byte.MaxValue
    ElseIf value = Byte.MaxValue AndAlso Not decrement Then
      Return Byte.MinValue
    Else
      Return value + If(decrement, -1, 1)
    End If
  End Function

  Private Shared Function Increment(value As UShort, Optional decrement As Boolean = False) As UShort
    If value = UShort.MinValue AndAlso decrement Then
      Return UShort.MaxValue
    ElseIf value = UShort.MaxValue AndAlso Not decrement Then
      Return UShort.MinValue
    Else
      Return value + If(decrement, -1, 1)
    End If
  End Function

  '-------------
  ' brainf*ck eg:
  '
  ' MessageBox.Show(Utility.BrainFckEval(
  '    "++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+."
  ' ))
  ''------------
  Public Shared Function BrainFckEval(brainFckCode As String,
                                      Optional input As Func(Of Byte()) = Nothing) As String

    Dim memory(UShort.MaxValue + 1) As Byte
    Dim instptr As Integer = 0
    Dim ptr As UShort = 0
    Dim output As String = ""
    Dim callstack = New Stack(Of Integer)
    Dim inputBuffer = New Queue(Of Byte)
    brainFckCode = Regex.Replace(brainFckCode, "[^<>\-+.,\[\]]", "")

    Dim opCodes = New Dictionary(Of Char, Action) From {
      {">", Sub() ptr = Increment(ptr)}, {"<", Sub() ptr = Increment(ptr, True)},
      {"+", Sub() memory(ptr) = Increment(memory(ptr))}, {"-", Sub() memory(ptr) = Increment(memory(ptr), True)},
      {".", Sub() output &= Convert.ToChar(memory(ptr))},
      {"[", Sub() callstack.Push(instptr)},
      {"]", Sub() instptr = If(memory(ptr) = 0, instptr, callstack.Pop() - 1)},
      {",",
       Sub()
         If Not IsNothing(input) AndAlso inputBuffer.Count = 0 Then
           input().ToList().ForEach(Sub(b) inputBuffer.Enqueue(b))
         End If
         If Not inputBuffer.Count = 0 Then
           memory(ptr) = inputBuffer.Dequeue()
         End If
       End Sub
    }}

    While instptr < brainFckCode.Length
      opCodes(brainFckCode.ElementAt(instptr))()
      instptr += 1
    End While

    Return output
  End Function

  Public Shared Function ParseDataRow(row As DataRow, Optional overridesValueWhenDuplicate As Boolean = True) As Dictionary(Of String, Object)
    Dim data As New Dictionary(Of String, Object)

    For Each col As DataColumn In row.Table.Columns
      If Not data.ContainsKey(col.ColumnName) Then
        data.Add(col.ColumnName, row(col.ColumnName))
      ElseIf overridesValueWhenDuplicate Then
        data(col.ColumnName) = row(col.ColumnName)
      End If
    Next

    Return data
  End Function

  Public Shared Function ParseDataSetTable(table As DataTable, Optional overridesValueWhenDuplicate As Boolean = True) As List(Of Dictionary(Of String, Object))
    Dim data As New List(Of Dictionary(Of String, Object))

    For Each row In table.Rows
      data.Add(ParseDataRow(row, overridesValueWhenDuplicate))
    Next

    Return data
  End Function

  Public Shared Function ParseDataSet(dataSet As DataSet, Optional overridesValueWhenDuplicate As Boolean = True) As List(Of List(Of Dictionary(Of String, Object)))
    Dim data As New List(Of List(Of Dictionary(Of String, Object)))

    For Each table In dataSet.Tables
      data.Add(ParseDataSetTable(table, overridesValueWhenDuplicate))
    Next

    Return data
  End Function

  <DebuggerHidden()>
  Public Shared Function fetchInstanceByString(fullyQualifiedClassName As String) As Object
    Try
      Dim assembliesNames As New List(Of System.Reflection.AssemblyName)
      assembliesNames.AddRange(System.Reflection.Assembly.GetExecutingAssembly().GetReferencedAssemblies())
      assembliesNames.Add(System.Reflection.Assembly.GetCallingAssembly().GetName())
      assembliesNames.Add(System.Reflection.Assembly.GetExecutingAssembly().GetName())
      assembliesNames.Add(System.Reflection.Assembly.GetEntryAssembly().GetName())

      For Each ay In assembliesNames
        If fullyQualifiedClassName.Contains(ay.Name) Then
          Try
            Return System.Reflection.Assembly.Load(ay).CreateInstance(fullyQualifiedClassName)
          Catch
            'Throw New Exception("You may have a ""Public Sub New()"" in your Object (Without Arguments)")
          End Try
        End If
      Next
    Catch
    End Try
    Return Nothing
  End Function

  ''' <summary>
  ''' Provides directy .ForEach after Linq
  ''' </summary>
  Public Shared Function L(Of T)(linq As IEnumerable(Of T)) As List(Of T)
    Return linq.ToList()
  End Function

  Public Shared Function ObjectToXml(obj As Object,
                                     Optional relations As Dictionary(Of String, Object) = Nothing,
                                     Optional itemName As String = Nothing,
                                     Optional propertiesHasAttributs As Boolean = False,
                                     Optional maxDeep As Integer = 2,
                                     Optional includeSubClasses As Boolean = False,
                                     Optional includeNullOrEmpty As Boolean = False,
                                     Optional includeTypes As Boolean = False) As XMLNodeLight

    If Not IsNothing(obj) AndAlso String.IsNullOrEmpty(itemName) Then
      itemName = obj.GetType().Name
    End If

    If IsNothing(obj) Then
      Return If(Not String.IsNullOrEmpty(itemName), New XMLNodeLight(itemName), Nothing)
    End If

    Dim node As New XMLNodeLight(itemName)

    Dim properties = ObjectProperties(obj)

    If IsNothing(relations) Then
      relations = properties
    End If

    For Each paramName In relations.Keys
      Try
        Dim value = relations(paramName)

        If Not IsNothing(value) AndAlso properties.ContainsKey(value.ToString()) Then
          value = properties(value)
        End If

        If IsNothing(value) Then

        ElseIf value.GetType().IsPrimitive OrElse value.GetType().IsEnum OrElse TypeOf value Is String OrElse TypeOf value Is Drawing.Color Then
          Dim paramValue As String = ""

          If value.GetType().IsEnum Then
            paramValue = Val(value).ToString()
          ElseIf TypeOf value Is Drawing.Color Then
            paramValue = CType(value, Drawing.Color).Name
            If paramValue = "0" Then paramValue = ""
          Else
            paramValue = value.ToString()
          End If

          If includeNullOrEmpty OrElse (Not includeNullOrEmpty AndAlso Not String.IsNullOrEmpty(paramValue)) Then
            If Not propertiesHasAttributs Then
              Dim newNode As New XMLNodeLight(paramName, paramValue)

              If includeTypes Then
                newNode.Attributs.AddValue("type", value.GetType().FullName)
              End If

              node.AddNode(newNode)
            Else
              node.Attributs.AddValue(paramName, paramValue)
            End If
          End If
        ElseIf Not maxDeep = 0 AndAlso (TypeOf value Is IList OrElse TypeOf value Is ICollection) Then
          Dim itemsName As String = "item"

          Try
            If Not value.Count = 0 AndAlso Not IsNothing(value(0)) Then
              itemsName = value(0).GetType().Name
            End If
          Catch
          End Try
          Try
            node.AddNode(EnumerableToXML(value, paramName, itemsName, relations, propertiesHasAttributs, maxDeep - 1, includeSubClasses, includeNullOrEmpty, includeTypes))
          Catch
          End Try
        ElseIf Not maxDeep = 0 AndAlso TypeOf value Is IDictionary Then
          Try
            node.AddNode(DictionnaryToXML(value, Nothing, includeSubClasses, includeNullOrEmpty, includeTypes))
          Catch
          End Try
        ElseIf Not maxDeep = 0 AndAlso (includeSubClasses OrElse (Not includeSubClasses AndAlso Not value.GetType().IsClass)) Then
          Try
            node.AddNode(ObjectToXml(value, Nothing, paramName, propertiesHasAttributs, maxDeep - 1, includeSubClasses, includeNullOrEmpty, includeTypes))
          Catch
          End Try
        End If
      Catch ex As Exception
        Debug.Print("ObjectToXml Error : " & ex.Message)
      End Try
    Next

    Return node
  End Function

  Public Shared Function EnumerableToXML(Of T)(items As IEnumerable(Of T),
                                               Optional relations As Dictionary(Of String, Object) = Nothing,
                                               Optional listName As String = Nothing,
                                               Optional itemsName As String = Nothing,
                                               Optional propertiesHasAttributs As Boolean = False,
                                               Optional maxDeep As Integer = 2,
                                               Optional includeSubClasses As Boolean = False,
                                               Optional includeNullOrEmpty As Boolean = True,
                                               Optional includeTypes As Boolean = False) As XMLNodeLight

    If String.IsNullOrEmpty(listName) Then
      listName = GetType(T).Name & "List"
    End If

    If String.IsNullOrEmpty(itemsName) Then
      itemsName = GetType(T).Name
    End If

    Return EnumerableToXML(items, listName, itemsName, relations, propertiesHasAttributs, maxDeep, includeSubClasses, includeNullOrEmpty, includeTypes)
  End Function

  Public Shared Function EnumerableToXML(items As IEnumerable,
                                         listName As String,
                                         Optional itemsName As String = Nothing,
                                         Optional relations As Dictionary(Of String, Object) = Nothing,
                                         Optional propertiesHasAttributs As Boolean = False,
                                         Optional maxDeep As Integer = 2,
                                         Optional includeSubClasses As Boolean = False,
                                         Optional includeNullOrEmpty As Boolean = True,
                                         Optional includeTypes As Boolean = False) As XMLNodeLight

    Dim node As New XMLNodeLight(listName)

    For Each item In items
      node.AddNode(ObjectToXml(item, relations, itemsName, propertiesHasAttributs, maxDeep, includeSubClasses, includeNullOrEmpty, includeTypes))
    Next

    Return node
  End Function

  Public Shared Function DictionnaryToXML(Of TKey, TValue)(dictionnary As Dictionary(Of TKey, TValue),
                                                           Optional collectionName As String = Nothing,
                                                           Optional includeSubClasses As Boolean = False,
                                                           Optional includeNullOrEmpty As Boolean = False,
                                                           Optional includeTypes As Boolean = True) As XMLNodeLight

    If String.IsNullOrEmpty(collectionName) Then
      collectionName = "dictionnary"
    End If

    Dim node As New XMLNodeLight(collectionName)
    node.Attributs.AddValue("TKey", GetType(TKey).FullName)
    node.Attributs.AddValue("TValue", GetType(TValue).FullName)

    If Not IsNothing(dictionnary) Then
      For Each item In dictionnary

        Dim childNode As New XMLNodeLight(item.Key.ToString())
        childNode.Attributs.AddValue("type", If(IsNothing(item.Value), GetType(TValue).FullName, item.Value.GetType().FullName))

        If Not IsNothing(item.Value) AndAlso (item.Value.GetType().IsPrimitive OrElse item.Value.GetType().IsEnum OrElse TypeOf item.Value Is String OrElse TypeOf item.Value Is Drawing.Color) Then
          Dim innerValue As String = ""

          If item.Value.GetType().IsEnum Then
            innerValue = Val(item.Value).ToString()
          ElseIf TypeOf item.Value Is Drawing.Color Then
            innerValue = CType(CType(item.Value, Object), Drawing.Color).Name
            If innerValue = "0" Then innerValue = ""
          Else
            innerValue = item.Value.ToString()
          End If

          childNode.InnerText = innerValue
        Else
          childNode.InnerText = ObjectToXml(item.Value, includeNullOrEmpty:=True).InnerText
        End If

        node.AddNode(childNode)
      Next
    End If

    Return node
  End Function

#Region "Function XMLToDictionnary().."

  'Public Shared Function XMLToDictionnary(Of TKey, TValue)(xml As String) As Dictionary(Of TKey, TValue)
  '  Dim results As New Dictionary(Of TKey, TValue)

  '  Dim dicsMatches = Regex.Matches(xml, "<([a-zA-Z0-9]+)\s+TKey=""([^""]*)""\s+TValue=""([^""]*)""\s*>")

  '  For Each dicMatch As Match In dicsMatches
  '    Dim dicName = dicMatch.Groups(1).Value
  '    Dim xmlDicContent = Regex.Match(xml, "<" & dicName & "([^>]*)>(.*)</" & dicName & ">", RegexOptions.Singleline).Groups(2).Value

  '    Dim itemsMatches = Regex.Matches(xmlDicContent, "<([a-zA-Z0-9]+)\s+value=""([^""]*)""\s+type=""([^""]*)""\s+/>")

  '    For Each itemMatch As Match In itemsMatches
  '      Dim skey = itemMatch.Groups(1).Value
  '      Dim svalue = itemMatch.Groups(2).Value.Replace("&#34;", """").Replace("&lt;", "<").Replace("&gt;", ">")

  '      Dim tskey As TKey = CTypeDynamic(skey, GetType(TKey))
  '      Dim tsvalue As TValue = Nothing

  '      Dim vtype As Type = Type.GetType(itemMatch.Groups(3).Value, False, True)

  '      Dim fpdone = False

  '      If Not IsNothing(vtype) Then
  '        Try
  '          tsvalue = CTypeDynamic(svalue, vtype)
  '          fpdone = True
  '        Catch
  '        End Try
  '      End If

  '      If Not fpdone Then
  '        Try
  '          tsvalue = CTypeDynamic(svalue, GetType(TValue))
  '        Catch
  '          Try
  '            tsvalue = CTypeDynamic(Nothing, vtype)
  '          Catch
  '            Try
  '              tsvalue = CTypeDynamic(Nothing, GetType(TValue))
  '            Catch
  '            End Try
  '          End Try
  '        End Try
  '      End If

  '      If Not results.ContainsKey(tskey) Then
  '        results.Add(tskey, tsvalue)
  '      End If
  '    Next
  '  Next

  '  Return results
  'End Function

  'Public Shared Function XMLToDictionnary(xml As String) As Dictionary(Of String, Object)
  '  Return XMLToDictionnary(Of String, Object)(xml)
  'End Function

#End Region

  'Dim a = LiteralQuery("Selectionne chaque article dans _Articles où IsVisible est à vrai")
  'a = LiteralQuery("Selectionne chaque article dans _Articles où IsVisible = true")
  'a = LiteralQuery("Retourne chaque article qui n'est pas invisible et dont le nom ne commence pas par N ou n, et rajoute la 7 dans _Articles")

  'Dim a = LiteralQuery("Selectionne chaque article où IsVisible est à vrai", _Articles)
  'a = LiteralQuery("Selectionne chaque élément où IsVisible = true et dont l'id est entre 12 et 42, mais pas 38", _Articles)
  'a = LiteralQuery("Retourne chaque article visible ou qui a l'id est 5", _Articles)
  'a = LiteralQuery("Retourne chaque article qui n'est pas invisible et dont le nom ne commence pas par N ou n, et rajoute la 7", _Articles)

  Private Function LiteralQuery(query As String, values As IEnumerable) As IEnumerable(Of Object)
    Dim dataSource As IEnumerable = values
    Dim selector As Func(Of Object, Boolean) = Nothing
    Dim take As Integer? = Nothing
    Dim items As IEnumerable(Of Object) = Nothing
    Dim predicates As New List(Of Func(Of Object, Boolean))
    '
    ' Predicates
    '
    If Regex.IsMatch(query, "(o[u|ù]|est|where|is)\s+(.*)", RegexOptions.IgnoreCase) Then
      Dim predicatesPart = Regex.Match(query, "(o[u|ù]|est|where|is)\s+(.*)", RegexOptions.IgnoreCase).Groups(2).Value
      predicatesPart = Regex.Replace(predicatesPart, "(entre|between)\s+([0-9]+)\s+(et|and)\s+([0-9]+)", "$1 $2-$4", RegexOptions.IgnoreCase)
      Dim predicatesSequence = Regex.Split(predicatesPart, "\W+(o(u|r)|et|mais|and|but)\W+", RegexOptions.IgnoreCase).ToList()

      Dim lastSource As String = ""
      For Each predicate In predicatesSequence

      Next
    End If

    If Not IsNothing(dataSource) Then
      items = (From item In dataSource)
    End If

    If Not IsNothing(items) AndAlso Not predicates.Count = 0 Then
      For Each predicate In predicates
        items = items.Where(predicate)
      Next
    End If

    If Not IsNothing(items) AndAlso Not IsNothing(selector) Then
      items = items.Select(selector)
    End If

    If Not IsNothing(items) AndAlso take.HasValue Then items = items.Take(take.Value)

    Return items
  End Function
End Class