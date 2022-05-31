Public Class MapSize
    Private Sub maxY_LostFocus(sender As Object, e As EventArgs)
        Try
            Dim int As Integer = CInt(MaxY.Text)
        Catch ex As Exception
            MaxY.Text = "9"
            Exit Sub
        End Try


        If CInt(MaxY.Text) >= 1000 Then
            MaxY.Text = "1000"
        End If
    End Sub

    Private Sub MaxX_LostFocus(sender As Object, e As EventArgs)
        Try
            Dim int As Integer = CInt(MaxX.Text)
        Catch ex As Exception
            MaxX.Text = "9"
            Exit Sub
        End Try

        If CInt(MaxX.Text) >= 1000 Then
            MaxX.Text = "1000"
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Me.Hide()
    End Sub

    Private Sub MapSize_Load(sender As Object, e As EventArgs) Handles Me.Load
        KeyPreview = True
    End Sub

    Private Sub MapSize_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

        Select Case Asc(e.KeyChar)

            Case 37
                Button13.Select()
                Button13.PerformClick()
        End Select
    End Sub
End Class