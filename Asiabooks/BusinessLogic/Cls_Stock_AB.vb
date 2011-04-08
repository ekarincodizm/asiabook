Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data

Public Class Cls_Stock_AB
    Private strISBN_10 As String
    Private strISBN_13 As String
    Private strOrg_AB_Code As String
    Private strQty As String
    Property ISBN_10()
        Get
            Return strISBN_10
        End Get
        Set(ByVal value)
            strISBN_10 = value
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

    Property Org_AB_Code()
        Get
            Return strOrg_AB_Code
        End Get
        Set(ByVal value)
            strOrg_AB_Code = value
        End Set
    End Property

    Property Qty()
        Get
            Return strQty
        End Get
        Set(ByVal value)
            strQty = value
        End Set
    End Property
    Public Function RetreiveByGroupCode(ByVal Group_Code As String)
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = " SELECT tbt_jobber_stockab.ISBN_10"
        sqlCommand = sqlCommand & ",tbt_jobber_stockab.ISBN_13"
        sqlCommand = sqlCommand & ",tbt_jobber_stockab.Org_AB_Code"
        sqlCommand = sqlCommand & ",isnull(sum(tbt_jobber_stockab.Qty),0) as Qty"
        sqlCommand = sqlCommand & ",tbm_syst_organizeab.Org_AB_Name"
        sqlCommand = sqlCommand & ",tbm_syst_organizeab.Group_Code"
        sqlCommand = sqlCommand & ",isnull(sum(tbt_jobber_stockab.on_order_qty),0) as on_order_qty"
        ' find leadtime
        sqlCommand = sqlCommand & ",tbm_syst_organizeabableadtime.Lead_Time"
        sqlCommand = sqlCommand & " From tbt_jobber_stockab,tbm_syst_organizeab  "
        ' find leadtime
        sqlCommand = sqlCommand & " ,tbm_syst_organizeabableadtime "
        sqlCommand = sqlCommand & " where tbt_jobber_stockab.Org_AB_Code=tbm_syst_organizeab.Org_AB_Code"
        sqlCommand = sqlCommand & " and tbt_jobber_stockab.ISBN_13='" + ISBN_13 + "'"
        sqlCommand = sqlCommand & " and tbm_syst_organizeab.Group_Code='" & Group_Code & "' "
        ' find leadtime
        sqlCommand = sqlCommand & " and tbm_syst_organizeabableadtime.To_Org_AB_Code = tbt_jobber_stockab.Org_AB_Code "
        sqlCommand = sqlCommand & " and tbm_syst_organizeabableadtime.From_Org_AB_Code='" & Org_AB_Code & "' "
        sqlCommand = sqlCommand & " group by tbt_jobber_stockab.ISBN_10,tbt_jobber_stockab.ISBN_13, "
        sqlCommand = sqlCommand & " tbt_jobber_stockab.Org_AB_Code,tbm_syst_organizeab.Org_AB_Name,tbm_syst_organizeab.Group_Code, "
        sqlCommand = sqlCommand & " tbm_syst_organizeabableadtime.Lead_Time "
        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt
    End Function
    Public Function Retreive()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""
        If ISBN_10 <> "" Then
            condition = " WHERE ISBN_10='" + ISBN_10 + "'"
        End If

        If ISBN_13 <> "" Then
            If condition.Length = 0 Then
                condition = " WHERE ISBN_13='" + ISBN_13 + "'"
            Else
                condition = condition & " AND ISBN_13='" + ISBN_13 + "'"
            End If
        End If

        If Qty <> "" Then
            If condition.Length = 0 Then
                condition = " WHERE Qty='" + Qty + "'"
            Else
                condition = condition & " AND Qty='" + Qty + "'"
            End If
        End If


        If Org_AB_Code <> "" Then
            If condition.Length = 0 Then
                condition = " WHERE Org_AB_Code='" + Org_AB_Code + "'"
            Else
                condition = condition & " AND Org_AB_Code='" + Org_AB_Code + "'"
            End If
        End If

        sqlCommand = " SELECT *"
        sqlCommand = sqlCommand & ",(select Org_AB_Name from tbm_syst_organizeab where Org_AB_code=tbt_jobber_stockab.Org_AB_code) as Org_AB_Name "
        sqlCommand = sqlCommand & " From tbt_jobber_stockab " + condition
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Function RetreiveInformation()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""


        sqlCommand = "select tbt_jobber_book_search.isbn_13"
        sqlCommand &= " ,CASE WHEN convert(varchar,tbm_asbkeo_bookab.Maintenance_Date,103) = '01/01/1900' OR tbm_asbkeo_bookab.Maintenance_Date = '' THEN '-' ELSE convert(varchar,tbm_asbkeo_bookab.Maintenance_Date,103) END AS Maintenance_Date"
        'sqlCommand &= "		,case when tbm_asbkeo_bookab.Maintenance_Date is null or  tbm_asbkeo_bookab.Maintenance_Date ='' then '-' else tbm_asbkeo_bookab.Maintenance_Date end  as Maintenance_Date"
        'sqlCommand &= "		,case when tbm_asbkeo_bookab.field2 is null or  tbm_asbkeo_bookab.field2 ='' then '-' else tbm_asbkeo_bookab.field2 end  as field2"
        sqlCommand &= "		,case when tbm_asbkeo_bookab.ETA is null or  tbm_asbkeo_bookab.ETA ='' then '-' else tbm_asbkeo_bookab.ETA end  as ETA"
        sqlCommand &= "		,case when tbm_asbkeo_bookab.Remark is null or  tbm_asbkeo_bookab.Remark ='' then '-' else tbm_asbkeo_bookab.Remark end  as Remark"
        sqlCommand &= "		,isnull(tbt_jobber_stockab.on_order_qty,0) as on_order_qty"
        sqlCommand &= " from tbt_jobber_book_search  left join (select isbn_13,Maintenance_Date,ETA,Remark from tbm_asbkeo_bookab "
        sqlCommand &= "		group by isbn_13,Maintenance_Date,ETA,Remark) as tbm_asbkeo_bookab"
        sqlCommand &= "		on tbt_jobber_book_search.isbn_13=tbm_asbkeo_bookab.isbn_13"
        sqlCommand &= "		left join ( select isbn_13,sum(on_order_qty) as on_order_qty from tbt_jobber_stockab "
        sqlCommand &= "     group by isbn_13 ) as tbt_jobber_stockab"
        sqlCommand &= "		on tbt_jobber_book_search.isbn_13=tbt_jobber_stockab.isbn_13"
        sqlCommand &= " where tbt_jobber_book_search.isbn_13='" + ISBN_13 + "'"
        dt = sqlDb.GetDataTable(sqlCommand)

        Return dt

    End Function
    Public Function GetGroupAB() As String
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = " SELECT Group_Code From tbm_syst_organizeab WHERE Org_AB_Code='" + Org_AB_Code + "'"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt.Rows(0).Item(0)
    End Function
    Public Function GetBookTitle() As String
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = " SELECT Book_Title From tbt_jobber_book_search WHERE ISBN_13='" + ISBN_13 + "'"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt.Rows(0).Item(0)
    End Function
    Public Function GetStockIndent()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = "select ISBN_13,Org_Indent_code,"
        sqlCommand &= "  isnull(sum(On_hand_Qty),0) as On_hand_Qty,case isnull(On_hand_Qty,0) when '0' then '0' else "
        sqlCommand &= "	 (select lead_time_day  from tbm_syst_leadtime where stock_status = 'Available') end as LT_On_Hand, "
        sqlCommand &= "	 isnull(sum(On_Order_Qty),0) as On_Order_Qty,case isnull(On_Order_Qty,0) when '0' then '0' else "
        sqlCommand &= "  (select lead_time_day  from tbm_syst_leadtime where stock_status = 'Not Available') end as LT_On_Order "
        sqlCommand &= "   from tbt_jobber_stockindent "
        sqlCommand &= " where isbn_13='" + ISBN_13 + "'"
        sqlCommand &= "		group by ISBN_13,Org_Indent_code,On_hand_Qty,On_Order_Qty"
        dt = sqlDb.GetDataTable(sqlCommand)


        'sqlCommand = " select ISBN_13,Org_Indent_code,sum(On_hand_Qty) as On_hand_Qty,sum(On_Order_Qty) as On_Order_Qty from tbt_jobber_stockindent WHERE ISBN_13='" + ISBN_13 + "'"
        'sqlCommand &= "		group by ISBN_13,Org_Indent_code"
        'dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function

End Class
