
Partial Class Happy_Time_Ultimate_Collection
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Happy Time : Ultimate Collection ::"
    End Sub
End Class
