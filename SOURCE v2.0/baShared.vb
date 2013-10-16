Imports System.Runtime.InteropServices

Public Class baShared
    Public Shared AlwaysOnTop As Boolean
    Public Shared UseBitBlt As Boolean
    Public Shared TransBg, FullScreen, ShowTaskbar As Boolean
    Public Shared BGM As New MCIMedia("baBGM")

    Public Shared Reader As SSPReader

    Public Shared Function GetFrame(ImgIndex As Integer) As Bitmap
        Select Case ImgIndex
            Case 0 To 40, Is > 6512
                Return _GetFrame(0)
            Case Else
                Return _GetFrame(ImgIndex - 40)
        End Select
    End Function

    Private Shared Function _GetFrame(ImgIndex As Integer) As Bitmap
        'Return DLLs(ImgIndex \ 1000).GetNo(ImgIndex)
        Dim b() As Byte = Reader.ObtainByIndex(ImgIndex)
        Return Bitmap.FromStream(New IO.MemoryStream(b))
    End Function

    Public Const SRCCOPY As Integer = &HCC0020
    <DllImport("user32.dll", ExactSpelling:=True, SetLastError:=True)> _
    Public Shared Function GetDC(ByVal hdc As IntPtr) As IntPtr
    End Function
    <DllImport("gdi32.dll", ExactSpelling:=True, SetLastError:=True)> _
    Public Shared Function SaveDC(ByVal hdc As IntPtr) As Integer
    End Function
    <DllImport("user32.dll", ExactSpelling:=True, SetLastError:=True)> _
    Public Shared Function ReleaseDC(ByVal hdc As IntPtr, ByVal state As Integer) As Integer
    End Function
    <DllImport("gdi32.dll", ExactSpelling:=True, SetLastError:=True)> _
    Public Shared Function CreateCompatibleDC(ByVal hDC As IntPtr) As IntPtr
    End Function
    <DllImport("gdi32.dll", ExactSpelling:=True)> _
    Public Shared Function SelectObject(ByVal hDC As IntPtr, ByVal hObject As IntPtr) As IntPtr
    End Function
    <DllImport("gdi32.dll", ExactSpelling:=True, SetLastError:=True)> _
    Public Shared Function DeleteObject(ByVal hObject As IntPtr) As Boolean
    End Function
    <DllImport("gdi32.dll", ExactSpelling:=True, SetLastError:=True)> _
    Public Shared Function DeleteDC(ByVal hdc As IntPtr) As Boolean
    End Function
    <DllImport("gdi32.dll")> _
    Public Shared Function BitBlt(ByVal hdc As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As UInteger) As Boolean
    End Function

    <DllImport("winmm.dll")> _
    Public Shared Function timeBeginPeriod(ByVal uPeriod As Integer) As Integer
    End Function
    <DllImport("winmm.dll")> _
    Public Shared Function timeEndPeriod(ByVal uPeriod As Integer) As Integer
    End Function

    'Layered Window code

    Public Const WS_EX_LAYERED As Int32 = &H80000
    Public Const HTCAPTION As Int32 = &H2
    Public Const WM_NCHITTEST As Int32 = &H84
    Public Const ULW_ALPHA As Int32 = &H2
    Public Const AC_SRC_OVER As Byte = &H0
    Public Const AC_SRC_ALPHA As Byte = &H1

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure _POINT
        Public x, y As Int32
        Public Sub New(x As Int32, y As Int32)
            Me.x = x : Me.y = y
        End Sub
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure _SIZE
        Public cx, cy As Int32
        Public Sub New(cx As Int32, cy As Int32)
            Me.cx = cx : Me.cy = cy
        End Sub
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure _ARGB
        Public B, G, R, A As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure _BLENDFUNCTION
        Public BlendOp, BlendFlags, SourceConstantAlpha, AlphaFormat As Byte
    End Structure

    <DllImport("user32.dll")> _
    Public Shared Function UpdateLayeredWindow(hwnd As IntPtr, _
                                               hdcDest As IntPtr, _
                                               ByRef pptDst As _POINT, _
                                               ByRef pSize As _SIZE, _
                                               hdcSrc As IntPtr, _
                                               ByRef pprSrc As _POINT, _
                                               crKey As Int32, _
                                               ByRef pBlend As _BLENDFUNCTION, _
                                               dwFlags As Int32) As Boolean
    End Function

    ' Let this exe icon as its form's icon

    Declare Function SHGetFileInfo Lib "shell32.dll" (ByVal pszPath As String, _
  ByVal dwFileAttributes As Integer, _
  ByRef psfi As SHFILEINFO, _
  ByVal cbFileInfo As Integer, _
  ByVal uFlags As SHGFI) As IntPtr

    Structure SHFILEINFO
        Public hIcon As IntPtr
        Public iIcon As Integer
        Public dwAttributes As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> _
        Public szTypeName As String
    End Structure

    <Flags()> _
    Enum SHGFI
        ICON = &H100
        DISPLAYNAME = &H200
        TYPENAME = &H400
        ATTRIBUTES = &H800
        ICONLOCATION = &H1000
        EXETYPE = &H2000
        SYSICONINDEX = &H4000
        LINKOVERLAY = &H8000
        SELECTED = &H10000
        ATTR_SPECIFIED = &H20000
        LARGEICON = &H0
        SMALLICON = &H1
        OPENICON = &H2
        SHELLICONSIZE = &H4
        PIDL = &H8
        USEFILEATTRIBUTES = &H10
        ADDOVERLAYS = &H20
        OVERLAYINDEX = &H40
    End Enum

    ''' <summary>Get the display icon of stuff, such as the icon of a folder. If the stuff is icon file, such as exe and dll, will return the icon that used to display.</summary>
    ''' <param name="StuffPath">Stuff can be either file or folder.</param>
    Public Shared Function GetIconOf(ByVal StuffPath As String, ByVal LargeIcon As Boolean) As Icon
        Dim info As New SHFILEINFO
        Dim cbFileInfo As Integer = Marshal.SizeOf(info)
        Dim flags As SHGFI
        If LargeIcon Then
            flags = SHGFI.ICON Or SHGFI.LARGEICON
        Else
            flags = SHGFI.ICON Or SHGFI.SMALLICON
        End If
        SHGetFileInfo(StuffPath, 256, info, cbFileInfo, flags)
        Return Drawing.Icon.FromHandle(info.hIcon)
    End Function

End Class
