
Partial Class Online_Order
    Inherits System.Web.UI.Page

    Protected Sub lnkHowToOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkHowToOrder.Click
        Response.Redirect("Online_Order.aspx#howtoorder")
    End Sub

    Protected Sub lnkHowtoShip_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkHowtoShip.Click
        Response.Redirect("Online_Order.aspx#howtoship")
    End Sub

    Protected Sub lnkHowtoPay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkHowtoPay.Click
        Response.Redirect("Online_Order.aspx#howtopay")
    End Sub

    Protected Sub lnkHowtoTrack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkHowtoTrack.Click
        Response.Redirect("Online_Order.aspx#howtotrack")
    End Sub

    Protected Sub lnkTop1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkTop1.Click
        Response.Redirect("Online_Order.aspx#top")
    End Sub

    Protected Sub lnkTop2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkTop2.Click
        Response.Redirect("Online_Order.aspx#top")
    End Sub

    Protected Sub lnkTop3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkTop3.Click
        Response.Redirect("Online_Order.aspx#top")
    End Sub

    Protected Sub lnkTop4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkTop4.Click
        Response.Redirect("Online_Order.aspx#top")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Online Order ::"
    End Sub
End Class
