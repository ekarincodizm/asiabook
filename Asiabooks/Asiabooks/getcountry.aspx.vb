Imports System.Data
Imports System.Web
Partial Class getcountry
    Inherits System.Web.UI.Page
    Public country As String = ""
    Public ip As String = ""
    Public iplong As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Session("client_nation") Is Nothing Then
                country = Session("client_nation").ToString()
                'Response.Write("Your country code is " + Session("client_nation").ToString()) 
            Else
                country = "none"
            End If
            ip = Request.UserHostAddress().ToString()
            iplong = IP2Long(ip).ToString()

        Catch ex As Exception

        End Try


    End Sub

    Function IP2Long(ByVal ipadr As String) As Integer
        Dim result As Integer = 0
        Dim faktorer() As String = Split(ipadr, ".")
        For ix = 0 To 3
            Dim expn As Integer = 3 - ix
            result = result + Int64.Parse(faktorer(ix)) * 256 ^ expn
        Next
        Return result
    End Function
End Class
