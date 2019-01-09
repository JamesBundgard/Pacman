Public Class GameOver

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        quit = True
        Me.Hide()
    End Sub

    Private Sub RestartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartButton.Click
        Me.Hide()
    End Sub
End Class