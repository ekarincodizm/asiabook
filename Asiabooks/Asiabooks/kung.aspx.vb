
Partial Class kung
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Label1.Text = Session("client_nation")
        End If
    End Sub
End Class
