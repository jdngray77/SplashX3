Public Class NewUser
    Private Sub NewUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Controls.Clear()
        Me.InitializeComponent()
        Label6.Text = DateAndTime.DateString

        Label8.Text = frmMenu.CurrentUser
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("./AppData/User" & CInt(Label8.Text) & ".usr")
            'Specify that reading from a comma-delimited file
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentRow As String()
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    DataImport.Rows.Add(currentRow) 'Add new row to data grid view'
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    frmGame.MessageEngine("ERROR: At User Load, New User, Load: " & ex.Message, "Error")
                End Try
            End While
        End Using

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If Not TextBox3.Text = TextBox2.Text Then
            TextBox3.BackColor = Color.Red
        Else
            TextBox3.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TextBox2.BackColor = Color.LightGray
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Then
            TextBox2.BackColor = Color.Red
            Exit Sub
        End If

        If TextBox1.Text = "" Then
            TextBox1.BackColor = Color.Red
            Exit Sub
        End If

        DataImport(0, 1).Value = TextBox1.Text
        DataImport(2, 1).Value = DateAndTime.DateString
        DataImport(3, 1).Value = "Never"
        DataImport(3, 1).Value = "0"
        DataImport(6, 1).Value = "User"
        DataImport(5, 1).Value = TextBox2.Text
        Dim headers = (From header As DataGridViewColumn In DataImport.Columns.Cast(Of DataGridViewColumn)()
                       Select header.HeaderText).ToArray
        Dim rows = From row As DataGridViewRow In DataImport.Rows.Cast(Of DataGridViewRow)()
                   Where Not row.IsNewRow
                   Select Array.ConvertAll(row.Cells.Cast(Of DataGridViewCell).ToArray, Function(c) If(c.Value IsNot Nothing, c.Value.ToString, ""))
        Using sw As New IO.StreamWriter("./AppData/User" & CInt(Label8.Text) & ".usr")
            For Each r In rows
                sw.WriteLine(String.Join(",", r))
            Next
        End Using
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox2.BackColor = Color.LightGray
    End Sub
End Class