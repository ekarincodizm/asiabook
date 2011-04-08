Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Eordering.BusinessLogic

Public Class clsSqlCommand

    Private clsDataAccess As New clsDataAccess
    Dim SqlDb As New SqlDb

    Public Function Insert_Utility_SpecialBook(ByVal Dt As DataTable) As Boolean
        Try
            SqlDb.BeginTrans()

            For Each Dr As DataRow In Dt.Rows
                Dim StrSql As New StringBuilder
                StrSql.Append("Insert Into [Utility_SpecialBook] ([Type], Seq, ISBN, Status, Remark, CreatedBy) ")
                StrSql.Append("Values (")
                StrSql.Append("'" & Dr("Type") & "', ")
                StrSql.Append(Dr("Seq") & ", ")
                StrSql.Append("'" & Dr("ISBN") & "', ")
                StrSql.Append("'" & Dr("Status") & "', ")
                StrSql.Append("'" & Dr("Remark") & "', ")
                StrSql.Append("'" & Dr("CreatedBy") & "' ")
                StrSql.Append(") ")

                SqlDb.Exec(StrSql.ToString)
            Next

            SqlDb.CommitTrans()
            Return True

        Catch ex As Exception
            SqlDb.RollbackTrans()
            Throw New Exception("Insert_Utility_SpecialBook : " & ex.Message)
        End Try
    End Function

    Public Function Update_Status_Utility_SpecialBook() As Boolean
        Try
            Dim StrSql As New StringBuilder

            StrSql.Append("Update Utility_SpecialBook ")
            StrSql.Append("Set Status = 'N', Remark = 'ISBN Not In Database, Please verify.' ")
            StrSql.Append("FROM Utility_SpecialBook LEFT OUTER JOIN tbm_asbkeo_bookab ")
            StrSql.Append("ON Utility_SpecialBook.ISBN = tbm_asbkeo_bookab.ISBN_13 ")
            StrSql.Append("WHERE Utility_SpecialBook.Status = 'Y' And  tbm_asbkeo_bookab.ISBN_13 Is Null ")

            SqlDb.BeginTrans()
            SqlDb.Exec(StrSql.ToString)
            SqlDb.CommitTrans()

            Return True

        Catch ex As Exception
            SqlDb.RollbackTrans()
            Throw New Exception("Insert_Utility_SpecialBook : " & ex.Message)
        End Try
    End Function

    Public Function Turncate_Utility_SpecialBook() As Boolean
        Try
            Dim StrSql As New StringBuilder

            StrSql.Append("Truncate Table [Utility_SpecialBook] ")

            SqlDb.BeginTrans()
            SqlDb.Exec(StrSql.ToString)
            SqlDb.CommitTrans()

            Return True

        Catch ex As Exception
            SqlDb.RollbackTrans()
            Throw New Exception("Insert_Utility_SpecialBook : " & ex.Message)
        End Try
    End Function

    Public Function Select_Utility_SpecialBook() As DataTable
        Try
            Dim StrSql As New StringBuilder
            Dim Dt As New DataTable

            StrSql.Append("SELECT CASE Utility_SpecialBook.Type WHEN 'A' THEN 'New Arrival' WHEN 'B' THEN 'Best Saller' ")
            StrSql.Append("WHEN 'R' THEN 'Recommend' ELSE Utility_SpecialBook.Type END AS SpecialType, ")
            StrSql.Append("Utility_SpecialBook.Seq, Utility_SpecialBook.ISBN, ISNULL(tbm_asbkeo_bookab.Book_Title, N'') AS Book_Title, ")
            StrSql.Append("IsNull(tbm_asbkeo_bookab.Author,'') As Author, IsNull(tbm_asbkeo_bookab.Subject_Name,'') As Category, ")
            StrSql.Append("Utility_SpecialBook.Status, Utility_SpecialBook.Remark, Isnull(tbm_asbkeo_bookab.Image,'') AS Book_Image, ")
            StrSql.Append("Left(Isnull(tbm_asbkeo_bookab.Synopsis,''), 425)+'...' AS Synopsis ")

            StrSql.Append("FROM Utility_SpecialBook LEFT OUTER JOIN tbm_asbkeo_bookab ON ")
            StrSql.Append("Utility_SpecialBook.ISBN = tbm_asbkeo_bookab.ISBN_13 ")
            StrSql.Append("ORDER BY Utility_SpecialBook.Type, Utility_SpecialBook.Seq, Book_Title ")

            SqlDb.BeginTrans()
            Dt = SqlDb.GetDataset(StrSql.ToString).Tables(0)
            SqlDb.CommitTrans()

            Return Dt

        Catch ex As Exception
            SqlDb.RollbackTrans()
            Throw New Exception("Insert_Utility_SpecialBook : " & ex.Message)
        End Try

    End Function

    Public Function Select_Top_SpecialBook_BestSaller() As DataTable
        Try
            Dim StrSql As New StringBuilder
            Dim Dt As New DataTable

            StrSql.Append("SELECT Top 10 CASE Utility_SpecialBook.Type WHEN 'A' THEN 'New Arrival' WHEN 'B' THEN 'Best Saller' ")
            StrSql.Append("WHEN 'R' THEN 'Recommend' ELSE Utility_SpecialBook.Type END AS SpecialType, ")
            StrSql.Append("Utility_SpecialBook.Seq, Utility_SpecialBook.ISBN, ISNULL(tbm_asbkeo_bookab.Book_Title, N'') AS Book_Title, ")
            StrSql.Append("IsNull(tbm_asbkeo_bookab.Author,'') As Author, IsNull(tbm_asbkeo_bookab.Subject_Name,'') As Category, ")
            StrSql.Append("Utility_SpecialBook.Status, Utility_SpecialBook.Remark, Isnull(tbm_asbkeo_bookab.Image,'') AS Book_Image, ")
            StrSql.Append("Left(Isnull(tbm_asbkeo_bookab.Synopsis,''), 425)+'...' AS Synopsis ")

            StrSql.Append("FROM Utility_SpecialBook LEFT OUTER JOIN tbm_asbkeo_bookab ON ")
            StrSql.Append("Utility_SpecialBook.ISBN = tbm_asbkeo_bookab.ISBN_13 ")

            StrSql.Append("Where Utility_SpecialBook.Type = 'B' And Utility_SpecialBook.Status = 'Y' ")
            StrSql.Append("Order By Utility_SpecialBook.Seq, Book_Title ")

            SqlDb.BeginTrans()
            Dt = SqlDb.GetDataset(StrSql.ToString).Tables(0)
            SqlDb.CommitTrans()

            Return Dt
        Catch ex As Exception

            SqlDb.RollbackTrans()
            Throw New Exception("Insert_Utility_SpecialBook : " & ex.Message)

        End Try
    End Function

    Public Function Select_Top_SpecialBook_Recommend() As DataTable
        Try
            Dim StrSql As New StringBuilder
            Dim Dt As New DataTable

            StrSql.Append("SELECT Top 5 CASE Utility_SpecialBook.Type WHEN 'A' THEN 'New Arrival' WHEN 'B' THEN 'Best Saller' ")
            StrSql.Append("WHEN 'R' THEN 'Recommend' ELSE Utility_SpecialBook.Type END AS SpecialType, ")
            StrSql.Append("Utility_SpecialBook.Seq, Utility_SpecialBook.ISBN, ISNULL(tbm_asbkeo_bookab.Book_Title, N'') AS Book_Title, ")
            StrSql.Append("IsNull(tbm_asbkeo_bookab.Author,'') As Author, IsNull(tbm_asbkeo_bookab.Subject_Name,'') As Category, ")
            StrSql.Append("Utility_SpecialBook.Status, Utility_SpecialBook.Remark, Isnull(tbm_asbkeo_bookab.Image,'') AS Book_Image, ")
            StrSql.Append("Left(Isnull(tbm_asbkeo_bookab.Synopsis,''), 425)+'...' AS Synopsis ")

            StrSql.Append("FROM Utility_SpecialBook LEFT OUTER JOIN tbm_asbkeo_bookab ON ")
            StrSql.Append("Utility_SpecialBook.ISBN = tbm_asbkeo_bookab.ISBN_13 ")

            StrSql.Append("Where Utility_SpecialBook.Type = 'R' And Utility_SpecialBook.Status = 'Y' ")
            StrSql.Append("Order By Utility_SpecialBook.Seq, Book_Title ")

            SqlDb.BeginTrans()
            Dt = SqlDb.GetDataset(StrSql.ToString).Tables(0)
            SqlDb.CommitTrans()

            Return Dt

        Catch ex As Exception
            SqlDb.RollbackTrans()
            Throw New Exception("Insert_Utility_SpecialBook : " & ex.Message)
        End Try
    End Function

    Public Function Select_Top_SpecialBook_NewArrival() As DataTable
        Try
            Dim StrSql As New StringBuilder
            Dim Dt As New DataTable

            'StrSql.Append("SELECT Top 5 CASE Utility_SpecialBook.Type WHEN 'A' THEN 'New Arrival' WHEN 'B' THEN 'Best Saller' ")
            'StrSql.Append("WHEN 'R' THEN 'Recommend' ELSE Utility_SpecialBook.Type END AS SpecialType, ")
            'StrSql.Append("Utility_SpecialBook.Seq, Utility_SpecialBook.ISBN, ISNULL(tbm_asbkeo_bookab.Book_Title, N'') AS Book_Title, ")
            'StrSql.Append("IsNull(tbm_asbkeo_bookab.Author,'') As Author, IsNull(tbm_asbkeo_bookab.Subject_Name,'') As Category, ")
            'StrSql.Append("Utility_SpecialBook.Status, Utility_SpecialBook.Remark, Isnull(tbm_asbkeo_bookab.Image,'') AS Book_Image, ")
            'StrSql.Append("Left(Isnull(tbm_asbkeo_bookab.Synopsis,''), 425)+'...' AS Synopsis ")

            'StrSql.Append("FROM Utility_SpecialBook LEFT OUTER JOIN tbm_asbkeo_bookab ON ")
            'StrSql.Append("Utility_SpecialBook.ISBN = tbm_asbkeo_bookab.ISBN_13 ")

            'StrSql.Append("Where Utility_SpecialBook.Type = 'A' And Utility_SpecialBook.Status = 'Y' ")
            'StrSql.Append("Order By Utility_SpecialBook.Seq, Book_Title ")

            StrSql.Append("select top 10 *,case source when 'Asiabooks' then convert(numeric(13,0),tbt_jobber_book_search.selling) else ")
            StrSql.Append("convert(numeric(18,0),(tbt_jobber_book_search.selling*(isnull(tbt_jobber_book_search.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbt_jobber_book_search.field1,0))) ")
            StrSql.Append("+tbt_jobber_book_search.selling*(isnull(tbt_jobber_book_search.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbt_jobber_book_search.field1,0))) ")
            StrSql.Append("*Mark_UP/100)) end as Selling_price ")
            StrSql.Append("from (select	tbt_jobber_book_search.image,tbt_jobber_book_search.Book_Title , ")
            StrSql.Append("case when (tbt_jobber_book_search.Author='' or tbt_jobber_book_search.Author ='NONE') then '-' else tbt_jobber_book_search.Author end as Author, ")
            StrSql.Append("tbt_jobber_book_search.ISBN_13, ")
            StrSql.Append("case when tbt_jobber_book_search.Publisher_name='' then '-' else tbt_jobber_book_search.Publisher_name end as Publisher_name, ")
            StrSql.Append("tbt_jobber_book_search.[Size], convert(numeric(13,2),tbt_jobber_book_search.Weight) as Weight ,tbt_jobber_book_search.binding_description ")
            StrSql.Append(" ,case when convert(varchar(10),tbt_jobber_book_search.Page_qty)='0' THEN '-'  else convert(varchar(10),tbt_jobber_book_search.Page_qty)end as Page_qty ")
            StrSql.Append(" ,case when tbt_jobber_book_search.Subject_Name='' then '-'  else tbt_jobber_book_search.Subject_Name end as Subject_Name ")
            StrSql.Append(" ,case when tbt_jobber_book_search.Stock_status='' then '-' else tbt_jobber_book_search.Stock_status end as stock_status ")
            StrSql.Append(" ,case when right(tbt_jobber_book_search.Publication_Date,4)='0000' then '-'  else right(tbt_jobber_book_search.Publication_Date,4) end as Publication_Date ")
            StrSql.Append(",source,Selling_Price as selling,discount,tbt_jobber_book_search.field1 ")
            StrSql.Append("from tbt_jobber_book_search ) as tbt_jobber_book_search Inner Join  Utility_SpecialBook On tbt_jobber_book_search.ISBN_13 = Utility_SpecialBook.ISBN ")
            StrSql.Append("left join (select mark_up,From_Pub_Discount,to_Pub_Discount,sales_channel_code from tbm_syst_saleschannel )as tbm_syst_saleschannel ")
            StrSql.Append("on tbt_jobber_book_search.discount>=tbm_syst_saleschannel.From_Pub_Discount and tbt_jobber_book_search.discount <= tbm_syst_saleschannel.to_Pub_Discount ")
            StrSql.Append("and tbm_syst_saleschannel.sales_channel_code=' + sales_channel + ' ,(select Buffer_Rate from tbm_syst_company) as tbm_syst_company ")

            StrSql.Append("Where Utility_SpecialBook.Type='A' And Utility_SpecialBook.Status='Y' Order By Seq ")

            SqlDb.BeginTrans()
            Dt = SqlDb.GetDataset(StrSql.ToString).Tables(0)
            SqlDb.CommitTrans()

            Return Dt
        Catch ex As Exception
            SqlDb.RollbackTrans()
            Throw New Exception("Insert_Utility_SpecialBook : " & ex.Message)
        End Try
    End Function

    Public Function Select_SpecialBook_BestSaller() As DataTable
        Try
            Dim StrSql As New StringBuilder
            Dim Dt As New DataTable

            StrSql.Append("SELECT Utility_SpecialBook.Type, Utility_SpecialBook.Seq, Utility_SpecialBook.ISBN, ")
            StrSql.Append("IsNull(tbm_asbkeo_bookab.Book_Title,'') As Book_Title, ")
            StrSql.Append("tbm_asbkeo_bookab.Author, tbm_asbkeo_bookab.Publisher_Name, tbm_asbkeo_bookab.Size, ")
            StrSql.Append("tbm_asbkeo_bookab.Weight, tbm_asbkeo_bookab.Binding_Description, tbm_asbkeo_bookab.Page_Qty, ")
            StrSql.Append("tbm_asbkeo_bookab.Subject_Name, Convert(Decimal (18,2), tbm_asbkeo_bookab.Selling_Price) As Selling_Price, ")
            StrSql.Append("Isnull(tbm_asbkeo_bookab.Image,'') AS Book_Image, Left(Isnull(tbm_asbkeo_bookab.Synopsis,''), 425)+'...' AS Synopsis ")

            StrSql.Append("FROM tbm_asbkeo_bookab INNER JOIN Utility_SpecialBook ON tbm_asbkeo_bookab.ISBN_13 = Utility_SpecialBook.ISBN ")

            StrSql.Append("Where Utility_SpecialBook.Type='B' And Utility_SpecialBook.Status='Y' ")
            StrSql.Append("Order By Utility_SpecialBook.Seq, Book_Title ")

            SqlDb.BeginTrans()
            Dt = SqlDb.GetDataset(StrSql.ToString).Tables(0)
            SqlDb.CommitTrans()

            Return Dt
        Catch ex As Exception

            SqlDb.RollbackTrans()
            Throw New Exception("Insert_Utility_SpecialBook : " & ex.Message)

        End Try
    End Function

    Public Function Select_SpecialBook_Recommend() As DataTable
        Try
            Dim StrSql As New StringBuilder
            Dim Dt As New DataTable

            StrSql.Append("SELECT Utility_SpecialBook.Type, Utility_SpecialBook.Seq, Utility_SpecialBook.ISBN, ")
            StrSql.Append("IsNull(tbm_asbkeo_bookab.Book_Title,'') As Book_Title, ")
            StrSql.Append("tbm_asbkeo_bookab.Author, tbm_asbkeo_bookab.Publisher_Name, tbm_asbkeo_bookab.Size, ")
            StrSql.Append("tbm_asbkeo_bookab.Weight, tbm_asbkeo_bookab.Binding_Description, tbm_asbkeo_bookab.Page_Qty, ")
            StrSql.Append("tbm_asbkeo_bookab.Subject_Name, Convert(Decimal (18,2), tbm_asbkeo_bookab.Selling_Price) As Selling_Price, ")
            StrSql.Append("Isnull(tbm_asbkeo_bookab.Image,'') AS Book_Image, Left(Isnull(tbm_asbkeo_bookab.Synopsis,''), 425)+'...' AS Synopsis ")

            StrSql.Append("FROM tbm_asbkeo_bookab INNER JOIN Utility_SpecialBook ON tbm_asbkeo_bookab.ISBN_13 = Utility_SpecialBook.ISBN ")

            StrSql.Append("Where Utility_SpecialBook.Type='R' And Utility_SpecialBook.Status='Y' ")
            StrSql.Append("Order By Utility_SpecialBook.Seq, Book_Title ")

            SqlDb.BeginTrans()
            Dt = SqlDb.GetDataset(StrSql.ToString).Tables(0)
            SqlDb.CommitTrans()

            Return Dt

        Catch ex As Exception
            SqlDb.RollbackTrans()
            Throw New Exception("Insert_Utility_SpecialBook : " & ex.Message)
        End Try
    End Function

    Public Function Select_SpecialBook_NewArrival() As DataTable
        Try
            Dim StrSql As New StringBuilder
            Dim Dt As New DataTable

            'StrSql.Append("SELECT Utility_SpecialBook.Type, Utility_SpecialBook.Seq, Utility_SpecialBook.ISBN, ")
            'StrSql.Append("IsNull(tbm_asbkeo_bookab.Book_Title,'') As Book_Title, ")
            'StrSql.Append("tbm_asbkeo_bookab.Author, tbm_asbkeo_bookab.Publisher_Name, tbm_asbkeo_bookab.Size, ")
            'StrSql.Append("tbm_asbkeo_bookab.Weight, tbm_asbkeo_bookab.Binding_Description, tbm_asbkeo_bookab.Page_Qty, ")
            'StrSql.Append("tbm_asbkeo_bookab.Subject_Name, Convert(Decimal (18,2), tbm_asbkeo_bookab.Selling_Price) As Selling_Price, ")
            'StrSql.Append("Isnull(tbm_asbkeo_bookab.Image,'') AS Book_Image, Left(Isnull(tbm_asbkeo_bookab.Synopsis,''), 425)+'...' AS Synopsis ")

            'StrSql.Append("FROM tbm_asbkeo_bookab INNER JOIN Utility_SpecialBook ON tbm_asbkeo_bookab.ISBN_13 = Utility_SpecialBook.ISBN ")

            'StrSql.Append("Where Utility_SpecialBook.Type='A' And Utility_SpecialBook.Status='Y' ")
            'StrSql.Append("Order By Utility_SpecialBook.Seq, Book_Title ")

            StrSql.Append("select *,case source when 'Asiabooks' then convert(numeric(13,0),tbt_jobber_book_search.selling) else ")
            StrSql.Append("convert(numeric(18,0),(tbt_jobber_book_search.selling*(isnull(tbt_jobber_book_search.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbt_jobber_book_search.field1,0))) ")
            StrSql.Append("+tbt_jobber_book_search.selling*(isnull(tbt_jobber_book_search.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbt_jobber_book_search.field1,0))) ")
            StrSql.Append("*Mark_UP/100)) end as Selling_price ")
            StrSql.Append("from (select	tbt_jobber_book_search.image,tbt_jobber_book_search.Book_Title , ")
            StrSql.Append("case when (tbt_jobber_book_search.Author='' or tbt_jobber_book_search.Author ='NONE') then '-' else tbt_jobber_book_search.Author end as Author, ")
            StrSql.Append("tbt_jobber_book_search.ISBN_13, ")
            StrSql.Append("case when tbt_jobber_book_search.Publisher_name='' then '-' else tbt_jobber_book_search.Publisher_name end as Publisher_name, ")
            StrSql.Append("tbt_jobber_book_search.[Size], convert(numeric(13,2),tbt_jobber_book_search.Weight) as Weight ,tbt_jobber_book_search.binding_description ")
            StrSql.Append(" ,case when convert(varchar(10),tbt_jobber_book_search.Page_qty)='0' THEN '-'  else convert(varchar(10),tbt_jobber_book_search.Page_qty)end as Page_qty ")
            StrSql.Append(" ,case when tbt_jobber_book_search.Subject_Name='' then '-'  else tbt_jobber_book_search.Subject_Name end as Subject_Name ")
            StrSql.Append(" ,case when tbt_jobber_book_search.Stock_status='' then '-' else tbt_jobber_book_search.Stock_status end as stock_status ")
            StrSql.Append(" ,case when right(tbt_jobber_book_search.Publication_Date,4)='0000' then '-'  else right(tbt_jobber_book_search.Publication_Date,4) end as Publication_Date ")
            StrSql.Append(",source,Selling_Price as selling,discount,tbt_jobber_book_search.field1, Isnull(Image,'') AS Book_Image, Left(Isnull(Synopsis,''), 425)+'...' AS Synopsis  ")
            StrSql.Append("from tbt_jobber_book_search ) as tbt_jobber_book_search Inner Join  Utility_SpecialBook On tbt_jobber_book_search.ISBN_13 = Utility_SpecialBook.ISBN ")
            StrSql.Append("left join (select mark_up,From_Pub_Discount,to_Pub_Discount,sales_channel_code from tbm_syst_saleschannel )as tbm_syst_saleschannel ")
            StrSql.Append("on tbt_jobber_book_search.discount>=tbm_syst_saleschannel.From_Pub_Discount and tbt_jobber_book_search.discount <= tbm_syst_saleschannel.to_Pub_Discount ")
            StrSql.Append("and tbm_syst_saleschannel.sales_channel_code=' + sales_channel + ' ,(select Buffer_Rate from tbm_syst_company) as tbm_syst_company ")

            StrSql.Append("Where Utility_SpecialBook.Type='A' And Utility_SpecialBook.Status='Y' Order By Seq ")

            SqlDb.BeginTrans()
            Dt = SqlDb.GetDataset(StrSql.ToString).Tables(0)
            SqlDb.CommitTrans()

            Return Dt
        Catch ex As Exception
            SqlDb.RollbackTrans()
            Throw New Exception("Insert_Utility_SpecialBook : " & ex.Message)
        End Try
    End Function

    Public Function Select_Mid_SpecialBook_NewArrival() As DataTable
        Try
            Dim StrSql As New StringBuilder
            Dim Dt As New DataTable

            'StrSql.Append("SELECT Utility_SpecialBook.Type, Utility_SpecialBook.Seq, Utility_SpecialBook.ISBN, ")
            'StrSql.Append("IsNull(tbm_asbkeo_bookab.Book_Title,'') As Book_Title, ")
            'StrSql.Append("tbm_asbkeo_bookab.Author, tbm_asbkeo_bookab.Publisher_Name, tbm_asbkeo_bookab.Size, ")
            'StrSql.Append("tbm_asbkeo_bookab.Weight, tbm_asbkeo_bookab.Binding_Description, tbm_asbkeo_bookab.Page_Qty, ")
            'StrSql.Append("tbm_asbkeo_bookab.Subject_Name, Convert(Decimal (18,2), tbm_asbkeo_bookab.Selling_Price) As Selling_Price, ")
            'StrSql.Append("Isnull(tbm_asbkeo_bookab.Image,'') AS Book_Image, Left(Isnull(tbm_asbkeo_bookab.Synopsis,''), 425)+'...' AS Synopsis ")

            'StrSql.Append("FROM tbm_asbkeo_bookab INNER JOIN Utility_SpecialBook ON tbm_asbkeo_bookab.ISBN_13 = Utility_SpecialBook.ISBN ")

            'StrSql.Append("Where Utility_SpecialBook.Type='A' And Utility_SpecialBook.Status='Y' ")
            'StrSql.Append("Order By Utility_SpecialBook.Seq, Book_Title ")

            StrSql.Append("select top 5 *,case source when 'Asiabooks' then convert(numeric(13,0),tbt_jobber_book_search.selling) else ")
            StrSql.Append("convert(numeric(18,0),(tbt_jobber_book_search.selling*(isnull(tbt_jobber_book_search.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbt_jobber_book_search.field1,0))) ")
            StrSql.Append("+tbt_jobber_book_search.selling*(isnull(tbt_jobber_book_search.field1,0)+((tbm_syst_company.Buffer_Rate/100) * isnull(tbt_jobber_book_search.field1,0))) ")
            StrSql.Append("*Mark_UP/100)) end as Selling_price ")
            StrSql.Append("from (select	tbt_jobber_book_search.image,tbt_jobber_book_search.Book_Title , ")
            StrSql.Append("case when (tbt_jobber_book_search.Author='' or tbt_jobber_book_search.Author ='NONE') then '-' else tbt_jobber_book_search.Author end as Author, ")
            StrSql.Append("tbt_jobber_book_search.ISBN_13, ")
            StrSql.Append("case when tbt_jobber_book_search.Publisher_name='' then '-' else tbt_jobber_book_search.Publisher_name end as Publisher_name, ")
            StrSql.Append("tbt_jobber_book_search.[Size], convert(numeric(13,2),tbt_jobber_book_search.Weight) as Weight ,tbt_jobber_book_search.binding_description ")
            StrSql.Append(" ,case when convert(varchar(10),tbt_jobber_book_search.Page_qty)='0' THEN '-'  else convert(varchar(10),tbt_jobber_book_search.Page_qty)end as Page_qty ")
            StrSql.Append(" ,case when tbt_jobber_book_search.Subject_Name='' then '-'  else tbt_jobber_book_search.Subject_Name end as Subject_Name ")
            StrSql.Append(" ,case when tbt_jobber_book_search.Stock_status='' then '-' else tbt_jobber_book_search.Stock_status end as stock_status ")
            StrSql.Append(" ,case when right(tbt_jobber_book_search.Publication_Date,4)='0000' then '-'  else right(tbt_jobber_book_search.Publication_Date,4) end as Publication_Date ")
            StrSql.Append(",source,Selling_Price as selling,discount,tbt_jobber_book_search.field1 ")
            StrSql.Append("from tbt_jobber_book_search ) as tbt_jobber_book_search Inner Join  Utility_SpecialBook On tbt_jobber_book_search.ISBN_13 = Utility_SpecialBook.ISBN ")
            StrSql.Append("left join (select mark_up,From_Pub_Discount,to_Pub_Discount,sales_channel_code from tbm_syst_saleschannel )as tbm_syst_saleschannel ")
            StrSql.Append("on tbt_jobber_book_search.discount>=tbm_syst_saleschannel.From_Pub_Discount and tbt_jobber_book_search.discount <= tbm_syst_saleschannel.to_Pub_Discount ")
            StrSql.Append("and tbm_syst_saleschannel.sales_channel_code=' + sales_channel + ' ,(select Buffer_Rate from tbm_syst_company) as tbm_syst_company ")

            StrSql.Append("Where Utility_SpecialBook.Type='A' And Utility_SpecialBook.Status='Y' And Seq > 10 Order By Seq ")

            SqlDb.BeginTrans()
            Dt = SqlDb.GetDataset(StrSql.ToString).Tables(0)
            SqlDb.CommitTrans()

            Return Dt
        Catch ex As Exception
            SqlDb.RollbackTrans()
            Throw New Exception("Insert_Utility_SpecialBook : " & ex.Message)
        End Try
    End Function

    Public Function Select_Category() As DataTable
        Try
            Dim StrSql As New StringBuilder
            Dim Dt As New DataTable

            StrSql.Append("Select *, Replace(Description,' & ', '|') As Link From Utility_BookCategory ")
            StrSql.Append("Where Len(Code)=1 ")
            StrSql.Append("Order By Seq")

            SqlDb.BeginTrans()
            Dt = SqlDb.GetDataset(StrSql.ToString).Tables(0)
            SqlDb.CommitTrans()

            Return Dt
        Catch ex As Exception
            SqlDb.RollbackTrans()
            Throw New Exception("Insert_Utility_SpecialBook : " & ex.Message)
        End Try
    End Function
    Public Function Select_Organizead() As DataTable
        Try
            Dim StrSql As New StringBuilder
            Dim Dt As New DataTable

            StrSql.Append("select org_ab_code ,org_ab_name from dbo.tbm_syst_organizeab ")
            StrSql.Append("where group_code not in ('Intransit','HO-Good','HO','WS','KPG','DS') ")

            SqlDb.BeginTrans()
            Dt = SqlDb.GetDataset(StrSql.ToString).Tables(0)
            SqlDb.CommitTrans()

            Return Dt

        Catch ex As Exception
            SqlDb.RollbackTrans()
            Throw New Exception("Insert_Utility_SpecialBook : " & ex.Message)
        End Try

    End Function
    Public Function Select_SubCategory(ByVal CategoryCode As String) As DataTable
        Try
            Dim StrSql As New StringBuilder
            Dim Dt As New DataTable

            StrSql.Append("Select *, Replace(Description,' & ', '|') As Link From Utility_BookCategory ")
            StrSql.Append("Where Keyword ='SubCategory' ")
            StrSql.Append("And Left(Code,1) = '" & CategoryCode.Trim & "' ")
            StrSql.Append("Order By Seq")

            SqlDb.BeginTrans()
            Dt = SqlDb.GetDataset(StrSql.ToString).Tables(0)
            SqlDb.CommitTrans()

            Return Dt
        Catch ex As Exception
            SqlDb.RollbackTrans()
            Throw New Exception("Insert_Utility_SpecialBook : " & ex.Message)
        End Try
    End Function
End Class
