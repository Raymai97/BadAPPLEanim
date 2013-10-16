Imports BadAppleAnim.baShared
Imports System.Threading

Public Class frmLayered

    Dim hWnd As IntPtr

    Protected Overrides ReadOnly Property CreateParams As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_LAYERED
            Return cp
        End Get
    End Property

    ''' <summary>
    ''' Let this Form transforms into Bitmap.
    ''' </summary>
    ''' <param name="Bmp"></param>
    ''' <param name="Opacity">Specifies an alpha transparency value to be used on the entire source bitmap. 
    ''' The SourceConstantAlpha value is combined with any per-pixel alpha values in the source bitmap. 
    ''' The value ranges from 0 to 255. If you set SourceConstantAlpha to 0, it is assumed that your image is transparent. 
    ''' When you only want to use per-pixel alpha values, set the SourceConstantAlpha value to 255 (opaque).</param>
    ''' <remarks></remarks>
    Public Sub ShowAsBmp(Bmp As Bitmap, Optional Opacity As Integer = 255)
        ' Is Bmp a 32bppArgb Bitmap?
        If Bmp.PixelFormat <> Imaging.PixelFormat.Format32bppArgb Then
            Throw New Exception("Unsupported Bitmap.")
        End If

        Dim srcDc As IntPtr = GetDC(IntPtr.Zero)
        Dim memDc As IntPtr = CreateCompatibleDC(srcDc)
        Dim hBmp, hOldBmp As IntPtr

        Try
            hBmp = Bmp.GetHbitmap(Color.FromArgb(0))
            hOldBmp = SelectObject(memDc, hBmp)
            ' Parameters for layered window update.
            Dim layerlocation As New _POINT(0, 0)
            Dim frmlocation As New _POINT(Me.Left, Me.Top)
            Dim frmsize As New _SIZE(Bmp.Width, Bmp.Height)
            Dim blend As New _BLENDFUNCTION
            With blend
                .BlendOp = AC_SRC_OVER
                .BlendFlags = 0
                .SourceConstantAlpha = Opacity
                .AlphaFormat = AC_SRC_ALPHA
            End With
            ' Update the window.
            UpdateLayeredWindow( _
                hWnd, _
                srcDc, _
                frmlocation, _
                frmsize, _
                memDc, _
                layerlocation, _
                0, _
                blend, _
                ULW_ALPHA _
                )
        Catch ex As Exception
        Finally
            ReleaseDC(IntPtr.Zero, srcDc)
            If hBmp <> IntPtr.Zero Then
                SelectObject(memDc, hOldBmp)
                DeleteObject(hBmp)
            End If
            DeleteDC(memDc)
        End Try
    End Sub

    ' STANDARD CODE

    Dim DispSize As Size
    Dim Stopwatch As New Stopwatch
    Dim IMGindex As Integer

    Dim DrawThread As Thread

    Sub DrawLoop()
        Do While Me.Visible And Me.IsDisposed = False And Me.Disposing = False
            'calc the frame
            IMGindex = Fix(Stopwatch.ElapsedMilliseconds / 33.2)
            If IMGindex >= 6569 Then
                Me.Invoke(New MethodInvoker(AddressOf BGM._PlayFrom0))
                Stopwatch.Reset() : Stopwatch.Start()
                IMGindex = 0
            End If
            'prepare streteched bmp
            Using Bmp As New Bitmap(DispSize.Width, DispSize.Height)
                Using gBmp As Graphics = Graphics.FromImage(Bmp)
                    Using Frame As Bitmap = GetFrame(IMGindex)
                        If Not TransBg Then
                            gBmp.Clear(Color.White)
                        End If
                        gBmp.DrawImage(Frame, Me.ClientRectangle)
                    End Using
                End Using
                'draw it
                ShowAsBmp(Bmp)
            End Using
        Loop
    End Sub

    Public Sub New()
        InitializeComponent()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, False)
    End Sub

    Private Sub frmLayered_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        timeEndPeriod(1)
        End
    End Sub

    Private Sub frmLayered_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        timeBeginPeriod(1)
        Me.TopMost = AlwaysOnTop
        If FullScreen Then
            If ShowTaskbar Then
                Me.Location = New Point(0, 0)
                DispSize = Screen.PrimaryScreen.WorkingArea.Size
            Else
                Me.WindowState = FormWindowState.Maximized
                DispSize = Me.Size
            End If
        Else
            DispSize = New Size(700, 500)
        End If
        Me.Size = DispSize
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - DispSize.Width) \ 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - DispSize.Height) \ 2
        hWnd = Me.Handle
    End Sub

    Private Sub frmLayered_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        BGM._PlayFrom0()
        Stopwatch.Start()
        DrawThread = New Thread(AddressOf DrawLoop)
        DrawThread.IsBackground = True
        DrawThread.Start()
    End Sub

#Region " typical movable window code "

    Dim mDown As Boolean
    Dim mPos, frmPos As Point

    Private Sub frmLayered_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        mDown = True
        mPos = MousePosition
        frmPos = Me.Location
    End Sub

    Private Sub frmLayered_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If mDown And Not FullScreen Then
            Dim mPos2 As Point = MousePosition
            Me.Left = frmPos.X + mPos2.X - mPos.X
            Me.Top = frmPos.Y + mPos2.Y - mPos.Y
        End If
    End Sub

    Private Sub frmLayered_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        mDown = False
    End Sub

#End Region

    Private Sub frmLayered_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class