Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Web
Imports System.IO

Imports ws_gardners

Public Class PromptNow
    Public Shared ExpireDateCount As Integer = 0

    '' <summary>
    '' Programmatically performs an HTTP request for the <paramref name="fullUrl" /> URL's content.
    '' </summary>
    '' <exception cref="System.Exception">
    '' Thrown if the HTTP Request fails, or if the <see cref="System.Net.HttpWebResponse" />
    '' has a <see cref="System.Net.HttpWebResponse.StatusCode" /> other than
    '' <see cref="System.Net.HttpStatusCode.OK" />.
    '' </exception>
    '' <returns>The content from the requested URL's HTTP Response.</returns>
    Public Shared Function ExecuteUrl( _
        ByVal fullUrl As String, _
        Optional ByVal bAllowAutoRedirect As Boolean = True, _
        Optional ByVal iTimeout As Integer = System.Threading.Timeout.Infinite _
    ) As String
        Dim webRequest As System.Net.HttpWebRequest
        Dim webResponse As System.Net.HttpWebResponse
        Try
            'Create an HttpWebRequest with the specified URL.
            webRequest = CType(System.Net.WebRequest.Create(fullUrl), System.Net.HttpWebRequest)
            webRequest.AllowAutoRedirect = bAllowAutoRedirect
            'webRequest.MaximumAutomaticRedirections = 50
            webRequest.Timeout = iTimeout
            webRequest.Method = "POST"

            'Send the request and wait for a response.
            Try
                webResponse = CType(webRequest.GetResponse(), System.Net.HttpWebResponse)
                Select Case (webResponse.StatusCode)
                    Case System.Net.HttpStatusCode.OK
                        'read the content from the response
                        Dim responseStream As System.IO.Stream = _
                            webResponse.GetResponseStream()
                        Dim responseEncoding As System.Text.Encoding = _
                            System.Text.Encoding.UTF8
                        ' Pipes the response stream to a higher level stream reader with the required encoding format.
                        Dim responseReader As New StreamReader(responseStream, responseEncoding)
                        Dim responseContent As String = _
                            responseReader.ReadToEnd()
                        Return responseContent
                    Case System.Net.HttpStatusCode.Redirect, System.Net.HttpStatusCode.MovedPermanently
                        Throw New System.Exception(String.Format( _
                            "Unable to read response content.  URL has moved. StatusCode={0}.", _
                            webResponse.StatusCode))
                    Case System.Net.HttpStatusCode.NotFound
                        Throw New System.Exception(String.Format( _
                            "Unable to read response content. URL not found. StatusCode={0}.", _
                            webResponse.StatusCode))
                    Case Else
                        Throw New System.Exception(String.Format( _
                            "Unable to read response content. StatusCode={0}.", _
                            webResponse.StatusCode))
                End Select
            Catch we As System.Net.WebException
                'If (we.Status = Net.WebExceptionStatus.Timeout) Then
                '    Return False
                'End If
                Throw New System.Exception( _
                    "Unable to execute URL.", _
                    we)
            Finally
                If (Not IsNothing(webResponse)) Then
                    webResponse.Close()
                End If
            End Try
        Catch e As System.Exception
            Throw New System.Exception( _
                "Unable to execute URL.", _
                e)
        End Try
    End Function

    Public Function GetGardnersDownloadURL(ByVal SKU_13 As String, ByVal EBookID As String, ByVal ItemIdx As String, ByVal ItemQtyIdx As String, ByVal Format_Type As String, ByVal COUNTRYCODE As String, ByVal ORDERNO As String) As String
        Dim login As String = "ASI001"
        Dim account As String = "ASI001"
        Dim password As String = "4SytV8nR"
        Dim format As Integer
        Dim Download_URL As String = ""

        If Format_Type.Equals("1") Or Format_Type.Equals("2") Then
            format = 2
        ElseIf Format_Type.Equals("3") Or Format_Type.Equals("4") Then
            format = 6
        ElseIf Format_Type.Equals("6") Then
            format = 5
        ElseIf Format_Type.Equals("5") Then
            format = 4
        End If

        Dim gOrderMsg As EBookOrderMsg = New EBookOrderMsg()
        gOrderMsg.LoginName = login
        gOrderMsg.AccountCode = account
        gOrderMsg.Password = password
        'gOrderMsg.CountryCode = "US"
        gOrderMsg.CountryCode = COUNTRYCODE
        gOrderMsg.Ean = SKU_13 'ISBN or SKU_13
        'gOrderMsg.Ean = "9781907016783" 'ISBN or SKU_13
        gOrderMsg.EBookFormat = format '(PDF) 1,2 -> 2 | (EPUB) 3,4 -> 6
        gOrderMsg.Pids = ""
        'gOrderMsg.Pids = "12345"
        'gOrderMsg.UniqueRef = "10000006"  'Do not duplicate this number.
        gOrderMsg.UniqueRef = ORDERNO & ItemIdx & ItemQtyIdx  'Do not duplicate this number.
        'gOrderMsg.SecondaryRef = "a12345"
        gOrderMsg.SecondaryRef = ORDERNO


        GenerateLog("GetGardnersDownloadURL", "", "", ORDERNO, "", "", "http://www.asiabooks.com", "", _
        "[Input] login=" & login & ",account=" & account & ",password=" & password & ",COUNTRYCODE=" & COUNTRYCODE & ",SKU_13=" & SKU_13 & _
        ",format=" & format & ",UniqueRef=" & ORDERNO & ItemIdx & ItemQtyIdx & ",SecondaryRef=" & ORDERNO)

        GenerateLog("GetGardnersDownloadURL", "", "", ORDERNO, "", "", "http://www.asiabooks.com", "", _
        "gOrderMsg.AccountCode=" & gOrderMsg.AccountCode & _
        ",gOrderMsg.CountryCode=" & gOrderMsg.CountryCode & _
        ",gOrderMsg.Ean=" & gOrderMsg.Ean & _
        ",gOrderMsg.EBookFormat=" & gOrderMsg.EBookFormat & _
        ",gOrderMsg.EndUserID=" & gOrderMsg.EndUserID & _
        ",gOrderMsg.LoginName=" & gOrderMsg.LoginName & _
        ",gOrderMsg.Password=" & gOrderMsg.Password & _
        ",gOrderMsg.Pids=" & gOrderMsg.Pids & _
        ",gOrderMsg.SecondaryRef=" & gOrderMsg.SecondaryRef & _
        ",gOrderMsg.UniqueRef=" & gOrderMsg.UniqueRef)


        Dim gOrderRep As EBookOrderReply = New EBookOrderReply()
        Dim gSendOrder As EBookSendOrder = New ws_gardners.EBookSendOrder()
        gOrderRep = gSendOrder.PlaceEBookOrder(gOrderMsg)


        GenerateLog("GetGardnersDownloadURL", "", "", ORDERNO, "", "", "http://www.asiabooks.com", "", _
        "gOrderRep.Ean=" & gOrderRep.Ean & _
        ",gOrderRep.EBookFormat=" & gOrderRep.EBookFormat & _
        ",gOrderRep.ErrorCode=" & gOrderRep.ErrorCode & _
        ",gOrderRep.ErrorDesc=" & gOrderRep.ErrorDesc & _
        ",gOrderRep.SecondaryRef=" & gOrderRep.SecondaryRef & _
        ",gOrderRep.UniqueRef=" & gOrderRep.UniqueRef)

        If gOrderRep.ErrorCode.Equals("E000") Then

            Dim gDownloadMsg As EBookDownloadMsg = New EBookDownloadMsg()
            gDownloadMsg.LoginName = login
            gDownloadMsg.AccountCode = account
            gDownloadMsg.Password = password

            GenerateLog("GetGardnersDownloadURL", "", "", ORDERNO, "", "", "http://www.asiabooks.com", "", _
            "gDownloadMsg.AccountCode=" & gDownloadMsg.AccountCode & _
            ",gDownloadMsg.LoginName=" & gDownloadMsg.LoginName & _
            ",gDownloadMsg.Password=" & gDownloadMsg.Password)

            Dim gDownloadRep As EBookDownloadReply = New EBookDownloadReply()
            gDownloadRep = gSendOrder.RequestDownload(gDownloadMsg)

            GenerateLog("GetGardnersDownloadURL", "", "", ORDERNO, "", "", "http://www.asiabooks.com", "", _
           "gDownloadRep.AccountCode=" & gDownloadRep.AccountCode & _
           ",gDownloadRep.Ean=" & gDownloadRep.Ean & _
           ",gDownloadRep.EBookFormat=" & gDownloadRep.EBookFormat & _
           ",gDownloadRep.ErrorCode=" & gDownloadRep.ErrorCode & _
           ",gDownloadRep.ErrorDesc=" & gDownloadRep.ErrorDesc & _
           ",gDownloadRep.SecondaryRef=" & gDownloadRep.SecondaryRef & _
           ",gDownloadRep.UniqueRef=" & gDownloadRep.UniqueRef & _
           ",gDownloadRep.Url=" & gDownloadRep.Url)

            Dim isUrlReceived As Boolean = False

            If gOrderRep.UniqueRef = gDownloadRep.UniqueRef Then
                isUrlReceived = True
            End If

            Dim i As Integer = 0
            Do While gOrderRep.UniqueRef <> gDownloadRep.UniqueRef And gDownloadRep.UniqueRef <> ""
                gDownloadRep = gSendOrder.RequestDownload(gDownloadMsg)

                GenerateLog("GetGardnersDownloadURL_repeat" & i, "", "", ORDERNO, "", "", "http://www.asiabooks.com", "", _
                  "gDownloadRep.AccountCode=" & gDownloadRep.AccountCode & _
                  ",gDownloadRep.Ean=" & gDownloadRep.Ean & _
                  ",gDownloadRep.EBookFormat=" & gDownloadRep.EBookFormat & _
                  ",gDownloadRep.ErrorCode=" & gDownloadRep.ErrorCode & _
                  ",gDownloadRep.ErrorDesc=" & gDownloadRep.ErrorDesc & _
                  ",gDownloadRep.SecondaryRef=" & gDownloadRep.SecondaryRef & _
                  ",gDownloadRep.UniqueRef=" & gDownloadRep.UniqueRef & _
                  ",gDownloadRep.Url=" & gDownloadRep.Url)

                i = i + 1

                If gOrderRep.UniqueRef = gDownloadRep.UniqueRef Then
                    isUrlReceived = True
                    Exit Do
                End If

                If gDownloadRep.Url Is Nothing Or gDownloadRep.UniqueRef = "" Then
                    Exit Do
                End If
            Loop

            If Not isUrlReceived Then
                For i = 0 To 50
                    gDownloadRep = gSendOrder.RequestDownload(gDownloadMsg)

                    GenerateLog("GetGardnersDownloadURL_repeat_null" & i, "", "", ORDERNO, "", "", "http://www.asiabooks.com", "", _
                      "gDownloadRep.AccountCode=" & gDownloadRep.AccountCode & _
                      ",gDownloadRep.Ean=" & gDownloadRep.Ean & _
                      ",gDownloadRep.EBookFormat=" & gDownloadRep.EBookFormat & _
                      ",gDownloadRep.ErrorCode=" & gDownloadRep.ErrorCode & _
                      ",gDownloadRep.ErrorDesc=" & gDownloadRep.ErrorDesc & _
                      ",gDownloadRep.SecondaryRef=" & gDownloadRep.SecondaryRef & _
                      ",gDownloadRep.UniqueRef=" & gDownloadRep.UniqueRef & _
                      ",gDownloadRep.Url=" & gDownloadRep.Url)

                    If Not gDownloadRep.Url Is Nothing And gDownloadRep.Url <> "" Then
                        Exit For
                    End If
                Next
            End If

            If gDownloadRep.ErrorCode.Equals("E000") Then

                GenerateLog("GetGardnersDownloadURL", "", "", ORDERNO, "", "", "http://www.asiabooks.com", "", "[URL] gDownloadRep.Url=" & gDownloadRep.Url)
                Download_URL = gDownloadRep.Url

            End If
        End If

        Return (Download_URL)
    End Function

    Public Function GetIngramDownloadURL(ByVal SKU_13 As String, ByVal EBookID As String, ByVal ItemIdx As String, ByVal ItemQtyIdx As String, ByVal ORDERNO As String, ByVal COUNTRYCODE As String) As String

        Dim responseContent As String = ""
        Try
            'use SKU_13
            'HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://9PfaF2MnQls2:740007edfaf9016e4634b5ee2db792952c3ee546@ipws-demo.ingramdigital.com/ebook/items/9785551290957");
            Dim req As HttpWebRequest = CType(WebRequest.Create(ConfigurationManager.AppSettings("Ingram_URL").ToString & SKU_13), HttpWebRequest)
            req.Method = "POST"
            req.KeepAlive = False
            req.Credentials = New NetworkCredential(ConfigurationManager.AppSettings("Ingram_User").ToString, ConfigurationManager.AppSettings("Ingram_Pwd").ToString)
            req.PreAuthenticate = True
            req.ContentType = "application/x-www-form-urlencoded"
            Dim postData As String = "billtocountry=" & COUNTRYCODE & "&orderno=" & ORDERNO & ItemIdx & ItemQtyIdx
            req.ContentLength = postData.Length

            GenerateLog("GetIngramDownloadURL", "", "", ORDERNO, "", "", "http://www.asiabooks.com", "", "COUNTRYCODE=" & COUNTRYCODE & "SKU_13=" & SKU_13 & ",EBookID=" & EBookID & ",postData=" & postData)

            Dim stOut As StreamWriter = New StreamWriter(req.GetRequestStream())
            stOut.Write(postData)
            stOut.Close()

            Dim httpWebResponse As HttpWebResponse = CType(req.GetResponse(), HttpWebResponse)
            Dim responseStream As Stream = httpWebResponse.GetResponseStream()

            Dim sb As StringBuilder = New StringBuilder()

            Dim reader As StreamReader = New StreamReader(responseStream)
            responseContent = reader.ReadToEnd()

            GenerateLog("GetIngramDownloadURL", "", "", ORDERNO, "", "", "http://www.asiabooks.com", "", "responseContent=" & responseContent)

            'Response.Redirect(sb.ToString())
        Catch ex As Exception
            'Throw ex
            GenerateLog("GetIngramDownloadURL", "", "", ORDERNO, "", "", "http://www.asiabooks.com", "", ex.Message + " " + ex.GetBaseException.ToString)
        End Try

        Return (responseContent)
    End Function

    Public Function GenerateLog(ByVal CallFunation As String, ByVal CallServiceURL As String, ByVal IPAddress As String, ByVal DocumrntNo As String, ByVal MemberNo As String, ByVal Amount As String, ByVal ResultURL As String, ByVal TanksURL As String, ByVal Description As String) As Boolean
        Try
            Dim StrPath As String = HttpContext.Current.Server.MapPath("Log File").ToString & "\"
            Dim StrFileName As String = "Log_eOrdering_" & Format(Now, "yyyyMMdd") & ".txt"
            Dim StrValue As New StringBuilder

            StrValue.Append(Format(Now, "dd/MM/yyyy") & " " & Format(Now, "hh:mm:ss"))
            StrValue.Append("; CallFunation ")
            StrValue.Append(CallFunation)
            StrValue.Append("; CallServiceURL ")
            StrValue.Append(CallServiceURL)
            StrValue.Append("; IPAddress ")
            StrValue.Append(IPAddress)
            StrValue.Append("; DocumrntNo ")
            StrValue.Append(DocumrntNo)
            StrValue.Append("; MemberNo ")
            StrValue.Append(MemberNo)
            StrValue.Append("; Amount ")
            StrValue.Append(Amount)
            'StrValue.Append("; ResultURL ")
            'StrValue.Append(ResultURL)
            StrValue.Append("; TanksURL ")
            StrValue.Append(TanksURL)
            StrValue.Append("; Description ")
            StrValue.Append(Description)
            StrValue.Append(";")

            'Dim sw As StreamWriter = New StreamWriter(StrPath.Replace("PaymentMethod\", "") & StrFileName, True, Encoding.GetEncoding(874))
            ' '' Add some text to the file.
            'sw.WriteLine(StrValue.ToString)
            'sw.Close()
            'StrValue.Remove(0, StrValue.Length)
            CollectionWrite(StrPath.Replace("PaymentMethod\", ""), StrFileName, StrValue.ToString)

            Return True

        Catch ex As Exception
            'Throw ex
            Return False
        End Try
    End Function

    Public Function CollectionWrite(ByVal strPath As String, ByVal strName As String, ByVal error_message As String) As Boolean
        Try
            Dim i As Integer = 0
            Dim fso As New StreamWriter(strPath & "\" & strName, True)
            fso.WriteLine(error_message)
            fso.Close()
            fso = Nothing
        Catch ex As Exception
        End Try
    End Function

End Class
