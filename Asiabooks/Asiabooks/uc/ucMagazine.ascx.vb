Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports Eordering.BusinessLogic.PageControl
Imports System.Linq
Imports System.Xml
Imports System.Xml.Linq

Partial Class uc_ucMagazine
    Inherits System.Web.UI.UserControl
    Private bd As New Class_book_detail
    Private _Utility As New clsUtility
    Private uCon As uConnect

    Private Sub binddata_book(ByVal cat_name As String)
        Dim str_para As String()
        Dim strpage_name As String = ""
        Dim strcat_name As String = ""
        Dim Datalist As New Object

        Try
            str_para = cat_name.Split("|")
            strpage_name = str_para(0)
            strcat_name = str_para(1)

            Select Case strpage_name
                Case "Magazine"
                    Datalist = Me.Top6_Magazine(strcat_name, uXML.Magazine)
                    Me.lblhead.Visible = False
                    'Me.lblhead.Text = "COMING SOON IN "
                    Me.lblcat_name.Visible = True
                    Me.lblcat_name.Text = Me.Top1_Magazine_Desc(strcat_name, uXML.Magazine)
                    Me.lnkMore.HRef = "~/Magazine_SeeMore.aspx?Page_Name=Magazine|Magazine|" + strcat_name.Replace("&", "$") + ""

                Case "Magazine_Detail"
                    Datalist = Me.Top6_Magazine_Datil(uXML.Magazine)
                    Me.lblhead.Visible = False
                    Me.lblcat_name.Visible = False
                    Me.lnkMore.HRef = "~/Magazine_SeeMore.aspx?Page_Name=Magazine|Magazine|" + strcat_name.Replace("&", "$") + ""

                Case Else
                    Datalist = Nothing

            End Select

            Me.lvBooks.DataSource = Datalist
            Me.lvBooks.DataBind()
        Catch ex As Exception
            Throw ex
        Finally
            str_para = Nothing
            strpage_name = Nothing
            strcat_name = Nothing
            Datalist = Nothing
        End Try
    End Sub

    Private Function Top6_Magazine(ByVal cat_name As String, ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("Magazine") _
                        Where c.Element("Cat_Code") = cat_name _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        image = _Utility.GetImagePath_Magazine(c.Element("image").Value), _
                        book_title = IIf(c.Element("book_title").Value.Length > 38, Left(c.Element("book_title").Value, 38) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("publisher_name").Value.Length > 20, Left(c.Element("publisher_name").Value, 20) & "...", c.Element("publisher_name").Value), _
                        selling_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        price_usd = bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        save_price = c.Element("save_price").Value, _
                        book_title_full = c.Element("book_title").Value, _
                        author_full = c.Element("publisher_name").Value

            Return Items.Take(6)
        Catch ex As Exception
            Throw New Exception("Top6_Magazine : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function
    Private Function Top6_Magazine_Datil(ByVal strfile As String) As Object
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("Magazine") _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        image = _Utility.GetImagePath_Magazine(c.Element("image").Value), _
                        book_title = IIf(c.Element("book_title").Value.Length > 38, Left(c.Element("book_title").Value, 38) & "...", c.Element("book_title").Value), _
                        author = IIf(c.Element("publisher_name").Value.Length > 20, Left(c.Element("publisher_name").Value, 20) & "...", c.Element("publisher_name").Value), _
                        selling_price = CDbl(c.Element("list_price").Value.ToString).ToString("#,###,##0.00"), _
                        your_price = CDbl(c.Element("your_price").Value.ToString).ToString("#,###,##0.00"), _
                        price_usd = bd.callUsd(uXML.Currency, Convert.ToDouble(c.Element("your_price").Value)), _
                        save_price = c.Element("save_price").Value, _
                        book_title_full = c.Element("book_title").Value, _
                        author_full = c.Element("publisher_name").Value

            Return Items.Take(6)
        Catch ex As Exception
            Throw New Exception("Top6_Magazine : " & ex.Message.ToString)
            Return Nothing
        Finally
            xmlDoc = Nothing
        End Try
    End Function
    Private Function Top1_Magazine_Desc(ByVal cat_name As String, ByVal strfile As String) As String
        Dim xmlDoc As XElement

        Try
            xmlDoc = XElement.Load(strfile)

            Dim Items = From c In xmlDoc.Elements("Magazine") _
                        Where c.Element("Cat_Code") = cat_name _
                        Order By Convert.ToInt16(c.Element("OrderNo").Value) Ascending _
                        Select isbn_13 = c.Element("isbn_13").Value, _
                        cat_description = c.Element("Cat_Description").Value

            Return Items.First.cat_description.ToString
        Catch ex As Exception
            Throw New Exception("Top1_Magazine_Desc : " & ex.Message.ToString)
            Return ""
        Finally
            xmlDoc = Nothing
        End Try
    End Function

#Region "Property"

    Property cat_name() As String
        Get
            Return 0
        End Get
        Set(ByVal value As String)
            binddata_book(value)
        End Set
    End Property
#End Region

    Protected Sub lvBooks_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles lvBooks.ItemDataBound

        If e.Item.ItemType = ListViewItemType.DataItem Then

            Dim imgCustomer_Average As Image = e.Item.FindControl("imgCustomer_Average")
            Dim lblCustomerView As Label = e.Item.FindControl("lblCustomerView")
            Dim lblisbn As Label = e.Item.FindControl("lblisbn")
            Dim lblList_Price_H As Label = e.Item.FindControl("lblList_Price_H")
            Dim lblList_Price_D As Label = e.Item.FindControl("lblList_Price_D")
            Dim lblsave_price_L As Label = e.Item.FindControl("lblsave_price_L")
            Dim lblsave_price_C As Label = e.Item.FindControl("lblsave_price_C")
            Dim lblsave_price_R As Label = e.Item.FindControl("lblsave_price_R")
            Dim lblYour_Price As Label = e.Item.FindControl("lblYour_Price")

            If lblList_Price_D.Text = lblYour_Price.Text Then
                lblList_Price_H.Visible = False
                lblList_Price_D.Visible = False
                lblsave_price_L.Visible = False
                lblsave_price_C.Visible = False
                lblsave_price_R.Visible = False
            Else
                lblList_Price_D.Font.Strikeout = True
            End If

            uCon = New uConnect
            Dim strImageUrl As String = ""
            Dim dt_view As New DataTable
            Dim strsql As String = ""

            strsql = ""
            strsql &= " select * from dbo.tbm_AB_CustomerReview"
            strsql &= " where isbn_13 = '" + lblisbn.Text + "'"

            dt_view = uFunction.getDataTable(uCon.conn, strsql)
            If dt_view.Rows.Count > 0 Then
                lblCustomerView.Text = "View : " & dt_view.Rows(0).Item("No_CustomerView").ToString
            Else
                lblCustomerView.Text = "View : 0"
            End If
            imgCustomer_Average.Visible = False


            'strsql = ""
            'strsql &= " select case No_CustomerDiscussion when '0' then '0' else ((No_CusReview1*1)+(No_CusReview2*2)+(No_CusReview3*3)+"
            'strsql &= " (No_CusReview4*4)+(No_CusReview5*5))/No_CustomerDiscussion end as total,*"
            'strsql &= " from dbo.tbm_AB_CustomerReview"
            'strsql &= " where isbn_13 = '" + lblisbn.Text + "'"

            'dt_view = uFunction.getDataTable(uCon.conn, strsql)
            'If dt_view.Rows.Count > 0 Then
            '    Dim strCustomer_Average As String = ""
            '    strCustomer_Average = dt_view.Rows(0).Item("total").ToString
            '    'กรณีคำนวนแล้วได้ 0 ต้องคิดค่าเฉลี่ยเอง
            '    If strCustomer_Average = "0" Then
            '        dt_view.Clear()
            '        strsql = ""
            '        strsql &= " select (CASE WHEN right(isbn_13,2)='00' "
            '        strsql &= " THEN 99*3/99 "
            '        strsql &= " ELSE right(isbn_13,2)*3/right(isbn_13,2) END) AS total,"
            '        strsql &= " (CASE WHEN right(isbn_13,2)='00' "
            '        strsql &= " THEN '99' "
            '        strsql &= " ELSE right(isbn_13,2) END) AS No_CustomerView"
            '        strsql &= " from tbt_jobber_book_search"
            '        strsql &= " where isbn_13 = '" + lblisbn.Text + "'"
            '        dt_view = uFunction.getDataTable(uCon.conn, strsql)
            '        If dt_view.Rows.Count > 0 Then
            '            strCustomer_Average = dt_view.Rows(0).Item("total").ToString
            '            lblCustomerView.Text = dt_view.Rows(0).Item("No_CustomerView").ToString

            '            Select Case strCustomer_Average
            '                Case "1"
            '                    imgCustomer_Average.ImageUrl = "~/images/Template/stars1.gif"
            '                Case "2"
            '                    imgCustomer_Average.ImageUrl = "~/images/Template/stars2.gif"
            '                Case "3"
            '                    imgCustomer_Average.ImageUrl = "~/images/Template/stars3.gif"
            '                Case "4"
            '                    imgCustomer_Average.ImageUrl = "~/images/Template/stars4.gif"
            '                Case "5"
            '                    imgCustomer_Average.ImageUrl = "~/images/Template/stars5.gif"
            '                Case Else
            '                    imgCustomer_Average.ImageUrl = "~/images/Template/stars0.gif"
            '            End Select
            '        End If
            '    Else
            '        lblCustomerView.Text = dt_view.Rows(0).Item("No_CustomerView").ToString

            '        Select Case strCustomer_Average
            '            Case "1"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars1.gif"
            '            Case "2"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars2.gif"
            '            Case "3"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars3.gif"
            '            Case "4"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars4.gif"
            '            Case "5"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars5.gif"
            '            Case Else
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars0.gif"
            '        End Select
            '    End If

            'Else
            '    dt_view.Clear()
            '    strsql = ""
            '    strsql &= " select (CASE WHEN right(isbn_13,2)='00' "
            '    strsql &= " THEN 99*3/99 "
            '    strsql &= " ELSE right(isbn_13,2)*3/right(isbn_13,2) END) AS total,"
            '    strsql &= " (CASE WHEN right(isbn_13,2)='00' "
            '    strsql &= " THEN '99' "
            '    strsql &= " ELSE right(isbn_13,2) END) AS No_CustomerView"
            '    strsql &= " from tbt_jobber_book_search"
            '    strsql &= " where isbn_13 = '" + lblisbn.Text + "'"
            '    dt_view = uFunction.getDataTable(uCon.conn, strsql)
            '    If dt_view.Rows.Count > 0 Then
            '        Dim strCustomer_Average As String = ""
            '        strCustomer_Average = dt_view.Rows(0).Item("total").ToString
            '        lblCustomerView.Text = dt_view.Rows(0).Item("No_CustomerView").ToString

            '        Select Case strCustomer_Average
            '            Case "1"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars1.gif"
            '            Case "2"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars2.gif"
            '            Case "3"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars3.gif"
            '            Case "4"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars4.gif"
            '            Case "5"
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars5.gif"
            '            Case Else
            '                imgCustomer_Average.ImageUrl = "~/images/Template/stars0.gif"
            '        End Select
            '    End If

            'End If
        End If
    End Sub
End Class
