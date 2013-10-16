Imports System.Runtime.InteropServices
Imports System.Text

Public Class MCIMedia

    ''' <param name="lpszReturnString">Some command return string here</param>
    ''' <param name="cchReturn">Size of return string</param>
    ''' <param name="hwndCallback">In this case just put 0</param>
    <DllImport("winmm.dll")> _
    Private Shared Function mciSendString(lpszCommand As String, _
                                          lpszReturnString As StringBuilder, _
                                          cchReturn As UInteger, _
                                          hwndCallback As UInteger) As UInteger
    End Function

    ''' <param name="cchBuffer">Buffer size of short path</param>
    <DllImport("kernel32.dll")> _
    Private Shared Function GetShortPathName(lpszLongPath As String, _
                                         lpszShortPath As StringBuilder, _
                                         cchBuffer As Integer) As Integer
    End Function

    Private myAlias As String
    Private myFilePath As String

    Public Sub New(_Alias As String)
        myAlias = _Alias
    End Sub

    Public Function _Open(FilePath As String) As Boolean
        Dim shortsb As New StringBuilder(256)
        GetShortPathName(FilePath, shortsb, 256)
        If mciSendString("open " & shortsb.ToString & " alias " & myAlias, Nothing, 0, 0) = 0 Then
            myFilePath = FilePath
            Return True
        End If
        Return False
    End Function

    Public Function _Close() As Boolean
        If mciSendString("close " & myAlias, Nothing, 0, 0) = 0 Then Return True
        Return False
    End Function

    Public Function _Play() As Boolean
        If mciSendString("play " & myAlias, Nothing, 0, 0) = 0 Then
            Return True
        End If
        Return False
    End Function

    Public Function _PlayFrom0() As Boolean
        If mciSendString("play " & myAlias & " from 0", Nothing, 0, 0) = 0 Then
            Return True
        End If
        Return False
    End Function

    Public Function _Pause() As Boolean
        If mciSendString("pause " & myAlias, Nothing, 0, 0) = 0 Then
            Return True
        End If
        Return False
    End Function

End Class
