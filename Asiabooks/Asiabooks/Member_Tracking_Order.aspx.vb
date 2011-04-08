Imports Eordering.BusinessLogic
Imports System.Web.UI
Imports System
Imports System.Data
Imports MycustomDG
Imports Eordering.BusinessLogic.PageControl
Imports Microsoft.VisualBasic
Imports System.Web.UI.ClientScriptManager1

Partial Class Member_Tracking_Order
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Private uCon As uConnect
    Private uClass As New uClass

    Protected Sub Alert(ByVal Message As String)
        UI.ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Close", "alert('" + Message + "');", True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Customer Order Tracking ::"

        If Not IsPostBack Then

            Dim dt_nothing As New DataTable
            Me.Datagrid.DataSource = dt_nothing
            Me.Datagrid.DataBind()
        End If
    End Sub

    Private Sub bindData()
        Dim startDate As String = uClass.SpritDate(Me.txtStartDate.Text)
        Dim strendDate As String = uClass.SpritDate(Me.txtEndDate.Text)
        Dim sqlCommand As String
        Dim condition As String = ""

        If txtOrder_No.Text <> "" Then
            condition &= " and Order_No='" + txtOrder_No.Text + "'"

        End If

        If txtStartDate.Text <> "" And txtEndDate.Text <> "" Then
            condition &= " and tbt_asbkeo_cus_order.Order_Date between '" + startDate + "' and '" + strendDate + "'"
        Else
            If txtStartDate.Text = "" And txtEndDate.Text <> "" Then
                Alert("กรุณากรอกวันที่เริ่มต้นด้วยค่ะ")
                Exit Sub
            End If
            If txtStartDate.Text <> "" And txtEndDate.Text = "" Then
                Alert("กรุณากรอกวันที่สิ้นสุดด้วยค่ะ")
                Exit Sub
            End If
            If rdio30day.Checked Then
                condition &= " and convert(datetime,tbt_asbkeo_cus_order.Order_Date) >= getdate()-30 "
            End If
            If rdio60day.Checked Then
                condition &= " and convert(datetime,tbt_asbkeo_cus_order.Order_Date) >= getdate()-60 "
            End If
            If rdio90day.Checked Then
                condition &= " and convert(datetime,tbt_asbkeo_cus_order.Order_Date) >= getdate()-90 "
            End If
        End If


        sqlCommand = "SELECT tbt_asbkeo_cus_order.Order_no"
        sqlCommand &= ",convert(varchar(10),tbt_asbkeo_cus_order.Order_Date,103) as Order_Date"
        sqlCommand &= ",tbt_asbkeo_cus_order.Customer_Name+' '+tbt_asbkeo_cus_order.Last_Name as Customer_Name"
        sqlCommand &= ",tbt_asbkeo_cus_order.Sales_Channel_Code,tbm_syst_organizeab.Org_AB_Name"
        sqlCommand &= ",Sales_Channel_Name,tbt_asbkeo_cus_order.Grand_Total,tbt_asbkeo_cus_order.Member_Id"
        sqlCommand &= " FROM tbt_asbkeo_cus_order LEFT JOIN tbm_syst_organizeab"
        sqlCommand &= " ON tbt_asbkeo_cus_order.Address_Org_Ab=tbm_syst_organizeab.Org_AB_code"
        sqlCommand &= " LEFT JOIN (select distinct Sales_Channel_Code,Sales_Channel_Name "
        sqlCommand &= " from tbm_syst_saleschannel)  as tbm_syst_saleschannel"
        sqlCommand &= " ON tbt_asbkeo_cus_order.Sales_Channel_Code=tbm_syst_saleschannel.Sales_Channel_Code where tbt_asbkeo_cus_order.Member_Id = '" + Request.Cookies("myCookie_user")("MemberCode") + "' " + condition
        sqlCommand &= " ORDER BY  tbt_asbkeo_cus_order.order_date DESC ,tbt_asbkeo_cus_order.order_no DESC"

        Dim pcontrol As New PageControl
        Dim dt_nothing As New DataTable
        dt.Clear()

        uCon = New uConnect
        dt = uFunction.getDataTable(uCon.conn, sqlCommand)

        If dt.Rows.Count > 0 Then
            Me.Datagrid.DataSource = dt
            Me.Datagrid.DataBind()
            Datagrid.PagerStyle.Visible = True
            Datagrid.ShowFooter = False
            Me.Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, dt.Rows.Count)

        Else
            Me.Datagrid.DataSource = dt_nothing
            Me.Datagrid.DataBind()
            Datagrid.PagerStyle.Visible = False
            Datagrid.ShowFooter = True
            Me.Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, dt_nothing.Rows.Count)

        End If


    End Sub

    Protected Sub b_search_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles b_search.Click
        bindData()
    End Sub

    Protected Sub Datagrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        Me.Datagrid.CurrentPageIndex = e.NewPageIndex
        Me.bindData()
    End Sub

    Protected Sub Datagrid_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        If e.CommandName.ToString = "Edit" Then
            Dim lbl_Sales_Channel_Code As Label = e.Item.FindControl("lbl_Sales_Channel_Code")
            Response.Redirect("Customer_Order_Tracking_Internet.aspx?action=Edit&Order_NO=" + e.CommandArgument.ToString())

        End If

    End Sub

End Class
