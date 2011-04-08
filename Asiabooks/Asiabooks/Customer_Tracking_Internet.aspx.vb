Imports Eordering.BusinessLogic
Imports System.Web.UI
Imports System
Imports System.Data
Imports MycustomDG
Imports Eordering.BusinessLogic.PageControl
Imports Microsoft.VisualBasic

Partial Class Customer_Tracking_Internet
    Inherits System.Web.UI.Page
    Dim dt As DataTable
    Dim sno As Integer = 0
    Dim Co As New Cls_Customer_Order
    Dim Security As New Cls_security

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Customer tacking ::"
        Session("CachePage") = Nothing

        If Not Me.IsPostBack Then

            If Not IsNothing(Request.Cookies("myCookie_user")) Then
                Response.Redirect("Member_Tracking_Order.aspx")
            Else
                Session("CachePage") = Request.Url.AbsoluteUri
                Response.Redirect("My_Account.aspx")
            End If

            Dim dt_nothing As New DataTable
            Me.Datagrid.DataSource = dt_nothing
            Me.Datagrid.DataBind()
        End If
    End Sub
    Private Sub bindData(ByVal ds As DataTable)
        Dim pcontrol As New PageControl
        Dim dt_nothing As New DataTable

        If Me.tbx_order_no.Text <> "" Then
            Co.Order_No = Me.tbx_order_no.Text
            Me.dt = Co.Retreive
            Me.Datagrid.DataSource = dt
            Me.Datagrid.DataBind()
            If dt.Rows.Count > 0 Then
                Me.Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, dt.Rows.Count)

                Datagrid.PagerStyle.Visible = True
                Datagrid.ShowFooter = False
            Else
                Datagrid.PagerStyle.Visible = False
                Datagrid.ShowFooter = True
            End If

        Else
            Me.Datagrid.DataSource = dt_nothing
            Me.Datagrid.DataBind()
            Datagrid.PagerStyle.Visible = False
            Datagrid.ShowFooter = True
            Me.Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, dt_nothing.Rows.Count)

        End If

    End Sub

    Protected Sub b_search_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles b_search.Click
        Me.Datagrid.CurrentPageIndex = 0
        bindData(dt)
    End Sub

    Protected Sub Datagrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        Me.Datagrid.CurrentPageIndex = e.NewPageIndex
        Me.bindData(dt)
    End Sub

    Protected Sub Datagrid_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        If e.CommandName.ToString = "Edit" Then
            Dim lbl_Sales_Channel_Code As Label = e.Item.FindControl("lbl_Sales_Channel_Code")
            If lbl_Sales_Channel_Code.Text = ConfigurationSettings.AppSettings("UserInternet") Then
                Response.Redirect("Customer_Order_Tracking_Internet.aspx?action=Edit&Order_NO=" + e.CommandArgument.ToString())
            End If

        End If

    End Sub

End Class
