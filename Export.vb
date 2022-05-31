Public Class Export
    Private mappart = ""
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            btnExport.Enabled = True
        Else
            btnExport.Enabled = False
        End If
    End Sub


    Private Sub txtTitle_TextChanged(sender As Object, e As EventArgs) Handles txtTitle.TextChanged
        If txtTitle.Text = "" Then
            Me.Text = "Export"

        Else
            Me.Text = "Export - " & txtTitle.Text
            lblfileto.Text = "To: ./ClassName.vb"
        End If
        lblFamily.Text = txtTitle.Text
        lblClass.Text = txtTitle.Text & "Map" & mappart
        lblfileto.Text = "To: ./" & lblClass.Text & ".vb"
    End Sub

    Dim exitcount = 0
    Private Sub btnAddExit_Click(sender As Object, e As EventArgs) Handles btnAddExit.Click
        Dim intent = MsgBox("Exits cannot be removed, are you sure this is correct?", MessageBoxButtons.YesNo)
        If intent = vbYes Then
            txtexitsetcode.Text += vbCrLf & "'" & ExitLocName.Text & vbCrLf
            txtexitsetcode.Text += "exitSet(" & ExitX.Text & ", " & ExitY.Text & ") = "" new " & ExitName.Text & "**"
            txtexitsetcode.Text += vbCrLf & "exitName(" & ExitX.Text & ", " & ExitY.Text & ") = **" & ExitLocName.Text & "**"
            exitcount += 1

        End If
    End Sub

    Private Sub txtpart_TextChanged(sender As Object, e As EventArgs) Handles txtpart.TextChanged
        If txtpart.Text = "" Then
            mappart = ""
            txtTitle_TextChanged(Me, EventArgs.Empty)
            lblPart.Text = txtpart.Text
        Else
            mappart = "_Part" & txtpart.Text
            txtTitle_TextChanged(Me, EventArgs.Empty)
            lblPart.Text = txtpart.Text
        End If
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If CheckBox1.Checked = True Then
                If Not System.IO.Directory.Exists("./Exports") Then
                    System.IO.Directory.CreateDirectory("./Exports/")
                End If

                If Not System.IO.File.Exists(lblClass.Text & ".vb") Then
                    System.IO.File.Create("./Exports/" & lblClass.Text & ".vb").Dispose()
                Else
                    MsgBox("An export file with this class name already exists!")
                    Exit Sub
                End If

                Dim file As System.IO.StreamWriter
                file = My.Computer.FileSystem.OpenTextFileWriter("./Exports/" & lblClass.Text & ".vb", False)
                file.WriteLine("Public Class " & lblClass.Text)
                file.WriteLine("'====Map Info====")
                file.WriteLine("Public MapDrawn(10, 20)")
                file.WriteLine(vbCrLf & "Public MapName = **" & lblClass.Text & "**")
                file.WriteLine("Public MapFamily = **" & lblFamily.Text & "**")
                file.WriteLine("Public MapTrack = **CrimsonDrive**")
                file.WriteLine("Public StartX = " & txtStartX.Text)
                file.WriteLine("Public StartY = " & txtStarty.Text)
                file.WriteLine("Public MapX = " & CInt(MapSize.MaxX.Text))
                file.WriteLine("Public MapY = " & CInt(MapSize.MaxY.Text))
                file.WriteLine(vbCrLf & "'Active Components")
                file.WriteLine("Public exitSet(" & CInt(MapSize.MaxX.Text) & ", " & CInt(MapSize.MaxY.Text) & ")")
                file.WriteLine("Public exitName(" & CInt(MapSize.MaxX.Text) & ", " & CInt(MapSize.MaxY.Text) & ")")
                file.WriteLine(vbCrLf & "Public charSet(" & CInt(MapSize.MaxX.Text) & ", " & CInt(MapSize.MaxY.Text) & ") as Object")
                file.WriteLine("Public sub Initialise()")
                file.WriteLine("'Exits")
                file.Write(txtexitsetcode.Text)

                file.WriteLine(vbCrLf & "'Character Set")
                For rowcount = 0 To CInt(MapSize.MaxX.Text) Step 1
                    file.WriteLine(vbCrLf & "'Row " & rowcount)
                    For columncount = 0 To CInt(MapSize.MaxY.Text) Step 1
                        Dim style = MapDesigner.LoadedDisplayMemory(rowcount, columncount)
                        file.WriteLine("charset(" & rowcount & ", " & columncount & ") = **" & style & "**")
                    Next
                Next

                file.WriteLine("End sub")
                file.WriteLine("'Public sub StoryLine(trigger)")
                file.WriteLine("'dim story As storyEngine = new storyEngine")
                file.WriteLine("'Dim message As MessageEngine = New MessageEngine")
                file.WriteLine("'Dim display As DisplayEngine = New DisplayEngine")
                file.WriteLine("'Select case game.StoryProgress")
                file.WriteLine("'Case 1")
                file.WriteLine("'if trigger = **Load** then")
                file.WriteLine("'end if")
                file.WriteLine("'end select")
                file.WriteLine("'end sub")
                file.WriteLine("end class")
                file.Close()
                MsgBox("Done!")
                txtexitsetcode.ResetText()
                Me.Hide()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ExitX.Text = MapDesigner.selectorx
        ExitY.Text = MapDesigner.selectory
    End Sub
End Class