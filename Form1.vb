Public Class Form1
    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Select Case Asc(e.KeyChar)
            Case 32
                Dim output = Rnd() * Math.PI * 100

                lbloutput.Text = Math.Round(output, 0)
                lblunrounded.Text = output
        End Select
    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        ServiceHome.Show()
    End Sub

End Class