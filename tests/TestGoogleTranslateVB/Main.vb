Imports NQuenault.Utility

Public Class Main

    Public Sub New()
        Application.EnableVisualStyles()
        InitializeComponent()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
		result.text = GoogleTranslate.Translate(source.text, tl.text)
    End Sub

End Class
