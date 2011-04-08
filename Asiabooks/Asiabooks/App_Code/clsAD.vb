Imports Microsoft.VisualBasic
Imports System.DirectoryServices
Imports System.Runtime.InteropServices
Imports System.Security.Principal

Public Class clsAD
    Public Function checkAD(ByVal strUser As String, ByVal strPass As String) As Boolean
        Dim rootEntry As DirectoryEntry
        Dim obj As Object
        Dim Search As DirectorySearcher
        Dim resultCollection As SearchResultCollection
        Dim count As Integer = 0

        Try
            rootEntry = New DirectoryEntry("LDAP://ASIABOOKS.COM", strUser, strPass)
            'rootEntry = New DirectoryEntry("LDAP://ASIABOOKS.COM")
            obj = rootEntry.NativeObject
            Search = New DirectorySearcher(rootEntry)

            'เป็นการ Query
            Search.Filter = "(&(SAMAccountName=" & strUser & ")(sAMAccountType=*))"
            resultCollection = Search.FindAll()

            If resultCollection.Count = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            'MsgBox("Can not logon : " & Environment.NewLine & "    " & ex.Message)
            Return False
        End Try
    End Function
End Class
