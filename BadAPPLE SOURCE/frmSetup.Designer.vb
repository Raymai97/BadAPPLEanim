<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetup
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
        Me.btnStart = New System.Windows.Forms.Button()
        Me.rdoWindowed = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rdoLayered = New System.Windows.Forms.RadioButton()
        Me.chkBitblt = New System.Windows.Forms.CheckBox()
        Me.chkTransBg = New System.Windows.Forms.CheckBox()
        Me.chkFullScr = New System.Windows.Forms.CheckBox()
        Me.chkShowTaskbar = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBGM = New System.Windows.Forms.TextBox()
        Me.lnkBrowseBGM = New System.Windows.Forms.LinkLabel()
        Me.lnkTestBGM = New System.Windows.Forms.LinkLabel()
        Me.chkTopMost = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(252, 370)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(90, 28)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'rdoWindowed
        '
        Me.rdoWindowed.AutoSize = True
        Me.rdoWindowed.BackColor = System.Drawing.Color.Black
        Me.rdoWindowed.Checked = True
        Me.rdoWindowed.ForeColor = System.Drawing.Color.White
        Me.rdoWindowed.Location = New System.Drawing.Point(213, 119)
        Me.rdoWindowed.Name = "rdoWindowed"
        Me.rdoWindowed.Size = New System.Drawing.Size(82, 19)
        Me.rdoWindowed.TabIndex = 1
        Me.rdoWindowed.TabStop = True
        Me.rdoWindowed.Text = "Windowed"
        Me.rdoWindowed.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(194, 95)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "- Window mode -"
        '
        'rdoLayered
        '
        Me.rdoLayered.AutoSize = True
        Me.rdoLayered.BackColor = System.Drawing.Color.Black
        Me.rdoLayered.ForeColor = System.Drawing.Color.White
        Me.rdoLayered.Location = New System.Drawing.Point(229, 147)
        Me.rdoLayered.Name = "rdoLayered"
        Me.rdoLayered.Size = New System.Drawing.Size(66, 19)
        Me.rdoLayered.TabIndex = 1
        Me.rdoLayered.Text = "Layered"
        Me.rdoLayered.UseVisualStyleBackColor = False
        '
        'chkBitblt
        '
        Me.chkBitblt.AutoSize = True
        Me.chkBitblt.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.chkBitblt.ForeColor = System.Drawing.Color.Black
        Me.chkBitblt.Location = New System.Drawing.Point(313, 119)
        Me.chkBitblt.Name = "chkBitblt"
        Me.chkBitblt.Size = New System.Drawing.Size(183, 19)
        Me.chkBitblt.TabIndex = 4
        Me.chkBitblt.Text = "Use Bitblt (faster on some PC)"
        Me.chkBitblt.UseVisualStyleBackColor = False
        '
        'chkTransBg
        '
        Me.chkTransBg.AutoSize = True
        Me.chkTransBg.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.chkTransBg.Enabled = False
        Me.chkTransBg.ForeColor = System.Drawing.Color.Black
        Me.chkTransBg.Location = New System.Drawing.Point(313, 147)
        Me.chkTransBg.Name = "chkTransBg"
        Me.chkTransBg.Size = New System.Drawing.Size(156, 19)
        Me.chkTransBg.TabIndex = 4
        Me.chkTransBg.Text = "Transparent background"
        Me.chkTransBg.UseVisualStyleBackColor = False
        '
        'chkFullScr
        '
        Me.chkFullScr.AutoSize = True
        Me.chkFullScr.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.chkFullScr.Enabled = False
        Me.chkFullScr.ForeColor = System.Drawing.Color.Black
        Me.chkFullScr.Location = New System.Drawing.Point(313, 172)
        Me.chkFullScr.Name = "chkFullScr"
        Me.chkFullScr.Size = New System.Drawing.Size(79, 19)
        Me.chkFullScr.TabIndex = 4
        Me.chkFullScr.Text = "Fullscreen"
        Me.chkFullScr.UseVisualStyleBackColor = False
        '
        'chkShowTaskbar
        '
        Me.chkShowTaskbar.AutoSize = True
        Me.chkShowTaskbar.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.chkShowTaskbar.Enabled = False
        Me.chkShowTaskbar.ForeColor = System.Drawing.Color.Black
        Me.chkShowTaskbar.Location = New System.Drawing.Point(398, 172)
        Me.chkShowTaskbar.Name = "chkShowTaskbar"
        Me.chkShowTaskbar.Size = New System.Drawing.Size(116, 19)
        Me.chkShowTaskbar.TabIndex = 4
        Me.chkShowTaskbar.Text = "but show taskbar"
        Me.chkShowTaskbar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(115, 259)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "- BGM -"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBGM
        '
        Me.txtBGM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtBGM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem
        Me.txtBGM.BackColor = System.Drawing.Color.Black
        Me.txtBGM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBGM.ForeColor = System.Drawing.Color.White
        Me.txtBGM.Location = New System.Drawing.Point(115, 280)
        Me.txtBGM.Name = "txtBGM"
        Me.txtBGM.Size = New System.Drawing.Size(180, 23)
        Me.txtBGM.TabIndex = 5
        Me.txtBGM.Text = "%mypath%\ba.mp3"
        '
        'lnkBrowseBGM
        '
        Me.lnkBrowseBGM.ActiveLinkColor = System.Drawing.Color.Blue
        Me.lnkBrowseBGM.AutoSize = True
        Me.lnkBrowseBGM.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.lnkBrowseBGM.DisabledLinkColor = System.Drawing.Color.Silver
        Me.lnkBrowseBGM.ForeColor = System.Drawing.Color.Black
        Me.lnkBrowseBGM.LinkColor = System.Drawing.Color.Black
        Me.lnkBrowseBGM.Location = New System.Drawing.Point(310, 282)
        Me.lnkBrowseBGM.Margin = New System.Windows.Forms.Padding(3)
        Me.lnkBrowseBGM.Name = "lnkBrowseBGM"
        Me.lnkBrowseBGM.Size = New System.Drawing.Size(45, 15)
        Me.lnkBrowseBGM.TabIndex = 6
        Me.lnkBrowseBGM.TabStop = True
        Me.lnkBrowseBGM.Text = "Browse"
        Me.lnkBrowseBGM.VisitedLinkColor = System.Drawing.Color.Black
        '
        'lnkTestBGM
        '
        Me.lnkTestBGM.ActiveLinkColor = System.Drawing.Color.Blue
        Me.lnkTestBGM.AutoSize = True
        Me.lnkTestBGM.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.lnkTestBGM.DisabledLinkColor = System.Drawing.Color.Silver
        Me.lnkTestBGM.ForeColor = System.Drawing.Color.Black
        Me.lnkTestBGM.LinkColor = System.Drawing.Color.Black
        Me.lnkTestBGM.Location = New System.Drawing.Point(361, 282)
        Me.lnkTestBGM.Margin = New System.Windows.Forms.Padding(3)
        Me.lnkTestBGM.Name = "lnkTestBGM"
        Me.lnkTestBGM.Size = New System.Drawing.Size(29, 15)
        Me.lnkTestBGM.TabIndex = 6
        Me.lnkTestBGM.TabStop = True
        Me.lnkTestBGM.Text = "Test"
        Me.lnkTestBGM.VisitedLinkColor = System.Drawing.Color.Black
        '
        'chkTopMost
        '
        Me.chkTopMost.AutoSize = True
        Me.chkTopMost.BackColor = System.Drawing.Color.Black
        Me.chkTopMost.ForeColor = System.Drawing.Color.White
        Me.chkTopMost.Location = New System.Drawing.Point(189, 176)
        Me.chkTopMost.Name = "chkTopMost"
        Me.chkTopMost.Size = New System.Drawing.Size(106, 19)
        Me.chkTopMost.TabIndex = 4
        Me.chkTopMost.Text = "Always On Top"
        Me.chkTopMost.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(310, 12)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(171, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "a remade from MaiSoft (2013)..."
        '
        'frmSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BadAppleAnim.My.Resources.Resources.ba
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(594, 422)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lnkTestBGM)
        Me.Controls.Add(Me.lnkBrowseBGM)
        Me.Controls.Add(Me.txtBGM)
        Me.Controls.Add(Me.chkTopMost)
        Me.Controls.Add(Me.chkShowTaskbar)
        Me.Controls.Add(Me.chkFullScr)
        Me.Controls.Add(Me.chkTransBg)
        Me.Controls.Add(Me.chkBitblt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rdoLayered)
        Me.Controls.Add(Me.rdoWindowed)
        Me.Controls.Add(Me.btnStart)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bad APPLE Anim Setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents rdoWindowed As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rdoLayered As System.Windows.Forms.RadioButton
    Friend WithEvents chkBitblt As System.Windows.Forms.CheckBox
    Friend WithEvents chkTransBg As System.Windows.Forms.CheckBox
    Friend WithEvents chkFullScr As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowTaskbar As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBGM As System.Windows.Forms.TextBox
    Friend WithEvents lnkBrowseBGM As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkTestBGM As System.Windows.Forms.LinkLabel
    Friend WithEvents chkTopMost As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
