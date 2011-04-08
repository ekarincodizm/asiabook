
Partial Class Happy_Time_Unique_Lifestye_Gift
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Happy Time : Unique Lifestye Gift ::"
    End Sub
End Class
