Imports System.IO

Public Class SSPReader

    Private SSPStream As FileStream
    Private Reader As StreamReader
    Private BReader As BinaryReader

    Private HeaderLen As Integer

    Private FilesPos As New List(Of Integer)
    Private FilesSize As New List(Of Integer)

    Private _FileCount As Integer
    Public Property FileCount() As Integer
        Get
            Return _FileCount
        End Get
        Private Set(value As Integer)
            _FileCount = value
        End Set
    End Property

    Public Function ObtainByIndex(Index As Integer) As Byte()
        Try
            ' b(0) store 1 byte, b(1) store 2 byte...
            Dim b(FilesSize(Index) - 1) As Byte
            SSPStream.Seek(FilesPos(Index) + HeaderLen, SeekOrigin.Begin)
            ' write bytes as much as FilesSize(Index) to b(), start by pos 0 of b()
            BReader.Read(b, 0, FilesSize(Index))
            Return b
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub Close()
        SSPStream.Dispose()
    End Sub

    Public Sub New(SSPPath As String)
        SSPStream = New FileStream(SSPPath, FileMode.Open, FileAccess.Read)
        Reader = New StreamReader(SSPStream)
        BReader = New BinaryReader(SSPStream)
        ' retrieve the header length
        SSPStream.Seek(6, SeekOrigin.Begin)
        Dim c As Char = Convert.ToChar(SSPStream.ReadByte)
        If c <> "~" Then Throw New InvaildSSPException
        Do
            c = Convert.ToChar(SSPStream.ReadByte)
            If Integer.TryParse(c, 0) Then
                HeaderLen &= c
            Else
                Exit Do
            End If
        Loop
        SSPStream.Seek(0, SeekOrigin.Begin)
        ' read and check the header
        Dim HeaderC(HeaderLen) As Char
        Reader.Read(HeaderC, 0, HeaderLen)
        Dim Header As New String(HeaderC)
        If Header.StartsWith("MaiSSP") = False Then Throw New InvaildSSPException
        Header = Header.Substring(Header.IndexOf("//") + 2)
        Header = Header.Substring(0, Header.IndexOf("//"))
        ' parse the file count and files position
        Try
            Dim FilesPosInfo() As String = Header.Split("/")
            FileCount = FilesPosInfo.Length
            Dim FilePos As Integer = 0
            For Each FileSize As String In FilesPosInfo
                FilesPos.Add(FilePos)
                FilePos += CInt(FileSize)
                FilesSize.Add(CInt(FileSize))
            Next
        Catch ex As Exception
            Throw New InvaildSSPException
        End Try
    End Sub


End Class


Public Class InvaildSSPException
    Inherits Exception

    Public Overrides ReadOnly Property Message As String
        Get
            Return "Not a vaild SSP file!"
        End Get
    End Property
End Class