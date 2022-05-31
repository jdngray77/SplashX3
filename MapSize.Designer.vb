<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MapSize
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.MaxY = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.MaxX = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.Color.DimGray
        Me.Button13.ForeColor = System.Drawing.Color.White
        Me.Button13.Location = New System.Drawing.Point(50, 65)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(48, 25)
        Me.Button13.TabIndex = 608
        Me.Button13.Text = "Done"
        Me.Button13.UseVisualStyleBackColor = False
        '
        'MaxY
        '
        Me.MaxY.Location = New System.Drawing.Point(56, 39)
        Me.MaxY.Name = "MaxY"
        Me.MaxY.Size = New System.Drawing.Size(41, 20)
        Me.MaxY.TabIndex = 607
        Me.MaxY.Text = "19"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(5, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 605
        Me.Label7.Text = "Max Y"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(5, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 604
        Me.Label6.Text = "Max X"
        '
        'MaxX
        '
        Me.MaxX.Location = New System.Drawing.Point(56, 12)
        Me.MaxX.Name = "MaxX"
        Me.MaxX.Size = New System.Drawing.Size(41, 20)
        Me.MaxX.TabIndex = 606
        Me.MaxX.Text = "9"
        '
        'MapSize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(120, 99)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.MaxY)
        Me.Controls.Add(Me.MaxX)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Name = "MapSize"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MapSize"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button13 As Button
    Friend WithEvents MaxY As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents MaxX As TextBox
End Class
