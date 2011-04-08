Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports Eordering.BusinessLogic.PageControl

Partial Class Magazine_Detail_Internet
    Inherits System.Web.UI.Page
    Private uCon As uConnect
    Dim bd As New Class_book_detail
    Dim wish_list As New Cls_wish_list
    Private _Utility As New clsUtility

    Public Sub getUrl(ByVal imagePath As String)

        Response.Write(Request.Url.Scheme.ToString & Uri.SchemeDelimiter.ToString & _
                       Request.Url.Authority.ToString & _
                       IIf(Request.ApplicationPath.ToString = "/", "", Request.ApplicationPath.ToString) & imagePath)

    End Sub
    Private Function getUrl1(ByVal imagePath As String) As String
        Dim imag1 As String = ""
        imag1 = Request.Url.Scheme.ToString & Uri.SchemeDelimiter.ToString & _
                       Request.Url.Authority.ToString & _
                       IIf(Request.ApplicationPath.ToString = "/", "", Request.ApplicationPath.ToString) & imagePath
        Return imag1
    End Function
    Protected Sub Alert(ByVal Message As String)
        UI.ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Close", "alert('" + Message + "');", True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Book datail ::"
        Session("CachePage") = Nothing
        If Not IsPostBack Then
            bd.keyword_1 = Me.Request.QueryString("Title_1").ToString.Trim
            Me.txt_qty.Text = 1
            binddata()

        End If
        txt_qty.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + btnadd_to_cart.UniqueID + "').click();return false;}} else {return true}; ")
        Dim strPaht_facebook As String = ""
        Dim strPaht_Twitter As String = ""

        strPaht_facebook = "http://www.facebook.com/share.php?u=https://www.asiabooks.com/browse/BookInfo_New.asp?ProID=" & Me.Request.QueryString("Title_1").ToString.Trim
        strPaht_Twitter = "http://twitter.com/home?status=https://www.asiabooks.com/browse/BookInfo_New.asp?ProID=" & Me.Request.QueryString("Title_1").ToString.Trim

        img_facebook.Attributes.Add("OnClick", "window.open('" & strPaht_facebook & "','',''); return false;")
        imgtweet.Attributes.Add("OnClick", "window.open('" & strPaht_Twitter & "','',''); return false;")


    End Sub
    Private Sub CheckMember()
        If Not IsNothing(Request.Cookies("myCookie_user")) Then
            Panel_Discussion.Visible = True
            btnAdd_Review.Visible = False
        Else
            Panel_Discussion.Visible = False
            btnAdd_Review.Visible = True
        End If
    End Sub
    Protected Sub gvCustomer_Reviews_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCustomer_Reviews.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblReView_Rate As Label = e.Row.FindControl("lblReView_Rate")
            Dim img_start As Image = e.Row.FindControl("img_start")

            Select Case lblReView_Rate.Text
                Case "1"
                    img_start.ImageUrl = "~/images/Template/stars1.gif"
                Case "2"
                    img_start.ImageUrl = "~/images/Template/stars2.gif"
                Case "3"
                    img_start.ImageUrl = "~/images/Template/stars3.gif"
                Case "4"
                    img_start.ImageUrl = "~/images/Template/stars4.gif"
                Case "5"
                    img_start.ImageUrl = "~/images/Template/stars5.gif"
            End Select

        End If
    End Sub

    Protected Sub btnAdd_Review_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd_Review.Click
        Session("CachePage") = Request.Url.AbsoluteUri

        If Not IsNothing(Request.Cookies("myCookie_user")) Then
            Panel_Discussion.Visible = True
        Else
            Response.Redirect("My_Account.aspx")
        End If

    End Sub

    Protected Sub btnNew_Dis_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew_Dis.Click
        Dim strCustomer_Name As String = ""
        Dim strCustomer_Code As String = ""
        Dim strReView_Rate As String = ""
        Dim strsql As String = ""
        Dim strsql_update As String = ""
        Dim strRate_fieldSql As String = ""

        strCustomer_Code = Request.Cookies("myCookie_user")("MemberCode")
        strCustomer_Name = Request.Cookies("myCookie_user")("UserName")
        If txtDetail.Text = "" Then
            Alert("กรุณากรอกข้อมูลด้วยค่ะ")
            Exit Sub
        End If
        If radio1.Checked = False And radio2.Checked = False And radio3.Checked = False And radio4.Checked = False And radio5.Checked = False Then
            Alert("กรุณาเลือก Review Rate ด้วยค่ะ")
            Exit Sub
        End If

        If radio1.Checked = True Then
            strReView_Rate = "1"
            strRate_fieldSql = "No_CusReview1"
        End If
        If radio2.Checked = True Then
            strReView_Rate = "2"
            strRate_fieldSql = "No_CusReview2"
        End If
        If radio3.Checked = True Then
            strReView_Rate = "3"
            strRate_fieldSql = "No_CusReview3"
        End If
        If radio4.Checked = True Then
            strReView_Rate = "4"
            strRate_fieldSql = "No_CusReview4"
        End If
        If radio5.Checked = True Then
            strReView_Rate = "5"
            strRate_fieldSql = "No_CusReview5"
        End If

        Try

            strsql = ""
            strsql &= " insert into tbm_AB_CustomerReview_Discussion (Isbn_13,CusDiscussion,ReView_Rate,Is_Active,Updated,"
            strsql &= " UpdateBy,UpdateByIP,Created,CreateBy,CreateByIP) values ("
            strsql &= " '" + lblisbn.Text + "',"
            strsql &= " '" + txtDetail.Text.ToString.Replace("'", "'+Char(39)+'") + "',"
            strsql &= " '" + strReView_Rate + "','Y',getdate(),"
            strsql &= " '" + strCustomer_Name + "',"
            strsql &= " '" + Request.ServerVariables("REMOTE_ADDR") + "',"
            strsql &= " getdate(),"
            strsql &= " '" + strCustomer_Name + "',"
            strsql &= " '" + Request.ServerVariables("REMOTE_ADDR") + "')"

            uCon = New uConnect
            uFunction.ExecuteDataStringNonTran(uCon.conn, strsql)

            Dim dt_view As New DataTable

            dt_view = uFunction.getDataTable(uCon.conn, "select * from tbm_AB_CustomerReview where isbn_13 = '" + lblisbn.Text + "'")
            If dt_view.Rows.Count > 0 Then
                Dim Customer_View As Integer = 0
                Dim Rate_Count As Integer = 0

                Customer_View = Val(dt_view.Rows(0).Item("No_CustomerDiscussion").ToString) + 1
                Rate_Count = Val(dt_view.Rows(0).Item(strRate_fieldSql).ToString) + 1

                strsql_update = ""
                strsql_update &= " update tbm_AB_CustomerReview set "
                strsql_update &= " No_CustomerDiscussion = '" + Customer_View.ToString + "'"
                strsql_update &= " ,Is_Active = 'Y'"
                strsql_update &= " ," + strRate_fieldSql + " = '" + Rate_Count.ToString + "'"
                strsql_update &= " ,Updated = getdate()"
                strsql_update &= " ,UpdateBy = '" + Request.ServerVariables("REMOTE_ADDR") + "'"
                strsql_update &= " where isbn_13 = '" + lblisbn.Text + "'"
                uFunction.ExecuteDataStringNonTran(uCon.conn, strsql_update)
            End If
            Customer_Reviews()
            Customer_ReviewsDiscussion()
            txtDetail.Text = ""
        Catch ex As Exception
            Throw ex
        Finally
            uCon = Nothing
        End Try

    End Sub

    Private Sub Customer_ReviewsDiscussion()
        Try
            uCon = New uConnect
            Dim dt_review As New DataTable
            Dim strsql As String = ""
            strsql = " select CusDiscussion,CreateBy,convert(varchar,Created,106) as Created,ReView_Rate "
            strsql &= " from tbm_AB_CustomerReview_Discussion where isbn_13 = '" + lblisbn.Text + "' and Is_Active = 'Y'"
            dt_review = uFunction.getDataTable(uCon.conn, strsql)
            If dt_review.Rows.Count > 0 Then
                gvCustomer_Reviews.DataSource = dt_review
                gvCustomer_Reviews.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            uCon = Nothing
        End Try
    End Sub
    Private Sub Customer_Reviews()
        Try
            uCon = New uConnect
            'Dim sb1 As New StringBuilder
            'Dim sb2 As New StringBuilder
            'Dim sb3 As New StringBuilder
            'Dim sb4 As New StringBuilder
            'Dim sb5 As New StringBuilder
            'Dim sum1 As Double = 0
            'Dim sum2 As Double = 0
            'Dim sum3 As Double = 0
            'Dim sum4 As Double = 0
            'Dim sum5 As Double = 0
            'Dim srtHtml1 As String = ""
            'Dim srtHtml2 As String = ""
            'Dim srtHtml3 As String = ""
            'Dim srtHtml4 As String = ""
            'Dim srtHtml5 As String = ""
            Dim dt_view As New DataTable
            Dim strsql As String = ""
            Dim strAverate As String = ""

            strsql = ""
            strsql &= " select * from dbo.tbm_AB_CustomerReview"
            strsql &= " where isbn_13 = '" + lblisbn.Text.Trim + "'"

            dt_view = uFunction.getDataTable(uCon.conn, strsql)
            If dt_view.Rows.Count > 0 Then
                lblview.Text = dt_view.Rows(0).Item("No_CustomerView").ToString
            Else
                lblview.Text = "0"
            End If
            imgCustomer_Average.Visible = False


            'strsql = ""
            'strsql &= " select case No_CustomerDiscussion when '0' then '0' else ((No_CusReview1*1)+(No_CusReview2*2)+(No_CusReview3*3)+"
            'strsql &= " (No_CusReview4*4)+(No_CusReview5*5))/No_CustomerDiscussion end as total,*"
            'strsql &= " from dbo.tbm_AB_CustomerReview"
            'strsql &= " where isbn_13 = '" + lblisbn.Text + "'"

            'dt_view = uFunction.getDataTable(uCon.conn, strsql)
            'If dt_view.Rows.Count > 0 Then
            '    'lblcustomer_review.Text = dt_view.Rows(0).Item("No_CustomerDiscussion").ToString
            '    'lblview.Text = dt_view.Rows(0).Item("No_CustomerView").ToString

            '    'sum1 = (Val(dt_view.Rows(0).Item("No_CusReview1").ToString) / Val(dt_view.Rows(0).Item("No_CustomerDiscussion").ToString)) * 100
            '    'sb1.Append("  <table style='width:").Append(sum1.ToString).Append("%; height: 8px;' border='0' cellpadding='0' cellspacing='0' >")
            '    'sb1.Append("  <tr> <td style='width:").Append(sum1.ToString).Append("%; height: 8px; background-color:Green'></td> </tr> </table>")
            '    'srtHtml1 = sb1.ToString
            '    'spanPost1.InnerHtml = sb1.ToString()
            '    'lblcus_review1.Text = "(" + dt_view.Rows(0).Item("No_CusReview1").ToString + ")"

            '    'sum2 = (Val(dt_view.Rows(0).Item("No_CusReview2").ToString) / Val(dt_view.Rows(0).Item("No_CustomerDiscussion").ToString)) * 100
            '    'sb2.Append("  <table style='width:").Append(sum2.ToString).Append("%; height: 8px;' border='0' cellpadding='0' cellspacing='0' >")
            '    'sb2.Append("  <tr> <td style='width:").Append(sum2.ToString).Append("%; height: 8px; background-color:Green'></td> </tr> </table>")
            '    'srtHtml2 = sb2.ToString
            '    'spanPost2.InnerHtml = sb2.ToString()
            '    'lblcus_review2.Text = "(" + dt_view.Rows(0).Item("No_CusReview2").ToString + ")"

            '    'sum3 = (Val(dt_view.Rows(0).Item("No_CusReview3").ToString) / Val(dt_view.Rows(0).Item("No_CustomerDiscussion").ToString)) * 100
            '    'sb3.Append("  <table style='width:").Append(sum3.ToString).Append("%; height: 8px;' border='0' cellpadding='0' cellspacing='0' >")
            '    'sb3.Append("  <tr> <td style='width:").Append(sum3.ToString).Append("%; height: 8px; background-color:Green'></td> </tr> </table>")
            '    'srtHtml3 = sb3.ToString
            '    'spanPost3.InnerHtml = sb3.ToString()
            '    'lblcus_review3.Text = "(" + dt_view.Rows(0).Item("No_CusReview3").ToString + ")"

            '    'sum4 = (Val(dt_view.Rows(0).Item("No_CusReview4").ToString) / Val(dt_view.Rows(0).Item("No_CustomerDiscussion").ToString)) * 100
            '    'sb4.Append("  <table style='width:").Append(sum4.ToString).Append("%; height: 8px;' border='0' cellpadding='0' cellspacing='0' >")
            '    'sb4.Append("  <tr> <td style='width:").Append(sum4.ToString).Append("%; height: 8px; background-color:Green'></td> </tr> </table>")
            '    'srtHtml4 = sb4.ToString
            '    'spanPost4.InnerHtml = sb4.ToString()
            '    'lblcus_review4.Text = "(" + dt_view.Rows(0).Item("No_CusReview4").ToString + ")"

            '    'sum5 = (Val(dt_view.Rows(0).Item("No_CusReview5").ToString) / Val(dt_view.Rows(0).Item("No_CustomerDiscussion").ToString)) * 100
            '    'sb5.Append("  <table style='width:").Append(sum5.ToString).Append("%; height: 8px;' border='0' cellpadding='0' cellspacing='0' >")
            '    'sb5.Append("  <tr> <td style='width:").Append(sum5.ToString).Append("%; height: 8px; background-color:Green'></td> </tr> </table>")
            '    'srtHtml5 = sb5.ToString
            '    'spanPost5.InnerHtml = sb5.ToString()
            '    'lblcus_review5.Text = "(" + dt_view.Rows(0).Item("No_CusReview5").ToString + ")"

            '    Dim strCustomer_Average As String = ""
            '    strCustomer_Average = dt_view.Rows(0).Item("total").ToString
            '    lblview.Text = dt_view.Rows(0).Item("No_CustomerView").ToString

            '    Select Case strCustomer_Average
            '        Case "1"
            '            imgCustomer_Average.ImageUrl = "~/images/Template/stars1.gif"
            '        Case "2"
            '            imgCustomer_Average.ImageUrl = "~/images/Template/stars2.gif"
            '        Case "3"
            '            imgCustomer_Average.ImageUrl = "~/images/Template/stars3.gif"
            '        Case "4"
            '            imgCustomer_Average.ImageUrl = "~/images/Template/stars4.gif"
            '        Case "5"
            '            imgCustomer_Average.ImageUrl = "~/images/Template/stars5.gif"
            '        Case Else
            '            imgCustomer_Average.ImageUrl = "~/images/Template/stars0.gif"
            '    End Select
            'Else
            '    dt_view.Clear()
            '    strsql = ""
            '    strsql &= " select (CASE WHEN right(isbn_13,2)='00' "
            '    strsql &= " THEN 99*3/99 "
            '    strsql &= " ELSE right(isbn_13,2)*3/right(isbn_13,2) END) AS total,"
            '    strsql &= " (CASE WHEN right(isbn_13,2)='00' "
            '    strsql &= " THEN '99' "
            '    strsql &= " ELSE right(isbn_13,2) END) AS No_CustomerView"
            '    strsql &= " from tbt_jobber_book_search"
            '    strsql &= " where isbn_13 = '" + lblisbn.Text + "'"
            '    dt_view = uFunction.getDataTable(uCon.conn, strsql)
            '    If dt_view.Rows.Count > 0 Then
            '        Dim strCustomer_Average As String = ""
            '        strCustomer_Average = dt_view.Rows(0).Item("total").ToString
            '        lblview.Text = dt_view.Rows(0).Item("No_CustomerView").ToString

            '        Select Case strCustomer_Average
            '            Case "1"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars1.gif"
            '            Case "2"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars2.gif"
            '            Case "3"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars3.gif"
            '            Case "4"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars4.gif"
            '            Case "5"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars5.gif"
            '            Case Else
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars0.gif"
            '        End Select
            '    End If

            'End If


        Catch ex As Exception
            Throw ex
        Finally
            uCon = Nothing
        End Try
    End Sub
    Private Sub Insert_CustomerView()
        Try
            uCon = New uConnect
            Dim Customer_View As Integer = 0
            Dim strsql As String = ""
            Dim dt_view As New DataTable

            dt_view = uFunction.getDataTable(uCon.conn, "select * from tbm_AB_CustomerReview where isbn_13 = '" + lblisbn.Text + "'")

            If dt_view.Rows.Count > 0 Then
                Customer_View = Val(dt_view.Rows(0).Item("No_CustomerView").ToString) + 1
                strsql = ""
                strsql &= " update tbm_AB_CustomerReview set "
                strsql &= " No_CustomerView = '" + Customer_View.ToString + "'"
                strsql &= " ,Is_Active = 'Y'"
                strsql &= " ,Updated = getdate()"
                strsql &= " ,UpdateBy = '" + Request.ServerVariables("REMOTE_ADDR") + "'"
                strsql &= " where isbn_13 = '" + lblisbn.Text + "'"
                uFunction.ExecuteDataStringNonTran(uCon.conn, strsql)
            Else
                strsql = ""
                strsql &= " insert tbm_AB_CustomerReview (Isbn_13,No_CustomerView,No_CustomerDiscussion,No_CusReview1,"
                strsql &= " No_CusReview2,No_CusReview3,No_CusReview4,No_CusReview5,Is_Active,Created,CreatedBy) values ("
                strsql &= " '" + lblisbn.Text + "'"
                strsql &= " ,'1','0','0','0','0','0','0','Y',getdate(),"
                strsql &= " '" + Request.ServerVariables("REMOTE_ADDR") + "')"
                uFunction.ExecuteDataStringNonTran(uCon.conn, strsql)
            End If

        Catch ex As Exception
            Throw ex
        Finally
            uCon = Nothing
        End Try
    End Sub

    Private Sub binddata()
        Dim dt As New DataTable
        Dim price As Double = 0
        Dim price_usd As Double = 0
        Dim imag As String = ""
        bd.sales_channel = "INTERNET"
        dt = bd._dt_book_detail
        If dt.Rows.Count > 0 Then
            Panel5.Visible = False
            Panel4.Visible = True

            lbltitle.Text = dt.Rows(0).Item("book_title").ToString
            lblisbn.Text = dt.Rows(0).Item("ISBN_13").ToString
            lblauthor.Text = dt.Rows(0).Item("Author").ToString
            lblpublisher.Text = dt.Rows(0).Item("publisher_Name").ToString
            lbllanguage.Text = dt.Rows(0).Item("Language").ToString
            lblweight.Text = dt.Rows(0).Item("Weight").ToString
            lblavailable_status.Text = dt.Rows(0).Item("Stock_status").ToString
            lblsynopsis.Text = dt.Rows(0).Item("Synopsis").ToString
            lblsource.Text = dt.Rows(0).Item("source").ToString
            lblBook_Image.Text = dt.Rows(0).Item("image").ToString

            Imag_Book.ImageUrl = _Utility.GetImagePath_Magazine(lblBook_Image.Text.Trim)

            If lblsource.Text = "Asiabooks" Then
                lbllist_price.Text = Convert.ToDouble(dt.Rows(0).Item("selling_price")).ToString("#,###,##0.00")
                lblyour_price.Text = Convert.ToDouble(dt.Rows(0).Item("selling_price_eCom")).ToString("#,###,##0.00")
                lblsave_price.Text = "(Save " + Convert.ToDouble(dt.Rows(0).Item("eCom_Discount")).ToString("#,##0") + "%)"
                price = CDbl(lblyour_price.Text)
                price_usd = bd.callUsd(price) ' convert bath to USD
                lbl_price_usd.Text = "US$ " + Convert.ToDouble(price_usd).ToString("#,##0.00")

                If lbllist_price.Text = lblyour_price.Text Then
                    Label4.Visible = False
                    lbllist_price.Visible = False
                    lblsave_price.Visible = False
                    lblyour_price.Visible = True
                    Label8.Visible = True
                Else
                    lbllist_price.Font.Strikeout = True
                End If

            Else
                lblyour_price.Text = Convert.ToDouble(dt.Rows(0).Item("selling_price")).ToString("#,###,##0.00")
                price = CDbl(lblyour_price.Text)
                price_usd = bd.callUsd(price) ' convert bath to USD
                lbl_price_usd.Text = "US$ " + Convert.ToDouble(price_usd).ToString("#,##0.00")
                Label4.Visible = False
                lbllist_price.Visible = False
                lblsave_price.Visible = False

            End If

            Insert_CustomerView()
            Customer_Reviews()
            Customer_ReviewsDiscussion()
            CheckMember()
        Else
            Panel4.Visible = False
            Panel5.Visible = True
            Response.Redirect("BooksNot_Found.aspx?Meassge=Data not found")

        End If
    End Sub

    Private Sub add_to_cart()
        If lblweight.Text = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert(' There are few quantities of the ISBN " + lblisbn.Text + " in stock, so please contact Customer Service or Sales Staffs at 02-7159000 EXT: 8103, 8102 ');", True)
            Exit Sub
        Else
            If lblsource.Text = "Asiabooks" Then
                bd.Status = "AB"
                Dim dt_xx As DataTable

                Dim sqlDB As SqlDb = New SqlDb
                Dim dt_stock As New DataTable
                Dim dt_stockJobber As New DataTable
                Dim SqlStr As String = ""

                SqlStr = SqlStr + " select a.on_hand_qty ,a.on_order_qty from dbo.tbt_jobber_stockindent a,tbm_syst_company b "
                SqlStr = SqlStr + " where a.isbn_13 = '" + lblisbn.Text + "'"
                SqlStr = SqlStr + " and a.on_hand_qty + a.on_order_qty >  b.Minimum_Stock_Jobber "
                dt_stockJobber.Clear()
                dt_stockJobber = sqlDB.GetDataTable(SqlStr)
                If dt_stockJobber.Rows.Count > 0 Then
                    bd.Jobber_Status = "INDENT"
                Else
                    bd.Jobber_Status = "AB"

                    If Session("In_Branch") Is Nothing Then
                        SqlStr = ""
                        SqlStr = SqlStr + " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-" + txt_qty.Text + " as total_stock "
                        SqlStr = SqlStr + "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                        SqlStr = SqlStr + "	where a.isbn_13 = '" + lblisbn.Text + "' and org_ab_code = 'HO-Internet'  "
                        SqlStr = SqlStr + "	and a.qty -" + txt_qty.Text + " >=  b.Minimum_Stock_Internet "
                        dt_stock.Clear()
                        dt_stock = sqlDB.GetDataTable(SqlStr)
                        If dt_stock.Rows.Count > 0 Then
                        Else
                            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('There are a few quantity of the ISBN : " + lblisbn.Text + " in stock, so please contact Customer Service at 02-7159000 \n EXT: 8103, 8102 or Sales Staffs to confirm availability before processing order');", True)
                            Exit Sub
                        End If
                    Else
                        Dim aa As String = ""
                        Dim yy As String = ""
                        Dim qty As String = ""
                        dt_xx = Session("In_Branch")
                        For ixx As Integer = 0 To dt_xx.Rows.Count - 1
                            If dt_xx.Rows(ixx).Item("isbn_13").ToString = lblisbn.Text Then
                                aa = "1"
                                qty = dt_xx.Rows(ixx).Item("Quantity").ToString
                            End If
                        Next
                        If aa = "1" Then
                            SqlStr = ""
                            SqlStr = SqlStr + " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-" + qty + " as total_stock "
                            SqlStr = SqlStr + "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                            SqlStr = SqlStr + "	where a.isbn_13 = '" + lblisbn.Text + "' and org_ab_code = 'HO-Internet'  "
                            SqlStr = SqlStr + "	and (a.qty-b.Minimum_Stock_Internet)-" + qty + " >=  b.Minimum_Stock_Internet "
                            dt_stock.Clear()
                            dt_stock = sqlDB.GetDataTable(SqlStr)
                            If dt_stock.Rows.Count > 0 Then
                            Else
                                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('There are a few quantity of the ISBN : " + lblisbn.Text + " in stock, so please contact Customer Service at 02-7159000 \n EXT: 8103, 8102 or Sales Staffs to confirm availability before processing order');", True)
                                Exit Sub
                            End If
                        Else
                            SqlStr = ""
                            SqlStr = SqlStr + " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-" + txt_qty.Text + " as total_stock "
                            SqlStr = SqlStr + "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                            SqlStr = SqlStr + "	where a.isbn_13 = '" + lblisbn.Text + "' and org_ab_code = 'HO-Internet'  "
                            SqlStr = SqlStr + "	and (a.qty-b.Minimum_Stock_Internet)-" + txt_qty.Text + " >=  b.Minimum_Stock_Internet "
                            dt_stock.Clear()
                            dt_stock = sqlDB.GetDataTable(SqlStr)
                            If dt_stock.Rows.Count > 0 Then
                            Else
                                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('There are a few quantity of the ISBN : " + lblisbn.Text + " in stock, so please contact Customer Service at 02-7159000 \n EXT: 8103, 8102 or Sales Staffs to confirm availability before processing order');", True)
                                Exit Sub
                            End If
                        End If
                    End If

                End If

                SqlStr = ""
                SqlStr = SqlStr + " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-" + txt_qty.Text + " as total_stock "
                SqlStr = SqlStr + "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                SqlStr = SqlStr + "	where a.isbn_13 = '" + lblisbn.Text + "' and org_ab_code = 'HO-Internet'  "
                'and (a.qty-b.Minimum_Stock_Internet)-" + txt_qty.Text + " >=  b.Minimum_Stock_Internet "

                dt_stock.Clear()
                dt_stock = sqlDB.GetDataTable(SqlStr)
                If dt_stock.Rows.Count > 0 Then
                    If Session("In_Branch") Is Nothing Then
                        bd.Jobber_Status = "AB"
                        bd.Status = "AB"
                    Else
                        Dim aa As String = ""
                        Dim yy As String = ""
                        dt_xx = Session("In_Branch")
                        For ixx As Integer = 0 To dt_xx.Rows.Count - 1
                            If dt_xx.Rows(ixx).Item("isbn_13").ToString = lblisbn.Text And dt_xx.Rows(ixx).Item("Quantity").ToString = dt_stock.Rows(0).Item("qty").ToString Then
                                aa = "1"
                            End If
                        Next
                        If aa = "1" Then
                            bd.Status = "SPECIAL"

                        Else
                            bd.Jobber_Status = "AB"
                            bd.Status = "AB"
                        End If
                    End If

                End If

            Else
                bd.Jobber_Status = "AB"
                bd.Status = "INDENT"
            End If


            If Session("sales_channel") Is Nothing Then
                'bd.sales_channel = "ab"
                'Me.Response.Redirect("default.aspx")
                bd.sales_channel = System.Configuration.ConfigurationManager.AppSettings("UserInternet")
            Else
                bd.sales_channel = Session("sales_channel").ToString
            End If

            bd.keyword_1 = Me.Request.QueryString("Title_1").ToString.Trim

            If Not (IsNumeric(txt_qty.Text) And txt_qty.Text > 0) Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Quantity is not Valid');", True)
                Exit Sub
            Else
                bd.keyword_Qty = CInt(txt_qty.Text)
            End If
            'bd.Status = "1"
            bd.keyword_Branch = "HO-Internet"
            If Session("In_Branch") Is Nothing Then
                ' No such value in session state, take appropriate action.
                bd.dt_Old_book_In_Branch = New DataTable
            Else
                bd.dt_Old_book_In_Branch = Session("In_Branch")
            End If

            If Session("Other_Branch") Is Nothing Then
                ' No such value in session state, take appropriate action.
                bd.dt_Old_book_Other_Branch = New DataTable
            Else
                bd.dt_Old_book_Other_Branch = Session("Other_Branch")
            End If

            If Session("jobber") Is Nothing Then
                ' No such value in session state, take appropriate action.
                bd.dt_Old_book_jobber = New DataTable
            Else
                bd.dt_Old_book_jobber = Session("jobber")
            End If

            Dim i As Integer = 0

            bd.Recalcuate()


            Session("In_Branch") = bd.dt_book_In_Branch
            Session("Other_Branch") = bd.dt_book_Other_Branch
            Session("jobber") = bd.dt_book_jobber
            Session("amount_Branch") = bd.amount_Branch
            Session("amount_Other_Branch") = bd.amount_Other_Branch
            Session("amount_Jobber") = bd.amount_Jobber

            binddata()

            Dim Flag1 As String = ""
            Dim Flag2 As String = ""
            Dim Flag3 As String = ""
            If Not bd.dt_book_In_Branch Is Nothing Then
                If bd.dt_book_In_Branch.Select("ISBN_13='" + bd.keyword_1.Trim + "'").Length = 0 Then
                    Flag1 = "0"
                Else
                    Flag1 = "1"
                End If
            Else
                Flag1 = "0"
            End If
            If Not bd.dt_book_Other_Branch Is Nothing Then
                If bd.dt_book_Other_Branch.Select("ISBN_13='" + bd.keyword_1.Trim + "'").Length = 0 Then
                    Flag2 = "0"
                Else
                    Flag2 = "1"
                End If
            Else
                Flag2 = "0"
            End If
            If Not bd.dt_book_jobber Is Nothing Then
                If bd.dt_book_jobber.Select("ISBN_13='" + bd.keyword_1.Trim + "'").Length = 0 Then
                    Flag3 = "0"
                Else
                    Flag3 = "1"
                End If
            Else
                Flag3 = "0"
            End If

            If Flag1 = "0" And Flag2 = "0" And Flag3 = "0" Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('There are a few quantity of the ISBN : " + bd.keyword_1.Trim + " in stock, so please contact Customer Service at 02-7159000 \n EXT: 8103, 8102 or Sales Staffs to confirm availability before processing order');", True)
                Exit Sub
            Else

                Dim In_branch_qty As Integer = 0
                Dim Other_branch_qty As Integer = 0
                Dim Jobber_qty As Integer = 0
                Dim total_In_branch_qty As Integer = 0
                Dim total_Other_branch_qty As Integer = 0
                Dim total_Jobber_qty As Integer = 0

                If Not bd.dt_book_In_Branch Is Nothing Then
                    For ix As Integer = 0 To bd.dt_book_In_Branch.Rows.Count - 1
                        In_branch_qty = bd.dt_book_In_Branch.Rows(ix).Item("Quantity")
                        total_In_branch_qty = total_In_branch_qty + In_branch_qty
                    Next
                End If
                If Not bd.dt_book_Other_Branch Is Nothing Then
                    For ix As Integer = 0 To bd.dt_book_Other_Branch.Rows.Count - 1
                        In_branch_qty = bd.dt_book_Other_Branch.Rows(ix).Item("Quantity")
                        total_Other_branch_qty = total_Other_branch_qty + In_branch_qty
                    Next
                    'Other_branch_qty = bd.dt_book_Other_Branch.Rows(0).Item("Quantity")
                End If

                If Not bd.dt_book_jobber Is Nothing Then
                    For ix As Integer = 0 To bd.dt_book_jobber.Rows.Count - 1
                        Jobber_qty = bd.dt_book_jobber.Rows(ix).Item("Quantity")
                        total_Jobber_qty = total_Jobber_qty + Jobber_qty
                    Next
                    'Jobber_qty = bd.dt_book_jobber.Rows(0).Item("Quantity")
                End If

                'If bd.input_Quantity > In_branch_qty + Other_branch_qty + Jobber_qty Then
                If bd.input_Quantity > total_In_branch_qty + total_Other_branch_qty + total_Jobber_qty Then

                    If Not bd.dt_book_In_Branch Is Nothing Then
                        If bd.dt_book_In_Branch.Rows.Count <> 0 Then
                            For i = 0 To bd.dt_book_In_Branch.Rows.Count - 1
                                If bd.dt_book_In_Branch.Rows(i).Item("ISBN_13").ToString.Trim = bd.keyword_1.Trim Then
                                    bd.dt_book_In_Branch.Rows(i).Delete()
                                End If
                            Next
                        End If
                    End If
                    If Not bd.dt_book_Other_Branch Is Nothing Then
                        If bd.dt_book_Other_Branch.Rows.Count <> 0 Then
                            For i = 0 To bd.dt_book_Other_Branch.Rows.Count - 1
                                If bd.dt_book_Other_Branch.Rows(i).Item("ISBN_13").ToString.Trim = bd.keyword_1.Trim Then
                                    bd.dt_book_Other_Branch.Rows(i).Delete()
                                End If
                            Next
                        End If
                    End If
                    If Not bd.dt_book_jobber Is Nothing Then
                        If bd.dt_book_jobber.Rows.Count <> 0 Then
                            For i = 0 To bd.dt_book_jobber.Rows.Count - 1
                                If bd.dt_book_jobber.Rows(i).Item("ISBN_13").ToString.Trim = bd.keyword_1.Trim Then
                                    bd.dt_book_jobber.Rows(i).Delete()
                                End If
                            Next
                        End If
                    End If
                    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Quantity of ISBN : " + bd.keyword_1 + " is not enough,Please contact staff');", True)
                    Exit Sub
                End If


                Response.Redirect("shoppingCart_Internet.aspx")

                'If Session("sales_channel").ToString = ConfigurationSettings.AppSettings("UserInternet") Then
                '    Response.Redirect("shoppingCart_Internet_Internet.aspx")
                'ElseIf Session("sales_channel").ToString = ConfigurationSettings.AppSettings("UserDirectSale") Then
                '    Response.Redirect("ShoppingCart_Directsales.aspx")
                'Else
                '    If Session("Cartno") Is Nothing Then
                '        Response.Redirect("shopping_Cart.aspx")
                '    Else
                '        Response.Redirect("ShoppingCart_Employee.aspx?action=Edit")
                '    End If
                'End If
            End If
        End If

    End Sub
    Protected Sub btnadd_to_cart_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnadd_to_cart.Click
        add_to_cart()
    End Sub

    Protected Sub imgwish_list_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgwish_list.Click
        System.Threading.Thread.Sleep(1000)
        Dim alert As String = ""
        Dim datatable As DataTable = New DataTable("datatable")
        Dim datacolumn As DataColumn
        Dim datarow As DataRow

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "ISBN_13"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "ISBN_13"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Book_Title"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Book_Title"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Author"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Author"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Source"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Source"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Selling_Price"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Selling_Price"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Image"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Image"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Item_Dis_Group"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Item_Dis_Group"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Status"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Status"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        datacolumn = New DataColumn()
        datacolumn.DataType = System.Type.GetType("System.String")
        datacolumn.ColumnName = "Synopsis"
        datacolumn.AutoIncrement = False
        datacolumn.Caption = "Synopsis"
        datacolumn.ReadOnly = False
        datacolumn.Unique = False
        datatable.Columns.Add(datacolumn)

        check_stock_book()

        If Session("book_wish_lish") Is Nothing Then
            datarow = datatable.NewRow
            datarow("Image") = lblBook_Image.Text.Trim
            datarow("ISBN_13") = lblisbn.Text.Trim
            datarow("Book_Title") = lbltitle.Text.Trim
            datarow("Author") = lblauthor.Text.Trim
            datarow("Source") = lblsource.Text.Trim
            datarow("Selling_Price") = lblyour_price.Text.Trim
            datarow("Status") = lblavailable_status.Text.Trim
            datarow("Item_Dis_Group") = ""
            Dim synopsis As String = lblsynopsis.Text.Trim
            If synopsis = "-" Then
                datarow("Synopsis") = ""
            Else
                datarow("Synopsis") = synopsis
            End If
            datatable.Rows.Add(datarow)
            Session("book_wish_lish") = datatable
        Else
            datatable = Session("book_wish_lish")
            Dim isbn As String = lblisbn.Text.Trim
            For Each a As DataRow In datatable.Rows
                If a.Item("ISBN_13").ToString = isbn Then
                    alert = "alert"
                End If
            Next
            If alert = "" Then
                datarow = datatable.NewRow
                datarow("Image") = lblBook_Image.Text.Trim
                datarow("ISBN_13") = lblisbn.Text.Trim
                datarow("Book_Title") = lbltitle.Text.Trim
                datarow("Author") = lblauthor.Text.Trim
                datarow("Source") = lblsource.Text.Trim
                datarow("Selling_Price") = lblyour_price.Text.Trim
                datarow("Status") = lblavailable_status.Text.Trim
                datarow("Item_Dis_Group") = ""
                Dim synopsis As String = lblsynopsis.Text.Trim
                If synopsis = "-" Then
                    datarow("Synopsis") = ""
                Else
                    datarow("Synopsis") = synopsis
                End If
                datatable.Rows.Add(datarow)
                Session("book_wish_lish") = datatable
            End If
        End If

        If alert = "" Then
            Response.Redirect("Wishlist_internet.aspx")
        Else
            ModalPopupAlert.Show()
        End If
    End Sub

    Private Sub check_stock_book()
        If lblweight.Text = "0" Then
            Response.Redirect("BooksNot_Found.aspx?Meassge=Data not weight")
        Else
            If lblsource.Text = "Asiabooks" Then
                bd.Status = "AB"
                Dim dt_xx As DataTable

                Dim sqlDB As SqlDb = New SqlDb
                Dim dt_stock As New DataTable
                Dim dt_stockJobber As New DataTable
                Dim SqlStr As String = ""

                SqlStr &= " select a.on_hand_qty ,a.on_order_qty from dbo.tbt_jobber_stockindent a,tbm_syst_company b "
                SqlStr &= " where a.isbn_13 = '" + lblisbn.Text.Trim + "'"
                SqlStr &= " and a.on_hand_qty + a.on_order_qty >  b.Minimum_Stock_Jobber "
                dt_stockJobber.Clear()
                dt_stockJobber = sqlDB.GetDataTable(SqlStr)
                If dt_stockJobber.Rows.Count > 0 Then
                    bd.Jobber_Status = "INDENT"
                Else
                    bd.Jobber_Status = "AB"

                    If Session("In_Branch") Is Nothing Then
                        SqlStr = ""
                        SqlStr &= " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-" + txt_qty.Text + " as total_stock "
                        SqlStr &= "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                        SqlStr &= "	where a.isbn_13 = '" + lblisbn.Text.Trim + "' and org_ab_code = 'HO-Internet'  "
                        SqlStr &= "	and a.qty -" + txt_qty.Text + " >=  b.Minimum_Stock_Internet "
                        dt_stock.Clear()
                        dt_stock = sqlDB.GetDataTable(SqlStr)
                        If dt_stock.Rows.Count > 0 Then
                        Else
                            Response.Redirect("BooksNot_Found.aspx?Meassge=Stock is not available")
                        End If
                    Else
                        Dim aa As String = ""
                        Dim yy As String = ""
                        Dim qty As String = ""
                        dt_xx = Session("In_Branch")
                        For ixx As Integer = 0 To dt_xx.Rows.Count - 1
                            If dt_xx.Rows(ixx).Item("isbn_13").ToString = lblisbn.Text.Trim Then
                                aa = "1"
                                qty = dt_xx.Rows(ixx).Item("Quantity").ToString
                            End If
                        Next
                        If aa = "1" Then
                            SqlStr = ""
                            SqlStr &= " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-" + qty + " as total_stock "
                            SqlStr &= "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                            SqlStr &= "	where a.isbn_13 = '" + lblisbn.Text.Trim + "' and org_ab_code = 'HO-Internet'  "
                            SqlStr &= "	and (a.qty-b.Minimum_Stock_Internet)-" + qty + " >=  b.Minimum_Stock_Internet "
                            dt_stock.Clear()
                            dt_stock = sqlDB.GetDataTable(SqlStr)
                            If dt_stock.Rows.Count > 0 Then
                            Else
                                Response.Redirect("BooksNot_Found.aspx?Meassge=Stock is not available")
                            End If
                        Else
                            SqlStr = ""
                            SqlStr &= " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-" + txt_qty.Text + " as total_stock "
                            SqlStr &= "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                            SqlStr &= "	where a.isbn_13 = '" + lblisbn.Text.Trim + "' and org_ab_code = 'HO-Internet'  "
                            SqlStr &= "	and a.qty -" + txt_qty.Text + " >=  b.Minimum_Stock_Internet "
                            dt_stock.Clear()
                            dt_stock = sqlDB.GetDataTable(SqlStr)
                            If dt_stock.Rows.Count > 0 Then
                            Else
                                Response.Redirect("BooksNot_Found.aspx?Meassge=Stock is not available")
                            End If
                        End If
                    End If

                End If

                SqlStr = ""
                SqlStr &= " select a.isbn_13,a.org_ab_code,a.qty,(a.qty-b.Minimum_Stock_Internet)-" + txt_qty.Text + " as total_stock "
                SqlStr &= "	from tbt_jobber_stockab a,dbo.tbm_syst_company b "
                SqlStr &= "	where a.isbn_13 = '" + lblisbn.Text.Trim + "' and org_ab_code = 'HO-Internet'  "

                dt_stock.Clear()
                dt_stock = sqlDB.GetDataTable(SqlStr)
                If dt_stock.Rows.Count > 0 Then
                    If Session("In_Branch") Is Nothing Then
                        bd.Jobber_Status = "AB"
                        bd.Status = "AB"
                    Else
                        Dim aa As String = ""
                        Dim yy As String = ""
                        dt_xx = Session("In_Branch")
                        For ixx As Integer = 0 To dt_xx.Rows.Count - 1
                            If dt_xx.Rows(ixx).Item("isbn_13").ToString = lblisbn.Text.Trim And dt_xx.Rows(ixx).Item("Quantity").ToString = dt_stock.Rows(0).Item("qty").ToString Then
                                aa = "1"
                            End If
                        Next
                        If aa = "1" Then
                            bd.Status = "SPECIAL"

                        Else
                            bd.Jobber_Status = "AB"
                            bd.Status = "AB"
                        End If
                    End If

                End If

            Else
                bd.Jobber_Status = "AB"
                bd.Status = "INDENT"
            End If


            If Session("sales_channel") Is Nothing Then
                bd.sales_channel = System.Configuration.ConfigurationManager.AppSettings("UserInternet")
            Else
                bd.sales_channel = Session("sales_channel").ToString
            End If

            bd.keyword_1 = Me.Request.QueryString("Title_1").ToString.Trim

            If Not (IsNumeric(txt_qty.Text) And txt_qty.Text > 0) Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Quantity is not Valid');", True)
                Exit Sub
            Else
                bd.keyword_Qty = CInt(txt_qty.Text)
            End If
            bd.keyword_Branch = "HO-Internet"
            If Session("In_Branch") Is Nothing Then
                bd.dt_Old_book_In_Branch = New DataTable
            Else
                bd.dt_Old_book_In_Branch = Session("In_Branch")
            End If

            If Session("Other_Branch") Is Nothing Then
                bd.dt_Old_book_Other_Branch = New DataTable
            Else
                bd.dt_Old_book_Other_Branch = Session("Other_Branch")
            End If

            If Session("jobber") Is Nothing Then
                bd.dt_Old_book_jobber = New DataTable
            Else
                bd.dt_Old_book_jobber = Session("jobber")
            End If

            Dim i As Integer = 0

            Dim client_nation As String = ""
            Dim territory As String = ""
            If Session("client_nation") Is Nothing Then
                Dim gen As New gen_nation
                gen.ip = Request.UserHostAddress()
                client_nation = gen.gen_ip_code
            Else
                client_nation = Session("client_nation")
            End If
            '///// check flag for territory table /////
            Dim sp As String = client_nation.Trim.Substring(0, 1)
            territory = "ebook_territory_" + sp
            bd.country = client_nation
            bd.territory = territory
            bd.Recalcuate()

            Dim Flag1 As String = ""
            Dim Flag2 As String = ""
            Dim Flag3 As String = ""
            If Not bd.dt_book_In_Branch Is Nothing Then
                If bd.dt_book_In_Branch.Select("ISBN_13='" + bd.keyword_1.Trim + "'").Length = 0 Then
                    Flag1 = "0"
                Else
                    Flag1 = "1"
                End If
            Else
                Flag1 = "0"
            End If
            If Not bd.dt_book_Other_Branch Is Nothing Then
                If bd.dt_book_Other_Branch.Select("ISBN_13='" + bd.keyword_1.Trim + "'").Length = 0 Then
                    Flag2 = "0"
                Else
                    Flag2 = "1"
                End If
            Else
                Flag2 = "0"
            End If
            If Not bd.dt_book_jobber Is Nothing Then
                If bd.dt_book_jobber.Select("ISBN_13='" + bd.keyword_1.Trim + "'").Length = 0 Then
                    Flag3 = "0"
                Else
                    Flag3 = "1"
                End If
            Else
                Flag3 = "0"
            End If

            If Flag1 = "0" And Flag2 = "0" And Flag3 = "0" Then
                Response.Redirect("BooksNot_Found.aspx?Meassge=Stock is not available")
            Else

                Dim In_branch_qty As Integer = 0
                Dim Other_branch_qty As Integer = 0
                Dim Jobber_qty As Integer = 0
                Dim total_In_branch_qty As Integer = 0
                Dim total_Other_branch_qty As Integer = 0
                Dim total_Jobber_qty As Integer = 0

                If Not bd.dt_book_In_Branch Is Nothing Then
                    For ix As Integer = 0 To bd.dt_book_In_Branch.Rows.Count - 1
                        In_branch_qty = bd.dt_book_In_Branch.Rows(ix).Item("Quantity")
                        total_In_branch_qty = total_In_branch_qty + In_branch_qty
                    Next
                End If
                If Not bd.dt_book_Other_Branch Is Nothing Then
                    For ix As Integer = 0 To bd.dt_book_Other_Branch.Rows.Count - 1
                        In_branch_qty = bd.dt_book_Other_Branch.Rows(ix).Item("Quantity")
                        total_Other_branch_qty = total_Other_branch_qty + In_branch_qty
                    Next
                    'Other_branch_qty = bd.dt_book_Other_Branch.Rows(0).Item("Quantity")
                End If

                If Not bd.dt_book_jobber Is Nothing Then
                    For ix As Integer = 0 To bd.dt_book_jobber.Rows.Count - 1
                        Jobber_qty = bd.dt_book_jobber.Rows(ix).Item("Quantity")
                        total_Jobber_qty = total_Jobber_qty + Jobber_qty
                    Next
                End If

                If bd.input_Quantity > total_In_branch_qty + total_Other_branch_qty + total_Jobber_qty Then

                    If Not bd.dt_book_In_Branch Is Nothing Then
                        If bd.dt_book_In_Branch.Rows.Count <> 0 Then
                            For i = 0 To bd.dt_book_In_Branch.Rows.Count - 1
                                If bd.dt_book_In_Branch.Rows(i).Item("ISBN_13").ToString.Trim = bd.keyword_1.Trim Then
                                    bd.dt_book_In_Branch.Rows(i).Delete()
                                End If
                            Next
                        End If
                    End If
                    If Not bd.dt_book_Other_Branch Is Nothing Then
                        If bd.dt_book_Other_Branch.Rows.Count <> 0 Then
                            For i = 0 To bd.dt_book_Other_Branch.Rows.Count - 1
                                If bd.dt_book_Other_Branch.Rows(i).Item("ISBN_13").ToString.Trim = bd.keyword_1.Trim Then
                                    bd.dt_book_Other_Branch.Rows(i).Delete()
                                End If
                            Next
                        End If
                    End If
                    If Not bd.dt_book_jobber Is Nothing Then
                        If bd.dt_book_jobber.Rows.Count <> 0 Then
                            For i = 0 To bd.dt_book_jobber.Rows.Count - 1
                                If bd.dt_book_jobber.Rows(i).Item("ISBN_13").ToString.Trim = bd.keyword_1.Trim Then
                                    bd.dt_book_jobber.Rows(i).Delete()
                                End If
                            Next
                        End If
                    End If
                    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Alert", "alert('Quantity of ISBN : " + bd.keyword_1 + " is not enough,Please contact staff');", True)
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Protected Sub btn_alertClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_alertClose.Click
        Response.Redirect("Wishlist_internet.aspx")
    End Sub
End Class
