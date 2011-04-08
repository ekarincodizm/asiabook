
Partial Class Reading_Time
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = ConfigurationManager.AppSettings("SiteTitle").ToString & "Reading Time ::"
        If Not IsPostBack Then
            If Request.QueryString("Number") Is Nothing Then
                lblNumber.Text = ""
            Else
                lblNumber.Text = Request.QueryString("Number").ToString
            End If

            BindData()
        End If
    End Sub
    Private Sub BindData()

        Dim strHtml As String = ""

        Select Case lblNumber.Text
            Case "1"
                strHtml = ""
                strHtml &= "<div><object style='width:650px;height:464px' ><param name='movie' "
                strHtml &= "value='http://static.issuu.com/webembed/viewers/style1/v1/IssuuViewer.swf?mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true&amp;documentId=100901082713-43f3de64999643d9b21c287e1fa90c27&amp;docName=readingtime_living_with_art_10&amp;username=Asiabooks&amp;loadingInfoText=Reading%20Time%3A%20Living%20with%20Art%20(Sep%20-%20Oct%202010)&amp;et=1283739374872&amp;er=91' />"
                strHtml &= "<param name='allowfullscreen' value='true'/><param name='menu' value='false'/>"
                strHtml &= "<embed src='http://static.issuu.com/webembed/viewers/style1/v1/IssuuViewer.swf' "
                strHtml &= "type='application/x-shockwave-flash' allowfullscreen='true' "
                strHtml &= "menu='false' style='width:650px;height:464px' "
                strHtml &= "flashvars='mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true&amp;documentId=100901082713-43f3de64999643d9b21c287e1fa90c27&amp;docName=readingtime_living_with_art_10&amp;username=Asiabooks&amp;loadingInfoText=Reading%20Time%3A%20Living%20with%20Art%20(Sep%20-%20Oct%202010)&amp;et=1283739374872&amp;er=91' /></object></div> "

                lblDownload.Visible = True
                lnkDownload.HRef = "images/Template/Reading_Time/Download/ReadingTime1.rar"

            Case "2"
                strHtml = ""
                strHtml &= "<div><object style='width:650px;height:464px' >"
                strHtml &= "<param name='movie' value='http://static.issuu.com/webembed/viewers/style1/v1/IssuuViewer.swf?mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true&amp;documentId=100928076507-fd7da1f8bac044f5b0c582cc4027ff5b&amp;docName=childrenfestival&amp;username=Asiabooks&amp;loadingInfoText=Reading%20Time%3A%20Children's%20Festival%20(Oct-Sept%2010)&amp;et=1286361198500&amp;er=55' /><param name='allowfullscreen' value='true'/>"
                strHtml &= "<param name='menu' value='false'/>"
                strHtml &= "<embed src='http://static.issuu.com/webembed/viewers/style1/v1/IssuuViewer.swf' "
                strHtml &= "type='application/x-shockwave-flash' allowfullscreen='true' menu='false' style='width:650px;height:464px' flashvars='mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true&amp;documentId=100928076507-fd7da1f8bac044f5b0c582cc4027ff5b&amp;docName=childrenfestival&amp;username=Asiabooks&amp;loadingInfoText=Reading%20Time%3A%20Children's%20Festival%20(Oct-Sept%2010)&amp;et=1286361198500&amp;er=55' />"
                strHtml &= "</object></div>"

                lblDownload.Visible = True
                lnkDownload.HRef = "images/Template/Reading_Time/Download/ReadingTime2.rar"

            Case "3"
                strHtml = ""
                strHtml &= "<div><object style='width:650px;height:464px' ><param name='movie' "
                strHtml &= "value='http://static.issuu.com/webembed/viewers/style1/v1/IssuuViewer.swf?mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true&amp;documentId=101028132231-c2c20f010e4c40c79d58276b59fda6f8&amp;docName=verygifted2010&amp;username=Asiabooks&amp;loadingInfoText=Reading%20Time%3A%20Very%20Gifted%20(Nov%2010%20-%20Jan%2011)&amp;et=1288835701486&amp;er=70' />"
                strHtml &= "<param name='allowfullscreen' value='true'/><param name='menu' value='false'/>"
                strHtml &= "<embed src='http://static.issuu.com/webembed/viewers/style1/v1/IssuuViewer.swf' type='application/x-shockwave-flash' allowfullscreen='true' menu='false' style='width:650px;height:464px' "
                strHtml &= "flashvars='mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true&amp;documentId=101028132231-c2c20f010e4c40c79d58276b59fda6f8&amp;docName=verygifted2010&amp;username=Asiabooks&amp;loadingInfoText=Reading%20Time%3A%20Very%20Gifted%20(Nov%2010%20-%20Jan%2011)&amp;et=1288835701486&amp;er=70' />"
                strHtml &= "</object></div>"

                lblDownload.Visible = True
                lnkDownload.HRef = "images/Template/Reading_Time/Download/ReadingTime3.rar"

            Case "4"
                strHtml = ""
                strHtml &= "<div><object style='width:650px;height:464px' ><param name='movie' "
                strHtml &= "value='http://static.issuu.com/webembed/viewers/style1/v1/IssuuViewer.swf?mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Fgrass%2Flayout.xml&amp;showFlipBtn=true&amp;documentId=101227113755-85971a18fbed457c8779150d272263ef&amp;docName=fiction_jan11&amp;username=Asiabooks&amp;loadingInfoText=Reading%20Time%3A%20Read%20All%20Year%20Round%20(Jan%20-%20Feb%2011)&amp;et=1294114130659&amp;er=29' />"
                strHtml &= "<param name='allowfullscreen' value='true'/><param name='menu' value='false'/>"
                strHtml &= "<embed src='http://static.issuu.com/webembed/viewers/style1/v1/IssuuViewer.swf' type='application/x-shockwave-flash' allowfullscreen='true' menu='false' style='width:650px;height:464px' "
                strHtml &= "flashvars='mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Fgrass%2Flayout.xml&amp;showFlipBtn=true&amp;documentId=101227113755-85971a18fbed457c8779150d272263ef&amp;docName=fiction_jan11&amp;username=Asiabooks&amp;loadingInfoText=Reading%20Time%3A%20Read%20All%20Year%20Round%20(Jan%20-%20Feb%2011)&amp;et=1294114130659&amp;er=29' />"
                strHtml &= "</object></div>"

                lblDownload.Visible = True
                lnkDownload.HRef = "images/Template/Reading_Time/Download/ReadingTime4.rar"

            Case "5"
                strHtml = ""
                strHtml &= "<div><object style='width:650px;height:464px' ><param name='movie' value='http://static.issuu.com/webembed/viewers/style1/v1/IssuuViewer.swf?mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true&amp;documentId=110214065208-5d7bf3c5aa344ceea99f7b8522f5341e&amp;docName=readingtime_growupreading&amp;username=Asiabooks&amp;loadingInfoText=Reading%20Time%3A%20Children's%20Festival%20Grow%20Up%20Reading&amp;et=1298546612140&amp;er=8' /><param name='allowfullscreen' value='true'/><param name='menu' value='false'/>"
                strHtml &= "<embed src='http://static.issuu.com/webembed/viewers/style1/v1/IssuuViewer.swf' type='application/x-shockwave-flash' allowfullscreen='true' menu='false' style='width:650px;height:464px' flashvars='mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true&amp;documentId=110214065208-5d7bf3c5aa344ceea99f7b8522f5341e&amp;docName=readingtime_growupreading&amp;username=Asiabooks&amp;loadingInfoText=Reading%20Time%3A%20Children's%20Festival%20Grow%20Up%20Reading&amp;et=1298546612140&amp;er=8' /></object></div>"

                lblDownload.Visible = True
                lnkDownload.HRef = "images/Template/Reading_Time/Download/ReadingTime5.rar"

            Case "6"
                strHtml = ""
                strHtml &= "<div><object style='width:650px;height:464px' >"
                strHtml &= "<param name='movie' value='http://static.issuu.com/webembed/viewers/style1/v1/IssuuViewer.swf?mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true&amp;documentId=110324034315-9d656212953144e08a45b612cddfca47&amp;docName=livingwitharts&amp;username=Asiabooks&amp;loadingInfoText=Asia%20Books%3A%20Living%20with%20Arts%20(April%202011)&amp;et=1301541281336&amp;er=83' />"
                strHtml &= "<param name='allowfullscreen' value='true'/>"
                strHtml &= "<param name='menu' value='false'/>"
                strHtml &= "<embed src='http://static.issuu.com/webembed/viewers/style1/v1/IssuuViewer.swf' type='application/x-shockwave-flash' allowfullscreen='true' menu='false' style='width:650px;height:464px' flashvars='mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true&amp;documentId=110324034315-9d656212953144e08a45b612cddfca47&amp;docName=livingwitharts&amp;username=Asiabooks&amp;loadingInfoText=Asia%20Books%3A%20Living%20with%20Arts%20(April%202011)&amp;et=1301541281336&amp;er=83' />"
                strHtml &= "</object></div>"

                lblDownload.Visible = True
                lnkDownload.HRef = "images/Template/Reading_Time/Download/ReadingTime6.rar"

            Case Else
                strHtml = ""
                strHtml &= "<div><object style='width:650px;height:464px' ><param name='movie' "
                strHtml &= "value='http://static.issuu.com/webembed/viewers/style1/v1/IssuuViewer.swf?mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true&amp;documentId=101028132231-c2c20f010e4c40c79d58276b59fda6f8&amp;docName=verygifted2010&amp;username=Asiabooks&amp;loadingInfoText=Reading%20Time%3A%20Very%20Gifted%20(Nov%2010%20-%20Jan%2011)&amp;et=1288835701486&amp;er=70' />"
                strHtml &= "<param name='allowfullscreen' value='true'/><param name='menu' value='false'/>"
                strHtml &= "<embed src='http://static.issuu.com/webembed/viewers/style1/v1/IssuuViewer.swf' type='application/x-shockwave-flash' allowfullscreen='true' menu='false' style='width:650px;height:464px' "
                strHtml &= "flashvars='mode=embed&amp;layout=http%3A%2F%2Fskin.issuu.com%2Fv%2Flight%2Flayout.xml&amp;showFlipBtn=true&amp;documentId=101028132231-c2c20f010e4c40c79d58276b59fda6f8&amp;docName=verygifted2010&amp;username=Asiabooks&amp;loadingInfoText=Reading%20Time%3A%20Very%20Gifted%20(Nov%2010%20-%20Jan%2011)&amp;et=1288835701486&amp;er=70' />"
                strHtml &= "</object></div>"

                lblDownload.Visible = True
                lnkDownload.HRef = "images/Template/Reading_Time/Download/ReadingTime3.rar"

        End Select
        spanRTOnline.InnerHtml = strHtml.ToString()
    End Sub

    Protected Sub img1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img1.Click
        lblNumber.Text = "1"
        BindData()
    End Sub

    Protected Sub img2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img2.Click
        lblNumber.Text = "2"
        BindData()
    End Sub

    Protected Sub img3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img3.Click
        lblNumber.Text = "3"
        BindData()
    End Sub

    Protected Sub img4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img4.Click
        lblNumber.Text = "4"
        BindData()
    End Sub

    Protected Sub img5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img5.Click
        lblNumber.Text = "5"
        BindData()
    End Sub

    Protected Sub img6_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img6.Click
        lblNumber.Text = "6"
        BindData()
    End Sub
End Class
