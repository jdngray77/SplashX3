Public Class frmStart
    Private Sub frmStart_Load(sender As Object, e As EventArgs) Handles Me.Load
        My.Computer.Audio.Play(My.Resources.Splash, AudioPlayMode.Background)
        Dim Valid = True
        FileList.Items.Clear()
        FileList.Items.AddRange({"./AppData/User1.usr", "./AppData/User2.usr", "./AppData/User3.usr"})
        FileList.SelectedIndex = 0

        If Not System.IO.Directory.Exists("./AppData/") Then
            System.IO.Directory.CreateDirectory("./AppData")
        End If

        For i = 1 To FileList.Items.Count
            FileList.SelectedIndex = i - 1
            If Not System.IO.File.Exists(FileList.SelectedItem) Then
                Valid = False
                frmGame.MessageEngine("FileList.SelectedItem & Doesn't Exist, Creating it!", "Warn")
                System.IO.File.Create(FileList.SelectedItem).Dispose()
                writedefaultfile(FileList.SelectedItem)
            End If
        Next

        If Valid = True Then
            Debugger.Log(1, "Info", "User Files already exist")
        End If
        frmMenu.Show()
    End Sub

    Public Sub writedefaultfile(path)
        frmGame.MessageEngine("Writing default save file to: " & FileList.SelectedItem, "Info")
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(path, True)
        file.WriteLine("Name,Playtime,Created,Last Played,Level Loaded, Password,Creation Tag")
        file.WriteLine("Unused,0,0/0/0,0/0/0,0,,None") 'Creation tag = 'Developer', 'User', 'None'
        file.WriteLine("(Inventory) Item, Ammount, Durability")
        For j = 0 To 47
            file.WriteLine(",")
        Next
        file.WriteLine("(Loaded Level - Screen Memory)")
        file.Close()
    End Sub
    'XXX Import character data
    'XXX Validate file structure
End Class
