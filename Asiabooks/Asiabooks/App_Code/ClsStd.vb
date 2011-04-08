Imports Microsoft.VisualBasic
Imports System.Web
Imports System.Data
Imports System.Net.Mail
Imports System.Configuration

Public Class ClsStd

#Region " Enum "

    Public Enum PageType
        Ajax = 0
        Normal = 1
    End Enum

#End Region

#Region " Script "

    Public Shared Sub Msg(ByVal page As Page, ByVal str As String, Optional ByVal type As pageType = pageType.Ajax)
        Try
            Select Case type
                Case PageType.Ajax
                    'ScriptManager.RegisterStartupScript(page, GetType(String), "xAlert", "<Script>alert('" & str & "');</Script>", False)
                Case PageType.Normal
                    page.ClientScript.RegisterStartupScript(GetType(String), "xAlert", "<Script>alert('" & str & "');</Script>")
            End Select
        Catch ex As Exception
            Throw New Exception(ex.ToString)
        End Try
    End Sub

    Public Shared Sub MsgBoxAndChangePage(ByVal page As Page, ByVal strAlert As String, ByVal PageName As String, Optional ByVal type As PageType = PageType.Ajax)
        page.ClientScript.RegisterStartupScript(GetType(String), "xAlert", "<Script>alert(' " & strAlert & " '); window.location='" & PageName & "' </Script>")
    End Sub

    Public Shared Sub myPopCalendar(ByVal Page As Page, ByVal imgCalendar As Object, ByVal Control As String)
        Try
            imgCalendar.Style.Add("CURSOR", "hand")
            imgCalendar.Attributes.Add("onclick", "popUpCalendar(document.forms[0]." & Control & ",document.forms[0]." & Control & ",'dd/mm/yyyy','E');")
        Catch ex As Exception
            Throw New Exception(ex.ToString)
        End Try
    End Sub

#End Region

#Region " DateTime "
    Public Shared Function ConvertDate(ByVal itmDate As String)
        Try
            Dim RealDate As String
            If itmDate = "" Then
                Return itmDate
                Exit Function
            End If
            If Split(itmDate, "/", -1).Length = 1 Then
                Dim dd As String = Mid(itmDate, 7, 2)
                Dim MM As String = Mid(itmDate, 5, 2)
                Dim yy As String = Left(itmDate, 4)
                RealDate = dd & "/" & MM & "/" & yy
            Else
                '20/05/2006'
                Dim dd As String = Left(itmDate, 2)
                Dim MM As String = Mid(itmDate, 4, 2)
                Dim yy As String = Mid(itmDate, 7, 4)
                RealDate = yy & MM & dd
            End If
            Return RealDate
        Catch ex As Exception
            Return itmDate
        End Try

    End Function
    Public Shared Function DateQuery(ByVal itmDate As String)
        Dim year As Integer
        year = Convert.ToInt64(itmDate.Substring(6, 4))
        If year > 2473 Then
            year = year - 543
        End If
        Return year.ToString() & "-" & itmDate.Substring(3, 2) & "-" & itmDate.Substring(0, 2)
    End Function

    Public Shared Function ConvertToTypeDate(ByVal itmDate As String)
        Try
            Dim rtnDate As DateTime
            If itmDate.Length = 8 Then
                Dim rYear As Integer = Left(itmDate, 4)
                Dim rMonth As Integer = Mid(itmDate, 5, 2)
                Dim rDay As Integer = Right(itmDate, 2)
                rtnDate = New DateTime(rYear, rMonth, rDay)
            Else
                Dim rYear As Integer = Right(itmDate, 4)
                Dim rMonth As Integer = Mid(itmDate, 4, 2)
                Dim rDay As Integer = Left(itmDate, 2)
                rtnDate = New DateTime(rYear, rMonth, rDay)
            End If
            Return rtnDate
        Catch ex As Exception
            Throw New Exception(ex.ToString)
        End Try
    End Function

#End Region
    Public Function Encrypt(ByVal str As String) As String
        Dim X As String
        Dim tmp As String = ""
        Dim i As Integer
        For i = 1 To Len(str)
            X = Mid(str, i, 1)
            tmp = tmp & Chr(Asc(X) + 1)
        Next
        tmp = StrReverse(tmp)

        Return tmp
    End Function
    Public Function Decrypt(ByVal str As String) As String
        Dim X As String
        Dim tmp As String = ""
        Dim i As Integer
        str = StrReverse(str)
        For i = 1 To Len(str)
            X = Mid(str, i, 1)
            tmp = tmp & Chr(Asc(X) - 1)
        Next

        Return tmp
    End Function



End Class
