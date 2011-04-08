Imports System.Data
Imports Subgurim.Controles

Partial Class Store_Event_Detail
    Inherits System.Web.UI.Page
    Private uCon As uConnect
    Public Sub getUrl(ByVal imagePath As String)

        Response.Write(Request.Url.Scheme.ToString & Uri.SchemeDelimiter.ToString & _
                       Request.Url.Authority.ToString & _
                       IIf(Request.ApplicationPath.ToString = "/", "", Request.ApplicationPath.ToString) & imagePath)

    End Sub
    Private Function getUrl1(ByVal imagePath As String) As String
        Dim imag1 As String = ""
        imag1 = Request.Url.Scheme.ToString & Uri.SchemeDelimiter.ToString & _
                       Request.Url.Authority.ToString & _
                       IIf(Request.ApplicationPath.ToString = "/", "", Request.ApplicationPath.ToString) & imagePath
        Return imag1
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Store & Event ::"
        If Not IsPostBack Then
            GetData()

        End If
    End Sub
    Private Sub GetBranch_AB()
        Dim dt_ab As New DataTable
        Dim strhtml_ab As String = ""
        Dim imag_ab As String = ""

        uCon = New uConnect
        dt_ab = uFunction.getDataTable(uCon.conn, "select * from tbm_syst_organizeab where group_code = 'ab' and status <> 'N'")
        imag_ab = getUrl1("/images/Template/StoreDetail_ab.jpg")

        strhtml_ab &= " <ul id='store_event'>"
        strhtml_ab &= " <li><a href='#nogo'><img alt='' src='" + imag_ab + "' border='0' /></a>"
        strhtml_ab &= " <ul>"
        strhtml_ab &= " <li style='height:7px'></li>"

        For iab As Integer = 0 To dt_ab.Rows.Count - 1
            strhtml_ab &= " <li><a href='Store_Event_Detail.aspx?Branch_Code=" + dt_ab.Rows(iab).Item("org_ab_code").ToString + " &Branch_Group=" + dt_ab.Rows(iab).Item("group_code").ToString + "'>" + dt_ab.Rows(iab).Item("org_ab_name").ToString + "</a></li>"
        Next
        strhtml_ab &= " <li style='height:7px'></li>"
        strhtml_ab &= " </ul>"
        strhtml_ab &= " </li>"
        strhtml_ab &= " </ul>"
        spanab.InnerHtml = strhtml_ab.ToString()

    End Sub
    Private Sub GetBranch_BZ()
        Dim imag_bz As String = ""
        Dim dt_bz As New DataTable
        Dim strhtml_bz As String = ""
        uCon = New uConnect

        dt_bz = uFunction.getDataTable(uCon.conn, "select * from tbm_syst_organizeab where group_code = 'bz' and status <> 'N'")
        imag_bz = getUrl1("/images/Template/store&event_bz.jpg")

        strhtml_bz &= " <ul id='store_event'>"
        strhtml_bz &= " <li><a href='#nogo'><img alt='' src='" + imag_bz + "' border='0' /></a>"
        strhtml_bz &= " <ul>"
        strhtml_bz &= " <li style='height:7px'><a href='#nogo'></a></li>"

        For ibz As Integer = 0 To dt_bz.Rows.Count - 1
            strhtml_bz &= " <li><a href='Store_Event_Detail.aspx?Branch_Code=" + dt_bz.Rows(ibz).Item("org_ab_code").ToString + " &Branch_Group=" + dt_bz.Rows(ibz).Item("group_code").ToString + "'>" + dt_bz.Rows(ibz).Item("org_ab_name").ToString + "</a></li>"
        Next
        strhtml_bz &= " <li style='height:7px'><a href='#nogo'></a></li>"
        strhtml_bz &= " </ul>"
        strhtml_bz &= " </li>"
        strhtml_bz &= " </ul>"
        spanbz.InnerHtml = strhtml_bz.ToString()


    End Sub
    Private Sub GetData()
        Dim dt As New DataTable
        Dim strBranch_code As String = ""
        Dim strBranch_Group As String = ""

        uCon = New uConnect
        strBranch_code = Request.QueryString("Branch_Code")
        strBranch_Group = Request.QueryString("Branch_Group")

        dt = uFunction.getDataTable(uCon.conn, "select isnull(Latitude,'') as Latitude_new,isnull(Longtitude,'')as Longtitude_new ,* from tbm_syst_organizeab where group_code = '" + strBranch_Group + "' and org_ab_code = '" + strBranch_code + "' and status <> 'N'")
        If dt.Rows.Count > 0 Then
            lblBranch_Name1.Text = dt.Rows(0).Item("org_ab_name").ToString
            lblBranch_Name2.Text = dt.Rows(0).Item("org_ab_name").ToString
            lbladdress.Text = dt.Rows(0).Item("field1").ToString
            lblPhone.Text = dt.Rows(0).Item("field2").ToString
            Dim strLatitude As String = dt.Rows(0).Item("Latitude_new").ToString
            Dim strLongtitude As String = dt.Rows(0).Item("Longtitude_new").ToString
            Dim strimage As String = dt.Rows(0).Item("Org_Image_Path").ToString

            If strBranch_Group = "BZ" Then
                GetBranch_BZ()
                'img_branch_code.ImageUrl = "~/images/Template/store&event_bz.jpg"
            Else
                GetBranch_AB()
                'img_branch_code.ImageUrl = "~/images/Template/StoreDetail_ab.jpg"
            End If

            If strLatitude = "" Or strLongtitude = "" Then
                strLatitude = "13.757096"
                strLongtitude = "100.568767"
            End If

            Select Case strBranch_Group
                Case "AB"
                    img_shop.ImageUrl = "~/images/imageShop/AB_Shop/" & strimage
                Case "BZ"
                    img_shop.ImageUrl = "~/images/imageShop/BZ_Shop/" & strimage
                Case "KP"
                    img_shop.ImageUrl = "~/images/imageShop/KPS_Shop/" & strimage
            End Select

            Dim latlon As New GLatLng(strLatitude, strLongtitude)

            Dim strURL As String = Request.Url.GetLeftPart(UriPartial.Authority)
            If strURL = "https://www.asiabooks.com" Then
                GMap1.Key = ConfigurationManager.AppSettings("googlemaps.subgurim.net").ToString
            ElseIf strURL = "https://www.asiabooks.co.th" Then
                GMap1.Key = ConfigurationManager.AppSettings("googlemaps.subgurim.net2").ToString
            Else
                GMap1.Key = ConfigurationManager.AppSettings("googlemaps.subgurim.net").ToString
            End If

            'ตั้งค่าพิกัดที่ต้องต้องการแสดง
            GMap1.setCenter(latlon, 14)

            'ตั้งค่าประเภทแผนที่
            GMap1.mapType = GMapType.GTypes.Physical

            'ตั้งค่า Cursor
            GMap1.addCustomCursor(New GCustomCursor(cursor.hand, cursor.move))

            'เพิ่ม Control ให้กับแผนที่
            GMap1.addControl(New GControl(GControl.preBuilt.SmallZoomControl3D))
            GMap1.addControl(New GControl(GControl.preBuilt.MenuMapTypeControl))
            GMap1.addControl(New GControl(GControl.extraBuilt.MarkCenter))
            GMap1.addControl(New GControl(GControl.extraBuilt.TextualCoordinatesControl, New GControlPosition(GControlPosition.position.Bottom_Right)))

            Dim icono As New GMarker(latlon)

            ''Popup แบบแท็บเดียว
            'Dim Window As New GInfoWindow(icono, "<img atl='' src='https://www.asiabooks.com/images/logonew.jpg'><br /><b>Asia Books Head Office </b>", False, GListener.Event.mouseover)

            'GMap1.addInfoWindow(Window)

            'Popup แบบหลายแท็บ
            Dim strAddress As String = dt.Rows(0).Item("field5").ToString
            Dim iwTabs As New GInfoWindowTabs()
            Dim tabs As New System.Collections.Generic.List(Of GInfoWindowTab)
            If strBranch_Group = "BZ" Then
                tabs.Add(New GInfoWindowTab("สถานที่", "<img atl='' src='https://www.asiabooks.com/images/logoBZ.jpg' width='183px' height='24px'><br /><b>" + lblBranch_Name1.Text + "</b>"))
            Else
                tabs.Add(New GInfoWindowTab("สถานที่", "<img atl='' src='https://www.asiabooks.com/images/logonew.jpg'><br /><b>" + lblBranch_Name1.Text + "</b>"))
            End If
            tabs.Add(New GInfoWindowTab("ที่อยู่", strAddress))
            tabs.Add(New GInfoWindowTab("เบอร์ติดต่อ", lblPhone.Text))

            iwTabs.gMarker = icono
            iwTabs.tabs = tabs
            GMap1.addInfoWindowTabs(iwTabs)
        End If
    End Sub
    Private Sub loadGoogleMap1()
        Dim latlon As New GLatLng(13.757096, 100.568767)

        GMap1.Key = ConfigurationManager.AppSettings("googlemaps.subgurim.net").ToString
        'ตั้งค่าพิกัดที่ต้องต้องการแสดง
        GMap1.setCenter(latlon, 14)

        'ตั้งค่าประเภทแผนที่
        GMap1.mapType = GMapType.GTypes.Physical

        'ตั้งค่า Cursor
        GMap1.addCustomCursor(New GCustomCursor(cursor.hand, cursor.move))

        'เพิ่ม Control ให้กับแผนที่
        GMap1.addControl(New GControl(GControl.preBuilt.SmallZoomControl3D))
        GMap1.addControl(New GControl(GControl.preBuilt.MenuMapTypeControl))
        GMap1.addControl(New GControl(GControl.extraBuilt.MarkCenter))
        GMap1.addControl(New GControl(GControl.extraBuilt.TextualCoordinatesControl, New GControlPosition(GControlPosition.position.Bottom_Right)))

        Dim icono As New GMarker(latlon)

        ''Popup แบบแท็บเดียว
        'Dim Window As New GInfoWindow(icono, "<img atl='' src='https://www.asiabooks.com/images/logonew.jpg'><br /><b>Asia Books Head Office </b>", False, GListener.Event.mouseover)

        'GMap1.addInfoWindow(Window)

        'Popup แบบหลายแท็บ
        Dim iwTabs As New GInfoWindowTabs()
        Dim tabs As New System.Collections.Generic.List(Of GInfoWindowTab)

        tabs.Add(New GInfoWindowTab("สถานที่", "<img atl='' src='https://www.asiabooks.com/images/logonew.jpg'><br /><b>Asia Books Head Office </b>"))
        tabs.Add(New GInfoWindowTab("ที่อยู่", "65/66, 65/70 7th Floor, <br> Chamnan Phenjati Business Center, <br>Rama 9 road, Khet Huaykwang, Kwang Huaykwang, <br>Bangkok 10320 Thailand "))
        tabs.Add(New GInfoWindowTab("เบอร์ติดต่อ", "(Monday-Friday 8.30 am.- 5.30 pm.) <br>Tel: (662) 715-9000 <br>Fax: (662) 715-9198 "))

        iwTabs.gMarker = icono
        iwTabs.tabs = tabs
        GMap1.addInfoWindowTabs(iwTabs)
    End Sub

End Class
