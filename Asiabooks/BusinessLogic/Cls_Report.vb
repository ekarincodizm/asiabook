Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.Configuration
Public Class Cls_Report
    Private strJobber As String
    Private strOrder_Datefrom As String
    Private strOrder_Dateto As String
    Private strOrg_AB_Code As String
    Private strPO_Nofrom As String
    Private strPO_Noto As String
    Private strOrder_Nofrom As String
    Private strOrder_Noto As String
    Private strOrder_status As String
    Property Jobber()
        Get
            Return strJobber
        End Get
        Set(ByVal value)
            strJobber = value
        End Set
    End Property

    Property Order_Date_FROM()
        Get
            Return strOrder_Datefrom
        End Get
        Set(ByVal value)
            strOrder_Datefrom = value
        End Set
    End Property
    Property Order_Date_To()
        Get
            Return strOrder_Dateto
        End Get
        Set(ByVal value)
            strOrder_Dateto = value
        End Set
    End Property
    Property Org_AB_Code()
        Get
            Return strOrg_AB_Code
        End Get
        Set(ByVal value)
            strOrg_AB_Code = value
        End Set
    End Property
    Property PO_No_from()
        Get
            Return strPO_Nofrom
        End Get
        Set(ByVal value)
            strPO_Nofrom = value
        End Set
    End Property
    Property PO_No_to()
        Get
            Return strPO_Noto
        End Get
        Set(ByVal value)
            strPO_Noto = value
        End Set
    End Property
    Property Order_No_from()
        Get
            Return strOrder_Nofrom
        End Get
        Set(ByVal value)
            strOrder_Nofrom = value
        End Set
    End Property
    Property Order_No_to()
        Get
            Return strOrder_Noto
        End Get
        Set(ByVal value)
            strOrder_Noto = value
        End Set
    End Property
    Property Order_status()
        Get
            Return strOrder_status
        End Get
        Set(ByVal value)
            strOrder_status = value
        End Set
    End Property
    Public Function Backorder()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""
        Dim OrderDateFrom(2) As String
        Dim OrderDateFRomConvert As String = ""

        Dim OrderDateTo(2) As String
        Dim OrderDateToConvert As String = ""

        If Order_Date_FROM <> "" Then
            OrderDateFrom = Order_Date_FROM.ToString.Split("/")
            OrderDateFRomConvert = OrderDateFrom(2) & "-" & OrderDateFrom(1) & "-" & OrderDateFrom(0)
            condition &= " AND  tbt_asbkeo_cus_order.Order_Date>='" + OrderDateFRomConvert + "'"
        End If
        If Order_Date_To <> "" Then
            OrderDateTo = Order_Date_To.ToString.Split("/")
            OrderDateToConvert = OrderDateTo(2) & "-" & OrderDateTo(1) & "-" & OrderDateTo(0)
            condition &= " AND tbt_asbkeo_cus_order.Order_Date<='" + OrderDateToConvert + "'"
        End If

        If PO_No_from <> "" Then
            condition &= " AND tbt_asbkeo_cus_orderdtl.Po_No>='" + PO_No_from + "'"

        End If
        If PO_No_to <> "" Then
            condition &= " AND tbt_asbkeo_cus_orderdtl.Po_No<='" + PO_No_from + "'"
        End If

        If Order_No_from <> "" Then
            condition &= " AND tbt_asbkeo_cus_orderdtl.order_no>='" + Order_No_from + "'"
        End If
        If Order_No_to <> "" Then
            condition &= " AND tbt_asbkeo_cus_orderdtl.order_no<='" + Order_No_to + "'"
        End If

        If Jobber <> "" Then
            condition &= " AND tbt_asbkeo_cartdetail.Org_Other_Code='" + Jobber + "'"
        End If

        If Order_status = "6" Then
            condition &= " AND order_status='6'"
        End If

        sqlCommand = "select	tbt_asbkeo_cus_order.Order_date,tbt_asbkeo_cus_orderdtl.Po_No"
        sqlCommand &= "		,tbt_asbkeo_cus_order.Address_Org_Ab,tbm_syst_organizeab.Org_AB_Name"
        sqlCommand &= "		,tbt_asbkeo_cus_order.order_no,tbt_asbkeo_cus_orderdtl.Orderqty"
        sqlCommand &= "		,tbt_asbkeo_cus_orderdtl.isbn,tbt_jobber_book_search.book_title"
        sqlCommand &= "		,tbt_asbkeo_cartdetail.Org_Other_Code,tbm_syst_organizeindent.Org_Indent_Name"
        sqlCommand &= "     ,'" + Order_Date_FROM + "' as Date_From,'" + Order_Date_To + "' as Date_To"
        sqlCommand &= "     ,'" + PO_No_from + "' as Po_From,'" + PO_No_to + "' as Po_To "
        sqlCommand &= "     ,'" + Order_No_from + "' as Order_No_From,'" + Order_No_to + "' as Order_No_To "
        sqlCommand &= " from	tbt_asbkeo_cus_order left join tbt_asbkeo_cus_orderdtl"
        sqlCommand &= "		on tbt_asbkeo_cus_order.order_no=tbt_asbkeo_cus_orderdtl.order_no"
        sqlCommand &= "		left join tbm_syst_organizeab on tbt_asbkeo_cus_order.Address_Org_Ab=tbm_syst_organizeab.Org_AB_code"
        sqlCommand &= "		left join (select isbn_13,book_title from tbt_jobber_book_search group by isbn_13,book_title ) as  tbt_jobber_book_search"
        sqlCommand &= "	    on tbt_asbkeo_cus_orderdtl.isbn=tbt_jobber_book_search.isbn_13"
        sqlCommand &= "		left join tbt_asbkeo_cartdetail on tbt_asbkeo_cus_orderdtl.cartno=tbt_asbkeo_cartdetail.cartno"
        sqlCommand &= "										and tbt_asbkeo_cus_orderdtl.cartdtlno=tbt_asbkeo_cartdetail.cartdtlno"
        sqlCommand &= "		left join tbm_syst_organizeindent on tbt_asbkeo_cartdetail.Org_Other_Code=tbm_syst_organizeindent.Org_Indent_Code"
        sqlCommand &= " where tbt_asbkeo_cus_orderdtl.Po_No is not null" + condition
        sqlCommand &= " order by right(tbt_asbkeo_cus_order.order_no,13),tbt_asbkeo_cus_orderdtl.Orderdtl_No"


        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Function Indent_Order()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""
        Dim OrderDateFrom(2) As String
        Dim OrderDateFRomConvert As String

        Dim OrderDateTo(2) As String
        Dim OrderDateToConvert As String

        If Org_AB_Code <> "0" Then
            condition &= " AND tbt_asbkeo_cus_order.Address_Org_Ab='" + Org_AB_Code + "'"
        End If
        If Order_Date_FROM <> "" Then
            OrderDateFrom = Order_Date_FROM.ToString.Split("/")
            OrderDateFRomConvert = OrderDateFrom(2) & "-" & OrderDateFrom(1) & "-" & OrderDateFrom(0)
            condition &= " AND  tbt_asbkeo_cus_order.Order_Date>='" + OrderDateFRomConvert + "'"
        End If
        If Order_Date_To <> "" Then
            OrderDateTo = Order_Date_To.ToString.Split("/")
            OrderDateToConvert = OrderDateTo(2) & "-" & OrderDateTo(1) & "-" & OrderDateTo(0)
            condition &= " AND tbt_asbkeo_cus_order.Order_Date<='" + OrderDateToConvert + "'"
        End If

        sqlCommand = " select * from "
        sqlCommand &= "		(select tbt_asbkeo_cus_order.Order_No,tbt_asbkeo_cus_order.Address_Org_Ab"
        sqlCommand &= "		,tbm_syst_organizeab.Org_AB_Name,tbt_asbkeo_cus_order.addempcd"
        sqlCommand &= "		,tbt_asbkeo_cus_order.addpcnm,tbt_asbkeo_cus_order.Order_Date"
        sqlCommand &= "		,tbt_asbkeo_cus_order.adddt,tbt_asbkeo_cus_order.Customer_Name"
        sqlCommand &= "		,tbt_asbkeo_cus_order.Last_Name,tbt_asbkeo_cus_order.Telephone"
        sqlCommand &= "		,tbt_asbkeo_cus_order.Member_Id,tbt_asbkeo_cus_orderdtl.Orderdtl_No"
        sqlCommand &= "		,tbt_asbkeo_cus_orderdtl.ISBN,case when Org_Other_Code is null then "
        sqlCommand &= "	'Asiabooks' else Org_Other_Code end as Org_Other_Code"
        sqlCommand &= "	    ,tbt_asbkeo_cus_orderdtl.Unitprice as selling_price"
        sqlCommand &= "	    ,tbt_asbkeo_cus_orderdtl.Leadtime"
        sqlCommand &= "	    ,tbt_asbkeo_cus_orderdtl.Orderqty"
        sqlCommand &= "	    ,case isnull(convert(numeric(18,2),tbt_asbkeo_cus_orderdtl.Discount),0) when 0 then isnull(convert(varchar,tbt_asbkeo_cus_orderdtl.Discount_Report),0) else tbt_asbkeo_cus_orderdtl.Discount end as Discount "
        sqlCommand &= "		from tbt_asbkeo_cus_order left join "
        sqlCommand &= "			(select Org_AB_code,Org_AB_Name from tbm_syst_organizeab) as tbm_syst_organizeab"
        sqlCommand &= "			on tbt_asbkeo_cus_order.Address_Org_Ab=tbm_syst_organizeab.Org_AB_code"
        sqlCommand &= "		left join "
        sqlCommand &= "		    (select Order_No,Orderdtl_No,ISBN ,CartNo"
        sqlCommand &= "	        ,Unitprice,Orderqty,Leadtime,Available_Group_Id,Discount,Discount_Report "
        sqlCommand &= "		    from tbt_asbkeo_cus_orderdtl ) as tbt_asbkeo_cus_orderdtl"
        sqlCommand &= "		on tbt_asbkeo_cus_order.Order_No=tbt_asbkeo_cus_orderdtl.Order_No "
        sqlCommand &= "     left join (select ISBN,Org_Other_Code,CartNo,Available_Group_id"
        sqlCommand &= "             from tbt_asbkeo_cartdetail) as tbt_asbkeo_cartdetail"
        sqlCommand &= "     on tbt_asbkeo_cus_orderdtl.CartNo=tbt_asbkeo_cartdetail.CartNo"
        sqlCommand &= "     and tbt_asbkeo_cus_orderdtl.ISBN=tbt_asbkeo_cartdetail.ISBN"
        sqlCommand &= "     and tbt_asbkeo_cus_orderdtl.Available_Group_Id=tbt_asbkeo_cartdetail.Available_Group_id"
        sqlCommand &= " where tbt_asbkeo_cus_orderdtl.Available_Group_Id='3' AND tbt_asbkeo_cus_order.Address_Org_Ab <> 'HO-Internet' " + condition
        sqlCommand &= "	) as tbt_asbkeo_cus_order "
        sqlCommand &= "	left join "
        sqlCommand &= "	(select distinct tbt_jobber_book_search.ISBN_13,Book_Title,Discount"
        sqlCommand &= "				,tbt_jobber_book_search.source,'Could be placed Special Order Upon Request' as stock_status"
        'tbt_jobber_book_search.stock_status"
        sqlCommand &= "	from tbt_jobber_book_search ) as tbt_jobber_book_search "
        sqlCommand &= "	on tbt_asbkeo_cus_order.isbn=tbt_jobber_book_search.isbn_13"
        sqlCommand &= "	left join "
        sqlCommand &= "	(select ISBN_13,Cover_Price,tbm_jobber_book_indent.Org_Indent_Code"
        sqlCommand &= "	from tbm_jobber_book_indent " 
        sqlCommand &= "	) as tbm_jobber_book_indent "
        sqlCommand &= "	on tbt_asbkeo_cus_order.isbn=tbm_jobber_book_indent.isbn_13"
        sqlCommand &= " and tbm_jobber_book_indent.Org_Indent_Code=tbt_asbkeo_cus_order.Org_Other_Code"
        sqlCommand &= " left join "
        sqlCommand &= "	(select  empcd,empnm from tbm_syst_emp ) as tbm_syst_emp"
        sqlCommand &= "	on tbt_asbkeo_cus_order.addempcd=tbm_syst_emp.empcd "
        sqlCommand &= " left join (select Org_Indent_Code,Currency_Code from tbm_syst_organizeindent) as tbm_syst_organizeindent"
        sqlCommand &= " on tbm_jobber_book_indent.Org_Indent_Code=tbm_syst_organizeindent.Org_Indent_Code"
        sqlCommand &= " order by  tbt_asbkeo_cus_order.Order_No,tbt_asbkeo_cus_order.Orderdtl_No"

        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Function Locator()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String = ""
        Dim condition As String = ""

        Dim OrderDateFrom(2) As String
        Dim OrderDateFRomConvert As String

        Dim OrderDateTo(2) As String
        Dim OrderDateToConvert As String

        If Order_Date_FROM <> "" Then
            OrderDateFrom = Order_Date_FROM.ToString.Split("/")
            OrderDateFRomConvert = OrderDateFrom(2) & "-" & OrderDateFrom(1) & "-" & OrderDateFrom(0)
            condition &= " AND  tbt_asbkeo_cus_order.Order_Date>='" + OrderDateFRomConvert + "'"
        End If
        If Order_Date_To <> "" Then
            OrderDateTo = Order_Date_To.ToString.Split("/")
            OrderDateToConvert = OrderDateTo(2) & "-" & OrderDateTo(1) & "-" & OrderDateTo(0)
        End If
        If Org_AB_Code <> "0" Then

            condition &= " AND tbt_asbkeo_cus_order.Address_Org_Ab='" + Org_AB_Code + "'"
        End If
        'tom+.a.2009-07-01 k.orapin request


        sqlCommand &= " select order_no,isbn,locator,on_hand_qty,Order_Date,Address_Org_Ab from "
        sqlCommand &= " (select  tbt_asbkeo_cus_order.order_no,tbt_asbkeo_cus_orderdtl.isbn,Order_Date,Address_Org_Ab"
        sqlCommand &= " from tbt_asbkeo_cus_order"
        sqlCommand &= " left join tbt_asbkeo_cus_orderdtl "
        sqlCommand &= " on tbt_asbkeo_cus_orderdtl.order_no=tbt_asbkeo_cus_order.order_no and tbt_asbkeo_cus_orderdtl.Jobber <> 'Bertrams') as tbt_asbkeo_cus_order"
        sqlCommand &= " left join"
        sqlCommand &= " (select a.isbn_13"
        sqlCommand &= "	,a.locator"
        sqlCommand &= "	,case"
        sqlCommand &= "	when a.on_hand_qty > 0 then a.on_hand_qty"
        sqlCommand &= "	else a.on_order_qty"
        sqlCommand &= "	end as on_hand_qty"
        sqlCommand &= " from ("
        sqlCommand &= " select isbn_13,locator,on_hand_qty,0 as on_order_qty from tbt_jobber_stocklocator where on_hand_qty > 0"
        sqlCommand &= " union"
        sqlCommand &= " select isbn_13,locator,0 as on_hand_qty,on_order_qty from tbt_jobber_stocklocator where on_order_qty > 0"
        sqlCommand &= " and isbn_13 not in (select isbn_13 from tbt_jobber_stocklocator where on_hand_qty > 0)"
        sqlCommand &= " ) as a) as tbt_jobber_stocklocator"
        sqlCommand &= " on tbt_asbkeo_cus_order.isbn=tbt_jobber_stocklocator.isbn_13" + condition
        '---------------------------------------------
        'sqlCommand = "select  tbt_asbkeo_cus_order.order_no,tbt_asbkeo_cus_orderdtl.isbn"
        'sqlCommand &= " ,org_indent_code,locator,on_hand_qty"
        'sqlCommand &= " from tbt_asbkeo_cus_order left join tbt_asbkeo_cus_orderdtl "
        'sqlCommand &= " on tbt_asbkeo_cus_orderdtl.order_no=tbt_asbkeo_cus_order.order_no"
        'sqlCommand &= " left join tbt_jobber_stocklocator"
        'sqlCommand &= " on tbt_asbkeo_cus_orderdtl.isbn=tbt_jobber_stocklocator.isbn_13 "
        'sqlCommand &= " WHERE isnull(tbt_jobber_stocklocator.on_hand_qty,0)>0" + condition
        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Function Summary()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""
        Dim OrderDateFrom(2) As String
        Dim OrderDateFRomConvert As String = ""

        Dim OrderDateTo(2) As String
        Dim OrderDateToConvert As String = ""

        If Order_Date_FROM <> "" Then
            OrderDateFrom = Order_Date_FROM.ToString.Split("/")
            OrderDateFRomConvert = OrderDateFrom(2) & "-" & OrderDateFrom(1) & "-" & OrderDateFrom(0)
            condition &= " AND  tbt_asbkeo_cus_order.Order_Date>='" + OrderDateFRomConvert + "'"
        End If
        If Order_Date_To <> "" Then
            OrderDateTo = Order_Date_To.ToString.Split("/")
            OrderDateToConvert = OrderDateTo(2) & "-" & OrderDateTo(1) & "-" & OrderDateTo(0)
            condition &= " AND tbt_asbkeo_cus_order.Order_Date<='" + OrderDateToConvert + "'"
        End If


        sqlCommand = "select *,(isnull(cover_price,0)-(( isnull(cover_price,0)"
        sqlCommand &= "		 *isnull(discount,0))/100)) * Exchange_Rate as PO_NET"
        sqlCommand &= " from "
        sqlCommand &= "	(select tbt_asbkeo_cus_order.Order_No,tbt_asbkeo_cus_orderdtl.isbn,Orderqty,Unitprice"
        sqlCommand &= "		,org_other_code,addempcd,Exchange_Rate"
        sqlCommand &= "	from  tbt_asbkeo_cus_order "
        sqlCommand &= "		left join (select Order_No,isbn,Available_Group_Id,cartno,Orderqty,Unitprice"
        sqlCommand &= "					from tbt_asbkeo_cus_orderdtl  )as tbt_asbkeo_cus_orderdtl"
        sqlCommand &= "		on tbt_asbkeo_cus_order.Order_No=tbt_asbkeo_cus_orderdtl.Order_No"
        sqlCommand &= "		left join (select isbn,Available_Group_Id,cartno,org_other_code "
        sqlCommand &= "					from tbt_asbkeo_cartdetail) as tbt_asbkeo_cartdetail"
        sqlCommand &= "		on tbt_asbkeo_cus_orderdtl.cartno=tbt_asbkeo_cartdetail.cartno"
        sqlCommand &= "		and tbt_asbkeo_cus_orderdtl.isbn=tbt_asbkeo_cartdetail.isbn"
        sqlCommand &= "		and tbt_asbkeo_cus_orderdtl.Available_Group_Id=tbt_asbkeo_cartdetail.Available_Group_Id"
        sqlCommand &= "	WHERE  tbt_asbkeo_cus_orderdtl.Available_Group_Id='3'" + condition + ""
        sqlCommand &= "	) as tbt_asbkeo_cus_order"
        sqlCommand &= " left join "
        sqlCommand &= "	(select isbn_13,tbm_jobber_book_indent.org_indent_code,cover_price,discount"
        sqlCommand &= "				from tbm_jobber_book_indent"
        sqlCommand &= "	) as tbm_jobber_book_indent"
        sqlCommand &= " on tbt_asbkeo_cus_order.isbn=tbm_jobber_book_indent.isbn_13"
        sqlCommand &= " and tbt_asbkeo_cus_order.org_other_code=tbm_jobber_book_indent.org_indent_code "
        sqlCommand &= " left join "
        sqlCommand &= "	(select  empcd,Department_Name from tbm_syst_emp ) as tbm_syst_emp"
        sqlCommand &= "	on tbt_asbkeo_cus_order.addempcd=tbm_syst_emp.empcd"
        sqlCommand &= " left join (select org_indent_code,org_indent_name from tbm_syst_organizeindent) as tbm_syst_organizeindent"
        sqlCommand &= " on tbm_jobber_book_indent.org_indent_code=tbm_syst_organizeindent.org_indent_code"



        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt
    End Function
End Class
