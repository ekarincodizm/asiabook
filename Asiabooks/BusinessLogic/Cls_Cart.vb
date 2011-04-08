Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Net.DNS

Public Class Cls_Cart
    Dim message As String
    Public sumno As Integer
    Public sumstt As Integer
    Private strCartNo As String
    Private strCartDate As String
    Private strAmount_Available As String
    Private strAmount_Other As String
    Private strAmount_Special As String
    Private strCartdtlno As String
    Private strOrg_AB_Code As String
    Private strOrg_Other_Code As String
    Private strISBN As String
    Private strUnitprice As String
    Private strLeadtime As String
    Private strWeight As String
    Private strCartqty As String
    Private strAmount As String
    Private strAvailable_Group_id As String
    Private strOrdstt As String
    Private strSales_Channel_Code As String
    Private strTransport_Type As String
    Private strTotal_Weight As String
    Private strEmpcd As String
    Private strPcnm As String
    Private strStatus As String
    Property Status()
        Get
            Return strStatus
        End Get
        Set(ByVal value)
            strStatus = value
        End Set
    End Property
    Property Pcnm()
        Get
            Return strPcnm
        End Get
        Set(ByVal value)
            strPcnm = value
        End Set
    End Property
    Property CartNo()
        Get
            Return strCartNo
        End Get
        Set(ByVal value)
            strCartNo = value
        End Set
    End Property
    Property CartDate()
        Get
            Return strCartDate
        End Get
        Set(ByVal value)
            strCartDate = value
        End Set
    End Property
    Property Amount_Available()
        Get
            Return strAmount_Available
        End Get
        Set(ByVal value)
            strAmount_Available = value
        End Set
    End Property
    Property Amount_Other()
        Get
            Return strAmount_Other
        End Get
        Set(ByVal value)
            strAmount_Other = value
        End Set
    End Property
    Property Amount_Special()
        Get
            Return strAmount_Special
        End Get
        Set(ByVal value)
            strAmount_Special = value
        End Set
    End Property
    Property Cartdtlno()
        Get
            Return strCartdtlno
        End Get
        Set(ByVal value)
            strCartdtlno = value
        End Set
    End Property
    Property Org_Other_Code()
        Get
            Return strOrg_Other_Code
        End Get
        Set(ByVal value)
            strOrg_Other_Code = value
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
    Property ISBN()
        Get
            Return strISBN
        End Get
        Set(ByVal value)
            strISBN = value
        End Set
    End Property
    Property Unitprice()
        Get
            Return strUnitprice
        End Get
        Set(ByVal value)
            strUnitprice = value
        End Set
    End Property
    Property Leadtime()
        Get
            Return strLeadtime
        End Get
        Set(ByVal value)
            strLeadtime = value
        End Set
    End Property
    Property Weight()
        Get
            Return strWeight
        End Get
        Set(ByVal value)
            strWeight = value
        End Set
    End Property
    Property Cartqty()
        Get
            Return strCartqty
        End Get
        Set(ByVal value)
            strCartqty = value
        End Set
    End Property
    Property Available_Group_id()
        Get
            Return strAvailable_Group_id
        End Get
        Set(ByVal value)
            strAvailable_Group_id = value
        End Set
    End Property
    Property Amount()
        Get
            Return strAmount
        End Get
        Set(ByVal value)
            strAmount = value
        End Set
    End Property
    Property Ordstt()
        Get
            Return strOrdstt
        End Get
        Set(ByVal value)
            strOrdstt = value
        End Set
    End Property

    Property Transport_Type()
        Get
            Return strTransport_Type
        End Get
        Set(ByVal value)
            strTransport_Type = value
        End Set
    End Property
    Property Total_Weight()
        Get
            Return strTotal_Weight
        End Get
        Set(ByVal value)
            strTotal_Weight = value
        End Set
    End Property
    Property Sales_Channel_Code()
        Get
            Return strSales_Channel_Code
        End Get
        Set(ByVal value)
            strSales_Channel_Code = value
        End Set
    End Property
    Property Empcd()
        Get
            Return strEmpcd
        End Get
        Set(ByVal value)
            strEmpcd = value
        End Set
    End Property
    Public Function Retreive_Branch()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = " SELECT  a.CartNo,Cartdtlno,ISBN_13,book_title,Available_Group_id,Ordstt, "
        sqlCommand &= "Unitprice as Selling_Price,Leadtime as Lead_Time,a.Weight,Cartqty as Quantity,"
        sqlCommand &= "Amount,Org_Other_Code as To_Org_AB_code,a.Status"
        sqlCommand &= " FROM tbt_asbkeo_cartdetail a,"
        sqlCommand &= "(select distinct isbn_13,Book_Title "
        sqlCommand &= " from tbt_jobber_book_search) b, "
        sqlCommand &= "tbt_asbkeo_cart c"
        sqlCommand &= " WHERE a.CartNo=c.CartNo "
        sqlCommand &= " AND a.ISBN=b.ISBN_13 "
        sqlCommand &= " AND Available_Group_id='1' "
        sqlCommand &= " AND a.cartno='" + CartNo + "'"
        sqlCommand &= " ORDER BY Cartdtlno"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function Retreive_Orther_Branch()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = " SELECT  a.CartNo,Cartdtlno,ISBN_13,book_title ,Available_Group_id,Ordstt,"
        sqlCommand &= "Unitprice as Selling_Price,Leadtime as Lead_Time,a.Weight,Cartqty as Quantity,"
        sqlCommand &= "Amount,Org_Other_Code as To_Org_AB_code,a.Status"
        sqlCommand &= " FROM tbt_asbkeo_cartdetail a,"
        sqlCommand &= "(select distinct isbn_13,Book_Title from tbt_jobber_book_search) b, "
        sqlCommand &= " tbt_asbkeo_cart c"
        sqlCommand &= " WHERE a.CartNo=c.CartNo "
        sqlCommand &= " AND a.ISBN=b.ISBN_13 "
        sqlCommand &= " AND Available_Group_id='2' "
        sqlCommand &= " AND a.cartno='" + CartNo + "'"
        sqlCommand &= " ORDER BY Cartdtlno"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function Retreive_Special()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = " SELECT  a.CartNo,Cartdtlno,ISBN_13,book_title ,Available_Group_id,Ordstt,"
        sqlCommand &= "Unitprice as Selling_Price,Leadtime as Lead_Time,a.Weight,Cartqty as Quantity,"
        sqlCommand &= "Amount,Org_Other_Code as To_Org_AB_code,a.Status"
        sqlCommand &= " FROM tbt_asbkeo_cartdetail a,"
        sqlCommand &= "(select distinct isbn_13,Book_Title from tbt_jobber_book_search) b, "
        sqlCommand &= " tbt_asbkeo_cart c"
        sqlCommand &= " WHERE a.CartNo=c.CartNo "
        sqlCommand &= " AND a.ISBN=b.ISBN_13 "
        sqlCommand &= " AND Available_Group_id='3' "
        sqlCommand &= " AND a.cartno='" + CartNo + "'"
        sqlCommand &= " ORDER BY Cartdtlno"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function Retrive()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""
        Dim datenow As String = sqlDb.GetDataTable("SELECT convert(varchar(10),getdate(),120)").Rows(0)(0).ToString

        Dim CartDateArr(2) As String
        Dim CartDateConvert As String


        If CartNo <> "" Then
            'condition = " AND a.cartNo= '" + Org_AB_Code + "'+'" + sqlDb.GetDataTable("select convert(varchar(10),getdate(),12)").Rows(0)(0).ToString + "'" + _
            '            "+" + "'CR'" + "+" + "'" + Convert.ToInt16(CartNo).ToString("00000") + "'"
            condition = " AND a.cartNo= '" + CartNo + "'"
        End If
        If CartDate <> "" Then
            CartDateArr = CartDate.ToString.Split("/")
            CartDateConvert = CartDateArr(2) & "-" & CartDateArr(1) & "-" & CartDateArr(0)
            condition &= " AND CartDate >= '" + CartDateConvert + "'" + _
                        "  AND CartDate <= '" + CartDateConvert + "'"
        End If

        sqlCommand = " SELECT  a.CartNo,b.ISBN,Book_Title,Unitprice,Cartqty,b.weight,b.amount"
        sqlCommand &= ",CASE WHEN Available_Group_id='1' THEN 'In Branch' "
        sqlCommand &= " WHEN Available_Group_id='2' THEN 'Other Branch' ELSE 'Special Order' "
        sqlCommand &= " END as Available_Group_id"
        sqlCommand &= ",CASE WHEN Available_Group_id='1' or Available_Group_id='2'  THEN tbm_syst_organizeab.org_ab_name "
        sqlCommand &= " ELSE tbm_syst_organizeindent.org_indent_name END as branch_name"
        sqlCommand &= " FROM tbt_asbkeo_cart a,tbt_asbkeo_cartdetail b"
        sqlCommand &= " left join tbm_syst_organizeab on b.org_other_code=tbm_syst_organizeab.org_ab_code"
        sqlCommand &= " left join tbm_syst_organizeindent on b.org_other_code=tbm_syst_organizeindent.org_indent_code,"
        sqlCommand &= "(select distinct isbn_13,Book_Title from tbt_jobber_book_search) as  c"
        sqlCommand &= " WHERE a.CartNo=b.CartNo "
        sqlCommand &= " AND Ordstt<>'2'"
        sqlCommand &= " AND Sales_Channel_Code='" + Sales_Channel_Code + "'"
        sqlCommand &= " AND a.org_ab_code='" + Org_AB_Code + "'"
        sqlCommand &= " AND b.ISBN=c.ISBN_13" + condition
        sqlCommand &= " order by a.CartNo DESC,Org_Other_Code,cartdtlno "
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function Retrive_SpecialOrder()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""
        Dim datenow As String = sqlDb.GetDataTable("SELECT convert(varchar(10),getdate(),120)").Rows(0)(0).ToString

        Dim CartDateArr(2) As String
        Dim CartDateConvert As String


        If CartNo <> "" Then
            'condition = " AND a.cartNo= '" + Org_AB_Code + "'+'" + sqlDb.GetDataTable("select convert(varchar(10),getdate(),12)").Rows(0)(0).ToString + "'" + _
            '            "+" + "'CR'" + "+" + "'" + Convert.ToInt16(CartNo).ToString("00000") + "'"
            condition = " AND a.cartNo= '" + CartNo + "'"
        End If
        If CartDate <> "" Then
            CartDateArr = CartDate.ToString.Split("/")
            CartDateConvert = CartDateArr(2) & "-" & CartDateArr(1) & "-" & CartDateArr(0)
            condition &= " AND CartDate >= '" + CartDateConvert + "'" + _
                        "  AND CartDate <= '" + CartDateConvert + "'"
        End If

        sqlCommand = " SELECT  a.CartNo,b.ISBN,Book_Title,Unitprice,Cartqty,b.weight,b.amount"
        sqlCommand &= ",CASE WHEN Available_Group_id='1' THEN 'In Branch' "
        sqlCommand &= " WHEN Available_Group_id='2' THEN 'Other Branch' ELSE 'Special Order' "
        sqlCommand &= " END as Available_Group_id"
        sqlCommand &= ",CASE WHEN Available_Group_id='1' or Available_Group_id='2'  THEN tbm_syst_organizeab.org_ab_name "
        sqlCommand &= " ELSE tbm_syst_organizeindent.org_indent_name END as branch_name"
        sqlCommand &= " FROM tbt_asbkeo_cart a,tbt_asbkeo_cartdetail b"
        sqlCommand &= " left join tbm_syst_organizeab on b.org_other_code=tbm_syst_organizeab.org_ab_code"
        sqlCommand &= " left join tbm_syst_organizeindent on b.org_other_code=tbm_syst_organizeindent.org_indent_code,"
        sqlCommand &= "(select distinct isbn_13,Book_Title from tbt_jobber_book_search) as  c"
        sqlCommand &= " WHERE a.CartNo=b.CartNo "
        sqlCommand &= " AND Ordstt<>'1'"
        sqlCommand &= " AND Sales_Channel_Code='INTERNET'"
        sqlCommand &= " AND a.org_ab_code='HO-Internet'"
        sqlCommand &= " AND b.ISBN=c.ISBN_13" + condition
        sqlCommand &= " order by a.CartNo DESC,Org_Other_Code,cartdtlno "
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
   
    Public Function RetriveToCo()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = " SELECT  a.CartNo,Cartdtlno,b.ISBN,Book_Title,Unitprice, "
        sqlCommand &= " Cartqty, b.weight, b.amount, b.Available_Group_id,org_other_code,currency_code,"
        sqlCommand &= " c.Cover_Price,c.discount as Discount_Report,c.field1 as Exchange_Rate"
        sqlCommand &= " ,e.on_hand_qty,e.on_order_qty,b.Status"
        sqlCommand &= " FROM tbt_asbkeo_cart a,tbt_asbkeo_cartdetail b, "
        sqlCommand &= " tbm_jobber_book_indent c ,tbm_syst_organizeindent d"
        sqlCommand &= " , tbt_jobber_stockindent e"
        sqlCommand &= " WHERE a.CartNo = b.CartNo"
        sqlCommand &= " AND b.ISBN=c.ISBN_13 "
        sqlCommand &= " AND b.org_other_code=d.org_indent_code"
        sqlCommand &= " AND b.org_other_code=c.org_indent_code"
        sqlCommand &= " AND a.cartNo='" + CartNo + "'"
        sqlCommand &= " AND b.Ordstt='1'  "
        sqlCommand &= " AND b.org_other_code=e.org_indent_code"
        sqlCommand &= " AND b.ISBN=e.ISBN_13"
        sqlCommand &= " order by Org_Other_Code,cartdtlno "

        'sqlCommand = " SELECT  a.CartNo,Cartdtlno,b.ISBN,Book_Title,Unitprice,"
        'sqlCommand &= "Cartqty, b.weight, b.amount, b.Available_Group_id,org_other_code "
        'sqlCommand &= " FROM tbt_asbkeo_cart a,tbt_asbkeo_cartdetail b,"
        'sqlCommand &= "(select distinct isbn_13,Book_Title from tbt_jobber_book_search) c"
        'sqlCommand &= " WHERE a.CartNo=b.CartNo "
        'sqlCommand &= " AND b.ISBN=c.ISBN_13"
        'sqlCommand &= " AND a.cartNo='" + CartNo + "'"
        'sqlCommand &= " AND b.Ordstt='1' "
        'sqlCommand &= " order by Org_Other_Code,cartdtlno"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function Checkdb()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""
        sqlCommand = " SELECT  ISBN "
        sqlCommand &= " FROM tbt_asbkeo_cartdetail"
        sqlCommand &= " WHERE cartNo='" + CartNo + "'"
        sqlCommand &= " AND Available_Group_id='" + Available_Group_id + "'"
        sqlCommand &= " AND ISBN='" + ISBN + "'"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function F_Amount_Available()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = " SELECT  Amount_Available,CONVERT(VARCHAR(10),CartDate,103) as CartDate"
        sqlCommand &= " FROM  tbt_asbkeo_cart "
        sqlCommand &= " WHERE cartno='" + CartNo + "'"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt

    End Function

    Public Function F_Amount_Other()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = " SELECT  Amount_Other"
        sqlCommand &= " FROM  tbt_asbkeo_cart "
        sqlCommand &= " WHERE cartno='" + CartNo + "'"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function

    Public Function F_Amount_Special()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = " SELECT  Amount_Special"
        sqlCommand &= " FROM  tbt_asbkeo_cart "
        sqlCommand &= " WHERE cartno='" + CartNo + "'"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function Totalweight()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = " SELECT  isnull(sum(Weight),0) as totalweight"
        sqlCommand &= " FROM  tbt_asbkeo_cartdetail "
        sqlCommand &= " WHERE cartno='" + CartNo + "'"
        sqlCommand &= " AND Ordstt='1'"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function MaxLeadtime()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = " SELECT  isnull(max(Leadtime),0) as maxleadtime"
        sqlCommand &= " FROM  tbt_asbkeo_cartdetail "
        sqlCommand &= " WHERE cartno='" + CartNo + "'"
        sqlCommand &= " AND Ordstt='1'"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function TotalAmount()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = " SELECT isnull(sum(Amount),0) as totalamount"
        sqlCommand &= " FROM  tbt_asbkeo_cartdetail "
        sqlCommand &= " WHERE cartno='" + CartNo + "'"
        sqlCommand &= " AND Ordstt='1'"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function Zone()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = " SELECT b.ZONE_code,Country_Name"
        sqlCommand &= " FROM  tbm_syst_country a,tbm_syst_deliverycharge b"
        sqlCommand &= " WHERE a.ZONE_code=b.zone_code"
        sqlCommand &= " AND Transport_Type='" + Transport_Type + "'"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function

    Public Sub DeleteGrid()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try
            sqlDb.BeginTrans()
            sqlCommand = "DELETE tbt_asbkeo_cartdetail"
            sqlCommand &= " WHERE CartNo='" + CartNo + "'"
            sqlCommand &= " AND ISBN='" + ISBN + "'"
            sqlCommand &= " AND Available_Group_id='" + Available_Group_id + "'"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()

            message = "Delete " + CartNo + " Successful"
        Catch ex As Exception
            sqlDb.RollbackTrans()
            message = ex.Message
        End Try
    End Sub

    Public Sub Delete()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try
            sqlDb.BeginTrans()
            sqlCommand = "DELETE tbt_asbkeo_cartdetail"
            sqlCommand &= " WHERE CartNo='" + CartNo + "'"
            sqlCommand &= " AND Ordstt<>'2'"

            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Delete " + CartNo + " Successful"
        Catch ex As Exception
            sqlDb.RollbackTrans()
            message = ex.Message
        End Try
    End Sub

    Public Sub AddCartDetail()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try
            sqlDb.BeginTrans()
            sqlCommand = "INSERT INTO tbt_asbkeo_cartdetail"
            sqlCommand &= "(CartNo,Cartdtlno,ISBN,Unitprice,Leadtime,Weight,"
            sqlCommand &= "Cartqty,Amount,Available_Group_id,Org_Other_Code,"
            sqlCommand &= "Ordstt,addemp,addpcnm,adddt,Status)"
            sqlCommand &= " VALUES('" + CartNo + "',"
            sqlCommand &= " '" + Cartdtlno + "',"
            sqlCommand &= " '" + ISBN + "',"
            sqlCommand &= " '" + CDbl(Unitprice).ToString + "',"
            sqlCommand &= " '" + Leadtime + "',"
            sqlCommand &= " '" + CDbl(Weight).ToString + "',"
            sqlCommand &= " '" + CDbl(Cartqty).ToString + "',"
            sqlCommand &= " '" + CDbl(Amount).ToString + "',"
            sqlCommand &= " '" + Available_Group_id + "',"
            sqlCommand &= " '" + Org_Other_Code + "',"
            sqlCommand &= " '" + Ordstt + "',"
            sqlCommand &= " '" + Empcd + "',"
            sqlCommand &= " '" + Pcnm + "',"
            sqlCommand &= " '" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "',"
            sqlCommand &= " '" + Status + "')"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()

        Catch ex As Exception
            sqlDb.RollbackTrans()

        End Try
    End Sub

    Public Sub UpdateAmountCart()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try

            sqlDb.BeginTrans()

            sqlCommand = " UPDATE tbt_asbkeo_cart "
            sqlCommand &= "SET Amount_Available=(SELECT isnull(sum(amount),0) "
            sqlCommand &= " FROM tbt_asbkeo_cartdetail "
            sqlCommand &= " WHERE cartno='" + CartNo + "' "
            sqlCommand &= " and Available_Group_id='1' ),"
            sqlCommand &= "Amount_Other =(SELECT isnull(sum(amount),0) "
            sqlCommand &= " FROM tbt_asbkeo_cartdetail "
            sqlCommand &= " WHERE cartno='" + CartNo + "' "
            sqlCommand &= " and Available_Group_id='2' ),"
            sqlCommand &= "Amount_Special=(SELECT isnull(sum(amount),0) "
            sqlCommand &= " FROM tbt_asbkeo_cartdetail "
            sqlCommand &= " WHERE cartno='" + CartNo + "' "
            sqlCommand &= " and Available_Group_id='3' ), "
            sqlCommand &= " updemp='" + Empcd + "',"
            sqlCommand &= " updpcnm='" + Pcnm + "',"
            sqlCommand &= " upddt='" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "'"
            sqlCommand &= "WHERE cartno='" + CartNo + "'"

            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
        Catch ex As Exception
            sqlDb.RollbackTrans()
            message = ex.Message
        End Try
    End Sub
    Public Sub UpdateCartCancel()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try

            sqlDb.BeginTrans()
            sqlCommand = "UPDATE tbt_asbkeo_cart "
            sqlCommand &= "SET field1='2',"
            sqlCommand &= " updemp='" + Empcd + "',"
            sqlCommand &= " updpcnm='" + Pcnm + "',"
            sqlCommand &= " upddt='" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "'"
            sqlCommand &= " WHERE Amount_Available=0"
            sqlCommand &= " AND Amount_Other=0"
            sqlCommand &= " AND Amount_Special=0"
            sqlCommand &= " AND cartno='" + CartNo + "'"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()



        Catch ex As Exception
            sqlDb.RollbackTrans()
            message = ex.Message
        End Try
    End Sub
    Public Sub UpdateCartOpen()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try

            sqlDb.BeginTrans()
            sqlCommand = "UPDATE tbt_asbkeo_cart "
            sqlCommand &= "SET field1='0',"
            sqlCommand &= " updemp='" + Empcd + "',"
            sqlCommand &= " updpcnm='" + Pcnm + "',"
            sqlCommand &= " upddt='" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "'"
            sqlCommand &= " WHERE (Amount_Available<>0"
            sqlCommand &= " OR Amount_Other<>0"
            sqlCommand &= " OR Amount_Special<>0)"
            sqlCommand &= " AND cartno='" + CartNo + "'"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()



        Catch ex As Exception
            sqlDb.RollbackTrans()
            message = ex.Message
        End Try
    End Sub
    Public Sub UpdateCartComfirm()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try

            sqlDb.BeginTrans()
            sqlCommand = "UPDATE tbt_asbkeo_cart "
            sqlCommand &= "SET field1='1',"
            sqlCommand &= " updemp='" + Empcd + "',"
            sqlCommand &= " updpcnm='" + Pcnm + "',"
            sqlCommand &= " upddt='" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "'"
            sqlCommand &= " WHERE (Amount_Available<>0"
            sqlCommand &= " OR Amount_Other<>0"
            sqlCommand &= " OR Amount_Special<>0)"
            sqlCommand &= " AND cartno='" + CartNo + "'"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()



        Catch ex As Exception
            sqlDb.RollbackTrans()
            message = ex.Message
        End Try
    End Sub
    Public Sub UpdateCartStt()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try
            sqlDb.BeginTrans()
            sqlCommand = "UPDATE tbt_asbkeo_cartdetail"
            sqlCommand &= " SET Ordstt='2',"
            sqlCommand &= " updemp='" + Empcd + "',"
            sqlCommand &= " updpcnm='" + Pcnm + "',"
            sqlCommand &= " upddt='" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "'"
            sqlCommand &= " WHERE CartNo='" + CartNo + "'"
            sqlCommand &= " AND Cartdtlno= '" + Cartdtlno + "'"
            sqlCommand &= " AND Org_Other_Code= '" + Org_Other_Code + "'"

            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()

        Catch ex As Exception
            sqlDb.RollbackTrans()
        End Try
    End Sub
    Public Sub UpdateAmount_Available()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try
            sqlDb.BeginTrans()
            sqlCommand = "UPDATE tbt_asbkeo_cart"
            sqlCommand &= " SET Amount_Available=(SELECT isnull(sum(amount),0) FROM tbt_asbkeo_cartdetail "
            sqlCommand &= " WHERE CartNo='" + CartNo + "' and Available_Group_id='" + Available_Group_id + "'),"
            sqlCommand &= " updemp='" + Empcd + "',"
            sqlCommand &= " updpcnm='" + Pcnm + "',"
            sqlCommand &= " upddt='" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "'"
            sqlCommand &= " WHERE CartNo='" + CartNo + "'"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()

        Catch ex As Exception
            sqlDb.RollbackTrans()
        End Try
    End Sub
    Public Sub UpdateAmount_Other()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try
            sqlDb.BeginTrans()
            sqlCommand = "UPDATE tbt_asbkeo_cart"
            sqlCommand &= " SET Amount_Other=(SELECT isnull(sum(amount),0) FROM tbt_asbkeo_cartdetail "
            sqlCommand &= " WHERE CartNo='" + CartNo + "' and Available_Group_id='" + Available_Group_id + "'),"
            sqlCommand &= " updemp='" + Empcd + "',"
            sqlCommand &= " updpcnm='" + Pcnm + "',"
            sqlCommand &= " upddt='" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "'"
            sqlCommand &= " WHERE CartNo='" + CartNo + "'"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()

        Catch ex As Exception
            sqlDb.RollbackTrans()
        End Try
    End Sub
    Public Sub UpdateAmount_Special()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try
            sqlDb.BeginTrans()
            sqlCommand = "UPDATE tbt_asbkeo_cart"
            sqlCommand &= " SET Amount_Special=(SELECT isnull(sum(amount),0) FROM tbt_asbkeo_cartdetail "
            sqlCommand &= " WHERE CartNo='" + CartNo + "' and Available_Group_id='" + Available_Group_id + "'),"
            sqlCommand &= " updemp='" + Empcd + "',"
            sqlCommand &= " updpcnm='" + Pcnm + "',"
            sqlCommand &= " upddt='" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "'"
            sqlCommand &= " WHERE CartNo='" + CartNo + "'"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()

        Catch ex As Exception
            sqlDb.RollbackTrans()
        End Try
    End Sub
    Public Sub sumstatus()
        Dim sqlDb As New SqlDb
        sumstt = sqlDb.GetDataTable("SELECT count(Cartdtlno) FROM tbt_asbkeo_cartdetail WHERE  CartNo='" + CartNo + "' AND Ordstt='2'").Rows(0)(0).ToString
        sumno = sqlDb.GetDataTable("SELECT count(Cartdtlno) FROM tbt_asbkeo_cartdetail WHERE  CartNo='" + CartNo + "'").Rows(0)(0).ToString
    End Sub
End Class
