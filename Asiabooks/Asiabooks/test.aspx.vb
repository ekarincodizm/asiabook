
Partial Class test
    Inherits System.Web.UI.Page
    Public Sub getUrl(ByVal imagePath As String)

        Response.Write(Request.Url.Scheme.ToString & Uri.SchemeDelimiter.ToString & _
                       Request.Url.Authority.ToString & _
                       IIf(Request.ApplicationPath.ToString = "/", "", Request.ApplicationPath.ToString) & imagePath)

    End Sub
    Private Function getUrl1(ByVal imagePath As String) As String
        Dim imag1 As String = ""
        imag1 = Request.Url.Scheme.ToString & Uri.SchemeDelimiter.ToString & _
                       Request.Url.Authority.ToString & _
                       IIf(Request.ApplicationPath.ToString = "/", "", Request.ApplicationPath.ToString) & imagePath
        Return imag1
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        uScript.Alert(Me.Page, Me.GetType, Request.Url.GetLeftPart(UriPartial.Authority))
    End Sub
End Class
