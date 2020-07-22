Public Class DebugMenuForm

    Private Sub DebugMenuForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Location = frmGame.Location
        Me.Left = frmGame.Left + frmGame.Width
        Timer1.Start()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        optdebugSelecterZoneLimit.Checked = frmGame.debugSelecterZoneLimit
        SelecterEnabled.Checked = frmGame.SelecterMode
        optdebugfreecam.Checked = frmGame.debugFreeCam
        frmGame.X1Y1.Select()
    End Sub

    Private Sub optdebugfreecam_CheckedChanged(sender As Object, e As EventArgs) Handles optdebugfreecam.CheckedChanged
        frmGame.debugFreeCam = optdebugfreecam.Checked
        If optdebugfreecam.Checked = True Then
            prevofx = frmGame.columnoffset
            prevofy = frmGame.rowoffset
        Else
            frmGame.columnoffset = prevofx
            frmGame.rowoffset = prevofy
            frmGame.DisplayEngine("ReDraw", "null", vbNull, vbNull, vbNull)
            frmGame.CharacterEngine("DrawerCharacter", "null")
        End If
    End Sub

    Private prevofx = 0, prevofy = 0
    Private Sub optdebugSelecterZoneLimit_CheckedChanged(sender As Object, e As EventArgs) Handles optdebugSelecterZoneLimit.CheckedChanged
        frmGame.debugSelecterZoneLimit = optdebugSelecterZoneLimit.Checked
    End Sub



    Private Sub SelecterEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles SelecterEnabled.CheckedChanged
        If SelecterEnabled.Checked Then frmGame.SelecterEngine("Open", "null") Else frmGame.SelecterEngine("Close", "null")
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        Using frmGame
            frmGame.LblKeyUsed.Text = "True"
            Erase frmGame.LoadedDisplayMemory, frmGame.ActiveDisplayMemory, frmGame.TempDisplayMemory
            ReDim frmGame.LoadedDisplayMemory(1000, 1000), frmGame.ActiveDisplayMemory(10, 20), frmGame.TempDisplayMemory(1000, 1000)
            frmGame.Controls.Clear()
            frmGame.callInitializeComponent()
            frmGame.Show()
            frmGame.frmGame_Load(Me, EventArgs.Empty)
            frmGame.Show()
        End Using

    End Sub

    Private Sub btnEND_Click(sender As Object, e As EventArgs) Handles btnEND.Click
        End
    End Sub

    Private Sub InvGive_Click(sender As Object, e As EventArgs) Handles InvGive.Click
        frmGame.inventory("Add", ComboInvItem.SelectedItem)
    End Sub
End Class