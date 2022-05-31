Public Class KeyMap
    Private Sub KeyMap_Load(sender As Object, e As EventArgs) Handles Me.Load
        KeyPreview = True
    End Sub

    Private Sub KeyMap_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Try
            lblChar.Text = e.KeyChar
            lblID.Text = Asc(e.KeyChar)
        Catch ex As Exception
        End Try
    End Sub
End Class