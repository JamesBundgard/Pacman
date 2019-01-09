Public Class youdieform

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles quitbutton.Click
        quit = True
        Me.Hide()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tryagain.Click
        Me.Hide()
    End Sub
End Class