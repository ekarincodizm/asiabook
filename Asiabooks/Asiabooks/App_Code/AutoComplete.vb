Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<System.Web.Script.Services.ScriptService()> _
Public Class AutoComplete
    Inherits System.Web.Services.WebService

    <WebMethod()> _
        Public Function GetKeywords(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim con As New uConnect
        Dim _strQuery As New StringBuilder
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim i As Integer = 0
        Dim items As String()

        Try
            If count <= 0 Then
                count = 10
            End If
            _strQuery.Append(" select [prefixtext] ")
            _strQuery.Append(" from [tbm_AB_keywordForSearch] ")
            _strQuery.Append(" where [Is_Active] = 'Y' ")
            _strQuery.Append(" and [prefixtext] like '" & prefixText & "%' ")
            _strQuery.Append(" order by [prefixtext] asc ")
            dt = uFunction.getDataTable(con.conn, _strQuery.ToString)

            If (dt.Rows.Count - 1) < count Then
                count = dt.Rows.Count - 1
            End If

            items = New String(count) {}
            For Each dr In dt.Rows
                If i <= count Then
                    items.SetValue(dr("prefixtext").ToString(), i)
                    i += 1
                Else
                    Exit For
                End If
            Next

            Return items
        Catch ex As Exception
            Return Nothing
        End Try

    End Function
End Class
