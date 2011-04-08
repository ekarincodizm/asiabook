Imports System
Imports System.Data
Imports asiabooksmember.member

Partial Class Customer_Tran_Buy_Books
    Inherits System.Web.UI.Page
    Dim member As New Member
    Private uCon As uConnect
    Private uClass As New uClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Transection ::"

        If Not IsPostBack Then
            If Not IsNothing(Request.Cookies("myCookie_user")) Then
                Session("MemberCode") = Request.Cookies("myCookie_user")("MemberCode")
                GetTransactionHeader()
                GetTransactionHeaderDetail()
            Else
                Response.Redirect("My_Account.aspx")
            End If
        End If
    End Sub

    Private Sub GetTransactionHeader()
        Dim dsHeader As New DataSet
        Dim dtHeader As New DataTable

        dsHeader = member.GetTransactionHeader(Session("MemberCode"), "ubKPwB6lD2fihnqJycW/TBHP5S9MYMJJ")
        dtHeader = dsHeader.Tables("profileheader")

        If dtHeader.Rows.Count > 0 Then
            lblMember_Code.Text = dtHeader.Rows(0).Item("username").ToString()
            lblName.Text = dtHeader.Rows(0).Item("NameEN").ToString()
            lblExpire_Date.Text = dtHeader.Rows(0).Item("member_expire").ToString()
            lblTotal_Point.Text = dtHeader.Rows(0).Item("total_point").ToString()
            lblMember_Type.Text = dtHeader.Rows(0).Item("member_type").ToString()
        End If

    End Sub
    Private Sub GetTransactionHeaderDetail()
        Dim dt As New DataTable
        Dim dsDetail As New DataSet
        dsDetail = member.GetTransactionHeader(Session("MemberCode"), "ubKPwB6lD2fihnqJycW/TBHP5S9MYMJJ")

        dt = dsDetail.Tables("transactionheader")

        If dt.Rows.Count > 0 Then
            gvDetail.DataSource = dt
            gvDetail.DataBind()
        End If
    End Sub

    Protected Sub gvDetail_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvDetail.PageIndexChanging
        gvDetail.PageIndex = e.NewPageIndex
        GetTransactionHeaderDetail()
    End Sub

    Protected Sub gvDetail_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDetail.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblDocument_No As Label = e.Row.FindControl("lblDocument_No")
            Dim imgView As ImageButton = e.Row.FindControl("imgView")

            imgView.CommandArgument = lblDocument_No.Text.Trim

        End If
    End Sub
    Protected Sub imgView_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim imgView As ImageButton = sender

        lblDocument_No.Text = imgView.CommandArgument.ToString

        GetTransactionDetail()
        Me.mdlPopUp_Detail.Show()
    End Sub
    Private Sub GetTransactionDetail()
        Dim dt As New DataTable
        Dim dsDetail As New DataSet
        dsDetail = member.GetTransactionDeail(Session("MemberCode"), "ubKPwB6lD2fihnqJycW/TBHP5S9MYMJJ", lblDocument_No.Text)

        dt = dsDetail.Tables("transactiondetail")

        If dt.Rows.Count > 0 Then
            gvDetail_Tran.DataSource = dt
            gvDetail_Tran.DataBind()
        End If
    End Sub

    Protected Sub gvDetail_Tran_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvDetail_Tran.PageIndexChanging
        gvDetail_Tran.PageIndex = e.NewPageIndex
        GetTransactionDetail()
        Me.mdlPopUp_Detail.Show()
    End Sub
End Class
