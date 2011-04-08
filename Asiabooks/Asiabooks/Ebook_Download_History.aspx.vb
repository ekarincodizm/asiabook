Imports Eordering.BusinessLogic
Imports System.Web.UI
Imports System
Imports System.Data
Imports MycustomDG
Imports Eordering.BusinessLogic.PageControl
Imports Microsoft.VisualBasic
Imports System.Web.UI.ClientScriptManager1
Imports asiabooksmember.member
Imports System.IO
Imports System.Data.SqlClient

Partial Class Ebook_Download_History
    Inherits System.Web.UI.Page
    Dim Emember As New member
    Dim dt_bs_person As DataTable
    Dim dt_bs_address As DataTable
    Dim dt As New DataTable
    Dim sno As Integer = 0
    Dim Co As New Cls_Customer_Order
    Private uCon As uConnect
    Private uClass As New uClass
    Private MyEBookID As String

    Protected Sub Alert(ByVal Message As String)
        UI.ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Close", "alert('" + Message + "');", True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "My EBook Download History::"
        Dim ds As New DataSet

        MyEBookID = Request.QueryString("MyEBookID")

        If Not Me.IsPostBack Then

            bindData()

        End If
    End Sub
    'Response.Redirect("Customer_Profile_Edit.aspx?action=Edit&MEMBER_CODE=" + e.CommandArgument.ToString())

    Private Sub bindData()
        'Dim startDate As String = uClass.SpritDate(Me.txtStartDate.Text)
        'Dim strendDate As String = uClass.SpritDate(Me.txtEndDate.Text)
        Dim sqlCommand As String

        Dim MemberId As String = ""
        If Not Request.Cookies("myCookie_user") Is Nothing Then
            MemberId = Request.Cookies("myCookie_user")("MemberCode")
        End If

        sqlCommand = "select CONVERT(VARCHAR(10), l.Timestamp, 103) + ' ' + CONVERT(VARCHAR(10), l.Timestamp, 108) as Timestamp, "
        sqlCommand &= "e.isbn_13, e.book_title, t.type, case l.status when '0' then 'Fail' when '1' then 'Success' else 'On Process' end as Status "
        sqlCommand &= "from ebook_download_log l "
        sqlCommand &= "inner join ebook_store e on e.bookid = l.bookid "
        sqlCommand &= "inner join tbt_asbkeo_cus_order c on c.order_no = l.orderno "
        sqlCommand &= "inner join ebook_type t ON t.formatID = e.format_Type "
        sqlCommand &= "where c.Member_Id = '" + MemberId + "' and l.MyEBookID = '" + MyEBookID + "' order by l.Timestamp desc "


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
            'Me.Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, dt_nothing.Rows.Count)
            Me.Label_Result.Text = "Showing 0 of 0 records"
        End If


    End Sub

    'Protected Sub b_search_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles b_search.Click
    '    'Me.Datagrid.CurrentPageIndex = 0
    '    bindData()
    'End Sub

    Protected Sub Datagrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        Me.Datagrid.CurrentPageIndex = e.NewPageIndex
        Me.bindData()
    End Sub

End Class
