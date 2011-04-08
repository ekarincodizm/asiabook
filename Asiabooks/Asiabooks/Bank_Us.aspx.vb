
Partial Class Bank_Us
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "About Us ::"
	Me.lbl.Text = now.date()
    End Sub
End Class
