
'Namespace RegexDotNet

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    Private Sub InitializeComponent()
		dim bp as integer = 1


        Me.components = New System.ComponentModel.Container()
        'Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MainTabControl = New System.Windows.Forms.TabControl()
        Me.tabReplace = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.txtReplaceReplacement = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtReplaceSource = New System.Windows.Forms.RichTextBox()
        Me.txtReplacePattern = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtReplaceResult = New System.Windows.Forms.RichTextBox()
        Me.tabIsMatch = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.txtIsMatchSource = New System.Windows.Forms.RichTextBox()
        Me.txtIsMatchPattern = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.picIsMatchResult = New System.Windows.Forms.PictureBox()
        Me.tabMatch = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer6 = New System.Windows.Forms.SplitContainer()
        Me.txtMatchSource = New System.Windows.Forms.RichTextBox()
        Me.txtMatchPattern = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.tabGroups = New System.Windows.Forms.TabPage()
        Me.lstMatchGroups = New System.Windows.Forms.ListView()
        Me.colMatchGroupsNum = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMatchGroupsIndex = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMatchGroupsLength = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMatchGroupsCaptures = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMatchGroupsSuccess = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMatchGroupsValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tabCaptures = New System.Windows.Forms.TabPage()
        Me.lstMatchCaptures = New System.Windows.Forms.ListView()
        Me.colMatchCapturesNum = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMatchCapturesIndex = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMatchCapturesLength = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMatchCapturesValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.tabMatches = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer7 = New System.Windows.Forms.SplitContainer()
        Me.txtMatchesSource = New System.Windows.Forms.RichTextBox()
        Me.txtMatchesPattern = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TabControl3 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lstMatchesGroups = New System.Windows.Forms.ListView()
        Me.colMatchesGroupsNum = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMatchesGroupsIndex = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMatchesGroupsLength = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMatchesGroupsCaptures = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMatchesGroupsSuccess = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMatchesGroupsValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.lstMatchesCaptures = New System.Windows.Forms.ListView()
        Me.colMatchesCapturesNum = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMatchesCapturesIndex = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMatchesCapturesLength = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMatchesCapturesValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tabSplit = New System.Windows.Forms.TabPage()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.txtSplitSource = New System.Windows.Forms.RichTextBox()
        Me.txtSplitPattern = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstSplitResults = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tabEscape = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtEscapeSource = New System.Windows.Forms.RichTextBox()
        Me.txtEscapeResult = New System.Windows.Forms.RichTextBox()
        Me.tabUnescape = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.txtUnescapeSource = New System.Windows.Forms.RichTextBox()
        Me.txtUnescapeResult = New System.Windows.Forms.RichTextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.pbTotal = New System.Windows.Forms.ToolStripProgressBar()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblInstantExec = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OuvrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.MiniJeuRegexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NouvellePartieToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExecuterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExécutionInstantannToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MementoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MementoRapideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MementoSurLeSiteDuZeroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TutorielsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SurRegularexpressionsinfoENToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SurLeSiteDuZero2PartiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExemplesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReplaceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NomDhôteParRienToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IsMatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdresseIPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmailToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstUneAdresseEmailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConditionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MatchesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSVToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.LiensMSDNToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegexReplaceToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegexIsMatchToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegexMatchToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegexMatchesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegexSplitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegexEscapeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegexUnescapeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegexOptionsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.AProposToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButtonCultureInvariant = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonExplicitCapture = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonIgnoreCase = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonIgnorePatternWhitespace = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonMultiline = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonRightToLeft = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonSingleline = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.MainTabControl.SuspendLayout()
        Me.tabReplace.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        Me.tabIsMatch.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        CType(Me.picIsMatchResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMatch.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.SplitContainer6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer6.Panel1.SuspendLayout()
        Me.SplitContainer6.Panel2.SuspendLayout()
        Me.SplitContainer6.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.tabGroups.SuspendLayout()
        Me.tabCaptures.SuspendLayout()
        Me.tabMatches.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.SplitContainer7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer7.Panel1.SuspendLayout()
        Me.SplitContainer7.Panel2.SuspendLayout()
        Me.SplitContainer7.SuspendLayout()
        Me.TabControl3.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.tabSplit.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.tabEscape.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tabUnescape.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainTabControl
        '
        Me.MainTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MainTabControl.Controls.Add(Me.tabReplace)
        Me.MainTabControl.Controls.Add(Me.tabIsMatch)
        Me.MainTabControl.Controls.Add(Me.tabMatch)
        Me.MainTabControl.Controls.Add(Me.tabMatches)
        Me.MainTabControl.Controls.Add(Me.tabSplit)
        Me.MainTabControl.Controls.Add(Me.tabEscape)
        Me.MainTabControl.Controls.Add(Me.tabUnescape)
        Me.MainTabControl.ImageList = Me.ImageList1
        Me.MainTabControl.Location = New System.Drawing.Point(0, 52)
        Me.MainTabControl.Name = "MainTabControl"
        Me.MainTabControl.SelectedIndex = 0
        Me.MainTabControl.Size = New System.Drawing.Size(934, 447)
        Me.MainTabControl.TabIndex = 0
        '
        'tabReplace
        '
        Me.tabReplace.Controls.Add(Me.GroupBox3)
        Me.tabReplace.ImageIndex = 0
        Me.tabReplace.Location = New System.Drawing.Point(4, 23)
        Me.tabReplace.Name = "tabReplace"
        Me.tabReplace.Size = New System.Drawing.Size(926, 420)
        Me.tabReplace.TabIndex = 0
        Me.tabReplace.Text = "Regex.Replace"
        Me.tabReplace.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.SplitContainer5)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(926, 420)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Regex.Replace"
        '
        'SplitContainer5
        '
        Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer5.Location = New System.Drawing.Point(3, 16)
        Me.SplitContainer5.Name = "SplitContainer5"
        Me.SplitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer5.Panel1
        '
        Me.SplitContainer5.Panel1.Controls.Add(Me.txtReplaceReplacement)
        Me.SplitContainer5.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer5.Panel1.Controls.Add(Me.txtReplaceSource)
        Me.SplitContainer5.Panel1.Controls.Add(Me.txtReplacePattern)
        Me.SplitContainer5.Panel1.Controls.Add(Me.Label3)
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.Controls.Add(Me.txtReplaceResult)
        Me.SplitContainer5.Size = New System.Drawing.Size(920, 401)
        Me.SplitContainer5.SplitterDistance = 180
        Me.SplitContainer5.TabIndex = 0
        '
        'txtReplaceReplacement
        '
        Me.txtReplaceReplacement.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReplaceReplacement.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReplaceReplacement.Location = New System.Drawing.Point(58, 30)
        Me.txtReplaceReplacement.Name = "txtReplaceReplacement"
        Me.txtReplaceReplacement.Size = New System.Drawing.Size(857, 22)
        Me.txtReplaceReplacement.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Replace :"
        '
        'txtReplaceSource
        '
        Me.txtReplaceSource.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReplaceSource.DetectUrls = False
        Me.txtReplaceSource.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReplaceSource.Location = New System.Drawing.Point(8, 56)
        Me.txtReplaceSource.Name = "txtReplaceSource"
        Me.txtReplaceSource.Size = New System.Drawing.Size(907, 121)
        Me.txtReplaceSource.TabIndex = 3
        Me.txtReplaceSource.Text = ""
        '
        'txtReplacePattern
        '
        Me.txtReplacePattern.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReplacePattern.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReplacePattern.Location = New System.Drawing.Point(58, 4)
        Me.txtReplacePattern.Name = "txtReplacePattern"
        Me.txtReplacePattern.Size = New System.Drawing.Size(857, 22)
        Me.txtReplacePattern.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Pattern :"
        '
        'txtReplaceResult
        '
        Me.txtReplaceResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReplaceResult.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtReplaceResult.DetectUrls = False
        Me.txtReplaceResult.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReplaceResult.Location = New System.Drawing.Point(8, 3)
        Me.txtReplaceResult.Name = "txtReplaceResult"
        Me.txtReplaceResult.ReadOnly = True
        Me.txtReplaceResult.Size = New System.Drawing.Size(907, 211)
        Me.txtReplaceResult.TabIndex = 0
        Me.txtReplaceResult.TabStop = False
        Me.txtReplaceResult.Text = ""
        '
        'tabIsMatch
        '
        Me.tabIsMatch.Controls.Add(Me.GroupBox4)
        Me.tabIsMatch.ImageIndex = 0
        Me.tabIsMatch.Location = New System.Drawing.Point(4, 23)
        Me.tabIsMatch.Name = "tabIsMatch"
        Me.tabIsMatch.Size = New System.Drawing.Size(926, 420)
        Me.tabIsMatch.TabIndex = 1
        Me.tabIsMatch.Text = "Regex.IsMatch"
        Me.tabIsMatch.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.SplitContainer4)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(926, 420)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Regex.IsMatch"
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer4.Location = New System.Drawing.Point(3, 16)
        Me.SplitContainer4.Name = "SplitContainer4"
        Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.txtIsMatchSource)
        Me.SplitContainer4.Panel1.Controls.Add(Me.txtIsMatchPattern)
        Me.SplitContainer4.Panel1.Controls.Add(Me.Label2)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.picIsMatchResult)
        Me.SplitContainer4.Size = New System.Drawing.Size(920, 401)
        Me.SplitContainer4.SplitterDistance = 268
        Me.SplitContainer4.TabIndex = 0
        '
        'txtIsMatchSource
        '
        Me.txtIsMatchSource.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIsMatchSource.DetectUrls = False
        Me.txtIsMatchSource.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIsMatchSource.Location = New System.Drawing.Point(8, 30)
        Me.txtIsMatchSource.Name = "txtIsMatchSource"
        Me.txtIsMatchSource.Size = New System.Drawing.Size(907, 235)
        Me.txtIsMatchSource.TabIndex = 2
        Me.txtIsMatchSource.Text = ""
        '
        'txtIsMatchPattern
        '
        Me.txtIsMatchPattern.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIsMatchPattern.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIsMatchPattern.Location = New System.Drawing.Point(58, 4)
        Me.txtIsMatchPattern.Name = "txtIsMatchPattern"
        Me.txtIsMatchPattern.Size = New System.Drawing.Size(857, 22)
        Me.txtIsMatchPattern.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Pattern :"
        '
        'picIsMatchResult
        '
        Me.picIsMatchResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picIsMatchResult.BackColor = System.Drawing.Color.White
        Me.picIsMatchResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        'Me.picIsMatchResult.Image = My.Resources.Resources.lighton

		GetImageByUri("https://raw.githubusercontent.com/nquenault/dnsi/master/apps/Regex.Net/Resources/lighton.PNG",
			sub(image as image)
				Me.picIsMatchResult.Image = image
			End sub
		)

		GetIconByUri("https://raw.githubusercontent.com/nquenault/dnsi/master/apps/Regex.Net/icons/regex.ico",
			sub(icon as icon)
				me.icon = icon
			end sub
		)

        Me.picIsMatchResult.Location = New System.Drawing.Point(8, 3)
        Me.picIsMatchResult.Name = "picIsMatchResult"
        Me.picIsMatchResult.Size = New System.Drawing.Size(907, 123)
        Me.picIsMatchResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picIsMatchResult.TabIndex = 0
        Me.picIsMatchResult.TabStop = False
        '
        'tabMatch
        '
        Me.tabMatch.Controls.Add(Me.GroupBox5)
        Me.tabMatch.ImageIndex = 0
        Me.tabMatch.Location = New System.Drawing.Point(4, 23)
        Me.tabMatch.Name = "tabMatch"
        Me.tabMatch.Size = New System.Drawing.Size(926, 420)
        Me.tabMatch.TabIndex = 2
        Me.tabMatch.Text = "Regex.Match"
        Me.tabMatch.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.SplitContainer6)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(926, 420)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Regex.Match"
        '
        'SplitContainer6
        '
        Me.SplitContainer6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer6.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer6.Location = New System.Drawing.Point(3, 16)
        Me.SplitContainer6.Name = "SplitContainer6"
        Me.SplitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer6.Panel1
        '
        Me.SplitContainer6.Panel1.Controls.Add(Me.txtMatchSource)
        Me.SplitContainer6.Panel1.Controls.Add(Me.txtMatchPattern)
        Me.SplitContainer6.Panel1.Controls.Add(Me.Label5)
        '
        'SplitContainer6.Panel2
        '
        Me.SplitContainer6.Panel2.Controls.Add(Me.TabControl2)
        Me.SplitContainer6.Size = New System.Drawing.Size(920, 401)
        Me.SplitContainer6.SplitterDistance = 180
        Me.SplitContainer6.TabIndex = 0
        '
        'txtMatchSource
        '
        Me.txtMatchSource.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMatchSource.DetectUrls = False
        Me.txtMatchSource.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatchSource.Location = New System.Drawing.Point(8, 30)
        Me.txtMatchSource.Name = "txtMatchSource"
        Me.txtMatchSource.Size = New System.Drawing.Size(907, 147)
        Me.txtMatchSource.TabIndex = 2
        Me.txtMatchSource.Text = ""
        '
        'txtMatchPattern
        '
        Me.txtMatchPattern.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMatchPattern.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatchPattern.Location = New System.Drawing.Point(58, 4)
        Me.txtMatchPattern.Name = "txtMatchPattern"
        Me.txtMatchPattern.Size = New System.Drawing.Size(857, 22)
        Me.txtMatchPattern.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Pattern :"
        '
        'TabControl2
        '
        Me.TabControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl2.Controls.Add(Me.tabGroups)
        Me.TabControl2.Controls.Add(Me.tabCaptures)
        Me.TabControl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl2.ImageList = Me.ImageList1
        Me.TabControl2.Location = New System.Drawing.Point(8, 3)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(907, 211)
        Me.TabControl2.TabIndex = 0
        '
        'tabGroups
        '
        Me.tabGroups.BackColor = System.Drawing.Color.White
        Me.tabGroups.Controls.Add(Me.lstMatchGroups)
        Me.tabGroups.ImageKey = "prop.PNG"
        Me.tabGroups.Location = New System.Drawing.Point(4, 23)
        Me.tabGroups.Name = "tabGroups"
        Me.tabGroups.Size = New System.Drawing.Size(899, 184)
        Me.tabGroups.TabIndex = 0
        Me.tabGroups.Text = "Groups"
        '
        'lstMatchGroups
        '
        Me.lstMatchGroups.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colMatchGroupsNum, Me.colMatchGroupsIndex, Me.colMatchGroupsLength, Me.colMatchGroupsCaptures, Me.colMatchGroupsSuccess, Me.colMatchGroupsValue})
        Me.lstMatchGroups.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstMatchGroups.FullRowSelect = True
        Me.lstMatchGroups.GridLines = True
        Me.lstMatchGroups.HideSelection = False
        Me.lstMatchGroups.Location = New System.Drawing.Point(0, 0)
        Me.lstMatchGroups.Name = "lstMatchGroups"
        Me.lstMatchGroups.ShowGroups = False
        Me.lstMatchGroups.Size = New System.Drawing.Size(899, 184)
        Me.lstMatchGroups.TabIndex = 0
        Me.lstMatchGroups.UseCompatibleStateImageBehavior = False
        Me.lstMatchGroups.View = System.Windows.Forms.View.Details
        '
        'colMatchGroupsNum
        '
        Me.colMatchGroupsNum.Text = "#"
        Me.colMatchGroupsNum.Width = 28
        '
        'colMatchGroupsIndex
        '
        Me.colMatchGroupsIndex.Text = "Index"
        '
        'colMatchGroupsLength
        '
        Me.colMatchGroupsLength.Text = "Length"
        '
        'colMatchGroupsCaptures
        '
        Me.colMatchGroupsCaptures.Text = "Captures"
        '
        'colMatchGroupsSuccess
        '
        Me.colMatchGroupsSuccess.Text = "Success"
        '
        'colMatchGroupsValue
        '
        Me.colMatchGroupsValue.Text = "Value"
        Me.colMatchGroupsValue.Width = 349
        '
        'tabCaptures
        '
        Me.tabCaptures.BackColor = System.Drawing.Color.White
        Me.tabCaptures.Controls.Add(Me.lstMatchCaptures)
        Me.tabCaptures.ImageKey = "prop.PNG"
        Me.tabCaptures.Location = New System.Drawing.Point(4, 23)
        Me.tabCaptures.Name = "tabCaptures"
        Me.tabCaptures.Size = New System.Drawing.Size(899, 184)
        Me.tabCaptures.TabIndex = 1
        Me.tabCaptures.Text = "Captures"
        '
        'lstMatchCaptures
        '
        Me.lstMatchCaptures.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colMatchCapturesNum, Me.colMatchCapturesIndex, Me.colMatchCapturesLength, Me.colMatchCapturesValue})
        Me.lstMatchCaptures.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstMatchCaptures.FullRowSelect = True
        Me.lstMatchCaptures.GridLines = True
        Me.lstMatchCaptures.HideSelection = False
        Me.lstMatchCaptures.Location = New System.Drawing.Point(0, 0)
        Me.lstMatchCaptures.Name = "lstMatchCaptures"
        Me.lstMatchCaptures.ShowGroups = False
        Me.lstMatchCaptures.Size = New System.Drawing.Size(899, 184)
        Me.lstMatchCaptures.TabIndex = 0
        Me.lstMatchCaptures.UseCompatibleStateImageBehavior = False
        Me.lstMatchCaptures.View = System.Windows.Forms.View.Details
        '
        'colMatchCapturesNum
        '
        Me.colMatchCapturesNum.Text = "#"
        Me.colMatchCapturesNum.Width = 28
        '
        'colMatchCapturesIndex
        '
        Me.colMatchCapturesIndex.Text = "Index"
        '
        'colMatchCapturesLength
        '
        Me.colMatchCapturesLength.Text = "Length"
        '
        'colMatchCapturesValue
        '
        Me.colMatchCapturesValue.Text = "Value"
        Me.colMatchCapturesValue.Width = 400
        '
        'ImageList1
        '
        'Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.White
        'Me.ImageList1.Images.SetKeyName(0, "fct.PNG")
        'Me.ImageList1.Images.SetKeyName(1, "prop.PNG")
		GetImageByUri("https://raw.githubusercontent.com/nquenault/dnsi/master/apps/Regex.Net/Resources/fct.PNG",
			sub(image as image)
				Me.ImageList1.Images.Add(0, image)
				Me.tabReplace.refresh()
				Me.tabIsMatch.refresh()
				Me.tabMatch.refresh()
				Me.tabMatches.refresh()
				Me.tabMatches.update()
				Me.tabMatches.ResumeLayout(True)
				Me.tabSplit.refresh()
				Me.tabEscape.refresh()
				Me.tabUnescape.refresh()

				Me.Update()
				Me.Refresh()
				Me.ResumeLayout(True)
			End sub
		)

		'GetImageByUri("https://raw.githubusercontent.com/nquenault/dnsi/master/apps/Regex.Net/Resources/lighton.PNG",
		'	sub(image as image)
		'		Me.picIsMatchResult.Image = image
		'	End sub
		')

        '
        'tabMatches
        '


        Me.tabMatches.Controls.Add(Me.GroupBox6)
        Me.tabMatches.ImageIndex = 0
        Me.tabMatches.Location = New System.Drawing.Point(4, 23)
        Me.tabMatches.Name = "tabMatches"
        Me.tabMatches.Size = New System.Drawing.Size(926, 420)
        Me.tabMatches.TabIndex = 3
        Me.tabMatches.Text = "Regex.Matches"
        Me.tabMatches.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.SplitContainer7)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox6.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(926, 420)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Regex.Matches"
        '
        'SplitContainer7
        '
        Me.SplitContainer7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer7.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer7.Location = New System.Drawing.Point(3, 16)
        Me.SplitContainer7.Name = "SplitContainer7"
        Me.SplitContainer7.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer7.Panel1
        '
        Me.SplitContainer7.Panel1.Controls.Add(Me.txtMatchesSource)
        Me.SplitContainer7.Panel1.Controls.Add(Me.txtMatchesPattern)
        Me.SplitContainer7.Panel1.Controls.Add(Me.Label6)
        '
        'SplitContainer7.Panel2
        '
        Me.SplitContainer7.Panel2.Controls.Add(Me.TabControl3)
        Me.SplitContainer7.Size = New System.Drawing.Size(920, 401)
        Me.SplitContainer7.SplitterDistance = 180
        Me.SplitContainer7.TabIndex = 0
        '
        'txtMatchesSource
        '
        Me.txtMatchesSource.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMatchesSource.DetectUrls = False
        Me.txtMatchesSource.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatchesSource.Location = New System.Drawing.Point(8, 30)
        Me.txtMatchesSource.Name = "txtMatchesSource"
        Me.txtMatchesSource.Size = New System.Drawing.Size(907, 147)
        Me.txtMatchesSource.TabIndex = 2
        Me.txtMatchesSource.Text = ""
        '
        'txtMatchesPattern
        '
        Me.txtMatchesPattern.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMatchesPattern.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatchesPattern.Location = New System.Drawing.Point(58, 4)
        Me.txtMatchesPattern.Name = "txtMatchesPattern"
        Me.txtMatchesPattern.Size = New System.Drawing.Size(857, 22)
        Me.txtMatchesPattern.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Pattern :"
        '
        'TabControl3
        '
        Me.TabControl3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl3.Controls.Add(Me.TabPage3)
        Me.TabControl3.Controls.Add(Me.TabPage4)
        Me.TabControl3.ImageList = Me.ImageList1
        Me.TabControl3.Location = New System.Drawing.Point(8, 3)
        Me.TabControl3.Name = "TabControl3"
        Me.TabControl3.SelectedIndex = 0
        Me.TabControl3.Size = New System.Drawing.Size(907, 211)
        Me.TabControl3.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.White
        Me.TabPage3.Controls.Add(Me.lstMatchesGroups)
        Me.TabPage3.ImageKey = "prop.PNG"
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(899, 184)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "Groups"
        '
        'lstMatchesGroups
        '
        Me.lstMatchesGroups.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colMatchesGroupsNum, Me.colMatchesGroupsIndex, Me.colMatchesGroupsLength, Me.colMatchesGroupsCaptures, Me.colMatchesGroupsSuccess, Me.colMatchesGroupsValue})
        Me.lstMatchesGroups.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstMatchesGroups.FullRowSelect = True
        Me.lstMatchesGroups.GridLines = True
        Me.lstMatchesGroups.HideSelection = False
        Me.lstMatchesGroups.Location = New System.Drawing.Point(0, 0)
        Me.lstMatchesGroups.Name = "lstMatchesGroups"
        Me.lstMatchesGroups.Size = New System.Drawing.Size(899, 184)
        Me.lstMatchesGroups.TabIndex = 0
        Me.lstMatchesGroups.UseCompatibleStateImageBehavior = False
        Me.lstMatchesGroups.View = System.Windows.Forms.View.Details
        '
        'colMatchesGroupsNum
        '
        Me.colMatchesGroupsNum.Text = "#"
        Me.colMatchesGroupsNum.Width = 28
        '
        'colMatchesGroupsIndex
        '
        Me.colMatchesGroupsIndex.Text = "Index"
        '
        'colMatchesGroupsLength
        '
        Me.colMatchesGroupsLength.Text = "Length"
        '
        'colMatchesGroupsCaptures
        '
        Me.colMatchesGroupsCaptures.Text = "Captures"
        '
        'colMatchesGroupsSuccess
        '
        Me.colMatchesGroupsSuccess.Text = "Success"
        '
        'colMatchesGroupsValue
        '
        Me.colMatchesGroupsValue.Text = "Value"
        Me.colMatchesGroupsValue.Width = 350
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.White
        Me.TabPage4.Controls.Add(Me.lstMatchesCaptures)
        Me.TabPage4.ImageKey = "prop.PNG"
        Me.TabPage4.Location = New System.Drawing.Point(4, 23)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(899, 184)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "Captures"
        '
        'lstMatchesCaptures
        '
        Me.lstMatchesCaptures.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colMatchesCapturesNum, Me.colMatchesCapturesIndex, Me.colMatchesCapturesLength, Me.colMatchesCapturesValue})
        Me.lstMatchesCaptures.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstMatchesCaptures.FullRowSelect = True
        Me.lstMatchesCaptures.GridLines = True
        Me.lstMatchesCaptures.HideSelection = False
        Me.lstMatchesCaptures.Location = New System.Drawing.Point(0, 0)
        Me.lstMatchesCaptures.Name = "lstMatchesCaptures"
        Me.lstMatchesCaptures.Size = New System.Drawing.Size(899, 184)
        Me.lstMatchesCaptures.TabIndex = 0
        Me.lstMatchesCaptures.UseCompatibleStateImageBehavior = False
        Me.lstMatchesCaptures.View = System.Windows.Forms.View.Details
        '
        'colMatchesCapturesNum
        '
        Me.colMatchesCapturesNum.Text = "#"
        Me.colMatchesCapturesNum.Width = 28
        '
        'colMatchesCapturesIndex
        '
        Me.colMatchesCapturesIndex.Text = "Index"
        '
        'colMatchesCapturesLength
        '
        Me.colMatchesCapturesLength.Text = "Length"
        '
        'colMatchesCapturesValue
        '
        Me.colMatchesCapturesValue.Text = "Value"
        Me.colMatchesCapturesValue.Width = 481
        '
        'tabSplit
        '
        Me.tabSplit.Controls.Add(Me.GroupBox7)
        Me.tabSplit.ImageIndex = 0
        Me.tabSplit.Location = New System.Drawing.Point(4, 23)
        Me.tabSplit.Name = "tabSplit"
        Me.tabSplit.Size = New System.Drawing.Size(926, 420)
        Me.tabSplit.TabIndex = 6
        Me.tabSplit.Text = "Regex.Split"
        Me.tabSplit.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.SplitContainer3)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox7.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(926, 420)
        Me.GroupBox7.TabIndex = 0
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Regex.Split"
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.Location = New System.Drawing.Point(3, 16)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.txtSplitSource)
        Me.SplitContainer3.Panel1.Controls.Add(Me.txtSplitPattern)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.lstSplitResults)
        Me.SplitContainer3.Size = New System.Drawing.Size(920, 401)
        Me.SplitContainer3.SplitterDistance = 180
        Me.SplitContainer3.TabIndex = 0
        '
        'txtSplitSource
        '
        Me.txtSplitSource.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSplitSource.DetectUrls = False
        Me.txtSplitSource.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSplitSource.Location = New System.Drawing.Point(8, 30)
        Me.txtSplitSource.Name = "txtSplitSource"
        Me.txtSplitSource.Size = New System.Drawing.Size(907, 147)
        Me.txtSplitSource.TabIndex = 2
        Me.txtSplitSource.Text = ""
        '
        'txtSplitPattern
        '
        Me.txtSplitPattern.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSplitPattern.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSplitPattern.Location = New System.Drawing.Point(58, 4)
        Me.txtSplitPattern.Name = "txtSplitPattern"
        Me.txtSplitPattern.Size = New System.Drawing.Size(857, 22)
        Me.txtSplitPattern.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Pattern :"
        '
        'lstSplitResults
        '
        Me.lstSplitResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstSplitResults.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lstSplitResults.FullRowSelect = True
        Me.lstSplitResults.GridLines = True
        Me.lstSplitResults.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstSplitResults.HideSelection = False
        Me.lstSplitResults.Location = New System.Drawing.Point(8, 3)
        Me.lstSplitResults.Name = "lstSplitResults"
        Me.lstSplitResults.ShowGroups = False
        Me.lstSplitResults.Size = New System.Drawing.Size(907, 211)
        Me.lstSplitResults.TabIndex = 0
        Me.lstSplitResults.UseCompatibleStateImageBehavior = False
        Me.lstSplitResults.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "#"
        Me.ColumnHeader1.Width = 28
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Value"
        Me.ColumnHeader2.Width = 647
        '
        'tabEscape
        '
        Me.tabEscape.Controls.Add(Me.GroupBox1)
        Me.tabEscape.ImageIndex = 0
        Me.tabEscape.Location = New System.Drawing.Point(4, 23)
        Me.tabEscape.Name = "tabEscape"
        Me.tabEscape.Size = New System.Drawing.Size(926, 420)
        Me.tabEscape.TabIndex = 4
        Me.tabEscape.Text = "Regex.Escape"
        Me.tabEscape.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SplitContainer1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(926, 420)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Regex.Escape"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 16)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtEscapeSource)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtEscapeResult)
        Me.SplitContainer1.Size = New System.Drawing.Size(920, 401)
        Me.SplitContainer1.SplitterDistance = 180
        Me.SplitContainer1.TabIndex = 0
        '
        'txtEscapeSource
        '
        Me.txtEscapeSource.DetectUrls = False
        Me.txtEscapeSource.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEscapeSource.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEscapeSource.Location = New System.Drawing.Point(0, 0)
        Me.txtEscapeSource.Name = "txtEscapeSource"
        Me.txtEscapeSource.Size = New System.Drawing.Size(920, 180)
        Me.txtEscapeSource.TabIndex = 0
        Me.txtEscapeSource.Text = ""
        '
        'txtEscapeResult
        '
        Me.txtEscapeResult.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtEscapeResult.DetectUrls = False
        Me.txtEscapeResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEscapeResult.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEscapeResult.Location = New System.Drawing.Point(0, 0)
        Me.txtEscapeResult.Name = "txtEscapeResult"
        Me.txtEscapeResult.ReadOnly = True
        Me.txtEscapeResult.Size = New System.Drawing.Size(920, 217)
        Me.txtEscapeResult.TabIndex = 0
        Me.txtEscapeResult.Text = ""
        '
        'tabUnescape
        '
        Me.tabUnescape.Controls.Add(Me.GroupBox2)
        Me.tabUnescape.ImageIndex = 0
        Me.tabUnescape.Location = New System.Drawing.Point(4, 23)
        Me.tabUnescape.Name = "tabUnescape"
        Me.tabUnescape.Size = New System.Drawing.Size(926, 420)
        Me.tabUnescape.TabIndex = 5
        Me.tabUnescape.Text = "Regex.Unescape"
        Me.tabUnescape.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.SplitContainer2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(926, 420)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Regex.Unescape"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 16)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtUnescapeSource)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.txtUnescapeResult)
        Me.SplitContainer2.Size = New System.Drawing.Size(920, 401)
        Me.SplitContainer2.SplitterDistance = 180
        Me.SplitContainer2.TabIndex = 0
        '
        'txtUnescapeSource
        '
        Me.txtUnescapeSource.DetectUrls = False
        Me.txtUnescapeSource.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUnescapeSource.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnescapeSource.Location = New System.Drawing.Point(0, 0)
        Me.txtUnescapeSource.Name = "txtUnescapeSource"
        Me.txtUnescapeSource.Size = New System.Drawing.Size(920, 180)
        Me.txtUnescapeSource.TabIndex = 0
        Me.txtUnescapeSource.Text = ""
        '
        'txtUnescapeResult
        '
        Me.txtUnescapeResult.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUnescapeResult.DetectUrls = False
        Me.txtUnescapeResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUnescapeResult.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnescapeResult.Location = New System.Drawing.Point(0, 0)
        Me.txtUnescapeResult.Name = "txtUnescapeResult"
        Me.txtUnescapeResult.ReadOnly = True
        Me.txtUnescapeResult.Size = New System.Drawing.Size(920, 217)
        Me.txtUnescapeResult.TabIndex = 0
        Me.txtUnescapeResult.Text = ""
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pbTotal, Me.lblStatus, Me.lblInstantExec})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 502)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(934, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'pbTotal
        '
        Me.pbTotal.Name = "pbTotal"
        Me.pbTotal.Size = New System.Drawing.Size(100, 16)
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'lblInstantExec
        '
        Me.lblInstantExec.Name = "lblInstantExec"
        Me.lblInstantExec.Size = New System.Drawing.Size(0, 17)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(934, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OuvrirToolStripMenuItem, Me.ToolStripMenuItem6, Me.MiniJeuRegexToolStripMenuItem, Me.ToolStripMenuItem4, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.FileToolStripMenuItem.Text = "&Fichier"
        '
        'OuvrirToolStripMenuItem
        '
        Me.OuvrirToolStripMenuItem.Name = "OuvrirToolStripMenuItem"
        Me.OuvrirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OuvrirToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.OuvrirToolStripMenuItem.Text = "Ouvrir..."
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(164, 6)
        '
        'MiniJeuRegexToolStripMenuItem
        '
        Me.MiniJeuRegexToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NouvellePartieToolStripMenuItem})
        Me.MiniJeuRegexToolStripMenuItem.Name = "MiniJeuRegexToolStripMenuItem"
        Me.MiniJeuRegexToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.MiniJeuRegexToolStripMenuItem.Text = "Mini jeu WoR"
        '
        'NouvellePartieToolStripMenuItem
        '
        Me.NouvellePartieToolStripMenuItem.Name = "NouvellePartieToolStripMenuItem"
        Me.NouvellePartieToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NouvellePartieToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.NouvellePartieToolStripMenuItem.Text = "Nouvelle partie..."
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(164, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ExitToolStripMenuItem.Text = "&Quitter"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExecuterToolStripMenuItem, Me.ToolStripMenuItem5, Me.ExécutionInstantannToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.OptionsToolStripMenuItem.Text = "&Exécution"
        '
        'ExecuterToolStripMenuItem
        '
        'Me.ExecuterToolStripMenuItem.Image = My.Resources.Resources.run
		GetImageByUri("https://raw.githubusercontent.com/nquenault/dnsi/master/apps/Regex.Net/Resources/run.PNG",
			sub(image as image)
				Me.ExecuterToolStripMenuItem.Image = image
			End sub
		)

        Me.ExecuterToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.ExecuterToolStripMenuItem.Name = "ExecuterToolStripMenuItem"
        Me.ExecuterToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.ExecuterToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.ExecuterToolStripMenuItem.Text = "Exécuter"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(214, 6)
        '
        'ExécutionInstantannToolStripMenuItem
        '
        Me.ExécutionInstantannToolStripMenuItem.Checked = True
        Me.ExécutionInstantannToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ExécutionInstantannToolStripMenuItem.Name = "ExécutionInstantannToolStripMenuItem"
        Me.ExécutionInstantannToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10
        Me.ExécutionInstantannToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.ExécutionInstantannToolStripMenuItem.Text = "Exécution instantanée"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MementoToolStripMenuItem, Me.TutorielsToolStripMenuItem, Me.ExemplesToolStripMenuItem, Me.ToolStripMenuItem3, Me.LiensMSDNToolStripMenuItem, Me.ToolStripMenuItem2, Me.AProposToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(40, 20)
        Me.ToolStripMenuItem1.Text = "&Aide"
        '
        'MementoToolStripMenuItem
        '
        Me.MementoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MementoRapideToolStripMenuItem, Me.MementoSurLeSiteDuZeroToolStripMenuItem})
        Me.MementoToolStripMenuItem.Name = "MementoToolStripMenuItem"
        Me.MementoToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.MementoToolStripMenuItem.Text = "Memento"
        '
        'MementoRapideToolStripMenuItem
        '
        Me.MementoRapideToolStripMenuItem.Name = "MementoRapideToolStripMenuItem"
        Me.MementoRapideToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.MementoRapideToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.MementoRapideToolStripMenuItem.Text = "Memento rapide"
        '
        'MementoSurLeSiteDuZeroToolStripMenuItem
        '
        Me.MementoSurLeSiteDuZeroToolStripMenuItem.Name = "MementoSurLeSiteDuZeroToolStripMenuItem"
        Me.MementoSurLeSiteDuZeroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.MementoSurLeSiteDuZeroToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.MementoSurLeSiteDuZeroToolStripMenuItem.Text = "Memento sur le site du Zero"
        '
        'TutorielsToolStripMenuItem
        '
        Me.TutorielsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SurRegularexpressionsinfoENToolStripMenuItem, Me.SurLeSiteDuZero2PartiesToolStripMenuItem})
        Me.TutorielsToolStripMenuItem.Name = "TutorielsToolStripMenuItem"
        Me.TutorielsToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.TutorielsToolStripMenuItem.Text = "Tutoriels"
        '
        'SurRegularexpressionsinfoENToolStripMenuItem
        '
        Me.SurRegularexpressionsinfoENToolStripMenuItem.Name = "SurRegularexpressionsinfoENToolStripMenuItem"
        Me.SurRegularexpressionsinfoENToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.SurRegularexpressionsinfoENToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.SurRegularexpressionsinfoENToolStripMenuItem.Text = "regular-expressions.info (EN)"
        '
        'SurLeSiteDuZero2PartiesToolStripMenuItem
        '
        Me.SurLeSiteDuZero2PartiesToolStripMenuItem.Name = "SurLeSiteDuZero2PartiesToolStripMenuItem"
        Me.SurLeSiteDuZero2PartiesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.SurLeSiteDuZero2PartiesToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.SurLeSiteDuZero2PartiesToolStripMenuItem.Text = "Le site du Zero (2 Parties)"
        '
        'ExemplesToolStripMenuItem
        '
        Me.ExemplesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReplaceToolStripMenuItem, Me.IsMatchToolStripMenuItem, Me.MatchToolStripMenuItem, Me.MatchesToolStripMenuItem, Me.SplitToolStripMenuItem})
        Me.ExemplesToolStripMenuItem.Name = "ExemplesToolStripMenuItem"
        Me.ExemplesToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.ExemplesToolStripMenuItem.Text = "Exemples"
        '
        'ReplaceToolStripMenuItem
        '
        Me.ReplaceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NomDhôteParRienToolStripMenuItem})
        Me.ReplaceToolStripMenuItem.Name = "ReplaceToolStripMenuItem"
        Me.ReplaceToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.ReplaceToolStripMenuItem.Text = "Replace"
        '
        'NomDhôteParRienToolStripMenuItem
        '
        Me.NomDhôteParRienToolStripMenuItem.Name = "NomDhôteParRienToolStripMenuItem"
        Me.NomDhôteParRienToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.NomDhôteParRienToolStripMenuItem.Text = "@ + nom d'hôte par..."
        '
        'IsMatchToolStripMenuItem
        '
        Me.IsMatchToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdresseIPToolStripMenuItem, Me.EmailToolStripMenuItem1, Me.EstUneAdresseEmailToolStripMenuItem, Me.ConditionsToolStripMenuItem})
        Me.IsMatchToolStripMenuItem.Name = "IsMatchToolStripMenuItem"
        Me.IsMatchToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.IsMatchToolStripMenuItem.Text = "IsMatch"
        '
        'AdresseIPToolStripMenuItem
        '
        Me.AdresseIPToolStripMenuItem.Name = "AdresseIPToolStripMenuItem"
        Me.AdresseIPToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.AdresseIPToolStripMenuItem.Text = "Est une adresse IP"
        '
        'EmailToolStripMenuItem1
        '
        Me.EmailToolStripMenuItem1.Name = "EmailToolStripMenuItem1"
        Me.EmailToolStripMenuItem1.Size = New System.Drawing.Size(219, 22)
        Me.EmailToolStripMenuItem1.Text = "Contient une adresse e-mail"
        '
        'EstUneAdresseEmailToolStripMenuItem
        '
        Me.EstUneAdresseEmailToolStripMenuItem.Name = "EstUneAdresseEmailToolStripMenuItem"
        Me.EstUneAdresseEmailToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.EstUneAdresseEmailToolStripMenuItem.Text = "Est une adresse e-mail"
        '
        'ConditionsToolStripMenuItem
        '
        Me.ConditionsToolStripMenuItem.Name = "ConditionsToolStripMenuItem"
        Me.ConditionsToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ConditionsToolStripMenuItem.Text = "Conditions"
        '
        'MatchToolStripMenuItem
        '
        Me.MatchToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmailToolStripMenuItem})
        Me.MatchToolStripMenuItem.Name = "MatchToolStripMenuItem"
        Me.MatchToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.MatchToolStripMenuItem.Text = "Match"
        '
        'EmailToolStripMenuItem
        '
        Me.EmailToolStripMenuItem.Name = "EmailToolStripMenuItem"
        Me.EmailToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.EmailToolStripMenuItem.Text = "1ère adresse e-mail"
        '
        'MatchesToolStripMenuItem
        '
        Me.MatchesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmailsToolStripMenuItem, Me.CSVToolStripMenuItem1})
        Me.MatchesToolStripMenuItem.Name = "MatchesToolStripMenuItem"
        Me.MatchesToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.MatchesToolStripMenuItem.Text = "Matches"
        '
        'EmailsToolStripMenuItem
        '
        Me.EmailsToolStripMenuItem.Name = "EmailsToolStripMenuItem"
        Me.EmailsToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.EmailsToolStripMenuItem.Text = "Toutes les adresses e-mail"
        '
        'CSVToolStripMenuItem1
        '
        Me.CSVToolStripMenuItem1.Name = "CSVToolStripMenuItem1"
        Me.CSVToolStripMenuItem1.Size = New System.Drawing.Size(211, 22)
        Me.CSVToolStripMenuItem1.Text = "CSV"
        '
        'SplitToolStripMenuItem
        '
        Me.SplitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CSVToolStripMenuItem})
        Me.SplitToolStripMenuItem.Name = "SplitToolStripMenuItem"
        Me.SplitToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.SplitToolStripMenuItem.Text = "Split"
        '
        'CSVToolStripMenuItem
        '
        Me.CSVToolStripMenuItem.Name = "CSVToolStripMenuItem"
        Me.CSVToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.CSVToolStripMenuItem.Text = "Ligne CSV"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(137, 6)
        '
        'LiensMSDNToolStripMenuItem
        '
        Me.LiensMSDNToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegexToolStripMenuItem, Me.RegexReplaceToolStripMenuItem1, Me.RegexIsMatchToolStripMenuItem1, Me.RegexMatchToolStripMenuItem1, Me.RegexMatchesToolStripMenuItem1, Me.RegexSplitToolStripMenuItem1, Me.RegexEscapeToolStripMenuItem, Me.RegexUnescapeToolStripMenuItem, Me.RegexOptionsToolStripMenuItem1})
        Me.LiensMSDNToolStripMenuItem.Name = "LiensMSDNToolStripMenuItem"
        Me.LiensMSDNToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.LiensMSDNToolStripMenuItem.Text = "Liens MSDN"
        '
        'RegexToolStripMenuItem
        '
        Me.RegexToolStripMenuItem.Name = "RegexToolStripMenuItem"
        Me.RegexToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.RegexToolStripMenuItem.Text = "Regex"
        '
        'RegexReplaceToolStripMenuItem1
        '
        Me.RegexReplaceToolStripMenuItem1.Name = "RegexReplaceToolStripMenuItem1"
        Me.RegexReplaceToolStripMenuItem1.Size = New System.Drawing.Size(167, 22)
        Me.RegexReplaceToolStripMenuItem1.Text = "Regex.Replace"
        '
        'RegexIsMatchToolStripMenuItem1
        '
        Me.RegexIsMatchToolStripMenuItem1.Name = "RegexIsMatchToolStripMenuItem1"
        Me.RegexIsMatchToolStripMenuItem1.Size = New System.Drawing.Size(167, 22)
        Me.RegexIsMatchToolStripMenuItem1.Text = "Regex.IsMatch"
        '
        'RegexMatchToolStripMenuItem1
        '
        Me.RegexMatchToolStripMenuItem1.Name = "RegexMatchToolStripMenuItem1"
        Me.RegexMatchToolStripMenuItem1.Size = New System.Drawing.Size(167, 22)
        Me.RegexMatchToolStripMenuItem1.Text = "Regex.Match"
        '
        'RegexMatchesToolStripMenuItem1
        '
        Me.RegexMatchesToolStripMenuItem1.Name = "RegexMatchesToolStripMenuItem1"
        Me.RegexMatchesToolStripMenuItem1.Size = New System.Drawing.Size(167, 22)
        Me.RegexMatchesToolStripMenuItem1.Text = "Regex.Matches"
        '
        'RegexSplitToolStripMenuItem1
        '
        Me.RegexSplitToolStripMenuItem1.Name = "RegexSplitToolStripMenuItem1"
        Me.RegexSplitToolStripMenuItem1.Size = New System.Drawing.Size(167, 22)
        Me.RegexSplitToolStripMenuItem1.Text = "Regex.Split"
        '
        'RegexEscapeToolStripMenuItem
        '
        Me.RegexEscapeToolStripMenuItem.Name = "RegexEscapeToolStripMenuItem"
        Me.RegexEscapeToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.RegexEscapeToolStripMenuItem.Text = "Regex.Escape"
        '
        'RegexUnescapeToolStripMenuItem
        '
        Me.RegexUnescapeToolStripMenuItem.Name = "RegexUnescapeToolStripMenuItem"
        Me.RegexUnescapeToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.RegexUnescapeToolStripMenuItem.Text = "Regex.Unescape"
        '
        'RegexOptionsToolStripMenuItem1
        '
        Me.RegexOptionsToolStripMenuItem1.Name = "RegexOptionsToolStripMenuItem1"
        Me.RegexOptionsToolStripMenuItem1.Size = New System.Drawing.Size(167, 22)
        Me.RegexOptionsToolStripMenuItem1.Text = "Regex.Options"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(137, 6)
        '
        'AProposToolStripMenuItem
        '
        Me.AProposToolStripMenuItem.Name = "AProposToolStripMenuItem"
        Me.AProposToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.AProposToolStripMenuItem.Text = "A propos"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripButtonCultureInvariant, Me.ToolStripSeparator1, Me.ToolStripButtonExplicitCapture, Me.ToolStripSeparator3, Me.ToolStripButtonIgnoreCase, Me.ToolStripSeparator4, Me.ToolStripButtonIgnorePatternWhitespace, Me.ToolStripSeparator5, Me.ToolStripButtonMultiline, Me.ToolStripSeparator6, Me.ToolStripButtonRightToLeft, Me.ToolStripSeparator7, Me.ToolStripButtonSingleline, Me.ToolStripSeparator9})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStrip1.Size = New System.Drawing.Size(934, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(86, 22)
        Me.ToolStripLabel1.Text = "Regex.Options :"
        '
        'ToolStripButtonCultureInvariant
        '
        Me.ToolStripButtonCultureInvariant.CheckOnClick = True
        'Me.ToolStripButtonCultureInvariant.Image = My.Resources.Resources.struc
		GetImageByUri("https://raw.githubusercontent.com/nquenault/dnsi/master/apps/Regex.Net/Resources/struc.PNG",
			sub(image as image)
				Me.ToolStripButtonCultureInvariant.Image = image
				Me.ToolStripButtonExplicitCapture.Image = image
				Me.ToolStripButtonIgnoreCase.Image = image
				Me.ToolStripButtonIgnorePatternWhitespace.Image = image
				Me.ToolStripButtonMultiline.Image = image
				Me.ToolStripButtonRightToLeft.Image = image
				Me.ToolStripButtonSingleline.Image = image
			End sub
		)

        Me.ToolStripButtonCultureInvariant.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripButtonCultureInvariant.Name = "ToolStripButtonCultureInvariant"
        Me.ToolStripButtonCultureInvariant.Size = New System.Drawing.Size(106, 22)
        Me.ToolStripButtonCultureInvariant.Text = "CultureInvariant"
        'Me.ToolStripButtonCultureInvariant.ToolTipText = resources.GetString("ToolStripButtonCultureInvariant.ToolTipText")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButtonExplicitCapture
        '
        Me.ToolStripButtonExplicitCapture.CheckOnClick = True
        'Me.ToolStripButtonExplicitCapture.Image = My.Resources.Resources.struc
        Me.ToolStripButtonExplicitCapture.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripButtonExplicitCapture.Name = "ToolStripButtonExplicitCapture"
        Me.ToolStripButtonExplicitCapture.Size = New System.Drawing.Size(99, 22)
        Me.ToolStripButtonExplicitCapture.Text = "ExplicitCapture"
        'Me.ToolStripButtonExplicitCapture.ToolTipText = resources.GetString("ToolStripButtonExplicitCapture.ToolTipText")
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButtonIgnoreCase
        '
        Me.ToolStripButtonIgnoreCase.Checked = True
        Me.ToolStripButtonIgnoreCase.CheckOnClick = True
        Me.ToolStripButtonIgnoreCase.CheckState = System.Windows.Forms.CheckState.Checked
        'Me.ToolStripButtonIgnoreCase.Image = My.Resources.Resources.struc
        Me.ToolStripButtonIgnoreCase.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripButtonIgnoreCase.Name = "ToolStripButtonIgnoreCase"
        Me.ToolStripButtonIgnoreCase.Size = New System.Drawing.Size(83, 22)
        Me.ToolStripButtonIgnoreCase.Text = "IgnoreCase"
        Me.ToolStripButtonIgnoreCase.ToolTipText = "Spécifie la correspondance qui ne respecte pas la casse."
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButtonIgnorePatternWhitespace
        '
        Me.ToolStripButtonIgnorePatternWhitespace.CheckOnClick = True
        'Me.ToolStripButtonIgnorePatternWhitespace.Image = My.Resources.Resources.struc
        Me.ToolStripButtonIgnorePatternWhitespace.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripButtonIgnorePatternWhitespace.Name = "ToolStripButtonIgnorePatternWhitespace"
        Me.ToolStripButtonIgnorePatternWhitespace.Size = New System.Drawing.Size(151, 22)
        Me.ToolStripButtonIgnorePatternWhitespace.Text = "IgnorePatternWhitespace"
        'Me.ToolStripButtonIgnorePatternWhitespace.ToolTipText = resources.GetString("ToolStripButtonIgnorePatternWhitespace.ToolTipText")
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButtonMultiline
        '
        Me.ToolStripButtonMultiline.Checked = True
        Me.ToolStripButtonMultiline.CheckOnClick = True
        Me.ToolStripButtonMultiline.CheckState = System.Windows.Forms.CheckState.Checked
        'Me.ToolStripButtonMultiline.Image = My.Resources.Resources.struc
        Me.ToolStripButtonMultiline.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripButtonMultiline.Name = "ToolStripButtonMultiline"
        Me.ToolStripButtonMultiline.Size = New System.Drawing.Size(65, 22)
        Me.ToolStripButtonMultiline.Text = "Multiline"
        'Me.ToolStripButtonMultiline.ToolTipText = resources.GetString("ToolStripButtonMultiline.ToolTipText")
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButtonRightToLeft
        '
        Me.ToolStripButtonRightToLeft.CheckOnClick = True
        'Me.ToolStripButtonRightToLeft.Image = My.Resources.Resources.struc
        Me.ToolStripButtonRightToLeft.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripButtonRightToLeft.Name = "ToolStripButtonRightToLeft"
        Me.ToolStripButtonRightToLeft.Size = New System.Drawing.Size(83, 22)
        Me.ToolStripButtonRightToLeft.Text = "RightToLeft"
        Me.ToolStripButtonRightToLeft.ToolTipText = "Spécifie que la recherche sera effectuée de droite à gauche et non de gauche à dr" & _
    "oite."
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButtonSingleline
        '
        Me.ToolStripButtonSingleline.CheckOnClick = True
        'Me.ToolStripButtonSingleline.Image = My.Resources.Resources.struc
        Me.ToolStripButtonSingleline.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripButtonSingleline.Name = "ToolStripButtonSingleline"
        Me.ToolStripButtonSingleline.Size = New System.Drawing.Size(71, 22)
        Me.ToolStripButtonSingleline.Text = "Singleline"
        Me.ToolStripButtonSingleline.ToolTipText = "Spécifie le mode à ligne simple." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Modifie la signification du point (.) de sorte " & _
    "qu'il corresponde à chaque caractère (et non à chaque caractère sauf \n)."
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 524)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MainTabControl)
        'Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Regex .Net"
        Me.MainTabControl.ResumeLayout(False)
        Me.tabReplace.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel1.PerformLayout()
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer5.ResumeLayout(False)
        Me.tabIsMatch.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel1.PerformLayout()
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        CType(Me.picIsMatchResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMatch.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.SplitContainer6.Panel1.ResumeLayout(False)
        Me.SplitContainer6.Panel1.PerformLayout()
        Me.SplitContainer6.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer6.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.tabGroups.ResumeLayout(False)
        Me.tabCaptures.ResumeLayout(False)
        Me.tabMatches.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.SplitContainer7.Panel1.ResumeLayout(False)
        Me.SplitContainer7.Panel1.PerformLayout()
        Me.SplitContainer7.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer7.ResumeLayout(False)
        Me.TabControl3.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.tabSplit.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.tabEscape.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.tabUnescape.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainTabControl As System.Windows.Forms.TabControl
    Friend WithEvents tabReplace As System.Windows.Forms.TabPage
    Friend WithEvents tabIsMatch As System.Windows.Forms.TabPage
    Friend WithEvents tabMatch As System.Windows.Forms.TabPage
    Friend WithEvents tabMatches As System.Windows.Forms.TabPage
    Friend WithEvents tabSplit As System.Windows.Forms.TabPage
    Friend WithEvents tabEscape As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tabUnescape As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtEscapeSource As System.Windows.Forms.RichTextBox
    Friend WithEvents txtEscapeResult As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtUnescapeSource As System.Windows.Forms.RichTextBox
    Friend WithEvents txtUnescapeResult As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtSplitSource As System.Windows.Forms.RichTextBox
    Friend WithEvents txtSplitPattern As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstSplitResults As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIsMatchPattern As System.Windows.Forms.TextBox
    Friend WithEvents txtIsMatchSource As System.Windows.Forms.RichTextBox
    Friend WithEvents SplitContainer5 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtReplaceSource As System.Windows.Forms.RichTextBox
    Friend WithEvents txtReplacePattern As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtReplaceResult As System.Windows.Forms.RichTextBox
    Friend WithEvents txtReplaceReplacement As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer6 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtMatchSource As System.Windows.Forms.RichTextBox
    Friend WithEvents txtMatchPattern As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents tabGroups As System.Windows.Forms.TabPage
    Friend WithEvents lstMatchGroups As System.Windows.Forms.ListView
    Friend WithEvents colMatchGroupsNum As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMatchGroupsIndex As System.Windows.Forms.ColumnHeader
    Friend WithEvents tabCaptures As System.Windows.Forms.TabPage
    Friend WithEvents lstMatchCaptures As System.Windows.Forms.ListView
    Friend WithEvents colMatchCapturesNum As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMatchGroupsLength As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMatchGroupsCaptures As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMatchGroupsSuccess As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMatchGroupsValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMatchCapturesIndex As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMatchCapturesLength As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMatchCapturesValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents SplitContainer7 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtMatchesSource As System.Windows.Forms.RichTextBox
    Friend WithEvents txtMatchesPattern As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TabControl3 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents lstMatchesGroups As System.Windows.Forms.ListView
    Friend WithEvents colMatchesGroupsNum As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMatchesGroupsIndex As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMatchesGroupsLength As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMatchesGroupsCaptures As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents lstMatchesCaptures As System.Windows.Forms.ListView
    Friend WithEvents colMatchesGroupsSuccess As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMatchesGroupsValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMatchesCapturesNum As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMatchesCapturesIndex As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMatchesCapturesLength As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMatchesCapturesValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents pbTotal As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblInstantExec As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MiniJeuRegexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NouvellePartieToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExecuterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExécutionInstantannToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MementoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MementoRapideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MementoSurLeSiteDuZeroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TutorielsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SurRegularexpressionsinfoENToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SurLeSiteDuZero2PartiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExemplesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReplaceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NomDhôteParRienToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IsMatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdresseIPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmailToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstUneAdresseEmailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MatchesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CSVToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CSVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LiensMSDNToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegexReplaceToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegexIsMatchToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegexMatchToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegexMatchesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegexSplitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegexEscapeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegexUnescapeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegexOptionsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AProposToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonCultureInvariant As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonExplicitCapture As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonIgnoreCase As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonIgnorePatternWhitespace As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonMultiline As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonRightToLeft As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonSingleline As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents picIsMatchResult As System.Windows.Forms.PictureBox
    Friend WithEvents ConditionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents OuvrirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator

End Class

'End Namespace
