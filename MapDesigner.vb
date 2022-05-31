Imports System.ComponentModel

Public Class MapDesigner
    Public selectedTile = "PathBlack"
    Public SecondaryTile = "TreeNew"
    Public selectorx = 1
    Public selectory = 1
    Public map(1000, 1000)
    Public fillsize = 1

    Public LoadType
    Private Sub MapDesigner_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim cursor As PictureBox
        Erase ActiveDisplayMemory, LoadedDisplayMemory
        Erase ActiveDisplayMemory, LoadedDisplayMemory
        Erase ActiveDisplayMemory, LoadedDisplayMemory
        Erase ActiveDisplayMemory, LoadedDisplayMemory
        ReDim ActiveDisplayMemory(10, 20)
        ReDim LoadedDisplayMemory(1000, 1000)
        Label3.Text = "Fill size: " & fillsize + 2
        itemlist.Items.Add("PathAxe")
        itemlist.Items.Add("PickAxe")
        itemlist.Items.Add("SaveNew")
        itemlist.Items.Add("PathExit")
        itemlist.Items.Add("PathBlack")
        itemlist.Items.Add("RockBig")
        itemlist.Items.Add("RockSmall")
        itemlist.Items.Add("WoodPlank")
        itemlist.Items.Add("WaterNew")
        itemlist.Items.Add("SandPoleLarge")
        itemlist.Items.Add("Sand")
        itemlist.Items.Add("SandGravel")
        itemlist.Items.Add("SandPoleFence")
        itemlist.Items.Add("SandSign")
        itemlist.Items.Add("SandCactus")
        itemlist.Items.Add("GrassTree")
        itemlist.Items.Add("GrassPoleLarge")
        itemlist.Items.Add("GrassPlain")
        itemlist.Items.Add("GrassWorn")
        itemlist.Items.Add("GrassLong")
        itemlist.Items.Add("GrassSign")
        itemlist.Items.Add("GrassFlower")
        itemlist.Items.Add("GrassPoleFence")


        itemlist.Items.Add("EnemyBase")
        itemlist.Items.Add("EnemyTurrets")
        FileWrite.LoadData()
        SecondaryTile = "GrassPlain"
        DisplaySecond.Image = My.Resources.GrassPlain
        selectedTile = "PathBlack"
        itemlist.SelectedItem = selectedTile
        DisplayEngine("InitMap", vbNull, vbNull, vbNull, vbNull)

        cursor = Controls("X" & selectorx & "Y" & selectory)
        cursor.BorderStyle = BorderStyle.Fixed3D
        Me.KeyPreview = True
    End Sub


    Public Sub MessageEngine(Message As String, Type As String)
        Select Case Type.ToLower
            Case "load"
                If Not System.IO.File.Exists("./AppData/Log.txt") Then
                    System.IO.File.Create("./AppData/Log.txt").Dispose()
                Else
                    System.IO.File.Delete("./AppData/Log.txt")
                    System.IO.File.Create("./AppData/Log.txt").Dispose()
                End If

                Dim file As System.IO.StreamWriter
                file = My.Computer.FileSystem.OpenTextFileWriter("./AppData/Log.txt", True)

                file.WriteLine("Log Created: " & DateString & ", " & TimeString)
                file.WriteLine("By loaded DevMapDesigner;SplashX3")
                file.Close()
                Exit Sub
        End Select

        Dim logger As System.IO.StreamWriter
        logger = My.Computer.FileSystem.OpenTextFileWriter("./AppData/Log.txt", True)
        logger.WriteLine("[" & TimeString & "] " & Message)
        logger.Close()
        Exit Sub

    End Sub

    'Display Engine
    Private ActiveDisplayMemory(10, 20)
    'Contains what is actually drawn on screen. Used to query what is displayed, for boundarys etc.

    Public LoadedDisplayMemory(1000, 1000)
    'Contains the loaded map data from either save display memory or map file. Is modified as the user plays, and is written to save.

    Private TempDisplayMemory(1000, 1000)
    'Contains contents of active display, is used for making changes to the display and telling display engine to draw it, without affecting the map data. Used for character etc.
    Private columnoffset = 0, rowoffset = 0
    Public Sub DisplayEngine(Action, actionArg, column, row, Style)
        Dim cursor As PictureBox
        If Style = Nothing Then
            Style = "mapnull"
        End If
        Select Case Action
            Case "InitMap"
                If LoadType = "LoadNew" Then
                    Try
                        ActiveDisplayMemory.Initialize()
                        LoadedDisplayMemory.Initialize()
                        TempDisplayMemory.Initialize()
                    Catch
                    End Try
                    For rowcount = 0 To 9 Step 1
                        For columncount = 0 To 19 Step 1
                            Try
                                cursor = Me.Controls("X" & rowcount + 1 & "Y" & columncount + 1)
                                cursor.Image = My.Resources.mapnull
                            Catch
                            End Try
                        Next
                    Next
                ElseIf LoadType = "LoadActive" Then

                    For rowcount = 0 To CInt(MapSize.MaxX.Text) - 1 Step 1
                        For columncount = 0 To CInt(MapSize.MaxY.Text) - 1 Step 1
                            Try
                                Dim DisStyle = FileWrite.ReadFromTable(rowcount, columncount + 30)
                                If DisStyle = "" Then
                                    DisStyle = "mapnull"
                                End If

                                LoadedDisplayMemory(rowcount, columncount) = DisStyle


                                'ONLY CONTINUES HERE IF TILE CAN BE DRAWN
                                ActiveDisplayMemory(rowcount, columncount) = DisStyle
                                cursor = Me.Controls("X" & rowcount + 1 & "Y" & columncount + 1)
                                cursor.Image = My.Resources.ResourceManager.GetObject(selectedTile)
                                Try
                                    cursor.Image = My.Resources.ResourceManager.GetObject(DisStyle)
                                    cursor.BackgroundImage = My.Resources.ResourceManager.GetObject(DisStyle)
                                Catch
                                    cursor.Image = My.Resources.mapnull
                                End Try
                            Catch
                            End Try
                        Next
                    Next
                ElseIf LoadType = "LoadExisting" Then
                    Close()
                End If
            Case "ReDraw"
                For rowcount = 1 To 20 Step 1
                    For columncount = 1 To 10 Step 1
                        cursor = Controls("X" & column & "Y" & row)
                        Try
                            ActiveDisplayMemory(columncount - 1, rowcount - 1) = LoadedDisplayMemory(columncount - 1 + columnoffset, rowcount - 1 + rowoffset)
                            DisplayEngine("PlaceTile", "ForAndBack", columncount, rowcount, ActiveDisplayMemory(columncount - 1, rowcount - 1))
                        Catch ex As Exception

                            MessageEngine("ERROR: At Load Map, Display engine, Game: " & ex.Message, "Error")
                            cursor.Image = My.Resources.mapnull
                        End Try
                    Next
                Next
            Case "PlaceTile"
                cursor = Controls("X" & column & "Y" & row)
                Select Case actionArg
                    Case "ForAndBack"
                        LoadedDisplayMemory(column - 1 + columnoffset, row - 1 + rowoffset) = Style
                        ActiveDisplayMemory(column - 1, row - 1) = Style
                        cursor.BackgroundImage = My.Resources.ResourceManager.GetObject(Style)
                        Try
                            cursor.Image = My.Resources.ResourceManager.GetObject(Style)
                        Catch ex As Exception

                            MessageEngine("ERROR At fore Image, Display Engine, Game: " & ex.Message, "Error")
                            cursor.Image = My.Resources.mapnull
                        End Try
                    Case "Clear"
                        DisplayEngine("PlaceTile", "Fore", column, row, ActiveDisplayMemory(column - 1, row - 1))
                    Case "Fore"
                        Try
                            cursor.Image = My.Resources.ResourceManager.GetObject(Style)
                        Catch ex As Exception
                            MessageEngine("ERROR At fore Image, Display Engine, Game: " & ex.Message, "Error")
                            cursor.Image = My.Resources.mapnull
                        End Try
                End Select
            Case "Clear"
                FileWrite.WriteToTable(selectorx - 1, selectory + 29, "")
                Erase ActiveDisplayMemory, LoadedDisplayMemory
                ReDim ActiveDisplayMemory(10, 20)
                ReDim LoadedDisplayMemory(1000, 1000)

                For rowcount = 0 To 9 Step 1
                    For columncount = 0 To 19 Step 1
                        Try
                            cursor = Me.Controls("X" & rowcount + 1 & "Y" & columncount + 1)
                            cursor.Image = My.Resources.mapnull
                        Catch
                        End Try
                    Next
                Next
        End Select
    End Sub

    Private Sub MapDesigner_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Dim cursor As PictureBox
        Try
            Select Case e.KeyChar
                Case "w"
                    If selectorx = 1 Then
                        If Not columnoffset <= 0 Then
                            columnoffset += -1
                            DisplayEngine("ReDraw", vbNull, vbNull, vbNull, vbNull)
                        End If
                        Exit Sub
                    End If
                    cursor = Controls("X" & selectorx & "Y" & selectory)
                    cursor.BorderStyle = BorderStyle.None
                    selectorx += -1

                    cursor = Controls("X" & selectorx & "Y" & selectory)
                    cursor.BorderStyle = BorderStyle.Fixed3D
                    Label4.Text = "X" & selectorx & "Y" & selectory
                Case "a"
                    If selectory = 1 Then
                        If Not rowoffset <= 0 Then
                            rowoffset += -1
                            DisplayEngine("ReDraw", vbNull, vbNull, vbNull, vbNull)
                        End If
                        Exit Sub
                    End If
                    cursor = Controls("X" & selectorx & "Y" & selectory)
                    cursor.BorderStyle = BorderStyle.None
                    selectory += -1
                    cursor = Controls("X" & selectorx & "Y" & selectory)
                    cursor.BorderStyle = BorderStyle.Fixed3D
                    Label4.Text = "X" & selectorx & "Y" & selectory
                Case "s"
                    If selectorx = 10 Then
                        If Not columnoffset + 10 >= CInt(MapSize.MaxX.Text) Then
                            columnoffset += 1
                            DisplayEngine("ReDraw", vbNull, vbNull, vbNull, vbNull)
                        End If
                        Exit Sub
                    End If
                    cursor = Controls("X" & selectorx & "Y" & selectory)
                    cursor.BorderStyle = BorderStyle.None
                    selectorx += 1
                    cursor = Controls("X" & selectorx & "Y" & selectory)
                    cursor.BorderStyle = BorderStyle.Fixed3D
                    Label4.Text = "X" & selectorx & "Y" & selectory
                Case "d"
                    If selectory = 20 Then
                        If Not rowoffset + 20 >= CInt(MapSize.MaxY.Text) Then
                            rowoffset += 1
                            DisplayEngine("ReDraw", vbNull, vbNull, vbNull, vbNull)
                        End If
                        Exit Sub
                    End If
                    cursor = Controls("X" & selectorx & "Y" & selectory)
                    cursor.BorderStyle = BorderStyle.None
                    selectory += 1
                    cursor = Controls("X" & selectorx & "Y" & selectory)
                    cursor.BorderStyle = BorderStyle.Fixed3D
                    Label4.Text = "X" & selectorx & "Y" & selectory
                Case "1"
                    cursor = Controls("X" & selectorx & "Y" & selectory)
                    cursor.Image = My.Resources.ResourceManager.GetObject(selectedTile)
                    DisplayEngine("PlaceTile", "ForAndBack", selectorx, selectory, selectedTile)


                Case "2"
                    selectedTile = LoadedDisplayMemory(selectorx - 1 + columnoffset, selectory - 1 + rowoffset)
                    DisplaySelected.Image = My.Resources.ResourceManager.GetObject(selectedTile)
                Case "3"
                    DisplayEngine("PlaceTile", "ForAndBack", selectorx, selectory, SecondaryTile)

                Case "5"
                    SecondaryTile = selectedTile
                    DisplaySecond.Image = My.Resources.ResourceManager.GetObject(SecondaryTile)
                Case "*"
                    Dim intent = MsgBox("Reload form?", MessageBoxButtons.YesNo)
                    If Not intent = vbYes Then
                        Exit Sub
                    End If
                    Me.Controls.Clear()
                    Me.InitializeComponent()
                    MapDesigner_Load(Me, EventArgs.Empty)
                Case "7"
                    Dim TileToReplace = LoadedDisplayMemory(selectorx - 1 + columnoffset, selectory - 1 + rowoffset)
                    For rowcount = -1 To fillsize Step 1
                        For columncount = -1 To fillsize Step 1
                            Try
                                If LoadedDisplayMemory(selectorx - 1 + columnoffset + rowcount, selectory - 1 + rowoffset + columncount) = TileToReplace Then
                                    DisplayEngine("PlaceTile", "ForAndBack", rowcount + selectorx, columncount + selectory, selectedTile)
                                End If
                            Catch
                            End Try
                        Next
                    Next
                Case "8"
                    Dim intent = MsgBox("Fill entire canvas? Please note that filling large maps will take some time!", MessageBoxButtons.YesNo)
                    If Not intent = vbYes Then
                        Exit Sub
                    End If
                    For rowcount = 0 To CInt(MapSize.MaxX.Text) Step 1
                        For columncount = 0 To CInt(MapSize.MaxY.Text) Step 1
                            Try
                                LoadedDisplayMemory(rowcount, columncount) = selectedTile
                                FileWrite.WriteToTable(rowcount, columncount + 30, selectedTile)
                            Catch
                            End Try

                        Next
                    Next
                    DisplayEngine("ReDraw", vbNull, vbNull, vbNull, vbNull)
                    FileWrite.SaveToFile()
                Case "4"
                    If itemlist.SelectedIndex = 0 Then
                        Exit Sub
                    End If
                    itemlist.SelectedIndex += -1
                    selectedTile = itemlist.SelectedItem
                    DisplaySelected.Image = My.Resources.ResourceManager.GetObject(selectedTile)
                Case "6"
                    If itemlist.SelectedIndex = itemlist.Items.Count Then
                        Exit Sub
                    End If
                    itemlist.SelectedIndex += 1
                    selectedTile = itemlist.SelectedItem
                    DisplaySelected.Image = My.Resources.ResourceManager.GetObject(selectedTile)
                Case "9"
                    Dim intent = MsgBox("Clear the entire canvas?", MessageBoxButtons.YesNo)
                    If Not intent = vbYes Then
                        Exit Sub
                    End If
                    DisplayEngine("Clear", vbNull, vbNull, vbNull, vbNull)
                Case "-"
                    If fillsize = 0 Then
                        Exit Sub
                    End If
                    fillsize += -1
                    Label3.Text = "Fill size: " & fillsize + 2
                Case "+"
                    If fillsize = 5 Then
                        Exit Sub
                    End If
                    fillsize += 1
                    Label3.Text = "Fill size: " & fillsize + 2
            End Select
        Catch ex As Exception
            Dim err = ex.Message
        End Try
    End Sub



    Private Sub SaveScreenmemorytofile()
        For rowcount = 0 To CInt(MapSize.MaxX.Text) Step 1
            For columncount = 0 To CInt(MapSize.MaxY.Text) Step 1
                Try

                    FileWrite.WriteToTable(rowcount, columncount + 30, LoadedDisplayMemory(rowcount, columncount))
                Catch ex As Exception
                End Try
            Next
        Next
        FileWrite.SaveToFile()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SaveScreenmemorytofile()
        FileWrite.Show()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        SaveScreenmemorytofile()
        Export.Show()
    End Sub

    Private Sub DisplayPathAxe_Click(sender As Object, e As EventArgs) Handles DisplayPathAxe.Click
        selectedTile = "PathAxe"
        DisplaySelected.Text = "Selected: " & selectedTile
    End Sub

    Private Sub DisplayTreeSmall_Click(sender As Object, e As EventArgs)
        selectedTile = "TreeSmall"
        DisplaySelected.Text = "Selected: " & selectedTile
    End Sub

    Private Sub DisplaySavePoint_Click(sender As Object, e As EventArgs)
        selectedTile = "SavePoint"
        DisplaySelected.Text = "Selected: " & selectedTile
    End Sub

    Private Sub DisplayWaterDown_Click(sender As Object, e As EventArgs)
        selectedTile = "WaterDown"
        DisplaySelected.Text = "Selected: " & selectedTile
    End Sub

    Private Sub DisplaySandPlain_Click(sender As Object, e As EventArgs) Handles DisplaySandPlain.Click
        selectedTile = "SandPlain"
        DisplaySelected.Text = "Selected: " & selectedTile
    End Sub

    Private Sub DisplayRockSmall_Click(sender As Object, e As EventArgs) Handles DisplayRockSmall.Click
        selectedTile = "RockSmall"
        DisplaySelected.Text = "Selected: " & selectedTile
    End Sub

    Private Sub DisplaySandCactus_Click(sender As Object, e As EventArgs) Handles DisplaySandCactus.Click
        selectedTile = "SandCactus"
        DisplaySelected.Text = "Selected: " & selectedTile
    End Sub

    Private Sub DisplayRockBig_Click(sender As Object, e As EventArgs) Handles DisplayRockBig.Click
        selectedTile = "RockBig"
        DisplaySelected.Text = "Selected: " & selectedTile
    End Sub

    Private Sub DisplayPathExit_Click(sender As Object, e As EventArgs) Handles DisplayPathExit.Click
        selectedTile = "PathExit"
        DisplaySelected.Text = "Selected: " & selectedTile
    End Sub

    Private Sub DisplayPathBlack_Click(sender As Object, e As EventArgs) Handles DisplayPathBlack.Click
        selectedTile = "PathBlack"
        DisplaySelected.Text = "Selected: " & selectedTile
    End Sub

    Private Sub DisplayWaterNew_Click(sender As Object, e As EventArgs) Handles DisplayWaterNew.Click
        selectedTile = "WaterNew"
        DisplaySelected.Text = "Selected: " & selectedTile
    End Sub

    Private Sub DisplayTreeNew_Click(sender As Object, e As EventArgs) Handles DisplayTreeNew.Click
        selectedTile = "TreeNew"
        DisplaySelected.Text = "Selected: " & selectedTile
    End Sub

    Private Sub DisplaySaveNew_Click(sender As Object, e As EventArgs) Handles DisplaySaveNew.Click
        selectedTile = "SaveNew"
        DisplaySelected.Text = "Selected: " & selectedTile
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles DisplayBase.Click
        selectedTile = "EnemyBase"
        DisplaySelected.Text = "Selected: " & selectedTile
    End Sub

    Private Sub DisplayTurret_Click(sender As Object, e As EventArgs) Handles DisplayTurret.Click
        selectedTile = "EnemyTurrets"
        DisplaySelected.Text = "Selected: " & selectedTile
    End Sub

    Private Sub Label4_TextChanged(sender As Object, e As EventArgs) Handles Label4.TextChanged
        Export.Label20.Text = "X" & selectorx & "Y" & selectory
        Export.Label12.Text = "X" & selectorx - 1 & "Y" & selectory - 1
    End Sub

    Private Sub MapDesigner_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FileWrite.SaveToFile()
    End Sub

    Private Sub DisplayWoodenPlanks_Click(sender As Object, e As EventArgs) Handles DisplayWoodenPlanks.Click
        selectedTile = "WoodPlank"
        DisplaySelected.Text = "Selected: " & selectedTile
    End Sub

    Private Sub btnSize_Click(sender As Object, e As EventArgs) Handles btnSize.Click
        MapSize.ShowDialog()
    End Sub

    Private Sub DisplayPickAxe_Click(sender As Object, e As EventArgs) Handles DisplayPickAxe.Click
        selectedTile = "PickAxe"
        DisplaySelected.Text = "Selected: " & selectedTile
    End Sub

    Private Sub MapDesigner_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim cursor As PictureBox = Controls("X" & selectorx & "Y" & selectory)
        cursor.BorderStyle = BorderStyle.None
        SaveScreenmemorytofile()
    End Sub
End Class