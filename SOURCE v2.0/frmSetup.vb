Imports BadAppleAnim.baShared

Public Class frmSetup

    Private Sub rdoWindowed_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoWindowed.CheckedChanged
        chkBitblt.Enabled = rdoWindowed.Checked
    End Sub

    Private Sub rdoLayered_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoLayered.CheckedChanged
        chkFullScr.Enabled = rdoLayered.Checked
        chkTransBg.Enabled = rdoLayered.Checked
    End Sub

    Private Sub chkFullScr_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkFullScr.CheckedChanged, chkFullScr.EnabledChanged
        chkShowTaskbar.Enabled = chkFullScr.Enabled AndAlso chkFullScr.Checked
    End Sub

    Private Sub frmSetup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Icon = GetIconOf(Application.ExecutablePath, True)
        txtBGM.Text = IO.Path.GetFullPath("ba.mp3")
    End Sub

    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click
        baShared.UseBitBlt = chkBitblt.Checked
        baShared.FullScreen = chkFullScr.Checked
        baShared.ShowTaskbar = chkShowTaskbar.Checked
        baShared.TransBg = chkTransBg.Checked
        baShared.AlwaysOnTop = chkTopMost.Checked
        Try
            Reader = New SSPReader(IO.Path.GetFullPath("ba.ssp"))
        Catch ex As Exception
            MsgBox("Cannot load ba.ssp!" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Error") : Return
        End Try
        If BGM._Open(txtBGM.Text) = False Then
            MsgBox("Cannot open BGM file. The program will continue without playing BGM.", MsgBoxStyle.Exclamation, "Error")
        End If
        If rdoLayered.Checked Then
            MsgBox("Press ESC when you want to exit.", MsgBoxStyle.Information)
            frmLayered.Show()
        Else
            frmStandard.Show()
        End If
        Me.Close()
    End Sub

    Private Sub lnkBrowseBGM_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkBrowseBGM.LinkClicked
        Dim ofd As New OpenFileDialog
        ofd.FileName = ""
        ofd.Title = "Select BGM for Bad APPLE"
        ofd.Filter = "Supported music files|*.wma;*.mp3"
        ofd.ShowDialog()
        If ofd.FileName <> "" Then
            txtBGM.Text = ofd.FileName
        End If
    End Sub

    Private Sub lnkTestBGM_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkTestBGM.LinkClicked
        If BGM._Open(txtBGM.Text) Then
            BGM._PlayFrom0()
            MsgBox("You should hear the BGM now. Press OK to stop.", MsgBoxStyle.Information)
            BGM._Close()
        Else
            MsgBox("Cannot open the BGM file!", MsgBoxStyle.Exclamation)
        End If
    End Sub
End Class