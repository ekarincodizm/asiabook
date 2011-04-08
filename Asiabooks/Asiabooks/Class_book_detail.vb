Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.Configuration
Public Class Class_book_detail
    Public message As String
    Public In_Branch_Number As Integer
    Public Other_Branch_Number As Integer
    Public Jobber_Number As Integer
    Public dr_in_branch As DataRow
    Public dr_other_branch As DataRow

    Public amount_Branch As Double
    Public amount_Other_Branch As Double
    Public amount_Jobber As Double

    Public sales_channel As String

    '/////////promptnow/////////
    Public amount_ebook As Double
    Public discount As Double
    Public country As String
    Public From_ebook As String
    Public original_total As String
    Public percent_discount As String
    Public alert As String
    Public ebook_isbn As String
    Public ebook_format As String
    Public territory As String
    Public dt_ebook As DataTable
    Public dt_ebook_detail As DataTable
    Public dt_ebook_shopping As DataTable
    Public dt_Old_ebook As DataTable    
    '///////promptnow end///////

    Public keyword_1 As String
    Public keyword_Qty As Integer
    Public keyword_Branch As String

    Public ID As Integer
    Public image As String
    Public Book_Title As String
    Public isbn_13 As String
    Public Author As String
    Public Publisher_name As String
    Public Asia_Books_category As String    '  Subject_Name
    Public Language As String               '  Language_Name
    Public Size As String
    Public Weight As Double
    Public binding_description As String
    Public Page_qty As Integer
    Public Publication_Date As String
    Public Copyrights_Date As String        ' Publication_Date
    Public Available_status As String       ' Stock_status
    Public Selling_Price As Double
    Public Synopsis As String               ' Synopsis
    Public AB_ERP_information As String
    Public last_BR_Date As String
    Public On_Order_Qty_Remark As String
    Public dt_book_detail As DataTable

    Public dt_book_In_Branch As DataTable
    Public dt_book_Other_Branch As DataTable
    Public dt_book_jobber As DataTable

    Public dt_Old_book_In_Branch As DataTable
    Public dt_Old_book_Other_Branch As DataTable
    Public dt_Old_book_jobber As DataTable
    Public dt_New_book_In_Branch As DataTable
    Public dt_New_book_Other_Branch As DataTable
    Public dt_New_book_jobber As DataTable

    Public input_No As String
    Public input_Book_Title As String
    Public input_ISBN_13 As String
    Public input_Selling_Price As String
    Public input_Lead_Time As String
    Public input_Weight As String
    Public input_Quantity As String
    Public input_Amount As String
    'Public output_sumqty As String
    Dim dt_trn_In_Branch As DataTable = New DataTable("dt_trn_In_Branch")
    Dim dt_trn_Other_Branch As DataTable = New DataTable("dt_trn_Other_Branch")
    Dim dt_trn_Jobber As DataTable = New DataTable("dt_trn_Jobber")
    'Public dt_trn_sum_Qty As DataTable = New DataTable("dt_trn_sum_Qty")

    Public Exchange_Rate As String
    Public Status As String
    Public input_qtyAB As String
    Public input_qtyIndent As String
    Public Jobber_Status As String

    '/////////promptnow/////////
    Property _territory()
        Get
            Return territory
        End Get
        Set(ByVal value)
            territory = value
        End Set
    End Property
    Property _percent_discount()
        Get
            Return percent_discount
        End Get
        Set(ByVal value)
            percent_discount = value
        End Set
    End Property
    Property _ebook_isbn()
        Get
            Return ebook_isbn
        End Get
        Set(ByVal value)
            ebook_isbn = value
        End Set
    End Property
    Property _ebook_format()
        Get
            Return ebook_format
        End Get
        Set(ByVal value)
            ebook_format = value
        End Set
    End Property
    Property _alert()
        Get
            Return alert
        End Get
        Set(ByVal value)
            alert = value
        End Set
    End Property
    Property _original_total()
        Get
            Return original_total
        End Get
        Set(ByVal value)
            original_total = value
        End Set
    End Property

    Property _From_ebook()
        Get
            Return From_ebook
        End Get
        Set(ByVal value)
            From_ebook = From_ebook
        End Set
    End Property
    Property _country()
        Get
            Return country
        End Get
        Set(ByVal value)
            country = country
        End Set
    End Property
    Property _discount()
        Get
            Return discount
        End Get
        Set(ByVal value)
            discount = discount
        End Set
    End Property
    '///////promptnow end///////

    Property _Jobber_Status()
        Get
            Return Jobber_Status
        End Get
        Set(ByVal value)
            Status = Jobber_Status
        End Set
    End Property
    Property _Status()
        Get
            Return Status
        End Get
        Set(ByVal value)
            Status = value
        End Set
    End Property

    Property _Exchange_Rate()
        Get
            Return Exchange_Rate
        End Get
        Set(ByVal value)
            Exchange_Rate = value
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
    Property _keyword_1()
        Get
            Return keyword_1
        End Get
        Set(ByVal value)
            keyword_1 = value
        End Set
    End Property
    Property _keyword_Qty()
        Get
            Return keyword_Qty
        End Get
        Set(ByVal value)
            keyword_Qty = value
        End Set
    End Property
    Property _keyword_Branch()
        Get
            Return keyword_Branch
        End Get
        Set(ByVal value)
            keyword_Branch = value
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
    Property _isbn_13()
        Get
            Return isbn_13
        End Get
        Set(ByVal value)
            isbn_13 = value
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
    Property _Publisher_name()
        Get
            Return Publisher_name
        End Get
        Set(ByVal value)
            Publisher_name = value
        End Set
    End Property
    Property _Asia_Books_category()
        Get
            Return Asia_Books_category
        End Get
        Set(ByVal value)
            Asia_Books_category = value
        End Set
    End Property
    Property _Language()
        Get
            Return Language
        End Get
        Set(ByVal value)
            Language = value
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
    Property _Publication_Date()
        Get
            Return Publication_Date
        End Get
        Set(ByVal value)
            Publication_Date = value
        End Set
    End Property
    Property _Copyrights_Date()
        Get
            Return Copyrights_Date
        End Get
        Set(ByVal value)
            Copyrights_Date = value
        End Set
    End Property
    Property _Available_status()
        Get
            Return Available_status
        End Get
        Set(ByVal value)
            Available_status = value
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
    Property _Synopsis()
        Get
            Return Synopsis
        End Get
        Set(ByVal value)
            Synopsis = value
        End Set
    End Property
    Property _AB_ERP_information()
        Get
            Return AB_ERP_information
        End Get
        Set(ByVal value)
            AB_ERP_information = value
        End Set
    End Property
    Property _last_BR_Date()
        Get
            Return last_BR_Date
        End Get
        Set(ByVal value)
            last_BR_Date = value
        End Set
    End Property
    Property _On_Order_Qty_Remark()
        Get
            Return On_Order_Qty_Remark
        End Get
        Set(ByVal value)
            On_Order_Qty_Remark = value
        End Set
    End Property

    Property _dt_Old_book_In_Branch()
        Get
            Return dt_Old_book_In_Branch
        End Get
        Set(ByVal value)
            dt_Old_book_In_Branch = value
        End Set
    End Property
    Property _dt_Old_book_Other_Branch()
        Get
            Return dt_Old_book_Other_Branch
        End Get
        Set(ByVal value)
            dt_Old_book_Other_Branch = value
        End Set
    End Property
    Property _dt_Old_book_jobber()
        Get
            Return dt_Old_book_jobber
        End Get
        Set(ByVal value)
            dt_Old_book_jobber = value
        End Set
    End Property

    Property _input_No()
        Get
            Return input_No
        End Get
        Set(ByVal value)
            input_No = value
        End Set
    End Property
    Property _input_Book_Title()
        Get
            Return input_Book_Title
        End Get
        Set(ByVal value)
            input_Book_Title = value
        End Set
    End Property
    Property _input_ISBN_13()
        Get
            Return input_ISBN_13
        End Get
        Set(ByVal value)
            input_ISBN_13 = value
        End Set
    End Property
    Property _input_Selling_Price()
        Get
            Return input_Selling_Price
        End Get
        Set(ByVal value)
            input_Selling_Price = value
        End Set
    End Property
    Property _input_Lead_Time()
        Get
            Return input_Lead_Time
        End Get
        Set(ByVal value)
            input_Lead_Time = value
        End Set
    End Property
    Property _input_Weight()
        Get
            Return input_Weight
        End Get
        Set(ByVal value)
            input_Weight = value
        End Set
    End Property
    Property _input_Quantity()
        Get
            Return input_Quantity
        End Get
        Set(ByVal value)
            input_Quantity = value
        End Set
    End Property
    Property _input_Amount()
        Get
            Return input_Amount
        End Get
        Set(ByVal value)
            input_Amount = value
        End Set
    End Property
    Function callUsd(ByVal bath As Double)
        Dim sqlDb As New SqlDb
        Exchange_Rate = sqlDb.GetDataTable("SELECT Exchange_Rate_Internet FROM tbm_syst_currency WHERE Currency_Code = 'USD'").Rows(0)(0).ToString
        Return (bath / Convert.ToDouble(Exchange_Rate)).ToString("#,###,##0.00")
    End Function
    Function callUsd(ByVal strfile As String, ByVal bath As Double)
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("SystCurrency") _
                        Where c.Element("currency_code") = "USD" _
                        Select currency_code = c.Element("currency_code").Value, _
                        Exchange_Rate = c.Element("exchange_rate_internet").Value

            Return (bath / Convert.ToDouble(Items.First.Exchange_Rate.ToString)).ToString("#,###,##0.00")
        Catch ex As Exception
            Throw New Exception("Top1_ComingSoon_Desc : " & ex.Message.ToString)
            Return ""
        Finally
            xmlDoc = Nothing
        End Try
    End Function

    Function _dt_book_detail()

        'Language
        Dim condition As String = ""
        Dim SqlDb As SqlDb = New SqlDb
        Dim SqlStr As String = ""
        SqlStr &= "     select distinct top(1) tbt_jobber_book_search.ISBN_13, isnull(tbt_jobber_book_search.book_type,0) as book_format, tbt_jobber_book_search.Book_Title,Publication_Date "
        SqlStr &= "     ,case  when (isnull(tbt_jobber_book_search.book_type,0) = 0) then tbt_jobber_book_search.link_isbn "
        SqlStr &= "     else tbt_jobber_book_search.ISBN_13 end as on_ebook "
        SqlStr &= "		,case when (tbt_jobber_book_search.Author='' or tbt_jobber_book_search.Author ='NONE') "
        SqlStr &= "		then '-' else tbt_jobber_book_search.Author end  as Author"
        SqlStr &= "		,tbt_jobber_book_search.image"
        SqlStr &= "	 	,tbt_jobber_book_search.Price_save "
        SqlStr &= "		,tbt_jobber_book_search.selling_price_eCom"
        SqlStr &= "	 	,tbt_jobber_book_search.eCom_Discount"
        SqlStr &= "	 	,isnull(tbt_jobber_book_search.[Item Disc_ Group],'') as [Item Disc_ Group]"
        SqlStr &= "		,case when tbt_jobber_book_search.Publisher_name='' then '-' "
        SqlStr &= "		else tbt_jobber_book_search.Publisher_name end as Publisher_name,tbt_jobber_book_search.[Size]"
        SqlStr &= "		,convert(numeric(13,2),tbt_jobber_book_search.Weight) as Weight"
        SqlStr &= "		,tbt_jobber_book_search.binding_description"
        SqlStr &= "		,case when convert(varchar(10),tbt_jobber_book_search.Page_qty)='0' THEN '-' "
        SqlStr &= "		else convert(varchar(10),tbt_jobber_book_search.Page_qty)end as Page_qty"
        SqlStr &= "     ,case when tbt_jobber_book_search.Language_Name='' then '-'"
        SqlStr &= "		else tbt_jobber_book_search.Language_Name end as Language"
        SqlStr &= "		,case when tbt_jobber_book_search.Subject_Name='' then '-'"
        SqlStr &= "		else tbt_jobber_book_search.Subject_Name end as Subject_Name"
        SqlStr &= "		,case when tbt_jobber_book_search.Stock_status='' then '-'"
        SqlStr &= "		else tbt_jobber_book_search.Stock_status end as stock_status"
        SqlStr &= "		,case when right(tbt_jobber_book_search.Publication_Date,4)='0000' OR source = 'Asiabooks' then '-'"
        'SqlStr &= "		,case when right(tbt_jobber_book_search.Publication_Date,4)='0000' then '-'"
        SqlStr &= "		else right(tbt_jobber_book_search.Publication_Date,4)  end as Copyrights_Date"
        'SqlStr &= "		,case source when 'Asiabooks' then convert(numeric(13,0),tbt_jobber_book_search.Selling_Price) else"
        'SqlStr &= "		convert(numeric(18,0),(tbt_jobber_book_search.Selling_Price*(isnull(tbt_jobber_book_search.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbt_jobber_book_search.field1,0)))"
        'SqlStr &= "		+tbt_jobber_book_search.Selling_Price*(isnull(tbt_jobber_book_search.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbt_jobber_book_search.field1,0)))"
        'SqlStr &= "			*Mark_UP/100)) end as Selling_price"
        SqlStr &= "		,case source when 'Asiabooks' then convert(numeric(13,0),tbt_jobber_book_search.Selling_Price) else "
        SqlStr &= "		convert(numeric(18,2),(tbt_jobber_book_search.Selling_Price*(isnull(CR.exchange_rate,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(CR.exchange_rate,0))) "
        SqlStr &= "		+tbt_jobber_book_search.Selling_Price*(isnull(CR.exchange_rate,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(CR.exchange_rate,0))) *Mark_UP/100)) end as Selling_Price"

        SqlStr &= "     ,'0' as OrdStt,'' as To_Org_AB_code,isnull(discount,0)as discount,short_title"
        SqlStr &= "     ,source, case convert(varchar(1200),Synopsis) WHEN '' THEN '-' ELSE Synopsis end AS Synopsis"
        SqlStr &= "	    ,case when tbm_asbkeo_bookab.Book_Type is null or tbm_asbkeo_bookab.Book_Type='' then '-' else tbm_asbkeo_bookab.Book_Type end as Book_Type"
        SqlStr &= "     ,case source when 'Asiabooks' then CASE WHEN convert(varchar,tbm_asbkeo_bookab.Maintenance_Date,103) = '01/01/1900' OR tbm_asbkeo_bookab.Maintenance_Date = '' THEN '-' ELSE convert(varchar,tbm_asbkeo_bookab.Maintenance_Date,103) END else '-' end AS Maintenance_Date"
        'SqlStr &= "	    ,CASE WHEN convert(varchar,tbm_asbkeo_bookab.Maintenance_Date,101) = '01/01/1900' OR tbm_asbkeo_bookab.Maintenance_Date = '' THEN '-' ELSE convert(varchar,tbm_asbkeo_bookab.Maintenance_Date,101) END AS Maintenance_Date "
        'SqlStr &= "	,case when tbm_asbkeo_bookab.Maintenance_Date is null or tbm_asbkeo_bookab.Maintenance_Date='' then '-' else tbm_asbkeo_bookab.Maintenance_Date end as Maintenance_Date"
        SqlStr &= "	    ,case when tbm_asbkeo_bookab.ETA is null or tbm_asbkeo_bookab.ETA='' then '-' else tbm_asbkeo_bookab.ETA end as ETA"
        SqlStr &= "	    ,case when tbm_asbkeo_bookab.Remark is null or tbm_asbkeo_bookab.Remark='' then '-' else tbm_asbkeo_bookab.Remark end as Remark"
        SqlStr &= "     ,isnull(tbt_jobber_stockab.on_order_qty,0) as on_order_qty "

        '/////////promptnow/////////
        If country.ToUpper = "TH" Then
            SqlStr &= " , case when ebook.isbn_13 is not null "
            SqlStr &= " then cast(ebook.isbn_13 as varchar) else 'not available'  end as other_format "
        Else
            SqlStr &= " , case when (ebook.isbn_13 is not null and territory.country_code is not null) "
            SqlStr &= " then cast(ebook.isbn_13 as varchar) else 'not available'  end as other_format "
        End If
        '///////promptnow end///////

        SqlStr &= " from tbt_jobber_book_search left join  tbm_syst_saleschannel"
        SqlStr &= "		on tbt_jobber_book_search.discount>=tbm_syst_saleschannel.From_Pub_Discount"
        SqlStr &= "		and tbt_jobber_book_search.discount<=tbm_syst_saleschannel.to_Pub_Discount"
        SqlStr &= "		and	tbm_syst_saleschannel.sales_channel_code='" + sales_channel + "'"
        SqlStr &= "	    left join (select isbn_13,Book_Type,convert(varchar,Maintenance_Date,103) as Maintenance_Date,ETA,Remark from tbm_asbkeo_bookab "
        SqlStr &= "     group by isbn_13,Book_Type,Maintenance_Date,ETA,Remark ) as tbm_asbkeo_bookab"
        SqlStr &= "	    on tbt_jobber_book_search.isbn_13=tbm_asbkeo_bookab.isbn_13"
        SqlStr &= "	    left join ( select isbn_13,sum(on_order_qty) as on_order_qty from tbt_jobber_stockab group by isbn_13 ) as tbt_jobber_stockab"
        SqlStr &= "	    on tbt_jobber_book_search.isbn_13=tbt_jobber_stockab.isbn_13"
        '=================== Start New du 30/11/2009
        SqlStr &= "	    left join (select a.Org_indent_code,b.currency_code,b.exchange_rate "
        SqlStr &= "	    from tbm_syst_organizeindent A ,tbm_syst_currency  B"
        SqlStr &= "	    where a.currency_code = b.currency_code) CR"
        SqlStr &= "	    On  tbt_jobber_book_search.source = CR.Org_indent_code "
        '=================== End New du 30/11/2009   

        '/////////promptnow/////////
        If country.ToUpper = "TH" Then
            SqlStr &= " left join (select bookid as ebook_id , isbn_13 "
            SqlStr &= " from ebook_store where (status = 'active' or status is null) and th = 1) as ebook  "
            SqlStr &= " on  tbt_jobber_book_search.link_isbn = ebook.isbn_13 "
        Else
            SqlStr &= " left join (select bookid as ebook_id , isbn_13 "
            SqlStr &= " from ebook_store where (status = 'active' or status is null)) as ebook  "
            SqlStr &= " on  tbt_jobber_book_search.link_isbn = ebook.isbn_13 "

            SqlStr &= " left join (select distinct bookid as ebook_id , country_code "
            SqlStr &= " from " + territory + " where country_code = '" + country + "') as territory "
            SqlStr &= " on ebook.ebook_id = territory.ebook_id "
        End If
        
        '///////promptnow end///////

        SqlStr &= " ,tbm_syst_company Where tbt_jobber_book_search.ISBN_13='" + keyword_1 + "'"
        SqlStr &= "	and tbt_jobber_book_search.selling_price>0"


        dt_book_detail = SqlDb.GetDataTable(SqlStr)
        Return dt_book_detail

    End Function
    Public Sub Recalcuate()
        Dim i, j As Integer
        Dim dt_trn_Book As DataTable = New DataTable("dt_trn_Book")

        Dim dt_trn_sum_Qty As DataTable = New DataTable("dt_trn_sum_Qty")
        Dim dc As DataColumn
        Dim dr_Old As DataRow
        Dim dc_sum As DataColumn

        '/////////promptnow/////////
        Dim dt_cart_ebook As DataTable = New DataTable("dt_cart_ebook")
        Dim datatable_ebook As DataTable = New DataTable("datatable_ebook")
        Dim dr As DataRow

        '/////////////////////////////////
        '////////// create column/////////
        If From_ebook = "ebook" Then

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "No"
            dc.AutoIncrement = False
            dc.Caption = "No"
            dc.ReadOnly = False
            dc.Unique = False
            dt_cart_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "ISBN_13"
            dc.AutoIncrement = False
            dc.Caption = "ISBN_13"
            dc.ReadOnly = False
            dc.Unique = False
            dt_cart_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "eBook_ID"
            dc.AutoIncrement = False
            dc.Caption = "eBook_ID"
            dc.ReadOnly = False
            dc.Unique = False
            dt_cart_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Book_Title"
            dc.AutoIncrement = False
            dc.Caption = "Book_Title"
            dc.ReadOnly = False
            dc.Unique = False
            dt_cart_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Page"
            dc.AutoIncrement = False
            dc.Caption = "Page"
            dc.ReadOnly = False
            dc.Unique = False
            dt_cart_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Double")
            dc.ColumnName = "Selling_Price"
            dc.AutoIncrement = False
            dc.Caption = "Selling_Price"
            dc.ReadOnly = False
            dc.Unique = False
            dt_cart_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Int32")
            dc.ColumnName = "Quantity"
            dc.AutoIncrement = False
            dc.Caption = "Quantity"
            dc.ReadOnly = False
            dc.Unique = False
            dt_cart_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Double")
            dc.ColumnName = "Items_Amount"
            dc.AutoIncrement = False
            dc.Caption = "Items_Amount"
            dc.ReadOnly = False
            dc.Unique = False
            dt_cart_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Supplier"
            dc.AutoIncrement = False
            dc.Caption = "Supplier"
            dc.ReadOnly = False
            dc.Unique = False
            dt_cart_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Exchange"
            dc.AutoIncrement = False
            dc.Caption = "Exchange"
            dc.ReadOnly = False
            dc.Unique = False
            dt_cart_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Exchange_Internet"
            dc.AutoIncrement = False
            dc.Caption = "Exchange_Internet"
            dc.ReadOnly = False
            dc.Unique = False
            dt_cart_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Discount"
            dc.AutoIncrement = False
            dc.Caption = "Discount"
            dc.ReadOnly = False
            dc.Unique = False
            dt_cart_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Format"
            dc.AutoIncrement = False
            dc.Caption = "Format"
            dc.ReadOnly = False
            dc.Unique = False
            dt_cart_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Format_Type"
            dc.AutoIncrement = False
            dc.Caption = "Format_Type"
            dc.ReadOnly = False
            dc.Unique = False
            dt_cart_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Country"
            dc.AutoIncrement = False
            dc.Caption = "Country"
            dc.ReadOnly = False
            dc.Unique = False
            dt_cart_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Size"
            dc.AutoIncrement = False
            dc.Caption = "Size"
            dc.ReadOnly = False
            dc.Unique = False
            dt_cart_ebook.Columns.Add(dc)

            '//////////////////////////////////
            '//////////////////////////////////

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "No"
            dc.AutoIncrement = False
            dc.Caption = "No"
            dc.ReadOnly = False
            dc.Unique = False
            datatable_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "ISBN_13"
            dc.AutoIncrement = False
            dc.Caption = "ISBN_13"
            dc.ReadOnly = False
            dc.Unique = False
            datatable_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "eBook_ID"
            dc.AutoIncrement = False
            dc.Caption = "eBook_ID"
            dc.ReadOnly = False
            dc.Unique = False
            datatable_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Book_Title"
            dc.AutoIncrement = False
            dc.Caption = "Book_Title"
            dc.ReadOnly = False
            dc.Unique = False
            datatable_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Int32")
            dc.ColumnName = "Quantity"
            dc.AutoIncrement = False
            dc.Caption = "Quantity"
            dc.ReadOnly = False
            dc.Unique = False
            datatable_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Double")
            dc.ColumnName = "Selling_Price"
            dc.AutoIncrement = False
            dc.Caption = "Selling_Price"
            dc.ReadOnly = False
            dc.Unique = False
            datatable_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Double")
            dc.ColumnName = "Items_Amount"
            dc.AutoIncrement = False
            dc.Caption = "Items_Amount"
            dc.ReadOnly = False
            dc.Unique = False
            datatable_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Supplier"
            dc.AutoIncrement = False
            dc.Caption = "Supplier"
            dc.ReadOnly = False
            dc.Unique = False
            datatable_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Exchange"
            dc.AutoIncrement = False
            dc.Caption = "Exchange"
            dc.ReadOnly = False
            dc.Unique = False
            datatable_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Exchange_Internet"
            dc.AutoIncrement = False
            dc.Caption = "Exchange_Internet"
            dc.ReadOnly = False
            dc.Unique = False
            datatable_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Discount"
            dc.AutoIncrement = False
            dc.Caption = "Discount"
            dc.ReadOnly = False
            dc.Unique = False
            datatable_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Format"
            dc.AutoIncrement = False
            dc.Caption = "Format"
            dc.ReadOnly = False
            dc.Unique = False
            datatable_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Format_Type"
            dc.AutoIncrement = False
            dc.Caption = "Format_Type"
            dc.ReadOnly = False
            dc.Unique = False
            datatable_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Country"
            dc.AutoIncrement = False
            dc.Caption = "Country"
            dc.ReadOnly = False
            dc.Unique = False
            datatable_ebook.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Size"
            dc.AutoIncrement = False
            dc.Caption = "Size"
            dc.ReadOnly = False
            dc.Unique = False
            datatable_ebook.Columns.Add(dc)

            '//////////////////////////////////
            '//////////////////////////////////

            amount_ebook = 0
            Dim qty As Integer = 0
            '///////////////////////////////////////////////////
            '//// first condition if user have item in cart/////
            If dt_Old_ebook Is Nothing Then
            Else
                For i = 0 To dt_Old_ebook.Rows.Count - 1
                    dr = dt_cart_ebook.NewRow()
                    dr("ISBN_13") = dt_Old_ebook.Rows(i).Item("ISBN_13").ToString()
                    dr("eBook_ID") = dt_Old_ebook.Rows(i).Item("eBook_ID").ToString()
                    dr("Book_Title") = dt_Old_ebook.Rows(i).Item("Book_Title").ToString()
                    dr("Quantity") = dt_Old_ebook.Rows(i).Item("Quantity")
                    dr("Selling_Price") = dt_Old_ebook.Rows(i).Item("Selling_Price")
                    dr("Items_Amount") = CDbl(dr("Quantity")) * CDbl(dr("Selling_Price"))
                    'amount_ebook = amount_ebook + (Convert.ToDouble(dr("Items_Amount")))
                    dr("Supplier") = dt_Old_ebook.Rows(i).Item("Supplier").ToString()
                    dr("Exchange") = dt_Old_ebook.Rows(i).Item("Exchange").ToString()
                    dr("Exchange_Internet") = dt_Old_ebook.Rows(i).Item("Exchange_Internet").ToString()
                    dr("Discount") = dt_Old_ebook.Rows(i).Item("Discount").ToString()
                    dr("Format") = dt_Old_ebook.Rows(i).Item("Format").ToString()
                    dr("Format_Type") = dt_Old_ebook.Rows(i).Item("Format_Type").ToString()
                    dr("Country") = dt_Old_ebook.Rows(i).Item("Country").ToString()
                    dr("Size") = dt_Old_ebook.Rows(i).Item("Size").ToString()
                    dt_cart_ebook.Rows.Add(dr)
                Next
            End If

            '/////////////////////////////////////////////////////
            '//// first condition if user have 0 item in cart/////
            If dt_ebook Is Nothing Then
            Else
                If dt_cart_ebook.Rows.Count > 0 Then
                    For i = 0 To dt_cart_ebook.Rows.Count - 1
                        If dt_cart_ebook.Rows(i).Item("ISBN_13") = dt_ebook.Rows(0).Item("ISBN_13") Then
                            alert = "alert"
                            dt_cart_ebook.Rows(i).Item("Quantity") = CInt(dt_cart_ebook.Rows(i).Item("Quantity")) + CInt(dt_ebook.Rows(0).Item("Quantity"))
                        Else
                            dr = dt_cart_ebook.NewRow()
                            dr("ISBN_13") = dt_ebook.Rows(0).Item("ISBN_13").ToString()
                            dr("eBook_ID") = dt_ebook.Rows(0).Item("eBook_ID").ToString()
                            dr("Book_Title") = dt_ebook.Rows(0).Item("Book_Title").ToString()
                            dr("Quantity") = dt_ebook.Rows(0).Item("Quantity")
                            dr("Selling_Price") = dt_ebook.Rows(0).Item("Selling_Price")
                            dr("Items_Amount") = CDbl(dr("Quantity")) * CDbl(dr("Selling_Price"))
                            'amount_ebook = amount_ebook + (Convert.ToDouble(dr("Items_Amount")))
                            dr("Supplier") = dt_ebook.Rows(0).Item("Supplier").ToString()
                            dr("Exchange") = dt_ebook.Rows(0).Item("Exchange").ToString()
                            dr("Exchange_Internet") = dt_ebook.Rows(0).Item("Exchange_Internet").ToString()
                            dr("Discount") = dt_ebook.Rows(0).Item("Discount").ToString()
                            dr("Format") = dt_ebook.Rows(0).Item("Format").ToString()
                            dr("Format_Type") = dt_ebook.Rows(0).Item("Format_type").ToString()
                            dr("Country") = dt_ebook.Rows(0).Item("Country").ToString()
                            dr("Size") = dt_ebook.Rows(0).Item("Size").ToString()
                            dt_cart_ebook.Rows.Add(dr)
                        End If
                    Next
                Else
                    dr = dt_cart_ebook.NewRow()
                    dr("ISBN_13") = dt_ebook.Rows(0).Item("ISBN_13").ToString()
                    dr("eBook_ID") = dt_ebook.Rows(0).Item("eBook_ID").ToString()
                    dr("Book_Title") = dt_ebook.Rows(0).Item("Book_Title").ToString()
                    dr("Quantity") = dt_ebook.Rows(0).Item("Quantity")
                    dr("Selling_Price") = dt_ebook.Rows(0).Item("Selling_Price")
                    dr("Items_Amount") = CDbl(dr("Quantity")) * CDbl(dr("Selling_Price"))
                    'amount_ebook = amount_ebook + (Convert.ToDouble(dr("Items_Amount")))
                    dr("Supplier") = dt_ebook.Rows(0).Item("Supplier").ToString()
                    dr("Exchange") = dt_ebook.Rows(0).Item("Exchange").ToString()
                    dr("Exchange_Internet") = dt_ebook.Rows(0).Item("Exchange_Internet").ToString()
                    dr("Discount") = dt_ebook.Rows(0).Item("Discount").ToString()
                    dr("Format") = dt_ebook.Rows(0).Item("Format").ToString()
                    dr("Format_Type") = dt_ebook.Rows(0).Item("Format_type").ToString()
                    dr("Country") = dt_ebook.Rows(0).Item("Country").ToString()
                    dr("Size") = dt_ebook.Rows(0).Item("Size").ToString()
                    dt_cart_ebook.Rows.Add(dr)
                End If
            End If

            If dt_cart_ebook.Rows.Count > 0 Then
                For i = 0 To dt_cart_ebook.Rows.Count - 1
                    dr = datatable_ebook.NewRow()
                    dr("No") = (i + 1).ToString()
                    dr("ISBN_13") = dt_cart_ebook.Rows(i).Item("ISBN_13").ToString()
                    dr("eBook_ID") = dt_cart_ebook.Rows(i).Item("eBook_ID").ToString()
                    dr("Book_Title") = dt_cart_ebook.Rows(i).Item("Book_Title").ToString()
                    dr("Quantity") = dt_cart_ebook.Rows(i).Item("Quantity")
                    Dim convert As String = dt_cart_ebook.Rows(i).Item("Selling_Price").ToString()
                    dr("Selling_Price") = CDbl(convert)
                    dr("Items_Amount") = CDbl(dr("Quantity")) * CDbl(dr("Selling_Price"))
                    amount_ebook = amount_ebook + (CDbl(dr("Items_Amount")))
                    qty += CInt(dr("Quantity"))
                    dr("Supplier") = dt_cart_ebook.Rows(i).Item("Supplier").ToString()
                    dr("Exchange") = dt_cart_ebook.Rows(i).Item("Exchange").ToString()
                    dr("Exchange_Internet") = dt_cart_ebook.Rows(i).Item("Exchange_Internet").ToString()
                    dr("Discount") = dt_cart_ebook.Rows(i).Item("Discount").ToString()
                    dr("Format") = dt_cart_ebook.Rows(i).Item("Format").ToString()
                    dr("Format_Type") = dt_cart_ebook.Rows(i).Item("Format_Type").ToString()
                    dr("Country") = dt_cart_ebook.Rows(i).Item("Country").ToString()
                    dr("Size") = dt_cart_ebook.Rows(i).Item("Size").ToString()
                    datatable_ebook.Rows.Add(dr)
                Next
                dt_ebook_shopping = datatable_ebook
                original_total = amount_ebook.ToString
            End If

            Try
                Dim guy As DataTable = New DataTable
                Dim SqlDb As SqlDb = New SqlDb
                Dim sql As String = ""

                Dim num As Integer

                sql &= "SELECT DISTINCT buy , discount "
                sql &= "FROM ebook_promotion "
                sql &= "WHERE status = 1 AND promotion = 1"

                guy = SqlDb.GetDataTable(sql)

                If guy.Rows.Count > 0 Then
                    num = CInt(guy.Rows(0).Item("buy").ToString)
                    discount = CDbl(guy.Rows(0).Item("discount").ToString)
                    percent_discount = discount.ToString
                    If qty >= num Then
                        amount_ebook = amount_ebook - (amount_ebook * (discount / 100))
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
            '///////promptnow end///////
        Else
            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Int32")
            dc.ColumnName = "No"
            dc.AutoIncrement = False
            dc.Caption = "No"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Book.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Book_Title"
            dc.AutoIncrement = False
            dc.Caption = "Book_Title"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Book.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "ISBN_13"
            dc.AutoIncrement = False
            dc.Caption = "ISBN_13"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Book.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Double")
            dc.ColumnName = "Selling_Price"
            dc.AutoIncrement = False
            dc.Caption = "Selling_Price"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Book.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Int32")
            dc.ColumnName = "Lead_Time"
            dc.AutoIncrement = False
            dc.Caption = "Lead_Time"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Book.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Weight"
            dc.AutoIncrement = False
            dc.Caption = "Weight"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Book.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Double")
            dc.ColumnName = "Quantity"
            dc.AutoIncrement = False
            dc.Caption = "Quantity"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Book.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Double")
            dc.ColumnName = "Amount"
            dc.AutoIncrement = False
            dc.Caption = "Amount"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Book.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Ordstt"
            dc.AutoIncrement = False
            dc.Caption = "Ordstt"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Book.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "To_Org_AB_code"
            dc.AutoIncrement = False
            dc.Caption = "To_Org_AB_code"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Book.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Status"
            dc.AutoIncrement = False
            dc.Caption = "Status"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Book.Columns.Add(dc)

            dc_sum = New DataColumn()
            dc_sum.DataType = System.Type.GetType("System.Int32")
            dc_sum.ColumnName = "No"
            dc_sum.AutoIncrement = False
            dc_sum.Caption = "No"
            dc_sum.ReadOnly = False
            dc_sum.Unique = False
            dt_trn_sum_Qty.Columns.Add(dc_sum)

            dc_sum = New DataColumn()
            dc_sum.DataType = System.Type.GetType("System.String")
            dc_sum.ColumnName = "Book_Title"
            dc_sum.AutoIncrement = False
            dc_sum.Caption = "Book_Title"
            dc_sum.ReadOnly = False
            dc_sum.Unique = False
            dt_trn_sum_Qty.Columns.Add(dc_sum)

            dc_sum = New DataColumn()
            dc_sum.DataType = System.Type.GetType("System.String")
            dc_sum.ColumnName = "ISBN_13"
            dc_sum.AutoIncrement = False
            dc_sum.Caption = "ISBN_13"
            dc_sum.ReadOnly = False
            dc_sum.Unique = False
            dt_trn_sum_Qty.Columns.Add(dc_sum)

            dc_sum = New DataColumn()
            dc_sum.DataType = System.Type.GetType("System.Double")
            dc_sum.ColumnName = "Selling_Price"
            dc_sum.AutoIncrement = False
            dc_sum.Caption = "Selling_Price"
            dc_sum.ReadOnly = False
            dc_sum.Unique = False
            dt_trn_sum_Qty.Columns.Add(dc_sum)


            dc_sum = New DataColumn()
            dc_sum.DataType = System.Type.GetType("System.Int32")
            dc_sum.ColumnName = "Lead_Time"
            dc_sum.AutoIncrement = False
            dc_sum.Caption = "Lead_Time"
            dc_sum.ReadOnly = False
            dc_sum.Unique = False
            dt_trn_sum_Qty.Columns.Add(dc_sum)

            dc_sum = New DataColumn()
            dc_sum.DataType = System.Type.GetType("System.String")
            dc_sum.ColumnName = "Weight"
            dc_sum.AutoIncrement = False
            dc_sum.Caption = "Weight"
            dc_sum.ReadOnly = False
            dc_sum.Unique = False
            dt_trn_sum_Qty.Columns.Add(dc_sum)

            dc_sum = New DataColumn()
            dc_sum.DataType = System.Type.GetType("System.Double")
            dc_sum.ColumnName = "Quantity"
            dc_sum.AutoIncrement = False
            dc_sum.Caption = "Quantity"
            dc_sum.ReadOnly = False
            dc_sum.Unique = False
            dt_trn_sum_Qty.Columns.Add(dc_sum)

            dc_sum = New DataColumn()
            dc_sum.DataType = System.Type.GetType("System.Double")
            dc_sum.ColumnName = "Amount"
            dc_sum.AutoIncrement = False
            dc_sum.Caption = "Amount"
            dc_sum.ReadOnly = False
            dc_sum.Unique = False
            dt_trn_sum_Qty.Columns.Add(dc_sum)

            dc_sum = New DataColumn()
            dc_sum.DataType = System.Type.GetType("System.String")
            dc_sum.ColumnName = "Ordstt"
            dc_sum.AutoIncrement = False
            dc_sum.Caption = "Ordstt"
            dc_sum.ReadOnly = False
            dc_sum.Unique = False
            dt_trn_sum_Qty.Columns.Add(dc_sum)

            dc_sum = New DataColumn()
            dc_sum.DataType = System.Type.GetType("System.String")
            dc_sum.ColumnName = "To_Org_AB_code"
            dc_sum.AutoIncrement = False
            dc_sum.Caption = "To_Org_AB_code"
            dc_sum.ReadOnly = False
            dc_sum.Unique = False
            dt_trn_sum_Qty.Columns.Add(dc_sum)

            dc_sum = New DataColumn()
            dc_sum.DataType = System.Type.GetType("System.String")
            dc_sum.ColumnName = "Status"
            dc_sum.AutoIncrement = False
            dc_sum.Caption = "Status"
            dc_sum.ReadOnly = False
            dc_sum.Unique = False
            dt_trn_sum_Qty.Columns.Add(dc_sum)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Int32")
            dc.ColumnName = "No"
            dc.AutoIncrement = False
            dc.Caption = "No"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_In_Branch.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Book_Title"
            dc.AutoIncrement = False
            dc.Caption = "Book_Title"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_In_Branch.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "ISBN_13"
            dc.AutoIncrement = False
            dc.Caption = "ISBN_13"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_In_Branch.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Double")
            dc.ColumnName = "Selling_Price"
            dc.AutoIncrement = False
            dc.Caption = "Selling_Price"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_In_Branch.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Int32")
            dc.ColumnName = "Lead_Time"
            dc.AutoIncrement = False
            dc.Caption = "Lead_Time"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_In_Branch.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Weight"
            dc.AutoIncrement = False
            dc.Caption = "Weight"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_In_Branch.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Double")
            dc.ColumnName = "Quantity"
            dc.AutoIncrement = False
            dc.Caption = "Quantity"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_In_Branch.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Double")
            dc.ColumnName = "Amount"
            dc.AutoIncrement = False
            dc.Caption = "Amount"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_In_Branch.Columns.Add(dc)


            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Ordstt"
            dc.AutoIncrement = False
            dc.Caption = "Ordstt"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_In_Branch.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "To_Org_AB_code"
            dc.AutoIncrement = False
            dc.Caption = "To_Org_AB_code"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_In_Branch.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Status"
            dc.AutoIncrement = False
            dc.Caption = "Status"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_In_Branch.Columns.Add(dc)


            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Int32")
            dc.ColumnName = "No"
            dc.AutoIncrement = False
            dc.Caption = "No"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Other_Branch.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Book_Title"
            dc.AutoIncrement = False
            dc.Caption = "Book_Title"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Other_Branch.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "ISBN_13"
            dc.AutoIncrement = False
            dc.Caption = "ISBN_13"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Other_Branch.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Double")
            dc.ColumnName = "Selling_Price"
            dc.AutoIncrement = False
            dc.Caption = "Selling_Price"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Other_Branch.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Int32")
            dc.ColumnName = "Lead_Time"
            dc.AutoIncrement = False
            dc.Caption = "Lead_Time"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Other_Branch.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Weight"
            dc.AutoIncrement = False
            dc.Caption = "Weight"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Other_Branch.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Double")
            dc.ColumnName = "Quantity"
            dc.AutoIncrement = False
            dc.Caption = "Quantity"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Other_Branch.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Double")
            dc.ColumnName = "Amount"
            dc.AutoIncrement = False
            dc.Caption = "Amount"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Other_Branch.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Ordstt"
            dc.AutoIncrement = False
            dc.Caption = "Ordstt"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Other_Branch.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "To_Org_AB_code"
            dc.AutoIncrement = False
            dc.Caption = "To_Org_AB_code"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Other_Branch.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Status"
            dc.AutoIncrement = False
            dc.Caption = "Status"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Other_Branch.Columns.Add(dc)


            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Int32")
            dc.ColumnName = "No"
            dc.AutoIncrement = False
            dc.Caption = "No"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Jobber.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Book_Title"
            dc.AutoIncrement = False
            dc.Caption = "Book_Title"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Jobber.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "ISBN_13"
            dc.AutoIncrement = False
            dc.Caption = "ISBN_13"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Jobber.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Double")
            dc.ColumnName = "Selling_Price"
            dc.AutoIncrement = False
            dc.Caption = "Selling_Price"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Jobber.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Int32")
            dc.ColumnName = "Lead_Time"
            dc.AutoIncrement = False
            dc.Caption = "Lead_Time"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Jobber.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Weight"
            dc.AutoIncrement = False
            dc.Caption = "Weight"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Jobber.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Double")
            dc.ColumnName = "Quantity"
            dc.AutoIncrement = False
            dc.Caption = "Quantity"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Jobber.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.Double")
            dc.ColumnName = "Amount"
            dc.AutoIncrement = False
            dc.Caption = "Amount"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Jobber.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Ordstt"
            dc.AutoIncrement = False
            dc.Caption = "Ordstt"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Jobber.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "To_Org_AB_code"
            dc.AutoIncrement = False
            dc.Caption = "To_Org_AB_code"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Jobber.Columns.Add(dc)

            dc = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Status"
            dc.AutoIncrement = False
            dc.Caption = "Status"
            dc.ReadOnly = False
            dc.Unique = False
            dt_trn_Jobber.Columns.Add(dc)

            If dt_Old_book_In_Branch Is Nothing Then
            Else
                For i = 0 To dt_Old_book_In_Branch.Rows.Count - 1
                    dr_Old = dt_trn_Book.NewRow()
                    dr_Old("No") = dt_Old_book_In_Branch.Rows(i).Item("No").ToString()
                    dr_Old("Book_Title") = dt_Old_book_In_Branch.Rows(i).Item("Book_Title").ToString()
                    dr_Old("ISBN_13") = dt_Old_book_In_Branch.Rows(i).Item("ISBN_13").ToString()
                    dr_Old("Selling_Price") = dt_Old_book_In_Branch.Rows(i).Item("Selling_Price")
                    dr_Old("Lead_Time") = dt_Old_book_In_Branch.Rows(i).Item("Lead_Time")
                    dr_Old("Weight") = dt_Old_book_In_Branch.Rows(i).Item("Weight").ToString()
                    dr_Old("Quantity") = dt_Old_book_In_Branch.Rows(i).Item("Quantity")
                    dr_Old("Amount") = dt_Old_book_In_Branch.Rows(i).Item("Amount")
                    dr_Old("Ordstt") = dt_Old_book_In_Branch.Rows(i).Item("Ordstt")
                    dr_Old("To_Org_AB_code") = dt_Old_book_In_Branch.Rows(i).Item("To_Org_AB_code")
                    dr_Old("Status") = dt_Old_book_In_Branch.Rows(i).Item("Status")
                    dt_trn_Book.Rows.Add(dr_Old)
                Next
            End If
            If dt_Old_book_Other_Branch Is Nothing Then
            Else
                For i = 0 To dt_Old_book_Other_Branch.Rows.Count - 1
                    dr_Old = dt_trn_Book.NewRow()
                    dr_Old("No") = dt_Old_book_Other_Branch.Rows(i).Item("No").ToString()
                    dr_Old("Book_Title") = dt_Old_book_Other_Branch.Rows(i).Item("Book_Title").ToString()
                    dr_Old("ISBN_13") = dt_Old_book_Other_Branch.Rows(i).Item("ISBN_13").ToString()
                    dr_Old("Selling_Price") = dt_Old_book_Other_Branch.Rows(i).Item("Selling_Price")
                    dr_Old("Lead_Time") = dt_Old_book_Other_Branch.Rows(i).Item("Lead_Time")
                    dr_Old("Weight") = dt_Old_book_Other_Branch.Rows(i).Item("Weight").ToString()
                    dr_Old("Quantity") = dt_Old_book_Other_Branch.Rows(i).Item("Quantity")
                    dr_Old("Amount") = dt_Old_book_Other_Branch.Rows(i).Item("Amount")
                    dr_Old("Ordstt") = dt_Old_book_Other_Branch.Rows(i).Item("Ordstt")
                    dr_Old("To_Org_AB_code") = dt_Old_book_Other_Branch.Rows(i).Item("To_Org_AB_code")
                    dr_Old("Status") = dt_Old_book_Other_Branch.Rows(i).Item("Status")
                    dt_trn_Book.Rows.Add(dr_Old)
                Next
            End If
            If dt_Old_book_jobber Is Nothing Then
            Else
                For i = 0 To dt_Old_book_jobber.Rows.Count - 1
                    dr_Old = dt_trn_Book.NewRow()
                    dr_Old("No") = dt_Old_book_jobber.Rows(i).Item("No").ToString()
                    dr_Old("Book_Title") = dt_Old_book_jobber.Rows(i).Item("Book_Title").ToString()
                    dr_Old("ISBN_13") = dt_Old_book_jobber.Rows(i).Item("ISBN_13").ToString()
                    dr_Old("Selling_Price") = dt_Old_book_jobber.Rows(i).Item("Selling_Price").ToString()
                    dr_Old("Lead_Time") = dt_Old_book_jobber.Rows(i).Item("Lead_Time").ToString()
                    dr_Old("Weight") = dt_Old_book_jobber.Rows(i).Item("Weight").ToString()
                    dr_Old("Quantity") = dt_Old_book_jobber.Rows(i).Item("Quantity").ToString()
                    dr_Old("Amount") = dt_Old_book_jobber.Rows(i).Item("Amount").ToString()
                    dr_Old("Ordstt") = dt_Old_book_jobber.Rows(i).Item("Ordstt").ToString()
                    dr_Old("To_Org_AB_code") = dt_Old_book_jobber.Rows(i).Item("To_Org_AB_code").ToString()
                    dr_Old("Status") = dt_Old_book_jobber.Rows(i).Item("Status").ToString()
                    dt_trn_Book.Rows.Add(dr_Old)
                Next
            End If
            If keyword_1 <> "" Then
                Dim dt_detail As New DataTable
                dt_detail = _dt_book_detail()
                dr_Old = dt_trn_Book.NewRow()
                dr_Old("No") = "1"
                dr_Old("Book_Title") = dt_detail.Rows(0).Item("Book_Title").ToString()
                dr_Old("ISBN_13") = keyword_1
                dr_Old("Selling_Price") = CDbl(dt_detail.Rows(0).Item("Selling_Price").ToString())
                dr_Old("Lead_Time") = "2"
                dr_Old("Weight") = dt_detail.Rows(0).Item("Weight").ToString()
                dr_Old("Quantity") = keyword_Qty
                dr_Old("Amount") = CDbl(CDbl(dt_detail.Rows(0).Item("Selling_Price")) * keyword_Qty)
                dr_Old("Ordstt") = dt_detail.Rows(0).Item("Ordstt")
                dr_Old("To_Org_AB_code") = dt_detail.Rows(0).Item("To_Org_AB_code")
                dr_Old("Status") = Status
                dt_trn_Book.Rows.Add(dr_Old)
            End If
            If dt_trn_Book.Rows.Count > 0 Then

                dt_trn_Book.Select("", "ISBN_13,Status DESC")

                Dim dt_sort As New DataTable
                Dim dr_sort As DataRow
                dt_sort.Columns.Add("ISBN_13")
                dt_sort.Columns.Add("Status")
                dr_sort = dt_sort.NewRow()
                dr_sort("ISBN_13") = ""
                dr_sort("Status") = ""

                dt_sort.Rows.Add(dr_sort)
                Dim sumObject As Integer

                For i = 0 To dt_trn_Book.Rows.Count - 1

                    Dim num As New Integer
                    num = 0
                    For j = 1 To dt_sort.Rows.Count - 1
                        If dt_trn_Book.Rows(i).Item("ISBN_13").ToString = dt_sort.Rows(j).Item("ISBN_13").ToString And dt_trn_Book.Rows(i).Item("Status").ToString = dt_sort.Rows(j).Item("Status").ToString Then
                            num = num + 1

                        End If
                    Next
                    If num = 0 Then
                        alert = "alert"
                        sumObject = CInt(dt_trn_Book.Compute("Sum(Quantity)", "ISBN_13 = '" + dt_trn_Book.Rows(i).Item("ISBN_13").ToString() + "' and Status = '" + dt_trn_Book.Rows(i).Item("Status").ToString() + "'"))
                        dr_Old = dt_trn_sum_Qty.NewRow()
                        dr_Old("No") = CInt(dt_trn_Book.Rows(i).Item("No").ToString())
                        dr_Old("Book_Title") = dt_trn_Book.Rows(i).Item("Book_Title").ToString()
                        dr_Old("ISBN_13") = dt_trn_Book.Rows(i).Item("ISBN_13").ToString()
                        dr_Old("Selling_Price") = CDbl(dt_trn_Book.Rows(i).Item("Selling_Price").ToString())
                        dr_Old("Lead_Time") = dt_trn_Book.Rows(i).Item("Lead_Time").ToString()
                        dr_Old("Weight") = dt_trn_Book.Rows(i).Item("Weight").ToString()
                        dr_Old("Quantity") = CInt(sumObject)
                        dr_Old("Amount") = CDbl(dt_trn_Book.Rows(i).Item("Amount").ToString())
                        dr_Old("Ordstt") = dt_trn_Book.Rows(i).Item("Ordstt")
                        dr_Old("To_Org_AB_code") = dt_trn_Book.Rows(i).Item("To_Org_AB_code").ToString()
                        dr_Old("Status") = dt_trn_Book.Rows(i).Item("Status").ToString()
                        dt_trn_sum_Qty.Rows.Add(dr_Old)

                        dr_sort = dt_sort.NewRow()
                        dr_sort("ISBN_13") = dt_trn_Book.Rows(i).Item("ISBN_13").ToString()
                        dt_sort.Rows.Add(dr_sort)

                        If dt_trn_sum_Qty.Select("ISBN_13='" + dr_Old("ISBN_13") + "' and Status='" + dr_Old("Status") + "'").Length > 1 Then
                            dt_trn_sum_Qty.Rows(i).Delete()
                        End If

                    End If

                Next

            End If


            If dt_trn_sum_Qty.Rows.Count > 0 Then
                Dim isbn_13 As String
                In_Branch_Number = 0
                Other_Branch_Number = 0
                Jobber_Number = 0
                amount_Branch = 0
                amount_Other_Branch = 0
                amount_Jobber = 0
                For i = 0 To dt_trn_sum_Qty.Rows.Count - 1

                    isbn_13 = dt_trn_sum_Qty.Rows(i).Item("ISBN_13").ToString()
                    input_No = dt_trn_sum_Qty.Rows(i).Item("No").ToString()
                    input_Book_Title = dt_trn_sum_Qty.Rows(i).Item("Book_Title").ToString()
                    input_ISBN_13 = dt_trn_sum_Qty.Rows(i).Item("ISBN_13").ToString()
                    input_Selling_Price = dt_trn_sum_Qty.Rows(i).Item("Selling_Price").ToString()
                    input_Lead_Time = dt_trn_sum_Qty.Rows(i).Item("Lead_Time").ToString()
                    input_Weight = dt_trn_sum_Qty.Rows(i).Item("Weight").ToString()
                    input_Quantity = dt_trn_sum_Qty.Rows(i).Item("Quantity").ToString()
                    input_Amount = dt_trn_sum_Qty.Rows(i).Item("Amount").ToString()

                    If dt_trn_sum_Qty.Rows(i).Item("Status").ToString() = "AB" Then
                        Status = "AB"
                        check_dt_book_In_Branch()
                    ElseIf dt_trn_sum_Qty.Rows(i).Item("Status").ToString() = "SPECIAL" Then
                        Status = "SPECIAL"
                        check_dt_book_Jobber_Indent()
                    ElseIf dt_trn_sum_Qty.Rows(i).Item("Status").ToString() = "INDENT" Then
                        Status = "INDENT"
                        check_dt_book_Jobber()
                    End If
                    'If Status = "AB" Then
                    '    check_dt_book_In_Branch()
                    'ElseIf Status = "INDENT" Then
                    '    check_dt_book_In_Branch()
                    'ElseIf Status = "Spec" Then
                    '    check_dt_book_Jobber_Indent()
                    'End If


                Next
            End If
        End If
    End Sub
    Public Sub check_dt_book_In_Branch()

        Dim dr_Old_In_Branch As DataRow

        Dim dt_stock_in_Branch As New DataTable
        Dim dt_detail_in_Branch As New DataTable
        Dim SqlDb As SqlDb = New SqlDb
        Dim SqlStr1 As String = ""
        Dim dt_Minimum_Stock As New DataTable
        Dim Minimun1 As Integer
        'SqlStr1 = SqlStr1 + "select Minimum_Stock_Branch from  tbm_syst_company "
        'dt_Minimum_Stock = SqlDb.GetDataTable(SqlStr1)
        'Minimun1 = CInt(dt_Minimum_Stock.Rows(0).Item(0).ToString)
        'dt_detail_in_Branch = _dt_book_detail()
        Dim condition As String = ""
        Dim SqlStr As String = ""
        Dim codition_internet As String = ""
        Dim codition_internet2 As String = ""

        If sales_channel = "INTERNET" Then
            codition_internet = " AND tbt_jobber_stockab.QTY-Minimum_Stock_Internet >= Minimum_Stock_Internet "
            codition_internet2 = " tbt_jobber_stockab.QTY-Minimum_Stock_Internet as Quantity, "
        Else
            codition_internet = " AND tbt_jobber_stockab.QTY-Minimum_Stock_Branch >= Minimum_Stock_Branch "
            codition_internet2 = " tbt_jobber_stockab.QTY-Minimum_Stock_Branch as Quantity, "
        End If
        'SqlStr &= "select	a.ISBN_13 as ISBN_13 ,b.From_Org_AB_code as From_Org_AB_code,b.To_Org_AB_code as To_Org_AB_code,Lead_Time,qty,Group_code "
        'SqlStr &= "from	    tbt_jobber_stockab a,tbm_syst_organizeabableadtime b,tbm_syst_organizeab c "
        'SqlStr &= "where	a.Org_AB_code=b.To_Org_AB_code "
        'SqlStr &= "and	    b.To_Org_AB_code=c.Org_AB_code "
        'SqlStr &= "and	    b.From_Org_AB_code='" + keyword_Branch + "' "
        'SqlStr &= "and	    b.To_Org_AB_code='" + keyword_Branch + "' "
        'If input_ISBN_13 <> Nothing Then
        '    condition = "and    (ISBN_10 = '" + input_ISBN_13.Replace("'", "") + "' or ISBN_13 = '" + input_ISBN_13.Replace("'", "") + "')"
        'End If
        'SqlStr = SqlStr + condition
        SqlStr &= "SELECT  distinct tbm_asbkeo_bookab.ISBN_13,"
        SqlStr &= "		tbm_asbkeo_bookab.Book_Title,"
        SqlStr &= "		tbt_jobber_stockab.Org_AB_Code as To_Org_AB_code,"
        SqlStr &= "		tbm_asbkeo_bookab.Weight,"
        SqlStr &= "		tbt_jobber_stockab.QTY-Minimum_Stock_Branch as Quantity,"
        SqlStr &= "		tbm_asbkeo_bookab.selling_price_eCom as Selling_price,"
        SqlStr &= "     CASE WHEN tbt_jobber_stockab.Org_AB_Code='Ho_internet' THEN '5'"
        SqlStr &= "     ELSE isnull(Lead_Time,0) END as Lead_Time, "
        SqlStr &= "		Group_code"
        SqlStr &= " FROM (((((tbt_jobber_book_search LEFT OUTER JOIN tbm_asbkeo_bookab"
        SqlStr &= "		ON tbt_jobber_book_search.ISBN_13=tbm_asbkeo_bookab.ISBN_13)"
        SqlStr &= "		LEFT OUTER JOIN tbt_jobber_stockab "
        SqlStr &= "		ON tbm_asbkeo_bookab.ISBN_13=tbt_jobber_stockab.ISBN_13)"
        SqlStr &= "		LEFT OUTER JOIN tbm_syst_organizeab "
        SqlStr &= "		ON tbt_jobber_stockab.Org_AB_Code=tbm_syst_organizeab.Org_AB_code)"
        SqlStr &= "		LEFT OUTER JOIN tbm_syst_organizeabableadtime"
        SqlStr &= "		ON tbt_jobber_stockab.Org_AB_Code=tbm_syst_organizeabableadtime.To_Org_AB_Code "
        SqlStr &= "		AND tbm_syst_organizeab.Org_AB_Code=tbm_syst_organizeabableadtime.From_Org_AB_Code)"
        SqlStr &= "		LEFT OUTER JOIN tbt_jobber_stockindent"
        SqlStr &= "		ON tbt_jobber_stockab.ISBN_13=tbt_jobber_stockindent.ISBN_13),"
        SqlStr &= "		tbm_syst_company"
        SqlStr &= " WHERE   tbt_jobber_book_search.ISBN_13 = '" + input_ISBN_13.Trim + "'" + codition_internet + ""
        'SqlStr &= " AND     tbt_jobber_stockab.QTY-Minimum_Stock_Branch>0"
        SqlStr &= " AND     tbt_jobber_stockab.Org_AB_Code='" + keyword_Branch + "'"
        dt_stock_in_Branch = SqlDb.GetDataTable(SqlStr)
        If dt_stock_in_Branch.Rows.Count > 0 Then
            If input_Quantity > CInt(dt_stock_in_Branch.Rows(0).Item("Quantity").ToString) Then
                If CInt(dt_stock_in_Branch.Rows(0).Item("Quantity").ToString) And _
                    (ConfigurationSettings.AppSettings("UserInternet") <> sales_channel _
                         And ConfigurationSettings.AppSettings("UserDirectSale") <> sales_channel) Then
                    In_Branch_Number = In_Branch_Number + 1
                    dr_Old_In_Branch = dt_trn_In_Branch.NewRow()
                    dr_Old_In_Branch("No") = CInt(In_Branch_Number) 'CInt(dt_book_In_Branch.Rows.Count + 1)
                    dr_Old_In_Branch("Book_Title") = dt_stock_in_Branch.Rows(0).Item("Book_Title").ToString
                    dr_Old_In_Branch("ISBN_13") = dt_stock_in_Branch.Rows(0).Item("ISBN_13").ToString
                    dr_Old_In_Branch("Selling_Price") = CDbl(dt_stock_in_Branch.Rows(0).Item("Selling_Price")).ToString("#,###,##0.00")
                    dr_Old_In_Branch("Lead_Time") = CDbl(dt_stock_in_Branch.Rows(0).Item("Lead_Time")).ToString("0")
                    dr_Old_In_Branch("Weight") = CDbl(CDbl(dt_stock_in_Branch.Rows(0).Item("Weight")).ToString("#0.00") * _
                                                dt_stock_in_Branch.Rows(0).Item("Quantity")).ToString("#,###,##0.00")
                    dr_Old_In_Branch("Quantity") = dt_stock_in_Branch.Rows(0).Item("Quantity")
                    dr_Old_In_Branch("Amount") = CDbl(CDbl(dt_stock_in_Branch.Rows(0).Item("Selling_Price")).ToString("#0.00") * _
                                                 dt_stock_in_Branch.Rows(0).Item("Quantity")).ToString("#,###,##0.00")
                    dr_Old_In_Branch("Status") = Status
                    dt_trn_In_Branch.Rows.Add(dr_Old_In_Branch)
                    dt_book_In_Branch = dt_trn_In_Branch
                    amount_Branch = amount_Branch + CDbl(CDbl(dt_stock_in_Branch.Rows(0).Item("Selling_Price")).ToString("#0.00") * _
                                                   dt_stock_in_Branch.Rows(0).Item("Quantity")).ToString("#,###,##0.00")
                    input_Quantity = input_Quantity - CInt(dt_stock_in_Branch.Rows(0).Item("Quantity"))
                    check_dt_book_Other_Branch()
                Else
                    If (ConfigurationSettings.AppSettings("UserInternet") = sales_channel _
                         Or ConfigurationSettings.AppSettings("UserDirectSale") = sales_channel) Then

                        If Jobber_Status = "AB" Then
                            check_dt_book_Jobber()
                        Else
                            input_qtyAB = CInt(dt_stock_in_Branch.Rows(0).Item("Quantity").ToString) - 1
                            In_Branch_Number = In_Branch_Number + 1
                            dr_Old_In_Branch = dt_trn_In_Branch.NewRow()
                            dr_Old_In_Branch("No") = CInt(In_Branch_Number) 'CInt(dt_book_In_Branch.Rows.Count + 1)
                            dr_Old_In_Branch("Book_Title") = dt_stock_in_Branch.Rows(0).Item("Book_Title").ToString
                            dr_Old_In_Branch("ISBN_13") = dt_stock_in_Branch.Rows(0).Item("ISBN_13").ToString
                            dr_Old_In_Branch("Selling_Price") = CDbl(dt_stock_in_Branch.Rows(0).Item("Selling_Price")).ToString("#,###,##0.00")
                            dr_Old_In_Branch("Lead_Time") = CDbl(dt_stock_in_Branch.Rows(0).Item("Lead_Time")).ToString("0")
                            dr_Old_In_Branch("Weight") = CDbl(CDbl(dt_stock_in_Branch.Rows(0).Item("Weight")).ToString("#0.00") * _
                                                         input_qtyAB).ToString("#,##0.00")
                            dr_Old_In_Branch("Quantity") = input_qtyAB
                            dr_Old_In_Branch("Amount") = CDbl(CDbl(dt_stock_in_Branch.Rows(0).Item("Selling_Price")).ToString("#0.00") * _
                                                         input_qtyAB).ToString("#,###,##0.00")
                            dr_Old_In_Branch("Status") = "AB"
                            dt_trn_In_Branch.Rows.Add(dr_Old_In_Branch)
                            dt_book_In_Branch = dt_trn_In_Branch
                            amount_Branch = amount_Branch + CDbl(CDbl(dt_stock_in_Branch.Rows(0).Item("Selling_Price")).ToString("#0.00") * _
                                                            input_qtyAB).ToString("#,###,##0.00")
                            input_qtyIndent = input_Quantity - input_qtyAB
                            check_dt_book_Jobber_Qty()

                        End If

                    Else
                        check_dt_book_Other_Branch()
                    End If
                End If
            Else
                In_Branch_Number = In_Branch_Number + 1
                dr_Old_In_Branch = dt_trn_In_Branch.NewRow()
                dr_Old_In_Branch("No") = CInt(In_Branch_Number) 'CInt(dt_book_In_Branch.Rows.Count + 1)
                dr_Old_In_Branch("Book_Title") = dt_stock_in_Branch.Rows(0).Item("Book_Title").ToString
                dr_Old_In_Branch("ISBN_13") = dt_stock_in_Branch.Rows(0).Item("ISBN_13").ToString
                dr_Old_In_Branch("Selling_Price") = CDbl(dt_stock_in_Branch.Rows(0).Item("Selling_Price")).ToString("#,###,##0.00")
                dr_Old_In_Branch("Lead_Time") = CDbl(dt_stock_in_Branch.Rows(0).Item("Lead_Time")).ToString("0")
                dr_Old_In_Branch("Weight") = CDbl(CDbl(dt_stock_in_Branch.Rows(0).Item("Weight")).ToString("#0.00") * _
                                             input_Quantity).ToString("#,##0.00")
                dr_Old_In_Branch("Quantity") = input_Quantity
                dr_Old_In_Branch("Amount") = CDbl(CDbl(dt_stock_in_Branch.Rows(0).Item("Selling_Price")).ToString("#0.00") * _
                                             input_Quantity).ToString("#,###,##0.00")
                dr_Old_In_Branch("Status") = Status
                dt_trn_In_Branch.Rows.Add(dr_Old_In_Branch)
                dt_book_In_Branch = dt_trn_In_Branch
                amount_Branch = amount_Branch + CDbl(CDbl(dt_stock_in_Branch.Rows(0).Item("Selling_Price")).ToString("#0.00") * _
                                                input_Quantity).ToString("#,###,##0.00")
            End If
        Else
            If (ConfigurationSettings.AppSettings("UserInternet") = sales_channel _
                 Or ConfigurationSettings.AppSettings("UserDirectSale") = sales_channel) Then
                If Jobber_Status = "AB" Then
                    check_dt_book_Jobber()
                Else
                    check_dt_book_Jobber_Indent()
                    'input_qtyAB = CInt(dt_stock_in_Branch.Rows(0).Item("Quantity").ToString) - 1
                    'In_Branch_Number = In_Branch_Number + 1
                    'dr_Old_In_Branch = dt_trn_In_Branch.NewRow()
                    'dr_Old_In_Branch("No") = CInt(In_Branch_Number) 'CInt(dt_book_In_Branch.Rows.Count + 1)
                    'dr_Old_In_Branch("Book_Title") = dt_stock_in_Branch.Rows(0).Item("Book_Title").ToString
                    'dr_Old_In_Branch("ISBN_13") = dt_stock_in_Branch.Rows(0).Item("ISBN_13").ToString
                    'dr_Old_In_Branch("Selling_Price") = CDbl(dt_stock_in_Branch.Rows(0).Item("Selling_Price")).ToString("#,###,##0.00")
                    'dr_Old_In_Branch("Lead_Time") = CDbl(dt_stock_in_Branch.Rows(0).Item("Lead_Time")).ToString("0")
                    'dr_Old_In_Branch("Weight") = CDbl(CDbl(dt_stock_in_Branch.Rows(0).Item("Weight")).ToString("#0.00") * _
                    '                             input_qtyAB).ToString("#,##0.00")
                    'dr_Old_In_Branch("Quantity") = input_qtyAB
                    'dr_Old_In_Branch("Amount") = CDbl(CDbl(dt_stock_in_Branch.Rows(0).Item("Selling_Price")).ToString("#0.00") * _
                    '                             input_qtyAB).ToString("#,###,##0.00")
                    'dr_Old_In_Branch("Status") = "AB"
                    'dt_trn_In_Branch.Rows.Add(dr_Old_In_Branch)
                    'dt_book_In_Branch = dt_trn_In_Branch
                    'amount_Branch = amount_Branch + CDbl(CDbl(dt_stock_in_Branch.Rows(0).Item("Selling_Price")).ToString("#0.00") * _
                    '                                input_qtyAB).ToString("#,###,##0.00")
                    'input_qtyIndent = input_Quantity - input_qtyAB
                    'check_dt_book_Jobber_Qty()

                End If

            Else
                check_dt_book_Other_Branch()
            End If
        End If
    End Sub

    Public Sub check_dt_book_Other_Branch()

        ' Dim dc As DataColumn
        Dim dr_Old_Other_Branch As DataRow

        Dim dt_stock_Other_Branch As New DataTable
        Dim dt_detail_Other_Branch As New DataTable
        Dim SqlDb As SqlDb = New SqlDb
        Dim SqlStr1 As String = ""
        Dim dt_Minimum_Stock As New DataTable
        Dim condition As String = ""
        Dim SqlStr As String = ""
        Dim stk As String = ""
        Dim dt_loop As New DataTable
        Dim codition As String

        If sales_channel = "INTERNET" Then
            codition = " AND tbt_jobber_stockab.QTY-Minimum_Stock_Internet>=" + input_Quantity + ""
        Else
            codition = " AND tbt_jobber_stockab.QTY-Minimum_Stock_Branch>=" + input_Quantity + ""
        End If

        SqlStr = ""

        SqlStr &= "SELECT	 tbt_jobber_stockab.ISBN_13,"
        SqlStr &= "		tbt_jobber_book_search.Book_Title,"
        SqlStr &= "		tbm_syst_organizeabableadtime.From_Org_AB_code,"
        SqlStr &= "		tbm_syst_organizeabableadtime.To_Org_AB_code,"
        SqlStr &= "		tbt_jobber_book_search.Weight,"
        SqlStr &= "		tbm_syst_organizeabableadtime.Lead_Time,"
        SqlStr &= "		tbt_jobber_stockab.QTY-Minimum_Stock_Branch as Quantity,"
        SqlStr &= "		tbm_asbkeo_bookab.Selling_price,"
        SqlStr &= "		tbm_syst_organizeab.Group_code"
        SqlStr &= " FROM tbt_jobber_book_search"
        SqlStr &= "     LEFT JOIN tbt_jobber_stockab"
        SqlStr &= "		ON tbt_jobber_book_search.ISBN_13=tbt_jobber_stockab.ISBN_13 "
        SqlStr &= "		LEFT  JOIN tbm_asbkeo_bookab "
        SqlStr &= "     ON tbt_jobber_book_search.ISBN_13=tbm_asbkeo_bookab.ISBN_13"
        SqlStr &= "		LEFT JOIN tbm_syst_organizeabableadtime"
        SqlStr &= "		ON tbt_jobber_stockab.Org_AB_code=tbm_syst_organizeabableadtime.To_Org_AB_code"
        SqlStr &= "		LEFT JOIN tbm_syst_organizeab"
        SqlStr &= "		ON tbm_syst_organizeabableadtime.To_Org_AB_code=tbm_syst_organizeab.Org_AB_code"
        SqlStr &= "		LEFT JOIN tbm_syst_groupab"
        SqlStr &= "		ON tbm_syst_organizeab.Group_code=tbm_syst_groupab.Group_code,"
        SqlStr &= "		tbm_syst_company"

        SqlStr &= " WHERE	tbt_jobber_book_search.ISBN_13 = '" + input_ISBN_13 + "'"
        SqlStr &= " AND		tbm_syst_organizeabableadtime.From_Org_AB_code='" + keyword_Branch + "'"
        SqlStr &= " AND		tbm_syst_organizeabableadtime.To_Org_AB_code<>'" + keyword_Branch + "'"
        SqlStr &= " AND		tbm_syst_organizeabableadtime.To_Org_AB_code<>'HO-Internet'" + codition + ""
        'SqlStr &= " AND		tbt_jobber_stockab.QTY-Minimum_Stock_Branch>=" + input_Quantity + ""
        SqlStr &= " AND		tbt_jobber_stockab.Org_AB_code not in ('Intransit') and left(tbt_jobber_stockab.Org_AB_code,2) <> 'BO' "
        SqlStr &= " ORDER BY tbm_syst_groupab.priority,QTY-Minimum_Stock_Branch  desc,tbt_jobber_book_search.Selling_Price asc"

        dt_stock_Other_Branch = SqlDb.GetDataTable(SqlStr)
        'Loop dt_stock_in_Branch Ҩ Branch
        If dt_stock_Other_Branch.Rows.Count > 0 Then
            'If stk = "C" Then
            If input_Quantity <= CInt(dt_stock_Other_Branch.Rows(0).Item("Quantity").ToString()) Then
                Other_Branch_Number = Other_Branch_Number + 1
                dr_Old_Other_Branch = dt_trn_Other_Branch.NewRow()
                dr_Old_Other_Branch("No") = CInt(Other_Branch_Number) 'CInt(dt_book_Other_Branch.Rows.Count + 1)
                dr_Old_Other_Branch("Book_Title") = dt_stock_Other_Branch.Rows(0).Item("Book_Title")
                dr_Old_Other_Branch("ISBN_13") = dt_stock_Other_Branch.Rows(0).Item("ISBN_13")
                dr_Old_Other_Branch("Selling_Price") = CDbl(dt_stock_Other_Branch.Rows(0).Item("Selling_Price")).ToString("#,##0.00")
                dr_Old_Other_Branch("Lead_Time") = dt_stock_Other_Branch.Rows(0).Item("Lead_Time")
                dr_Old_Other_Branch("Weight") = CDbl(CDbl(dt_stock_Other_Branch.Rows(0).Item("Weight")).ToString("#0.00") * _
                                                input_Quantity).ToString("#0.00")
                dr_Old_Other_Branch("Quantity") = input_Quantity
                dr_Old_Other_Branch("Amount") = CDbl(CDbl(dt_stock_Other_Branch.Rows(0).Item("Selling_Price")).ToString("#0.00") * _
                                                input_Quantity).ToString("#0.00")
                dr_Old_Other_Branch("To_Org_AB_code") = dt_stock_Other_Branch.Rows(0).Item("To_Org_AB_code").ToString()
                dr_Old_Other_Branch("Status") = Status
                dt_trn_Other_Branch.Rows.Add(dr_Old_Other_Branch)
                dt_book_Other_Branch = dt_trn_Other_Branch
                amount_Other_Branch = amount_Other_Branch + CDbl(CDbl(dt_stock_Other_Branch.Rows(0).Item("Selling_Price")).ToString("#0.00") * _
                                                            input_Quantity).ToString("#0.00")
            Else
                check_dt_book_Jobber()
            End If
        Else

            check_dt_book_Jobber()
        End If


    End Sub
    Public Sub check_dt_book_Jobber_Qty()
        'Dim dc As DataColumn
        Dim SqlStr As String = ""
        Dim dt_check As New DataTable
        Dim SqlDb As SqlDb = New SqlDb
        Dim dt_Lead_Time As New DataTable
        Dim dt_source As New DataTable
        Dim dt_jobber As New DataTable

        Dim dt_minstk As New DataTable
        SqlStr = ""
        SqlStr &= "SELECT  tbm_jobber_book_indent.ISBN_13"
        SqlStr &= "		,tbm_jobber_book_indent.Book_Title"
        SqlStr &= "		,tbm_jobber_book_indent.Weight"
        'SqlStr &= "		,convert(numeric(18,0),(tbm_jobber_book_indent.Selling_Price*(isnull(tbm_jobber_book_indent.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbm_jobber_book_indent.field1,0)))"
        'SqlStr &= "		+tbm_jobber_book_indent.Selling_Price*(isnull(tbm_jobber_book_indent.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbm_jobber_book_indent.field1,0)))"
        'SqlStr &= "			*Mark_UP/100))  as Selling_price"
        'SqlStr &= "	,convert(numeric(18,0),(tbm_jobber_book_indent.Selling_Price*"
        'SqlStr &= "	(isnull(CR.exchange_rate,0)+((tbm_syst_company.Buffer_Rate/100) *"
        'SqlStr &= "	isnull(CR.exchange_rate,0)))+tbm_jobber_book_indent.Selling_Price*"
        'SqlStr &= "	(isnull(CR.exchange_rate,0)+((tbm_syst_company.Buffer_Rate/100) *"
        'SqlStr &= "	isnull(CR.exchange_rate,0)))*Mark_UP/100))  as Selling_price "
        SqlStr &= "	  ,convert(numeric(18,0),tbm_asbkeo_bookab.Selling_price) as Selling_price "
        SqlStr &= "		,(isnull(tbt_jobber_stockindent.On_hand_Qty,0)+isnull(tbt_jobber_stockindent.On_order_Qty,0))-Minimum_Stock_Jobber as On_hand_Qty,"
        SqlStr &= "		CASE WHEN isnull(tbt_jobber_stockindent.On_hand_Qty,0)-Minimum_Stock_Jobber<" + input_Quantity + " "
        SqlStr &= "			 THEN (SELECT Lead_Time_day FROM tbm_syst_leadtime WHERE Stock_status='Not Available')"
        SqlStr &= "			 ELSE (SELECT Lead_Time_day FROM tbm_syst_leadtime WHERE Stock_status='Available')"
        SqlStr &= "			 END as Lead_Time,"
        SqlStr &= "		tbt_jobber_stockindent.Org_Indent_code as To_Org_AB_code"
        SqlStr &= " FROM	 (select isbn_13,Book_Title,weight,org_indent_code,discount,field1,min(selling_price) as Selling_Price "
        SqlStr &= " from tbm_jobber_book_indent group by isbn_13,Book_Title,weight,org_indent_code,discount,field1) as tbm_jobber_book_indent"
        SqlStr &= " LEFT JOIN ("
        SqlStr &= "		select isbn_13,Org_Indent_Code,isnull(on_order_qty,0) as on_order_qty,on_hand_qty "
        SqlStr &= "		from tbt_jobber_stockindent  ) as tbt_jobber_stockindent"
        SqlStr &= "		ON tbm_jobber_book_indent.ISBN_13=tbt_jobber_stockindent.ISBN_13"
        SqlStr &= "		and tbm_jobber_book_indent.Org_Indent_Code=tbt_jobber_stockindent.Org_Indent_Code"
        SqlStr &= "     LEFT JOIN tbm_syst_saleschannel ON From_Pub_Discount<=tbm_jobber_book_indent.discount	"
        SqlStr &= "		AND To_Pub_Discount>=tbm_jobber_book_indent.discount"
        SqlStr &= "		INNER JOIN tbm_asbkeo_bookab on tbm_jobber_book_indent.ISBN_13 = tbm_asbkeo_bookab.ISBN_13"
        '=================== Start New du 30/11/2009 cal. Exchange
        'SqlStr &= "	left join(select a.Org_indent_code,b.currency_code,b.exchange_rate"
        'SqlStr &= "	from tbm_syst_organizeindent A ,tbm_syst_currency  B"
        'SqlStr &= "	where a.currency_code = b.currency_code ) CR On tbm_jobber_book_indent.Org_Indent_Code =CR.Org_indent_code"
        '=================== End New du 30/11/2009
        SqlStr &= "		,tbm_syst_company"
        SqlStr &= " WHERE	tbm_jobber_book_indent.ISBN_13 = '" + input_ISBN_13 + "'"
        SqlStr &= " AND tbm_syst_saleschannel.Sales_Channel_Code='" + sales_channel + "'"
        SqlStr &= " AND (isnull(tbt_jobber_stockindent.On_hand_Qty, 0) + isnull(tbt_jobber_stockindent.On_order_Qty, 0)) - Minimum_Stock_Jobber > 0"
        SqlStr &= " order by (isnull(tbt_jobber_stockindent.On_hand_Qty, 0) + isnull(tbt_jobber_stockindent.On_order_Qty, 0)) DESC ,tbt_jobber_stockindent.Org_Indent_Code DESC"
        'SqlStr &= "SELECT   tbt_jobber_book_search.ISBN_13,"
        'SqlStr &= "		tbt_jobber_book_search.Book_Title"
        'SqlStr &= "     ,case source when 'Asiabooks' then tbt_jobber_book_search.Weight else tbm_jobber_book_indent.Weight end as Weight "
        'SqlStr &= "		,convert(numeric(18,0),(tbm_jobber_book_indent.Selling_Price*(isnull(tbm_jobber_book_indent.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbm_jobber_book_indent.field1,0)))"
        'SqlStr &= "		+tbm_jobber_book_indent.Selling_Price*(isnull(tbm_jobber_book_indent.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbm_jobber_book_indent.field1,0)))"
        'SqlStr &= "			*Mark_UP/100))  as Selling_price"
        'SqlStr &= "		,(isnull(tbt_jobber_stockindent.On_hand_Qty,0)+isnull(tbt_jobber_stockindent.On_order_Qty,0))-Minimum_Stock_Jobber as On_hand_Qty,"
        'SqlStr &= "		CASE WHEN isnull(tbt_jobber_stockindent.On_hand_Qty,0)-Minimum_Stock_Jobber <" + input_Quantity + " "
        'SqlStr &= "			 THEN (SELECT Lead_Time_day FROM tbm_syst_leadtime WHERE Stock_status='Not Available')"
        'SqlStr &= "			 ELSE (SELECT Lead_Time_day FROM tbm_syst_leadtime WHERE Stock_status='Available')"
        'SqlStr &= "			 END as Lead_Time,"
        'SqlStr &= "		tbt_jobber_stockindent.Org_Indent_code as 	To_Org_AB_code"
        'SqlStr &= " FROM	tbt_jobber_book_search  LEFT JOIN   "
        'SqlStr &= " (select isbn_13,weight,org_indent_code,discount,field1,min(selling_price) as Selling_Price "
        'SqlStr &= " from tbm_jobber_book_indent group by isbn_13,weight,org_indent_code,discount,field1) as tbm_jobber_book_indent"
        'SqlStr &= "		ON tbt_jobber_book_search.ISBN_13=tbm_jobber_book_indent.ISBN_13"
        'SqlStr &= " LEFT JOIN (select isbn_13,Org_Indent_Code,isnull(on_order_qty,0) as on_order_qty,max(on_hand_qty) as on_hand_qty from tbt_jobber_stockindent"
        'SqlStr &= " group by isbn_13,Org_Indent_Code,on_order_qty) as tbt_jobber_stockindent"
        'SqlStr &= "		ON tbt_jobber_book_search.ISBN_13=tbt_jobber_stockindent.ISBN_13"
        ''SqlStr &= "     AND tbm_jobber_book_indent.Org_Indent_code=tbt_jobber_stockindent.Org_Indent_Code"
        'SqlStr &= "     LEFT JOIN tbm_syst_saleschannel ON From_Pub_Discount<=tbm_jobber_book_indent.discount	"
        'SqlStr &= "		AND To_Pub_Discount>=tbm_jobber_book_indent.discount"
        'SqlStr &= "		,tbm_syst_company"
        'SqlStr &= " WHERE	tbt_jobber_book_search.ISBN_13 = '" + input_ISBN_13 + "'"
        'SqlStr &= " AND tbm_syst_saleschannel.Sales_Channel_Code='" + sales_channel + "'"
        'SqlStr &= " AND (isnull(tbt_jobber_stockindent.On_hand_Qty, 0) + isnull(tbt_jobber_stockindent.On_order_Qty, 0)) - Minimum_Stock_Jobber > 0"
        'SqlStr &= " ORDER BY tbt_jobber_stockindent.Org_Indent_code DESC"
        dt_jobber = SqlDb.GetDataTable(SqlStr)

        If dt_jobber.Rows.Count > 0 Then

            Dim dr_Old_Jobber As DataRow
            Jobber_Number = Jobber_Number + 1
            dr_Old_Jobber = dt_trn_Jobber.NewRow()
            dr_Old_Jobber("No") = CInt(Jobber_Number) 'CInt(dt_book_jobber.Rows.Count + 1)
            dr_Old_Jobber("Book_Title") = dt_jobber.Rows(0).Item("Book_Title")
            dr_Old_Jobber("ISBN_13") = dt_jobber.Rows(0).Item("ISBN_13")
            dr_Old_Jobber("Selling_Price") = CDbl(dt_jobber.Rows(0).Item("Selling_Price")).ToString("#0.00")
            dr_Old_Jobber("Lead_Time") = dt_jobber.Rows(0).Item("Lead_Time")
            dr_Old_Jobber("Weight") = CDbl(CDbl(dt_jobber.Rows(0).Item("Weight")).ToString("#0.00") * _
                                      input_qtyIndent).ToString("#0.00")
            dr_Old_Jobber("Quantity") = input_qtyIndent
            dr_Old_Jobber("Amount") = CDbl(CDbl(dt_jobber.Rows(0).Item("Selling_Price")).ToString("#0.00") * _
                                      input_qtyIndent).ToString("#0.00")
            dr_Old_Jobber("To_Org_AB_code") = dt_jobber.Rows(0).Item("To_Org_AB_code")
            dr_Old_Jobber("Status") = "SPECIAL"
            dt_trn_Jobber.Rows.Add(dr_Old_Jobber)
            amount_Jobber = amount_Jobber + CDbl(CDbl(dt_jobber.Rows(0).Item("Selling_Price")).ToString("#0.00") * _
                                            input_qtyIndent).ToString("#,###,##0.00")
            dt_book_jobber = dt_trn_Jobber
        End If
    End Sub
    Public Sub check_dt_book_Jobber()
        'Dim dc As DataColumn
        Dim SqlStr As String = ""
        Dim dt_check As New DataTable
        Dim SqlDb As SqlDb = New SqlDb
        Dim dt_Lead_Time As New DataTable
        Dim dt_source As New DataTable
        Dim dt_jobber As New DataTable

        Dim dt_minstk As New DataTable
        SqlStr = ""
        SqlStr &= "SELECT  tbm_jobber_book_indent.ISBN_13"
        SqlStr &= "		,tbm_jobber_book_indent.Book_Title"
        SqlStr &= "		,tbm_jobber_book_indent.Weight"
        'SqlStr &= "		,convert(numeric(18,0),(tbm_jobber_book_indent.Selling_Price*(isnull(tbm_jobber_book_indent.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbm_jobber_book_indent.field1,0)))"
        'SqlStr &= "		+tbm_jobber_book_indent.Selling_Price*(isnull(tbm_jobber_book_indent.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbm_jobber_book_indent.field1,0)))"
        'SqlStr &= "			*Mark_UP/100))  as Selling_price"
        SqlStr &= "	,convert(numeric(18,0),(tbm_jobber_book_indent.Selling_Price*"
        SqlStr &= "	(isnull(CR.exchange_rate,0)+((tbm_syst_company.Buffer_Rate/100) *"
        SqlStr &= "	isnull(CR.exchange_rate,0)))+tbm_jobber_book_indent.Selling_Price*"
        SqlStr &= "	(isnull(CR.exchange_rate,0)+((tbm_syst_company.Buffer_Rate/100) *"
        SqlStr &= "	isnull(CR.exchange_rate,0)))*Mark_UP/100))  as Selling_price "
        SqlStr &= "		,(isnull(tbt_jobber_stockindent.On_hand_Qty,0)+isnull(tbt_jobber_stockindent.On_order_Qty,0))-Minimum_Stock_Jobber as On_hand_Qty,"
        SqlStr &= "		CASE WHEN isnull(tbt_jobber_stockindent.On_hand_Qty,0)-Minimum_Stock_Jobber<" + input_Quantity + " "
        SqlStr &= "			 THEN (SELECT Lead_Time_day FROM tbm_syst_leadtime WHERE Stock_status='Not Available')"
        SqlStr &= "			 ELSE (SELECT Lead_Time_day FROM tbm_syst_leadtime WHERE Stock_status='Available')"
        SqlStr &= "			 END as Lead_Time,"
        SqlStr &= "		tbt_jobber_stockindent.Org_Indent_code as To_Org_AB_code"
        SqlStr &= " FROM	 (select isbn_13,Book_Title,weight,org_indent_code,discount,field1,min(selling_price) as Selling_Price "
        SqlStr &= " from tbm_jobber_book_indent group by isbn_13,Book_Title,weight,org_indent_code,discount,field1) as tbm_jobber_book_indent"
        SqlStr &= " LEFT JOIN ("
        SqlStr &= "		select isbn_13,Org_Indent_Code,isnull(on_order_qty,0) as on_order_qty,on_hand_qty "
        SqlStr &= "		from tbt_jobber_stockindent  ) as tbt_jobber_stockindent"
        SqlStr &= "		ON tbm_jobber_book_indent.ISBN_13=tbt_jobber_stockindent.ISBN_13"
        SqlStr &= "		and tbm_jobber_book_indent.Org_Indent_Code=tbt_jobber_stockindent.Org_Indent_Code"
        SqlStr &= "     LEFT JOIN tbm_syst_saleschannel ON From_Pub_Discount<=tbm_jobber_book_indent.discount	"
        SqlStr &= "		AND To_Pub_Discount>=tbm_jobber_book_indent.discount"
        '=================== Start New du 30/11/2009 cal. Exchange
        SqlStr &= "	left join(select a.Org_indent_code,b.currency_code,b.exchange_rate"
        SqlStr &= "	from tbm_syst_organizeindent A ,tbm_syst_currency  B"
        SqlStr &= "	where a.currency_code = b.currency_code ) CR On tbm_jobber_book_indent.Org_Indent_Code =CR.Org_indent_code"
        '=================== End New du 30/11/2009
        SqlStr &= "		,tbm_syst_company"
        SqlStr &= " WHERE	tbm_jobber_book_indent.ISBN_13 = '" + input_ISBN_13 + "'"
        SqlStr &= " AND tbm_syst_saleschannel.Sales_Channel_Code='" + sales_channel + "'"
        SqlStr &= " AND (isnull(tbt_jobber_stockindent.On_hand_Qty, 0) + isnull(tbt_jobber_stockindent.On_order_Qty, 0)) - Minimum_Stock_Jobber >= 0"
        SqlStr &= " order by (isnull(tbt_jobber_stockindent.On_hand_Qty, 0) + isnull(tbt_jobber_stockindent.On_order_Qty, 0)) DESC ,tbt_jobber_stockindent.Org_Indent_Code DESC"
        'SqlStr &= "SELECT   tbt_jobber_book_search.ISBN_13,"
        'SqlStr &= "		tbt_jobber_book_search.Book_Title"
        'SqlStr &= "     ,case source when 'Asiabooks' then tbt_jobber_book_search.Weight else tbm_jobber_book_indent.Weight end as Weight "
        'SqlStr &= "		,convert(numeric(18,0),(tbm_jobber_book_indent.Selling_Price*(isnull(tbm_jobber_book_indent.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbm_jobber_book_indent.field1,0)))"
        'SqlStr &= "		+tbm_jobber_book_indent.Selling_Price*(isnull(tbm_jobber_book_indent.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbm_jobber_book_indent.field1,0)))"
        'SqlStr &= "			*Mark_UP/100))  as Selling_price"
        'SqlStr &= "		,(isnull(tbt_jobber_stockindent.On_hand_Qty,0)+isnull(tbt_jobber_stockindent.On_order_Qty,0))-Minimum_Stock_Jobber as On_hand_Qty,"
        'SqlStr &= "		CASE WHEN isnull(tbt_jobber_stockindent.On_hand_Qty,0)-Minimum_Stock_Jobber <" + input_Quantity + " "
        'SqlStr &= "			 THEN (SELECT Lead_Time_day FROM tbm_syst_leadtime WHERE Stock_status='Not Available')"
        'SqlStr &= "			 ELSE (SELECT Lead_Time_day FROM tbm_syst_leadtime WHERE Stock_status='Available')"
        'SqlStr &= "			 END as Lead_Time,"
        'SqlStr &= "		tbt_jobber_stockindent.Org_Indent_code as 	To_Org_AB_code"
        'SqlStr &= " FROM	tbt_jobber_book_search  LEFT JOIN   "
        'SqlStr &= " (select isbn_13,weight,org_indent_code,discount,field1,min(selling_price) as Selling_Price "
        'SqlStr &= " from tbm_jobber_book_indent group by isbn_13,weight,org_indent_code,discount,field1) as tbm_jobber_book_indent"
        'SqlStr &= "		ON tbt_jobber_book_search.ISBN_13=tbm_jobber_book_indent.ISBN_13"
        'SqlStr &= " LEFT JOIN (select isbn_13,Org_Indent_Code,isnull(on_order_qty,0) as on_order_qty,max(on_hand_qty) as on_hand_qty from tbt_jobber_stockindent"
        'SqlStr &= " group by isbn_13,Org_Indent_Code,on_order_qty) as tbt_jobber_stockindent"
        'SqlStr &= "		ON tbt_jobber_book_search.ISBN_13=tbt_jobber_stockindent.ISBN_13"
        ''SqlStr &= "     AND tbm_jobber_book_indent.Org_Indent_code=tbt_jobber_stockindent.Org_Indent_Code"
        'SqlStr &= "     LEFT JOIN tbm_syst_saleschannel ON From_Pub_Discount<=tbm_jobber_book_indent.discount	"
        'SqlStr &= "		AND To_Pub_Discount>=tbm_jobber_book_indent.discount"
        'SqlStr &= "		,tbm_syst_company"
        'SqlStr &= " WHERE	tbt_jobber_book_search.ISBN_13 = '" + input_ISBN_13 + "'"
        'SqlStr &= " AND tbm_syst_saleschannel.Sales_Channel_Code='" + sales_channel + "'"
        'SqlStr &= " AND (isnull(tbt_jobber_stockindent.On_hand_Qty, 0) + isnull(tbt_jobber_stockindent.On_order_Qty, 0)) - Minimum_Stock_Jobber > 0"
        'SqlStr &= " ORDER BY tbt_jobber_stockindent.Org_Indent_code DESC"
        dt_jobber = SqlDb.GetDataTable(SqlStr)

        If dt_jobber.Rows.Count > 0 Then

            Dim dr_Old_Jobber As DataRow
            Jobber_Number = Jobber_Number + 1
            dr_Old_Jobber = dt_trn_Jobber.NewRow()
            dr_Old_Jobber("No") = CInt(Jobber_Number) 'CInt(dt_book_jobber.Rows.Count + 1)
            dr_Old_Jobber("Book_Title") = dt_jobber.Rows(0).Item("Book_Title")
            dr_Old_Jobber("ISBN_13") = dt_jobber.Rows(0).Item("ISBN_13")
            dr_Old_Jobber("Selling_Price") = CDbl(dt_jobber.Rows(0).Item("Selling_Price")).ToString("#0.00")
            dr_Old_Jobber("Lead_Time") = dt_jobber.Rows(0).Item("Lead_Time")
            dr_Old_Jobber("Weight") = CDbl(CDbl(dt_jobber.Rows(0).Item("Weight")).ToString("#0.00") * _
                                      input_Quantity).ToString("#0.00")
            dr_Old_Jobber("Quantity") = input_Quantity
            dr_Old_Jobber("Amount") = CDbl(CDbl(dt_jobber.Rows(0).Item("Selling_Price")).ToString("#0.00") * _
                                      input_Quantity).ToString("#0.00")
            dr_Old_Jobber("To_Org_AB_code") = dt_jobber.Rows(0).Item("To_Org_AB_code")
            dr_Old_Jobber("Status") = Status
            dt_trn_Jobber.Rows.Add(dr_Old_Jobber)
            amount_Jobber = amount_Jobber + CDbl(CDbl(dt_jobber.Rows(0).Item("Selling_Price")).ToString("#0.00") * _
                                            input_Quantity).ToString("#,###,##0.00")
            dt_book_jobber = dt_trn_Jobber
        End If
    End Sub
    Public Sub check_dt_book_Jobber_Indent()
        'Dim dc As DataColumn
        Dim SqlStr As String = ""
        Dim dt_check As New DataTable
        Dim SqlDb As SqlDb = New SqlDb
        Dim dt_Lead_Time As New DataTable
        Dim dt_source As New DataTable
        Dim dt_jobber As New DataTable

        Dim dt_minstk As New DataTable
        SqlStr = ""
        SqlStr &= "SELECT  tbm_jobber_book_indent.ISBN_13"
        SqlStr &= "		,tbm_jobber_book_indent.Book_Title"
        SqlStr &= "		,tbm_jobber_book_indent.Weight"
        'SqlStr &= "		,convert(numeric(18,0),(tbm_jobber_book_indent.Selling_Price*(isnull(tbm_jobber_book_indent.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbm_jobber_book_indent.field1,0)))"
        'SqlStr &= "		+tbm_jobber_book_indent.Selling_Price*(isnull(tbm_jobber_book_indent.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbm_jobber_book_indent.field1,0)))"
        'SqlStr &= "			*Mark_UP/100))  as Selling_price"
        'SqlStr &= "	,convert(numeric(18,0),(tbm_jobber_book_indent.Selling_Price*"
        'SqlStr &= "	(isnull(CR.exchange_rate,0)+((tbm_syst_company.Buffer_Rate/100) *"
        'SqlStr &= "	isnull(CR.exchange_rate,0)))+tbm_jobber_book_indent.Selling_Price*"
        'SqlStr &= "	(isnull(CR.exchange_rate,0)+((tbm_syst_company.Buffer_Rate/100) *"
        'SqlStr &= "	isnull(CR.exchange_rate,0)))*Mark_UP/100))  as Selling_price "
        SqlStr &= "	  ,convert(numeric(18,0),tbm_asbkeo_bookab.Selling_price) as Selling_price "
        SqlStr &= "		,(isnull(tbt_jobber_stockindent.On_hand_Qty,0)+isnull(tbt_jobber_stockindent.On_order_Qty,0))-Minimum_Stock_Jobber as On_hand_Qty,"
        SqlStr &= "		CASE WHEN isnull(tbt_jobber_stockindent.On_hand_Qty,0)-Minimum_Stock_Jobber<" + input_Quantity + " "
        SqlStr &= "			 THEN (SELECT Lead_Time_day FROM tbm_syst_leadtime WHERE Stock_status='Not Available')"
        SqlStr &= "			 ELSE (SELECT Lead_Time_day FROM tbm_syst_leadtime WHERE Stock_status='Available')"
        SqlStr &= "			 END as Lead_Time,"
        SqlStr &= "		tbt_jobber_stockindent.Org_Indent_code as To_Org_AB_code"
        SqlStr &= " FROM	 (select isbn_13,Book_Title,weight,org_indent_code,discount,field1,min(selling_price) as Selling_Price "
        SqlStr &= " from tbm_jobber_book_indent group by isbn_13,Book_Title,weight,org_indent_code,discount,field1) as tbm_jobber_book_indent"
        SqlStr &= " LEFT JOIN ("
        SqlStr &= "		select isbn_13,Org_Indent_Code,isnull(on_order_qty,0) as on_order_qty,on_hand_qty "
        SqlStr &= "		from tbt_jobber_stockindent  ) as tbt_jobber_stockindent"
        SqlStr &= "		ON tbm_jobber_book_indent.ISBN_13=tbt_jobber_stockindent.ISBN_13"
        SqlStr &= "		and tbm_jobber_book_indent.Org_Indent_Code=tbt_jobber_stockindent.Org_Indent_Code"
        SqlStr &= "     LEFT JOIN tbm_syst_saleschannel ON From_Pub_Discount<=tbm_jobber_book_indent.discount	"
        SqlStr &= "		AND To_Pub_Discount>=tbm_jobber_book_indent.discount"
        SqlStr &= "		INNER JOIN tbm_asbkeo_bookab on tbm_jobber_book_indent.ISBN_13 = tbm_asbkeo_bookab.ISBN_13"
        '=================== Start New du 30/11/2009 cal. Exchange
        'SqlStr &= "	left join(select a.Org_indent_code,b.currency_code,b.exchange_rate"
        'SqlStr &= "	from tbm_syst_organizeindent A ,tbm_syst_currency  B"
        'SqlStr &= "	where a.currency_code = b.currency_code ) CR On tbm_jobber_book_indent.Org_Indent_Code =CR.Org_indent_code"
        '=================== End New du 30/11/2009
        SqlStr &= "		,tbm_syst_company"
        SqlStr &= " WHERE	tbm_jobber_book_indent.ISBN_13 = '" + input_ISBN_13 + "'"
        SqlStr &= " AND tbm_syst_saleschannel.Sales_Channel_Code='" + sales_channel + "'"
        SqlStr &= " AND (isnull(tbt_jobber_stockindent.On_hand_Qty, 0) + isnull(tbt_jobber_stockindent.On_order_Qty, 0)) - Minimum_Stock_Jobber > 0"
        SqlStr &= " order by (isnull(tbt_jobber_stockindent.On_hand_Qty, 0) + isnull(tbt_jobber_stockindent.On_order_Qty, 0)) DESC ,tbt_jobber_stockindent.Org_Indent_Code DESC"
        'SqlStr &= "SELECT   tbt_jobber_book_search.ISBN_13,"
        'SqlStr &= "		tbt_jobber_book_search.Book_Title"
        'SqlStr &= "     ,case source when 'Asiabooks' then tbt_jobber_book_search.Weight else tbm_jobber_book_indent.Weight end as Weight "
        'SqlStr &= "		,convert(numeric(18,0),(tbm_jobber_book_indent.Selling_Price*(isnull(tbm_jobber_book_indent.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbm_jobber_book_indent.field1,0)))"
        'SqlStr &= "		+tbm_jobber_book_indent.Selling_Price*(isnull(tbm_jobber_book_indent.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbm_jobber_book_indent.field1,0)))"
        'SqlStr &= "			*Mark_UP/100))  as Selling_price"
        'SqlStr &= "		,(isnull(tbt_jobber_stockindent.On_hand_Qty,0)+isnull(tbt_jobber_stockindent.On_order_Qty,0))-Minimum_Stock_Jobber as On_hand_Qty,"
        'SqlStr &= "		CASE WHEN isnull(tbt_jobber_stockindent.On_hand_Qty,0)-Minimum_Stock_Jobber <" + input_Quantity + " "
        'SqlStr &= "			 THEN (SELECT Lead_Time_day FROM tbm_syst_leadtime WHERE Stock_status='Not Available')"
        'SqlStr &= "			 ELSE (SELECT Lead_Time_day FROM tbm_syst_leadtime WHERE Stock_status='Available')"
        'SqlStr &= "			 END as Lead_Time,"
        'SqlStr &= "		tbt_jobber_stockindent.Org_Indent_code as 	To_Org_AB_code"
        'SqlStr &= " FROM	tbt_jobber_book_search  LEFT JOIN   "
        'SqlStr &= " (select isbn_13,weight,org_indent_code,discount,field1,min(selling_price) as Selling_Price "
        'SqlStr &= " from tbm_jobber_book_indent group by isbn_13,weight,org_indent_code,discount,field1) as tbm_jobber_book_indent"
        'SqlStr &= "		ON tbt_jobber_book_search.ISBN_13=tbm_jobber_book_indent.ISBN_13"
        'SqlStr &= " LEFT JOIN (select isbn_13,Org_Indent_Code,isnull(on_order_qty,0) as on_order_qty,max(on_hand_qty) as on_hand_qty from tbt_jobber_stockindent"
        'SqlStr &= " group by isbn_13,Org_Indent_Code,on_order_qty) as tbt_jobber_stockindent"
        'SqlStr &= "		ON tbt_jobber_book_search.ISBN_13=tbt_jobber_stockindent.ISBN_13"
        ''SqlStr &= "     AND tbm_jobber_book_indent.Org_Indent_code=tbt_jobber_stockindent.Org_Indent_Code"
        'SqlStr &= "     LEFT JOIN tbm_syst_saleschannel ON From_Pub_Discount<=tbm_jobber_book_indent.discount	"
        'SqlStr &= "		AND To_Pub_Discount>=tbm_jobber_book_indent.discount"
        'SqlStr &= "		,tbm_syst_company"
        'SqlStr &= " WHERE	tbt_jobber_book_search.ISBN_13 = '" + input_ISBN_13 + "'"
        'SqlStr &= " AND tbm_syst_saleschannel.Sales_Channel_Code='" + sales_channel + "'"
        'SqlStr &= " AND (isnull(tbt_jobber_stockindent.On_hand_Qty, 0) + isnull(tbt_jobber_stockindent.On_order_Qty, 0)) - Minimum_Stock_Jobber > 0"
        'SqlStr &= " ORDER BY tbt_jobber_stockindent.Org_Indent_code DESC"
        dt_jobber = SqlDb.GetDataTable(SqlStr)

        If dt_jobber.Rows.Count > 0 Then

            Dim dr_Old_Jobber As DataRow
            Jobber_Number = Jobber_Number + 1
            dr_Old_Jobber = dt_trn_Jobber.NewRow()
            dr_Old_Jobber("No") = CInt(Jobber_Number) 'CInt(dt_book_jobber.Rows.Count + 1)
            dr_Old_Jobber("Book_Title") = dt_jobber.Rows(0).Item("Book_Title")
            dr_Old_Jobber("ISBN_13") = dt_jobber.Rows(0).Item("ISBN_13")
            dr_Old_Jobber("Selling_Price") = CDbl(dt_jobber.Rows(0).Item("Selling_Price")).ToString("#0.00")
            dr_Old_Jobber("Lead_Time") = dt_jobber.Rows(0).Item("Lead_Time")
            dr_Old_Jobber("Weight") = CDbl(CDbl(dt_jobber.Rows(0).Item("Weight")).ToString("#0.00") * _
                                      input_Quantity).ToString("#0.00")
            dr_Old_Jobber("Quantity") = input_Quantity
            dr_Old_Jobber("Amount") = CDbl(CDbl(dt_jobber.Rows(0).Item("Selling_Price")).ToString("#0.00") * _
                                      input_Quantity).ToString("#0.00")
            dr_Old_Jobber("To_Org_AB_code") = dt_jobber.Rows(0).Item("To_Org_AB_code")
            dr_Old_Jobber("Status") = Status
            dt_trn_Jobber.Rows.Add(dr_Old_Jobber)
            amount_Jobber = amount_Jobber + CDbl(CDbl(dt_jobber.Rows(0).Item("Selling_Price")).ToString("#0.00") * _
                                            input_Quantity).ToString("#,###,##0.00")
            dt_book_jobber = dt_trn_Jobber
        End If
    End Sub

    Public Function CheckSumStockAB()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        If sales_channel = ConfigurationSettings.AppSettings("UserEmployee").ToString Then
            sqlCommand = " SELECT isnull(sum(qty),0) as qty FROM tbt_jobber_stockab WHERE ISBN_13='" + input_ISBN_13 + "' "
            sqlCommand &= " AND Org_AB_code<>'Ho-Internet'"
        ElseIf sales_channel = ConfigurationSettings.AppSettings("UserDirectSale").ToString _
            Or sales_channel = ConfigurationSettings.AppSettings("UserInternet").ToString Then
            sqlCommand = "	SELECT isnull(sum(qty),0) as qty  FROM tbt_jobber_stockab WHERE ISBN_13='" + input_ISBN_13 + "'"
            sqlCommand &= " AND Org_AB_code='Ho-Internet' "
        Else
            sqlCommand = "SELECT isnull(sum(qty),0) as qty FROM tbt_jobber_stockab WHERE ISBN_13='" + input_ISBN_13 + "'"
        End If
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function

    '/////////promptnow/////////
    Function _dt_ebook_detail()

        Dim tb_temp = New DataTable
        Dim condition As String = ""
        Dim SqlDb As SqlDb = New SqlDb
        Dim SqlStr As String = ""
        Dim data As DataTable = New DataTable
        Dim datatable As DataTable = New DataTable("datatable")
        Dim dc As DataColumn
        Dim dr As DataRow

        dc = New DataColumn()
        dc.DataType = System.Type.GetType("System.String")
        dc.ColumnName = "ISBN_13"
        dc.AutoIncrement = False
        dc.Caption = "ISBN_13"
        dc.ReadOnly = False
        dc.Unique = False
        datatable.Columns.Add(dc)

        dc = New DataColumn()
        dc.DataType = System.Type.GetType("System.String")
        dc.ColumnName = "Book_Title"
        dc.AutoIncrement = False
        dc.Caption = "Book_Title"
        dc.ReadOnly = False
        dc.Unique = False
        datatable.Columns.Add(dc)

        dc = New DataColumn()
        dc.DataType = System.Type.GetType("System.String")
        dc.ColumnName = "Author"
        dc.AutoIncrement = False
        dc.Caption = "Author"
        dc.ReadOnly = False
        dc.Unique = False
        datatable.Columns.Add(dc)

        dc = New DataColumn()
        dc.DataType = System.Type.GetType("System.String")
        dc.ColumnName = "Category"
        dc.AutoIncrement = False
        dc.Caption = "Category"
        dc.ReadOnly = False
        dc.Unique = False
        datatable.Columns.Add(dc)

        dc = New DataColumn()
        dc.DataType = System.Type.GetType("System.String")
        dc.ColumnName = "Copy_Rigths"
        dc.AutoIncrement = False
        dc.Caption = "Copy_Rigths"
        dc.ReadOnly = False
        dc.Unique = False
        datatable.Columns.Add(dc)

        dc = New DataColumn()
        dc.DataType = System.Type.GetType("System.String")
        dc.ColumnName = "Page"
        dc.AutoIncrement = False
        dc.Caption = "Page"
        dc.ReadOnly = False
        dc.Unique = False
        datatable.Columns.Add(dc)

        dc = New DataColumn()
        dc.DataType = System.Type.GetType("System.String")
        dc.ColumnName = "Size"
        dc.AutoIncrement = False
        dc.Caption = "Size"
        dc.ReadOnly = False
        dc.Unique = False
        datatable.Columns.Add(dc)

        dc = New DataColumn()
        dc.DataType = System.Type.GetType("System.String")
        dc.ColumnName = "Language"
        dc.AutoIncrement = False
        dc.Caption = "Language"
        dc.ReadOnly = False
        dc.Unique = False
        datatable.Columns.Add(dc)

        dc = New DataColumn()
        dc.DataType = System.Type.GetType("System.String")
        dc.ColumnName = "Selling_Price"
        dc.AutoIncrement = False
        dc.Caption = "Selling_Price"
        dc.ReadOnly = False
        dc.Unique = False
        datatable.Columns.Add(dc)

        dc = New DataColumn()
        dc.DataType = System.Type.GetType("System.String")
        dc.ColumnName = "Pub_Date"
        dc.AutoIncrement = False
        dc.Caption = "Pub_Date"
        dc.ReadOnly = False
        dc.Unique = False
        datatable.Columns.Add(dc)

        dc = New DataColumn()
        dc.DataType = System.Type.GetType("System.String")
        dc.ColumnName = "Publisher"
        dc.AutoIncrement = False
        dc.Caption = "Publisher"
        dc.ReadOnly = False
        dc.Unique = False
        datatable.Columns.Add(dc)

        dc = New DataColumn()
        dc.DataType = System.Type.GetType("System.String")
        dc.ColumnName = "Synopsis"
        dc.AutoIncrement = False
        dc.Caption = "Synopsis"
        dc.ReadOnly = False
        dc.Unique = False
        datatable.Columns.Add(dc)

        dc = New DataColumn()
        dc.DataType = System.Type.GetType("System.String")
        dc.ColumnName = "Image"
        dc.AutoIncrement = False
        dc.Caption = "Image"
        dc.ReadOnly = False
        dc.Unique = False
        datatable.Columns.Add(dc)

        dc = New DataColumn()
        dc.DataType = System.Type.GetType("System.String")
        dc.ColumnName = "Source"
        dc.AutoIncrement = False
        dc.Caption = "Source"
        dc.ReadOnly = False
        dc.Unique = False
        datatable.Columns.Add(dc)

        dc = New DataColumn()
        dc.DataType = System.Type.GetType("System.String")
        dc.ColumnName = "On_Book"
        dc.AutoIncrement = False
        dc.Caption = "On_Book"
        dc.ReadOnly = False
        dc.Unique = False
        datatable.Columns.Add(dc)

        dc = New DataColumn()
        dc.DataType = System.Type.GetType("System.String")
        dc.ColumnName = "Available_Status"
        dc.AutoIncrement = False
        dc.Caption = "Available_Status"
        dc.ReadOnly = False
        dc.Unique = False
        datatable.Columns.Add(dc)

        Try
            SqlStr &= "SELECT top(1) "
            SqlStr &= "ebook.isbn_13 "
            SqlStr &= ",ebook.book_title "
            SqlStr &= ",ebook.author "
            SqlStr &= ",'unknown' as category " '////// dump data as cat
            SqlStr &= ",ebook.copy_rigths "
            SqlStr &= ",ebook.page "
            SqlStr &= ",ebook.size "
            SqlStr &= ",ebook.language "
            SqlStr &= ",ebook.pub_date "
            SqlStr &= ",ebook.publisher "
            SqlStr &= ",ebook.synopsis "
            SqlStr &= ",ebook.image "
            SqlStr &= ",ebook.source "
            SqlStr &= ",ebook.on_book "
            SqlStr &= ",case ebook.source when 'Asiabooks' then convert(numeric(13,2),ebook.selling_price) "
            SqlStr &= "else convert(numeric(18,2),(ebook.selling_price * (isnull(currency.exchange_rate,0) + "
            SqlStr &= "((com.Buffer_Rate/100) * isnull(currency.exchange_rate,0))) + "
            SqlStr &= "ebook.selling_price * (isnull(currency.exchange_rate,0) + ((com.Buffer_Rate/100) * "
            SqlStr &= "isnull(currency.exchange_rate,0))) * markup.mark_up/100)) end as Selling_price "
            SqlStr &= ", case when ((territory.country_code = 'WORLD') "
            SqlStr &= "or (territory.status = 0 and territory.country_code <> '" + country + "') "
            SqlStr &= "or (territory.status = 1 and territory.country_code = '" + country + "')) "
            SqlStr &= "then 'available' else 'not available'  end as available_status "

            SqlStr &= "FROM "
            SqlStr &= "tbm_syst_company com "
            SqlStr &= ",( select bookid as ebook_id, isbn_13 , book_title , convert(numeric(13,2), selling_price) as selling_price , publication_date as pub_date , format_type "
            SqlStr &= ", publisher_name as publisher , isbn_10 as image , supplier_code as source , isnull(on_book,0) as on_book , isnull(discount,0) as discount "
            SqlStr &= ", case when author is null then '-' else author end as author "
            SqlStr &= ", case when right(publication_date,4) = '0000' then '-' else right(publication_date,4) end as copy_rigths "
            SqlStr &= ", case when cast(page_qty as varchar) is null then 'unknown' else cast(page_qty as varchar) end as page "
            SqlStr &= ", case when cast(file_size as varchar) is null then 'unknown' else cast(file_size as varchar) end as size "
            SqlStr &= ", case when language is null then 'unknown' else language end as language "
            SqlStr &= ", case when synopsis is null then '-' else synopsis end as synopsis "
            SqlStr &= "from ebook_store where isbn_13 = " + keyword_1 + " "
            SqlStr &= "and (status = 'active' or status is null)) as ebook "

            SqlStr &= "left join ( select distinct mark_up , From_Pub_Discount , To_Pub_Discount , Sales_Channel_Code "
            SqlStr &= "from tbm_syst_saleschannel with (nolock) where Sales_Channel_Code = 'EBOOK') as markup "
            SqlStr &= "on markup.From_Pub_Discount <= ebook.discount "
            SqlStr &= "and markup.To_Pub_Discount >= ebook.discount "

            SqlStr &= "left join ( select distinct Currency_Code , Org_Indent_Code "
            SqlStr &= "from tbm_syst_organizeindent ) as organize "
            SqlStr &= "on organize.Org_Indent_Code = ebook.source "

            SqlStr &= "left join ( select distinct Exchange_Rate , Currency_Code from tbm_syst_currency ) as currency "
            SqlStr &= "on organize.Currency_Code = currency.Currency_Code "

            SqlStr &= "left join ebook_type on ebook.format_type = ebook_type.formatid "

            SqlStr &= "left join (select distinct bookid as ebook_id , country_code , status "
            SqlStr &= "from ebook_territory) as territory "
            SqlStr &= "on ebook.ebook_id = territory.ebook_id "

            SqlStr &= "WHERE "
            SqlStr &= "case when ((territory.country_code = 'WORLD') "
            SqlStr &= "or (territory.status = 0 and territory.country_code <> '" + country + "') "
            SqlStr &= "or (territory.status = 1 and territory.country_code = '" + country + "')) "
            SqlStr &= "then 'available' else 'not available' end = 'available' "

            'SqlStr &= "ORDER BY ebook.book_title "

            data = SqlDb.GetDataTable(SqlStr)

            If data.Rows.Count > 0 Then
                For i = 0 To data.Rows.Count - 1
                    dr = datatable.NewRow()
                    dr("ISBN_13") = data.Rows(i).Item("ISBN_13").ToString
                    dr("Book_Title") = data.Rows(i).Item("Book_Title").ToString
                    dr("Author") = data.Rows(i).Item("Author").ToString
                    dr("Category") = data.Rows(i).Item("Category").ToString
                    dr("Copy_Rigths") = data.Rows(i).Item("Copy_Rigths").ToString
                    dr("Page") = data.Rows(i).Item("Page").ToString
                    dr("Size") = data.Rows(i).Item("Size").ToString
                    dr("Language") = data.Rows(i).Item("Language").ToString
                    dr("Selling_Price") = data.Rows(i).Item("Selling_Price").ToString
                    dr("Pub_Date") = data.Rows(i).Item("Pub_Date").ToString
                    dr("Publisher") = data.Rows(i).Item("Publisher").ToString
                    dr("Synopsis") = data.Rows(i).Item("Synopsis").ToString
                    dr("Image") = data.Rows(i).Item("Image").ToString
                    dr("Source") = data.Rows(i).Item("Source").ToString
                    dr("On_Book") = data.Rows(i).Item("On_Book").ToString
                    dr("Available_Status") = data.Rows(i).Item("Available_Status").ToString
                    datatable.Rows.Add(dr)
                Next
            End If
        Catch ex As Exception
            Throw New Exception("Error ebook search : " & ex.Message.ToString)
        End Try

        Return datatable
    End Function

    '/////////promptnow/////////
    Function wish_ebook()
        Dim SqlStr As String = ""
        Dim datatable As New DataTable
        Dim SqlDb As SqlDb = New SqlDb

        SqlStr &= "SELECT "
        SqlStr &= "ebook.isbn_13 "
        SqlStr &= ",ebook.book_title "
        SqlStr &= ",ebook.author "
        SqlStr &= ",ebook_type.type as format_type "
        SqlStr &= ",case when (ebook.Supplier_Code is null or ebook.Supplier_Code = '') then '-' else ebook.Supplier_Code end as Source"
        SqlStr &= ",case when ebook.image is null then 'no_image.jpg' else ebook.image end as Image "
        SqlStr &= ",(((ebook.selling_price*currency.exchange_rate)+((com.buffer_rate/100)+currency.exchange_rate))+((ebook.selling_price*currency.exchange_rate)*(markup.mark_up/100))) as selling_price "
        SqlStr &= ",ebook.ebook_id "

        SqlStr &= "FROM "
        SqlStr &= "tbm_syst_company com "
        SqlStr &= ", (select isbn_13 , bookid as ebook_id , book_title , discount , selling_price "
        SqlStr &= ", author , format_type , supplier_code , isbn_10 as image "
        SqlStr &= "from ebook_store where format_type = '" + keyword_1 + "' "
        SqlStr &= "and (status = 'active' or status is null)) as ebook "

        SqlStr &= "left join ( select mark_up , From_Pub_Discount , To_Pub_Discount , Sales_Channel_Code "
        SqlStr &= "from tbm_syst_saleschannel with (nolock) where Sales_Channel_Code = 'EBOOK') as markup "
        SqlStr &= "on markup.From_Pub_Discount <= ebook.discount "
        SqlStr &= "and markup.To_Pub_Discount >= ebook.discount "

        SqlStr &= "left join ( select distinct Currency_Code , Org_Indent_Code "
        SqlStr &= "from tbm_syst_organizeindent ) as organize "
        SqlStr &= "on organize.Org_Indent_Code = ebook.supplier_code "

        SqlStr &= "left join ( select Exchange_Rate , Currency_Code from tbm_syst_currency ) as currency "
        SqlStr &= "on organize.Currency_Code = currency.Currency_Code "

        SqlStr &= "left join ebook_type on ebook.format_type = ebook_type.formatid "
        SqlStr &= "left join ebook_territory as territory on ebook.ebook_id = territory.bookid "

        datatable = SqlDb.GetDataTable(SqlStr)

        Return datatable
    End Function

    '/////////promptnow/////////    
    Function getcountry_date()
        Dim SqlStr As String = ""
        Dim datatable As New DataTable
        Dim SqlDb As SqlDb = New SqlDb

        SqlStr &= "SELECT "

        SqlStr &= "case when (territory.country_code is null and territory.status = '0') "
        SqlStr &= "or (territory.status = '1') or (territory.country_code = 'WORLD') "
        SqlStr &= "then 'sale' else 'not sale' end as status "

        SqlStr &= ",case when (territory.country_code = 'WORLD' or territory.country_code = 'ROW' or territory.country_code is null) "
        SqlStr &= "then 'around the world' else country.fullname end as country "

        SqlStr &= "FROM "
        SqlStr &= "ebook_territory territory "

        SqlStr &= "left join (select shortcode,fullname from ebook_country) as country "
        SqlStr &= "on territory.country_code = country.shortcode "

        SqlStr &= "WHERE "
        SqlStr &= "territory.bookid = " + isbn_13 + " "

        SqlStr &= "ORDER BY territory.status "

        datatable = SqlDb.GetDataTable(SqlStr)

        Return datatable
    End Function

    '/////////promptnow/////////
    Function dropdown()
        Dim SqlStr As String = ""
        Dim datatable As New DataTable
        Dim SqlDb As SqlDb = New SqlDb

        Try
            SqlStr &= " SELECT "
            SqlStr &= " ebook.ebook_id "
            SqlStr &= " , ebook_type.format "
            SqlStr &= " ,case ebook.supplier_code when 'Asiabooks' then convert(numeric(13,2),ebook.selling_price) "
            SqlStr &= " else convert(numeric(18,2),(ebook.selling_price * (isnull(currency.exchange_rate,0) + "
            SqlStr &= " ((com.Buffer_Rate/100) * isnull(currency.exchange_rate,0))) + "
            SqlStr &= " ebook.selling_price * (isnull(currency.exchange_rate,0) + ((com.Buffer_Rate/100) * "
            SqlStr &= " isnull(currency.exchange_rate,0))) * markup.mark_up/100)) end as Selling_price "

            SqlStr &= " FROM "
            SqlStr &= " (select distinct bookid as ebook_id , isbn_13 , format_type "
            SqlStr &= " , discount , supplier_code , convert(numeric(13,2), selling_price) as selling_price "
            SqlStr &= " from ebook_store where isbn_13 = " + isbn_13 + ") as ebook "

            SqlStr &= " left join ( select mark_up , From_Pub_Discount , To_Pub_Discount , Sales_Channel_Code "
            SqlStr &= " from tbm_syst_saleschannel with (nolock) where Sales_Channel_Code = 'EBOOK') as markup "
            SqlStr &= " on markup.From_Pub_Discount <= ebook.discount "
            SqlStr &= " and markup.To_Pub_Discount >= ebook.discount "

            SqlStr &= " left join ( select distinct Currency_Code , Org_Indent_Code "
            SqlStr &= " from tbm_syst_organizeindent ) as organize "
            SqlStr &= " on organize.Org_Indent_Code = ebook.supplier_code "

            SqlStr &= " left join ( select Exchange_Rate , Currency_Code from tbm_syst_currency ) as currency "
            SqlStr &= " on organize.Currency_Code = currency.Currency_Code "

            SqlStr &= " left join (select formatid as format_id  "
            SqlStr &= " , type as format from ebook_type) as ebook_type "
            SqlStr &= " on ebook.format_type = ebook_type.format_id "

            SqlStr &= " , tbm_syst_company com "

            SqlStr &= " ORDER BY ebook.selling_price "

            datatable = SqlDb.GetDataTable(SqlStr)

        Catch ex As Exception
            Throw New Exception("Error dropdown : " & ex.Message.ToString)
        End Try
        

        Return datatable
    End Function

    '/////////promptnow/////////
    Function small_data()
        Dim SqlStr As String = ""
        Dim datatable As New DataTable
        Dim SqlDb As SqlDb = New SqlDb

        Try
            SqlStr &= " SELECT "
            SqlStr &= " case when ebook.page is null then 'unknown' else ebook.page end as page "
            SqlStr &= " , case when ebook.size is null then 'unknown' else ebook.size end as size "
            SqlStr &= " , case when ebook.language is null then 'unknown' else ebook.language end as language "
            SqlStr &= " , case when ebook.synopsis is null then '-' else ebook.synopsis end as synopsis "
            SqlStr &= " , case when ebook.author is null then 'unknown' else ebook.author end as author "

            SqlStr &= " FROM "
            SqlStr &= " (select bookid as ebook_id , author , cast(page_qty as varchar) as page "
            SqlStr &= " , cast(file_size as varchar) as size , language , synopsis "
            SqlStr &= " from ebook_store) as ebook "

            SqlStr &= " WHERE ebook.ebook_id = " + isbn_13 + " "

            datatable = SqlDb.GetDataTable(SqlStr)

        Catch ex As Exception
            Throw New Exception("Error small data : " & ex.Message.ToString)
        End Try

        Return datatable
    End Function

    '/////////promptnow/////////
    Function promotion()
        Dim SqlStr As String = ""
        Dim datatable As New DataTable
        Dim SqlDb As SqlDb = New SqlDb
        Dim promo As Double = 0
        Try
            SqlStr &= " SELECT "
            SqlStr &= " buy_book "

            SqlStr &= " FROM "
            SqlStr &= " ebook_promotion "

            SqlStr &= " WHERE promotion = 2 AND status = 1 "

            datatable = SqlDb.GetDataTable(SqlStr)
            If datatable.Rows.Count > 0 Then
                promo = CDbl(datatable.Rows(0).Item("buy_book"))
            Else
                promo = 0
            End If

        Catch ex As Exception
            Throw New Exception("Error promotion data : " & ex.Message.ToString)
        End Try

        Return promo
    End Function

    '/////////promptnow/////////
    Function promotion_getfree()
        Dim SqlStr As String = ""
        Dim datatable As New DataTable
        Dim SqlDb As SqlDb = New SqlDb
        Dim promo As Integer = 0
        Try
            SqlStr &= " SELECT "
            SqlStr &= " free_ebook "

            SqlStr &= " FROM "
            SqlStr &= " ebook_promotion "

            SqlStr &= " WHERE promotion = 2 AND status = 1 "

            datatable = SqlDb.GetDataTable(SqlStr)
            promo = CInt(datatable.Rows(0).Item("free_ebook"))

        Catch ex As Exception
            Throw New Exception("Error promotion data : " & ex.Message.ToString)
        End Try

        Return promo
    End Function

    Function ebook_detail()
        Dim sql As String = ""
        Dim datatable As New DataTable
        Dim SqlDb As SqlDb = New SqlDb

        sql &= " SELECT DISTINCT TOP(1) "
        sql &= " case search.source when 'Asiabooks' then convert(numeric(13,2),search.selling) "
        sql &= " else convert(numeric(18,0),((search.selling * isnull(search.exchange_rate,0)) + "
        sql &= " ((search.selling * isnull(search.exchange_rate,0)) * search.mark_up/100))) end as selling_price "

        sql &= " , case search.source when 'Asiabooks' then convert(numeric(13,2),search.selling) "
        sql &= " else convert(numeric(18,0),((search.selling * isnull(search.exchange_rate,0)) + "
        sql &= " ((search.selling * isnull(search.exchange_rate,0)) * search.mark_up/100))) end as selling_price_ecomn "

        sql &= " , case when search.other_format is null "
        sql &= " then 'none' else search.other_format end as other_format "

        sql &= " , search.ebook_id , search.isbn_13 , search.book_title , search.author , search.publisher_name "
        sql &= " , search.image , search.source , search.discount as ecom_discount , search.ebook_format "
        sql &= " , search.copy_rigths , search.page_qty , search.size , search.publication_date "
        sql &= " , search.language , search.synopsis , search.size "
        sql &= " , '-' as subject_name " '//// รอข้อมูล category

        sql &= " FROM "
        sql &= " (select distinct ebook.bookid as ebook_id , ebook.isbn_13 , ebook.book_title , ebook.publication_date "
        sql &= " , ebook.supplier_code as source , cast(ebook.on_book as varchar) as other_format "
        sql &= " , case ebook.author when '' then '-' else ebook.author end as author "
        sql &= " , case ebook.publisher_name when '' then '-' else ebook.publisher_name end as publisher_name "
        sql &= " , case when right(ebook.publication_date,4) = '0000' then '-' else right(ebook.publication_date,4) end as copy_rigths "
        sql &= " , case when cast(ebook.page_qty as varchar) is null then '-' else cast(ebook.page_qty as varchar) end as page_qty "
        sql &= " , case when cast(ebook.file_size as varchar) is null then '-' else cast(ebook.file_size as varchar) end as size "
        sql &= " , case when ebook.language is null then '-' else ebook.language end as language "
        sql &= " , case when ebook.synopsis is null then '-' else ebook.synopsis end as synopsis "
        sql &= " , convert(numeric(13,2) , ebook.selling_price) as selling , ebook.isbn_10 as image  "
        sql &= " , channel.mark_up , ebook.discount , channel.from_pub_discount  "
        sql &= " , channel.to_pub_discount , currency.exchange_rate , type.type as ebook_format "

        sql &= " , ROW_NUMBER() OVER(PARTITION BY ebook.isbn_13 ORDER BY ebook.selling_price ASC) as seq "

        sql &= " from ebook_store ebook with (nolock) "
        sql &= " , tbm_syst_saleschannel channel with (nolock) "
        sql &= " , tbm_syst_organizeindent organize with (nolock) "
        sql &= " , tbm_syst_currency currency with (nolock) "
        sql &= " , ebook_type type with (nolock) "

        sql &= " where (ebook.discount >= channel.from_pub_discount and ebook.discount <= channel.to_pub_discount) "
        sql &= " and (ebook.status = 'active' or ebook.status is null) and channel.sales_channel_code = 'EBOOK' "
        sql &= " and ebook.supplier_code = organize.org_indent_code and organize.currency_code = currency.currency_code "
        sql &= " and ebook.format_type = type.formatid "
        sql &= " and convert(numeric(13,2) , ebook.selling_price) > 0 "
        sql &= " and ebook.isbn_13 = " + ebook_isbn + " "
        If ebook_format <> "" Then
            sql &= " and ebook.format_type = " + ebook_format + " "
        End If
        'sql &= " order by ebook.selling_price ASC ) as search "
        sql &= " ) as search "
        Try
            datatable = SqlDb.GetDataTable(sql)
        Catch ex As Exception
            Throw New Exception("ebook_detail_all error : " & ex.Message.ToString)
        End Try

        Return datatable
    End Function
End Class