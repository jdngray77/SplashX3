<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DebugMenuForm
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
        Me.components = New System.ComponentModel.Container()
        Me.groupdebugmenu = New System.Windows.Forms.GroupBox()
        Me.btnEND = New System.Windows.Forms.Button()
        Me.btnReload = New System.Windows.Forms.Button()
        Me.btnRedraw = New System.Windows.Forms.Button()
        Me.comboInventory = New System.Windows.Forms.GroupBox()
        Me.InvGive = New System.Windows.Forms.Button()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ComboInvItem = New System.Windows.Forms.ComboBox()
        Me.optdebugfreecam = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SelecterEnabled = New System.Windows.Forms.CheckBox()
        Me.optdebugSelecterZoneLimit = New System.Windows.Forms.CheckBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.DebugMenu = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.groupdebugmenu.SuspendLayout()
        Me.comboInventory.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupdebugmenu
        '
        Me.groupdebugmenu.Controls.Add(Me.btnEND)
        Me.groupdebugmenu.Controls.Add(Me.btnReload)
        Me.groupdebugmenu.Controls.Add(Me.btnRedraw)
        Me.groupdebugmenu.Controls.Add(Me.comboInventory)
        Me.groupdebugmenu.Controls.Add(Me.optdebugfreecam)
        Me.groupdebugmenu.Controls.Add(Me.GroupBox2)
        Me.groupdebugmenu.Controls.Add(Me.DebugMenu)
        Me.groupdebugmenu.ForeColor = System.Drawing.Color.Lime
        Me.groupdebugmenu.Location = New System.Drawing.Point(12, 12)
        Me.groupdebugmenu.Name = "groupdebugmenu"
        Me.groupdebugmenu.Size = New System.Drawing.Size(421, 250)
        Me.groupdebugmenu.TabIndex = 0
        Me.groupdebugmenu.TabStop = False
        Me.groupdebugmenu.Text = "Debug Menu"
        '
        'btnEND
        '
        Me.btnEND.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEND.Location = New System.Drawing.Point(167, 19)
        Me.btnEND.Name = "btnEND"
        Me.btnEND.Size = New System.Drawing.Size(100, 21)
        Me.btnEND.TabIndex = 13
        Me.btnEND.Text = "Call process END"
        Me.btnEND.UseVisualStyleBackColor = True
        '
        'btnReload
        '
        Me.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReload.Location = New System.Drawing.Point(167, 46)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(100, 21)
        Me.btnReload.TabIndex = 12
        Me.btnReload.Text = "Reload"
        Me.btnReload.UseVisualStyleBackColor = True
        '
        'btnRedraw
        '
        Me.btnRedraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRedraw.Location = New System.Drawing.Point(167, 73)
        Me.btnRedraw.Name = "btnRedraw"
        Me.btnRedraw.Size = New System.Drawing.Size(100, 21)
        Me.btnRedraw.TabIndex = 11
        Me.btnRedraw.Text = "Re-draw level"
        Me.btnRedraw.UseVisualStyleBackColor = True
        '
        'comboInventory
        '
        Me.comboInventory.Controls.Add(Me.InvGive)
        Me.comboInventory.Controls.Add(Me.ListBox2)
        Me.comboInventory.Controls.Add(Me.ComboInvItem)
        Me.comboInventory.ForeColor = System.Drawing.Color.Lime
        Me.comboInventory.Location = New System.Drawing.Point(6, 96)
        Me.comboInventory.Name = "comboInventory"
        Me.comboInventory.Size = New System.Drawing.Size(155, 71)
        Me.comboInventory.TabIndex = 9
        Me.comboInventory.TabStop = False
        Me.comboInventory.Text = "Inventory"
        '
        'InvGive
        '
        Me.InvGive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.InvGive.Location = New System.Drawing.Point(72, 19)
        Me.InvGive.Name = "InvGive"
        Me.InvGive.Size = New System.Drawing.Size(75, 21)
        Me.InvGive.TabIndex = 10
        Me.InvGive.Text = "Give"
        Me.InvGive.UseVisualStyleBackColor = True
        '
        'ListBox2
        '
        Me.ListBox2.BackColor = System.Drawing.Color.Black
        Me.ListBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox2.ForeColor = System.Drawing.Color.Lime
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Items.AddRange(New Object() {"Debug toggles", "Give player item", "Loaded map", "Loaded Save", "Reload"})
        Me.ListBox2.Location = New System.Drawing.Point(6, 331)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(194, 65)
        Me.ListBox2.TabIndex = 2
        '
        'ComboInvItem
        '
        Me.ComboInvItem.BackColor = System.Drawing.Color.Black
        Me.ComboInvItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboInvItem.ForeColor = System.Drawing.Color.Lime
        Me.ComboInvItem.FormattingEnabled = True
        Me.ComboInvItem.Items.AddRange(New Object() {"PathAxe", "WoodPlank"})
        Me.ComboInvItem.Location = New System.Drawing.Point(6, 19)
        Me.ComboInvItem.Name = "ComboInvItem"
        Me.ComboInvItem.Size = New System.Drawing.Size(61, 21)
        Me.ComboInvItem.TabIndex = 9
        '
        'optdebugfreecam
        '
        Me.optdebugfreecam.AutoSize = True
        Me.optdebugfreecam.Location = New System.Drawing.Point(273, 19)
        Me.optdebugfreecam.Name = "optdebugfreecam"
        Me.optdebugfreecam.Size = New System.Drawing.Size(70, 17)
        Me.optdebugfreecam.TabIndex = 8
        Me.optdebugfreecam.Text = "Free cam"
        Me.optdebugfreecam.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.SelecterEnabled)
        Me.GroupBox2.Controls.Add(Me.optdebugSelecterZoneLimit)
        Me.GroupBox2.Controls.Add(Me.ListBox1)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Lime
        Me.GroupBox2.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(155, 71)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "SelecterEngine"
        '
        'SelecterEnabled
        '
        Me.SelecterEnabled.AutoSize = True
        Me.SelecterEnabled.Location = New System.Drawing.Point(6, 19)
        Me.SelecterEnabled.Name = "SelecterEnabled"
        Me.SelecterEnabled.Size = New System.Drawing.Size(92, 17)
        Me.SelecterEnabled.TabIndex = 7
        Me.SelecterEnabled.Text = "SelecterMode"
        Me.SelecterEnabled.UseVisualStyleBackColor = True
        '
        'optdebugSelecterZoneLimit
        '
        Me.optdebugSelecterZoneLimit.AutoSize = True
        Me.optdebugSelecterZoneLimit.Location = New System.Drawing.Point(6, 42)
        Me.optdebugSelecterZoneLimit.Name = "optdebugSelecterZoneLimit"
        Me.optdebugSelecterZoneLimit.Size = New System.Drawing.Size(141, 17)
        Me.optdebugSelecterZoneLimit.TabIndex = 6
        Me.optdebugSelecterZoneLimit.Text = "debugSelecterZoneLimit"
        Me.optdebugSelecterZoneLimit.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.Black
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox1.ForeColor = System.Drawing.Color.Lime
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Items.AddRange(New Object() {"Debug toggles", "Give player item", "Loaded map", "Loaded Save", "Reload"})
        Me.ListBox1.Location = New System.Drawing.Point(6, 331)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(194, 65)
        Me.ListBox1.TabIndex = 2
        '
        'DebugMenu
        '
        Me.DebugMenu.BackColor = System.Drawing.Color.Black
        Me.DebugMenu.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DebugMenu.ForeColor = System.Drawing.Color.Lime
        Me.DebugMenu.FormattingEnabled = True
        Me.DebugMenu.Items.AddRange(New Object() {"Debug toggles", "Give player item", "Loaded map", "Loaded Save", "Reload"})
        Me.DebugMenu.Location = New System.Drawing.Point(6, 331)
        Me.DebugMenu.Name = "DebugMenu"
        Me.DebugMenu.Size = New System.Drawing.Size(194, 65)
        Me.DebugMenu.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Red
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(-1, -1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(16, 18)
        Me.Button1.TabIndex = 5
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 50
        '
        'DebugMenuForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(445, 274)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.groupdebugmenu)
        Me.ForeColor = System.Drawing.Color.Lime
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DebugMenuForm"
        Me.Text = "DebugMenu"
        Me.TopMost = True
        Me.groupdebugmenu.ResumeLayout(False)
        Me.groupdebugmenu.PerformLayout()
        Me.comboInventory.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents groupdebugmenu As GroupBox
    Friend WithEvents DebugMenu As ListBox
    Friend WithEvents Button1 As Button
    Friend WithEvents optdebugSelecterZoneLimit As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents SelecterEnabled As CheckBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents optdebugfreecam As CheckBox
    Friend WithEvents comboInventory As GroupBox
    Friend WithEvents InvGive As Button
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents ComboInvItem As ComboBox
    Friend WithEvents btnReload As Button
    Friend WithEvents btnRedraw As Button
    Friend WithEvents btnEND As Button
End Class
