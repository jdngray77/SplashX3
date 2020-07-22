Class frmGame

    'CONTAINER ACTIVE
    Public LoadedMap
    Public DebugMode = False

    Public Sub frmGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If SelecterX = 0 Then SelecterX = 1
        If SelecterY = 0 Then SelecterY = 1
        SelecterEngine("Close", vbNull)
        MessageEngine("Loading", "Load")
        If Debugger.IsAttached Then
            'Debugg save files
            DebugMode = True
            MessageEngine("Debug mode activated", "info")
        End If
        'Load Game
        MessageEngine("Info: Beggining load", "info")
        'Enable viewing of keXpresses
        KeyPreview = True

        'Load User profile into memory
        FileEngine("Load", vbNull, vbNull, vbNull)
        MessageEngine("Info: Loaded save file", "info")
        'XXX Load Inventory

        'Load and drawer map
        DisplayEngine("InitMap", "GameLoad", vbNull, vbNull, vbNull)
        MessageEngine("Info: Loaded and drawn map", "info")
        'XXX Detect Active Vehicle
        'XXX Detect Active Vehicle

        'XXX Drawer character XX SCREENPOS /=/ MAPPOS, ACCOUNT FOR VEHICLE
        If DataImport(4, 1).Value = "0" Then
            CharScreenPosX = LoadedMap.startX
            CharMapPosX = LoadedMap.startX
            CharScreenPosY = LoadedMap.startY
            CharMapPosY = LoadedMap.startY
        End If
        CharacterEngine("DrawerCharacter", "InitMap")
        MessageEngine("Info: Drawn character", "info")
        inventory("Load", "Dew It")
        crafting("Load", "Dew It")
        Loading.Hide()
        Show()
    End Sub
    'END CONTAINER ACTIVE

    'CONTAINER PASSIVE
    Public MenuIsShown = False
    Public SelecterMode = False
    Public debugFreeCam = False
    Public Sub frmGame_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        lblKeyPress.Text = e.KeyChar
        LblKeyUsed.Text = "False"

        'Misc
        Select Case Asc(e.KeyChar)
            'Escape
            Case 27
                LblKeyUsed.Text = "True"
                If MenuIsShown = True Then
                    PnlMenu.Location = New Point(11, 625)
                    DisplayEngine("ReDraw", vbNull, vbNull, vbNull, vbNull)
                    DisplayEngine("PlaceTile", "Fore", CharScreenPosX, CharScreenPosY, "Idle")
                    MenuIsShown = False
                    SystemTick.Enabled = True
                    If SelecterMode = True Then
                        Dim cursor As PictureBox = Controls("X" & SelecterX & "Y" & SelecterY)
                        cursor.BorderStyle = BorderStyle.Fixed3D
                    End If
                    Exit Sub
                Else
                    PnlMenu.Location = New Point(321, 140)
                    DisplayEngine("BlackOut", vbNull, vbNull, vbNull, vbNull)
                    MenuIsShown = True
                    SystemTick.Enabled = False
                    If SelecterMode = True Then
                        Dim cursor As PictureBox = Controls("X" & SelecterX & "Y" & SelecterY)
                        cursor.BorderStyle = BorderStyle.None
                    End If
                    Exit Sub
                End If
        End Select


        Dim SelChar As String = e.KeyChar
        If DebugMode = True Then
            Select Case SelChar.ToLower
                Case "*"
                    LblKeyUsed.Text = "True"
                    Erase LoadedDisplayMemory, ActiveDisplayMemory, TempDisplayMemory
                    ReDim LoadedDisplayMemory(1000, 1000), ActiveDisplayMemory(10, 20), TempDisplayMemory(1000, 1000)
                    Controls.Clear()
                    InitializeComponent()
                    frmGame_Load(Me, EventArgs.Empty)
                    'CHANGES MADE HERE SHOULD BE ADDED TO DEBUG RELOAD
                Case "-"
                    LblKeyUsed.Text = "True"
                    LogBox.Items.Clear()
                Case "/"
                    LblKeyUsed.Text = "True"
                    DebugMode = False
                    MessageEngine("Debug mode deactivated", "Info")
                    Me.Size = New Size(1161, 601)
                    Exit Sub
                Case "`"
                    If DebugMode Then
                        DebugMenuForm.Show()
                    End If
            End Select
        ElseIf SelChar.ToLower = "/" Then
            LblKeyUsed.Text = "True"
            DebugMode = True
            MessageEngine("Debug mode activated", "Info")
            Me.Size = New Size(1161, 924)
        End If

        If ActionTimer.Enabled = True Then Exit Sub
        If MenuIsShown = True Then Exit Sub


        'Other, active
        If debugFreeCam Then
            Select Case SelChar.ToLower
                Case "w"
                    columnoffset += -1
                Case "a"
                    rowoffset += -1
                Case "s"
                    columnoffset += 1
                Case "d"
                    rowoffset += 1
            End Select
            DisplayEngine("ReDraw", "null", vbNull, vbNull, vbNull)
            Exit Sub
        End If


        If SelecterMode = True Then

            Try

                Select Case SelChar.ToLower
                    Case "w"
                        LblKeyUsed.Text = "True"
                        SelecterEngine("Move", "Up")
                    Case "a"
                        LblKeyUsed.Text = "True"
                        SelecterEngine("Move", "Left")
                    Case "s"
                        LblKeyUsed.Text = "True"
                        SelecterEngine("Move", "Down")
                    Case "d"
                        LblKeyUsed.Text = "True"
                        SelecterEngine("Move", "Right")
                    Case "1"
                        LblKeyUsed.Text = "True"
                        SelecterEngine("Action", vbNull)
                    Case "3"
                        LblKeyUsed.Text = "True"
                        SelecterEngine("Close", vbNull)
                End Select
                lblcursorpos.Text = "X" & SelecterX & "Y" & SelecterY
            Catch ex As Exception
                MessageEngine("ERROR At SelecterMovementKeyHandler, KeyPress, Game: " & ex.Message, "Error")
                MessageEngine("There was a problem with the selecter, so it has been deactivated!" & ex.Message, "Info")
                SelecterEngine("Close", "vbtothemotherfuckingnullbitch")
            End Try
            Exit Sub
        End If

        Try
            Select Case SelChar.ToLower
                Case "w"
                    LblKeyUsed.Text = "True"
                    CharacterEngine("Move", "Up")
                Case "a"
                    LblKeyUsed.Text = "True"
                    CharacterEngine("Move", "Left")
                Case "s"
                    LblKeyUsed.Text = "True"
                    CharacterEngine("Move", "Down")
                Case "d"
                    LblKeyUsed.Text = "True"
                    CharacterEngine("Move", "Right")
                Case "1"
                    LblKeyUsed.Text = "True"
                    CharacterEngine("Action", "1")
                Case "2"
                    LblKeyUsed.Text = "True"
                    CharacterEngine("Action", "2")
                Case "3"
                    LblKeyUsed.Text = "True"
                    CharacterEngine("Action", "3")
            End Select
        Catch ex As Exception
            MessageEngine("ERROR At CharacterMovementKeyHandler, KeyPress, Game: " & ex.Message, "Error")
        End Try
    End Sub

    Public Function callInitializeComponent()
        InitializeComponent()
        Return (1)
    End Function




    'END CONTAINER PASSIVE


    '================== ENGINES =====================
    'Display Engine
    Public ActiveDisplayMemory(10, 20)
    'Contains what is actually drawn on screen. Used to query what is displayed, for boundarys etc.

    Public LoadedDisplayMemory(1000, 1000)
    'Contains the loaded map data from either save display memory or map file. Is modified as the user plays, and is written to save.

    Public TempDisplayMemory(1000, 1000)
    'Contains contents of active display, is used for making changes to the display and telling display engine to draw it, without affecting the map data. Used for character etc.
    Public columnoffset = 0, rowoffset = 0
    Public Sub DisplayEngine(Action, actionArg, column, row, Style)
        If Style = Nothing Then
            Style = "mapnull"
        End If
        Select Case Action
            Case "InitMap"
                rowoffset = 0
                columnoffset = 0
                Erase ActiveDisplayMemory, LoadedDisplayMemory, TempDisplayMemory
                ReDim ActiveDisplayMemory(10, 20), LoadedDisplayMemory(1000, 1000), TempDisplayMemory(1000, 1000)

                LoadedMap = New SplashMap_Part1
                LoadedMap.Initialise()
                If Not DataImport(4, 1).Value = "0" Then

                    For columncount = 0 To LoadedMap.mapX Step 1
                        For rowcount = 0 To LoadedMap.MaxY Step 1
                            Try
                                LoadedDisplayMemory(columncount, rowcount) = DataImport(columncount, rowcount + 51)
                            Catch ex As Exception
                            End Try
                        Next
                    Next
                Else
                    For rowcount = 1 To LoadedMap.mapx Step 1
                        For columncount = 1 To LoadedMap.mapy Step 1
                            Try

                                LoadedDisplayMemory(columncount - 1, rowcount - 1) = LoadedMap.charSet(columncount - 1, rowcount - 1)

                                If rowcount <= 20 Then
                                    If column <= 10 Then
                                        ActiveDisplayMemory(columncount - 1, rowcount - 1) = LoadedDisplayMemory(columncount - 1, rowcount - 1)
                                        DisplayEngine("PlaceTile", "ForAndBack", columncount, rowcount, ActiveDisplayMemory(columncount - 1, rowcount - 1))
                                    End If
                                End If
                            Catch ex As Exception
                                MessageEngine("ERROR: At Load Map, Display engine, Game: " & ex.Message, "Error")
                            End Try
                        Next
                    Next
                End If
            Case "BlackOut"
                Dim cursor As PictureBox
                For rowcount = 1 To 20 Step 1
                    For columncount = 1 To 10 Step 1
                        Try
                            cursor = Controls("X" & columncount & "Y" & rowcount)
                            cursor.Image = My.Resources.nullBlack
                            cursor.BackgroundImage = My.Resources.nullBlack
                        Catch ex As Exception
                        End Try
                    Next
                Next
            Case "ReDraw"
                For rowcount = 1 To 20 Step 1
                    For columncount = 1 To 10 Step 1
                        Dim Cursor As PictureBox = Controls("X" & column & "Y" & row)
                        Try
                            ActiveDisplayMemory(columncount - 1, rowcount - 1) = LoadedDisplayMemory(columncount - 1 + columnoffset, rowcount - 1 + rowoffset)
                            DisplayEngine("PlaceTile", "ForAndBack", columncount, rowcount, ActiveDisplayMemory(columncount - 1, rowcount - 1))
                        Catch ex As Exception

                            MessageEngine("ERROR: At Load Map, Display engine, Game: " & ex.Message, "Error")
                            Cursor.Image = My.Resources.mapnull
                        End Try
                    Next
                Next
            Case "PlaceTile"
                Dim Cursor As PictureBox = Controls("X" & column & "Y" & row)
                Try
                    Dim preventative As String = actionArg
                    If actionArg = Nothing Then Throw New Exception("No display method specified.")
                Catch ex As Exception
                    MessageEngine("ERROR At ActionArg Test, PlaceTile, DisplayEngine, Game." & ex.Message, "Error")
                    MessageEngine("WARN Skipping PlaceTile function : X" & column & "Y" & row & " ," & Style, "Warn")
                    MessageEngine("WARN Cont. Expected display type, but got: " & actionArg & "Which makes no sense.", "Warn")
                End Try
                Select Case actionArg
                    Case "ForAndBack"
                        LoadedDisplayMemory(column - 1 + columnoffset, row - 1 + rowoffset) = Style
                        ActiveDisplayMemory(column - 1, row - 1) = Style
                        Cursor.BackgroundImage = My.Resources.ResourceManager.GetObject(Style)
                        Try
                            Cursor.Image = My.Resources.ResourceManager.GetObject(Style)
                        Catch ex As Exception

                            MessageEngine("ERROR At fore Image, Display Engine, Game: " & ex.Message, "Error")
                            Cursor.Image = My.Resources.mapnull
                        End Try
                    Case "Clear"
                        DisplayEngine("PlaceTile", "Fore", column, row, ActiveDisplayMemory(column - 1, row - 1))
                    Case "Fore"
                        Try
                            Cursor.Image = My.Resources.ResourceManager.GetObject(Style)
                        Catch ex As Exception
                            MessageEngine("ERROR At fore Image, Display Engine, Game: " & ex.Message, "Error")
                            Cursor.Image = My.Resources.mapnull
                        End Try
                End Select


            Case ""
        End Select
    End Sub

    Private craftingoffset
    Public Sub crafting(Action, actionarg)
        Select Case Action
            Case "Load"
                CraftingCombo.Items.Add("nullBlack")
                CraftingCombo.Items.Add("PathAxe")
                CraftingCombo.Items.Add("PickAxe")
                CraftingCombo.Items.Add("GunPistol")
                CraftingCombo.Items.Add("MapNull")
                craftingoffset = 1
                crafting("Update", 0)
            Case "Update"
                If actionarg = -1 Then
                    If craftingoffset - 1 = 0 Then
                        Exit Sub
                    Else
                        craftingoffset += -1
                    End If
                ElseIf actionarg = 1 Then
                    If craftingoffset + 1 = CraftingCombo.Items.Count Then
                        Exit Sub
                    Else
                        craftingoffset += 1
                    End If
                End If

                Try
                    CraftingCombo.SelectedIndex = craftingoffset - 1
                    CraftingPrev.Image = My.Resources.ResourceManager.GetObject(CraftingCombo.SelectedItem)
                Catch ex As Exception
                    MessageEngine("At Update, Crafting:" & ex.Message, "Error")
                    CraftingPrev.Image = My.Resources.mapnull
                End Try
                Try
                    CraftingCombo.SelectedIndex = craftingoffset
                    lblCraftingName.Text = "Item Name: " & CraftingCombo.SelectedItem
                    CraftingCurr.Image = My.Resources.ResourceManager.GetObject(CraftingCombo.SelectedItem)
                Catch ex As Exception
                    MessageEngine("At Update, Crafting:" & ex.Message, "Error")
                    CraftingCurr.Image = My.Resources.mapnull
                End Try
                Try
                    CraftingCombo.SelectedIndex = craftingoffset + 1
                    CraftingNext.Image = My.Resources.ResourceManager.GetObject(CraftingCombo.SelectedItem)
                Catch ex As Exception
                    MessageEngine("At Update, Crafting:" & ex.Message, "Error")
                    CraftingNext.Image = My.Resources.mapnull
                End Try
        End Select

    End Sub

    Private Sub btnCraftingPrev_Click(sender As Object, e As EventArgs) Handles btnCraftingPrev.Click
        crafting("Update", -1)
    End Sub

    Private Sub btnCraftingNext_Click(sender As Object, e As EventArgs) Handles btnCraftingNext.Click
        crafting("Update", +1)
    End Sub




    Public CharMapPosX, CharMapPosY, CharScreenPosX, CharScreenPosY, CharHealth, CharArmourMultiplyer, CharVehicle(4, 4), charDir
    Public charTransport = "Foot"
    Public Sub CharacterEngine(Action, actionarg)
        Select Case Action
            Case "Move"
                Dim style
                Select Case actionarg
                    Case "Up"
                        charDir = "Up"
                        Try
                            If BoundCheck(LoadedDisplayMemory(CharMapPosX - 2, CharMapPosY - 1)) = False Then
                                If CharScreenPosX = 1 Then
                                    If Not CharMapPosX <= 1 Then
                                        columnoffset += -1
                                        DisplayEngine("PlaceTile", "Clear", CharScreenPosX, CharScreenPosY, "")
                                        CharScreenPosX += 1
                                        DisplayEngine("ReDraw", "null", vbNull, vbNull, vbNull)
                                        DisplayEngine("PlaceTile", "Fore", CharScreenPosX, CharScreenPosY, "idle")
                                    End If
                                    Exit Sub
                                End If
                                Exit Sub
                            End If
                        Catch ex As Exception
                            MessageEngine("WARN At CharacterEngine:  " & ex.Message, "Warn")
                        End Try
                        'XXX MOVE MAP
                        style = "idle"
                        If CharScreenPosX = 1 Then
                            If Not CharMapPosX <= 1 Then
                                columnoffset += -1
                                DisplayEngine("PlaceTile", "Clear", CharScreenPosX, CharScreenPosY, "")
                                CharScreenPosX += 1
                                DisplayEngine("ReDraw", "null", vbNull, vbNull, vbNull)
                                DisplayEngine("PlaceTile", "Fore", CharScreenPosX, CharScreenPosY, "idle")
                            End If
                            Exit Sub
                        End If
                        If CharMapPosX = 1 Then
                            Exit Sub
                        End If
                        DisplayEngine("PlaceTile", "Clear", CharScreenPosX, CharScreenPosY, "")
                        CharScreenPosX += -1
                        CharMapPosX += -1
                        DisplayEngine("PlaceTile", "Fore", CharScreenPosX, CharScreenPosY, style)
                    Case "Down"
                        charDir = "Down"
                        If CharMapPosX = LoadedMap.mapY Then
                            Exit Sub
                        End If
                        Try
                            If BoundCheck(LoadedDisplayMemory(CharMapPosX, CharMapPosY - 1)) = False Then
                                If CharScreenPosX = 10 Then
                                    If Not CharMapPosX >= LoadedMap.mapX Then
                                        columnoffset += 1
                                        DisplayEngine("PlaceTile", "Clear", CharScreenPosX, CharScreenPosY, "")
                                        CharScreenPosX += -1
                                        style = "idle"
                                        DisplayEngine("ReDraw", "null", vbNull, vbNull, vbNull)

                                        DisplayEngine("PlaceTile", "Fore", CharScreenPosX, CharScreenPosY, style)
                                        Exit Sub
                                    End If
                                    Exit Sub
                                End If
                                Exit Sub
                            End If
                        Catch ex As Exception
                            MessageEngine("WARN At CharacterEngine: " & ex.Message, "Error")
                        End Try
                        If CharScreenPosX = 10 Then
                            If Not CharMapPosX >= LoadedMap.mapX Then
                                columnoffset += 1
                                DisplayEngine("PlaceTile", "Clear", CharScreenPosX, CharScreenPosY, "")
                                CharScreenPosX += -1
                                style = "idle"
                                DisplayEngine("ReDraw", "null", vbNull, vbNull, vbNull)

                                DisplayEngine("PlaceTile", "Fore", CharScreenPosX, CharScreenPosY, style)
                                Exit Sub
                            End If
                            Exit Sub
                        End If



                        DisplayEngine("PlaceTile", "Clear", CharScreenPosX, CharScreenPosY, "")
                        style = "idle"
                        CharScreenPosX += 1
                        CharMapPosX += 1
                        DisplayEngine("PlaceTile", "Fore", CharScreenPosX, CharScreenPosY, style)
                    Case "Left"
                        charDir = "Left"
                        Try
                            If BoundCheck(LoadedDisplayMemory(CharMapPosX - 1, CharMapPosY - 2)) = False Then
                                If CharScreenPosY = 1 Then
                                    If CharMapPosY = 1 Then
                                        Exit Sub
                                    Else
                                        rowoffset += -1
                                        DisplayEngine("PlaceTile", "Clear", CharScreenPosX, CharScreenPosY, "")
                                        CharScreenPosY += 1
                                        style = "idle"
                                        DisplayEngine("ReDraw", "null", vbNull, vbNull, vbNull)

                                        DisplayEngine("PlaceTile", "Fore", CharScreenPosX, CharScreenPosY, style)
                                        Exit Sub
                                    End If
                                End If
                                Exit Sub
                            End If
                        Catch ex As Exception
                            MessageEngine("WARN At CharacterEngine: " & ex.Message, "warn")
                        End Try
                        If CharScreenPosY = 1 Then
                            If CharMapPosY = 1 Then
                                Exit Sub
                            Else
                                rowoffset += -1
                                DisplayEngine("PlaceTile", "Clear", CharScreenPosX, CharScreenPosY, "")
                                CharScreenPosY += 1
                                style = "idle"
                                DisplayEngine("ReDraw", "null", vbNull, vbNull, vbNull)

                                DisplayEngine("PlaceTile", "Fore", CharScreenPosX, CharScreenPosY, style)
                                Exit Sub
                            End If
                        End If

                        DisplayEngine("PlaceTile", "Clear", CharScreenPosX, CharScreenPosY, "")
                        style = "idleLeft"
                        CharScreenPosY += -1
                        CharMapPosY += -1
                        DisplayEngine("PlaceTile", "Fore", CharScreenPosX, CharScreenPosY, style)
                    Case "Right"
                        charDir = "Right"
                        Try
                            If BoundCheck(LoadedDisplayMemory(CharMapPosX - 1, CharMapPosY)) = False Then
                                If CharScreenPosY = 20 Then
                                    If CharMapPosY >= LoadedMap.mapX Then
                                        Exit Sub
                                    Else

                                        rowoffset += 1
                                        DisplayEngine("PlaceTile", "Clear", CharScreenPosX, CharScreenPosY, "")
                                        CharScreenPosY += -1
                                        style = "idle"
                                        DisplayEngine("ReDraw", "null", vbNull, vbNull, vbNull)

                                        DisplayEngine("PlaceTile", "Fore", CharScreenPosX, CharScreenPosY, style)
                                        Exit Sub
                                    End If
                                End If
                                Exit Sub
                            End If
                        Catch ex As Exception
                            MessageEngine("WARN At CharacterEngine: " & ex.Message, "Error")
                        End Try
                        If CharScreenPosY = 20 Then
                            If CharMapPosY >= LoadedMap.mapX Then
                                Exit Sub
                            Else

                                rowoffset += 1
                                DisplayEngine("PlaceTile", "Clear", CharScreenPosX, CharScreenPosY, "")
                                CharScreenPosY += -1
                                style = "idle"
                                DisplayEngine("ReDraw", "null", vbNull, vbNull, vbNull)

                                DisplayEngine("PlaceTile", "Fore", CharScreenPosX, CharScreenPosY, style)
                                Exit Sub
                            End If
                        End If

                        DisplayEngine("PlaceTile", "Clear", CharScreenPosX, CharScreenPosY, "")
                        style = "idle"
                        CharScreenPosY += 1
                        CharMapPosY += 1
                        DisplayEngine("PlaceTile", "Fore", CharScreenPosX, CharScreenPosY, style)
                End Select

                lblCharCoords.Text = "X" & CharScreenPosX & "Y" & CharScreenPosY & "-X" & CharMapPosX & "Y" & CharMapPosY
            Case "Hurt"
            Case "DrawerCharacter"
                DisplayEngine("PlaceTile", "Fore", CharScreenPosX, CharScreenPosY, "idle")
                lblCharCoords.Text = "X" & CharScreenPosX & "Y" & CharScreenPosY & "-X" & CharMapPosX & "Y" & CharMapPosY
            Case "Action"

                Dim tiledat As TileData = New TileData
                tiledat.Initialise()
                If actionarg = "1" Then
                    Dim index = tiledat.GetIndex(Cursor1.Text, "Friend")
                    Dim tile = tiledat.TileIndex(index, 1)
                    Dim lookupofsetx = 0, lookupofsety = 0
                    Select Case charDir
                        Case "Up"
                            lookupofsetx += -1
                        Case "Down"
                            lookupofsetx += 1
                        Case "Left"
                            lookupofsety += -1
                        Case "Right"
                            lookupofsety += 1
                    End Select
                    tiledat.ItemAction(tile, actionarg, CharScreenPosX + lookupofsetx, CharScreenPosY + lookupofsety)

                ElseIf actionarg = "2" Then
                    If SelecterMode = True Then
                        SelecterEngine("Action", vbNull)
                    Else
                        If SelItem.Tag = Nothing Then Exit Sub
                        tiledat.ItemAction(ActiveItem, actionarg, vbNull, vbNull)
                    End If
                End If
        End Select
    End Sub

    Public Function BoundCheck(Tile)
        Dim TileDat As TileData = New TileData
        TileDat.Initialise()

        Dim index = TileDat.GetIndex(Tile, "Resource")
        If index = 1000 Then
            If DebugMode = True Then
                Return (True)
            Else
                Return (False)
            End If
            Exit Function
        End If

        Dim transIndex = 0
        Select Case charTransport
            Case "Foot"
                transIndex = 1
            Case "Air"
                transIndex = 0
            Case "Heavy"
                transIndex = 2
        End Select

        Try
            CursorPic.Image = My.Resources.ResourceManager.GetObject(Tile)
            Cursor1.Text = TileDat.TileData(index, 4)
            Cursor2.Text = TileDat.TileData(index, 5)
            Cursor3.Text = TileDat.TileData(index, 6)
        Catch ex As Exception
            MessageEngine("ERROR At Boundcheck, Game: " & ex.Message, "Error")
        End Try


        Return (TileDat.TileData(index, transIndex))
    End Function

    Public Sub FileEngine(Action, actionArg, X, Y)
        Select Case Action
            Case "Load"
                If frmMenu.CurrentUser.ToString = "0" Then
                    frmMenu.CurrentUser = "1"
                End If
                Dim FileToLoad = "./AppData/User" & frmMenu.CurrentUser.ToString & ".usr"
                DataImport.Rows.Clear()

                Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(FileToLoad)
                    MyReader.TextFieldType = FileIO.FieldType.Delimited
                    MyReader.SetDelimiters(",")
                    Dim currentRow As String()
                    While Not MyReader.EndOfData
                        Try
                            currentRow = MyReader.ReadFields()
                            DataImport.Rows.Add(currentRow) 'Add new row to data grid view'
                        Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                            MessageEngine("ERROR: At profile load, Game, File Write, Load: " & ex.Message, "Error")
                        End Try
                    End While
                End Using
        End Select
    End Sub

    Public Sub MessageEngine(Message As String, Type As String)
        lblLog.Text = TimeString
        Select Case Type.ToLower
            Case "error"
                If DebugMode = True Then
                    LogBox.ForeColor = Color.Red
                    LogBox.Items.Add(Message)
                End If
            Case "info"
                LogBox.ForeColor = Color.White
                LogBox.Items.Add(Message)
            Case "warn"
                If DebugMode = True Then
                    LogBox.ForeColor = Color.Yellow
                    LogBox.Items.Add(Message)
                End If
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
                file.WriteLine("By loaded user account: " & frmMenu.CurrentUser)
                file.Close()
                Exit Sub
        End Select

        Dim logger As System.IO.StreamWriter
        logger = My.Computer.FileSystem.OpenTextFileWriter("./AppData/Log.txt", True)
        logger.WriteLine("[" & TimeString & "] " & Message)
        logger.Close()
        Exit Sub

    End Sub

    Public Function inventoryContains(Item)
        For i = 1 To inventoryLength
            Try
                If inventoryContents(i, 1) = Item Then
                    Return (True)
                    Exit Function
                End If
            Catch ex As Exception
            End Try
        Next
        Return (False)
    End Function

    Public Function inventoryGetIndex(Item, type)
        If type = "Ident" Then type = 0 Else type = 1
        Try
            For i = 0 To inventoryLength
                If inventoryContents(i, type) = Item Then
                    Return (i)
                End If
            Next
        Catch ex As Exception
            MessageEngine("INFO At inventoryGetIndex. Likely item requested does not exist. :" & ex.Message, "Warn")
            Return False
            Exit Function
        End Try
        Return (False)
    End Function

    Public Function inventoryGenerateId()
        Dim flop = True
        Dim newid = Nothing
        While flop = True
            newid = Math.Round(Rnd() * Math.PI * 100, 0)


            For i = 0 To inventoryLength

                If inventoryContents(i, 2) = newid Then
                    Exit For
                End If

                If i = inventoryLength Then
                    flop = False
                End If
            Next
        End While
        Return (newid)
    End Function

    Public inventoryContents(10, 5)
    Public inventoryLength = 0
    Public ActiveItem 'ACTIVE FROM INVENTORY, NOT WORLD
    Public Function inventoryGetCursor()
        Dim cursor = Nothing
        Select Case inventoryIndex
            Case 1
                cursor = Inv1
            Case 2
                cursor = Inv2
            Case 3
                cursor = Inv3
            Case 4
                cursor = Inv4
            Case 5
                cursor = Inv5
            Case 6
                cursor = Inv6
            Case 7
                cursor = Inv7
            Case 8
                cursor = Inv8
        End Select
        Return (cursor)
    End Function


    Public inventoryIndex = 1
    Public Sub inventory(Action, ActionArg)
        Dim tiledat As TileData = New TileData
        tiledat.Initialise()
        Dim itemtype = "Item"
        Dim cursor As PictureBox
        cursor = inventoryGetCursor()

        Select Case Action
            Case "ChangeDurability"
                Dim index = inventoryGetIndex(SelItem.Tag, "Ident")
                If inventoryContents(index, 4) <= 0 Then
                    inventory("Remove", SelItem.Tag)
                Else
                    inventoryContents(index, 4) += ActionArg
                End If

            Case "UpdateActive"

                Try
                    If Not ActionArg.ToString = "Force" Then
                        If cursor.Tag = Nothing Or cursor.Tag = "null" Then
                            SelItem.Image = My.Resources.nullBlack
                            lblSelTitle.Text = "Nothing"
                            ActiveDurability.Value = 0
                            ActiveDurability.Update()
                            ActiveInfo.Items.Clear()
                            Exit Sub
                        End If
                    End If
                Catch
                End Try

                Dim item As String = InventoryRemoveIdentifyer(cursor.Tag)
                item = tiledat.GetIndex(item, "Friend")
                ActiveItem = tiledat.TileIndex(item, 1)
                SelItem.Image = My.Resources.ResourceManager.GetObject(tiledat.TileIndex(item, 1))
                SelItem.Tag = cursor.Tag
                lblSelTitle.Text = tiledat.TileIndex(item, 0)

                Dim index = inventoryGetIndex(cursor.Tag, "Ident")

                If inventoryContents(index, 3) = "Item" Then
                    ActiveDurability.Value = inventoryContents(index, 4)
                    ActiveDurability.Update()
                Else
                    ActiveDurability.Value = 0
                    ActiveDurability.Update()
                End If

                Try
                    ActiveInfo.Items.Clear()
                    ActiveInfo.Items.Add(tiledat.TileData(item, 12))
                Catch ex As Exception
                    MessageEngine("ERROR (Likely no defined active information for item in tileData) At Inventory, Update Active, Game: " & ex.Message, "Error")
                End Try

            Case "Add"
                If inventoryContains(ActionArg) Then 'Add one to existing
                    If inventoryContents(inventoryGetIndex(ActionArg, "Friend"), 3) = "Tile" Then 'only for tile types. Durability and quantity use the same slot.
                        inventoryContents(inventoryGetIndex(ActionArg, "Friend"), 4) += 1
                        Exit Sub
                    End If
                End If


                Dim index = tiledat.GetIndex(ActionArg, "Resource")
                Dim id = inventoryGenerateId()
                inventoryLength += 1
                inventoryContents(inventoryLength, 0) = "[" & id & "] " & tiledat.TileIndex(index, 0) 'name
                inventoryContents(inventoryLength, 1) = tiledat.TileIndex(index, 1) 'resourcename
                inventoryContents(inventoryLength, 2) = id 'id

                If tiledat.ItemData(index, 0) = Nothing Then
                    itemtype = "Tile"
                End If

                inventoryContents(inventoryLength, 3) = itemtype 'Type
                Dim dur, multi
                If itemtype = "Tile" Then
                    dur = 0
                    multi = 0
                Else
                    dur = tiledat.ItemData(index, 0)
                    multi = tiledat.ItemData(index, 1)
                End If

                inventoryContents(inventoryLength, 4) = dur 'Durability (Or quantity, for items that don't have durability. Durability items do not stack.)
                inventoryContents(inventoryLength, 5) = multi 'multiplyer

                InventoryList.Items.Add(inventoryContents(inventoryLength, 0))
                InventoryList.SelectedIndex = InventoryList.Items.Count - 1

            Case "Remove"
                Dim itemtoremoveIndex = inventoryGetIndex(ActionArg, "Ident") 'XXX CHECK

                Try
                    For index = 0 To 5 Step 1
                        inventoryContents(itemtoremoveIndex, index) = Nothing
                    Next
                    SelItem.Tag = ""
                    SelItem.Image = My.Resources.nullBlack
                    lblSelTitle.Text = "Nothing"
                    ActiveInfo.Items.Clear()
                    ActiveDurability.Value = 0
                    ActiveDurability.Update()
                    InventoryActive.Items.Remove(ActionArg)
                    InventoryList.Items.Remove(ActionArg)
                    Select Case inventoryIndex
                        Case 1
                            cursor = Inv1
                        Case 2
                            cursor = Inv2
                        Case 3
                            cursor = Inv3
                        Case 4
                            cursor = Inv4
                        Case 5
                            cursor = Inv5
                        Case 6
                            cursor = Inv6
                        Case 7
                            cursor = Inv7
                        Case 8
                            cursor = Inv8
                    End Select

                    Try

                        If cursor.Tag = ActionArg Then
                            cursor.Tag = ""
                            cursor.Image = My.Resources.nullBlack
                        End If
                    Catch
                    End Try


                Catch ex As Exception
                    MessageEngine("ERROR At Remove, Inventory handler, Game: " & ex.Message, "Error")
                End Try

                MessageEngine("INFO Removed item from inventory.", "Warn")
                MessageEngine(InventoryRemoveIdentifyer(SelItem.Tag) & " Finally broke!", "Info")
            Case "Load"
                cursor.BorderStyle = BorderStyle.Fixed3D
                Erase inventoryContents(10, 5)
                ReDim inventoryContents(10, 5)
                inventoryLength = 0
            Case "Scroll"

                cursor.BorderStyle = BorderStyle.FixedSingle

                If ActionArg = "Up" Then
                    If inventoryIndex = 8 Then
                        inventoryIndex = 1
                    Else
                        inventoryIndex += 1
                    End If

                ElseIf ActionArg = "Down" Then
                    If inventoryIndex = 1 Then
                        inventoryIndex = 8
                    Else
                        inventoryIndex += -1
                    End If

                Else
                    cursor.BorderStyle = BorderStyle.Fixed3D
                    Exit Sub
                End If

                Select Case inventoryIndex
                    Case 1
                        cursor = Inv1
                    Case 2
                        cursor = Inv2
                    Case 3
                        cursor = Inv3
                    Case 4
                        cursor = Inv4
                    Case 5
                        cursor = Inv5
                    Case 6
                        cursor = Inv6
                    Case 7
                        cursor = Inv7
                    Case 8
                        cursor = Inv8
                End Select
                cursor.BorderStyle = BorderStyle.Fixed3D
                inventory("UpdateActive", vbNull)
            Case "Select"
        End Select
    End Sub

    Public Function InventoryRemoveIdentifyer(ident As String)
        ident = ident.Replace("[", "")
        ident = ident.Replace("]", "")
        Try
            ident = ident.Replace("0", "")
        Catch
        End Try
        Try
            ident = ident.Replace("1", "")
        Catch
        End Try

        Try
            ident = ident.Replace("2", "")
        Catch
        End Try

        Try
            ident = ident.Replace("3", "")
        Catch
        End Try

        Try
            ident = ident.Replace("4", "")
        Catch
        End Try

        Try
            ident = ident.Replace("5", "")
        Catch
        End Try

        Try
            ident = ident.Replace("6", "")
        Catch
        End Try

        Try
            ident = ident.Replace("7", "")
        Catch
        End Try

        Try
            ident = ident.Replace("8", "")
        Catch
        End Try
        Try
            ident = ident.Replace("9", "")
        Catch
        End Try
        Try
            While ident.Chars(0) = " "
                ident = ident.Remove(0, 1)
            End While
        Catch
        End Try
        Return (ident)
    End Function

    Public SelecterX = 1, SelecterY = 1, debugSelecterZoneLimit = False, selecterPrevRowOffset = 1, selecterPrevColumnOffset = 1
    Public Sub SelecterEngine(Action, ActionArg)
        Dim cursor As PictureBox = Controls("X" & SelecterX & "Y" & SelecterY)
        Select Case Action
            Case "Open"
                SelecterX = CharScreenPosX
                SelecterY = CharScreenPosY
                selecterPrevRowOffset = rowoffset
                selecterPrevColumnOffset = columnoffset
                SelecterMode = True
                cursor = Controls("X" & SelecterX & "Y" & SelecterY)
                cursor.BorderStyle = BorderStyle.Fixed3D
            Case "Action"
                Dim tiledat As TileData = New TileData
                tiledat.ItemAction(ActiveItem, "ActionComplete", SelecterX, SelecterY)
            Case "Move"
                cursor.BorderStyle = BorderStyle.None
                If debugSelecterZoneLimit = True Then
                    If SelecterX = CharScreenPosX + 5 Or SelecterX = CharScreenPosX - 5 Or SelecterY = CharScreenPosY + 5 Or SelecterY = CharScreenPosY + 5 Then
                        cursor.BorderStyle = BorderStyle.Fixed3D
                        Exit Sub
                    End If
                End If
                Select Case ActionArg
                    Case "Up"
                        If SelecterX = 1 And columnoffset < LoadedMap.mapy Then
                            columnoffset += -1
                            DisplayEngine("ReDraw", "null", vbNull, vbNull, vbNull)
                            cursor.BorderStyle = BorderStyle.Fixed3D
                            Exit Sub
                        End If
                        If SelecterX = 1 Or SelecterX = 0 Then
                            cursor.BorderStyle = BorderStyle.Fixed3D
                            Exit Sub
                        End If

                        SelecterX += -1
                    Case "Down"
                        If SelecterX = 10 And columnoffset < LoadedMap.mapy - 10 Then
                            columnoffset += 1
                            DisplayEngine("ReDraw", "null", vbNull, vbNull, vbNull)
                            cursor.BorderStyle = BorderStyle.Fixed3D
                            Exit Sub
                        End If
                        If SelecterX = 10 Or SelecterX = LoadedMap.mapx Then
                            cursor.BorderStyle = BorderStyle.Fixed3D
                            Exit Sub
                        End If

                        SelecterX += 1
                    Case "Left"
                        If SelecterY = 1 And rowoffset < LoadedMap.mapx - 20 Then
                            rowoffset += -1
                            DisplayEngine("ReDraw", "null", vbNull, vbNull, vbNull)
                            cursor.BorderStyle = BorderStyle.Fixed3D
                            Exit Sub
                        End If
                        If SelecterY = 1 Or SelecterY = 0 Then
                            cursor.BorderStyle = BorderStyle.Fixed3D
                            Exit Sub
                        End If

                        SelecterY += -1
                    Case "Right"
                        If SelecterY = 20 And rowoffset < LoadedMap.mapx Then
                            rowoffset += 1
                            DisplayEngine("ReDraw", "null", vbNull, vbNull, vbNull)
                            cursor.BorderStyle = BorderStyle.Fixed3D
                            Exit Sub
                        End If
                        If SelecterY = 20 Or SelecterY = LoadedMap.mapy Then
                            cursor.BorderStyle = BorderStyle.Fixed3D
                            Exit Sub
                        End If

                        SelecterY += 1
                End Select
                cursor = Controls("X" & SelecterX & "Y" & SelecterY)
                cursor.BorderStyle = BorderStyle.Fixed3D
            Case "Close"
                SelecterMode = False
                Try
                    cursor.BorderStyle = BorderStyle.None
                    rowoffset = selecterPrevRowOffset
                    columnoffset = selecterPrevColumnOffset
                    DisplayEngine("ReDraw", "null", vbNull, vbNull, vbNull)
                    CharacterEngine("DrawerCharacter", "null")
                Catch
                End Try
            Case "TimerComplete"
                inventory("ChangeDurability", -1)
                If inventoryGetDurability() <= 0 Then
                    SelecterEngine("Close", vbNull)
                    inventory("Remove", SelItem.Tag)
                End If
        End Select
    End Sub

    Public Function inventoryGetDurability()
        Dim durability = 0
        Dim index = inventoryGetIndex(SelItem.Tag, "Ident")
        durability = inventoryContents(index, 4)
        Return (durability)
    End Function

    'CONTAINER MISC
    Public DebugUptime = 1
    Public TimerTime, TimerEfficiency

    Public Sub ActionTimer_Tick(sender As Object, e As EventArgs) Handles ActionTimer.Tick
        If CInt(lblUpTime.Text) <= 5 Then
            Exit Sub
        End If

        If TimerTime - 1 <= 0 Then
            ActionTimer.Enabled = False
            Dim tiledat As TileData = New TileData
            tiledat.ItemAction(ActiveItem, "TimerComplete", SelecterX, SelecterY)
            SelecterEngine("TimerComplete", vbNull)
        End If
        TimerTime += -TimerEfficiency
    End Sub

    Public Sub InventoryList_DoubleClick(sender As Object, e As EventArgs) Handles InventoryList.DoubleClick
        If InventoryList.SelectedIndex = -1 Then Exit Sub
        Dim cursor = inventoryGetCursor()
        If SelecterMode = True And Not cursor.tag = SelItem.Tag Then SelecterEngine("Close", vbNull)

        If InventoryActive.Items.Count >= 8 Then
            InventoryActive.SelectedIndex = InventoryActive.Items.Count - 1
            InventoryActive.Items.RemoveAt(InventoryActive.SelectedIndex)
        End If

        If InventoryActive.Items.Contains(InventoryList.SelectedItem) Then
            InventoryActive.SelectedItem = InventoryList.SelectedItem
            InventoryActive.Items.RemoveAt(InventoryActive.SelectedIndex)
        End If

        InventoryActive.Items.Add(InventoryList.SelectedItem)
        Dim ident As String = InventoryRemoveIdentifyer(InventoryList.SelectedItem)
        Dim tiledat As TileData = New TileData
        tiledat.Initialise()
        Dim index = tiledat.GetIndex(ident, "Friend")
        Dim ResourceName = tiledat.TileIndex(index, 1)
        InventoryActive.SelectedItem = InventoryList.SelectedItem
        For i = 0 To InventoryActive.Items.Count - 1 Step 1
            cursor = GroupBox16.Controls("Inv" & i + 1)
            ident = InventoryRemoveIdentifyer(InventoryActive.SelectedItem)
            index = tiledat.GetIndex(ident, "Friend")
            ResourceName = tiledat.TileIndex(index, 1)

            Try
                cursor.Image = My.Resources.ResourceManager.GetObject(ResourceName)
                cursor.Tag = InventoryActive.SelectedItem
            Catch
                cursor.Image = My.Resources.nullBlack
                cursor.Tag = "null"
            End Try
            ident = InventoryRemoveIdentifyer(InventoryList.SelectedItem)
            index = tiledat.GetIndex(ident, "Friend")
            ResourceName = tiledat.TileIndex(index, 1)
            InventoryActive.SelectedIndex += -1
        Next
        If InventoryActive.Items.Count > 8 Then
            For i = 7 To InventoryActive.Items.Count - 1
                InventoryActive.Items.RemoveAt(i)
            Next
        End If

        For i = InventoryActive.Items.Count To 7 Step 1
            Try
                cursor = GroupBox16.Controls("Inv" & i + 1)
                cursor.Tag = ""
                cursor.Image = My.Resources.nullBlack
            Catch
            End Try
        Next
    End Sub


    Public Sub SystemTick_Tick(sender As Object, e As EventArgs) Handles SystemTick.Tick
        DebugUptime += 1
        lblUpTime.Text = DebugUptime
        Dim x As Process = Process.GetCurrentProcess()
        lblMem.Text = x.WorkingSet64 / 1024 & "K"
        lblmemav.Text = My.Computer.Info.AvailablePhysicalMemory / 1024 & "K"
        LogBox.ForeColor = Color.White
        LogBox.SelectedIndex = LogBox.Items.Count - 1
        nullSelecter.Select()
        If SelecterMode = True Then
            SelecterInfo.Location = New Point(9, 443)
            OutputBox.Location = New Point(449, 706)

        Else
            SelecterInfo.Location = New Point(449, 706)
            OutputBox.Location = New Point(9, 443)
        End If

        Try
            If SelItem.Tag = inventoryGetCursor.Tag Then Exit Sub
        Catch ex As Exception
        End Try
        inventory("UpdateActive", vbNull)
    End Sub


    Public Sub btnExitForce_Click(sender As Object, e As EventArgs) Handles btnExitForce.Click
        frmMenu.Show()
        Close()
    End Sub

    Public Sub btnExitDesktop_Click(sender As Object, e As EventArgs) Handles btnExitDesktop.Click
        'XXX Call Save Game
        End
    End Sub

    Public Sub btnExitMenu_Click(sender As Object, e As EventArgs) Handles btnExitMenu.Click
        'XXX Call Save Game
        frmMenu.frmMenu_Load(Me, EventArgs.Empty)
        frmMenu.Show()
        Close()
    End Sub

    Public Sub frmGame_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.BackColor = Color.Navy
    End Sub

    Public Sub frmGame_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Me.BackColor = Color.Gray
    End Sub

    Public Sub frmGame_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        If SelecterMode Then SelecterEngine("Close", vbNull)
        If e.Delta > 0 Then
            inventory("Scroll", "Up")
        Else
            inventory("Scroll", "Down")
        End If
    End Sub
    'END CONTAINER MISC
End Class