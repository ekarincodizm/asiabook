
Partial Class eBooks
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "eBooks ::"
    End Sub
End Class
