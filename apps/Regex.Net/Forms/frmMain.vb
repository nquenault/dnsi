 Imports System.Text.RegularExpressions
 Imports System.Runtime.InteropServices

'Namespace RegexDotNet

Public Class frmMain
    Private StatusList As New Dictionary(Of String, StatusProperties)

    Private AskMatchesUpdate As Boolean = False
    Private AskMatchUpdate As Boolean = False
    Private AskSplitUpdate As Boolean = False

    Private UpdateOnChanges As Boolean = True

	Private m_frmMinijeu as frmMinijeu
	private m_frmMemento as frmMemento
   
   <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
  Public Shared Function SetParent(ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As IntPtr
  End Function

	private readonly property frmMinijeu as frmMinijeu
		Get
			if isnothing(m_frmMinijeu) then
				m_frmMinijeu = new frmMinijeu()
			end if

			return m_frmMinijeu
		end get
	end property

	private readonly property frmMemento as frmMemento
		Get
			if isnothing(m_frmMemento) then
				m_frmMemento = new frmMemento()
			end if

			return m_frmMemento
		end get
	end property

	private m_doexit as boolean = false

	private m_lighton as system.drawing.image
	private m_lightoff as system.drawing.image
	private m_lightbroken as system.drawing.image
	private m_lightbrokenb as system.drawing.image
   
	public sub new()
		Application.EnableVisualStyles()
		InitializeComponent()
		
		msgbox("here")
      
      try
        SetParent(Me.Handle, val("%owner%"))
      catch
      end try

		'GetImageByUri("https://raw.githubusercontent.com/nquenault/dnsi/master/apps/Regex.Net/Resources/lighton.PNG",
		'	sub(image as image)
		'		m_lighton = image
		'	End sub
		')

		'GetImageByUri("https://raw.githubusercontent.com/nquenault/dnsi/master/apps/Regex.Net/Resources/lightoff.PNG",
		'	sub(image as image)
		'		m_lightoff = image
		'	End sub
		')

		'GetImageByUri("https://raw.githubusercontent.com/nquenault/dnsi/master/apps/Regex.Net/Resources/lightbroken.PNG",
		'	sub(image as image)
		'		m_lightbroken = image
		'	End sub
		')

		'GetImageByUri("https://raw.githubusercontent.com/nquenault/dnsi/master/apps/Regex.Net/Resources/lightbrokenb.PNG",
		'	sub(image as image)
		'		m_lightbrokenb = image
		'	End sub
		')
		
		'show()

		'threading.thread.queueuserworkitem(
		'	sub()
		'	end sub()
		')
	end sub

#Region "Menu Fichier..."
    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub NouvellePartieToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NouvellePartieToolStripMenuItem.Click
        frmMinijeu.Show()
    End Sub
	
    Private Sub OuvrirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OuvrirToolStripMenuItem.Click
        Dim OpenFD As New OpenFileDialog()
        With OpenFD
            .Filter = "Tous les fichiers (*.*)|*.*"
            .Title = "Ouvrir un fichier..."
            .ShowDialog()

            If Not .FileName.Trim = "" AndAlso IO.File.Exists(.FileName) Then
                Dim fileContent As String = IO.File.ReadAllText(.FileName)

                UpdateOnChanges = False

                Select Case MainTabControl.SelectedTab.Name.ToLower.Replace("tab", "")
                    Case "replace"
                        txtReplaceSource.Text = fileContent
                    Case "ismatch"
                        txtIsMatchSource.Text = fileContent
                    Case "match"
                        txtMatchSource.Text = fileContent
                    Case "matches"
                        txtMatchesSource.Text = fileContent
                    Case "split"
                        txtSplitSource.Text = fileContent
                    Case "escape"
                        txtEscapeSource.Text = fileContent
                    Case "unescape"
                        txtUnescapeSource.Text = fileContent
                End Select

                UpdateOnChanges = ExécutionInstantannToolStripMenuItem.Checked
            End If
        End With
    End Sub
#End Region

#Region "Menu Executer..."
    Private Sub ExecuterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExecuterToolStripMenuItem.Click
        ExecuteSeletedTab()
    End Sub

    Private Sub ExécutionInstantannToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExécutionInstantannToolStripMenuItem.Click
        sender.checked = Not sender.checked
        UpdateOnChanges = sender.checked

        lblInstantExec.Text = "Exécution instantanée : " & If(UpdateOnChanges, "", "des") & "activé"
    End Sub
#End Region

#Region "Menu Aide..."
    Private Sub RegexReplaceToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles RegexReplaceToolStripMenuItem1.Click
        OpenMSDN(sender.Text)
    End Sub

    Private Sub RegexIsMatchToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles RegexIsMatchToolStripMenuItem1.Click
        OpenMSDN(sender.Text)
    End Sub

    Private Sub RegexMatchToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles RegexMatchToolStripMenuItem1.Click
        OpenMSDN(sender.Text)
    End Sub

    Private Sub RegexMatchesToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles RegexMatchesToolStripMenuItem1.Click
        OpenMSDN(sender.Text)
    End Sub

    Private Sub RegexSplitToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles RegexSplitToolStripMenuItem1.Click
        OpenMSDN(sender.Text)
    End Sub

    Private Sub RegexEscapeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RegexEscapeToolStripMenuItem.Click
        OpenMSDN(sender.Text)
    End Sub

    Private Sub RegexUnescapeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RegexUnescapeToolStripMenuItem.Click
        OpenMSDN(sender.Text)
    End Sub

    Private Sub RegexOptionsToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles RegexOptionsToolStripMenuItem1.Click
        OpenMSDN("regexoptions")
    End Sub

    Private Sub RegexToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RegexToolStripMenuItem.Click
        OpenMSDN("6f7hht7k", "")
    End Sub

    Private Sub SurLeSiteDuZero2PartiesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SurLeSiteDuZero2PartiesToolStripMenuItem.Click
        Process.Start("http://www.siteduzero.com/tutoriel-3-14608-les-expressions-regulieres-partie-1-2.html")
    End Sub

    Private Sub SurRegularexpressionsinfoENToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SurRegularexpressionsinfoENToolStripMenuItem.Click
        Process.Start("http://www.regular-expressions.info/tutorial.html")
    End Sub

    Private Sub MementoSurLeSiteDuZeroToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles MementoSurLeSiteDuZeroToolStripMenuItem.Click
        Process.Start("http://www.siteduzero.com/tutoriel-3-14663-memento-des-expressions-regulieres.html")
    End Sub

    Private Sub MementoRapideToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MementoRapideToolStripMenuItem.Click
        frmMemento.Show()
    End Sub
#End Region

#Region "Menu Exemples..."
    Private Sub AdresseIPToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AdresseIPToolStripMenuItem.Click
        ShowExemple(
            "ismatch",
            "127.0.0.1",
            "\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\." &
                "(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b",
            RegexOptions.IgnoreCase +
            RegexOptions.Multiline
        )
    End Sub

    Private Sub EmailToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles EmailToolStripMenuItem1.Click
		Dim example as string = "Voici la liste des inscrits :\n"
		example &= "-----------------------------------\n"
		example &= "1) soweak@gmail.com\n"
		example &= "2) pois0n@yahoo.com\n"
		example &= "3) v1ndicator@starbucks.com\n"
		example &= "4) starshoot@deadhost.it\n"
		example &= "-----------------------------------\n"
		example &= "Pour toutes inscriptions, merci de nous contacter à l'adresse suivante :\n"
		example &= "inscription@here.de\n"

        ShowExemple(
			"ismatch",
			example.replace("\n", vbcrlf),
			"([A-Z0-9._%+-]+)@([A-Z0-9.-]+)\.([A-Z]{2,4})",
			 RegexOptions.IgnoreCase +
			 RegexOptions.Multiline
		)
    End Sub

    Private Sub EmailToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EmailToolStripMenuItem.Click
		Dim example as string = "Voici la liste des inscrits :\n"
		example &= "-----------------------------------\n"
		example &= "1) soweak@gmail.com\n"
		example &= "2) pois0n@yahoo.com\n"
		example &= "3) v1ndicator@starbucks.com\n"
		example &= "4) starshoot@deadhost.it\n"
		example &= "-----------------------------------\n"
		example &= "Pour toutes inscriptions, merci de nous contacter à l'adresse suivante :\n"
		example &= "inscription@here.de\n"

        ShowExemple(
            "match",
            example.replace("\n", vbcrlf),
            "([A-Z0-9._%+-]+)@([A-Z0-9.-]+)\.([A-Z]{2,4})",
            RegexOptions.IgnoreCase +
            RegexOptions.Multiline
        )
    End Sub

    Private Sub EmailsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EmailsToolStripMenuItem.Click
		Dim example as string = "Voici la liste des inscrits :\n"
		example &= "-----------------------------------\n"
		example &= "1) soweak@gmail.com\n"
		example &= "2) pois0n@yahoo.com\n"
		example &= "3) v1ndicator@starbucks.com\n"
		example &= "4) starshoot@deadhost.it\n"
		example &= "-----------------------------------\n"
		example &= "Pour toutes inscriptions, merci de nous contacter à l'adresse suivante :\n"
		example &= "inscription@here.de\n"

        ShowExemple(
            "matches",
            example.replace("\n", vbcrlf),
            "([A-Z0-9._%+-]+)@([A-Z0-9.-]+)\.([A-Z]{2,4})",
            RegexOptions.IgnoreCase +
            RegexOptions.Multiline
        )
    End Sub

    Private Sub EstUneAdresseEmailToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EstUneAdresseEmailToolStripMenuItem.Click
        ShowExemple(
            "ismatch",
            "username@host.com",
            "^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$",
            RegexOptions.IgnoreCase +
            RegexOptions.Multiline
        )
    End Sub

    Private Sub NomDhôteParRienToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NomDhôteParRienToolStripMenuItem.Click
		Dim example as string = "Voici la liste des inscrits :\n"
		example &= "-----------------------------------\n"
		example &= "1) soweak@gmail.com\n"
		example &= "2) pois0n@yahoo.com\n"
		example &= "3) v1ndicator@starbucks.com\n"
		example &= "4) starshoot@deadhost.it\n"
		example &= "-----------------------------------\n"
		example &= "Pour toutes inscriptions, merci de nous contacter à l'adresse suivante :\n"
		example &= "inscription@here.de\n"

        ShowExemple(
            "replace",
            example.replace("\n", vbcrlf),
            "(@)(([A-Z0-9.-]+)\.([A-Z]{2,4}))(?#Remplace tous les ""@[host].[tld]"" par "" sur http://[host].[tld]/)",
            RegexOptions.IgnoreCase +
            RegexOptions.Multiline,
            " sur http://www.$2/"
        )
    End Sub

    Private Sub CSVToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CSVToolStripMenuItem.Click
        ShowExemple(
            "split",
            "1;2;3;4;5;6;7;8;9;10;11;12;13",
            ";",
            RegexOptions.IgnoreCase +
            RegexOptions.Multiline
        )
    End Sub

    Private Sub CSVToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles CSVToolStripMenuItem1.Click
		Dim example as string = "nom;prenom;age;email"
		example &= "Deloin;Alain;49;alain.deloin@carachat.com\n"
		example &= "Ratamère;Valdi;12;pokipsy@adolescents.it\n"
		example &= "Léponge;Bob;14;lefonde@locean.pac\n"
		example &= "Pasredford;Robert;57;rp@earth.org\n"
		example &= "De Rappel;Piqure Tétanique;28;ptdr@linux.ru\n"

        ShowExemple(
            "matches",
            example.replace("\n", vbcrlf),
            "^([^;\r\n]*?);([^;\r\n]*?);([^;\r\n]*?);([^,\r\n]*?)$",
            RegexOptions.IgnoreCase +
            RegexOptions.Multiline
        )
    End Sub

    Private Sub ConditionsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ConditionsToolStripMenuItem.Click
        ShowExemple(
            "ismatch",
            "Je suis un homme agé de 26 ans!",
            "suis\sun(e)?\s(?(1)(femme\s)|(homme\s))(agé(?(1)e|)\s)?de\s[0-9]+\s?ans?(?#Essayez de changer un/une homme/femme et agé/agée)",
            RegexOptions.IgnoreCase + RegexOptions.Singleline
        )
    End Sub
#End Region

#Region "AboutBox..."
    Private Sub AProposToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AProposToolStripMenuItem.Click
		Dim message as string = "/* Regex.Net */\n"
		message &= "\n/*-=[ Merci de rapporter tous bugs à nquenault (-a-t-)gmail . com ]=-*/"

		MsgBox(message.replace("\n", vbcrlf), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Application.ProductName)
    End Sub
#End Region

#Region "Toolbar RegexOptions..."
    Private Sub ProceedRegexOptionsUpdated()
        If Not UpdateOnChanges Then Exit Sub

        ProceedEscape()
        ProceedUnescape()
        ProceedIsMatch()
        ProceedReplace()

        AskMatchesUpdate = (Not lstMatchesCaptures.Items.Count = 0 Or Not lstMatchesGroups.Items.Count = 0)
        AskMatchUpdate = (Not lstMatchGroups.Items.Count = 0 Or Not lstMatchCaptures.Items.Count = 0)
        AskSplitUpdate = (Not lstSplitResults.Items.Count = 0)

        Select Case MainTabControl.SelectedTab.Name.ToLower.Replace("tab", "")
            Case "matches"
                ProceedMatches()
                AskMatchesUpdate = False
            Case "match"
                ProceedMatch()
                AskMatchUpdate = False
            Case "split"
                ProceedSplit()
                AskSplitUpdate = False
        End Select
    End Sub

    Private Sub ToolStripButtonCultureInvariant_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButtonCultureInvariant.Click
        ProceedRegexOptionsUpdated()
    End Sub

    Private Sub ToolStripButtonExplicitCapture_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButtonExplicitCapture.Click
        ProceedRegexOptionsUpdated()
    End Sub

    Private Sub ToolStripButtonIgnoreCase_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButtonIgnoreCase.Click
        ProceedRegexOptionsUpdated()
    End Sub

    Private Sub ToolStripButtonIgnorePatternWhitespace_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButtonIgnorePatternWhitespace.Click
        ProceedRegexOptionsUpdated()
    End Sub

    Private Sub ToolStripButtonMultiline_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButtonMultiline.Click
        ProceedRegexOptionsUpdated()
    End Sub

    Private Sub ToolStripButtonRightToLeft_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButtonRightToLeft.Click
        ProceedRegexOptionsUpdated()
    End Sub

    Private Sub ToolStripButtonSingleline_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButtonSingleline.Click
        ProceedRegexOptionsUpdated()
    End Sub
#End Region

    Private Sub frmMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Text = "Regex.Net Online"

        With pbTotal
            .Visible = False
            .Style = ProgressBarStyle.Blocks
            .Value = .Minimum
        End With

        With lblStatus
            .Text = ""
            .Visible = False
        End With

        ExécutionInstantannToolStripMenuItem.Checked = UpdateOnChanges
        lblInstantExec.Text = "Exécution instantanée : " & If(UpdateOnChanges, "", "des") & "activé"
        '
        ' Set Regex.Options Menu
        '
        ToolStripButtonCultureInvariant.Checked = False
        'ECMAScriptToolStripMenuItem.Checked = False
        ToolStripButtonExplicitCapture.Checked = False
        ToolStripButtonIgnoreCase.Checked = True
        ToolStripButtonIgnorePatternWhitespace.Checked = False
        ToolStripButtonMultiline.Checked = True
        ToolStripButtonRightToLeft.Checked = False
        ToolStripButtonSingleline.Checked = False

        lstMatchGroups.SetVariableColumnWidth("Text", "Value")
        lstMatchCaptures.SetVariableColumnWidth("Text", "Value")
        lstMatchesGroups.SetVariableColumnWidth("Text", "Value")
        lstMatchesCaptures.SetVariableColumnWidth("Text", "Value")
        lstSplitResults.SetVariableColumnWidth("Text", "Value")
    End Sub

#Region "Privates methods..."
    Private Function PartialEscape(value As String) As String
        Dim result = value.ToString()

        result = Regex.Replace(result, "\t", "\t")
        result = Regex.Replace(result, "\r", "\r")
        result = Regex.Replace(result, "\n", "\n")

        Return result
    End Function

    Private Function GetRegexOptions() As RegexOptions
        Dim result As RegexOptions = RegexOptions.None

        If ToolStripButtonCultureInvariant.Checked Then
            result += RegexOptions.CultureInvariant
        End If

        'If ECMAScriptToolStripMenuItem.Checked Then
        '    result += RegexOptions.ECMAScript
        'End If

        If ToolStripButtonExplicitCapture.Checked Then
            result += RegexOptions.ExplicitCapture
        End If

        If ToolStripButtonIgnoreCase.Checked Then
            result += RegexOptions.IgnoreCase
        End If

        If ToolStripButtonIgnorePatternWhitespace.Checked Then
            result += RegexOptions.IgnorePatternWhitespace
        End If

        If ToolStripButtonMultiline.Checked Then
            result += RegexOptions.Multiline
        End If

        If ToolStripButtonRightToLeft.Checked Then
            result += RegexOptions.RightToLeft
        End If

        If ToolStripButtonSingleline.Checked Then
            result += RegexOptions.Singleline
        End If

        Return result
    End Function

    Private Sub SetRegexOptions(options As RegexOptions)
        ToolStripButtonCultureInvariant.Checked = options.HasFlag(RegexOptions.CultureInvariant)
        ToolStripButtonExplicitCapture.Checked = options.HasFlag(RegexOptions.ExplicitCapture)
        ToolStripButtonIgnoreCase.Checked = options.HasFlag(RegexOptions.IgnoreCase)
        ToolStripButtonIgnorePatternWhitespace.Checked = options.HasFlag(RegexOptions.IgnorePatternWhitespace)
        ToolStripButtonMultiline.Checked = options.HasFlag(RegexOptions.Multiline)
        ToolStripButtonRightToLeft.Checked = options.HasFlag(RegexOptions.RightToLeft)
        ToolStripButtonSingleline.Checked = options.HasFlag(RegexOptions.Singleline)
    End Sub

    Private Sub updateStatus(tabName As String,
                             Optional ByVal message As String = Nothing,
                             Optional pbVisible As Object = Nothing,
                             Optional pbValue As Object = Nothing,
                             Optional pbMaximum As Object = Nothing,
                             Optional textVisible As Object = Nothing)

        message = message.SetIfNullOrEmpty("")

        With StatusList(tabName.ToLower.Replace("tab", ""))
            If Not IsNothing(textVisible) Then
                .LabelVisible = (textVisible = True)
            End If
            If Not message = "" Then
                .LabelVisible = True
                .Text = message
            End If

            If Not IsNothing(pbVisible) Then
                .PbVisible = (pbVisible = True)
            End If

            If Not IsNothing(pbMaximum) Then
                .PbMaximum = Val(pbMaximum)
            End If

            If Not IsNothing(pbValue) Then
                .PbValue = Val(pbValue)
            End If

            TryCallDelegate(
                Sub()
                    If tabName.ToLower.Replace("tab", "") = MainTabControl.SelectedTab.Name.ToLower.Replace("tab", "") Then
                        pbTotal.Visible = .PbVisible

                        If .PbVisible Then
                            If .PbMaximum > .PbValue Then
                                pbTotal.Maximum = .PbMaximum
                                pbTotal.Value = .PbValue
                            Else
                                pbTotal.Value = .PbValue
                                pbTotal.Maximum = .PbMaximum
                            End If
                        End If

                        lblStatus.Visible = .LabelVisible
                        lblStatus.Text = .Text & " |"
                    End If
                End Sub,
                Me
            )
        End With
    End Sub

    Private Sub OpenMSDN(methodName As String,
                         Optional namespaceName As String = "System.Text.RegularExpressions",
                         Optional lang As String = Nothing)

        ' Récupère la lang système de format <languagecode2>-<contry/regioncode2> (eg: en-EN, fr-FR)
        'lang = lang.SetIfNullOrEmpty(My.Computer.Info.InstalledUICulture.Name.ToLower)
		lang = "en-EN"

        Dim link = "http:/" & "/msdn.microsoft.com/" & lang & "/library/" & namespaceName.ToLower

        If Not namespaceName = "" Then
            link &= "."
        End If

        link &= methodName.ToLower & ".aspx"

        Process.Start(link)
    End Sub

    Private Sub ExecuteSeletedTab()
        Select Case MainTabControl.SelectedTab.Name.ToLower.Replace("tab", "")
            Case "replace"
                ProceedReplace()
            Case "ismatch"
                ProceedIsMatch()
            Case "match"
                ProceedMatch()
            Case "matches"
                ProceedMatches()
            Case "split"
                ProceedSplit()
            Case "escape"
                ProceedEscape()
            Case "unescape"
                ProceedUnescape()
        End Select
    End Sub

    Private Sub ShowExemple(tabName As String,
                            source As String,
                            pattern As String,
                            options As RegexOptions,
                            Optional replacement As String = "")

        MainTabControl.SelectTab("tab" & tabName.Replace("tab", ""))

        UpdateOnChanges = False

        SetRegexOptions(options)

        Select Case tabName.Replace("tab", "").ToLower
            Case "replace"
                txtReplaceSource.Text = source
                txtReplacePattern.Text = pattern
                txtReplaceReplacement.Text = replacement
            Case "ismatch"
                txtIsMatchSource.Text = source
                txtIsMatchPattern.Text = pattern
            Case "match"
                txtMatchSource.Text = source
                txtMatchPattern.Text = pattern
            Case "matches"
                txtMatchesSource.Text = source
                txtMatchesPattern.Text = pattern
            Case "split"
                txtSplitSource.Text = source
                txtSplitPattern.Text = pattern
            Case Else
                Exit Sub
        End Select

        UpdateOnChanges = ExécutionInstantannToolStripMenuItem.Checked
        ExecuteSeletedTab()
    End Sub
#End Region

#Region "Regex.Escape..."
    Private Sub txtEscapeSource_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtEscapeSource.TextChanged
        If Not UpdateOnChanges Then Exit Sub
        ProceedEscape()
    End Sub

    <DebuggerHidden()>
    Private Sub ProceedEscape()
        Try
            txtEscapeResult.Text = Regex.Escape(txtEscapeSource.Text)
            updateStatus("tabEscape", textVisible:=False)
        Catch ex As Exception
            updateStatus("tabEscape", "Error : " & ex.Message, False)
        End Try
    End Sub
#End Region

#Region "Regex.Unescape..."
    Private Sub txtUnescapeSource_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtUnescapeSource.TextChanged
        If Not UpdateOnChanges Then Exit Sub
        ProceedUnescape()
    End Sub

    <DebuggerHidden()>
    Private Sub ProceedUnescape()
        Try
            txtUnescapeResult.Text = Regex.Unescape(txtUnescapeSource.Text)
            updateStatus("tabUnescape", textVisible:=False)
        Catch ex As Exception
            updateStatus("tabUnescape", "Error : " & ex.Message, False)
        End Try
    End Sub
#End Region

#Region "Regex.Split..."
    Private Sub txtSplitSource_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSplitSource.TextChanged
        If Not UpdateOnChanges Then Exit Sub
        ProceedSplit()
    End Sub

    Private Sub txtSplitPattern_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSplitPattern.KeyDown
        If e.KeyCode = Keys.Return Then
            ExecuteSeletedTab()
        End If
    End Sub

    Private Sub txtSplitPattern_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSplitPattern.TextChanged
        If Not UpdateOnChanges Then Exit Sub
        ProceedSplit()
    End Sub

    <DebuggerHidden()>
    Private Sub ProceedSplit()
        SimpleThreadExecute(
            Sub(threadProc As Threading.Thread)
                lstSplitResults.Items.Clear()

                Try
                    Dim results() As String = Nothing

                    TryCallDelegate(
                        Sub()
                            Try
                                results = Regex.Split(
                                    txtSplitSource.Text,
                                    txtSplitPattern.Text,
                                    GetRegexOptions()
                                )
                            Catch ex As Exception
                                updateStatus("tabSplit", "Error : " & ex.Message, False)
                            End Try
                        End Sub,
                        Me
                    )

                    If IsNothing(results) Then
                        Exit Sub
                    End If

                    Dim i As Integer
                    For i = 0 To results.Length - 1
                        updateStatus("tabSplit", "Spliting... (" & i & "/" & results.Length - 1 & ")", True, i + 1, results.Length)

                        Threading.Thread.Sleep(5)
                        Application.DoEvents()

                        If Not threadProc.IsAlive Then
                            Exit For
                        End If

                        TryCallDelegate(
                            Sub()
                                lstSplitResults.Items.Add(i)
                                If Not IsNothing(lstSplitResults.Items(i)) Then
                                    lstSplitResults.Items(i).SubItems.Add(PartialEscape(results(i)))
                                End If
                            End Sub,
                            Me
                        )
                    Next

                    updateStatus("tabSplit", pbVisible:=False, textVisible:=False)
                Catch ex As Exception
                    updateStatus("tabSplit", "Error : " & ex.Message, False)
                End Try
            End Sub,
            ThreadName:="threadSplit"
        )
    End Sub
#End Region

#Region "Regex.IsMatch..."
    Private Sub txtIsMatchPattern_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtIsMatchPattern.KeyDown
        If e.KeyCode = Keys.Return Then
            ExecuteSeletedTab()
        End If
    End Sub

    Private Sub txtIsMatchPattern_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtIsMatchPattern.TextChanged
        If Not UpdateOnChanges Then Exit Sub
        ProceedIsMatch()
    End Sub

    Private Sub txtIsMatchSource_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtIsMatchSource.TextChanged
        If Not UpdateOnChanges Then Exit Sub
        ProceedIsMatch()
    End Sub

    Private Sub SetIsMatchResult(value As Object, Optional ResizePanel As Boolean = False, Optional MaxResizePanelIsMiddle As Boolean = True)
        Dim sValue = If(TypeOf value Is Boolean, value.ToString.ToLower, "error")
        Dim filename As String = Nothing
        Dim imagesFolders = "images|theme|themes|".Split("|")

        For Each imageFolder In imagesFolders
            Dim tmpFileName = GetFileNameByBaseFileName(imageFolder & "/" & sValue, "gif|png|bmp|jpg|jpeg|tiff")
            If Not IsNothing(tmpFileName) Then
                filename = tmpFileName
                Exit For
            End If
        Next

        If Not IsNothing(filename) Then
            picIsMatchResult.Image = Bitmap.FromStream(GetFileContentStream(filename))
        ElseIf sValue = "true" Then
            picIsMatchResult.Image = m_lighton 'My.Resources.lighton
        ElseIf sValue = "false" Then
            picIsMatchResult.Image = m_lightoff 'My.Resources.lightoff
        Else
            picIsMatchResult.Image = m_lightbroken 'My.Resources.lightbroken
        End If

        If ResizePanel Then
            Dim newValue = SplitContainer4.Height - (SplitContainer4.SplitterWidth + picIsMatchResult.Image.Height)

            SplitContainer4.SplitterDistance =
                If(
                    MaxResizePanelIsMiddle,
                    Math.Max(newValue, SplitContainer4.Height / 2),
                    newValue
                )
        End If
    End Sub

    <DebuggerHidden()>
    Private Sub ProceedIsMatch()
        Try
            SetIsMatchResult(Nothing)

            Dim result = Regex.IsMatch(txtIsMatchSource.Text, txtIsMatchPattern.Text, GetRegexOptions())

            SetIsMatchResult(result)
            updateStatus("tabIsMatch", textVisible:=False)
        Catch ex As Exception
            updateStatus("tabIsMatch", "Error : " & ex.Message, False)
        End Try
    End Sub
#End Region

#Region "Regex.Replace..."
    Private Sub txtReplaceSource_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtReplaceSource.TextChanged
        If Not UpdateOnChanges Then Exit Sub
        ProceedReplace()
    End Sub

    Private Sub txtReplacePattern_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtReplacePattern.KeyDown
        If e.KeyCode = Keys.Return Then
            ExecuteSeletedTab()
        End If
    End Sub

    Private Sub txtReplacePattern_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtReplacePattern.TextChanged
        If Not UpdateOnChanges Then Exit Sub
        ProceedReplace()
    End Sub

    Private Sub txtReplaceReplacement_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtReplaceReplacement.KeyDown
        If e.KeyCode = Keys.Return Then
            ExecuteSeletedTab()
        End If
    End Sub

    Private Sub txtReplaceReplacement_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtReplaceReplacement.TextChanged
        If Not UpdateOnChanges Then Exit Sub
        ProceedReplace()
    End Sub

    <DebuggerHidden()>
    Private Sub ProceedReplace()
        SimpleThreadExecute(
                Sub()
                    TryCallDelegate(
                        Sub()
                            Try
                                txtReplaceResult.Text = Regex.Replace(
                                    txtReplaceSource.Text,
                                    txtReplacePattern.Text,
                                    txtReplaceReplacement.Text,
                                    GetRegexOptions()
                                )
                                updateStatus("tabReplace", textVisible:=False)
                            Catch ex As Exception
                                updateStatus("tabReplace", "Error : " & ex.Message, False)
                            End Try
                        End Sub,
                        Me
                    )
                End Sub
            )
    End Sub
#End Region

#Region "Regex.Match..."
    Private Sub txtMatchPattern_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtMatchPattern.KeyDown
        If e.KeyCode = Keys.Return Then
            ExecuteSeletedTab()
        End If
    End Sub

    Private Sub txtMatchPattern_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMatchPattern.TextChanged
        If Not UpdateOnChanges Then Exit Sub
        ProceedMatch()
    End Sub

    Private Sub txtMatchSource_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMatchSource.TextChanged
        If Not UpdateOnChanges Then Exit Sub
        ProceedMatch()
    End Sub

    <DebuggerHidden()>
    Private Sub ProceedMatch()
        SimpleThreadExecute(
            Sub()
                Try
                    lstMatchGroups.Items.Clear()
                    lstMatchCaptures.Items.Clear()

                    Dim results As Match = Nothing

                    TryCallDelegate(
                        Sub()
                            Try
                                results = Regex.Match(
                                    txtMatchSource.Text,
                                    txtMatchPattern.Text,
                                    GetRegexOptions()
                                )
                            Catch ex As Exception
                                updateStatus("tabMatch", "Error : " & ex.Message, False)
                            End Try
                        End Sub,
                        Me
                    )

                    If IsNothing(results) Then
                        Exit Sub
                    End If

                    Dim totalCount = results.Groups.Count + results.Captures.Count

                    With lstMatchGroups
                        Dim i As Integer
                        For i = 0 To results.Groups.Count - 1
                            updateStatus(
                                "tabMatch",
                                "Matching... (" & i & "/" & totalCount - 1 & ")",
                                True,
                                i + 1,
                                totalCount
                            )

                            Dim result = results.Groups(i)

                            TryCallDelegate(
                                Sub()
                                    .Items.Add(i)
                                    With .Items(i).SubItems
                                        .Add(result.Index)
                                        .Add(result.Length)
                                        .Add(result.Captures.Count)
                                        .Add(result.Success.ToString)
                                        .Add(PartialEscape(result.Value))
                                    End With
                                End Sub,
                                Me
                            )
                        Next
                    End With

                    With lstMatchCaptures
                        Dim i As Integer
                        For i = 0 To results.Captures.Count - 1
                            updateStatus(
                                "tabMatch",
                                "Matching... (" & results.Groups.Count + i & "/" & totalCount - 1 & ")",
                                True,
                                results.Groups.Count + i + 1,
                                totalCount
                            )

                            Dim result = results.Captures(i)

                            TryCallDelegate(
                                Sub()
                                    .Items.Add(i)
                                    With .Items(i).SubItems
                                        .Add(result.Index)
                                        .Add(result.Length)
                                        .Add(PartialEscape(result.Value))
                                    End With
                                End Sub,
                                Me
                            )
                        Next
                    End With

                    updateStatus("tabMatch", pbVisible:=False, textVisible:=False)
                Catch ex As Exception
                    updateStatus("tabMatch", "Error : " & ex.Message, False)
                End Try
            End Sub,
            ThreadName:="threadMatch"
        )
    End Sub
#End Region

#Region "Regex.Matches..."
    Private Sub txtMatchesPattern_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtMatchesPattern.KeyDown
        If e.KeyCode = Keys.Return Then
            ExecuteSeletedTab()
        End If
    End Sub
    Private Sub txtMatchesPattern_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMatchesPattern.TextChanged
        If Not UpdateOnChanges Then Exit Sub
        ProceedMatches()
    End Sub

    Private Sub txtMatchesSource_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMatchesSource.TextChanged
        If Not UpdateOnChanges Then Exit Sub
        ProceedMatches()
    End Sub

    <DebuggerHidden()>
    Private Sub ProceedMatches()
        SimpleThreadExecute(
            Sub(thread As Threading.Thread)
                Try
                    Dim matches As MatchCollection = Nothing

                    TryCallDelegate(
                        Sub()
                            lstMatchesGroups.Items.Clear()
                            lstMatchesCaptures.Items.Clear()

                            Try
                                matches = Regex.Matches(
                                    txtMatchesSource.Text,
                                    txtMatchesPattern.Text,
                                    GetRegexOptions()
                                )
                            Catch ex As Exception
                                updateStatus("tabMatches", "Error : " & ex.Message, False)
                            End Try
                        End Sub,
                        Me
                    )

                    If IsNothing(matches) Then
                        Exit Sub
                    End If

                    Dim i As Integer
                    For i = 0 To matches.Count - 1
                        If Not thread.IsAlive Then
                            Exit For
                        End If

                        updateStatus("tabMatches", "Matching... (" & i & "/" & matches.Count - 1 & ")", True, i + 1, matches.Count)

                        Dim match = matches(i)

                        With lstMatchesGroups
                            Dim group = New ListViewGroup("match_group_" & i, "Match " & i)

                            Dim j As Integer
                            For j = 0 To match.Groups.Count - 1
                                If Not thread.IsAlive Then
                                    Exit For
                                End If

                                Threading.Thread.Sleep(5)
                                Application.DoEvents()

                                Dim result = match.Groups(j)

                                Dim lstItem = New ListViewItem(group)
                                With lstItem
                                    .Text = j
                                    .Name = "item_group_" & i & "_" & j
                                    .SubItems.Add(result.Index)
                                    .SubItems.Add(result.Length)
                                    .SubItems.Add(result.Captures.Count)
                                    .SubItems.Add(result.Success.ToString)
                                    .SubItems.Add(PartialEscape(result.Value))
                                End With

                                TryCallDelegate(
                                    Sub()
                                        .Groups.Add(lstItem.Group)
                                        .Items.Add(lstItem)
                                    End Sub,
                                    Me
                                )
                            Next
                        End With

                        With lstMatchesCaptures
                            Dim group = New ListViewGroup("match_capture_" & i, "Match " & i)

                            For j = 0 To match.Captures.Count - 1
                                If Not thread.IsAlive Then
                                    Exit For
                                End If

                                Threading.Thread.Sleep(5)
                                Application.DoEvents()

                                Dim result = match.Captures(j)

                                Dim lstItem = New ListViewItem(group)
                                With lstItem
                                    .Text = j
                                    .Name = "item_capture_" & i & "_" & j
                                    .SubItems.Add(result.Index)
                                    .SubItems.Add(result.Length)
                                    .SubItems.Add(PartialEscape(result.Value))
                                End With

                                TryCallDelegate(
                                    Sub()
                                        .Groups.Add(lstItem.Group)
                                        .Items.Add(lstItem)
                                    End Sub,
                                    Me
                                )
                            Next
                        End With
                    Next

                    updateStatus("tabMatches", pbVisible:=False, textVisible:=False)
                Catch ex As Exception
                    updateStatus("tabMatches", "Error : " & ex.Message, False)
                End Try
            End Sub,
            ThreadName:="threadMatches"
        )
    End Sub
#End Region

#Region "MainTabControl Events..."
    Private Sub MainTabControl_HandleCreated(sender As Object, e As System.EventArgs) Handles MainTabControl.HandleCreated
        For i = 0 To MainTabControl.TabCount - 1
            StatusList.Add(MainTabControl.TabPages(i).Name.ToLower.Replace("tab", ""), New StatusProperties)
        Next
    End Sub

    Private Sub MainTabControl_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles MainTabControl.SelectedIndexChanged
        Dim procMsgBox =
            Function() As Boolean
                Return MsgBox(
                    "Les options des expressions régulière ont changés, voulez vous mettre à jour le résultat pour cet onglet ?",
                    MsgBoxStyle.Question + vbYesNo,
                    Application.ProductName
                ) = MsgBoxResult.Yes
            End Function

        ' Réaffiche les informations concernant l'onglet selectionné dans la barre d'état
        updateStatus(MainTabControl.SelectedTab.Name)

        ' Si il y a eu un changement d'options de Regex et que cela implique une re-évaluation...
        Select Case MainTabControl.SelectedTab.Name.ToLower
            Case "tabIsMatch".ToLower
                ProceedIsMatch()
            Case "tabMatches".ToLower
                If Not AskMatchesUpdate Then
                    Exit Sub
                ElseIf procMsgBox() Then
                    AskMatchesUpdate = False
                    ProceedMatches()
                End If
            Case "tabMatch".ToLower
                If Not AskMatchUpdate Then
                    Exit Sub
                ElseIf procMsgBox() Then
                    AskMatchUpdate = False
                    ProceedMatch()
                End If
            Case "tabSplit".ToLower
                If Not AskSplitUpdate Then
                    Exit Sub
                ElseIf procMsgBox() Then
                    AskSplitUpdate = False
                    ProceedSplit()
                End If
        End Select
    End Sub
#End Region

End Class

'End Namespace
