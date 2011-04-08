
Partial Class frmError
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.HyperLink1.NavigateUrl = Me.Request.UrlReferrer.AbsoluteUri
        'Me.Label6.Text = "Please Contact Custer Service Tel. 2-0715-9000 email:information@asiabooks.com "

        Dim ex As Exception = Me.Server.GetLastError()

        If Not ex Is Nothing Then
            If ex.InnerException Is Nothing Then
                Me.lblMessage.Text = ex.Message
                Me.lblSource.Text = ex.Source
                Me.lblStactTrace.Text = ex.StackTrace
                Me.lbl_exmessage.Text = ex.Message

            Else
                Me.lblMessage.Text = ex.InnerException.Message
                Me.lblSource.Text = ex.InnerException.Source
                Me.lblStactTrace.Text = ex.InnerException.StackTrace
                Me.lbl_exmessage.Text = ex.InnerException.Message
            End If
        End If

        'Me.Server.ClearError()
        'Me.Session.Remove("error")
        'Session.RemoveAll()
        'Response.Redirect("default.aspx")
        'If Me.IsPostBack = False Then
        '    If Session("logonuser") Is Nothing Then
        '        Me.lbl_exmessage.Text = "Session is nothing "
        '        Response.Redirect("default.aspx")
        '    ElseIf ex.Source = "502" Then
        '        Me.lbl_exmessage.Text = "Server busy"
        '    Else
        '        Me.lbl_exmessage.Text = "Please contact staff"
        '    End If
        'End If

    End Sub

    Protected Sub b_exit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles b_exit.Click
        Session.RemoveAll()
        Me.Response.Redirect("default.aspx")
    End Sub


End Class
