Public Class Loading
    Private Sub Loading_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        frmGame.frmGame_Load(Me, EventArgs.Empty)
    End Sub
End Class