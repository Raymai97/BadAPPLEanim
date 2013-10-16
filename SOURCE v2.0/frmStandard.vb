Imports BadAppleAnim.baShared
Imports System.Threading

Public Class frmStandard

    Dim DispSize As Size
    Dim Stopwatch As New Stopwatch
    Dim IMGindex As Integer

    Dim DrawThread As Thread

    Sub DrawLoop()
        Do While Me.Visible And Me.IsDisposed = False And Me.Disposing = False
            'CreateGraphics all the time to support resizing window
            Using g As Graphics = Me.CreateGraphics
                'calc the frame
                IMGindex = Fix(Stopwatch.ElapsedMilliseconds / 33.2)
                If IMGindex >= 6569 Then
                    Me.Invoke(New MethodInvoker(AddressOf BGM._PlayFrom0))
                    Stopwatch.Reset() : Stopwatch.Start()
                    IMGindex = 0
                End If
                'prepare streteched bmp
                Using Bmp As New Bitmap(DispSize.Width, DispSize.Width)
                    Using gBmp As Graphics = Graphics.FromImage(Bmp)
                        Using Frame As Bitmap = GetFrame(IMGindex)
                            gBmp.Clear(Color.White)
                            gBmp.DrawImage(Frame, Me.ClientRectangle)
                        End Using
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
                End Using
            End Using
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
            DispSize = Me.ClientSize
        End If
    End Sub

    Private Sub frmStandard_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        BGM._PlayFrom0()
        Stopwatch.Start()
        DrawThread = New Thread(AddressOf DrawLoop)
        DrawThread.IsBackground = True
        DrawThread.Start()
    End Sub

End Class
