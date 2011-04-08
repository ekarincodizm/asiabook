
Partial Class Index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Redirect("https://www.asiabooks.com/HomepagePopup.aspx")
        End If
    End Sub
End Class
