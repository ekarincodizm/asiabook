
Partial Class testPromotion
    Inherits System.Web.UI.Page
    Dim clsPromotion As New clsGenCode_Promotion

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            clsPromotion.GenCode_Promotion_Cross("1103050009", "1")
        End If
    End Sub
End Class
