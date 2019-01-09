<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class youdieform
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
        Me.tryagain = New System.Windows.Forms.Button()
        Me.quitbutton = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'tryagain
        '
        Me.tryagain.Location = New System.Drawing.Point(12, 165)
        Me.tryagain.Name = "tryagain"
        Me.tryagain.Size = New System.Drawing.Size(95, 51)
        Me.tryagain.TabIndex = 0
        Me.tryagain.Text = "Try again?"
        Me.tryagain.UseVisualStyleBackColor = True
        '
        'quitbutton
        '
        Me.quitbutton.Location = New System.Drawing.Point(177, 165)
        Me.quitbutton.Name = "quitbutton"
        Me.quitbutton.Size = New System.Drawing.Size(95, 51)
        Me.quitbutton.TabIndex = 1
        Me.quitbutton.Text = "Quit?"
        Me.quitbutton.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TextBox1.Location = New System.Drawing.Point(15, 44)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(257, 49)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = "You have died."
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'youdieform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Pacman_james.My.Resources.Resources.GhostScared
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.quitbutton)
        Me.Controls.Add(Me.tryagain)
        Me.Name = "youdieform"
        Me.Text = "youdieform"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tryagain As System.Windows.Forms.Button
    Friend WithEvents quitbutton As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
