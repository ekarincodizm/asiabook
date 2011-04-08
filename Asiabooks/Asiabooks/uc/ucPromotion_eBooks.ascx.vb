Imports System
Imports System.Data

Partial Class uc_ucPromotion_eBooks
    Inherits System.Web.UI.UserControl

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
