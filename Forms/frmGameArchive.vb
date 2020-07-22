Class frmGameArchive

    'CONTAINER ACTIVE
    Private Sub frmGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load Game
        'Enable viewing of keypresses
        KeyPreview = True

        'Load User profile into memory
        FileEngine("Load", vbNull, vbNull, vbNull)

        'Load and drawer map
        DisplayEngine("InitMap", "GameLoad", vbNull, vbNull, vbNull)
    End Sub
    'END CONTAINER ACTIVE

    'CONTAINER PASSIVE
    Private MenuIsShown = False
    Private Sub frmGame_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        'Misc
        Select Case Asc(e.KeyChar)
            'Escape
            Case 27
                If MenuIsShown = True Then
                    PnlMenu.Location = New Point(11, 625)
                    PnlMenu.Visible = False
                    MenuIsShown = False
                Else
                    PnlMenu.Location = New Point(451, 199)
                    PnlMenu.Visible = True
                    MenuIsShown = True
                End If
        End Select

        If MenuIsShown = True Then
            Exit Sub
        End If
        'Other, active
        Select Case e.KeyChar
            Case "w"
        End Select
    End Sub
    'END CONTAINER PASSIVE


    '================== ENGINES =====================
    'Display Engine
    Private ActiveDisplayMemory(10, 10)
    'Contains what is actually drawn on screen. Used to query what is displayed, for boundarys etc.

    Private LoadedDisplayMemory(1000, 1000)
    'Contains the loaded map data from either save display memory or map file. Is modified as the user plays, and is written to save.

    Private TempDisplayMemory()
    'Contains contents of active display, is used for making changes to the display and telling display engine to draw it, without affecting the map data. Used for character etc.
    Private columnoffset = 0, rowoffset = 0
    Public Sub DisplayEngine(Action, actionArg, column, row, Style)
        Select Case Action
            Case "InitMap"
                If Not DataImport(4, 1).Value = "0" Then

                    For columncount = 0 To 99 Step 1
                        For rowcount = 0 To 99 Step 1
                            Try
                                LoadedDisplayMemory(columncount, rowcount) = DataImport(columncount, rowcount + 51)
                            Catch ex As Exception
                            End Try
                        Next
                    Next

                Else
                    Dim maptoload = New SplashMap_Part1
                    maptoload.Initialise()
                    For rowcount = 1 To 20 Step 1
                        For columncount = 1 To 10 Step 1
                            Try
                                LoadedDisplayMemory(columncount - 1, rowcount - 1) = maptoload.charSet(columncount - 1, rowcount - 1)
                                DisplayEngine("PlaceTile", "ForAndBack", columncount, rowcount, LoadedDisplayMemory(columncount - 1, rowcount - 1))
                            Catch ex As Exception
                                Console.Write(vbCrLf & "ERROR: At Load Map, Display engine, Game: " & ex.Message)
                            End Try
                        Next
                    Next
                End If


            Case "ReDraw"
            Case "PlaceTile"
                Dim Cursor As PictureBox = Controls("C" & column & "R" & row)
                If actionArg = "ForAndBack" Then
                    Try
                        Cursor.BackgroundImage = My.Resources.ResourceManager.GetObject(Style)
                    Catch ex As Exception
                        Console.Write(vbCrLf & "ERROR At Back Image, Display Engine, Game: " & ex.Message)
                    End Try
                End If
                Try
                    Cursor.Image = My.Resources.ResourceManager.GetObject(Style)
                Catch ex As Exception
                    Console.Write(vbCrLf & "ERROR At fore Image, Display Engine, Game: " & ex.Message)
                End Try

            Case ""
        End Select
    End Sub

    Public Sub CharacterEngine(Action, actionarg)
        Select Case Action
            Case "Move"
            Case "Hurt"
        End Select
    End Sub

    Public Sub FileEngine(Action, actionArg, X, Y)
        Select Case Action
            Case "Load"
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
                            Console.Write(vbCrLf & "ERROR: At profile load, Game, File Write, Load: " & ex.Message)
                        End Try
                    End While
                End Using
        End Select
    End Sub


    'CONTAINER MISC
    Private Sub Game_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        BackColor = Color.Gray
    End Sub
    Private Sub Game_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BackColor = Color.Navy
    End Sub

    Private Sub btnExitForce_Click(sender As Object, e As EventArgs) Handles btnExitForce.Click
        frmMenu.Show()
        Close()
    End Sub

    Private Sub btnExitDesktop_Click(sender As Object, e As EventArgs) Handles btnExitDesktop.Click
        'XXX Call Save Game
        End
    End Sub

    Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        If MenuIsShown = True Then
            PnlMenu.Location = New Point(11, 625)
            PnlMenu.Visible = False
            MenuIsShown = False
        Else
            PnlMenu.Location = New Point(451, 199)
            PnlMenu.Visible = True
            MenuIsShown = True
        End If
    End Sub

    Private Sub btnExitMenu_Click(sender As Object, e As EventArgs) Handles btnExitMenu.Click
        'XXX Call Save Game
        frmMenu.Show()
        Close()
    End Sub
    'END CONTAINER MISC
End Class