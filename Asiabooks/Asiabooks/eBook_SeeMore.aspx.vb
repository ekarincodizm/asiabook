Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports Eordering.BusinessLogic.PageControl

Partial Class eBook_SeeMore
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
                Dim catcode As String = ""
                Try
                    catcode = Me.Request.QueryString("catcode")
                Catch
                    catcode = ""
                End Try

                If catcode.Length = 1 Then
                    Me.Getdata_feature(catcode)
                ElseIf catcode.Substring(0, 1) = "a" Then
                    Me.Getdata_feature(catcode)
                ElseIf catcode.Substring(0, 1) = "l" Then
                    Me.Getdata_feature(catcode)
                Else
                    Me.Getdata(catcode)
                End If

            Catch ex As Exception
                uScript.Alert(Me.Page, Me.GetType, ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub Getdata(ByVal catcode As String)
        Dim pcontrol As New PageControl
        Dim strSql As String = ""
        'Dim strsplit As String()
        Dim strpage_name As String = ""
        Dim strtype As String = ""
        Dim strgroup As String = ""
        Dim DataList As New DataTable

        Dim item_num As String = "500"
        Dim cat_condition As String = ""
        If Not catcode Is "" Then
            cat_condition = " and ebook.catcode = '" + catcode + "' "

        End If


        Try
            DataList = ebook(item_num, 0, 0, cat_condition)
            Datagrid.DataSource = DataList
            Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, DataList.Rows.Count)
            Datagrid.DataBind()
            'DataList = DataGrid.DataSource
            Session("DataList") = DataList
            'Datagridview.DataSource = DataList
        Catch ex As Exception

        Finally
            DataList = Nothing
            pcontrol = Nothing
            strSql = Nothing
            strpage_name = Nothing
            strtype = Nothing
            strgroup = Nothing

        End Try
        'Datagridview.DataBind()
        


    End Sub

    Private Sub Getdata_feature(ByVal catcode As String)
        Dim pcontrol As New PageControl
        Dim strSql As String = ""
        'Dim strsplit As String()
        Dim strpage_name As String = ""
        Dim strtype As String = ""
        Dim strgroup As String = ""
        Dim DataList As New DataTable

        Dim item_num As String = "500"
        Dim cat_condition As String = ""
        If Not catcode Is "" Then
            Try
                If catcode = "1" Then

                    DataList = ebook_feature(item_num, 0, 0, "bestselling")
                    Datagrid.DataSource = DataList
                    Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, DataList.Rows.Count)
                    Datagrid.DataBind()
                    'DataList = DataGrid.DataSource
                    Session("DataList") = DataList
                    'Datagridview.DataSource = DataList
                
                ElseIf catcode = "2" Then
                    DataList = ebook_feature(item_num, 0, 0, "bestselling_nyt")
                    Datagrid.DataSource = DataList
                    Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, DataList.Rows.Count)
                    Datagrid.DataBind()
                    'DataList = DataGrid.DataSource
                    Session("DataList") = DataList
                    'Datagridview.DataSource = DataList
                    
                ElseIf catcode = "3" Then
                    DataList = ebook_feature(item_num, 0, 0, "feature")
                    Datagrid.DataSource = DataList
                    Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, DataList.Rows.Count)
                    Datagrid.DataBind()
                    'DataList = DataGrid.DataSource
                    Session("DataList") = DataList
                    'Datagridview.DataSource = DataList
                    
                ElseIf catcode = "4" Then
                    cat_condition = " and (convert(numeric(13,2) , ebook.price_thb)/(1-(convert(numeric(13,2) ,ebook.Discount)/100))) <= 350.00"

                    DataList = ebook(item_num, 0, 0, cat_condition)
                    Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, DataList.Rows.Count)
                    Datagrid.DataSource = DataList
                    Datagrid.DataBind()
                    'DataList = DataGrid.DataSource
                    Session("DataList") = DataList
                    'Datagridview.DataSource = DataList

                ElseIf catcode = "5" Then
                    DataList = ebook_Thailand_and_Regional("1000", 0, 0, "special_list")
                    Datagrid.DataSource = DataList
                    Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, DataList.Rows.Count)
                    Datagrid.DataBind()
                    'DataList = DataGrid.DataSource
                    Session("DataList") = DataList
                    'Datagridview.DataSource = DataList

                ElseIf catcode = "6" Then
                    DataList = International_bestsellers(item_num, 0, 0, "special_list")
                    Datagrid.DataSource = DataList
                    Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, DataList.Rows.Count)
                    Datagrid.DataBind()
                    'DataList = DataGrid.DataSource
                    Session("DataList") = DataList
                    'Datagridview.DataSource = DataList

                ElseIf catcode.Substring(0, 1) = "a" Then
                    DataList = ebook_award(item_num, 0, 0, catcode)
                    Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, DataList.Rows.Count)
                    Datagrid.DataSource = DataList
                    Datagrid.DataBind()
                    'DataList = DataGrid.DataSource
                    Session("DataList") = DataList
                    'Datagridview.DataSource = DataList
                ElseIf catcode.Substring(0, 1) = "l" Then
                    Dim day As Integer = 0
                    If catcode.Substring(1, 1) = "2" Then
                        day = 14
                    ElseIf catcode.Substring(1, 1) = "3" Then
                        day = 30
                    End If

                    DataList = ebook(item_num, 1, day, "")
                    Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, DataList.Rows.Count)
                    Datagrid.DataSource = DataList
                    Datagrid.DataBind()
                    'DataList = DataGrid.DataSource
                    Session("DataList") = DataList
                    'Datagridview.DataSource = DataList

                Else
                    cat_condition = " and ebook.catcode = '" + catcode + "' "
                    DataList = ebook(item_num, 0, 0, cat_condition)
                    Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, DataList.Rows.Count)
                    Datagrid.DataSource = DataList
                    Datagrid.DataBind()
                    'DataList = DataGrid.DataSource
                    Session("DataList") = DataList
                    'Datagridview.DataSource = DataList

                End If
            Catch ex As Exception

            Finally
                DataList = Nothing
                pcontrol = Nothing
                strSql = Nothing
                strpage_name = Nothing
                strtype = Nothing
                strgroup = Nothing

            End Try

        End If

        
        'Datagrid.DataSource = DataList
        'Datagrid.DataBind()

        'Session("DataList") = DataList
        
        'Datagridview.DataBind()



    End Sub


    Protected Sub Datagrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Datagrid.PageIndexChanged
        Dim pcontrol As New PageControl
        Dim dt As New DataTable

        Try
            Me.Datagrid.CurrentPageIndex = e.NewPageIndex

            If Session("DataList") Is Nothing Then
                Me.Getdata_feature("1")
            Else
                dt = Session("DataList")

                Me.Label_Result.Text = pcontrol.ShowingResultSet(Me.Datagrid.CurrentPageIndex, Me.Datagrid.PageSize, dt.Rows.Count)
                Me.Datagrid.DataSource = dt
                Me.Datagrid.DataBind()
            End If
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

    Function ebook(ByVal item_num As Integer, ByVal mode As Integer, ByVal day As Integer, ByVal condition As String) As DataTable
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

        strsql &= "select distinct top(" + (item_num).ToString() + ") ebook.isbn_13 "
        strsql &= " from ebook_store ebook with (nolock)"

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

        Dim territory = "ebook_territory_" + country.Substring(0, 1)

        If Not country = "TH" Then
            strsql &= " left join " + territory + " "
            strsql &= " on ebook.bookid = " + territory + ".bookid and " + territory + ".country_code = '" + country + "'"
        End If

        strsql &= " where (ebook.status = 'active') "

        If condition.Length > 0 Then
            strsql &= condition
        End If

        If mode = 1 Then
            If day = 14 Then
                strsql &= " and ebook.datenew < DATEADD(day, -14, GETDATE()) and ebook.datenew > DATEADD(day, -30, GETDATE())"
            ElseIf day = 30 Then
                strsql &= " and ebook.datenew < DATEADD(day, -30, GETDATE()) "
            Else
                strsql &= " and ebook.datenew > DATEADD(day, -7, GETDATE()) and ebook.datenew > DATEADD(day, -14, GETDATE())"
            End If
        End If

        If country = "TH" Then
            strsql &= " and ebook.th = 1 and (convert(numeric(13,2) , ebook.price_thb)/(1-(convert(numeric(13,2) ,ebook.Discount)/100))) > " + min_price + " "
        Else
            strsql &= " and (convert(numeric(13,2) , ebook.price_thb)/(1-(convert(numeric(13,2) ,ebook.Discount)/100)))  > " + min_price + " "
            strsql &= "and case when " + territory + ".country_code is null "
            strsql &= " then 'available' else 'not available' end = 'available' "
        End If

        
        strsql &= "ORDER BY ebook.isbn_13 desc"

        Try
            sql_datatable = New DataTable
            'Response.Write(strsql + "<br/>")
            sql_datatable = SqlDb.GetDataTable(strsql)
            Dim isbn_13 As String = ""
            If sql_datatable.Rows.Count > 0 Then
                isbn_13 = "("
                Dim first As Integer = 0
                Dim i As Integer = 0

                For i = 0 To sql_datatable.Rows.Count - 1
                    'sql_datatable.Rows(i).Item("ebook_format") = ""
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
                    data_format = get_format_ebook(isbn_13)
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
                            datarow("your_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("your_price_usd") = "US$ " & bd.callUsd(Convert.ToDouble(drj.Item("Selling_price").ToString)).ToString
                            datarow("save_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("Image") = drj.Item("Image").ToString
                            datarow("Book_Type") = "ebook"
                            'datarow("eBook_Format") = drj.Item("eBook_Format").ToString
                            datarow("Format_Type") = drj.Item("Format_Type").ToString
                            datarow("Other_Format") = drj.Item("Other_Format").ToString
                        End If
                    Next
                    datatable.Rows.Add(datarow)
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


    Private Function getExchangerate_string() As String
        Dim res As String = ""
        Dim strsql As String = ""
        strsql = "select tbm_syst_currency.Exchange_Rate,tbm_syst_organizeindent.Org_Indent_Code  from tbm_syst_currency inner join tbm_syst_organizeindent on tbm_syst_currency.Currency_Code = tbm_syst_organizeindent.Currency_Code"
        Dim SqlDb As New SqlDb
        Dim sql_datatable As New DataTable
        sql_datatable = New DataTable
        sql_datatable = SqlDb.GetDataTable(strsql)

        'when 'Gardners' then " + "50.76" + "
        Dim i As Integer
        For i = 0 To sql_datatable.Rows.Count - 1
            res &= " when '" & sql_datatable.Rows(i).Item("Org_Indent_Code").ToString() & "' then " & sql_datatable.Rows(i).Item("Exchange_Rate").ToString()
        Next
        Return res
    End Function


    Function get_format_ebook(ByVal isbn_13 As String) As DataTable
        'Get detail
        Dim strsql As String
        Dim SqlDb As New SqlDb
        Dim sql_datatable As New DataTable
        Dim exchange_str As String = ""
        Dim territory = "ebook_territory_" + country.Substring(0, 1)

        If Not Session("exchange_str") Is Nothing Then
            exchange_str = Session("exchange_str").ToString()
        End If

        strsql = ""
        strsql &= " select ebook_store.bookid , ebook_store.isbn_13 , ebook_store.discount, ebook_store.book_title ,ebook_store.synopsis"
        strsql &= " , case ebook_store.author when '' then '-' else ebook_store.author end as author,'0' as eCom_Discount "
        strsql &= " , case ebook_store.publisher_name when '' then '-' else ebook_store.publisher_name end as publisher_name "
        strsql &= " , round((convert(numeric(13,2) , ebook_store.price_org)*case ebook_store.supplier_code when 'AsiaBooks' then 1.00 " + exchange_str + " else 32.38 end),0) as selling_price , ebook_store.isbn_10 as image  "
        strsql &= " , ebook_store.supplier_code as source , cast(ebook_store.on_book as varchar) as other_format "
        strsql &= " , cast(ebook_store.format_type as varchar) as format_type,ebook_store.datenew from ebook_store with (nolock) "
        'If country = "TH" Then
        '    strsql &= " where ebook_store.th = 1 "
        'Else
        '    strsql &= " left join " + territory + " on ebook_store.bookid = " + territory + ".bookid and country_code = '" + country + "' and " + territory + ".isbn_13 in " + isbn_13 + " "
        '    strsql &= "  "
        '    strsql &= " where (ebook_store.status = 'active') "
        '    'strsql &= " and convert(numeric(13,2) , ebook_store.price_org) > 0 "
        '    strsql &= "and case when " + territory + ".country_code is null "
        '    strsql &= " then 'available' else 'not available' end = 'available' "
        'End If
        strsql &= "where ebook_store.isbn_13 in " + isbn_13 + " and ebook_store.status = 'active' "

        Try
            sql_datatable = New DataTable
            'Response.Write(strsql + "<br/>")
            sql_datatable = SqlDb.GetDataTable(strsql)
        Catch ex As Exception
            '    Throw (New Exception("Get Format Error :" + ex.Message))
        End Try

        Return sql_datatable
    End Function

    Function ebook_feature(ByVal item_num As Integer, ByVal mode As Integer, ByVal day As Integer, ByVal condition As String) As DataTable
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

        strsql &= "select distinct top(" + (item_num).ToString() + ") ebook.isbn_13,ebook.rank "
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
            strsql &= " inner join ebook_store with (nolock) on ebook.isbn_13 = ebook_store.isbn_13 and ebook_store.th = 1 and (convert(numeric(13,2) , ebook_store.price_thb)/(1-(convert(numeric(13,2) ,ebook_store.Discount)/100))) > " + min_price + " order by ebook.rank"
        Else
            Dim territory = "ebook_territory_" + country.Substring(0, 1)

            strsql &= " left join " + territory + " "
            strsql &= " on ebook.isbn_13 = " + territory + ".isbn_13 and " + territory + ".country_code = '" + country + "'"
            strsql &= " where case when " + territory + ".country_code is null "
            strsql &= " then 'available' else 'not available' end = 'available' order by ebook.rank"

        End If

        Try
            sql_datatable = New DataTable
            'Response.Write(strsql + "<br/>")
            sql_datatable = SqlDb.GetDataTable(strsql)
            Dim isbn_13 As String = ""
            If sql_datatable.Rows.Count > 0 Then
                isbn_13 = "("
                Dim first As Integer = 0
                Dim i As Integer = 0

                For i = 0 To sql_datatable.Rows.Count - 1
                    'sql_datatable.Rows(i).Item("ebook_format") = ""
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
                    data_format = get_format_ebook(isbn_13)
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
                            datarow("your_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("your_price_usd") = "US$ " & bd.callUsd(Convert.ToDouble(drj.Item("Selling_price").ToString)).ToString
                            datarow("save_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("Image") = drj.Item("Image").ToString
                            datarow("Book_Type") = "ebook"
                            'datarow("eBook_Format") = drj.Item("eBook_Format").ToString
                            datarow("Format_Type") = drj.Item("Format_Type").ToString
                            datarow("Other_Format") = drj.Item("Other_Format").ToString
                        End If
                    Next
                    If Not datarow("Book_Title") = "" Then
                        datatable.Rows.Add(datarow)
                        rownum += 1
                        If rownum >= item_num Then
                            Exit For
                        End If
                    End If
                Next
            Else
                datatable = sql_datatable
            End If
        Catch ex As Exception
            'Throw (New Exception("Advance Search Error :" + ex.Message))
        End Try

        Return datatable
    End Function

    Function ebook_Thailand_and_Regional(ByVal item_num As Integer, ByVal mode As Integer, ByVal day As Integer, ByVal condition As String) As DataTable
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

        strsql &= "select distinct top(" + (item_num).ToString() + ") ebook.isbn_13,ebook.type_code "
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
            strsql &= " where ebook.type_code = 'Thailand and Regional' "
            strsql &= " order by ebook.isbn_13 "
        Else
            Dim territory = "ebook_territory_" + country.Substring(0, 1)

            strsql &= " left join " + territory + " "
            strsql &= " on ebook.isbn_13 = " + territory + ".isbn_13 and " + territory + ".country_code = '" + country + "'"
            strsql &= " where ebook.type_code = 'Thailand and Regional' and case when " + territory + ".country_code is null "
            strsql &= " then 'available' else 'not available' end = 'available' order by ebook.isbn_13"

        End If

        Try
            sql_datatable = New DataTable
            'Response.Write(strsql + "<br/>")
            sql_datatable = SqlDb.GetDataTable(strsql)
            Dim isbn_13 As String = ""
            If sql_datatable.Rows.Count > 0 Then
                isbn_13 = "("
                Dim first As Integer = 0
                Dim i As Integer = 0

                For i = 0 To sql_datatable.Rows.Count - 1
                    'sql_datatable.Rows(i).Item("ebook_format") = ""
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
                    data_format = get_format_ebook(isbn_13)
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
                            datarow("your_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("your_price_usd") = "US$ " & bd.callUsd(Convert.ToDouble(drj.Item("Selling_price").ToString)).ToString
                            datarow("save_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("Image") = drj.Item("Image").ToString
                            datarow("Book_Type") = "ebook"
                            'datarow("eBook_Format") = drj.Item("eBook_Format").ToString
                            datarow("Format_Type") = drj.Item("Format_Type").ToString
                            datarow("Other_Format") = drj.Item("Other_Format").ToString
                        End If
                    Next
                    If Not datarow("Book_Title") = "" Then
                        datatable.Rows.Add(datarow)
                        rownum += 1
                        If rownum >= item_num Then
                            Exit For
                        End If
                    End If
                Next
            Else
                datatable = sql_datatable
            End If
        Catch ex As Exception
            'Throw (New Exception("Advance Search Error :" + ex.Message))
        End Try

        Return datatable
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

    Function ebook_award(ByVal item_num As Integer, ByVal mode As Integer, ByVal day As Integer, ByVal condition As String) As DataTable
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

        strsql &= "select distinct top(" + (item_num).ToString() + ") ebook.isbn_13,ebook.award_year "
        strsql &= " from ebook_award ebook with (nolock)"

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

        Dim territory = "ebook_territory_" + country.Substring(0, 1)

        If country = "TH" Then
            strsql &= " inner join ebook_store with (nolock) on ebook.isbn_13 = ebook_store.isbn_13 and ebook_store.th = 1  and (convert(numeric(13,2) , ebook_store.price_thb)/(1-(convert(numeric(13,2) ,ebook_store.Discount)/100))) > " + min_price + " and ebook.award_code = '" + condition + "' order by ebook.award_year desc"
        Else
            strsql &= " left join " + territory + " "
            strsql &= " on ebook.isbn_13 = " + territory + ".isbn_13 and " + territory + ".country_code = '" + country + "'"
            strsql &= "where case when " + territory + ".country_code is null "
            strsql &= " then 'available' else 'not available' end = 'available' and ebook.award_code = '" + condition + "' order by ebook.award_year desc"

        End If

        Try
            sql_datatable = New DataTable
            'Response.Write(strsql + "<br/>")
            sql_datatable = SqlDb.GetDataTable(strsql)
            Dim isbn_13 As String = ""
            If sql_datatable.Rows.Count > 0 Then
                isbn_13 = "("
                Dim first As Integer = 0
                Dim i As Integer = 0

                For i = 0 To sql_datatable.Rows.Count - 1
                    'sql_datatable.Rows(i).Item("ebook_format") = ""
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
                    data_format = get_format_ebook(isbn_13)
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
                            datarow("your_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("your_price_usd") = "US$ " & bd.callUsd(Convert.ToDouble(drj.Item("Selling_price").ToString)).ToString
                            datarow("save_price") = CDbl(drj.Item("Selling_price")).ToString("#,###")
                            datarow("Image") = drj.Item("Image").ToString
                            datarow("Book_Type") = "ebook"
                            'datarow("eBook_Format") = drj.Item("eBook_Format").ToString
                            datarow("Format_Type") = drj.Item("Format_Type").ToString
                            datarow("Other_Format") = drj.Item("Other_Format").ToString
                        End If
                    Next
                    If Not datarow("Book_Title") = "" Then
                        datatable.Rows.Add(datarow)
                        rownum += 1
                        If rownum >= item_num Then
                            Exit For
                        End If
                    End If
                Next
            Else
                datatable = sql_datatable
            End If
        Catch ex As Exception
            'Throw (New Exception("Advance Search Error :" + ex.Message))
        End Try

        Return datatable
    End Function
End Class
