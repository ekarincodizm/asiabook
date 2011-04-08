Imports System.Data
Partial Class uc_ucMenu_Cat
    Inherits System.Web.UI.UserControl
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

#Region "Property"
    Property Menu_Type() As String
        Get
            Return 0
        End Get
        Set(ByVal value As String)
            GetMenu_Boook(value)
        End Set
    End Property

#End Region

    Private Sub GetMenu_Boook(ByVal Menu_Type As String)
        Dim strhtml As String = ""
        Dim ss As String = ""
        Dim dt_cat As New DataTable
        Dim dt_sub_cat As New DataTable
        Dim imag1 As String = ""
        Dim imag2 As String = ""
        Dim imag3 As String = ""
        Dim imag4 As String = ""


        If Menu_Type = "BOOK" Then

            imag1 = getUrl1("/images/Template/bgmenu_cat.jpg")
            imag2 = getUrl1("/images/Template/menu_cat_books.jpg")
            imag3 = getUrl1("/images/Template/line_menu_cat.jpg")
            imag4 = getUrl1("/images/Template/footer_menu_cat.jpg")

            uCon = New uConnect
            dt_cat = uFunction.getDataTable(uCon.conn, "select * from Category where [Division Code] = 'BOOK' and Active = 'Y' order by [Description]")

            strhtml &= " <ul id='nav'>"
            strhtml &= " <li style='width:210px; height:35px;'><img alt='' src='" + imag2 + "' />"
            strhtml &= " <li><img alt='' src='" + imag3 + "' />"
            For icat As Integer = 0 To dt_cat.Rows.Count - 1
                strhtml &= " <li><a href='Book_SeeMore.aspx?Page_Name=Masterpage|Menu_Cat_Head|" + dt_cat.Rows(icat).Item("code").ToString + "'>" + dt_cat.Rows(icat).Item("Description").ToString + " &#187;</a><img alt='' src='" + imag3 + "' />"
                strhtml &= " <ul>"
                strhtml &= " <li style='height:7px'><a href='#nogo'></a></li>"
                dt_sub_cat.Clear()
                dt_sub_cat = uFunction.getDataTable(uCon.conn, "select * from Category_Sub where code = '" + dt_cat.Rows(icat).Item("code").ToString + "' and  Active = 'Y' order by [Description]")
                For iSub_cat As Integer = 0 To dt_sub_cat.Rows.Count - 1
                    strhtml &= " <li><a href='Book_SeeMore.aspx?Page_Name=Masterpage|Menu_Cat|" + dt_sub_cat.Rows(iSub_cat).Item("category_code").ToString + "'>" + dt_sub_cat.Rows(iSub_cat).Item("Description_Show").ToString + "</a></li>"
                Next
                strhtml &= " <li style='height:10px'><a href='#nogo'></a></li>"
                strhtml &= " </ul>"
                strhtml &= " </li>"
            Next
            strhtml &= "<li style='width:210px; height:35px;'><img src='" + imag4 + "' /></li>"
            strhtml &= " </ul>"

        ElseIf Menu_Type = "EBOOK" Then

            imag1 = getUrl1("/images/Template/bgmenu_cat.jpg")
            imag2 = getUrl1("/images/Template/menu_cat_ebooks.jpg")
            imag3 = getUrl1("/images/Template/line_menu_cat.jpg")
            imag4 = getUrl1("/images/Template/footer_menu_cat.jpg")

            uCon = New uConnect
            dt_cat = uFunction.getDataTable(uCon.conn, "select * from ebook_supplier_category where Active = 'Y' order by [Description]")

            strhtml &= " <ul id='nav'>"
            strhtml &= " <li style='width:210px; height:35px;'><img alt='' src='" + imag2 + "' />"
            strhtml &= " <li><img alt='' src='" + imag3 + "' />"
            For icat As Integer = 0 To dt_cat.Rows.Count - 1
                strhtml &= " <li><a href='eBook_SeeMore.aspx?catcode=" + dt_cat.Rows(icat).Item("code").ToString + "'>" + dt_cat.Rows(icat).Item("Description").ToString + " </a><img alt='' src='" + imag3 + "' />"
                strhtml &= " </li>"
            Next
            strhtml &= "<li style='width:210px; height:35px;'><img src='" + imag4 + "' /></li>"
            strhtml &= " </ul>"

	ElseIf Menu_Type = "MAGAZINE" Then

            imag1 = getUrl1("/images/Template/bgmenu_cat.jpg")
            imag2 = getUrl1("/images/Template/menu_cat_mag.jpg")
            imag3 = getUrl1("/images/Template/line_menu_cat.jpg")
            imag4 = getUrl1("/images/Template/footer_menu_cat.jpg")

            uCon = New uConnect
            dt_cat = uFunction.getDataTable(uCon.conn, "select * from Category where  [division code]= 'MAGAZINE' order by [Description]")

            strhtml &= " <ul id='nav'>"
            strhtml &= " <li style='width:210px; height:35px;'><img alt='' src='" + imag2 + "' />"
            strhtml &= " <li><img alt='' src='" + imag3 + "' />"
            For icat As Integer = 0 To dt_cat.Rows.Count - 1
                strhtml &= " <li><a href='Magazine_SeeMore.aspx?Page_Name=Masterpage|Menu_Cat|" + dt_cat.Rows(icat).Item("Code").ToString + "'>" + dt_cat.Rows(icat).Item("Description").ToString + " </a><img alt='' src='" + imag3 + "' />"
                strhtml &= " <ul>"
                strhtml &= " </ul>"
                strhtml &= " </li>"
            Next
            strhtml &= "<li style='width:210px; height:35px;'><img src='" + imag4 + "' /></li>"
            strhtml &= " </ul>"

        ElseIf Menu_Type = Nothing Then

            imag1 = getUrl1("/images/Template/bgmenu_cat.jpg")
            imag2 = getUrl1("/images/Template/menu_cat_books.jpg")
            imag3 = getUrl1("/images/Template/line_menu_cat.jpg")
            imag4 = getUrl1("/images/Template/footer_menu_cat.jpg")

            uCon = New uConnect
            dt_cat = uFunction.getDataTable(uCon.conn, "select * from Category where [Division Code] = 'BOOK' and Active = 'Y' order by [Description]")

            strhtml &= " <ul id='nav'>"
            strhtml &= " <li style='width:210px; height:35px;'><img alt='' src='" + imag2 + "' />"
            strhtml &= " <li><img alt='' src='" + imag3 + "' />"
            For icat As Integer = 0 To dt_cat.Rows.Count - 1
                strhtml &= " <li><a href='Book_SeeMore.aspx?Page_Name=Masterpage|Menu_Cat_Head|" + dt_cat.Rows(icat).Item("code").ToString + "'>" + dt_cat.Rows(icat).Item("Description").ToString + " &#187;</a><img alt='' src='" + imag3 + "' />"
                strhtml &= " <ul>"
                strhtml &= " <li style='height:7px'><a href='#nogo'></a></li>"
                dt_sub_cat.Clear()
                dt_sub_cat = uFunction.getDataTable(uCon.conn, "select * from Category_Sub where code = '" + dt_cat.Rows(icat).Item("code").ToString + "' and  Active = 'Y' order by [Description]")
                For iSub_cat As Integer = 0 To dt_sub_cat.Rows.Count - 1
                    strhtml &= " <li><a href='Book_SeeMore.aspx?Page_Name=Masterpage|Menu_Cat|" + dt_sub_cat.Rows(iSub_cat).Item("category_code").ToString + "'>" + dt_sub_cat.Rows(iSub_cat).Item("Description_Show").ToString + "</a></li>"
                Next
                strhtml &= " <li style='height:10px'><a href='#nogo'></a></li>"
                strhtml &= " </ul>"
                strhtml &= " </li>"
            Next

            strhtml &= " <li style='width:210px; height:35px;'><img src='" + imag4 + "' /></li>"
            strhtml &= " </ul>"
        End If

        spanbook.InnerHtml = strhtml.ToString()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
