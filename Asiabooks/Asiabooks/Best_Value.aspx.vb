Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports Eordering.BusinessLogic.PageControl

Partial Class Best_Value
    Inherits System.Web.UI.Page
    Private _Utility As New clsUtility
    Private bd As New Class_book_detail
    Private uCon As uConnect
    Private country As String = ""
    Private min_price As String = "50"

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "eBooks ::"
        If country = "" Then
            Try
                country = Session("client_nation").ToString()
            Catch ex As Exception
                Dim gen As New gen_nation
                gen.ip = Request.UserHostAddress()
                Session("client_nation") = gen.gen_ip_code
                country = Session("client_nation").ToString()

            End Try
        End If

        If Session("exchange_str") Is Nothing Then
            Try
                Session("exchange_str") = Me.getExchangerate_string()
            Catch ex As Exception

            End Try
        End If

        If Not IsPostBack Then
            Try

                Me.Getdata_feature()

            Catch ex As Exception
                uScript.Alert(Me.Page, Me.GetType, ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Function getExchangerate_string() As String
        Dim res As String = ""
        Dim strsql As String = ""
        strsql = "select tbm_syst_currency.Exchange_Rate,tbm_syst_organizeindent.Org_Indent_Code  from tbm_syst_currency inner join tbm_syst_organizeindent on tbm_syst_currency.Currency_Code = tbm_syst_organizeindent.Currency_Code"
        Dim SqlDb As New SqlDb
        Dim sql_datatable As New DataTable
        sql_datatable = New DataTable
        sql_datatable = SqlDb.GetDataTable(strsql)

        Dim i As Integer
        For i = 0 To sql_datatable.Rows.Count - 1
            res &= " when '" & sql_datatable.Rows(i).Item("Org_Indent_Code").ToString() & "' then " & sql_datatable.Rows(i).Item("Exchange_Rate").ToString()
        Next
        Return res
    End Function

    Private Sub Getdata_feature()
        Dim pcontrol As New PageControl
        Dim strSql As String = ""
        Dim strpage_name As String = ""
        Dim strtype As String = ""
        Dim strgroup As String = ""
        Dim DataList As New DataTable

        Dim item_num As String = "50"
        Dim cat_condition As String = ""
        Try
            DataList = International_bestsellers(item_num, 0, 0, "special_list")
            Datagrid.DataSource = DataList
            Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, DataList.Rows.Count)
            Datagrid.DataBind()
            'DataList = DataGrid.DataSource
            Session("DataList") = DataList

        Catch ex As Exception

        Finally
            DataList = Nothing
            pcontrol = Nothing
            strSql = Nothing
            strpage_name = Nothing
            strtype = Nothing
            strgroup = Nothing

        End Try

    End Sub

    Protected Sub Datagrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Datagrid.PageIndexChanged
        Dim pcontrol As New PageControl
        Dim dt As New DataTable

        Try
            Me.Datagrid.CurrentPageIndex = e.NewPageIndex
            dt = Session("DataList")

            Me.Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, dt.Rows.Count)
            Me.Datagrid.DataSource = dt
            Me.Datagrid.DataBind()
            
        Catch ex As Exception
            uScript.Alert(Me.Page, Me.GetType, ex.Message.ToString)

        Finally
            dt = Nothing
            pcontrol = Nothing
        End Try
    End Sub

    Protected Sub Datagrid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles Datagrid.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim lblisbn As Label = e.Item.FindControl("lblisbn")
            Dim lblList_Price_H As Label = e.Item.FindControl("lblList_Price_H")
            Dim lblList_Price_D As Label = e.Item.FindControl("lblList_Price_D")
            Dim lblYour_Price_D As Label = e.Item.FindControl("lblYour_Price_D")
            Dim lblSave_Price As Label = e.Item.FindControl("lblSave_Price")
            Dim lblImage As Image = e.Item.FindControl("Book_Image")
            Try
                lblImage.ImageUrl = _Utility.GetImagePath_eBook(lblImage.ImageUrl.ToString().Substring(0, 3) & "/" & lblImage.ImageUrl.ToString().Substring(3, 3) & "/" & lblImage.ImageUrl.ToString().Substring(6, 3) & "/" & lblImage.ImageUrl.ToString() + ".jpg")

            Catch ex As Exception

            End Try

            Dim hdd_ebook_format As Label = e.Item.FindControl("hdd_ebook_format")
            Dim format_name() As String = {"GUY", "DRM-PDF", "PDF", "DRM-EPUB", "EPUB", "LIT", "MP3", "PDB", "MOBI"}
            Dim format_img() As String = {"GUY", "<img src=""images/ebook/epdf.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF DRM-PDF"" title=""CLICK HERE TO VIEW DETAIL OF DRM-PDF"">", "<img src=""images/ebook/pdf.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF PDF"" title=""CLICK HERE TO VIEW DETAIL OF PDF"">", "<img src=""images/ebook/eepub.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF DRM-EPUB"" title=""CLICK HERE TO VIEW DETAIL OF DRM-EPUB"">", "<img src=""images/ebook/epub.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF EPUB"" title=""CLICK HERE TO VIEW DETAIL OF EPUB"">", "<img src=""images/ebook/lit.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF LIT"" title=""CLICK HERE TO VIEW DETAIL OF LIT"">", "<img src=""images/ebook/mp3.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF MP3"" title=""CLICK HERE TO VIEW DETAIL OF MP3"">", "<img src=""images/ebook/pdb.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF PDB"" title=""CLICK HERE TO VIEW DETAIL OF PDB"">", "<img src=""images/ebook/mobi.gif"" border=""0"" alt=""CLICK HERE TO VIEW DETAIL OF MOBI"" title=""CLICK HERE TO VIEW DETAIL OF MOBI"">"}
            Dim array() As String = hdd_ebook_format.Text.Split(",")
            Dim i As Integer = 0
            Dim isbn As String = lblisbn.Text
            Dim format_text As String = ""
            For i = 0 To array.Length - 1
                If array(i) <> "" Then
                    format_text &= " <a href=""ebook_detail.aspx?code=" + isbn + "&format=" + array(i) + """>" & format_img(array(i)) & "</a> "
                End If
            Next
            hdd_ebook_format.Text = format_text
            If lblList_Price_D.Text = lblYour_Price_D.Text Then
                lblList_Price_H.Visible = False
                lblList_Price_D.Visible = False
                lblSave_Price.Visible = False
            Else
                If lblSave_Price.Text <> "0" Then
                    lblSave_Price.Text = "(Save " & lblSave_Price.Text & "%)"
                Else
                    lblSave_Price.Visible = False
                End If
                lblList_Price_D.Font.Strikeout = True
            End If

        End If
    End Sub

    Private Function CreateDataTable() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add(New DataColumn("isbn_13", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("book_title", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("author", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Source", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Selling_price", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("list_price", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("your_price", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("your_price_usd", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Synopsis", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("publisher_name", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("eBook_Format", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Book_Type", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Format_Type", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Other_Format", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("save_price", System.Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("image", System.Type.GetType("System.String")))

        Return dt
    End Function

    Function International_bestsellers(ByVal item_num As Integer, ByVal mode As Integer, ByVal day As Integer, ByVal condition As String) As DataTable
        Dim strsql As String = ""
        Dim SqlDb As New SqlDb
        Dim sql_datatable As New DataTable

        Dim datatable As DataTable = New DataTable("datatable")
        Dim datacolumn As New DataColumn
        Dim datarow As DataRow

        datatable = CreateDataTable()

        If (item_num < 1) Then
            item_num = 1
        End If

        strsql &= "select distinct top(" + (item_num).ToString() + ") ebook.isbn_13,ebook.type_code,ebook.rank "
        strsql &= " from ebook_" + condition + " ebook with (nolock)"

        If country = "" Then
            Try
                country = Session("client_nation").ToString()
            Catch ex As Exception
                Dim gen As New gen_nation
                gen.ip = Request.UserHostAddress()
                Session("client_nation") = gen.gen_ip_code
                country = Session("client_nation").ToString()
            End Try
        End If

        If country = "TH" Then
            strsql &= " left join ebook_store on ebook.isbn_13 = ebook_store.isbn_13  "
            strsql &= " and ebook_store.th = 1 and (convert(numeric(13,2) , ebook_store.price_thb)/(1-(convert(numeric(13,2) "
            strsql &= " ,ebook_store.Discount)/100))) > " + min_price + " "
            strsql &= " where ebook.type_code = 'International bestsellers' "
            strsql &= " order by ebook.rank "
        Else
            Dim territory = "ebook_territory_" + country.Substring(0, 1)

            strsql &= " left join " + territory + " "
            strsql &= " on ebook.isbn_13 = " + territory + ".isbn_13 and " + territory + ".country_code = '" + country + "'"
            strsql &= " where ebook.type_code = 'International bestsellers' and case when " + territory + ".country_code is null "
            strsql &= " then 'available' else 'not available' end = 'available' order by ebook.rank"

        End If

        Try
            sql_datatable = New DataTable
            sql_datatable = SqlDb.GetDataTable(strsql)
            Dim isbn_13 As String = ""
            If sql_datatable.Rows.Count > 0 Then
                isbn_13 = "("
                Dim first As Integer = 0
                Dim i As Integer = 0

                For i = 0 To sql_datatable.Rows.Count - 1
                    If first = 0 Then
                        isbn_13 &= sql_datatable.Rows(i).Item("isbn_13").ToString
                        first = 1
                    Else
                        isbn_13 &= "," + sql_datatable.Rows(i).Item("isbn_13").ToString
                    End If
                Next
                isbn_13 &= ")"
                Dim data_format As New DataTable
                data_format = CreateDataTable()
                If isbn_13 <> "()" Then
                    data_format = get_format_ebook_International_bestsellers(isbn_13)
                End If
                Dim rownum As Integer = 0
                For i = 0 To sql_datatable.Rows.Count - 1
                    datarow = datatable.NewRow
                    For Each drj As DataRow In data_format.Rows
                        If sql_datatable.Rows(i).Item("isbn_13") = drj.Item("isbn_13") And CDbl(drj.Item("Selling_price")) > min_price Then
                            datarow("ebook_format") &= drj.Item("format_type").ToString + ","
                            datarow("ISBN_13") = drj.Item("ISBN_13").ToString
                            datarow("Book_Title") = drj.Item("Book_Title").ToString
                            datarow("Synopsis") = drj.Item("synopsis").ToString
                            datarow("Author") = drj.Item("Author").ToString
                            datarow("Publisher_Name") = drj.Item("Publisher_Name").ToString
                            datarow("Source") = drj.Item("Source").ToString
                            datarow("Selling_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("list_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("your_price") = CDbl(drj.Item("selling_price_eCom")).ToString("#,###")
                            datarow("your_price_usd") = "US$ " & bd.callUsd(Convert.ToDouble(drj.Item("selling_price_eCom").ToString)).ToString
                            datarow("save_price") = CDbl(drj.Item("eCom_Discount")).ToString("#,###")
                            datarow("Image") = drj.Item("Image").ToString
                            datarow("Book_Type") = "ebook"
                            datarow("Format_Type") = drj.Item("Format_Type").ToString
                            datarow("Other_Format") = drj.Item("Other_Format").ToString
                        End If
                    Next

                    If Not datarow("Book_Title") = "" Then
                        datatable.Rows.Add(datarow)
                    End If
                Next
            Else
                datatable = sql_datatable
            End If
        Catch ex As Exception
            '    Throw (New Exception("Advance Search Error :" + ex.Message))
        Finally
            sql_datatable = Nothing
            SqlDb = Nothing
            strsql = Nothing
            datacolumn = Nothing
            datarow = Nothing
        End Try

        Return datatable
    End Function

    Function get_format_ebook_International_bestsellers(ByVal isbn_13 As String) As DataTable
        Dim strsql As String
        Dim SqlDb As New SqlDb
        Dim sql_datatable As New DataTable
        Dim exchange_str As String = ""
        Dim territory = "ebook_territory_" + country.Substring(0, 1)

        If Not Session("exchange_str") Is Nothing Then
            exchange_str = Session("exchange_str").ToString()
        End If

        strsql = ""
        strsql &= " select ebook_store.bookid , ebook_store.isbn_13 , ebook_store.discount, "
        strsql &= " ebook_store.book_title ,ebook_store.synopsis ,"
        strsql &= " ebook_special_list.selling_price_eCom,ebook_special_list.eCom_Discount,ebook_special_list.Price_save,ebook_special_list.selling_price as selling_price,"
        strsql &= " case ebook_store.author when '' then '-' else ebook_store.author end as author  ,ebook_store.isbn_10 as image, "
        strsql &= " case ebook_store.publisher_name when '' then '-' else ebook_store.publisher_name end as publisher_name  , "
        'strsql &= " round((convert(numeric(13,2) , ebook_store.price_org)*case ebook_store.supplier_code when 'AsiaBooks' then 1.00 " + exchange_str + " else 32.38 end),0) as selling_price ,  "
        strsql &= " ebook_store.supplier_code as source , cast(ebook_store.on_book as varchar) as other_format  , "
        strsql &= " cast(ebook_store.format_type as varchar) as format_type,ebook_store.datenew "
        strsql &= " from ebook_store with (nolock) left join ebook_special_list "
        strsql &= " on ebook_special_list.isbn_13 = ebook_store.isbn_13"
        strsql &= " where ebook_store.isbn_13 in " + isbn_13
        strsql &= " and ebook_store.status = 'active'"
        strsql &= " order by ebook_special_list.rank"


        Try
            sql_datatable = New DataTable
            sql_datatable = SqlDb.GetDataTable(strsql)
        Catch ex As Exception
            '    Throw (New Exception("Get Format Error :" + ex.Message))
        Finally
            SqlDb = Nothing
            strsql = Nothing
        End Try

        Return sql_datatable
    End Function
End Class
