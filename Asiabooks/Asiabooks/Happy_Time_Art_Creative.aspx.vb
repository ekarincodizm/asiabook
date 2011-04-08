
Partial Class Happy_Time_Art_Creative
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Happy Time : Art Creative ::"
    End Sub
End Class
