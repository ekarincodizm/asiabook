 
Imports System
Imports System.Data
Imports System.IO
Imports System.Text

Imports ICSharpCode.SharpZipLib.Checksums
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.GZip
 
Public Class clsFileManager
    Private _FileName As String
    Private _Text As String
    Public FileName As String

    Public GobjData As Object
    Sub New()

    End Sub
    Sub New(ByVal FileName As String)
        _FileName = FileName
    End Sub
    Public Function ReadFile(ByVal FileName As String) As Boolean

        'Dim MyAppPath As String = Application.StartupPath
        Dim MyConfigXML As String = ""
        'MyConfigXML = MyAppPath + "\\" & FileName
        Try
            Dim Source As String

            ' Create an instance of StreamReader to read from a file.
            Dim sr As StreamReader = New StreamReader(FileName, Encoding.GetEncoding(874))
            ' Read and display the lines from the file until the end 
            ' of the file is reached.
            Source = sr.ReadToEnd
            _Text = _Text & Source
            sr.Close()
            Return True
        Catch E As Exception
            ' Let the user know what went wrong.
            'Console.WriteLine("The file could not be read:")
            'Console.WriteLine(E.Message)
            ' MessageBox.Show("The souce file could not be read: ")
            Throw New Exception("FileManager:ReadFile:" + E.Message)
            'Throw E
            Return False
        End Try

        Return True
    End Function

    Public Function WriteFile(ByVal FileName As String, ByVal Text As String) As Boolean
        Try
            Dim sw As StreamWriter = New StreamWriter(FileName, True, Encoding.GetEncoding(874))
            ' Add some text to the file.
            sw.Write(Text)
            sw.Close()
            Return True
        Catch E As Exception
            ' Let the user know what went wrong.
            'Console.WriteLine("The file could not be Write:")
            'Console.WriteLine(E.Message)
            'MessageBox.Show("The souce file could not be Write: ")
            'Throw E
            Throw New Exception("FileManager:WriteFile:" + E.Message)
            Return False
        End Try
    End Function

    Public Function MoveFile(ByVal SourceFile As String, ByVal DestFile As String, ByRef Excep As String) As Boolean
        Try
            Dim fileInfo As FileInfo
            fileInfo = New FileInfo(DestFile)
            If ExistsFile(DestFile) Then
                fileInfo.Delete()
            End If
            fileInfo = New FileInfo(SourceFile)
            fileInfo.MoveTo(DestFile)
            'fileInfo.CopyTo(DestFile)
            'fileInfo.Delete()
            Return True
        Catch ex As Exception
            Excep = "FileManager:MoveFile:" + ex.Message
            'Throw New Exception("FileManager:MoveFile:" + ex.Message)
            Return False
        End Try
    End Function
    Public Function CopyFile(ByVal SourceFile As String, ByVal DestFile As String, ByRef Excep As String) As Boolean
        Try
            Dim fileInfo As FileInfo
            fileInfo = New FileInfo(DestFile)
            If ExistsFile(DestFile) Then
                fileInfo.Delete()
            End If
            fileInfo = New FileInfo(SourceFile)
            fileInfo.CopyTo(DestFile)
            'fileInfo.Delete()

            Excep = ""
            Return True
        Catch ex As Exception
            Excep = "FileManager:CopyFile:" + ex.Message
            'Throw New Exception("FileManager:CopyFile:" + ex.Message)
            Return False
        End Try
    End Function

    Public Function ExistsFile(ByVal FileName As String) As Boolean
        Try
            If File.Exists(FileName) Then
                Return True
            Else
                Return False
            End If
        Catch E As Exception
            ' Let the user know what went wrong.
            'Console.WriteLine("The file could not be read:")
            'Console.WriteLine(E.Message)
            'MessageBox.Show("The souce file could not be check Exists: ")
            Throw New Exception("FileManager:ExistsFile:" + E.Message)
            'Throw E
            Return False
        End Try
    End Function

    Public Function GetSize_ExistsFile(ByVal FileName As String) As Integer

        Try
            If File.Exists(FileName) Then
                Dim fileInfo As FileInfo
                fileInfo = New FileInfo(FileName)
                Return CInt(fileInfo.Length / 1024)
                'Dim fileDetail As IO.FileInfo
                'fileDetail = My.Computer.FileSystem.GetFileInfo(FileName)
                'Return fileDetail.Length

            Else
                Return 0
            End If
        Catch E As Exception

            Throw New Exception("FileManager:ExistsFile:" + E.Message)

            Return 0
        End Try
    End Function

    Public Function DeleteFile(ByVal strFileName As String) As Boolean
        Dim fileInfo As FileInfo
        Try
            fileInfo = New FileInfo(strFileName)
            fileInfo.Delete()
            DeleteFile = True
        Catch ex As Exception
            ' Let the user know what went wrong.
            'Console.WriteLine("The file could not be read:")
            'Console.WriteLine(E.Message)
            'MessageBox.Show("The souce file could not be Delete: ")
            Throw New Exception("FileManager:DeleteFile" + ex.Message)
            'Throw E
            DeleteFile = False
        End Try

    End Function


    Public Function CreateFolder(ByVal _rootdir As String, ByVal _dirname As String) As Boolean
        ' For Each dir As String In System.IO.Directory.GetDirectories(_rootdir)
        Try
            If System.IO.Directory.Exists(_rootdir & "\" & _dirname) Then
                Return True
            Else
                System.IO.Directory.CreateDirectory(_rootdir & "\" & _dirname)
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try

        'If (dir.Split("\")(UBound(dir.Split("\"))) <> _dirname) Then
        '    Try
        '        System.IO.Directory.CreateDirectory(_rootdir & "\" & _dirname)
        '        Return True
        '    Catch ex As Exception
        '        Return False
        '    End Try
        'Else
        '    Return True
        'End If
        'Next

    End Function
    Public Function ZipFile(ByVal FileNameZip As String, ByVal PathSource As String, ByVal PahtforZip As String) As Boolean
        Try

            Dim objCrc32 As New Crc32()
            Dim zos As ZipOutputStream
            Dim strmFile As FileStream
            zos = New ZipOutputStream(File.Create(PahtforZip & "\" & ContainZip(FileNameZip)))

            Dim strFile As String = FileNameZip


            For Each f As String In System.IO.Directory.GetFiles(PathSource)
                strmFile = File.OpenRead(f)
                Dim abyBuffer(CInt(strmFile.Length - 1)) As Byte

                strmFile.Read(abyBuffer, 0, abyBuffer.Length)
                'Dim objZipEntry As ZipEntry = New ZipEntry(f) ' ‡Õ“ Path ‡µÁ¡Ê ¢Õß‰ø≈Ïπ—ÈπÊ ∑’Ë®– zip

                Dim objZipEntry As ZipEntry = New ZipEntry(f.Split("\")(UBound(f.Split("\"))))

                objZipEntry.DateTime = DateTime.Now
                objZipEntry.Size = strmFile.Length
                strmFile.Close()
                objCrc32.Reset()
                objCrc32.Update(abyBuffer)
                objZipEntry.Crc = objCrc32.Value
                zos.PutNextEntry(objZipEntry)
                zos.Write(abyBuffer, 0, abyBuffer.Length)
            Next
            zos.Finish()
            zos.Close()
            ZipFile = True
        Catch ex As Exception
            ZipFile = False
        End Try
    End Function
    Public Function DeleteFolder(ByVal _rootdir As String) As Boolean
        ' For Each dir As String In System.IO.Directory.GetDirectories(_rootdir)
        Try
            If System.IO.Directory.Exists(_rootdir) Then
                System.IO.Directory.Delete(_rootdir, True)
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function StartPath(ByVal path As String) As String
        Return CStr(IIf(path.StartsWith("\"), "", "\")) & path
    End Function
    Private Function EndPath(ByVal path As String) As String
        Return CStr(IIf(path.EndsWith("\"), "", "\"))
    End Function

    Private Function ContainZip(ByVal fileZipName As String) As String
        If fileZipName.Contains(".zip") Then
            ContainZip = fileZipName
        Else
            ContainZip = fileZipName & ".zip"
        End If
    End Function
  
    REM FileInfo get File all 
#Region "15/07/51"
    Public Function getFile(ByVal strPath As String) As Object
        Try
            Dim FileDs() As Object
            FileDs = System.IO.Directory.GetFiles(strPath)
            getFile = FileDs
        Catch ex As Exception
            Throw ex
            getFile = False
        End Try
        Return getFile
    End Function
    Public Function getTextFile(ByVal dtTable As DataTable) As String
        Try
            Dim i, j As Integer
            Dim temp As String = Nothing
            For j = 0 To dtTable.Rows.Count - 1
                For i = 0 To dtTable.Columns.Count - 1
                    If temp Is Nothing Then
                        temp = dtTable.Rows(j).Item(i).ToString.Trim
                    Else
                        If i = 0 Then
                            temp += dtTable.Rows(j).Item(i).ToString.Trim
                        Else
                            temp += "|" & dtTable.Rows(j).Item(i).ToString.Trim
                        End If

                    End If
                Next
                temp += vbCrLf
                MsgBox(temp)
            Next
            getTextFile = temp
            Return getTextFile
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Public Function GetDate_LastModified(ByVal FileName As String) As Date
        Try
            If File.Exists(FileName) Then
                Dim fileInfo As FileInfo
                fileInfo = New FileInfo(FileName)
                Return (fileInfo.LastWriteTime)
                'Dim fileDetail As IO.FileInfo
                'fileDetail = My.Computer.FileSystem.GetFileInfo(FileName)
                'Return fileDetail.Length

            Else
                ' Return 0
            End If
        Catch E As Exception

            Throw New Exception("FileManager:ExistsFile:" + E.Message)

            ' Return 0
        End Try
    End Function
    'Public Function getText_Member(ByVal dtTable As System.Data.EnumerableRowCollection, ByVal strPath As String, ByVal ccase As Integer, Optional ByVal check As Boolean = False) As Boolean
    '    Dim fso As StreamWriter
    '    If check Then
    '        fso = New StreamWriter(strPath, False, System.Text.Encoding.ASCII)
    '    Else
    '        fso = New StreamWriter(strPath, False, System.Text.Encoding.ASCII)
    '    End If
    '    Dim temp As String = Nothing
    '    Try
    '        For Each dtP In dtTable
    '            With dtP
    '                Select Case ccase
    '                    Case 1
    '                        temp = .no_ & "|" & .name & "|" & .Search_Name & "|" & .Address & "|" & .Address2 & "|" & _
    '                               .Address3 & "|" & .contact & "|" & .PhoneNo & "|" & .Customer & "|" & .Fax & "|" & .post
    '                        fso.WriteLine(temp)
    '                    Case 2
    '                        temp = .Customer_No_ & "|" & .Code & "|" & .name & "|" & .Address & "|" & .Address2 & "|" & _
    '                               .Address3 & "|" & .contact & "|" & .PhoneNo & "|" & .Fax & "|" & .County
    '                        fso.WriteLine(temp)
    '                    Case 3
    '                        temp = .contact_no_ & "|" & .Business_Relation_Code & "|" & .Link_to_Table & "|" & .no_
    '                        fso.WriteLine(temp)
    '                    Case 4
    '                        temp = .no_ & "|" & .name & "|" & .Address & "|" & .Address2 & "|" & .Address3 & "|" & _
    '                               .county & "|" & .PhoneNo & "|" & .Salesperson_Code & "|" & .BirthDay & "|" & .Search_Name & _
    '                               "|" & .Year_Old & "|" & .expiration_Date
    '                        fso.WriteLine(temp)
    '                    Case 5
    '                        temp = .Card_Number & "|" & .Link_Type & "|" & .Link_No & "|" & .Loyalty_Scheme & "|" & .Loyalty_Tender
    '                        fso.WriteLine(temp)
    '                End Select
    '            End With
    '        Next
    '        fso.Close()
    '        fso = Nothing
    '        Return getText_Member
    '    Catch ex As Exception
    '        Throw ex
    '        Return False
    '    End Try
    'End Function
    Public Function getDirecory(ByVal strPath As String) As Object
        Dim strArr As String() = IO.Directory.GetDirectories(strPath)
        Return strArr
    End Function
#End Region
End Class
