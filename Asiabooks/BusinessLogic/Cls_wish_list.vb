Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports Eordering.BusinessLogic.PageControl
Public Class Cls_wish_list
    Private strImage As String
    Private strBook_Title As String
    Private strISBN_13 As String
    Private strAuthor As String
    Private strSelling_Price As String
    Public message As String
    Public dt_old As DataTable

    '/////////promptnow/////////
    Private strSource As String
    Private strDisc As String
    Private strStatus As String
    '///////promptnow end///////

    Property _dt()
        Get
            Return dt_old
        End Get
        Set(ByVal value)
            dt_old = value
        End Set
    End Property

    Property Image()
        Get
            Return strImage
        End Get
        Set(ByVal value)
            strImage = value
        End Set
    End Property

    Property Book_Title()
        Get
            Return strBook_Title
        End Get
        Set(ByVal value)
            strBook_Title = value
        End Set
    End Property

    Property ISBN_13()
        Get
            Return strISBN_13
        End Get
        Set(ByVal value)
            strISBN_13 = value
        End Set
    End Property

    Property Author()
        Get
            Return strAuthor
        End Get
        Set(ByVal value)
            strAuthor = value
        End Set
    End Property

    Property Selling_Price()
        Get
            Return strSelling_Price
        End Get
        Set(ByVal value)
            strSelling_Price = value
        End Set
    End Property

    '/////////promptnow/////////
    Property Source()
        Get
            Return strSource
        End Get
        Set(ByVal value)
            strSource = value
        End Set
    End Property

    Property Disc()
        Get
            Return strDisc
        End Get
        Set(ByVal value)
            strDisc = value
        End Set
    End Property

    Property Status()
        Get
            Return strStatus
        End Get
        Set(ByVal value)
            strStatus = value
        End Set
    End Property

    '///////promptnow end///////

    Public Function Retreive()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        If ISBN_13 <> "" Then
            condition = " WHERE ISBN_13='" + ISBN_13 + "'"

        End If

        sqlCommand = "select * from tbt_jobber_book_search" + condition
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function

    Public Function dt_add()
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim dt_xxx As New DataTable
        Dim dr_xxx As DataRow
        Dim i As Integer

        dt_xxx.Columns.Add("Image")
        dt_xxx.Columns.Add("Book_Title")
        dt_xxx.Columns.Add("ISBN_13")
        dt_xxx.Columns.Add("Author")
        dt_xxx.Columns.Add("Selling_Price")

        '/////////promptnow/////////
        dt_xxx.Columns.Add("Id")
        dt_xxx.Columns.Add("Source")
        dt_xxx.Columns.Add("Disc")
        dt_xxx.Columns.Add("Status")
        dt_xxx.Columns.Add("Book_type")
        '///////promptnow end///////

        dr_xxx = dt_xxx.NewRow
        dt.Columns.Add("Image")
        dt.Columns.Add("Book_Title")
        dt.Columns.Add("ISBN_13")
        dt.Columns.Add("Author")
        dt.Columns.Add("Selling_Price")

        '/////////promptnow/////////
        dt.Columns.Add("Source")
        dt.Columns.Add("Disc")
        dt.Columns.Add("Status")
        '///////promptnow end///////

        If dt_old Is Nothing Then
        Else
            For i = 0 To dt_old.Rows.Count - 1
                dr = dt.NewRow
                dr("Image") = dt_old.Rows(i).Item("Image").ToString()
                dr("Book_Title") = dt_old.Rows(i).Item("Book_Title").ToString()
                dr("ISBN_13") = dt_old.Rows(i).Item("ISBN_13").ToString()
                dr("Author") = dt_old.Rows(i).Item("Author")
                dr("Selling_Price") = dt_old.Rows(i).Item("Selling_Price")

                '/////////promptnow/////////
                dr("Source") = dt_old.Rows(i).Item("Source").ToString()
                dr("Disc") = dt_old.Rows(i).Item("Disc").ToString()
                dr("Status") = dt_old.Rows(i).Item("Status").ToString()
                '///////promptnow end///////

                dt.Rows.Add(dr)
            Next
        End If

        Dim a As String
        a = "Y"
        If dt_old Is Nothing Then
        Else
            For i = 0 To dt_old.Rows.Count - 1        
                If ISBN_13 = dt_old.Rows(i).Item("ISBN_13").ToString() Then
                    a = "N"
                End If
            Next

            message = "Add To wisht list UnSuccessful,Please select new ISBN !!"

        End If
        If a = "Y" Then
            dr = dt.NewRow
            dr("Image") = Image
            dr("Book_Title") = Book_Title
            dr("ISBN_13") = ISBN_13
            dr("Author") = Author
            dr("Selling_Price") = Selling_Price

            '/////////promptnow/////////
            dr("Source") = Source
            dr("Disc") = Disc
            dr("Status") = Status
            '///////promptnow end///////

            dt.Rows.Add(dr)
            message = ""
        End If

        Return dt
    End Function
End Class
