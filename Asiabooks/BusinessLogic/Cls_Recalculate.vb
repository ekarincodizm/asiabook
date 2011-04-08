Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Public Class Cls_Recalculate
    Private strISBN_13 As String
    Private strSale_Channel As String
    Property ISBN_13()
        Get
            Return strISBN_13
        End Get
        Set(ByVal value)
            strISBN_13 = value
        End Set
    End Property
    Property Sale_Channel()
        Get
            Return strSale_Channel
        End Get
        Set(ByVal value)
            strSale_Channel = value
        End Set
    End Property
    Public Function Re_Calculate()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        sqlCommand = "SELECT tbm_asbkeo_bookab.ISBN_13,"
        sqlCommand &= "		tbm_asbkeo_bookab.Book_Title,"
        sqlCommand &= "		tbt_jobber_stockab.Org_AB_Code as To_Org_AB_code,"
        sqlCommand &= "		tbm_asbkeo_bookab.Weight,"
        sqlCommand &= "		tbt_jobber_stockab.QTY-Minimum_Stock_Branch as Quantity,"
        sqlCommand &= "		tbm_asbkeo_bookab.Selling_Price,isnull(Lead_Time,0) as Lead_Time,"
        sqlCommand &= "		tbm_asbkeo_bookab.Selling_Price*(tbt_jobber_stockab.QTY-Minimum_Stock_Branch) as Amount,"
        sqlCommand &= "		Group_code,"
        sqlCommand &= "		tbm_jobber_book_indent.Selling_Price+(tbm_jobber_book_indent.Selling_Price*"
        sqlCommand &= "		(SELECT Mark_Up From tbm_syst_saleschannel WHERE Sales_Channel_Code='" + Sale_Channel + "'"
        sqlCommand &= "			AND From_Pub_Discount<=tbm_jobber_book_indent.discount									"
        sqlCommand &= "			AND To_Pub_Discount>=tbm_jobber_book_indent.discount)/100) as Selling_Price_Jobber,"
        sqlCommand &= "		tbt_jobber_stockindent.On_hand_Qty-Minimum_Stock_Jobber as On_hand_Qty,"
        sqlCommand &= "		CASE WHEN tbt_jobber_stockindent.On_hand_Qty-Minimum_Stock_Jobber <=0 "
        sqlCommand &= "			 THEN (SELECT Lead_Time_day FROM tbm_syst_leadtime WHERE Stock_status='Not Available')"
        sqlCommand &= "			 ELSE (SELECT Lead_Time_day FROM tbm_syst_leadtime WHERE Stock_status='Available')"
        sqlCommand &= "			 END as Lead_Time_Jobber,"
        sqlCommand &= "		tbt_jobber_stockindent.Org_Indent_code				"
        sqlCommand &= "FROM ((((((tbt_jobber_book_search LEFT OUTER JOIN tbm_asbkeo_bookab"
        sqlCommand &= "		ON tbt_jobber_book_search.ISBN_13=tbm_asbkeo_bookab.ISBN_13)"
        sqlCommand &= "		LEFT OUTER JOIN tbt_jobber_stockab "
        sqlCommand &= "		ON tbm_asbkeo_bookab.ISBN_13=tbt_jobber_stockab.ISBN_13)"
        sqlCommand &= "		LEFT OUTER JOIN tbm_syst_organizeab "
        sqlCommand &= "		ON tbt_jobber_stockab.Org_AB_Code=tbm_syst_organizeab.Org_AB_code)"
        sqlCommand &= "		LEFT OUTER JOIN tbm_syst_organizeabableadtime"
        sqlCommand &= "		ON tbt_jobber_stockab.Org_AB_Code=tbm_syst_organizeabableadtime.To_Org_AB_Code "
        sqlCommand &= "		AND tbm_syst_organizeab.Org_AB_Code=tbm_syst_organizeabableadtime.From_Org_AB_Code)"
        sqlCommand &= "		LEFT OUTER JOIN tbt_jobber_stockindent"
        sqlCommand &= "		ON tbt_jobber_stockab.ISBN_13=tbt_jobber_stockindent.ISBN_13)"
        sqlCommand &= "		LEFT OUTER JOIN tbm_jobber_book_indent"
        sqlCommand &= "		ON tbt_jobber_book_search.ISBN_13=tbm_jobber_book_indent.ISBN_13),"
        sqlCommand &= "		tbm_syst_company "
        sqlCommand &= "WHERE   tbt_jobber_book_search.ISBN_13 = '" + ISBN_13 + "' "
        sqlCommand &= "AND     tbt_jobber_stockab.QTY-Minimum_Stock_Branch>0"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
End Class
