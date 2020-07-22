Imports System.ComponentModel

Public Class frmMenu

    'MAIN
    Public Sub frmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Sel1.ResetText()
        Sel2.ResetText()
        Sel3.ResetText()
        Sel4.ResetText()

        Dim sel = Sel1
        Select Case menuIndex
            Case 1
                sel = Sel1
            Case 2
                sel = Sel2
            Case 3
                sel = Sel3
            Case 4
                sel = Sel4
        End Select
        sel.Text = "►"



        'Look for user accounts

        For i = 1 To 3 Step 1
            Try
                loadSave(i)

                DataImport.ClearSelection()
                DataImport.CurrentCell = DataImport(6, 1)

                Dim cursor = User1DisplayName
                Dim imgcursor = Usr1Pic

                If i = 1 Then
                    cursor = User1DisplayName
                    imgcursor = Usr1Pic
                ElseIf i = 2 Then
                    cursor = User2DisplayName
                    imgcursor = Usr2Pic
                ElseIf i = 3 Then
                    cursor = User3DisplayName
                    imgcursor = Usr3Pic
                End If


                If Not DataImport.CurrentCell.Value = "None" Then
                    Select Case DataImport.CurrentCell.Value
                        Case "Developer"
                            imgcursor.Image = My.Resources.DevelopmentUser
                        Case "User"
                            imgcursor.Image = My.Resources.User
                        Case "Corroupt"
                            imgcursor.Image = My.Resources.Corroupt
                    End Select

                    DataImport.ClearSelection()
                    DataImport.CurrentCell = DataImport(0, 1)
                    cursor.Text = DataImport.CurrentCell.Value.ToString
                Else
                    imgcursor.Image = My.Resources.NoSave
                    cursor.Text = "No Save"
                End If
            Catch ex As Exception
                frmGame.MessageEngine("ERROR: At User Validate, Menu, Load: " & ex.Message, "Error")
            End Try
        Next
    End Sub


    'CONTAINER user



    Private Sub Usr1Pic_Click(sender As Object, e As EventArgs) Handles Usr1Pic.Click
        UserHandler(1, "PreLoad")
    End Sub

    Private Sub User1DisplayName_Click(sender As Object, e As EventArgs) Handles User1DisplayName.Click
        UserHandler(1, "PreLoad")
    End Sub

    Private Sub Usr2Pic_Click(sender As Object, e As EventArgs) Handles Usr2Pic.Click
        UserHandler(2, "PreLoad")
    End Sub

    Private Sub User2DisplayName_Click(sender As Object, e As EventArgs) Handles User2DisplayName.Click
        UserHandler(2, "PreLoad")
    End Sub

    Private Sub Usr3Pic_Click(sender As Object, e As EventArgs) Handles Usr3Pic.Click
        UserHandler(3, "PreLoad")
    End Sub

    Private Sub User3DisplayName_Click(sender As Object, e As EventArgs) Handles User3DisplayName.Click
        UserHandler(3, "PreLoad")
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        UserHandler(0, "Delete")
    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        UserHandler(0, "Load")
        frmGame.Show()
        Me.Close()
    End Sub

    Private Sub txtPassfield_TextChanged(sender As Object, e As EventArgs) Handles txtPassfield.TextChanged
        UserHandler(0, "passwdchk")
    End Sub


    Public CurrentUser = 0
    Public Sub UserHandler(User, Action)
        If Not User = 0 Then
            CurrentUser = User
        End If

        Try
            Select Case Action

                Case "PreLoad"
                    btnPlay.Enabled = False
                    btnDel.Enabled = False

                    loadSave(User)
                    If DataImport(6, 1).Value = "None" Then
                        NewUser.ShowDialog()
                        frmMenu_Load(Me, EventArgs.Empty)
                    End If
                    loadSave(User)
                    DataImport.CurrentCell = DataImport(0, 1)
                    lblSelUsrName.Text = DataImport.CurrentCell.Value
                    DataImport.CurrentCell = DataImport(1, 1)
                    lblSelUsrPlaytime.Text = DataImport.CurrentCell.Value
                    DataImport.CurrentCell = DataImport(2, 1)
                    lblSelUsrCreated.Text = DataImport.CurrentCell.Value
                    DataImport.CurrentCell = DataImport(3, 1)
                    lblSelUsrLastPlayed.Text = DataImport.CurrentCell.Value
                    DataImport.CurrentCell = DataImport(4, 1)
                    lblSelUsrLoadedLvl.Text = DataImport.CurrentCell.Value
                    UserPanel.Show()

                Case "Load"
                Case "Delete"
                    Try
                        UserPanel.Hide()
                        System.IO.File.Delete("./Appdata/User" & CurrentUser & ".usr")
                        frmStart.writedefaultfile("./Appdata/User" & CurrentUser & ".usr")
                        frmMenu_Load(Me, EventArgs.Empty)
                    Catch ex As Exception

                        frmGame.MessageEngine("ERROR At Delete Save, menu: " & ex.Message, "Error")
                    End Try
                Case "Save"
                Case "passwdchk"
                    If txtPassfield.Text = DataImport(5, 1).Value Then
                        btnPlay.Enabled = True
                        btnDel.Enabled = True
                    Else
                        btnPlay.Enabled = False
                        btnDel.Enabled = False
                    End If
            End Select

        Catch ex As Exception
            frmGame.MessageEngine("ERROR At UserHandler, Menu: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub loadSave(Save As Integer)
        If Save = 0 Then
            Exit Sub
        End If
        DataImport.Rows.Clear()

        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("./AppData/User" & Save & ".usr")
            'Specify that reading from a comma-delimited file
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentRow As String()
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    DataImport.Rows.Add(currentRow) 'Add new row to data grid view'
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    frmGame.MessageEngine("ERROR: At User Validate, Menu, Load:  " & ex.Message, "Error")
                End Try
            End While

        End Using
    End Sub
    'END CONTAINER USER


    'CONTAINER menu
    Private menuIndex = 1
    Private Sub menuupdate(Dir)
        If Dir = "Up" Then
            If menuIndex = 1 Then Exit Sub
            menuIndex += -1
        ElseIf Dir = "Down" Then
            If menuIndex = 4 Then Exit Sub
            menuIndex += 1
        End If
        Sel1.ResetText()
        Sel2.ResetText()
        Sel3.ResetText()
        Sel4.ResetText()

        Dim sel = Sel1
        Select Case menuIndex
            Case 1
                sel = Sel1
            Case 2
                sel = Sel2
            Case 3
                sel = Sel3
            Case 4
                sel = Sel4
        End Select
        sel.Text = "►"



    End Sub

    'END CONTAINER menu




    'CONTAINTER misc

    Private Sub frmGame_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.BackColor = Color.Navy
    End Sub

    Private Sub frmGame_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Me.BackColor = Color.Gray
    End Sub


    Private Sub MenuTimer_Tick(sender As Object, e As EventArgs) Handles MenuTimer.Tick
        PictureBox1.Image = My.Resources.SplashLogo
        MenuOptionsPanel.Top = 300
        MenuOptionsPanel.Left = 508
        MenuOptionsPanel.Show()
    End Sub

    Private Sub frmMenu_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Computer.Audio.Stop()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) 
        End
    End Sub

    Private Sub frmMenu_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Dim key As String = e.KeyChar
        Select Case key.ToLower
            Case "*"
                If DataImport.Visible = True Then
                    DataImport.Visible = False
                Else DataImport.Visible = True
                End If
            Case "m"
                My.Computer.Audio.Stop()
            Case "w"
                menuupdate("Up")
            Case "s"
                menuupdate("Down")
            Case "-"
                MenuTimer_Tick(Me, EventArgs.Empty)
        End Select
    End Sub

    Private Sub lblAbout_MouseEnter(sender As Object, e As EventArgs) Handles lblAbout.MouseEnter
        menuIndex = 3
        Sel1.ResetText()
        Sel2.ResetText()
        Sel3.ResetText()
        Sel4.ResetText()
        Sel4.ResetText()
        Sel3.Text = "►"
    End Sub

    Private Sub lblExit_MouseEnter(sender As Object, e As EventArgs) Handles lblExit.MouseEnter
        Sel1.ResetText()
        Sel2.ResetText()
        Sel3.ResetText()
        Sel4.ResetText()
        Sel4.ResetText()
        Sel4.Text = "►"
        menuIndex = 4
    End Sub

    Private Sub lblPlay_MouseEnter(sender As Object, e As EventArgs) Handles lblPlay.MouseEnter
        Sel1.ResetText()
        Sel2.ResetText()
        Sel3.ResetText()
        Sel4.ResetText()
        Sel4.ResetText()
        Sel1.Text = "►"
        menuIndex = 1
    End Sub

    Private Sub lblOptions_MouseEnter(sender As Object, e As EventArgs) Handles lblOptions.MouseEnter
        Sel1.ResetText()
        Sel2.ResetText()
        Sel3.ResetText()
        Sel4.ResetText()
        Sel4.ResetText()
        Sel2.Text = "►"
        menuIndex = 2
    End Sub

    Private Sub lblOptions_Click(sender As Object, e As EventArgs) Handles lblOptions.Click
        menuIndex = 2

    End Sub

    Private Sub lvlPlay_Click(sender As Object, e As EventArgs) Handles lblPlay.Click
        menuIndex = 1
        If MenuOptionsPanel.Visible = True Then Panel1.Show()
    End Sub

    Private Sub lblExit_Click(sender As Object, e As EventArgs) Handles lblExit.Click
        End
    End Sub

    Private Sub lblAbout_Click(sender As Object, e As EventArgs) Handles lblAbout.Click
        menuIndex = 3
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        MenuTimer_Tick(Me, EventArgs.Empty)
    End Sub

    'END CONTAINER MISC
End Class