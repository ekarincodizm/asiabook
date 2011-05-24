Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.Configuration

Public Class Class_Promotion
    '///// Public Parameter /////
    Public BOOK_TOTAL As Integer
    Public EBOOK_TOTAL As Integer

    Public BOOK_DATATABLE As DataTable
    Public EBOOK_DATATABLE As DataTable
    Public DATATABLE_01 As DataTable
    Public DATATABLE_02 As DataTable
    Public DATATABLE_03 As DataTable

    Property _BOOK_TOTAL()
        Get
            Return BOOK_TOTAL
        End Get
        Set(ByVal value)
            BOOK_TOTAL = value
        End Set
    End Property
    Property _EBOOK_TOTAL()
        Get
            Return EBOOK_TOTAL
        End Get
        Set(ByVal value)
            EBOOK_TOTAL = value
        End Set
    End Property
    Property _BOOK_DATATABLE()
        Get
            Return BOOK_DATATABLE
        End Get
        Set(ByVal value)
            BOOK_DATATABLE = value
        End Set
    End Property
    Property _EBOOK_DATATABLE()
        Get
            Return EBOOK_DATATABLE
        End Get
        Set(ByVal value)
            EBOOK_DATATABLE = value
        End Set
    End Property
    Property _DATATABLE_01()
        Get
            Return DATATABLE_01
        End Get
        Set(ByVal value)
            DATATABLE_01 = value
        End Set
    End Property
    Property _DATATABLE_02()
        Get
            Return DATATABLE_02
        End Get
        Set(ByVal value)
            DATATABLE_02 = value
        End Set
    End Property
    Property _DATATABLE_03()
        Get
            Return DATATABLE_03
        End Get
        Set(ByVal value)
            DATATABLE_03 = value
        End Set
    End Property

    '///// Private Parameter /////
    Dim SQL_CONNECTION As SqlDb = New SqlDb

    Dim DATATABLE As DataTable = New DataTable
    Dim RECORD As DataTable = New DataTable
    Dim datarow As DataRow

    Dim QUERY As String = ""

    Function CheckPromotion()
        Dim book_num As Integer = 0
        Dim ebook_num As Integer = 0
        Dim book_value As Integer = 0
        Dim ebook_value As Integer = 0
        Dim sp_num As Integer = 0
        Dim sp_value As Integer = 0
        Dim result As String = ""

        DATATABLE.Columns.Add("PROMOTION_ID", System.Type.GetType("System.String"))
        DATATABLE.Columns.Add("PROMOTION_NAME", System.Type.GetType("System.String"))
        DATATABLE.Columns.Add("CONDITION", System.Type.GetType("System.String"))
        DATATABLE.Columns.Add("BUY_TYPE", System.Type.GetType("System.String"))
        DATATABLE.Columns.Add("BUY_AMOUNT", System.Type.GetType("System.String"))
        DATATABLE.Columns.Add("REWARD_TYPE", System.Type.GetType("System.String"))
        DATATABLE.Columns.Add("FREE_REWARD", System.Type.GetType("System.String"))
        DATATABLE.Columns.Add("DISCOUNT_TYPE", System.Type.GetType("System.String"))
        DATATABLE.Columns.Add("DISCOUNT_VALUE", System.Type.GetType("System.String"))
        DATATABLE.Columns.Add("PAY_PROMOTION", System.Type.GetType("System.String"))
        DATATABLE.Columns.Add("PRIORITY", System.Type.GetType("System.Int32"))

        Try
            Dim listSP As DataTable = New DataTable
            Dim str_isbn As String = ""

            If Not BOOK_DATATABLE Is Nothing Then
                If BOOK_DATATABLE.Rows.Count > 0 Then
                    For Each row As DataRow In BOOK_DATATABLE.Rows
                        Dim isbn As String = row.Item("ISBN_13").ToString.Trim
                        Dim listSP_num As Integer = listSP.Rows.Count
                        listSP = getSP_FromList(isbn, "book", listSP)
                        If listSP_num < listSP.Rows.Count Then
                            sp_num = sp_num + CInt(row.Item("QUANTITY"))
                            sp_value = sp_value + (CInt(row.Item("SELLING_PRICE")) * CInt(row.Item("QUANTITY")))
                        End If
                        book_num = book_num + CInt(row.Item("QUANTITY"))
                    Next
                End If
            End If

            If Not EBOOK_DATATABLE Is Nothing Then
                If EBOOK_DATATABLE.Rows.Count > 0 Then
                    For Each row As DataRow In EBOOK_DATATABLE.Rows
                        ebook_num = ebook_num + CInt(row.Item("QUANTITY"))
                        Dim isbn As String = row.Item("ISBN_13").ToString.Trim
                        listSP = getSP_FromList(isbn, "ebook", listSP)
                    Next

                    For Each rowSP As DataRow In listSP.Select("BOOK_TYPE = 'ebook'")
                        Dim booleans As Boolean = False
                        For Each row As DataRow In EBOOK_DATATABLE.Rows
                            Dim a As String = rowSP.Item("ISBN").ToString
                            Dim b As String = row.Item("ISBN_13").ToString
                            Dim c As String = rowSP.Item("FORMAT").ToString
                            Dim d As String = row.Item("FORMAT").ToString
                            If rowSP.Item("ISBN") = row.Item("ISBN_13") And rowSP.Item("FORMAT") = row.Item("FORMAT") Then
                                booleans = True
                                sp_num = sp_num + CInt(row.Item("QUANTITY"))
                                sp_value = sp_value + (CInt(row.Item("SELLING_PRICE")) * CInt(row.Item("QUANTITY")))
                            End If
                        Next
                        If booleans = False Then
                            rowSP.Delete()
                        End If
                    Next
                End If
            End If

            book_value = BOOK_TOTAL
            ebook_value = EBOOK_TOTAL

            result = getPromotion()
            If result = "Y" Then
                For Each REC As DataRow In RECORD.Rows
                    Dim CONDITION As String = REC.Item("CONDITION").ToString.ToLower
                    Dim BUYTYPE As String = REC.Item("BUYTYPE").ToString.ToLower
                    Dim BUYAMOUNT As String = REC.Item("BUYAMOUNT").ToString.ToLower

                    If CONDITION = "book" And BUYTYPE = "item" And CInt(BUYAMOUNT) <= book_num Then
                        datarow = DATATABLE.NewRow
                        datarow("PROMOTION_ID") = REC.Item("PROMOTIONID").ToString
                        datarow("PROMOTION_NAME") = REC.Item("PROMOTIONNAME").ToString
                        datarow("CONDITION") = REC.Item("CONDITION").ToString
                        datarow("BUY_TYPE") = REC.Item("BUYTYPE").ToString
                        datarow("BUY_AMOUNT") = REC.Item("BUYAMOUNT").ToString
                        datarow("REWARD_TYPE") = REC.Item("REWARDTYPE").ToString
                        datarow("FREE_REWARD") = REC.Item("FREEREWARD").ToString
                        datarow("DISCOUNT_TYPE") = REC.Item("DISTYPE").ToString
                        datarow("DISCOUNT_VALUE") = REC.Item("DISVALUE").ToString
                        datarow("PAY_PROMOTION") = REC.Item("PAYPROMO").ToString
                        datarow("PRIORITY") = CInt(REC.Item("PRIORITY"))
                        DATATABLE.Rows.Add(datarow)
                    End If
                    If CONDITION = "book" And BUYTYPE = "value" And CInt(BUYAMOUNT) <= book_value Then
                        datarow = DATATABLE.NewRow
                        datarow("PROMOTION_ID") = REC.Item("PROMOTIONID").ToString
                        datarow("PROMOTION_NAME") = REC.Item("PROMOTIONNAME").ToString
                        datarow("CONDITION") = REC.Item("CONDITION").ToString
                        datarow("BUY_TYPE") = REC.Item("BUYTYPE").ToString
                        datarow("BUY_AMOUNT") = REC.Item("BUYAMOUNT").ToString
                        datarow("REWARD_TYPE") = REC.Item("REWARDTYPE").ToString
                        datarow("FREE_REWARD") = REC.Item("FREEREWARD").ToString
                        datarow("DISCOUNT_TYPE") = REC.Item("DISTYPE").ToString
                        datarow("DISCOUNT_VALUE") = REC.Item("DISVALUE").ToString
                        datarow("PAY_PROMOTION") = REC.Item("PAYPROMO").ToString
                        datarow("PRIORITY") = CInt(REC.Item("PRIORITY"))
                        DATATABLE.Rows.Add(datarow)
                    End If
                    If CONDITION = "e-book" And BUYTYPE = "item" And CInt(BUYAMOUNT) <= ebook_num Then
                        datarow = DATATABLE.NewRow
                        datarow("PROMOTION_ID") = REC.Item("PROMOTIONID").ToString
                        datarow("PROMOTION_NAME") = REC.Item("PROMOTIONNAME").ToString
                        datarow("CONDITION") = REC.Item("CONDITION").ToString
                        datarow("BUY_TYPE") = REC.Item("BUYTYPE").ToString
                        datarow("BUY_AMOUNT") = REC.Item("BUYAMOUNT").ToString
                        datarow("REWARD_TYPE") = REC.Item("REWARDTYPE").ToString
                        datarow("FREE_REWARD") = REC.Item("FREEREWARD").ToString
                        datarow("DISCOUNT_TYPE") = REC.Item("DISTYPE").ToString
                        datarow("DISCOUNT_VALUE") = REC.Item("DISVALUE").ToString
                        datarow("PAY_PROMOTION") = REC.Item("PAYPROMO").ToString
                        datarow("PRIORITY") = CInt(REC.Item("PRIORITY"))
                        DATATABLE.Rows.Add(datarow)
                    End If
                    If CONDITION = "e-book" And BUYTYPE = "value" And CInt(BUYAMOUNT) <= ebook_value Then
                        datarow = DATATABLE.NewRow
                        datarow("PROMOTION_ID") = REC.Item("PROMOTIONID").ToString
                        datarow("PROMOTION_NAME") = REC.Item("PROMOTIONNAME").ToString
                        datarow("CONDITION") = REC.Item("CONDITION").ToString
                        datarow("BUY_TYPE") = REC.Item("BUYTYPE").ToString
                        datarow("BUY_AMOUNT") = REC.Item("BUYAMOUNT").ToString
                        datarow("REWARD_TYPE") = REC.Item("REWARDTYPE").ToString
                        datarow("FREE_REWARD") = REC.Item("FREEREWARD").ToString
                        datarow("DISCOUNT_TYPE") = REC.Item("DISTYPE").ToString
                        datarow("DISCOUNT_VALUE") = REC.Item("DISVALUE").ToString
                        datarow("PAY_PROMOTION") = REC.Item("PAYPROMO").ToString
                        datarow("PRIORITY") = CInt(REC.Item("PRIORITY"))
                        DATATABLE.Rows.Add(datarow)
                    End If
                    If CONDITION = "all" And BUYTYPE = "item" And CInt(BUYAMOUNT) <= (book_num + ebook_num) Then
                        datarow = DATATABLE.NewRow
                        datarow("PROMOTION_ID") = REC.Item("PROMOTIONID").ToString
                        datarow("PROMOTION_NAME") = REC.Item("PROMOTIONNAME").ToString
                        datarow("CONDITION") = REC.Item("CONDITION").ToString
                        datarow("BUY_TYPE") = REC.Item("BUYTYPE").ToString
                        datarow("BUY_AMOUNT") = REC.Item("BUYAMOUNT").ToString
                        datarow("REWARD_TYPE") = REC.Item("REWARDTYPE").ToString
                        datarow("FREE_REWARD") = REC.Item("FREEREWARD").ToString
                        datarow("DISCOUNT_TYPE") = REC.Item("DISTYPE").ToString
                        datarow("DISCOUNT_VALUE") = REC.Item("DISVALUE").ToString
                        datarow("PAY_PROMOTION") = REC.Item("PAYPROMO").ToString
                        datarow("PRIORITY") = CInt(REC.Item("PRIORITY"))
                        DATATABLE.Rows.Add(datarow)
                    End If
                    If CONDITION = "all" And BUYTYPE = "value" And CInt(BUYAMOUNT) <= (book_value + ebook_value) Then
                        datarow = DATATABLE.NewRow
                        datarow("PROMOTION_ID") = REC.Item("PROMOTIONID").ToString
                        datarow("PROMOTION_NAME") = REC.Item("PROMOTIONNAME").ToString
                        datarow("CONDITION") = REC.Item("CONDITION").ToString
                        datarow("BUY_TYPE") = REC.Item("BUYTYPE").ToString
                        datarow("BUY_AMOUNT") = REC.Item("BUYAMOUNT").ToString
                        datarow("REWARD_TYPE") = REC.Item("REWARDTYPE").ToString
                        datarow("FREE_REWARD") = REC.Item("FREEREWARD").ToString
                        datarow("DISCOUNT_TYPE") = REC.Item("DISTYPE").ToString
                        datarow("DISCOUNT_VALUE") = REC.Item("DISVALUE").ToString
                        datarow("PAY_PROMOTION") = REC.Item("PAYPROMO").ToString
                        datarow("PRIORITY") = CInt(REC.Item("PRIORITY"))
                        DATATABLE.Rows.Add(datarow)
                    End If
                    If CONDITION = "from list" And BUYTYPE = "item" And CInt(BUYAMOUNT) <= sp_num Then
                        datarow = DATATABLE.NewRow
                        datarow("PROMOTION_ID") = REC.Item("PROMOTIONID").ToString
                        datarow("PROMOTION_NAME") = REC.Item("PROMOTIONNAME").ToString
                        datarow("CONDITION") = REC.Item("CONDITION").ToString
                        datarow("BUY_TYPE") = REC.Item("BUYTYPE").ToString
                        datarow("BUY_AMOUNT") = REC.Item("BUYAMOUNT").ToString
                        datarow("REWARD_TYPE") = REC.Item("REWARDTYPE").ToString
                        datarow("FREE_REWARD") = REC.Item("FREEREWARD").ToString
                        datarow("DISCOUNT_TYPE") = REC.Item("DISTYPE").ToString
                        datarow("DISCOUNT_VALUE") = REC.Item("DISVALUE").ToString
                        datarow("PAY_PROMOTION") = REC.Item("PAYPROMO").ToString
                        datarow("PRIORITY") = CInt(REC.Item("PRIORITY"))
                        DATATABLE.Rows.Add(datarow)
                    End If
                    If CONDITION = "from list" And BUYTYPE = "value" And CInt(BUYAMOUNT) <= sp_value Then
                        datarow = DATATABLE.NewRow
                        datarow("PROMOTION_ID") = REC.Item("PROMOTIONID").ToString
                        datarow("PROMOTION_NAME") = REC.Item("PROMOTIONNAME").ToString
                        datarow("CONDITION") = REC.Item("CONDITION").ToString
                        datarow("BUY_TYPE") = REC.Item("BUYTYPE").ToString
                        datarow("BUY_AMOUNT") = REC.Item("BUYAMOUNT").ToString
                        datarow("REWARD_TYPE") = REC.Item("REWARDTYPE").ToString
                        datarow("FREE_REWARD") = REC.Item("FREEREWARD").ToString
                        datarow("DISCOUNT_TYPE") = REC.Item("DISTYPE").ToString
                        datarow("DISCOUNT_VALUE") = REC.Item("DISVALUE").ToString
                        datarow("PAY_PROMOTION") = REC.Item("PAYPROMO").ToString
                        datarow("PRIORITY") = CInt(REC.Item("PRIORITY"))
                        DATATABLE.Rows.Add(datarow)
                    End If
                Next
            End If
        Catch ex As Exception
            Throw (New Exception("Exception Check Promotion :" + ex.Message))
        End Try
        

        DATATABLE.DefaultView.Sort = "PRIORITY,PROMOTION_ID ASC"

        Return DATATABLE
    End Function

    Function getPromotion()
        Dim result As String = ""

        Try
            QUERY = ""
            QUERY = QUERY + " SELECT PROMOTIONID , PROMOTIONNAME , CONDITION "
            QUERY = QUERY + " , BUYTYPE , BUYAMOUNT , REWARDTYPE , FREEREWARD "
            QUERY = QUERY + " , DISTYPE , DISVALUE , PAYPROMO , PRIORITY "

            QUERY = QUERY + " FROM EBOOK_PROMOTION_NEW "

            QUERY = QUERY + " WHERE STATUS = 'ACTIVE' "
            QUERY = QUERY + " AND STARTDATE <= GETDATE() "
            QUERY = QUERY + " AND ENDDATE >= GETDATE() "

            RECORD = SQL_CONNECTION.GetDataTable(QUERY)
        Catch ex As Exception
            Throw (New Exception("Exception getPromotion Function :" + ex.Message))
        End Try

        If RECORD.Rows.Count > 0 Then
            result = "Y"
        Else
            result = "N"
        End If

        Return result
    End Function

    Function getSP_FromList(ByVal isbn As String, ByVal type As String, ByVal table As DataTable)

        Try
            QUERY = ""
            QUERY = QUERY + " SELECT SP.PROMOTIONID AS ID , ISNULL(STORE.AUTHOR , '') AS AUTHOR "
            QUERY = QUERY + " , ISNULL(STORE.PUBLISHER , '') AS PUBLISHER , SP.BOOKTYPE AS BOOK_TYPE "
            QUERY = QUERY + " , ISNULL(SP.BOOK_ISBN , '') AS ISBN , ISNULL(TYPE.TYPE , '') AS FORMAT "

            QUERY = QUERY + " FROM EBOOK_FROMSP SP "

            If type = "book" Then
                QUERY = QUERY + " LEFT JOIN ( SELECT DISTINCT ISBN_13 , AUTHOR , SOURCE AS PUBLISHER "
                QUERY = QUERY + " FROM TBT_JOBBER_BOOK_SEARCH WHERE ISBN_13 = '" + isbn + "' ) AS STORE "
                QUERY = QUERY + " ON SP.BOOK_ISBN = STORE.ISBN_13 "
                QUERY = QUERY + " OR SP.AUTHOR_ISBN = STORE.AUTHOR "
                QUERY = QUERY + " OR SP.PUB_ISBN = STORE.PUBLISHER "
            End If
            If type = "ebook" Then
                QUERY = QUERY + " LEFT JOIN ( SELECT DISTINCT ISBN_13 , AUTHOR , PUBLISHER_NAME AS PUBLISHER "
                QUERY = QUERY + " FROM EBOOK_STORE WHERE ISBN_13 = '" + isbn + "' ) AS STORE "
                QUERY = QUERY + " ON SP.BOOK_ISBN = STORE.ISBN_13 "
                QUERY = QUERY + " OR SP.AUTHOR_ISBN = STORE.AUTHOR "
                QUERY = QUERY + " OR SP.PUB_ISBN = STORE.PUBLISHER "
            End If

            QUERY = QUERY + " LEFT JOIN EBOOK_TYPE TYPE "
            QUERY = QUERY + " ON SP.FORMAT = TYPE.FORMATID "

            QUERY = QUERY + " WHERE SP.STATUS = 'ACTIVE' "
            QUERY = QUERY + " AND ( SP.BOOK_ISBN = '" + isbn + "' "
            QUERY = QUERY + " OR SP.AUTHOR_ISBN = STORE.AUTHOR "
            QUERY = QUERY + " OR SP.PUB_ISBN = STORE.PUBLISHER ) "
            QUERY = QUERY + " AND SP.BOOKTYPE = '" + type + "' "

            RECORD = SQL_CONNECTION.GetDataTable(QUERY)
        Catch ex As Exception
            Throw (New Exception("Exception Get FromSP Function :" + ex.Message))
        End Try

        If RECORD.Rows.Count > 0 Then
            table.Merge(RECORD)
        End If

        Return table
    End Function

    Function getSP_List(ByVal id As String)
        Dim CASE_PROMOTION As Integer
        Try
            QUERY = ""
            QUERY = QUERY + " SELECT DISTINCT TOP(1) ISNULL(BOOK_ISBN,'-') AS ISBN_13 "
            QUERY = QUERY + " , ISNULL(AUTHOR_ISBN,'-') AS AUTHOR "
            QUERY = QUERY + " , ISNULL(PUB_ISBN,'-') AS ISBN_13 "
            QUERY = QUERY + " FROM EBOOK_LISTSP "
            QUERY = QUERY + " WHERE PROMOTIONID = " + id + " "

            RECORD = SQL_CONNECTION.GetDataTable(QUERY)

            If Not RECORD.Rows(0).Item("ISBN_13").ToString = "-" Then
                CASE_PROMOTION = 1
            End If

            If Not RECORD.Rows(0).Item("AUTHOR").ToString = "-" Then
                CASE_PROMOTION = 2
            End If

            If Not RECORD.Rows(0).Item("PUBLISHER").ToString = "-" Then
                CASE_PROMOTION = 3
            End If

            If Not RECORD.Rows(0).Item("AUTHOR").ToString = "-" And Not RECORD.Rows(0).Item("PUBLISHER").ToString = "-" Then
                CASE_PROMOTION = 4
            End If

        Catch ex As Exception
            Throw (New Exception("Exception Check Case Promotion :" + ex.Message))
        End Try

        RECORD = Nothing

        Try
            QUERY = ""

            QUERY = QUERY + " SELECT DISTINCT SP.PROMOTIONID AS ID "
            QUERY = QUERY + " , SP.BOOK_ISBN AS ISBN_13 "
            QUERY = QUERY + " , SP.BOOKTYPE AS BOOK_TYPE "
            QUERY = QUERY + " , CASE WHEN SP.BOOKTYPE = 'ebook' THEN EBOOK_STORE.BOOKID ELSE '0' END AS BOOK_ID "
            QUERY = QUERY + " , CASE WHEN SP.BOOKTYPE = 'ebook' THEN EBOOK_STORE.BOOK_TITLE ELSE BOOK_STORE.BOOK_TITLE END AS BOOK_TITLE "
            QUERY = QUERY + " , CASE WHEN SP.BOOKTYPE = 'ebook' THEN EBOOK_STORE.AUTHOR ELSE BOOK_STORE.AUTHOR END AS AUTHOR "
            QUERY = QUERY + " , CASE WHEN SP.BOOKTYPE = 'ebook' THEN EBOOK_STORE.PUBLISHER ELSE BOOK_STORE.PUBLISHER END AS PUBLISHER "
            QUERY = QUERY + " , CASE WHEN SP.BOOKTYPE = 'ebook' THEN TYPE.TYPE ELSE 'PRINTED BOOK' END AS FORMAT "
            QUERY = QUERY + " , CASE WHEN SP.BOOKTYPE = 'ebook' THEN SP.FORMAT ELSE '0' END AS FORMAT_TYPE "
            QUERY = QUERY + " , CASE WHEN SP.BOOKTYPE = 'ebook' THEN EBOOK_STORE.IMAGE ELSE BOOK_STORE.IMAGE END AS IMAGE "
            QUERY = QUERY + " , CASE WHEN SP.BOOKTYPE = 'ebook' THEN LEFT(ISNULL(EBOOK_STORE.SYNOPSIS,'-'),150)+'...' ELSE LEFT(ISNULL(BOOK_STORE.SYNOPSIS,'-'),150)+'...' END AS SYNOPSIS "
            QUERY = QUERY + " , CASE WHEN SP.BOOKTYPE = 'ebook' THEN EBOOK_STORE.SELLING_PRICE * CURRENCY.EXCHANGE_RATE ELSE (CASE WHEN BOOK_STORE.PUBLISHER = 'Asiabooks' THEN BOOK_STORE.SELLING_PRICE ELSE BOOK_STORE.SELLING_PRICE * CURRENCY.EXCHANGE_RATE END) END AS SELLING_PRICE "
            QUERY = QUERY + " , CASE WHEN SP.BOOKTYPE = 'ebook' THEN CURRENCY.EXCHANGE_RATE ELSE (CASE WHEN BOOK_STORE.PUBLISHER = 'Asiabooks' THEN 0 ELSE CURRENCY.EXCHANGE_RATE END) END AS EXCHANGE_RATE "
            QUERY = QUERY + " , CASE WHEN SP.BOOKTYPE = 'ebook' THEN CURRENCY.EXCHANGE_RATE_INTERNET  ELSE (CASE WHEN BOOK_STORE.PUBLISHER = 'Asiabooks' THEN 0 ELSE CURRENCY.EXCHANGE_RATE_INTERNET END) END AS EXCHANGE_RATE_INTERNET "
            QUERY = QUERY + " , CASE WHEN SP.BOOKTYPE = 'ebook' THEN EBOOK_STORE.SIZE + ' KB.' ELSE BOOK_STORE.SIZE + ' KG.' END AS SIZE  "

            QUERY = QUERY + " FROM EBOOK_LISTSP SP "

            QUERY = QUERY + " LEFT JOIN ( SELECT DISTINCT ISBN_13 ,BOOKID , BOOK_TITLE , CAST(FILE_SIZE AS VARCHAR) AS SIZE "
            QUERY = QUERY + " , AUTHOR , PUBLISHER_NAME AS PUBLISHER , SYNOPSIS , SUPPLIER_CODE AS SUPPLIER"
            QUERY = QUERY + " , CONVERT(NUMERIC(13,0),SELLING_PRICE) AS SELLING_PRICE "
            QUERY = QUERY + " , (SUBSTRING(ISBN_10, 1, 3)+'/'+SUBSTRING(ISBN_10, 3, 3)+'/'+SUBSTRING(ISBN_10, 6, 3)+'/'+ISBN_10+'.jpg') AS IMAGE "
            QUERY = QUERY + " FROM EBOOK_STORE "

            If CASE_PROMOTION = 1 Then
                QUERY = QUERY + " WHERE ISBN_13 IN (SELECT BOOK_ISBN "
                QUERY = QUERY + " FROM EBOOK_LISTSP WHERE PROMOTIONID = " + id + ") "
                QUERY = QUERY + " AND UPPER(STATUS) = 'ACTIVE' ) AS EBOOK_STORE "
                QUERY = QUERY + " ON SP.BOOK_ISBN = EBOOK_STORE.ISBN_13 "
            End If
            If CASE_PROMOTION = 2 Then
                QUERY = QUERY + " WHERE AUTHOR IN (SELECT AUTHOR_ISBN "
                QUERY = QUERY + " FROM EBOOK_LISTSP WHERE PROMOTIONID = " + id + ") "
                QUERY = QUERY + " AND UPPER(STATUS) = 'ACTIVE' ) AS EBOOK_STORE "
                QUERY = QUERY + " OR SP.AUTHOR_ISBN = EBOOK_STORE.AUTHOR "
            End If
            If CASE_PROMOTION = 3 Then
                QUERY = QUERY + " WHERE PUBLISHER_NAME IN (SELECT PUB_ISBN "
                QUERY = QUERY + " FROM EBOOK_LISTSP WHERE PROMOTIONID = " + id + ") "
                QUERY = QUERY + " AND UPPER(STATUS) = 'ACTIVE' ) AS EBOOK_STORE "
                QUERY = QUERY + " OR SP.PUB_ISBN = EBOOK_STORE.PUBLISHER "
            End If
            If CASE_PROMOTION = 4 Then
                QUERY = QUERY + " WHERE (AUTHOR IN (SELECT AUTHOR_ISBN  FROM EBOOK_LISTSP WHERE PROMOTIONID = 2) "
                QUERY = QUERY + " AND PUBLISHER_NAME IN (SELECT PUB_ISBN  FROM EBOOK_LISTSP WHERE PROMOTIONID = 2)) "
                QUERY = QUERY + " AND UPPER(STATUS) = 'ACTIVE' ) AS EBOOK_STORE "
                QUERY = QUERY + " OR ( SP.AUTHOR_ISBN = EBOOK_STORE.AUTHOR AND SP.PUB_ISBN = EBOOK_STORE.PUBLISHER ) "
            End If

            QUERY = QUERY + " LEFT JOIN ( SELECT DISTINCT ISBN_13 , BOOK_TITLE  , AUTHOR , SOURCE AS PUBLISHER "
            QUERY = QUERY + " , SYNOPSIS , IMAGE , SELLING_PRICE , CAST(WEIGHT AS VARCHAR) AS SIZE "
            QUERY = QUERY + " FROM TBT_JOBBER_BOOK_SEARCH "

            If CASE_PROMOTION = 1 Then
                QUERY = QUERY + " WHERE ISBN_13 IN (SELECT BOOK_ISBN "
                QUERY = QUERY + " FROM EBOOK_LISTSP WHERE PROMOTIONID = " + id + ")) AS BOOK_STORE "
                QUERY = QUERY + " ON SP.BOOK_ISBN = BOOK_STORE.ISBN_13 "
            End If
            If CASE_PROMOTION = 2 Then
                QUERY = QUERY + " WHERE AUTHOR IN (SELECT AUTHOR_ISBN "
                QUERY = QUERY + " FROM EBOOK_LISTSP WHERE PROMOTIONID = " + id + ")) AS BOOK_STORE "
                QUERY = QUERY + " OR SP.AUTHOR_ISBN = BOOK_STORE.AUTHOR "
            End If
            If CASE_PROMOTION = 3 Then
                QUERY = QUERY + " WHERE SOURCE IN (SELECT PUB_ISBN "
                QUERY = QUERY + " FROM EBOOK_LISTSP WHERE PROMOTIONID = " + id + ")) AS BOOK_STORE "
                QUERY = QUERY + " OR SP.PUB_ISBN = BOOK_STORE.PUBLISHER "
            End If
            If CASE_PROMOTION = 4 Then
                QUERY = QUERY + " WHERE (AUTHOR IN (SELECT AUTHOR_ISBN  FROM EBOOK_LISTSP WHERE PROMOTIONID = 2) "
                QUERY = QUERY + " AND SOURCE IN (SELECT PUB_ISBN  FROM EBOOK_LISTSP WHERE PROMOTIONID = 2))) AS BOOK_STORE "
                QUERY = QUERY + " OR ( SP.AUTHOR_ISBN = BOOK_STORE.AUTHOR AND SP.PUB_ISBN = BOOK_STORE.PUBLISHER ) "
            End If

            QUERY = QUERY + " LEFT JOIN EBOOK_TYPE TYPE "
            QUERY = QUERY + " ON SP.FORMAT = TYPE.FORMATID "

            QUERY = QUERY + " LEFT JOIN (SELECT DISTINCT CURRENCY_CODE , ORG_INDENT_CODE FROM TBM_SYST_ORGANIZEINDENT) AS ORGANIZE"
            QUERY = QUERY + " ON EBOOK_STORE.SUPPLIER = ORGANIZE.ORG_INDENT_CODE "
            QUERY = QUERY + " OR BOOK_STORE.PUBLISHER = ORGANIZE.ORG_INDENT_CODE "

            QUERY = QUERY + " LEFT JOIN (SELECT DISTINCT EXCHANGE_RATE , CURRENCY_CODE , EXCHANGE_RATE_INTERNET FROM TBM_SYST_CURRENCY) AS CURRENCY "
            QUERY = QUERY + " ON ORGANIZE.CURRENCY_CODE = CURRENCY.CURRENCY_CODE "

            QUERY = QUERY + " WHERE SP.STATUS = 'ACTIVE' "
            QUERY = QUERY + " AND SP.PROMOTIONID = " + id + " "


            RECORD = SQL_CONNECTION.GetDataTable(QUERY)
        Catch ex As Exception
            Throw (New Exception("Exception Get ListSP By ID Function :" + ex.Message))
        End Try

        Return RECORD
    End Function

    Function getReward_Discount(ByVal discount_type As String, ByVal discount_value As Integer, ByVal price As Integer)
        If discount_type = "percent" Then
            price = price * (discount_value / 100)
        End If
        If discount_type = "value" Then
            price = price - discount_value
        End If
        Return price
    End Function

    Function getReward_BuyXPayX(ByVal pay_promotion As String)
        Dim PRICE As Integer = 0

        Dim table As DataTable = New DataTable
        table.Columns.Add("ISBN", System.Type.GetType("System.String"))
        table.Columns.Add("NAME", System.Type.GetType("System.String"))
        table.Columns.Add("PRICE", System.Type.GetType("System.Int32"))
        table.Columns.Add("QUANTITY", System.Type.GetType("System.Int32"))
        table.Columns.Add("TYPE", System.Type.GetType("System.String"))

        Dim datarows As DataRow

        If Not DATATABLE_01 Is Nothing Then
            For Each row As DataRow In DATATABLE_01.Rows
                datarows = table.NewRow
                datarows("ISBN") = row.Item("ISBN_13").ToString
                datarows("NAME") = row.Item("BOOK_TITLE").ToString
                datarows("PRICE") = row.Item("SELLING_PRICE")
                datarows("QUANTITY") = row.Item("QUANTITY")
                datarows("TYPE") = "BOOK"
                table.Rows.Add(datarows)
            Next
        End If

        If Not DATATABLE_02 Is Nothing Then
            For Each row As DataRow In DATATABLE_02.Rows
                datarows = table.NewRow
                datarows("ISBN") = row.Item("ISBN_13").ToString
                datarows("NAME") = row.Item("BOOK_TITLE").ToString
                datarows("PRICE") = row.Item("SELLING_PRICE")
                datarows("QUANTITY") = row.Item("QUANTITY")
                datarows("TYPE") = "BOOK"
                table.Rows.Add(datarows)
            Next
        End If

        If Not DATATABLE_03 Is Nothing Then
            For Each row As DataRow In DATATABLE_03.Rows
                datarows = table.NewRow
                datarows("ISBN") = row.Item("ISBN_13").ToString
                datarows("NAME") = row.Item("BOOK_TITLE").ToString
                datarows("PRICE") = row.Item("SELLING_PRICE")
                datarows("QUANTITY") = row.Item("QUANTITY")
                datarows("TYPE") = "BOOK"
                table.Rows.Add(datarows)
            Next
        End If

        table.DefaultView.Sort = "PRICE ASC"

        For i As Integer = 0 To CInt(pay_promotion) - 1
            If table.Rows(i).Item("QUANTITY") >= CInt(pay_promotion) Then
                PRICE = PRICE + table.Rows(i).Item("PRICE") * CInt(pay_promotion)
                Exit For
            Else
                PRICE = PRICE + table.Rows(i).Item("PRICE")
            End If
        Next

        Return PRICE
    End Function
End Class
