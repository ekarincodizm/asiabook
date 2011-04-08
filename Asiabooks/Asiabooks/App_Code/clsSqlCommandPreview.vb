Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Eordering.BusinessLogic

Public Class clsSqlCommandPreview
    Private clsDataAccess As New clsDataAccess
    Dim SqlDb As New SqlDb

    Public Function CopyTemp_Utility_SpecialBook_To_Real() As Boolean
        Try
            Dim StrSql As StringBuilder
            StrSql = New StringBuilder
            StrSql.Append("Truncate Table [Utility_SpecialBook] ")
            SqlDb.BeginTrans()
            SqlDb.Exec(StrSql.ToString)
            SqlDb.CommitTrans()

            StrSql = New StringBuilder
            StrSql.Append("insert into [Utility_SpecialBook] ")
            StrSql.Append("([Type],[Seq],[ISBN],[Status],[Remark],[CreatedDate],[CreatedBy]) ")
            StrSql.Append("(select [Type],[Seq],[ISBN],[Status],[Remark],[CreatedDate],[CreatedBy] ")
            StrSql.Append("from [Utility_SpecialBook_Preview]) ")
            SqlDb.BeginTrans()
            SqlDb.Exec(StrSql.ToString)
            SqlDb.CommitTrans()

            Return True

        Catch ex As Exception
            SqlDb.RollbackTrans()
            Throw New Exception("Insert_Utility_SpecialBook_Preview : " & ex.Message)
        End Try
    End Function


    Public Function Insert_Utility_SpecialBook_Preview(ByVal Dt As DataTable) As Boolean
        Try
            SqlDb.BeginTrans()

            For Each Dr As DataRow In Dt.Rows
                Dim StrSql As New StringBuilder
                StrSql.Append("Insert Into [Utility_SpecialBook_Preview] ([Type], Seq, ISBN, Status, Remark, CreatedBy) ")
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
            Throw New Exception("Insert_Utility_SpecialBook_Preview : " & ex.Message)
        End Try
    End Function

    Public Function Update_Status_Utility_SpecialBook_Preview() As Boolean
        Try
            Dim StrSql As New StringBuilder

            StrSql.Append("Update Utility_SpecialBook_Preview ")
            StrSql.Append("Set Status = 'N', Remark = 'ISBN Not In Database, Please verify.' ")
            StrSql.Append("FROM Utility_SpecialBook_Preview LEFT OUTER JOIN tbm_asbkeo_bookab ")
            StrSql.Append("ON Utility_SpecialBook_Preview.ISBN = tbm_asbkeo_bookab.ISBN_13 ")
            StrSql.Append("WHERE Utility_SpecialBook_Preview.Status = 'Y' And  tbm_asbkeo_bookab.ISBN_13 Is Null ")

            SqlDb.BeginTrans()
            SqlDb.Exec(StrSql.ToString)
            SqlDb.CommitTrans()

            Return True

        Catch ex As Exception
            SqlDb.RollbackTrans()
            Throw New Exception("Update_Utility_SpecialBook : " & ex.Message)
        End Try
    End Function

    Public Function Turncate_Utility_SpecialBook_Preview() As Boolean
        Try
            Dim StrSql As New StringBuilder

            StrSql.Append("Truncate Table [Utility_SpecialBook_Preview] ")

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

            StrSql.Append("SELECT CASE a.Type WHEN 'A' THEN 'New Arrival' WHEN 'B' THEN 'Best Saller' ")
            StrSql.Append("WHEN 'R' THEN 'Recommend' ELSE a.Type END AS SpecialType, ")
            StrSql.Append("a.Seq, a.ISBN, ISNULL(tbm_asbkeo_bookab.Book_Title, N'') AS Book_Title, ")
            StrSql.Append("IsNull(tbm_asbkeo_bookab.Author,'') As Author, IsNull(tbm_asbkeo_bookab.Subject_Name,'') As Category, ")
            StrSql.Append("a.Status, a.Remark, Isnull(tbm_asbkeo_bookab.Image,'') AS Book_Image, ")
            StrSql.Append("Left(Isnull(tbm_asbkeo_bookab.Synopsis,''), 425)+'...' AS Synopsis ")

            StrSql.Append("FROM Utility_SpecialBook_Preview a LEFT OUTER JOIN tbm_asbkeo_bookab ON ")
            StrSql.Append("a.ISBN = tbm_asbkeo_bookab.ISBN_13 ")
            StrSql.Append("ORDER BY a.Type, a.Seq, Book_Title ")

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

            StrSql.Append("SELECT Top 5 CASE a.Type WHEN 'A' THEN 'New Arrival' WHEN 'B' THEN 'Best Saller' ")
            StrSql.Append("WHEN 'R' THEN 'Recommend' ELSE a.Type END AS SpecialType, ")
            StrSql.Append("a.Seq, a.ISBN, ISNULL(tbm_asbkeo_bookab.Book_Title, N'') AS Book_Title, ")
            StrSql.Append("IsNull(tbm_asbkeo_bookab.Author,'') As Author, IsNull(tbm_asbkeo_bookab.Subject_Name,'') As Category, ")
            StrSql.Append("a.Status, Utility_SpecialBook.Remark, Isnull(tbm_asbkeo_bookab.Image,'') AS Book_Image, ")
            StrSql.Append("Left(Isnull(tbm_asbkeo_bookab.Synopsis,''), 425)+'...' AS Synopsis ")

            StrSql.Append("FROM Utility_SpecialBook_Preview a LEFT OUTER JOIN tbm_asbkeo_bookab ON ")
            StrSql.Append("a.ISBN = tbm_asbkeo_bookab.ISBN_13 ")

            StrSql.Append("Where a.Type = 'B' And a.Status = 'Y' ")
            StrSql.Append("Order By a.Seq, Book_Title ")

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

            StrSql.Append("SELECT Top 5 CASE a.Type WHEN 'A' THEN 'New Arrival' WHEN 'B' THEN 'Best Saller' ")
            StrSql.Append("WHEN 'R' THEN 'Recommend' ELSE a.Type END AS SpecialType, ")
            StrSql.Append("a.Seq, a.ISBN, ISNULL(tbm_asbkeo_bookab.Book_Title, N'') AS Book_Title, ")
            StrSql.Append("IsNull(tbm_asbkeo_bookab.Author,'') As Author, IsNull(tbm_asbkeo_bookab.Subject_Name,'') As Category, ")
            StrSql.Append("a.Status, a.Remark, Isnull(tbm_asbkeo_bookab.Image,'') AS Book_Image, ")
            StrSql.Append("Left(Isnull(tbm_asbkeo_bookab.Synopsis,''), 425)+'...' AS Synopsis ")

            StrSql.Append("FROM Utility_SpecialBook_Preview a LEFT OUTER JOIN tbm_asbkeo_bookab ON ")
            StrSql.Append("a.ISBN = tbm_asbkeo_bookab.ISBN_13 ")

            StrSql.Append("Where a.Type = 'R' And a.Status = 'Y' ")
            StrSql.Append("Order By a.Seq, Book_Title ")

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

            StrSql.Append("SELECT Top 5 CASE a.Type WHEN 'A' THEN 'New Arrival' WHEN 'B' THEN 'Best Saller' ")
            StrSql.Append("WHEN 'R' THEN 'Recommend' ELSE a.Type END AS SpecialType, ")
            StrSql.Append("a.Seq, a.ISBN, ISNULL(b.Book_Title, N'') AS Book_Title, ")
            StrSql.Append("IsNull(b.Author,'') As Author, IsNull(b.Subject_Name,'') As Category, ")
            StrSql.Append("a.Status, Utility_SpecialBook.Remark, Isnull(b.Image,'') AS Book_Image, ")
            StrSql.Append("Left(Isnull(b.Synopsis,''), 425)+'...' AS Synopsis ")

            StrSql.Append("FROM Utility_SpecialBook_Preview a LEFT OUTER JOIN tbm_asbkeo_bookab b ON ")
            StrSql.Append("a.ISBN = b.ISBN_13 ")

            StrSql.Append("Where a.Type = 'A' And a.Status = 'Y' ")
            StrSql.Append("Order By a.Seq, b.Book_Title ")

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

            StrSql.Append("SELECT b.Type, b.Seq, b.ISBN, ")
            StrSql.Append("IsNull(tbm_asbkeo_bookab.Book_Title,'') As Book_Title, ")
            StrSql.Append("tbm_asbkeo_bookab.Author, tbm_asbkeo_bookab.Publisher_Name, tbm_asbkeo_bookab.Size, ")
            StrSql.Append("tbm_asbkeo_bookab.Weight, tbm_asbkeo_bookab.Binding_Description, tbm_asbkeo_bookab.Page_Qty, ")
            StrSql.Append("tbm_asbkeo_bookab.Subject_Name, Convert(Decimal (18,2), tbm_asbkeo_bookab.Selling_Price) As Selling_Price, ")
            StrSql.Append("Isnull(tbm_asbkeo_bookab.Image,'') AS Book_Image, Left(Isnull(tbm_asbkeo_bookab.Synopsis,''), 425)+'...' AS Synopsis ")

            StrSql.Append("FROM tbm_asbkeo_bookab INNER JOIN Utility_SpecialBook_Preview b ON tbm_asbkeo_bookab.ISBN_13 = b.ISBN ")

            StrSql.Append("Where b.Type='B' And b.Status='Y' ")
            StrSql.Append("Order By b.Seq, Book_Title ")

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

            StrSql.Append("SELECT b.Type, b.Seq, b.ISBN, ")
            StrSql.Append("IsNull(tbm_asbkeo_bookab.Book_Title,'') As Book_Title, ")
            StrSql.Append("tbm_asbkeo_bookab.Author, tbm_asbkeo_bookab.Publisher_Name, tbm_asbkeo_bookab.Size, ")
            StrSql.Append("tbm_asbkeo_bookab.Weight, tbm_asbkeo_bookab.Binding_Description, tbm_asbkeo_bookab.Page_Qty, ")
            StrSql.Append("tbm_asbkeo_bookab.Subject_Name, Convert(Decimal (18,2), tbm_asbkeo_bookab.Selling_Price) As Selling_Price, ")
            StrSql.Append("Isnull(tbm_asbkeo_bookab.Image,'') AS Book_Image, Left(Isnull(tbm_asbkeo_bookab.Synopsis,''), 425)+'...' AS Synopsis ")

            StrSql.Append("FROM tbm_asbkeo_bookab INNER JOIN Utility_SpecialBook_Preview b ON tbm_asbkeo_bookab.ISBN_13 = b.ISBN ")

            StrSql.Append("Where b.Type='R' And b.Status='Y' ")
            StrSql.Append("Order By b.Seq, Book_Title ")

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

            StrSql.Append("select b.[Type], b.[Seq], b.[ISBN], ")
            StrSql.Append("IsNull(a.Book_Title,'') As Book_Title, ")
            StrSql.Append("a.Author, a.Publisher_Name, a.Size, ")
            StrSql.Append("a.Weight, a.Binding_Description, a.Page_Qty, ")
            StrSql.Append("a.Subject_Name, Convert(Decimal (18,2), a.Selling_Price) As Selling_Price, ")
            StrSql.Append("Isnull(a.Image,'') AS Book_Image, Left(Isnull(a.Synopsis,''), 425)+'...' AS Synopsis ")

            StrSql.Append("from tbm_asbkeo_bookab a ")
            StrSql.Append("inner join Utility_SpecialBook_Preview B ON a.ISBN_13 = b.ISBN ")

            StrSql.Append("Where b.Type='A' And b.Status='Y' ")
            StrSql.Append("Order By b.Seq, a.Book_Title ")

            SqlDb.BeginTrans()
            Dt = SqlDb.GetDataset(StrSql.ToString).Tables(0)
            SqlDb.CommitTrans()

            Return Dt
        Catch ex As Exception
            SqlDb.RollbackTrans()
            Throw New Exception("Insert_Utility_SpecialBook_Preview : " & ex.Message)
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
            Throw New Exception("Select_Utility_SpecialBook : " & ex.Message)
        End Try
    End Function

End Class
