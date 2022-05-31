<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ServiceHome
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
        Me.GenMap = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.btnIdGen = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'GenMap
        '
        Me.GenMap.Location = New System.Drawing.Point(12, 12)
        Me.GenMap.Name = "GenMap"
        Me.GenMap.Size = New System.Drawing.Size(103, 35)
        Me.GenMap.TabIndex = 0
        Me.GenMap.Text = "Create new map"
        Me.GenMap.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(12, 53)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(222, 35)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Edit Existing Map"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(12, 94)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(222, 35)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Edit user data"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(12, 217)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(103, 35)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Quit"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(131, 217)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(103, 35)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "Log Out"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Enabled = False
        Me.Button6.Location = New System.Drawing.Point(12, 135)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(222, 35)
        Me.Button6.TabIndex = 5
        Me.Button6.Text = "Tile data editor"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(131, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(103, 35)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Continue from memory"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(12, 176)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(103, 35)
        Me.Button7.TabIndex = 7
        Me.Button7.Text = "Key map"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'btnIdGen
        '
        Me.btnIdGen.Location = New System.Drawing.Point(131, 176)
        Me.btnIdGen.Name = "btnIdGen"
        Me.btnIdGen.Size = New System.Drawing.Size(103, 35)
        Me.btnIdGen.TabIndex = 8
        Me.btnIdGen.Text = "ID Generator"
        Me.btnIdGen.UseVisualStyleBackColor = True
        '
        'ServiceHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(246, 263)
        Me.Controls.Add(Me.btnIdGen)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GenMap)
        Me.Name = "ServiceHome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ServiceHome"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GenMap As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents btnIdGen As Button
End Class
