
Partial Class BooksNot_Found
    Inherits System.Web.UI.Page

    Protected Sub img_submit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_submit.Click
        If Session("keyword") Is Nothing Then
            Response.Redirect("Special_Order_Form.aspx?Keyword=" + "&Meassge=" + lblMeassge.Text.ToString.Replace("&", "$"))
        Else
            Response.Redirect("Special_Order_Form.aspx?Keyword=" + Session("keyword").ToString.Replace("&", "$") + "&Meassge=" + lblMeassge.Text.ToString.Replace("&", "$"))
        End If
    End Sub

    Protected Sub img_search_other_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_search_other.Click

        '/////////promptnow/////////
        If Request.QueryString("p") Is Nothing Then
        Response.Redirect("Homepage.aspx")
        Else
            Response.Redirect("Advanced_Search.aspx")
        End If
        '///////promptnow end///////

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Book search ::"
        If Not IsPostBack Then
            If Request.QueryString("Meassge") Is Nothing Then
            Else
                If Request.QueryString("Meassge").ToString = "Data not found" Then
                    If Session("keyword") Is Nothing Then
                        lblMeassge.Text = "You Searched For: did not match any products. Please try your search again or send the inquiry by email to ecommerce team."
                    Else
                        lblMeassge.Text = "You Searched For: " + Session("keyword").ToString + " did not match any products. Please try your search again or send the inquiry by email to ecommerce team."
                    End If
                ElseIf Request.QueryString("Meassge").ToString = "Stock is not available" Then
                    lblMeassge.Text = "Stock is not available, but it can be a special order upon request. Please try your search again or send the inquiry by email to ecommerce team."
                ElseIf Request.QueryString("Meassge").ToString = "Data not weight" Then
                    lblMeassge.Text = "Sorry. It might something wrong. Please contact our Customer Service at 0-2715-9000 Ext. 8102-3 or ecommerce@asiabooks.com"
                End If

            End If
        End If
    End Sub
End Class
