
Partial Class kung_test2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim strOrder_No As String = ""
        'strOrder_No = Request.Form("RETURNINV")
        TextBox1.Text = Request.Form("txtName").ToString()
        TextBox2.Text = Request.Form("txtPassword").ToString()

    End Sub
End Class
