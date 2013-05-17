
'Namespace RegexDotNet

Public Class frmMinijeu
    Private StatusList As New List(Of String)

    Private intervalMin As Integer = 400
    Private intervalMax As Integer = 2400

    Private Sub frmMinijeu_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        With lblGameOver
            .Visible = False
            .Text = "GAME OVER ! Retournes bosser !"
        End With

        With lblStatus
            .Visible = Not lblGameOver.Visible
            .Text = ""
        End With

        With pbLoading
            .Visible = Not lblGameOver.Visible
            .Value = .Minimum
            .Style = ProgressBarStyle.Blocks
        End With

        With StatusList
            .Clear()
            .Add("Chargement des icônes...")
            .Add("Chargement des menus...")
            .Add("Chargement des textures...")
            .Add("Téléchargement des antécédents judiciaire du joueur...")
            .Add("Transfert de fonds vers la suisse...")
            .Add("Chargement des bugs...")
            .Add("Chargement des éléments de la matrice...")
            .Add("Chargement des méchants ennemies pas beaux...")
            .Add("Chargement de rien du tout...")
            .Add("Envoi d'un email dans l'espace...")
            .Add("Recalibrage des effets de l'eau sur la lune...")
            .Add("Souriez vous êtes filmé...")
            .Add("Démarrage du jeu...")
        End With
    End Sub

    Private Sub frmMinijeu_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        SimpleThreadExecute(
            Sub()
                pbLoading.Maximum = StatusList.Count - 1

                For i = 0 To StatusList.Count - 1
                    Dim sleepTime = Rand(intervalMax, intervalMin)
                    lblStatus.Text = StatusList(i) ' & " (" & sleepTime & "ms)"
                    pbLoading.Value = i

                    Application.DoEvents()
                    Threading.Thread.Sleep(sleepTime)
                Next

                Application.DoEvents()
                Threading.Thread.Sleep(Rand(intervalMax, intervalMin))
            End Sub,
            OnCompleted:=
                Sub()
                    lblGameOver.Visible = True
                    lblStatus.Visible = Not lblGameOver.Visible
                    pbLoading.Visible = Not lblGameOver.Visible
                End Sub,
            Invoker:=Me
        )
    End Sub
End Class

'End Namespace