Imports BadAppleAnim.baShared
Imports System.Threading

Public Class frmStandard

    Dim DispWidth, DispHeight As Integer
    Dim Stopwatch As New Stopwatch

    Dim DLLindex, IMGindex As Integer

    Sub Advance()
        If IMGindex >= 6569 Then
            Me.Invoke(New MethodInvoker(AddressOf BGM._PlayFrom0))
            DLLindex = 0
            IMGindex = 0
        Else
            IMGindex += 1
            DLLindex = IMGindex \ 1000
        End If
    End Sub

    Dim DrawThread, FrameThread As Thread

    Sub DrawLoop()
        Do While Me.Visible And Me.IsDisposed = False And Me.Disposing = False
            'CreateGraphics all the time to support resizing window
            Using g As Graphics = Me.CreateGraphics
                'prepare streteched bmp
                Using Bmp As New Bitmap(DispWidth, DispHeight)
                    Using gBmp As Graphics = Graphics.FromImage(Bmp)
                        Dim Frame As Bitmap = DLLs(DLLindex).GetNo(IMGindex)
                        gBmp.Clear(Color.White)
                        gBmp.DrawImage(Frame, Me.ClientRectangle)
                    End Using
                    'draw it
                    If UseBitBlt Then
                        Dim hDc As IntPtr = g.GetHdc
                        Dim hMemDc As IntPtr = CreateCompatibleDC(hDc)
                        Dim hBmp As IntPtr = Bmp.GetHbitmap
                        Dim hOldBmp As IntPtr = SelectObject(hMemDc, hBmp)
                        BitBlt(hDc, 0, 0, Bmp.Width, Bmp.Height, hMemDc, 0, 0, SRCCOPY)
                        SelectObject(hMemDc, hOldBmp)
                        DeleteObject(hBmp)
                        g.ReleaseHdc(hDc)
                        DeleteDC(hMemDc)
                    Else
                        g.DrawImageUnscaled(Bmp, Point.Empty)
                    End If
                    'FrameLoop will handle the timing job
                    Thread.Sleep(1)
                End Using
            End Using
        Loop
    End Sub

    Sub FrameLoop()
        Do While Me.Visible And Me.IsDisposed = False And Me.Disposing = False
            Stopwatch.Restart()
            Advance()
            'advance 30 times of frame per second
            Dim FPS As Integer = 30
            Dim TimeTaken As Integer = Stopwatch.ElapsedMilliseconds
            If TimeTaken < 1000 Then
                Do While TimeTaken > 1000 / FPS
                    FPS -= 1
                Loop
                Thread.Sleep(1000 / FPS - TimeTaken)
            End If
        Loop
    End Sub

    Public Sub New()
        InitializeComponent()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, False)
    End Sub

    Private Sub frmStandard_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        timeEndPeriod(1)
        End
    End Sub

    Private Sub frmStandard_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Icon = GetIconOf(Application.ExecutablePath, True)
        Me.TopMost = AlwaysOnTop
        timeBeginPeriod(1)
    End Sub

    Private Sub frmStandard_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        If Me.ClientSize.Width > 3 And Me.ClientSize.Height > 3 Then
            DispWidth = Me.ClientSize.Width
            DispHeight = Me.ClientSize.Height
        End If
    End Sub

    Private Sub frmStandard_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        BGM._PlayFrom0()
        DrawThread = New Thread(AddressOf DrawLoop)
        DrawThread.IsBackground = True
        DrawThread.Start()
        FrameThread = New Thread(AddressOf FrameLoop)
        FrameThread.IsBackground = True
        FrameThread.Priority = ThreadPriority.Highest
        FrameThread.Start()
    End Sub

End Class
