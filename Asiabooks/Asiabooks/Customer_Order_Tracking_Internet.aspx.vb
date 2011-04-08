Imports Eordering.BusinessLogic
Imports System.Web.UI
Imports System
Imports System.Data
Imports MycustomDG
Imports Eordering.BusinessLogic.PageControl
Imports Microsoft.VisualBasic
Imports Thailandpost_Track

Partial Class Customer_Order_Tracking_Internet
    Inherits System.Web.UI.Page
    Dim dt As DataTable
    Dim sno As Integer = 0
    Dim Co As New Cls_Customer_Order
    Dim Url As String
    Dim EMS_Tracking As New Thailandpost_Track.TrackandTraceService
    Dim PaymentService As New ws_payment.paymentservice.PaymentService

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Cutomer order tacking ::"
        If Not Me.IsPostBack Then
            Me.ViewState("action") = Me.Request.QueryString("action").ToString()
            If Me.ViewState("action").ToString() = "Edit" Then
                lbl_h_order_no.Text = Me.Request.QueryString("Order_No").ToString()
                ShowCo()
                bindDataAvilable(dt)
                bindDataOutofStock(dt)
                bindDataEBook(dt)
            End If
        End If
        Session("Order_No") = Me.lbl_h_order_no.Text
        Me.b_export.Attributes.Add("onclick", "window.open('Customer_Order_Tracking_Internet_export.aspx')")

    End Sub

    Private Sub ShowCo()
        Dim sqlDB As SqlDb = New SqlDb
        Dim dt_temp1 As DataTable
        Co.Order_No = Me.lbl_h_order_no.Text
        dt_temp1 = sqlDB.GetDataTable("select * from tbt_asbkeo_cus_order where order_no = '" + lbl_h_order_no.Text + "' ")
        If dt_temp1.Rows(0).Item("Transport_Type").ToString = "PICK UP AT BRANCH" Or dt_temp1.Rows(0).Item("Transport_Type").ToString = "" Then
            dt = Co.RetreiveCo_PickUpAsBranch()
        Else
            dt = Co.RetreiveCo()

        End If

        If dt.Rows.Count <> 0 Then
            lbl_h_Order_Date.Text = dt.Rows(0).Item("Order_Date")
            lbl_h_customer_name.Text = dt.Rows(0).Item("Customer_Name") + " " + dt.Rows(0).Item("Last_Name")
            lbl_h_telephone.Text = dt.Rows(0).Item("Telephone")
            lbl_total_amount.Text = Convert.ToDouble(dt.Rows(0).Item("Total_Amount")).ToString("#,##0.00")
            lbl_delivery_cost.Text = Convert.ToDouble(dt.Rows(0).Item("Delivery_Cost")).ToString("#,##0.00")
            lbl_grand_total.Text = Convert.ToDouble(dt.Rows(0).Item("Grand_Total")).ToString("#,##0.00")
            lbl_currency.Text = dt.Rows(0).Item("Payment_Type").ToString
            lbl_transport_type.Text = dt.Rows(0).Item("Transport_Type")
            If lbl_transport_type.Text = "Air Courier" Then
                lbl_Day.Text = "International : 3-7 Days"
            ElseIf lbl_transport_type.Text = "EMS" Then
                lbl_Day.Text = "Domestic : 2-4 Days"
            End If
            If dt.Rows(0).Item("Payment_method_Name").ToString.Trim = "Counter Service" Then
                ImgPrint.Visible = True
            Else
                ImgPrint.Visible = False
            End If
            lbl_country_name.Text = dt.Rows(0).Item("Country_Name")
            lbl_country_name.Text = dt.Rows(0).Item("Country_Name")
            lbl_ship_name.Text = dt.Rows(0).Item("Ship_to_name")
            tbx_ship_address.Text = dt.Rows(0).Item("Ship_to_address")
            lbl_billing_name.Text = dt.Rows(0).Item("Billing_Name")
            tbx_billing_address.Text = dt.Rows(0).Item("Billing_Address")
            lblemail.Text = dt.Rows(0).Item("Email")

            If dt.Rows(0).Item("Gift_Flag") = "1" Then
                lbl_send.Text = "Send items as a gift with our free gift-wrap"
                lbl_from.Text = "FROM : " + dt.Rows(0).Item("Gift_From")
                lbl_to.Text = "TO : " + dt.Rows(0).Item("Gift_to")
                lbl_message.Text = "MESSAGE : " + dt.Rows(0).Item("Gift_Message")
            Else
                lbl_send.Text = "Don't Send items as a gift with our free gift-wrap. "
                lbl_from.Text = ""
                lbl_to.Text = ""
                lbl_message.Text = ""
            End If

            lbl_datagrid1_delivery_cost.Text = Convert.ToDouble(dt.Rows(0).Item("Delivery_Available")).ToString("#,##0.00")
            lbl_datagrid2_delivery_cost.Text = Convert.ToDouble(dt.Rows(0).Item("Delivery_special")).ToString("#,##0.00")
            lbl_payment.Text = dt.Rows(0).Item("Payment_method_Name")
            lbl_total_amount_usd.Text = "US$" + Convert.ToDouble(dt.Rows(0).Item("Total_Amount_USD")).ToString("#,##0.00")
            lbl_delivery_cost_usd.Text = "US$" + Convert.ToDouble(dt.Rows(0).Item("Delivery_Cost_USD")).ToString("#,##0.00")
            lbl_grand_total_usd.Text = "US$" + Convert.ToDouble(dt.Rows(0).Item("Grand_Total_USD")).ToString("#,##0.00")

        End If


    End Sub
    Private Sub bindDataAvilable(ByVal ds As DataTable)
        Co.Order_No = Me.lbl_h_order_no.Text
        Me.dt = Co.RetreiveCoAviable_Internet
        Me.Datagrid1.DataSource = dt
        Me.Datagrid1.DataBind()
        If Datagrid1.Items.Count <> 0 Then
            Panel1.Visible = True
            Co.TotalOutofAviable()
            If dt.Rows(0).Item("EMS_Tracking").ToString <> "" Then
                lblEMS.Visible = True
                lnkEMS.Visible = True
                trEMS0.Visible = True
                trEMS.Visible = True
                lnkEMS.Text = dt.Rows(0).Item("EMS_Tracking").ToString
                GetEMS_Tracking()

            Else
                lblEMS.Visible = False
                lnkEMS.Visible = False
                trEMS0.Visible = False
                trEMS.Visible = False
            End If

            If Co.maxleadtime1 <> "" Then
                Me.lbl_datagrid1_max_leadtime.Text = Co.maxleadtime1
            Else
                Me.lbl_datagrid1_max_leadtime.Text = "0"
            End If
            If Co.totalweight1 <> "" Then
                Me.lbl_datagrid1_Total_Weight.Text = Convert.ToDouble(Co.totalweight1).ToString("#,##0.00")
            Else
                Me.lbl_datagrid1_Total_Weight.Text = "0.00"
            End If
            If Co.totalamount1 <> "" Then
                Me.lbl_datagrid1_amount.Text = Convert.ToDouble(Co.totalamount1).ToString("#,##0.00")
            Else
                Me.lbl_datagrid1_amount.Text = "0.00"
            End If
            If Co.delivertycost1 <> "" Then
                lbl_datagrid1_delivery_cost.Text = Convert.ToDouble(Co.delivertycost1).ToString("#,##0.00")
            Else
                lbl_datagrid1_delivery_cost.Text = "0.00"
            End If
            If Co.Exchange_Rate <> 0 Then
                lbl_datagrid1_amount_usd.Text = "US$" + (Convert.ToDouble(lbl_datagrid1_amount.Text) / Convert.ToDouble(Co.Exchange_Rate)).ToString("#,##0.00")
                lbl_datagrid1_delivery_cost_usd.Text = "US$" + (Convert.ToDouble(lbl_datagrid1_delivery_cost.Text) / Convert.ToDouble(Co.Exchange_Rate)).ToString("#,##0.00")
            Else
                lbl_datagrid1_amount_usd.Text = "US$0.00"
                lbl_datagrid1_delivery_cost_usd.Text = "US$0.00"
            End If
        Else
            Panel1.Visible = False
            Me.UpdatePanel2.Visible = False
            trBook.Visible = False
        End If
    End Sub

    Private Sub bindDataOutofStock(ByVal ds As DataTable)
        Co.Order_No = Me.lbl_h_order_no.Text
        Me.dt = Co.RetreiveCoOutofStock_Interner
        Me.Datagrid2.DataSource = dt
        Me.Datagrid2.DataBind()
        If Datagrid2.Items.Count <> 0 Then
            Panel2.Visible = True

            Co.TotalOutofStock()
            If dt.Rows(0).Item("EMS_Tracking").ToString <> "" Then
                lblEMS.Visible = True
                lnkEMS.Visible = True
                trEMS0.Visible = True
                trEMS.Visible = True
                lnkEMS.Text = dt.Rows(0).Item("EMS_Tracking").ToString
                GetEMS_Tracking()

            Else
                lblEMS.Visible = False
                lnkEMS.Visible = False
                trEMS0.Visible = False
                trEMS.Visible = False
            End If

            If Co.maxleadtime2 <> "" Then
                Me.lbl_datagrid2_max_leadtime.Text = Co.maxleadtime2
            Else
                Me.lbl_datagrid2_max_leadtime.Text = "0"
            End If

            If Co.totalweight2 <> "" Then
                Me.lbl_datagrid2_Total_Weight.Text = Convert.ToDouble(Co.totalweight2).ToString("#,##0.00")
            Else
                Me.lbl_datagrid2_Total_Weight.Text = "0.00"
            End If
            If Co.totalamount2 <> "" Then
                Me.lbl_datagrid2_amount.Text = Convert.ToDouble(Co.totalamount2).ToString("#,##0.00")
            Else
                Me.lbl_datagrid2_amount.Text = "0.00"
            End If
            If Co.delivertycost2 <> "" Then
                lbl_datagrid2_delivery_cost.Text = Convert.ToDouble(Co.delivertycost2).ToString("#,##0.00")
            Else
                lbl_datagrid2_delivery_cost.Text = "0.00"
            End If
            If Co.Exchange_Rate <> 0 Then
                lbl_datagrid2_amount_usd.Text = "US$" + (Convert.ToDouble(lbl_datagrid2_amount.Text) / Convert.ToDouble(Co.Exchange_Rate)).ToString("#,##0.00")
                lbl_datagrid2_delivery_cost_usd.Text = "US$" + (Convert.ToDouble(lbl_datagrid2_delivery_cost.Text) / Convert.ToDouble(Co.Exchange_Rate)).ToString("#,##0.00")
            Else
                lbl_datagrid2_amount_usd.Text = "US$0.00"
                lbl_datagrid2_delivery_cost_usd.Text = "US$0.00"
            End If
        Else
            Panel2.Visible = False
            Me.UpdatePanel1.Visible = False
        End If
    End Sub

    Private Sub bindDataEBook(ByVal ds As DataTable)
        Co.Order_No = Me.lbl_h_order_no.Text
        Me.dt = Co.RetreiveCoEBook
        Me.ebook.DataSource = dt
        Me.ebook.DataBind()
        If ebook.Items.Count <> 0 Then
            Panel3.Visible = True

            Co.TotalEBook()
           
            If Co.totalamount3 <> "" Then
                Me.lbl_ebook_amount.Text = Convert.ToDouble(Co.totalamount3).ToString("#,##0.00")
            Else
                Me.lbl_ebook_amount.Text = "0.00"
            End If
            If Co.promo_discount_amount <> "0.00" Then
                Me.P_ebook_promo.Visible = True
                lbl_ebook_discount_amount.Text = Convert.ToDouble(Co.promo_discount_amount).ToString("#,##0.00")
                Me.lblpromo_discount.Text = "Promotion Discount (" + Co.promo_discount + "%)"
            Else
                Me.P_ebook_promo.Visible = False
                lbl_ebook_discount_amount.Text = "0.00"
            End If
            If Co.Exchange_Rate <> 0 Then
                lbl_ebook_amount_usd.Text = "US$" + (Convert.ToDouble(lbl_ebook_amount.Text) / Convert.ToDouble(Co.Exchange_Rate)).ToString("#,##0.00")
                lbl_ebook_discount_amount_usd.Text = "US$" + (Convert.ToDouble(lbl_ebook_discount_amount.Text) / Convert.ToDouble(Co.Exchange_Rate)).ToString("#,##0.00")
            Else
                lbl_ebook_amount_usd.Text = "US$0.00"
                lbl_ebook_discount_amount_usd.Text = "US$0.00"
            End If
           
        Else
            Panel3.Visible = False
        End If
    End Sub

    Protected Sub b_export_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles b_export.Click
        Session("Order_No") = Me.lbl_h_order_no.Text
    End Sub

    Protected Sub ImgPrint_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgPrint.Click
        Co.Order_No = Me.lbl_h_order_no.Text
        If lbl_transport_type.Text = "PICK UP AT BRANCH" Then
            dt = Co.RetreiveCo_PickUpAsBranch()
        Else
            dt = Co.RetreiveCo()

        End If

        Dim CartDateArr(2) As String
        Dim CartDateConvert As String
        Dim CheckOrderNo As String
        CheckOrderNo = "0" + Right(lbl_h_order_no.Text, 9)

        CartDateArr = dt.Rows(0).Item("Order_Date").ToString.Split("/")
        CartDateConvert = CartDateArr(1) & "/" & CartDateArr(0) & "/" & CartDateArr(2)
        'CartDateConvert = CartDateArr(0) & "/" & CartDateArr(1) & "/" & CartDateArr(2)
        Url = PaymentService.PaymentCounterService(Request.Url.ToString, _
                           Page.Request.ServerVariables("REMOTE_ADDR"), CartDateConvert, lbl_h_order_no.Text, _
                          dt.Rows(0).Item("Member_Id"), Convert.ToDecimal(lbl_grand_total.Text).ToString("0.00"), CheckOrderNo, "02", "Order By www.Asiabooks.com - สั่งซื้อสินค้าจาก www.Asiabooks.com") '"Payment By Counter Service")
        ScriptManager.RegisterClientScriptBlock(Me.UpdatePanel1, Me.GetType, "Alert", "window.open('" + Url + "');", True)
    End Sub

    Protected Sub lnkEMS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkEMS.Click

        Me.mdlPopUp_EMS.Show()

    End Sub
    Private Sub GetEMS_Tracking()
        Dim dt As New Thailandpost_Track.TrackItem


        dt = EMS_Tracking.GetItems("asiabooks", "SJpQK/wMVmE02ios+e4F1A==", "en", lnkEMS.Text)
        

        Dim dt_ems As New DataTable
        Dim dr As DataRow
        'dt_ems.Columns.Add(New DataColumn("Barcode", System.Type.GetType("System.String")))
        dt_ems.Columns.Add(New DataColumn("DateTime", System.Type.GetType("System.String")))
        dt_ems.Columns.Add(New DataColumn("DeliveryDateTime", System.Type.GetType("System.String")))
        dt_ems.Columns.Add(New DataColumn("Description", System.Type.GetType("System.String")))
        dt_ems.Columns.Add(New DataColumn("Location", System.Type.GetType("System.String")))
        dt_ems.Columns.Add(New DataColumn("Signature", System.Type.GetType("System.String")))
        dt_ems.Columns.Add(New DataColumn("StatusName", System.Type.GetType("System.String")))

        For i As Integer = 0 To dt.ItemsData.Length - 1
            dr = dt_ems.NewRow()
            'dr("Barcode") = dt.ItemsData(i).Barcode
            dr("DateTime") = dt.ItemsData(i).DateTime
            dr("DeliveryDateTime") = dt.ItemsData(i).DeliveryDateTime
            dr("Description") = dt.ItemsData(i).StatusName
            dr("Location") = dt.ItemsData(i).Location
            dr("Signature") = dt.ItemsData(i).Signature
            dr("StatusName") = dt.ItemsData(i).Description

            dt_ems.Rows.Add(dr)

        Next


        Dim strdesc As String = ""
        If dt.ItemsData.Length = 1 Then
            strdesc = dt.ItemsData(0).StatusName
            If strdesc = "not found" Then
                Label1.Visible = True
                Label2.Visible = True
                gvEMS.Visible = False
            Else
                Label1.Visible = False
                Label2.Visible = False
                gvEMS.DataSource = dt_ems
                gvEMS.DataBind()
            End If
        Else
            Label1.Visible = False
            Label2.Visible = False
            gvEMS.DataSource = dt_ems
            gvEMS.DataBind()
        End If

    End Sub

    Protected Sub ebook_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles ebook.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lbl_Amount_ebook As Label = e.Item.FindControl("lbl_Amount_ebook")

            If CDbl(IIf(lbl_Amount_ebook.Text = "", "0", lbl_Amount_ebook.Text)) = 0 Then
                Dim lbl_Price_ebook As Label = e.Item.FindControl("lbl_Price_ebook")
                lbl_Price_ebook.Visible = False

                Dim lbl_Price_ebook_free As Label = e.Item.FindControl("lbl_Price_ebook_free")
                lbl_Price_ebook_free.Visible = True
            Else
                Dim lbl_Price_ebook As Label = e.Item.FindControl("lbl_Price_ebook")
                lbl_Price_ebook.Visible = True

                Dim lbl_Price_ebook_free As Label = e.Item.FindControl("lbl_Price_ebook_free")
                lbl_Price_ebook_free.Visible = False
            End If

        End If
    End Sub
End Class