Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Public Class Class_book_search
    Public sales_channel As String

    Public header As String
    Public keyword As String
    Public ID As Integer
    Public image As String
    Public Book_Title As String
    Public Author As String
    Public isbn_13 As String
    Public Publisher_name As String
    Public Size As String
    Public Weight As Double
    Public binding_description As String
    Public Page_qty As Integer
    Public Subject_name As String
    Public Stock_status As String
    Public Publication_Date As String
    Public Selling_Price As Double
    Public dt_book_search As DataTable
    Public dt_book_searchTest As DataTable
    Public dt_book_searchTest_Table As DataTable
    Public dt_book_search_check_weight As DataTable

    '/////////promptnow/////////
    Public by As String
    Public by2 As String
    Public advance_search_forcus As String
    Public like_ As String
    Public equal_ As String
    Public unequal_ As String
    Public like_2 As String
    Public equal_2 As String
    Public unequal_2 As String
    Public country As String
    Public territory As String
    '///////promptnow end///////
    Property _territory()
        Get
            Return territory
        End Get
        Set(ByVal value)
            territory = value
        End Set
    End Property

    Property _sales_channel()
        Get
            Return sales_channel
        End Get
        Set(ByVal value)
            sales_channel = value
        End Set
    End Property

    '/////////promptnow/////////
    Property _country()
        Get
            Return country
        End Get
        Set(ByVal value)
            country = value
        End Set
    End Property
    Property _by2()
        Get
            Return by2
        End Get
        Set(ByVal value)
            by2 = value
        End Set
    End Property
    Property _like_()
        Get
            Return like_
        End Get
        Set(ByVal value)
            like_ = value
        End Set
    End Property
    Property _equal_()
        Get
            Return equal_
        End Get
        Set(ByVal value)
            equal_ = value
        End Set
    End Property
    Property _unequal_()
        Get
            Return unequal_
        End Get
        Set(ByVal value)
            unequal_ = value
        End Set
    End Property
    Property _like_2()
        Get
            Return like_
        End Get
        Set(ByVal value)
            like_ = value
        End Set
    End Property
    Property _equal_2()
        Get
            Return equal_
        End Get
        Set(ByVal value)
            equal_ = value
        End Set
    End Property
    Property _unequal_2()
        Get
            Return unequal_
        End Get
        Set(ByVal value)
            unequal_ = value
        End Set
    End Property
    Property _advance_search_forcus()
        Get
            Return advance_search_forcus
        End Get
        Set(ByVal value)
            advance_search_forcus = value
        End Set
    End Property
    Property _by()
        Get
            Return by
        End Get
        Set(ByVal value)
            by = value
        End Set
    End Property
    '///////promptnow end///////

    Property _header()
        Get
            Return header
        End Get
        Set(ByVal value)
            header = value
        End Set
    End Property
    Property _keyword()
        Get
            Return keyword
        End Get
        Set(ByVal value)
            keyword = value
        End Set
    End Property
    Property _ID()
        Get
            Return ID
        End Get
        Set(ByVal value)
            ID = value
        End Set
    End Property
    Property _image()
        Get
            Return image
        End Get
        Set(ByVal value)
            image = value
        End Set
    End Property
    Property _Book_Title()
        Get
            Return Book_Title
        End Get
        Set(ByVal value)
            Book_Title = value
        End Set
    End Property
    Property _Author()
        Get
            Return Author
        End Get
        Set(ByVal value)
            Author = value
        End Set
    End Property
    Property _isbn_13()
        Get
            Return isbn_13
        End Get
        Set(ByVal value)
            isbn_13 = value
        End Set
    End Property
    Property _Publisher_name()
        Get
            Return Publisher_name
        End Get
        Set(ByVal value)
            Publisher_name = value
        End Set
    End Property
    Property _Size()
        Get
            Return Size
        End Get
        Set(ByVal value)
            Size = value
        End Set
    End Property
    Property _Weight()
        Get
            Return Weight
        End Get
        Set(ByVal value)
            Weight = value
        End Set
    End Property
    Property _binding_description()
        Get
            Return binding_description
        End Get
        Set(ByVal value)
            binding_description = value
        End Set
    End Property
    Property _Page_qty()
        Get
            Return Page_qty
        End Get
        Set(ByVal value)
            Page_qty = value
        End Set
    End Property
    Property _Subject_name()
        Get
            Return Subject_name
        End Get
        Set(ByVal value)
            Subject_name = value
        End Set
    End Property
    Property _Stock_status()
        Get
            Return Stock_status
        End Get
        Set(ByVal value)
            Stock_status = value
        End Set
    End Property
    Property _Publication_Date()
        Get
            Return Publication_Date
        End Get
        Set(ByVal value)
            Publication_Date = value
        End Set
    End Property
    Property _Selling_Price()
        Get
            Return Selling_Price
        End Get
        Set(ByVal value)
            Selling_Price = value
        End Set
    End Property

    Function _dt_book_searchTest_Table()
        Dim condition As String = ""
        Dim SqlDb As SqlDb = New SqlDb

        If header <> Nothing Then
            Select Case header
                Case "Title"
                    condition = " where  book_title= '" & keyword.Replace("'", "''") & "'"
                Case "ISBN"
                    condition = " where tmpDu_tbt_jobber_book_search.ISBN_13  = '" & keyword.Replace("'", "") & "'"
                Case "Author"
                    condition = " where Author like '" & keyword.Replace("'", "") & "' "

                Case "Keyword"
                    condition = " where book_title like '" & keyword.Replace("'", "") & "' "
                Case Else
                    condition = ""
            End Select
        End If
        Dim SqlStr As String = ""
        SqlStr &= " select *,case source when 'Asiabooks' then convert(numeric(13,2),tmpDu_tbt_jobber_book_search.selling) else"
        SqlStr &= "  convert(numeric(18,2),(tmpDu_tbt_jobber_book_search.selling*(isnull(tmpDu_tbt_jobber_book_search.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tmpDu_tbt_jobber_book_search.field1,0)))"
        SqlStr &= "  +tmpDu_tbt_jobber_book_search.selling*(isnull(tmpDu_tbt_jobber_book_search.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tmpDu_tbt_jobber_book_search.field1,0)))"
        SqlStr &= " *Mark_UP/100)) end as Selling_price "
        SqlStr &= " from "
        SqlStr &= " ("
        SqlStr &= "	select	tmpDu_tbt_jobber_book_search.image,tmpDu_tbt_jobber_book_search.Book_Title"
        SqlStr &= "		 ,case when (tmpDu_tbt_jobber_book_search.Author='' or tmpDu_tbt_jobber_book_search.Author ='NONE') "
        SqlStr &= "		 then '-' else tmpDu_tbt_jobber_book_search.Author end  as Author"
        SqlStr &= "		 ,tmpDu_tbt_jobber_book_search.ISBN_13"
        SqlStr &= "		 ,case when tmpDu_tbt_jobber_book_search.Publisher_name='' then '-' "
        SqlStr &= "		 else tmpDu_tbt_jobber_book_search.Publisher_name end as Publisher_name,tmpDu_tbt_jobber_book_search.[Size]"
        SqlStr &= "		 ,convert(numeric(13,2),tmpDu_tbt_jobber_book_search.Weight) as Weight"
        SqlStr &= "		 ,tmpDu_tbt_jobber_book_search.binding_description"
        SqlStr &= "		 ,case when convert(varchar(10),tmpDu_tbt_jobber_book_search.Page_qty)='0' THEN '-' "
        SqlStr &= "		 else convert(varchar(10),tmpDu_tbt_jobber_book_search.Page_qty)end as Page_qty"
        SqlStr &= "		 ,case when tmpDu_tbt_jobber_book_search.Subject_Name='' then '-'"
        SqlStr &= "		 else tmpDu_tbt_jobber_book_search.Subject_Name end as Subject_Name"
        SqlStr &= "		 ,case when tmpDu_tbt_jobber_book_search.Stock_status='' then '-'"
        SqlStr &= "		 else tmpDu_tbt_jobber_book_search.Stock_status end as stock_status"
        SqlStr &= "		 ,case when right(tmpDu_tbt_jobber_book_search.Publication_Date,4)='0000' OR source = 'Asiabooks' then '-'"
        SqlStr &= "		 else right(tmpDu_tbt_jobber_book_search.Publication_Date,4)  end as Publication_Date"
        SqlStr &= "		,source,Selling_Price as selling,discount,tmpDu_tbt_jobber_book_search.field1"
        SqlStr &= "	from	tmpDu_tbt_jobber_book_search " + condition
        SqlStr &= "	and tmpDu_tbt_jobber_book_search.field3 ='' "
        SqlStr &= "	and Selling_Price>0"

        SqlStr &= "	) as tmpDu_tbt_jobber_book_search "
        SqlStr &= " left join (select mark_up,From_Pub_Discount,to_Pub_Discount,sales_channel_code "
        SqlStr &= " from tbm_syst_saleschannel)as tbm_syst_saleschannel"
        SqlStr &= " on tmpDu_tbt_jobber_book_search.discount>=tbm_syst_saleschannel.From_Pub_Discount"
        SqlStr &= " and tmpDu_tbt_jobber_book_search.discount<=tbm_syst_saleschannel.to_Pub_Discount"
        SqlStr &= " and	tbm_syst_saleschannel.sales_channel_code='" + sales_channel + "' "
        SqlStr &= ",(select Buffer_Rate from   tbm_syst_company) as tbm_syst_company	"
        SqlStr &= " order by stock_status ,book_title "
        dt_book_searchTest_Table = SqlDb.GetDataTable(SqlStr)
        Return dt_book_searchTest_Table
    End Function
    Function _dt_book_searchTest()
        Dim condition As String = ""
        Dim SqlDb As SqlDb = New SqlDb

        If header <> Nothing Then
            Select Case header
                Case "Title"
                    condition = " where  book_title= '" & keyword.Replace("'", "''") & "'"
                Case "ISBN"
                    condition = " where View_tbt_jobber_book_search.ISBN_13  = '" & keyword.Replace("'", "") & "'"
                Case "Author"
                    condition = " where Author like '" & keyword.Replace("'", "") & "' "
                Case "Keyword"
                    condition = " where book_title like '" & keyword.Replace("'", "") & "' "
                Case Else
                    condition = ""
            End Select
        End If
        Dim SqlStr As String = ""
        SqlStr &= " select *,case source when 'Asiabooks' then convert(numeric(13,2),View_tbt_jobber_book_search.selling) else"
        SqlStr &= "  convert(numeric(18,2),(View_tbt_jobber_book_search.selling*(isnull(View_tbt_jobber_book_search.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(View_tbt_jobber_book_search.field1,0)))"
        SqlStr &= "  +View_tbt_jobber_book_search.selling*(isnull(View_tbt_jobber_book_search.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(View_tbt_jobber_book_search.field1,0)))"
        SqlStr &= " *Mark_UP/100)) end as Selling_price "
        SqlStr &= " from "
        SqlStr &= " ("
        SqlStr &= "	select	View_tbt_jobber_book_search.image,View_tbt_jobber_book_search.Book_Title"
        SqlStr &= "		 ,case when (View_tbt_jobber_book_search.Author='' or View_tbt_jobber_book_search.Author ='NONE') "
        SqlStr &= "		 then '-' else View_tbt_jobber_book_search.Author end  as Author"
        SqlStr &= "		 ,View_tbt_jobber_book_search.ISBN_13"
        SqlStr &= "		 ,case when View_tbt_jobber_book_search.Publisher_name='' then '-' "
        SqlStr &= "		 else View_tbt_jobber_book_search.Publisher_name end as Publisher_name,View_tbt_jobber_book_search.[Size]"
        SqlStr &= "		 ,convert(numeric(13,2),View_tbt_jobber_book_search.Weight) as Weight"
        SqlStr &= "		 ,View_tbt_jobber_book_search.binding_description"
        SqlStr &= "		 ,case when convert(varchar(10),View_tbt_jobber_book_search.Page_qty)='0' THEN '-' "
        SqlStr &= "		 else convert(varchar(10),View_tbt_jobber_book_search.Page_qty)end as Page_qty"
        SqlStr &= "		 ,case when View_tbt_jobber_book_search.Subject_Name='' then '-'"
        SqlStr &= "		 else View_tbt_jobber_book_search.Subject_Name end as Subject_Name"
        SqlStr &= "		 ,case when View_tbt_jobber_book_search.Stock_status='' then '-'"
        SqlStr &= "		 else View_tbt_jobber_book_search.Stock_status end as stock_status"
        SqlStr &= "		 ,case when right(View_tbt_jobber_book_search.Publication_Date,4)='0000' OR source = 'Asiabooks' then '-'"
        SqlStr &= "		 else right(View_tbt_jobber_book_search.Publication_Date,4)  end as Publication_Date"
        SqlStr &= "		,source,Selling_Price as selling,discount,View_tbt_jobber_book_search.field1"
        SqlStr &= "	from	View_tbt_jobber_book_search " + condition
        SqlStr &= "	and View_tbt_jobber_book_search.field3 ='' "
        'SqlStr &=  "	and View_tbt_jobber_book_search.Weight>0 and Selling_Price>0"
        SqlStr &= "	and Selling_Price>0"

        SqlStr &= "	) as View_tbt_jobber_book_search "
        SqlStr &= " left join (select mark_up,From_Pub_Discount,to_Pub_Discount,sales_channel_code "
        SqlStr &= " from tbm_syst_saleschannel)as tbm_syst_saleschannel"
        SqlStr &= " on View_tbt_jobber_book_search.discount>=tbm_syst_saleschannel.From_Pub_Discount"
        SqlStr &= " and View_tbt_jobber_book_search.discount<=tbm_syst_saleschannel.to_Pub_Discount"
        SqlStr &= " and	tbm_syst_saleschannel.sales_channel_code='" + sales_channel + "' "
        SqlStr &= ",(select Buffer_Rate from   tbm_syst_company) as tbm_syst_company	"
        SqlStr &= " order by stock_status ,book_title "
        dt_book_searchTest = SqlDb.GetDataTable(SqlStr)
        Return dt_book_searchTest
    End Function
    Function _dt_book_search()
        Dim condition As String = ""
        Dim SqlDb As SqlDb = New SqlDb
        'Dim SqlStlr_markup As String = ""
        ''SqlStlr_markup = "SELECT mark_up FROM tbm_syst_saleschannel where sales_channel_code ='" + sales_channal + "'"
        'Dim mark_up As String = "15" 'CStr(CDbl(CInt(SqlDb.GetDataTable(SqlStlr_markup).Rows(0)(0).ToString()) / 100))
        If header <> Nothing Then
            Select Case header
                Case "Title"
                    'condition = " where  contains(book_title, '" & """" & "*" & keyword.Replace("'", "") & "*" & """" & "')"
                    'condition = " where  contains(book_title, '" & """" & keyword.Replace("'", "") & """" & "')"
                    condition = " where  book_title= '" & keyword.Replace("'", "''") & "'"
                Case "ISBN"
                    condition = " where tbt_jobber_book_search.ISBN_13  = '" & keyword.Replace("'", "") & "'"
                Case "Author"
                    condition = " where Author like '" & Replace(keyword.Replace("'", ""), "*", "%") & "' "
                    'condition = " where freetext(Author,'" & keyword.Replace("'", "") & "%') "
                Case "Keyword"
                    condition = " where book_title like '" & Replace(keyword.Replace("'", ""), "*", "%") & "' "
                    'condition = " where freetext(book_title,'%" & keyword.Replace("'", "") & "%') or freetext(short_title,'%" & keyword.Replace("'", "") & "%')"
                Case Else
                    condition = ""
            End Select
        End If
        Dim SqlStr As String = ""
        'SqlStr &=  " select *,case source when 'Asiabooks' then convert(numeric(13,2),tbt_jobber_book_search.selling) else"
        'SqlStr &=  "  convert(numeric(18,2),(tbt_jobber_book_search.selling*(isnull(tbt_jobber_book_search.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbt_jobber_book_search.field1,0)))"
        'SqlStr &=  "  +tbt_jobber_book_search.selling*(isnull(tbt_jobber_book_search.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbt_jobber_book_search.field1,0)))"
        'SqlStr &=  " *Mark_UP/100)) end as Selling_price "
        SqlStr &= " select case source when 'Asiabooks' then convert(numeric(13,2),tbt_jobber_book_search.selling)  "
        SqlStr &= " else convert(numeric(18,2),(tbt_jobber_book_search.selling*(isnull(CR.exchange_rate,0)+ "
        SqlStr &= " ((tbm_syst_company.Buffer_Rate/100) * isnull(CR.exchange_rate,0)))  "
        SqlStr &= " +tbt_jobber_book_search.selling*(isnull(CR.exchange_rate,0)+((tbm_syst_company.Buffer_Rate/100)  * "
        SqlStr &= " isnull(CR.exchange_rate,0))) *Mark_UP/100))"
        SqlStr &= " end as Selling_price , *"

        SqlStr &= " from "
        SqlStr &= " ("
        SqlStr &= "	select	tbt_jobber_book_search.image,tbt_jobber_book_search.Book_Title"
        SqlStr &= "		 ,case when (tbt_jobber_book_search.Author='' or tbt_jobber_book_search.Author ='NONE') "
        SqlStr &= "		 then '-' else tbt_jobber_book_search.Author end  as Author"
        SqlStr &= "		 ,tbt_jobber_book_search.ISBN_13"
        SqlStr &= "		 ,case when tbt_jobber_book_search.Publisher_name='' then '-' "
        SqlStr &= "		 else tbt_jobber_book_search.Publisher_name end as Publisher_name,tbt_jobber_book_search.[Size]"
        SqlStr &= "		 ,convert(numeric(13,2),tbt_jobber_book_search.Weight) as Weight"
        SqlStr &= "		 ,tbt_jobber_book_search.binding_description"
        SqlStr &= "		 ,case when convert(varchar(10),tbt_jobber_book_search.Page_qty)='0' THEN '-' "
        SqlStr &= "		 else convert(varchar(10),tbt_jobber_book_search.Page_qty)end as Page_qty"
        SqlStr &= "		 ,case when tbt_jobber_book_search.Subject_Name='' then '-'"
        SqlStr &= "		 else tbt_jobber_book_search.Subject_Name end as Subject_Name"
        SqlStr &= "		 ,case when tbt_jobber_book_search.Stock_status='' then '-'"
        SqlStr &= "		 else tbt_jobber_book_search.Stock_status end as stock_status"
        SqlStr &= "		 ,case when right(tbt_jobber_book_search.Publication_Date,4)='0000' then '-'"
        SqlStr &= "		 else right(tbt_jobber_book_search.Publication_Date,4)  end as Publication_Date"
        SqlStr &= "		,source,Selling_Price as selling,discount,tbt_jobber_book_search.field1"
        SqlStr &= "	from	tbt_jobber_book_search " + condition
        SqlStr &= "	and tbt_jobber_book_search.field3 ='' "
        'SqlStr &=  "	and tbt_jobber_book_search.ISBN_13 not like '333%' and tbt_jobber_book_search.field3 ='' "
        'SqlStr &=  "	and tbt_jobber_book_search.Weight>0 and Selling_Price>0"
        SqlStr &= "	and Selling_Price>0"

        SqlStr &= "	) as tbt_jobber_book_search "
        SqlStr &= " left join (select mark_up,From_Pub_Discount,to_Pub_Discount,sales_channel_code "
        SqlStr &= " from tbm_syst_saleschannel)as tbm_syst_saleschannel"
        SqlStr &= " on tbt_jobber_book_search.discount>=tbm_syst_saleschannel.From_Pub_Discount"
        SqlStr &= " and tbt_jobber_book_search.discount<=tbm_syst_saleschannel.to_Pub_Discount"
        SqlStr &= " and	tbm_syst_saleschannel.sales_channel_code='" + sales_channel + "' "
        '=================== Start New du 30/11/2009
        SqlStr &= " left join (select a.Org_indent_code,b.currency_code,b.exchange_rate"
        SqlStr &= " from tbm_syst_organizeindent A ,tbm_syst_currency  B"
        SqlStr &= " where a.currency_code = b.currency_code) CR On  tbt_jobber_book_search.source =CR.Org_indent_code"
        '=================== End New du 30/11/2009


        SqlStr &= ",(select Buffer_Rate from   tbm_syst_company) as tbm_syst_company	"
        SqlStr &= " order by stock_status ,book_title  "
        dt_book_search = SqlDb.GetDataTable(SqlStr)

        Return dt_book_search
    End Function
    Function _dt_book_search_Internet()
        '/////////promptnow/////////
        Dim strsql As String = ""
        Dim SqlDb As New SqlDb
        Dim sql_datatable As New DataTable
        Dim sql_datatable2 As New DataTable

        Dim datatable As DataTable = New DataTable("datatable")
        Dim datacolumn As New DataColumn
        Dim datarow As DataRow

        '/////////////////////////////////
        '////////// create column/////////
        datatable.Columns.Add("isbn_13", System.Type.GetType("System.String"))
        datatable.Columns.Add("book_title", System.Type.GetType("System.String"))
        datatable.Columns.Add("book_title_search", System.Type.GetType("System.String"))
        datatable.Columns.Add("author", System.Type.GetType("System.String"))
        datatable.Columns.Add("author_search", System.Type.GetType("System.String"))
        datatable.Columns.Add("selling_price", System.Type.GetType("System.String"))
        datatable.Columns.Add("selling_price_ecomn", System.Type.GetType("System.String"))
        datatable.Columns.Add("ecom_discount", System.Type.GetType("System.String"))
        datatable.Columns.Add("publisher_name", System.Type.GetType("System.String"))
        datatable.Columns.Add("source", System.Type.GetType("System.String"))
        datatable.Columns.Add("image", System.Type.GetType("System.String"))
        datatable.Columns.Add("book_type", System.Type.GetType("System.String"))
        datatable.Columns.Add("other_format", System.Type.GetType("System.String"))
        datatable.Columns.Add("ebook_format", System.Type.GetType("System.String"))
        datatable.Columns.Add("keyword", System.Type.GetType("System.String"))
        datatable.Columns.Add("indexs", System.Type.GetType("System.String"))

        strsql &= " SELECT DISTINCT "
        strsql &= " case search.source when 'Asiabooks' then cast(ROUND(convert(numeric(13,2),search.selling),0) as varchar) "
        strsql &= " else cast(ROUND(convert(numeric(18,2),(search.selling * (isnull(search.exchange_rate,0) + "
        strsql &= " ((search.Buffer_Rate/100) * isnull(search.exchange_rate,0))) + "
        strsql &= " search.selling * (isnull(search.exchange_rate,0) + ((search.buffer_rate/100) * "
        strsql &= " isnull(search.exchange_rate,0))) * search.mark_up/100)),0) as varchar) end as selling_price "

        strsql &= " , case search.source when 'Asiabooks' then cast(ROUND(convert(numeric(13,2),search.selling_price_ecom),0) as varchar) "
        strsql &= " else cast(ROUND(convert(numeric(18,2),(search.selling * (isnull(search.exchange_rate,0) + "
        strsql &= " ((search.Buffer_Rate/100) * isnull(search.exchange_rate,0))) + "
        strsql &= " search.selling * (isnull(search.exchange_rate,0) + ((search.buffer_rate/100) * "
        strsql &= " isnull(search.exchange_rate,0))) * search.mark_up/100)),0) as varchar) end as selling_price_ecomn "

        If country.ToUpper = "TH" Then
            strsql &= " , case when (search.other_format is not null) "
            strsql &= " then search.other_format else 'none' end as other_format "
        Else
            strsql &= " , case when (search.other_format is not null and territory.country_code is null) "
            strsql &= " then search.other_format else 'none' end as other_format "
        End If

        strsql &= " , search.isbn_13 , search.book_title , search.book_title_search , search.author "
        strsql &= " , search.author_search , search.publisher_name , search.image , search.source "
        strsql &= " , cast(search.ecom_discount as varchar) as ecom_discount , 'book' as book_type "
        strsql &= " , '0' as ebook_format , search.keyword , search.stock , '1' as indexs "

        strsql &= " FROM "

        strsql &= " (select distinct top(1000) book.isbn_13 , book.book_title , UPPER(book.book_title) as book_title_search "
        strsql &= " , case book.author when '' then 'NONE' else book.author end as author , UPPER(book.author) as author_search "
        strsql &= " , case book.publisher_name when '' then '-' else book.publisher_name end as publisher_name "
        strsql &= " , convert(numeric(18,2),ecom_discount) as ecom_discount "
        strsql &= " , convert(numeric(13,2), book.selling_price) as selling , book.image , book.source  "
        strsql &= " , book.selling_price_ecom , book.price_save , UPPER(book.keyword) as keyword "
        strsql &= " , cast(book.link_isbn as varchar) as other_format , UPPER(left(book.stock_status,1)) as stock "
        strsql &= " , company.buffer_rate , book.discount , currency.exchange_rate , channel.mark_up "

        strsql &= " from tbt_jobber_book_search book with (nolock) "
        strsql &= " , tbm_syst_saleschannel channel with (nolock) "
        strsql &= " , tbm_syst_organizeindent organize with (nolock) "
        strsql &= " , tbm_syst_currency currency with (nolock) "
        strsql &= " , tbm_syst_company company with (nolock) "

        strsql &= " where (book.discount >= channel.from_pub_discount and book.discount <= channel.to_pub_discount) "
        strsql &= " and channel.sales_channel_code = 'INTERNET' "
        strsql &= " and ((book.source = organize.org_indent_code and book.source <> 'Asiabooks') "
        strsql &= " or (book.source <> organize.org_indent_code and book.source = 'Asiabooks')) "
        strsql &= " and organize.currency_code = currency.currency_code "
        strsql &= " and convert(numeric(13,2), book.selling_price) > 0 and book.field3 = '' "
        strsql &= " and contains(book.keyword,'" & """" & keyword.ToString.Trim.ToUpper.Replace("'S", "").Replace("'", "") & """" & "') "
        strsql &= " ) as search "
        If country.ToUpper = "TH" Then
            strsql &= " left join (select distinct bookid as ebook_id , isbn_13 "
            strsql &= " from ebook_store where status = 'active' and th = 1 ) ebook "
            strsql &= " on search.other_format = ebook.isbn_13 "
        Else
            strsql &= " left join (select distinct bookid as ebook_id , isbn_13 "
            strsql &= " from ebook_store where status = 'active' ) ebook "
            strsql &= " on search.other_format = ebook.isbn_13 "

            strsql &= " left join (select distinct bookid as ebook_id , country_code "
            strsql &= " from " + territory + " where country_code = '" + country + "') as territory "
            strsql &= " on ebook.ebook_id = territory.ebook_id "
        End If

        sql_datatable = SqlDb.GetDataTable(strsql)

        strsql = ""

        strsql &= " SELECT DISTINCT "
        strsql &= " '' as selling_price , '' as selling_price_ecomn "

        strsql &= " , '' as other_format "

        strsql &= " , search.isbn_13 , '' as book_title , '' as book_title_search , '' as author , '' as author_search "
        strsql &= " , '' as publisher_name , '' as image , '' as source , '' as ecom_discount , 'ebook' as book_type "
        strsql &= " , '' as ebook_format , '' as keyword , 'A' as stock , '2' as indexs "

        strsql &= " FROM "
        strsql &= " (select top(1000) cast(ebook.isbn_13 as varchar) as isbn_13 , cast(ebook.on_book as varchar) as other_format "
        strsql &= " , ebook.bookid as ebook_id , ebook.book_cuttitle "
        strsql &= " from ebook_store ebook with (nolock) "
        strsql &= " where ebook.status = 'active' "
        strsql &= " and (convert(numeric(18,2),isnull(ebook.price_org,0)) * convert(numeric(18,2),isnull(ebook.moneytype,0))) > 50 "
        strsql &= " and contains(ebook.keyword,'" & """" & keyword.ToString.Trim.ToUpper.Replace("'S", "").Replace("'", "") & """" & "') "
        If country = "TH" Then
            strsql &= " and ebook.th = 1 "
            strsql &= " ) as search "
        Else
            strsql &= " ) as search "

            strsql &= " left join (select distinct bookid as ebook_id , country_code "
            strsql &= " from " + territory + " where country_code = '" + country + "') as territory "
            strsql &= " on search.ebook_id = territory.ebook_id "

            strsql &= " WHERE territory.country_code is null "
        End If

        sql_datatable2 = SqlDb.GetDataTable(strsql)
        For Each row As DataRow In sql_datatable2.Rows
            sql_datatable.ImportRow(row)
            sql_datatable.AcceptChanges()
        Next

        Dim strings As String = ""
        If sql_datatable.Rows.Count > 0 Then
            For Each datarows As DataRow In sql_datatable.Select("book_type = 'ebook'")
                strings &= datarows.Item("isbn_13").ToString + ","
            Next
            If strings.Length > 13 Then
                isbn_13 = strings.Substring(0, strings.Length - 1)
                Dim data_format As New DataTable
                data_format = get_format_ebook()
                For Each i As DataRow In sql_datatable.Select("book_type = 'ebook'")
                    Dim ii As String = i.Item("isbn_13").ToString
                    Dim format As String = ""
                    Dim img As String = ""
                    For Each j As DataRow In data_format.Select("isbn_13 = " + ii + "")
                        format &= j.Item("ebook_format").ToString + ","
                        img = j.Item("image").ToString
                        i.Item("selling_price") = CDbl(j.Item("selling_price")).ToString("#,###")
                        i.Item("selling_price_ecomn") = CDbl(j.Item("selling_price_ecomn")).ToString("#,###")
                        i.Item("book_title") = j.Item("book_title").ToString
                        i.Item("book_title_search") = j.Item("book_title_search").ToString
                        i.Item("author") = j.Item("author").ToString
                        i.Item("author_search") = j.Item("author_search").ToString
                        i.Item("publisher_name") = j.Item("publisher_name").ToString
                        i.Item("other_format") = j.Item("other_format").ToString
                        i.Item("source") = j.Item("source").ToString
                        i.Item("ecom_discount") = j.Item("ecom_discount").ToString
                        i.Item("keyword") = j.Item("keyword").ToString
                    Next
                    i.Item("image") = img.Substring(0, 3) + "/" + img.Substring(3, 3) + "/" + img.Substring(6, 3) + "/" + img + ".jpg"
                    i.Item("ebook_format") = format.Substring(0, format.Length - 1)
                Next
            End If

            Dim key As String = keyword.ToString.Trim.ToUpper.Replace("'S", "").Replace("'", "")
            For Each r1 As DataRow In sql_datatable.Select("book_title_search = '" + key + "'", "indexs asc , stock asc")
                datarow = datatable.NewRow
                datarow("isbn_13") = r1.Item("isbn_13").ToString
                datarow("book_title") = r1.Item("book_title").ToString
                datarow("book_title_search") = r1.Item("book_title_search").ToString
                datarow("author") = r1.Item("author").ToString
                datarow("author_search") = r1.Item("author_search").ToString
                datarow("selling_price") = CDbl(r1.Item("selling_price")).ToString("#,###")
                datarow("selling_price_ecomn") = CDbl(r1.Item("selling_price_ecomn")).ToString("#,###")
                datarow("ecom_discount") = r1.Item("ecom_discount").ToString
                datarow("publisher_name") = r1.Item("publisher_name").ToString
                datarow("source") = r1.Item("source").ToString
                datarow("image") = r1.Item("image").ToString
                datarow("book_type") = r1.Item("book_type").ToString
                If Left(datarow("isbn_13").ToString, 3) = "MAG" Then
                    datarow("book_type") = "magazine"
                End If
                datarow("other_format") = r1.Item("other_format").ToString
                datarow("ebook_format") = r1.Item("ebook_format").ToString
                datarow("keyword") = r1.Item("keyword").ToString
                datarow("indexs") = r1.Item("indexs").ToString
                datatable.Rows.Add(datarow)
                r1.Delete()
                sql_datatable.AcceptChanges()
            Next

            For Each datarows As DataRow In sql_datatable.Select("", "indexs asc  , stock asc , book_title asc")
                datarow = datatable.NewRow
                datarow("isbn_13") = datarows.Item("isbn_13").ToString
                datarow("book_title") = datarows.Item("book_title").ToString
                datarow("book_title_search") = datarows.Item("book_title_search").ToString
                datarow("author") = datarows.Item("author").ToString
                datarow("author_search") = datarows.Item("author_search").ToString
                datarow("selling_price") = CDbl(datarows.Item("selling_price")).ToString("#,###")
                datarow("selling_price_ecomn") = CDbl(datarows.Item("selling_price_ecomn")).ToString("#,###")
                datarow("ecom_discount") = datarows.Item("ecom_discount").ToString
                datarow("publisher_name") = datarows.Item("publisher_name").ToString
                datarow("source") = datarows.Item("source").ToString
                datarow("image") = datarows.Item("image").ToString
                datarow("book_type") = datarows.Item("book_type").ToString
                If Left(datarow("isbn_13").ToString, 3) = "MAG" Then
                    datarow("book_type") = "magazine"
                End If
                datarow("other_format") = datarows.Item("other_format").ToString
                datarow("ebook_format") = datarows.Item("ebook_format").ToString
                datarow("keyword") = datarows.Item("keyword").ToString
                datarow("indexs") = datarows.Item("indexs").ToString
                datatable.Rows.Add(datarow)
            Next
            sql_datatable.Dispose()
        End If

        Return datatable
    End Function
    'Function _dt_book_search_Internet()
    '    Dim condition As String = ""
    '    Dim SqlDb As SqlDb = New SqlDb
    '    'Dim SqlStlr_markup As String = ""
    '    ''SqlStlr_markup = "SELECT mark_up FROM tbm_syst_saleschannel where sales_channel_code ='" + sales_channal + "'"
    '    'Dim mark_up As String = "15" 'CStr(CDbl(CInt(SqlDb.GetDataTable(SqlStlr_markup).Rows(0)(0).ToString()) / 100))
    '    If header <> Nothing Then
    '        Select Case header
    '            Case "Title"
    '                'condition = " where  contains(book_title, '" & """" & "*" & keyword.Replace("'", "") & "*" & """" & "')"
    '                'condition = " where  contains(book_title, '" & """" & keyword.Replace("'", "") & """" & "')"
    '                condition = " where  book_title like '%" & keyword & ("%") & "'"
    '            Case "ISBN"
    '                condition = " where tbt_jobber_book_search.ISBN_13  = '" & keyword.Replace("'", "") & "'"
    '            Case "Author"
    '                condition = " where Author like '%" & keyword.Replace(" ", "%") & ("%") & "' "
    '                'condition = " where freetext(Author,'" & keyword.Replace("'", "") & "%') "
    '            Case "Keyword"
    '                condition = " where book_title like '%" & keyword.Replace(" ", "%") & ("%") & "' "
    '                'condition = " where freetext(book_title,'%" & keyword.Replace("'", "") & "%') or freetext(short_title,'%" & keyword.Replace("'", "") & "%')"
    '            Case "Cate"
    '                condition = " where substring(Subject_Code,4,1) = '" & keyword & "' "
    '            Case "SubCate"
    '                condition = " where substring(Subject_Code,4,2) = '" & keyword & "' "
    '            Case Else
    '                condition = ""
    '        End Select
    '    End If
    '    Dim SqlStr As String = ""
    '    SqlStr &=  " select "
    '    'SqlStr &=  "  *,case source when 'Asiabooks' then convert(numeric(13,2),tbt_jobber_book_search.selling) else"
    '    'SqlStr &=  "  convert(numeric(18,2),(tbt_jobber_book_search.selling*(isnull(tbt_jobber_book_search.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbt_jobber_book_search.field1,0)))"
    '    'SqlStr &=  "  +tbt_jobber_book_search.selling*(isnull(tbt_jobber_book_search.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbt_jobber_book_search.field1,0)))"
    '    'SqlStr &=  " *Mark_UP/100)) end as Selling_price "
    '    SqlStr &=  "  case source when 'Asiabooks' then convert(numeric(13,2),tbt_jobber_book_search.selling) else"
    '    SqlStr &=  "  convert(numeric(18,2),(tbt_jobber_book_search.selling*(isnull(CR.exchange_rate,0)+"
    '    SqlStr &=  "  ((tbm_syst_company.Buffer_Rate/100) * isnull(CR.exchange_rate,0)))"
    '    SqlStr &=  "  +tbt_jobber_book_search.selling*(isnull(CR.exchange_rate,0)+((tbm_syst_company.Buffer_Rate/100) * "
    '    SqlStr &=  "  isnull(CR.exchange_rate,0))) * Mark_UP/100)) end as Selling_price , * "
    '    SqlStr &=  " from "
    '    SqlStr &=  " ("
    '    SqlStr &=  "	select	tbt_jobber_book_search.image,tbt_jobber_book_search.Book_Title"
    '    SqlStr &=  "		 ,case when (tbt_jobber_book_search.Author='' or tbt_jobber_book_search.Author ='NONE') "
    '    SqlStr &=  "		 then '-' else tbt_jobber_book_search.Author end  as Author"
    '    SqlStr &=  "		 ,tbt_jobber_book_search.ISBN_13"
    '    SqlStr &=  "		 ,case when tbt_jobber_book_search.Publisher_name='' then '-' "
    '    SqlStr &=  "		 else tbt_jobber_book_search.Publisher_name end as Publisher_name,tbt_jobber_book_search.[Size]"
    '    SqlStr &=  "		 ,convert(numeric(13,2),tbt_jobber_book_search.Weight) as Weight"
    '    SqlStr &=  "		 ,tbt_jobber_book_search.binding_description"
    '    SqlStr &=  "		 ,case when convert(varchar(10),tbt_jobber_book_search.Page_qty)='0' THEN '-' "
    '    SqlStr &=  "		 else convert(varchar(10),tbt_jobber_book_search.Page_qty)end as Page_qty"
    '    SqlStr &=  "		 ,case when tbt_jobber_book_search.Subject_Name='' then '-'"
    '    SqlStr &=  "		 else tbt_jobber_book_search.Subject_Name end as Subject_Name"
    '    SqlStr &=  "		 ,case when tbt_jobber_book_search.Stock_status='' then '-'"
    '    SqlStr &=  "		 else tbt_jobber_book_search.Stock_status end as stock_status"
    '    SqlStr &=  "		 ,case when right(tbt_jobber_book_search.Publication_Date,4)='0000' then '-'"
    '    SqlStr &=  "		 else right(tbt_jobber_book_search.Publication_Date,4)  end as Publication_Date"
    '    SqlStr &=  "		,source,Selling_Price as selling,discount,tbt_jobber_book_search.field1"
    '    SqlStr &=  "	from	tbt_jobber_book_search " + condition
    '    SqlStr &=  "	and tbt_jobber_book_search.field3 ='' "
    '    'SqlStr &=  "	and tbt_jobber_book_search.ISBN_13 not like '333%' and tbt_jobber_book_search.field3 ='' "
    '    'SqlStr &=  "	and tbt_jobber_book_search.Weight>0 and Selling_Price>0"
    '    SqlStr &=  "	and Selling_Price>0 "

    '    SqlStr &=  "	) as tbt_jobber_book_search "
    '    SqlStr &=  " left join (select mark_up,From_Pub_Discount,to_Pub_Discount,sales_channel_code "
    '    SqlStr &=  " from tbm_syst_saleschannel)as tbm_syst_saleschannel"
    '    SqlStr &=  " on tbt_jobber_book_search.discount>=tbm_syst_saleschannel.From_Pub_Discount"
    '    SqlStr &=  " and tbt_jobber_book_search.discount<=tbm_syst_saleschannel.to_Pub_Discount"
    '    SqlStr &=  " and	tbm_syst_saleschannel.sales_channel_code='" + sales_channel + "' "
    '    '=================== Start New du 30/11/2009
    '    SqlStr &=  " left join (select a.Org_indent_code,b.currency_code,b.exchange_rate"
    '    SqlStr &=  " from tbm_syst_organizeindent A ,tbm_syst_currency  B"
    '    SqlStr &=  " where a.currency_code = b.currency_code) CR On  tbt_jobber_book_search.source =CR.Org_indent_code"
    '    '=================== End New du 30/11/2009

    '    SqlStr &=  ",(select Buffer_Rate from   tbm_syst_company) as tbm_syst_company	"
    '    SqlStr &=  " order by stock_status ,book_title  "
    '    dt_book_search = SqlDb.GetDataTable(SqlStr)
    '    Return dt_book_search
    'End Function
    Function _dt_book_search_Internet_Check_Weight()
        Dim condition As String = ""
        Dim SqlDb As SqlDb = New SqlDb
        'Dim SqlStlr_markup As String = ""
        ''SqlStlr_markup = "SELECT mark_up FROM tbm_syst_saleschannel where sales_channel_code ='" + sales_channal + "'"
        'Dim mark_up As String = "15" 'CStr(CDbl(CInt(SqlDb.GetDataTable(SqlStlr_markup).Rows(0)(0).ToString()) / 100))
        If header <> Nothing Then
            Select Case header
                Case "Title"
                    'condition = " where  contains(book_title, '" & """" & "*" & keyword.Replace("'", "") & "*" & """" & "')"
                    'condition = " where  contains(book_title, '" & """" & keyword.Replace("'", "") & """" & "')"
                    condition = " where book_title like '%" & keyword & ("%") & "'"
                Case "ISBN"
                    condition = " where ISBN_13  = '" & keyword.Replace("'", "") & "'"
                Case "Author"
                    condition = " where Author like '%" & keyword.Replace(" ", "%") & ("%") & "' "
                    'condition = " where freetext(Author,'" & keyword.Replace("'", "") & "%') "
                Case "Keyword"
                    condition = " where book_title like '%" & keyword.Replace(" ", "%") & ("%") & "' "
                    'condition = " where freetext(book_title,'%" & keyword.Replace("'", "") & "%') or freetext(short_title,'%" & keyword.Replace("'", "") & "%')"
                    'Case "Cate"
                    '    condition = " where substring(Subject_Code,4,1) = '" & keyword & "' "
                    'Case "SubCate"
                    '    condition = " where substring(Subject_Code,4,2) = '" & keyword & "' "
                Case Else
                    condition = ""
            End Select
        End If
        Dim SqlStr As String = ""
        SqlStr &= " select isbn_13,book_title,weight,selling_price "
        SqlStr &= " from dbo.tbt_jobber_book_search " + condition
        'SqlStr &=  " where a.isbn_13 = b.isbn_13 "
        dt_book_search_check_weight = SqlDb.GetDataTable(SqlStr)
        Return dt_book_search_check_weight
    End Function
    Function _dt_book_search_Internet_CateCode()
        Dim condition As String = ""
        Dim SqlDb As SqlDb = New SqlDb
        'Dim SqlStlr_markup As String = ""
        ''SqlStlr_markup = "SELECT mark_up FROM tbm_syst_saleschannel where sales_channel_code ='" + sales_channal + "'"
        'Dim mark_up As String = "15" 'CStr(CDbl(CInt(SqlDb.GetDataTable(SqlStlr_markup).Rows(0)(0).ToString()) / 100))
        If header <> Nothing Then
            Select Case header
                Case "Title"
                    'condition = " where  contains(book_title, '" & """" & "*" & keyword.Replace("'", "") & "*" & """" & "')"
                    'condition = " where  contains(book_title, '" & """" & keyword.Replace("'", "") & """" & "')"
                    condition = " where  book_title like '%" & keyword & "%' and Weight >0 "
                Case "ISBN"
                    condition = " where ISBN_13  = '" & keyword.Replace("'", "") & "'  and Weight >0 "
                Case "Author"
                    condition = " where Author like '%" & keyword.Replace(" ", "%") & "%'  and Weight >0 "
                    'condition = " where freetext(Author,'" & keyword.Replace("'", "") & "%') "
                Case "Keyword"
                    condition = " where book_title like '%" & keyword.Replace(" ", "%") & "%'  and Weight >0 "
                    'condition = " where freetext(book_title,'%" & keyword.Replace("'", "") & "%') or freetext(short_title,'%" & keyword.Replace("'", "") & "%')"
                Case "Cate"
                    condition = " where substring(Subject_Code,4,1) = '" & keyword.Replace("'", "") & "'  and Weight >0 "
                Case "SubCate"
                    condition = " where substring(Subject_Code,4,2) = '" & keyword.Replace("'", "") & "'  and Weight >0 "
                Case Else
                    condition = ""
            End Select
        End If
        Dim SqlStr As String = ""
        SqlStr &= " SELECT ISBN_13, Selling_price, [Image], Book_Title, Author, Publisher_name, "
        SqlStr &= " [Size], Weight, Binding_Description, Page_qty, Subject_Name, Stock_status, "
        SqlStr &= " Publication_Date, Source, Subject_Code"
        SqlStr &= " FROM v_book_search_internet " + condition

        SqlStr &= " order by Maintenance_Date desc "
        'SqlStr &=  " select ISBN_13,convert(numeric(13,2),Selling_Price) as  Selling_price ,[image],Book_Title"
        'SqlStr &=  "  ,case when (Author='' or Author ='NONE') then '-' else Author end  as Author"
        'SqlStr &=  "  ,case when Publisher_name='' then '-'  else Publisher_name end as Publisher_name,[Size]"
        'SqlStr &=  "  ,convert(numeric(13,2),Weight) as Weight	,Binding_Description "
        'SqlStr &=  "  ,case when convert(varchar(10),Page_qty)='0' THEN '-' else convert(varchar(10),Page_qty)end as Page_qty "
        'SqlStr &=  "	 ,case when Subject_Name='' then '-'	else Subject_Name end as Subject_Name"
        'SqlStr &=  "	 ,Stock_status='Available in Asia Books/Bookazine' ,Publication_Date = '',source "
        'SqlStr &=  "	 from	tbm_asbkeo_bookab " + condition
        'SqlStr &=  "	and tbm_asbkeo_bookab.ISBN_13 not like '333%'"
        'SqlStr &=  "	 and Selling_Price>0 and ISBN_13 in (select ISBN_13 from tbt_jobber_book_search where source = 'Asiabooks')"
        'SqlStr &=  "	 order by stock_status ,book_title "

        dt_book_search = SqlDb.GetDataTable(SqlStr)
        Return dt_book_search
    End Function
    Function Top_Sale()
        Dim SqlDb As SqlDb = New SqlDb
        Dim SqlStr As String = ""
        SqlStr &= " select	tbt_jobber_book_search.image,tbt_jobber_book_search.Book_Title"
        SqlStr &= "		,case when (tbt_jobber_book_search.Author='' or tbt_jobber_book_search.Author ='NONE') "
        SqlStr &= "		then '-' else tbt_jobber_book_search.Author end  as Author"
        SqlStr &= "		,tbt_jobber_book_search.ISBN_13"
        SqlStr &= "		,case when tbt_jobber_book_search.Publisher_name='' then '-'"
        SqlStr &= "		else tbt_jobber_book_search.Publisher_name end as Publisher_name,tbt_jobber_book_search.[Size]"
        SqlStr &= "		,convert(numeric(13,2),tbt_jobber_book_search.Weight) as Weight"
        SqlStr &= "		,tbt_jobber_book_search.binding_description"
        SqlStr &= "		,case when convert(varchar(10),tbt_jobber_book_search.Page_qty)='0' THEN '-' "
        SqlStr &= "		else convert(varchar(10),tbt_jobber_book_search.Page_qty)end as Page_qty"
        SqlStr &= "		,case when tbt_jobber_book_search.Subject_Name='' then '-'"
        SqlStr &= "		else tbt_jobber_book_search.Subject_Name end as Subject_Name"
        SqlStr &= "		,case when tbt_jobber_book_search.Stock_status='' then '-'"
        SqlStr &= "		else tbt_jobber_book_search.Stock_status end as stock_status"
        SqlStr &= "		,case when right(tbt_jobber_book_search.Publication_Date,4)='0000' then '-'"
        SqlStr &= "		else right(tbt_jobber_book_search.Publication_Date,4)  end as Publication_Date"
        SqlStr &= "		,case tbt_jobber_book_search.source when 'Asiabooks' then convert(numeric(13,2),tbt_jobber_book_search.Selling_Price) else "
        SqlStr &= "		CAST(convert(numeric(13,2),convert(numeric(13,2),tbt_jobber_book_search.Selling_Price)+((convert(numeric(13,2),tbt_jobber_book_search.Selling_Price)*Mark_UP)/100)) AS numeric(18,2)) end as Selling_Price "
        SqlStr &= " from	tbt_jobber_book_search left join  tbm_syst_saleschannel"
        SqlStr &= "		on tbt_jobber_book_search.discount>=tbm_syst_saleschannel.From_Pub_Discount"
        SqlStr &= "		and tbt_jobber_book_search.discount<=tbm_syst_saleschannel.to_Pub_Discount"
        SqlStr &= "		and	tbm_syst_saleschannel.sales_channel_code='" + sales_channel + "'"
        SqlStr &= "	inner join tbm_asbkeo_bookab on tbt_jobber_book_search.isbn_13=tbm_asbkeo_bookab.isbn_13"
        SqlStr &= "		and tbt_jobber_book_search.selling_price>0 "
        'SqlStr &=  "		and tbt_jobber_book_search.Weight>0 and tbt_jobber_book_search.selling_price>0 and tbt_jobber_book_search.isbn_13 = '0000014982'"
        SqlStr &= "	   Order by ISBN_13"
        'SqlStr &=  "		and tbm_asbkeo_bookab.field10='TopSale' Order by ISBN_13"
        dt_book_search = SqlDb.GetDataTable(SqlStr)
        Return dt_book_search
    End Function

    Function list_promotion()
        Dim strsql As String = ""
        Dim SqlDb As SqlDb = New SqlDb
        Dim datatable As DataTable

        strsql &= " SELECT DISTINCT "
        strsql &= " ebook.isbn_13 "
        strsql &= " , ebook.bookid as ebook_id "
        strsql &= " , ebook.book_title as title "
        strsql &= " , ebook.publisher_name as publisher "
        strsql &= " , ebook.author "
        strsql &= " , ebook_type.type as format "
        strsql &= " , ebook.isbn_10 as image "
        strsql &= " , case when len(ebook.synopsis) > 150 "
        strsql &= " then left(isnull(ebook.synopsis,'-'),150)+'...' else isnull(ebook.synopsis,'-') end as synopsis "
        strsql &= " , isnull(ebook.synopsis,'') as synopsis_full "
        strsql &= " FROM "
        strsql &= " (select isbn_13,bookid,book_title,publisher_name,author,format_type,isbn_10,synopsis "
        strsql &= " from ebook_store where (status='active' or status is null) and promotion = 1) as ebook "
        strsql &= " left join ebook_type "
        strsql &= " on ebook.format_type = ebook_type.formatid "
        strsql &= " ORDER BY ebook.book_title "

        datatable = SqlDb.GetDataTable(strsql)

        Return datatable
    End Function

    Function Advance_Search()
        Dim strsql As String = ""
        Dim SqlDb As New SqlDb
        Dim datatable As New DataTable
        Dim datatable2 As New DataTable

        If advance_search_forcus = "ebook" Then
            datatable = ebook()
        End If
        If advance_search_forcus = "book" Then
            datatable = book()
        End If
        If advance_search_forcus = "all" Then
            datatable = book_and_ebook()
        End If

        Return datatable
    End Function

    Function ebook()
        Dim strsql As String = ""
        Dim SqlDb As New SqlDb
        Dim sql_datatable As New DataTable
        Dim sql_datatable2 As New DataTable

        Dim datatable As DataTable = New DataTable("datatable")
        Dim datacolumn As New DataColumn
        Dim datarow As DataRow

        '/////////////////////////////////
        '////////// create column/////////
        datatable.Columns.Add("isbn_13", System.Type.GetType("System.String"))
        datatable.Columns.Add("book_title", System.Type.GetType("System.String"))
        datatable.Columns.Add("book_title_search", System.Type.GetType("System.String"))
        datatable.Columns.Add("author", System.Type.GetType("System.String"))
        datatable.Columns.Add("author_search", System.Type.GetType("System.String"))
        datatable.Columns.Add("selling_price", System.Type.GetType("System.Double"))
        datatable.Columns.Add("selling_price_ecomn", System.Type.GetType("System.Double"))
        datatable.Columns.Add("ecom_discount", System.Type.GetType("System.String"))
        datatable.Columns.Add("publisher_name", System.Type.GetType("System.String"))
        datatable.Columns.Add("source", System.Type.GetType("System.String"))
        datatable.Columns.Add("image", System.Type.GetType("System.String"))
        datatable.Columns.Add("book_type", System.Type.GetType("System.String"))
        datatable.Columns.Add("other_format", System.Type.GetType("System.String"))
        datatable.Columns.Add("ebook_format", System.Type.GetType("System.String"))
        datatable.Columns.Add("keyword", System.Type.GetType("System.String"))
        datatable.Columns.Add("indexs", System.Type.GetType("System.String"))

        strsql &= " SELECT DISTINCT "
        strsql &= " '' as selling_price , '' as selling_price_ecomn "

        strsql &= " , '' as other_format "

        strsql &= " , search.isbn_13 , '' as book_title , '' as book_title_search , '' as author , '' as author_search "
        strsql &= " , '' as publisher_name , '' as image , '' as source , '' as ecom_discount , 'ebook' as book_type "
        strsql &= " , '' as ebook_format , '' as keyword , '1' as indexs "

        strsql &= " FROM "
        strsql &= " (select cast(ebook.isbn_13 as varchar) as isbn_13 , ebook.bookid as ebook_id , cast(ebook.on_book as varchar) as other_format "
        strsql &= " from ebook_store ebook with (nolock) "
        strsql &= " where ebook.status = 'active' "
        strsql &= " and (convert(numeric(18,2),isnull(ebook.price_org,0)) * convert(numeric(18,2),isnull(ebook.moneytype,0))) > 50 "
        strsql &= " " + equal_ + " "
        If country = "TH" Then
            strsql &= " and ebook.th = 1 "
            strsql &= " ) as search "
        Else
            strsql &= " ) as search "

            strsql &= " left join (select distinct bookid as ebook_id , country_code "
            strsql &= " from " + territory + " where country_code = '" + country + "') as territory "
            strsql &= " on search.ebook_id = territory.ebook_id "

            strsql &= " WHERE territory.country_code is null "
        End If

        sql_datatable = SqlDb.GetDataTable(strsql)

        strsql = ""
        strsql &= " SELECT DISTINCT "
        strsql &= " '' as selling_price , '' as selling_price_ecomn "

        strsql &= " , '' as other_format "

        strsql &= " , search.isbn_13 , '' as book_title , '' as book_title_search , '' as author , '' as author_search "
        strsql &= " , '' as publisher_name , '' as image , '' as source , '' as ecom_discount , 'ebook' as book_type "
        strsql &= " , '' as ebook_format , '' as keyword , '2' as indexs "

        strsql &= " FROM "
        strsql &= " (select top(500) cast(ebook.isbn_13 as varchar) as isbn_13 , ebook.bookid as ebook_id , cast(ebook.on_book as varchar) as other_format "
        strsql &= " from ebook_store ebook with (nolock) "
        strsql &= " where ebook.status = 'active' "
        strsql &= " and (convert(numeric(18,2),isnull(ebook.price_org,0)) * convert(numeric(18,2),isnull(ebook.moneytype,0))) > 50 "
        strsql &= " " + like_ + " "
        If country = "TH" Then
            strsql &= " and ebook.th = 1 "
            strsql &= " ) as search "
        Else
            strsql &= " ) as search "

            strsql &= " left join (select distinct bookid as ebook_id , country_code "
            strsql &= " from " + territory + " where country_code = '" + country + "') as territory "
            strsql &= " on search.ebook_id = territory.ebook_id "

            strsql &= " WHERE territory.country_code is null "
        End If

        sql_datatable2 = SqlDb.GetDataTable(strsql)

        For Each row As DataRow In sql_datatable2.Rows
            sql_datatable.ImportRow(row)
            sql_datatable.AcceptChanges()
        Next

        Dim strings As String = ""
        If sql_datatable.Rows.Count > 0 Then
            Dim d1 As New DataTable
            d1 = sql_datatable.Copy
            For Each aaa As DataRow In d1.Select("indexs = '1'")
                Dim isbn As String = aaa.Item("isbn_13").ToString.Trim
                For Each bbb As DataRow In sql_datatable.Select("isbn_13 = " + isbn + "")
                    If bbb.Item("indexs").ToString = "2" Then
                        bbb.Delete()
                        sql_datatable.AcceptChanges()
                    End If
                Next
            Next

            For Each datarows As DataRow In sql_datatable.Rows
                strings &= datarows.Item("isbn_13").ToString + ","
            Next

            If strings.Length > 13 Then
                isbn_13 = strings.Substring(0, strings.Length - 1)
                Dim data_format As New DataTable
                data_format = get_format_ebook()
                For Each i As DataRow In sql_datatable.Rows
                    Dim ii As String = i.Item("isbn_13").ToString
                    Dim format As String = ""
                    Dim img As String = ""
                    For Each j As DataRow In data_format.Select("isbn_13 = " + ii + "")
                        format &= j.Item("ebook_format").ToString + ","
                        img = j.Item("image").ToString
                        i.Item("selling_price") = CDbl(j.Item("selling_price"))
                        i.Item("selling_price_ecomn") = CDbl(j.Item("selling_price_ecomn"))
                        i.Item("book_title") = j.Item("book_title").ToString
                        i.Item("book_title_search") = j.Item("book_title_search").ToString
                        i.Item("author") = j.Item("author").ToString
                        i.Item("author_search") = j.Item("author_search").ToString
                        i.Item("publisher_name") = j.Item("publisher_name").ToString
                        i.Item("source") = j.Item("source").ToString
                        i.Item("ecom_discount") = j.Item("ecom_discount").ToString
                        i.Item("other_format") = j.Item("other_format").ToString
                        i.Item("keyword") = j.Item("keyword").ToString
                    Next

                    i.Item("image") = img.Substring(0, 3) + "/" + img.Substring(3, 3) + "/" + img.Substring(6, 3) + "/" + img + ".jpg"
                    i.Item("ebook_format") = format.Substring(0, format.Length - 1)
                Next
            End If
            For Each datarows As DataRow In sql_datatable.Rows
                datarow = datatable.NewRow
                datarow("isbn_13") = datarows.Item("isbn_13").ToString
                datarow("book_title") = datarows.Item("book_title").ToString
                datarow("book_title_search") = datarows.Item("book_title_search").ToString
                datarow("author") = datarows.Item("author").ToString
                datarow("author_search") = datarows.Item("author_search").ToString
                datarow("selling_price") = CDbl(datarows.Item("selling_price"))
                datarow("selling_price_ecomn") = CDbl(datarows.Item("selling_price_ecomn"))
                datarow("ecom_discount") = datarows.Item("ecom_discount").ToString
                datarow("publisher_name") = datarows.Item("publisher_name").ToString
                datarow("source") = datarows.Item("source").ToString
                datarow("image") = datarows.Item("image").ToString
                datarow("book_type") = datarows.Item("book_type").ToString
                datarow("other_format") = datarows.Item("other_format").ToString
                datarow("ebook_format") = datarows.Item("ebook_format").ToString
                datarow("keyword") = datarows.Item("keyword").ToString
                datarow("indexs") = datarows.Item("indexs").ToString
                datatable.Rows.Add(datarow)
            Next
            sql_datatable.Dispose()
            datatable.DefaultView.Sort = "indexs,book_title,selling_price asc"
        End If

        Return datatable
    End Function

    Function book()
        Dim strsql As String = ""
        Dim SqlDb As New SqlDb
        Dim sql_datatable As New DataTable
        Dim sql_datatable2 As New DataTable

        Dim datatable As DataTable = New DataTable("datatable")
        Dim datacolumn As New DataColumn
        Dim datarow As DataRow

        '/////////////////////////////////
        '////////// create column/////////
        datatable.Columns.Add("isbn_13", System.Type.GetType("System.String"))
        datatable.Columns.Add("book_title", System.Type.GetType("System.String"))
        datatable.Columns.Add("book_title_search", System.Type.GetType("System.String"))
        datatable.Columns.Add("author", System.Type.GetType("System.String"))
        datatable.Columns.Add("author_search", System.Type.GetType("System.String"))
        datatable.Columns.Add("selling_price", System.Type.GetType("System.Double"))
        datatable.Columns.Add("selling_price_ecomn", System.Type.GetType("System.Double"))
        datatable.Columns.Add("ecom_discount", System.Type.GetType("System.String"))
        datatable.Columns.Add("publisher_name", System.Type.GetType("System.String"))
        datatable.Columns.Add("source", System.Type.GetType("System.String"))
        datatable.Columns.Add("image", System.Type.GetType("System.String"))
        datatable.Columns.Add("book_type", System.Type.GetType("System.String"))
        datatable.Columns.Add("other_format", System.Type.GetType("System.String"))
        datatable.Columns.Add("ebook_format", System.Type.GetType("System.String"))
        datatable.Columns.Add("keyword", System.Type.GetType("System.String"))
        datatable.Columns.Add("stock", System.Type.GetType("System.String"))
        datatable.Columns.Add("indexs", System.Type.GetType("System.String"))

        strsql &= " SELECT DISTINCT "
        strsql &= " case search.source when 'Asiabooks' then cast(ROUND(convert(numeric(13,2),search.selling),0) as varchar) "
        strsql &= " else cast(ROUND(convert(numeric(18,2),(search.selling * (isnull(search.exchange_rate,0) + "
        strsql &= " ((search.Buffer_Rate/100) * isnull(search.exchange_rate,0))) + "
        strsql &= " search.selling * (isnull(search.exchange_rate,0) + ((search.buffer_rate/100) * "
        strsql &= " isnull(search.exchange_rate,0))) * search.mark_up/100)),0) as varchar) end as selling_price "

        strsql &= " , case search.source when 'Asiabooks' then cast(ROUND(convert(numeric(13,2),search.selling_price_ecom),0) as varchar) "
        strsql &= " else cast(ROUND(convert(numeric(18,2),(search.selling * (isnull(search.exchange_rate,0) + "
        strsql &= " ((search.Buffer_Rate/100) * isnull(search.exchange_rate,0))) + "
        strsql &= " search.selling * (isnull(search.exchange_rate,0) + ((search.buffer_rate/100) * "
        strsql &= " isnull(search.exchange_rate,0))) * search.mark_up/100)),0) as varchar) end as selling_price_ecomn "

        If country.ToUpper = "TH" Then
            strsql &= " , case when (search.other_format is not null) "
            strsql &= " then search.other_format else 'none' end as other_format "
        Else
            strsql &= " , case when (search.other_format is not null and territory.country_code is null) "
            strsql &= " then search.other_format else 'none' end as other_format "
        End If

        strsql &= " , search.isbn_13 , search.book_title , search.book_title_search , search.author "
        strsql &= " , search.author_search , search.publisher_name , search.image , search.source "
        strsql &= " , cast(search.ecom_discount as varchar) as ecom_discount , 'book' as book_type "
        strsql &= " , '0' as ebook_format , search.keyword , search.stock , '1' as indexs "

        strsql &= " FROM "

        strsql &= " (select distinct book.isbn_13 , book.book_title , UPPER(book.book_title) as book_title_search "
        strsql &= " , case book.author when '' then 'NONE' else book.author end as author , UPPER(book.author) as author_search "
        strsql &= " , case book.publisher_name when '' then '-' else book.publisher_name end as publisher_name "
        strsql &= " , convert(numeric(18,2),ecom_discount) as ecom_discount , book.source "
        strsql &= " , convert(numeric(13,2), book.selling_price) as selling , book.image "
        strsql &= " , book.selling_price_ecom , book.price_save , UPPER(book.keyword) as keyword "
        strsql &= " , cast(book.link_isbn as varchar) as other_format , UPPER(left(book.stock_status,1)) as stock "
        strsql &= " , company.buffer_rate , book.discount , currency.exchange_rate , channel.mark_up "

        strsql &= " from tbt_jobber_book_search book with (nolock) "
        strsql &= " , tbm_syst_saleschannel channel with (nolock) "
        strsql &= " , tbm_syst_organizeindent organize with (nolock) "
        strsql &= " , tbm_syst_currency currency with (nolock) "
        strsql &= " , tbm_syst_company company with (nolock) "

        strsql &= " where (book.discount >= channel.from_pub_discount and book.discount <= channel.to_pub_discount) "
        strsql &= " and channel.sales_channel_code = 'INTERNET' "
        strsql &= " and ((book.source = organize.org_indent_code and book.source <> 'Asiabooks') "
        strsql &= " or (book.source <> organize.org_indent_code and book.source = 'Asiabooks')) "
        strsql &= " and organize.currency_code = currency.currency_code "
        strsql &= " and convert(numeric(13,2), book.selling_price) > 0 and book.field3 = '' "
        strsql &= " " + equal_ + " "
        strsql &= " ) as search "

        If country.ToUpper = "TH" Then
            strsql &= " left join (select distinct bookid as ebook_id , isbn_13 "
            strsql &= " from ebook_store where status = 'active' and th = 1) ebook "
            strsql &= " on search.other_format = ebook.isbn_13 "
        Else
            strsql &= " left join (select distinct bookid as ebook_id , isbn_13 "
            strsql &= " from ebook_store where status = 'active') ebook "
            strsql &= " on search.other_format = ebook.isbn_13 "

            strsql &= " left join (select distinct bookid as ebook_id , country_code "
            strsql &= " from " + territory + " where country_code = '" + country + "') as territory "
            strsql &= " on ebook.ebook_id = territory.ebook_id "
        End If

        sql_datatable = SqlDb.GetDataTable(strsql)

        strsql = ""
        strsql &= " SELECT DISTINCT "
        strsql &= " case search.source when 'Asiabooks' then cast(ROUND(convert(numeric(13,2),search.selling),0) as varchar) "
        strsql &= " else cast(ROUND(convert(numeric(18,2),(search.selling * (isnull(search.exchange_rate,0) + "
        strsql &= " ((search.Buffer_Rate/100) * isnull(search.exchange_rate,0))) + "
        strsql &= " search.selling * (isnull(search.exchange_rate,0) + ((search.buffer_rate/100) * "
        strsql &= " isnull(search.exchange_rate,0))) * search.mark_up/100)),0) as varchar) end as selling_price "

        strsql &= " , case search.source when 'Asiabooks' then cast(ROUND(convert(numeric(13,2),search.selling_price_ecom),0) as varchar) "
        strsql &= " else cast(ROUND(convert(numeric(18,2),(search.selling * (isnull(search.exchange_rate,0) + "
        strsql &= " ((search.Buffer_Rate/100) * isnull(search.exchange_rate,0))) + "
        strsql &= " search.selling * (isnull(search.exchange_rate,0) + ((search.buffer_rate/100) * "
        strsql &= " isnull(search.exchange_rate,0))) * search.mark_up/100)),0) as varchar) end as selling_price_ecomn "

        If country.ToUpper = "TH" Then
            strsql &= " , case when (search.other_format is not null) "
            strsql &= " then search.other_format else 'none' end as other_format "
        Else
            strsql &= " , case when (search.other_format is not null and territory.country_code is null) "
            strsql &= " then search.other_format else 'none' end as other_format "
        End If

        strsql &= " , search.isbn_13 , search.book_title , search.book_title_search , search.author "
        strsql &= " , search.author_search , search.publisher_name , search.image , search.source "
        strsql &= " , cast(search.ecom_discount as varchar) as ecom_discount , 'book' as book_type "
        strsql &= " , '0' as ebook_format , search.keyword , search.stock , '2' as indexs "

        strsql &= " FROM "

        strsql &= " (select distinct top(500) book.isbn_13 , book.book_title , UPPER(book.book_title) as book_title_search "
        strsql &= " , case book.author when '' then 'NONE' else book.author end as author , UPPER(book.author) as author_search "
        strsql &= " , case book.publisher_name when '' then '-' else book.publisher_name end as publisher_name "
        strsql &= " , convert(numeric(18,2),ecom_discount) as ecom_discount , book.source "
        strsql &= " , convert(numeric(13,2), book.selling_price) as selling , book.image "
        strsql &= " , book.selling_price_ecom , book.price_save , UPPER(book.keyword) as keyword "
        strsql &= " , cast(book.link_isbn as varchar) as other_format , UPPER(left(book.stock_status,1)) as stock "
        strsql &= " , company.buffer_rate , book.discount , currency.exchange_rate , channel.mark_up "

        strsql &= " from tbt_jobber_book_search book with (nolock) "
        strsql &= " , tbm_syst_saleschannel channel with (nolock) "
        strsql &= " , tbm_syst_organizeindent organize with (nolock) "
        strsql &= " , tbm_syst_currency currency with (nolock) "
        strsql &= " , tbm_syst_company company with (nolock) "

        strsql &= " where (book.discount >= channel.from_pub_discount and book.discount <= channel.to_pub_discount) "
        strsql &= " and channel.sales_channel_code = 'INTERNET' "
        strsql &= " and ((book.source = organize.org_indent_code and book.source <> 'Asiabooks') "
        strsql &= " or (book.source <> organize.org_indent_code and book.source = 'Asiabooks')) "
        strsql &= " and organize.currency_code = currency.currency_code "
        strsql &= " and convert(numeric(13,2), book.selling_price) > 0 and book.field3 = '' "
        strsql &= " " + like_ + " "
        strsql &= " ) as search "

        If country.ToUpper = "TH" Then
            strsql &= " left join (select distinct bookid as ebook_id , isbn_13 "
            strsql &= " from ebook_store where status = 'active' and th = 1) ebook "
            strsql &= " on search.other_format = ebook.isbn_13 "
        Else
            strsql &= " left join (select distinct bookid as ebook_id , isbn_13 "
            strsql &= " from ebook_store where status = 'active') ebook "
            strsql &= " on search.other_format = ebook.isbn_13 "

            strsql &= " left join (select distinct bookid as ebook_id , country_code "
            strsql &= " from " + territory + " where country_code = '" + country + "') as territory "
            strsql &= " on ebook.ebook_id = territory.ebook_id "
        End If

        sql_datatable2 = SqlDb.GetDataTable(strsql)

        For Each row As DataRow In sql_datatable2.Rows
            sql_datatable.ImportRow(row)
            sql_datatable.AcceptChanges()
        Next

        If sql_datatable.Rows.Count > 0 Then
            Dim d1 As New DataTable
            d1 = sql_datatable.Copy
            For Each aaa As DataRow In d1.Select("indexs = '1'")
                Dim isbn As String = aaa.Item("isbn_13").ToString.Trim
                For Each bbb As DataRow In sql_datatable.Select("isbn_13 = " + isbn + "")
                    If bbb.Item("indexs").ToString = "2" Then
                        bbb.Delete()
                        sql_datatable.AcceptChanges()
                    End If
                Next
            Next

            For Each datarows As DataRow In sql_datatable.Rows
                datarow = datatable.NewRow
                datarow("isbn_13") = datarows.Item("isbn_13").ToString
                datarow("book_title") = datarows.Item("book_title").ToString
                datarow("book_title_search") = datarows.Item("book_title_search").ToString
                datarow("author") = datarows.Item("author").ToString
                datarow("author_search") = datarows.Item("author_search").ToString
                datarow("selling_price") = CDbl(datarows.Item("selling_price"))
                datarow("selling_price_ecomn") = CDbl(datarows.Item("selling_price_ecomn"))
                datarow("ecom_discount") = datarows.Item("ecom_discount").ToString
                datarow("publisher_name") = datarows.Item("publisher_name").ToString
                datarow("source") = datarows.Item("source").ToString
                datarow("image") = datarows.Item("image").ToString
                datarow("book_type") = datarows.Item("book_type").ToString
                If Left(datarow("isbn_13").ToString, 3) = "MAG" Then
                    datarow("book_type") = "magazine"
                End If
                datarow("other_format") = datarows.Item("other_format").ToString
                datarow("ebook_format") = datarows.Item("ebook_format").ToString
                datarow("keyword") = datarows.Item("keyword").ToString
                datarow("stock") = datarows.Item("stock").ToString
                datarow("indexs") = datarows.Item("indexs").ToString
                datatable.Rows.Add(datarow)
            Next
            sql_datatable.Dispose()
            datatable.DefaultView.Sort = "indexs,stock,book_title,selling_price asc"
        End If

        Return datatable
    End Function

    Function book_and_ebook()
        Dim strsql As String = ""
        Dim SqlDb As New SqlDb
        Dim sql_datatable As New DataTable
        Dim sql_datatable2 As New DataTable
        Dim sql_datatable3 As New DataTable
        Dim sql_datatable4 As New DataTable

        Dim datatable As DataTable = New DataTable("datatable")
        Dim datacolumn As New DataColumn
        Dim datarow As DataRow

        '/////////////////////////////////
        '////////// create column/////////
        datatable.Columns.Add("isbn_13", System.Type.GetType("System.String"))
        datatable.Columns.Add("book_title", System.Type.GetType("System.String"))
        datatable.Columns.Add("book_title_search", System.Type.GetType("System.String"))
        datatable.Columns.Add("author", System.Type.GetType("System.String"))
        datatable.Columns.Add("author_search", System.Type.GetType("System.String"))
        datatable.Columns.Add("selling_price", System.Type.GetType("System.Double"))
        datatable.Columns.Add("selling_price_ecomn", System.Type.GetType("System.Double"))
        datatable.Columns.Add("ecom_discount", System.Type.GetType("System.String"))
        datatable.Columns.Add("publisher_name", System.Type.GetType("System.String"))
        datatable.Columns.Add("source", System.Type.GetType("System.String"))
        datatable.Columns.Add("image", System.Type.GetType("System.String"))
        datatable.Columns.Add("book_type", System.Type.GetType("System.String"))
        datatable.Columns.Add("other_format", System.Type.GetType("System.String"))
        datatable.Columns.Add("ebook_format", System.Type.GetType("System.String"))
        datatable.Columns.Add("keyword", System.Type.GetType("System.String"))
        datatable.Columns.Add("stock", System.Type.GetType("System.String"))
        datatable.Columns.Add("indexs", System.Type.GetType("System.String"))

        strsql &= " SELECT DISTINCT "
        strsql &= " case search.source when 'Asiabooks' then cast(ROUND(convert(numeric(13,2),search.selling),0) as varchar) "
        strsql &= " else cast(ROUND(convert(numeric(18,2),(search.selling * (isnull(search.exchange_rate,0) + "
        strsql &= " ((search.Buffer_Rate/100) * isnull(search.exchange_rate,0))) + "
        strsql &= " search.selling * (isnull(search.exchange_rate,0) + ((search.buffer_rate/100) * "
        strsql &= " isnull(search.exchange_rate,0))) * search.mark_up/100)),0) as varchar) end as selling_price "

        strsql &= " , case search.source when 'Asiabooks' then cast(ROUND(convert(numeric(13,2),search.selling_price_ecom),0) as varchar) "
        strsql &= " else cast(ROUND(convert(numeric(18,2),(search.selling * (isnull(search.exchange_rate,0) + "
        strsql &= " ((search.Buffer_Rate/100) * isnull(search.exchange_rate,0))) + "
        strsql &= " search.selling * (isnull(search.exchange_rate,0) + ((search.buffer_rate/100) * "
        strsql &= " isnull(search.exchange_rate,0))) * search.mark_up/100)),0) as varchar) end as selling_price_ecomn "

        If country.ToUpper = "TH" Then
            strsql &= " , case when (search.other_format is not null) "
            strsql &= " then search.other_format else 'none' end as other_format "
        Else
            strsql &= " , case when (search.other_format is not null and territory.country_code is null) "
            strsql &= " then search.other_format else 'none' end as other_format "
        End If

        strsql &= " , search.isbn_13 , search.book_title , search.book_title_search , search.author "
        strsql &= " , search.author_search , search.publisher_name , search.image , search.source "
        strsql &= " , cast(search.ecom_discount as varchar) as ecom_discount , 'book' as book_type "
        strsql &= " , '0' as ebook_format , search.keyword , search.stock , '1' as indexs "

        strsql &= " FROM "

        strsql &= " (select distinct book.isbn_13 , book.book_title , UPPER(book.book_title) as book_title_search "
        strsql &= " , case book.author when '' then 'NONE' else book.author end as author , UPPER(book.author) as author_search "
        strsql &= " , case book.publisher_name when '' then '-' else book.publisher_name end as publisher_name "
        strsql &= " , convert(numeric(18,2),ecom_discount) as ecom_discount , book.source "
        strsql &= " , convert(numeric(13,2), book.selling_price) as selling , book.image "
        strsql &= " , book.selling_price_ecom , book.price_save , UPPER(book.keyword) as keyword "
        strsql &= " , cast(book.link_isbn as varchar) as other_format , UPPER(left(book.stock_status,1)) as stock "
        strsql &= " , company.buffer_rate , book.discount , currency.exchange_rate , channel.mark_up "

        strsql &= " from tbt_jobber_book_search book with (nolock) "
        strsql &= " , tbm_syst_saleschannel channel with (nolock) "
        strsql &= " , tbm_syst_organizeindent organize with (nolock) "
        strsql &= " , tbm_syst_currency currency with (nolock) "
        strsql &= " , tbm_syst_company company with (nolock) "

        strsql &= " where (book.discount >= channel.from_pub_discount and book.discount <= channel.to_pub_discount) "
        strsql &= " and channel.sales_channel_code = 'INTERNET' "
        strsql &= " and ((book.source = organize.org_indent_code and book.source <> 'Asiabooks') "
        strsql &= " or (book.source <> organize.org_indent_code and book.source = 'Asiabooks')) "
        strsql &= " and organize.currency_code = currency.currency_code "
        strsql &= " and convert(numeric(13,2), book.selling_price) > 0 and book.field3 = '' "
        strsql &= " " + equal_2 + " "
        strsql &= " ) as search "

        If country.ToUpper = "TH" Then
            strsql &= " left join (select distinct bookid as ebook_id , isbn_13 "
            strsql &= " from ebook_store where status = 'active' and th = 1) ebook "
            strsql &= " on search.other_format = ebook.isbn_13 "
        Else
            strsql &= " left join (select distinct bookid as ebook_id , isbn_13 "
            strsql &= " from ebook_store where status = 'active') ebook "
            strsql &= " on search.other_format = ebook.isbn_13 "

            strsql &= " left join (select distinct bookid as ebook_id , country_code "
            strsql &= " from " + territory + " where country_code = '" + country + "') as territory "
            strsql &= " on ebook.ebook_id = territory.ebook_id "
        End If

        sql_datatable = SqlDb.GetDataTable(strsql)

        strsql = ""
        strsql &= " SELECT DISTINCT "
        strsql &= " '' as selling_price , '' as selling_price_ecomn "

        strsql &= " , '' as other_format "

        strsql &= " , search.isbn_13 , '' as book_title , '' as book_title_search , '' as author , '' as author_search "
        strsql &= " , '' as publisher_name , '' as image , '' as source , '' as ecom_discount , 'ebook' as book_type "
        strsql &= " , '' as ebook_format , '' as keyword , 'A' as stock , '2' as indexs "

        strsql &= " FROM "
        strsql &= " (select cast(ebook.isbn_13 as varchar) as isbn_13 , ebook.bookid as ebook_id "
        strsql &= " , cast(ebook.on_book as varchar) as other_format , ebook.book_cuttitle "
        strsql &= " from ebook_store ebook with (nolock) "
        strsql &= " where ebook.status = 'active' "
        strsql &= " and (convert(numeric(18,2),isnull(ebook.price_org,0)) * convert(numeric(18,2),isnull(ebook.moneytype,0))) > 50 "
        strsql &= " " + equal_ + " "
        If country = "TH" Then
            strsql &= " and ebook.th = 1 "
            strsql &= " ) as search "
        Else
            strsql &= " ) as search "

            strsql &= " left join (select distinct bookid as ebook_id , country_code "
            strsql &= " from " + territory + " where country_code = '" + country + "') as territory "
            strsql &= " on search.ebook_id = territory.ebook_id "

            strsql &= " WHERE territory.country_code is null "
        End If

        sql_datatable2 = SqlDb.GetDataTable(strsql)

        strsql = ""
        strsql &= " SELECT DISTINCT "
        strsql &= " case search.source when 'Asiabooks' then cast(ROUND(convert(numeric(13,2),search.selling),0) as varchar) "
        strsql &= " else cast(ROUND(convert(numeric(18,2),(search.selling * (isnull(search.exchange_rate,0) + "
        strsql &= " ((search.Buffer_Rate/100) * isnull(search.exchange_rate,0))) + "
        strsql &= " search.selling * (isnull(search.exchange_rate,0) + ((search.buffer_rate/100) * "
        strsql &= " isnull(search.exchange_rate,0))) * search.mark_up/100)),0) as varchar) end as selling_price "

        strsql &= " , case search.source when 'Asiabooks' then cast(ROUND(convert(numeric(13,2),search.selling_price_ecom),0) as varchar) "
        strsql &= " else cast(ROUND(convert(numeric(18,2),(search.selling * (isnull(search.exchange_rate,0) + "
        strsql &= " ((search.Buffer_Rate/100) * isnull(search.exchange_rate,0))) + "
        strsql &= " search.selling * (isnull(search.exchange_rate,0) + ((search.buffer_rate/100) * "
        strsql &= " isnull(search.exchange_rate,0))) * search.mark_up/100)),0) as varchar) end as selling_price_ecomn "

        If country.ToUpper = "TH" Then
            strsql &= " , case when (search.other_format is not null) "
            strsql &= " then search.other_format else 'none' end as other_format "
        Else
            strsql &= " , case when (search.other_format is not null and territory.country_code is null) "
            strsql &= " then search.other_format else 'none' end as other_format "
        End If

        strsql &= " , search.isbn_13 , search.book_title , search.book_title_search , search.author "
        strsql &= " , search.author_search , search.publisher_name , search.image , search.source "
        strsql &= " , cast(search.ecom_discount as varchar) as ecom_discount , 'book' as book_type "
        strsql &= " , '0' as ebook_format , search.keyword , search.stock , '3' as indexs "

        strsql &= " FROM "

        strsql &= " (select distinct top(500) book.isbn_13 , book.book_title , UPPER(book.book_title) as book_title_search "
        strsql &= " , case book.author when '' then 'NONE' else book.author end as author , UPPER(book.author) as author_search "
        strsql &= " , case book.publisher_name when '' then '-' else book.publisher_name end as publisher_name "
        strsql &= " , convert(numeric(18,2),ecom_discount) as ecom_discount , book.source "
        strsql &= " , convert(numeric(13,2), book.selling_price) as selling , book.image "
        strsql &= " , book.selling_price_ecom , book.price_save , UPPER(book.keyword) as keyword "
        strsql &= " , cast(book.link_isbn as varchar) as other_format , UPPER(left(book.stock_status,1)) as stock "
        strsql &= " , company.buffer_rate , book.discount , currency.exchange_rate , channel.mark_up "

        strsql &= " from tbt_jobber_book_search book with (nolock) "
        strsql &= " , tbm_syst_saleschannel channel with (nolock) "
        strsql &= " , tbm_syst_organizeindent organize with (nolock) "
        strsql &= " , tbm_syst_currency currency with (nolock) "
        strsql &= " , tbm_syst_company company with (nolock) "

        strsql &= " where (book.discount >= channel.from_pub_discount and book.discount <= channel.to_pub_discount) "
        strsql &= " and channel.sales_channel_code = 'INTERNET' "
        strsql &= " and ((book.source = organize.org_indent_code and book.source <> 'Asiabooks') "
        strsql &= " or (book.source <> organize.org_indent_code and book.source = 'Asiabooks')) "
        strsql &= " and organize.currency_code = currency.currency_code "
        strsql &= " and convert(numeric(13,2), book.selling_price) > 0 and book.field3 = '' "
        strsql &= " " + like_2 + " "
        strsql &= " ) as search "

        If country.ToUpper = "TH" Then
            strsql &= " left join (select distinct bookid as ebook_id , isbn_13 "
            strsql &= " from ebook_store where status = 'active' and th = 1) ebook "
            strsql &= " on search.other_format = ebook.isbn_13 "
        Else
            strsql &= " left join (select distinct bookid as ebook_id , isbn_13 "
            strsql &= " from ebook_store where status = 'active') ebook "
            strsql &= " on search.other_format = ebook.isbn_13 "

            strsql &= " left join (select distinct bookid as ebook_id , country_code "
            strsql &= " from " + territory + " where country_code = '" + country + "') as territory "
            strsql &= " on ebook.ebook_id = territory.ebook_id "
        End If

        sql_datatable3 = SqlDb.GetDataTable(strsql)

        strsql = ""
        strsql &= " SELECT DISTINCT "
        strsql &= " '' as selling_price , '' as selling_price_ecomn "

        strsql &= " , '' as other_format "

        strsql &= " , search.isbn_13 , '' as book_title , '' as book_title_search , '' as author , '' as author_search "
        strsql &= " , '' as publisher_name , '' as image , '' as source , '' as ecom_discount , 'ebook' as book_type "
        strsql &= " , '' as ebook_format , '' as keyword , 'A' as stock , '4' as indexs "

        strsql &= " FROM "
        strsql &= " (select top(500) cast(ebook.isbn_13 as varchar) as isbn_13 , ebook.bookid as ebook_id "
        strsql &= " , cast(ebook.on_book as varchar) as other_format , ebook.book_cuttitle "
        strsql &= " from ebook_store ebook with (nolock) "
        strsql &= " where ebook.status = 'active' "
        strsql &= " and (convert(numeric(18,2),isnull(ebook.price_org,0)) * convert(numeric(18,2),isnull(ebook.moneytype,0))) > 50 "
        strsql &= " " + like_ + " "
        If country = "TH" Then
            strsql &= " and ebook.th = 1 "
            strsql &= " ) as search "
        Else
            strsql &= " ) as search "

            strsql &= " left join (select distinct bookid as ebook_id , country_code "
            strsql &= " from " + territory + " where country_code = '" + country + "') as territory "
            strsql &= " on search.ebook_id = territory.ebook_id "

            strsql &= " WHERE territory.country_code is null "
        End If

        sql_datatable4 = SqlDb.GetDataTable(strsql)

        For Each row As DataRow In sql_datatable2.Rows
            sql_datatable.ImportRow(row)
            sql_datatable.AcceptChanges()
        Next
        For Each row As DataRow In sql_datatable3.Rows
            sql_datatable.ImportRow(row)
            sql_datatable.AcceptChanges()
        Next
        For Each row As DataRow In sql_datatable4.Rows
            sql_datatable.ImportRow(row)
            sql_datatable.AcceptChanges()
        Next

        Dim strings As String = ""
        If sql_datatable.Rows.Count > 0 Then

            Dim d1 As New DataTable
            d1 = sql_datatable.Copy
            For Each aaa As DataRow In d1.Select("indexs = '1'")
                Dim isbn As String = aaa.Item("isbn_13").ToString.Trim
                For Each bbb As DataRow In sql_datatable.Select("isbn_13 = " + isbn + "")
                    If bbb.Item("indexs").ToString = "3" Then
                        bbb.Delete()
                        sql_datatable.AcceptChanges()
                    End If
                Next
            Next

            d1 = New DataTable
            d1 = sql_datatable.Copy
            For Each aaa As DataRow In d1.Select("indexs = '2'")
                Dim isbn As String = aaa.Item("isbn_13").ToString.Trim
                For Each bbb As DataRow In sql_datatable.Select("isbn_13 = " + isbn + "")
                    If bbb.Item("indexs").ToString = "4" Then
                        bbb.Delete()
                        sql_datatable.AcceptChanges()
                    End If
                Next
            Next

            For Each datarows As DataRow In sql_datatable.Select("book_type = 'ebook'")
                strings &= datarows.Item("isbn_13").ToString + ","
            Next
            If strings.Length > 13 Then
                isbn_13 = strings.Substring(0, strings.Length - 1)
                Dim data_format As New DataTable
                data_format = get_format_ebook()
                For Each i As DataRow In sql_datatable.Select("book_type = 'ebook'")
                    Dim ii As String = i.Item("isbn_13").ToString
                    Dim format As String = ""
                    Dim img As String = ""
                    For Each j As DataRow In data_format.Select("isbn_13 = " + ii + "")
                        format &= j.Item("ebook_format").ToString + ","
                        img = j.Item("image").ToString
                        i.Item("selling_price") = CDbl(j.Item("selling_price"))
                        i.Item("selling_price_ecomn") = CDbl(j.Item("selling_price_ecomn"))
                        i.Item("book_title") = j.Item("book_title").ToString
                        i.Item("book_title_search") = j.Item("book_title_search").ToString
                        i.Item("author") = j.Item("author").ToString
                        i.Item("author_search") = j.Item("author_search").ToString
                        i.Item("publisher_name") = j.Item("publisher_name").ToString
                        i.Item("source") = j.Item("source").ToString
                        i.Item("ecom_discount") = j.Item("ecom_discount").ToString
                        i.Item("other_format") = j.Item("other_format").ToString
                        i.Item("keyword") = j.Item("keyword").ToString
                    Next
                    i.Item("image") = img.Substring(0, 3) + "/" + img.Substring(3, 3) + "/" + img.Substring(6, 3) + "/" + img + ".jpg"
                    i.Item("ebook_format") = format.Substring(0, format.Length - 1)
                Next
            End If
            For Each datarows As DataRow In sql_datatable.Rows
                datarow = datatable.NewRow
                datarow("isbn_13") = datarows.Item("isbn_13").ToString
                datarow("book_title") = datarows.Item("book_title").ToString
                datarow("book_title_search") = datarows.Item("book_title_search").ToString
                datarow("author") = datarows.Item("author").ToString
                datarow("author_search") = datarows.Item("author_search").ToString
                datarow("selling_price") = CDbl(datarows.Item("selling_price"))
                datarow("selling_price_ecomn") = CDbl(datarows.Item("selling_price_ecomn"))
                datarow("ecom_discount") = datarows.Item("ecom_discount").ToString
                datarow("publisher_name") = datarows.Item("publisher_name").ToString
                datarow("source") = datarows.Item("source").ToString
                datarow("image") = datarows.Item("image").ToString
                datarow("book_type") = datarows.Item("book_type").ToString
                If Left(datarow("isbn_13").ToString, 3) = "MAG" Then
                    datarow("book_type") = "magazine"
                End If
                datarow("other_format") = datarows.Item("other_format").ToString
                datarow("ebook_format") = datarows.Item("ebook_format").ToString
                datarow("keyword") = datarows.Item("keyword").ToString
                datarow("stock") = datarows.Item("stock").ToString
                datarow("indexs") = datarows.Item("indexs").ToString
                datatable.Rows.Add(datarow)
            Next
            sql_datatable.Dispose()
            datatable.DefaultView.Sort = "indexs,stock,book_title,selling_price asc"
        End If

        Return datatable
    End Function

    Function get_format_ebook()
        Dim strsql As String = ""
        Dim SqlDb As New SqlDb
        Dim datatable As New DataTable

        strsql &= " SELECT "
        strsql &= " case search.source when 'Asiabooks' then ROUND(convert(numeric(18,4),search.selling),0) "
        strsql &= " else ROUND(convert(numeric(18,4),(search.selling * isnull(search.exchange_rate,0))),0) "
        strsql &= " end as selling_price "

        strsql &= " , case search.source when 'Asiabooks' then ROUND(convert(numeric(18,4),search.selling),0) "
        strsql &= " else ROUND(convert(numeric(18,4),(search.selling * isnull(search.exchange_rate,0))) - "
        strsql &= " convert(numeric(18,4),(search.selling * isnull(search.exchange_rate,0) * (search.ecom_discount)) / 100),0) "
        strsql &= " end as selling_price_ecomn "

        strsql &= " , case when search.other_format is null "
        strsql &= " then 'none' else search.other_format end as other_format "

        strsql &= " , search.isbn_13 , search.book_title , search.book_title_search , search.author , search.author_search , search.publisher_name "
        strsql &= " , search.image , search.source , search.ecom_discount , search.format_type as ebook_format , search.keyword "

        strsql &= " FROM "
        strsql &= " (select ebook.bookid as ebook_id , ebook.isbn_13 , ebook.book_title , UPPER(ebook.book_title) as book_title_search "
        strsql &= " , case ebook.author when '' then '-' else ebook.author end as author , case ebook.author when '' then '-' else UPPER(ebook.author) end as author_search"
        strsql &= " , case ebook.publisher_name when '' then '-' else ebook.publisher_name end as publisher_name "
        strsql &= " , convert(numeric(18,4) , ebook.price_org) as selling , ebook.isbn_10 as image , cast(ebook.on_book as varchar) as other_format "
        strsql &= " , ebook.supplier_code as source , isnull(ebook.discount_sp,0) as ecom_discount , currency.exchange_rate "
        strsql &= " , cast(ebook.format_type as varchar) as format_type , UPPER(ebook.keyword) as keyword "

        strsql &= " from ebook_store ebook with (nolock) "
        strsql &= " , tbm_syst_organizeindent organize with (nolock) "
        strsql &= " , tbm_syst_currency currency with (nolock) "

        strsql &= " where ebook.status = 'active' and (convert(numeric(18,2),isnull(ebook.price_org,0)) * convert(numeric(18,2),isnull(ebook.moneytype,0))) > 50 "
        strsql &= " and ebook.supplier_code = organize.org_indent_code and organize.currency_code = currency.currency_code "
        strsql &= " and isbn_13 in (" + isbn_13 + ") "
        If country = "TH" Then
            strsql &= " and ebook.th = 1 "
            strsql &= " ) as search "
        Else
            strsql &= " ) as search "

            strsql &= " left join (select distinct bookid as ebook_id , country_code "
            strsql &= " from " + territory + " where country_code = '" + country + "' and isbn_13 in (" + isbn_13 + ")) as territory "
            strsql &= " on search.ebook_id = territory.ebook_id "
            strsql &= " WHERE territory.country_code is null "
        End If

        Try
            datatable = SqlDb.GetDataTable(strsql)
        Catch ex As Exception
            Throw (New Exception("Get Format Error :" + ex.Message))
        End Try
        datatable.DefaultView.Sort = "other_format desc"
        Return datatable
    End Function

    Function author_search()
        Dim strsql As String = ""
        Dim SqlDb As New SqlDb
        Dim sql_datatable As New DataTable
        Dim sql_datatable2 As New DataTable

        Dim datatable As DataTable = New DataTable("datatable")
        Dim datacolumn As New DataColumn
        Dim datarow As DataRow

        '/////////////////////////////////
        '////////// create column/////////
        datatable.Columns.Add("isbn_13", System.Type.GetType("System.String"))
        datatable.Columns.Add("book_title", System.Type.GetType("System.String"))
        datatable.Columns.Add("book_title_search", System.Type.GetType("System.String"))
        datatable.Columns.Add("author", System.Type.GetType("System.String"))
        datatable.Columns.Add("author_search", System.Type.GetType("System.String"))
        datatable.Columns.Add("selling_price", System.Type.GetType("System.Double"))
        datatable.Columns.Add("selling_price_ecomn", System.Type.GetType("System.Double"))
        datatable.Columns.Add("ecom_discount", System.Type.GetType("System.String"))
        datatable.Columns.Add("publisher_name", System.Type.GetType("System.String"))
        datatable.Columns.Add("source", System.Type.GetType("System.String"))
        datatable.Columns.Add("image", System.Type.GetType("System.String"))
        datatable.Columns.Add("book_type", System.Type.GetType("System.String"))
        datatable.Columns.Add("other_format", System.Type.GetType("System.String"))
        datatable.Columns.Add("ebook_format", System.Type.GetType("System.String"))
        datatable.Columns.Add("keyword", System.Type.GetType("System.String"))
        datatable.Columns.Add("stock", System.Type.GetType("System.String"))
        datatable.Columns.Add("indexs", System.Type.GetType("System.String"))

        strsql &= " SELECT DISTINCT "
        strsql &= " case search.source when 'Asiabooks' then cast(ROUND(convert(numeric(13,2),search.selling),0) as varchar) "
        strsql &= " else cast(ROUND(convert(numeric(18,2),(search.selling * (isnull(search.exchange_rate,0) + "
        strsql &= " ((search.Buffer_Rate/100) * isnull(search.exchange_rate,0))) + "
        strsql &= " search.selling * (isnull(search.exchange_rate,0) + ((search.buffer_rate/100) * "
        strsql &= " isnull(search.exchange_rate,0))) * search.mark_up/100)),0) as varchar) end as selling_price "

        strsql &= " , case search.source when 'Asiabooks' then cast(ROUND(convert(numeric(13,2),search.selling_price_ecom),0) as varchar) "
        strsql &= " else cast(ROUND(convert(numeric(18,2),(search.selling * (isnull(search.exchange_rate,0) + "
        strsql &= " ((search.Buffer_Rate/100) * isnull(search.exchange_rate,0))) + "
        strsql &= " search.selling * (isnull(search.exchange_rate,0) + ((search.buffer_rate/100) * "
        strsql &= " isnull(search.exchange_rate,0))) * search.mark_up/100)),0) as varchar) end as selling_price_ecomn "

        If country.ToUpper = "TH" Then
            strsql &= " , case when (search.other_format is not null) "
            strsql &= " then search.other_format else 'none' end as other_format "
        Else
            strsql &= " , case when (search.other_format is not null and territory.country_code is null) "
            strsql &= " then search.other_format else 'none' end as other_format "
        End If

        strsql &= " , search.isbn_13 , search.book_title , search.book_title_search , search.author "
        strsql &= " , search.author_search , search.publisher_name , search.image , search.source "
        strsql &= " , cast(search.ecom_discount as varchar) as ecom_discount , 'book' as book_type "
        strsql &= " , '0' as ebook_format , search.keyword , search.stock , '1' as indexs "

        strsql &= " FROM "

        strsql &= " (select distinct top(1000) book.isbn_13 , book.book_title , UPPER(book.book_title) as book_title_search "
        strsql &= " , case book.author when '' then 'NONE' else book.author end as author , UPPER(book.author) as author_search "
        strsql &= " , case book.publisher_name when '' then '-' else book.publisher_name end as publisher_name "
        strsql &= " , convert(numeric(18,2),ecom_discount) as ecom_discount , book.source "
        strsql &= " , convert(numeric(13,2), book.selling_price) as selling , book.image "
        strsql &= " , book.selling_price_ecom , book.price_save , UPPER(book.keyword) as keyword "
        strsql &= " , cast(book.link_isbn as varchar) as other_format , UPPER(left(book.stock_status,1)) as stock "
        strsql &= " , company.buffer_rate , book.discount , currency.exchange_rate , channel.mark_up "

        strsql &= " from tbt_jobber_book_search book with (nolock) "
        strsql &= " , tbm_syst_saleschannel channel with (nolock) "
        strsql &= " , tbm_syst_organizeindent organize with (nolock) "
        strsql &= " , tbm_syst_currency currency with (nolock) "
        strsql &= " , tbm_syst_company company with (nolock) "

        strsql &= " where (book.discount >= channel.from_pub_discount and book.discount <= channel.to_pub_discount) "
        strsql &= " and channel.sales_channel_code = 'INTERNET' "
        strsql &= " and ((book.source = organize.org_indent_code and book.source <> 'Asiabooks') "
        strsql &= " or (book.source <> organize.org_indent_code and book.source = 'Asiabooks')) "
        strsql &= " and organize.currency_code = currency.currency_code "
        strsql &= " and convert(numeric(13,2), book.selling_price) > 0 and book.field3 = '' "
        strsql &= " and book.author = '" + keyword.ToString.ToUpper.Replace("'S", "").Replace("'", "") + "' "
        strsql &= " ) as search "

        If country.ToUpper = "TH" Then
            strsql &= " left join (select distinct bookid as ebook_id , isbn_13 "
            strsql &= " from ebook_store where status = 'active' and th = 1) ebook "
            strsql &= " on search.other_format = ebook.isbn_13 "
        Else
            strsql &= " left join (select distinct bookid as ebook_id , isbn_13 "
            strsql &= " from ebook_store where status = 'active') ebook "
            strsql &= " on search.other_format = ebook.isbn_13 "

            strsql &= " left join (select distinct bookid as ebook_id , country_code "
            strsql &= " from " + territory + " where country_code = '" + country + "') as territory "
            strsql &= " on ebook.ebook_id = territory.ebook_id "
        End If

        sql_datatable = SqlDb.GetDataTable(strsql)

        strsql = ""
        strsql &= " SELECT DISTINCT "
        strsql &= " '' as selling_price , '' as selling_price_ecomn "

        strsql &= " , '' as other_format "

        strsql &= " , search.isbn_13 , '' as book_title , '' as book_title_search , '' as author , '' as author_search "
        strsql &= " , '' as publisher_name , '' as image , '' as source , '' as ecom_discount , 'ebook' as book_type "
        strsql &= " , '' as ebook_format , '' as keyword , 'A' as stock , '2' as indexs "

        strsql &= " FROM "
        strsql &= " (select top(1000) cast(ebook.isbn_13 as varchar) as isbn_13 , ebook.bookid as ebook_id "
        strsql &= " , cast(ebook.on_book as varchar) as other_format , ebook.book_cuttitle "
        strsql &= " from ebook_store ebook with (nolock) "
        strsql &= " where ebook.status = 'active' "
        strsql &= " and (convert(numeric(18,2),isnull(ebook.price_org,0)) * convert(numeric(18,2),isnull(ebook.moneytype,0))) > 50 "
        strsql &= " and ebook.author = '" + keyword.ToString.ToUpper.Replace("'S", "").Replace("'", "") + "' "
        If country = "TH" Then
            strsql &= " and ebook.th = 1 "
            strsql &= " ) as search "
        Else
            strsql &= " ) as search "

            strsql &= " left join (select distinct isbn_13 , country_code "
            strsql &= " from " + territory + " where country_code = '" + country + "') as territory "
            strsql &= " on search.isbn_13 = territory.isbn_13 "

            strsql &= " WHERE territory.country_code is null "
        End If

        sql_datatable2 = SqlDb.GetDataTable(strsql)
        For Each row As DataRow In sql_datatable2.Rows
            sql_datatable.ImportRow(row)
            sql_datatable.AcceptChanges()
        Next

        Dim strings As String = ""
        If sql_datatable.Rows.Count > 0 Then

            For Each datarows As DataRow In sql_datatable.Select("book_type = 'ebook'")
                strings &= datarows.Item("isbn_13").ToString + ","
            Next
            If strings.Length > 13 Then
                isbn_13 = strings.Substring(0, strings.Length - 1)
                Dim data_format As New DataTable
                data_format = get_format_ebook()
                For Each i As DataRow In sql_datatable.Select("book_type = 'ebook'")
                    Dim ii As String = i.Item("isbn_13").ToString
                    Dim format As String = ""
                    Dim img As String = ""
                    For Each j As DataRow In data_format.Select("isbn_13 = " + ii + "")
                        format &= j.Item("ebook_format").ToString + ","
                        img = j.Item("image").ToString
                        i.Item("selling_price") = CDbl(j.Item("selling_price"))
                        i.Item("selling_price_ecomn") = CDbl(j.Item("selling_price_ecomn"))
                        i.Item("book_title") = j.Item("book_title").ToString
                        i.Item("book_title_search") = j.Item("book_title_search").ToString
                        i.Item("author") = j.Item("author").ToString
                        i.Item("author_search") = j.Item("author_search").ToString
                        i.Item("publisher_name") = j.Item("publisher_name").ToString
                        i.Item("source") = j.Item("source").ToString
                        i.Item("ecom_discount") = j.Item("ecom_discount").ToString
                        i.Item("other_format") = j.Item("other_format").ToString
                        i.Item("keyword") = j.Item("keyword").ToString
                    Next
                    If img = "" Then
                        Dim aa As String = img
                    End If
                    i.Item("image") = img.Substring(0, 3) + "/" + img.Substring(3, 3) + "/" + img.Substring(6, 3) + "/" + img + ".jpg"
                    i.Item("ebook_format") = format.Substring(0, format.Length - 1)
                Next
            End If
            For Each datarows As DataRow In sql_datatable.Rows
                datarow = datatable.NewRow
                datarow("isbn_13") = datarows.Item("isbn_13").ToString
                datarow("book_title") = datarows.Item("book_title").ToString
                datarow("book_title_search") = datarows.Item("book_title_search").ToString
                datarow("author") = datarows.Item("author").ToString
                datarow("author_search") = datarows.Item("author_search").ToString
                datarow("selling_price") = CDbl(datarows.Item("selling_price"))
                datarow("selling_price_ecomn") = CDbl(datarows.Item("selling_price_ecomn"))
                datarow("ecom_discount") = datarows.Item("ecom_discount").ToString
                datarow("publisher_name") = datarows.Item("publisher_name").ToString
                datarow("source") = datarows.Item("source").ToString
                datarow("image") = datarows.Item("image").ToString
                datarow("book_type") = datarows.Item("book_type").ToString
                If Left(datarow("isbn_13").ToString, 3) = "MAG" Then
                    datarow("book_type") = "magazine"
                End If
                datarow("other_format") = datarows.Item("other_format").ToString
                datarow("ebook_format") = datarows.Item("ebook_format").ToString
                datarow("keyword") = datarows.Item("keyword").ToString
                datarow("stock") = datarows.Item("stock").ToString
                datarow("indexs") = datarows.Item("indexs").ToString
                datatable.Rows.Add(datarow)
            Next
            sql_datatable.Dispose()
            datatable.DefaultView.Sort = "indexs,stock,book_title,selling_price asc"
        End If

        Return datatable
    End Function
End Class