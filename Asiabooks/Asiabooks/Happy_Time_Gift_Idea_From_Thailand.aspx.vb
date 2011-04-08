
Partial Class Happy_Time_Gift_Idea_From_Thailand
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Happy Time : Gift Idea From Thailand ::"
    End Sub
End Class
