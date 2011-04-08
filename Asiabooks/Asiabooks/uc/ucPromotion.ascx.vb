Imports System
Imports System.Data

Partial Class uc_ucPromotion
    Inherits System.Web.UI.UserControl

    Protected Sub imgBook_Month_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBook_Month.Click
        Response.Redirect("~/Book_SeeMore.aspx?Page_Name=BookOfTheMonth|BookOfTheMonth|")
    End Sub

    Protected Sub imgBargain_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBargain.Click
        Response.Redirect("~/Bargain.aspx")
    End Sub

    Protected Sub Image45_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Image45.Click
        Response.Redirect("~/Shock_Price.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not IsNothing(Request.Cookies("myCookie_user")) Then
                Dim strCatCode As String = ""
                strCatCode = Request.Cookies("myCookie_user")("CatCode")
                If strCatCode <> "" Then
                    Me.ucTop51.Top_Name = "Top5_MemberFavioritesCat"
                Else
                    ucTop51.Visible = False
                End If
            Else
                ucTop51.Visible = False
            End If
        End If
    End Sub
End Class
