
Partial Class Happy_Time_Gift_Idea_For_Kids
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Happy Time : Gift Idea For Kids ::"
    End Sub
End Class
