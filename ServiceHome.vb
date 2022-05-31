Public Class ServiceHome

    Private Sub GenMap_Click(sender As Object, e As EventArgs) Handles GenMap.Click
        Me.Hide()
        MapDesigner.LoadType = "LoadNew"
        MapDesigner.ShowDialog()
        Me.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        KeyMap.ShowDialog()
    End Sub

    Private Sub btnIdGen_Click(sender As Object, e As EventArgs) Handles btnIdGen.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        MapDesigner.LoadType = "LoadActive"
        MapSize.ShowDialog()
        MapDesigner.ShowDialog()
        Me.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        MapDesigner.LoadType = "LoadExisting"
        MapDesigner.ShowDialog()
        Me.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        End
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub
End Class