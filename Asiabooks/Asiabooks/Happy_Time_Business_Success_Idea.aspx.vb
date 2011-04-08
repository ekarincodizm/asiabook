
Partial Class Happy_Time_Business_Success_Idea
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Happy Time : Business Success Idea ::"
    End Sub
End Class
