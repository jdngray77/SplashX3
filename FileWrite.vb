Imports System.ComponentModel

Public Class FileWrite
    Private index


    Public Sub LoadData()
        Me.Controls.Clear()
        Me.InitializeComponent()
        If Not System.IO.File.Exists("CharData.csv") Then
            System.IO.File.Create("CharData.csv").Dispose()
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter("CharData.csv", True)
            file.WriteLine("Inventory,Unlocked,Axe,Apple")
            file.WriteLine(",False,False,False")
            file.WriteLine("Player Position,Map Family,Map Name,X,Y,DeathCause")
            file.WriteLine(",Splash,SplashMap,1,5,null")
            file.WriteLine("Game Data,Storyline,Story Progress, Player Health, Max Health")
            file.WriteLine(",SplashStory,1,10,10")
            file.Close()
        End If
        DataGridView1.AutoGenerateColumns = True
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("CharData.csv")
            Dim counter As Integer = 0
            'Specify that reading from a comma-delimited file'
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentRow As String()
            While Not MyReader.EndOfData
                Try
                    counter += 1
                    currentRow = MyReader.ReadFields()
                    DataGridView1.Rows.Add(currentRow) 'Add new row to data grid view'
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                End Try
            End While
        End Using
    End Sub

    Public Function LoadWorld()
        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = DataGridView1(2, 3)
        Return (DataGridView1.CurrentCell.Value)
    End Function

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim headers = (From header As DataGridViewColumn In DataGridView1.Columns.Cast(Of DataGridViewColumn)()
                       Select header.HeaderText).ToArray
        Dim rows = From row As DataGridViewRow In DataGridView1.Rows.Cast(Of DataGridViewRow)()
                   Where Not row.IsNewRow
                   Select Array.ConvertAll(row.Cells.Cast(Of DataGridViewCell).ToArray, Function(c) If(c.Value IsNot Nothing, c.Value.ToString, ""))
        Using sw As New IO.StreamWriter("CharData.csv")
            For Each r In rows
                sw.WriteLine(String.Join(",", r))
            Next
        End Using

        Dim lines() As String
        Dim outputlines As New List(Of String)
        Dim searchString As String = "Column"
        lines = IO.File.ReadAllLines("CharData.csv")
        Me.Hide()
    End Sub

    Public Sub WriteToTable(FieldX, FieldY, Data)
        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = DataGridView1(FieldX, FieldY)
        DataGridView1.CurrentCell.Value = Data
    End Sub


    Public Function ReadFromTable(FieldX, FieldY)
        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = DataGridView1(FieldX, FieldY)
        Return (DataGridView1.CurrentCell.Value)
    End Function

    Public Sub SaveToFile()
        btnUpdate_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        cellSelect()
    End Sub

    Public Sub cellSelect()
        DataGridView1.ClearSelection()
        Try
            DataGridView1.CurrentCell = DataGridView1(CInt(NumericUpDown1.Value), CInt(NumericUpDown2.Value))
        Catch
        End Try
    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        cellSelect()
    End Sub

    Private Sub FileWrite_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class