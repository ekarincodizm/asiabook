Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Eordering.BusinessLogic

Public Class sqlImageFileControl

    Dim SqlDb As New SqlDb
    Public Function Select_ImageFile_control(ByVal fileName As String) As DataTable
        Try
            Dim _strQuery As StringBuilder
            Dim _dt As DataTable

            _strQuery = New StringBuilder
            _dt = New DataTable
            _strQuery.Append("select [fileName],[Path] from [MS_asiabooks.com_ImageFile_control]  ")
            _strQuery.Append("where [DescriptionFileName]='" & fileName.Trim & "' ")
            _dt = SqlDb.GetDataTable(_strQuery.ToString)

            Return _dt
        Catch ex As Exception
            Throw New Exception("Select_ImageFile_control : " & ex.Message)
        End Try
    End Function
    Public Shared Sub myPopCalendar(ByVal Page As Page, ByVal imgCalendar As Object, ByVal Control As String)
        Try
            imgCalendar.Style.Add("CURSOR", "hand")
            imgCalendar.Attributes.Add("onclick", "popUpCalendar(document.forms[0]." & Control & ",document.forms[0]." & Control & ",'dd/mm/yyyy','E');")
        Catch ex As Exception
            Throw New Exception(ex.ToString)
        End Try
    End Sub
End Class
