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

Partial Class My_Ebook
    Inherits System.Web.UI.Page
    Dim Emember As New member
    Dim dt_bs_person As DataTable
    Dim dt_bs_address As DataTable
    Dim dt As New DataTable
    Dim dt2 As New DataTable
    Dim sno As Integer = 0
    Dim Co As New Cls_Customer_Order
    Private uCon As uConnect
    Private uClass As New uClass

    Protected Sub Alert(ByVal Message As String)
        UI.ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Close", "alert('" + Message + "');", True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "My EBook ::"
        Dim ds As New DataSet
        If Not Me.IsPostBack Then
            Dim strCatCode As String = ""

            'strCatCode = Request.Cookies("myCookie_user")("CatCode")
            'If strCatCode <> "" Then
            '    ucBooks1.cat_name = "Customer_Profile|" + strCatCode
            'Else
            '    ucBooks1.Visible = False
            'End If

            'Dim dt_nothing As New DataTable
            'Me.Datagrid.DataSource = dt_nothing
            'Me.Datagrid.DataBind()

            bindData()
            bindData2()

        End If
    End Sub
    'Response.Redirect("Customer_Profile_Edit.aspx?action=Edit&MEMBER_CODE=" + e.CommandArgument.ToString())

    Private Sub bindData()
        'Dim startDate As String = uClass.SpritDate(Me.txtStartDate.Text)
        'Dim strendDate As String = uClass.SpritDate(Me.txtEndDate.Text)
        Dim sqlCommand As String
        'Dim condition As String = ""

        Dim MemberId As String = ""
        If Not Request.Cookies("myCookie_user") Is Nothing Then
            MemberId = Request.Cookies("myCookie_user")("MemberCode")
        End If

        sqlCommand = "SELECT MyEBookID, e.bookid, e.isbn_13, e.book_title, e.Format_Type, t.Type, e.max_download, Downloaded_Times, Download_URL, l.Order_No, l.Is_Void "
        sqlCommand &= "FROM ebook_mylist l "
        sqlCommand &= "LEFT JOIN ebook_store e ON e.BookID = l.EBookID "
        sqlCommand &= "LEFT JOIN ebook_type t ON t.FormatID = e.Format_Type "
        'sqlCommand &= "WHERE Member_Id = '" + MemberId + "' AND max_download > Downloaded_Times ORDER BY MyEBookID DESC"
        sqlCommand &= "WHERE Member_Id = '" + MemberId + "' And isnull(Is_CC_Unauth, 'N') <> 'Y' ORDER BY MyEBookID DESC"


        Dim pcontrol As New PageControl
        Dim dt_nothing As New DataTable
        dt.Clear()

        uCon = New uConnect
        dt = uFunction.getDataTable(uCon.conn, sqlCommand)

        If dt.Rows.Count > 0 Then
            Me.Datagrid.DataSource = dt
            Me.Datagrid.DataBind()
            DataGrid.PagerStyle.Visible = True
            DataGrid.ShowFooter = False
            Me.Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, dt.Rows.Count)

        Else
            Me.Datagrid.DataSource = dt_nothing
            Me.Datagrid.DataBind()
            DataGrid.PagerStyle.Visible = False
            DataGrid.ShowFooter = True
            'Me.Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, dt_nothing.Rows.Count)
            Me.Label_Result.Text = "Showing 0 of 0 records"
        End If


    End Sub

    Private Sub bindData2()
        'Dim startDate As String = uClass.SpritDate(Me.txtStartDate.Text)
        'Dim strendDate As String = uClass.SpritDate(Me.txtEndDate.Text)
        Dim sqlCommand As String
        'Dim condition As String = ""

        Dim MemberId As String = ""
        If Not Request.Cookies("myCookie_user") Is Nothing Then
            MemberId = Request.Cookies("myCookie_user")("MemberCode")
        End If

        sqlCommand = "SELECT MyEBookID, e.bookid, e.isbn_13, e.book_title, e.Format_Type, t.Type, e.max_download, Downloaded_Times, Download_URL, l.Order_No "
        sqlCommand &= "FROM ebook_mylist l "
        sqlCommand &= "LEFT JOIN ebook_store e ON e.BookID = l.EBookID "
        sqlCommand &= "LEFT JOIN ebook_type t ON t.FormatID = e.Format_Type "
        'sqlCommand &= "WHERE Member_Id = '" + MemberId + "' AND max_download > Downloaded_Times ORDER BY MyEBookID DESC"
        sqlCommand &= "WHERE Member_Id = '" + MemberId + "' And Is_CC_Unauth = 'Y' And Is_Void <> 'Y' ORDER BY MyEBookID DESC"


        Dim pcontrol As New PageControl
        Dim dt_nothing As New DataTable
        dt2.Clear()

        uCon = New uConnect
        dt2 = uFunction.getDataTable(uCon.conn, sqlCommand)

        If dt2.Rows.Count > 0 Then
            Me.lbl_UnAuthEBook.Text = "Unsaleable eBooks (Please contact the system administrator at ecommerce@asiabooks.com or call 0-2715-9000 ext. 8101 and 8104)"
            Me.Datagrid2.DataSource = dt2
            Me.Datagrid2.DataBind()
            Datagrid2.PagerStyle.Visible = True
            Datagrid2.ShowFooter = False
            Me.Label_Result2.Text = pcontrol.ShowingResultSet(Me.Datagrid2.CurrentPageIndex, Me.Datagrid2.PageSize, dt2.Rows.Count)
        Else
            Me.Datagrid2.Visible = False
            Me.Label_Result2.Visible = False
            'Me.Datagrid2.DataSource = dt_nothing
            'Me.Datagrid2.DataBind()
            'Datagrid2.PagerStyle.Visible = False
            'Datagrid2.ShowFooter = True
            ''Me.Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, dt_nothing.Rows.Count)
            'Me.Label_Result2.Text = "Showing 0 of 0 records"
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

    Protected Sub Datagrid2_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Datagrid2.PageIndexChanged
        Me.Datagrid2.CurrentPageIndex = e.NewPageIndex
        Me.bindData2()
    End Sub


    Protected Sub b_Select_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim imgBt As ImageButton = DirectCast(sender, ImageButton)
        Dim dgIt As DataGridItem = DirectCast(imgBt.NamingContainer, DataGridItem)
        Dim idx As Integer = dgIt.ItemIndex

        'Dim b_select As ImageButton = dgIt.FindControl("b_Select")
        'b_select.OnClientClick = "this.style.visibility = 'hidden'"

        Session("DL_MyEBookID") = Me.Datagrid.DataKeys(idx)

        Dim bc As String = Request.Browser.Browser
        If Request.Browser.Browser = "IE" Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", " window.open('My_Ebook2_Popup.aspx','_blank','toolbar=no,location=no,status=no,scrollbars =no,menubar=no,dependent=no,titlebar=no,top=100,left=100,width=500,height=380');", True)
        Else
            Response.Redirect("My_Ebook2.aspx")
        End If


    End Sub

    Protected Sub Datagrid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles Datagrid.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lbl_Max_Download As Label = e.Item.FindControl("lbl_Max_Download")
            Dim lbl_Downloaded_Times As Label = e.Item.FindControl("lbl_Downloaded_Times")
            Dim lbl_Download_URL As Label = e.Item.FindControl("lbl_Download_URL")
            Dim lbl_Is_Void As Label = e.Item.FindControl("lbl_Is_Void")

            Dim max_dl As Integer = 0
            Dim dl_times As Integer = 0


            max_dl = CInt(IIf(lbl_Max_Download.Text = "", "0", lbl_Max_Download.Text))
            dl_times = CInt(IIf(lbl_Downloaded_Times.Text = "", "0", lbl_Downloaded_Times.Text))

            If dl_times >= max_dl Then
                Dim b_Select As ImageButton = e.Item.FindControl("b_Select")
                b_Select.Visible = False
            End If

            If lbl_Is_Void.Text = "Y" Then
                Dim b_Select As ImageButton = e.Item.FindControl("b_Select")
                b_Select.Visible = False

                Dim lbl_Note As Label = e.Item.FindControl("lbl_Note")
                lbl_Note.Text = "- This eBook is void already."
                lbl_Note.Style.Add("color", "green")
                lbl_Note.Visible = True
            ElseIf lbl_Download_URL.Text = "" Then
                Dim b_Select As ImageButton = e.Item.FindControl("b_Select")
                b_Select.Visible = False

                Dim lbl_Note As Label = e.Item.FindControl("lbl_Note")
                lbl_Note.Text = "- This eBook cannot be downloaded, please contact the system administrator at ecommerce@asiabooks.com or call 0-2715-9000 ext. 8101 and 8104."
                lbl_Note.Visible = True
            End If

        End If

    End Sub
End Class
