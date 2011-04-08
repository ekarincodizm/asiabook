
Partial Class Sing_Out
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim userCookie As New HttpCookie("myCookie_user")
            userCookie.Expires = Now.Date.AddDays(-10)
            userCookie.Value = ""
            HttpContext.Current.Response.Cookies.Add(userCookie)
            Session.Clear()

            Response.Redirect("Homepage.aspx")

        End If
    End Sub
End Class
