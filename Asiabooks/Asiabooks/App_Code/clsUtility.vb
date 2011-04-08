Imports Microsoft.VisualBasic
Imports System.Configuration.ConfigurationManager
Imports System.IO
Imports System.Net

Public Class clsUtility

    Dim PicPath As String = AppSettings("PicPath").ToString

    '/////////promptnow/////////
    Dim PicPath_eBook As String = AppSettings("PicPath_eBook").ToString
    '///////promptnow end///////

    Public Function GetImagePath(ByVal strImageName As String) As String
        Try
            Dim strPathImag As String = ""
            strPathImag = PicPath & strImageName.Trim
            Dim fr As System.Net.HttpWebRequest
            Dim targetURI As New Uri(strPathImag)

            Try
                fr = DirectCast(System.Net.HttpWebRequest.Create(targetURI), System.Net.HttpWebRequest)
                If (fr.GetResponse().ContentLength > 0) Then
                    Dim str As New System.IO.StreamReader(fr.GetResponse().GetResponseStream())
                    str.Close()
                Else
                    strPathImag = "~/images_book/no_book.jpg"
                End If
            Catch ex As System.Net.WebException
                strPathImag = "~/images_book/no_book.jpg"
            End Try

            If strImageName = "no_image.jpg" Then
                strPathImag = "~/images_book/no_book.jpg"
                'Else
                '    strPathImag = PicPath & strImageName.Trim
            End If
            Return strPathImag

        Catch ex As Exception
            Return (PicPath & "no_image.jpg").Trim
        End Try
    End Function
    Public Function GetImagePath_Magazine(ByVal strImageName As String) As String
        Try

            Dim strPathImag As String = ""

            If strImageName = "no_image.jpg" Then
                strPathImag = "images_book/no_magazine.jpg"
            Else
                strPathImag = PicPath & strImageName.Trim
            End If
            Return strPathImag

        Catch ex As Exception
            Return (PicPath & "no_image.jpg").Trim
        End Try
    End Function
    Public Function GetImagePath_Book(ByVal strImageName As String) As String
        Try

            Dim strPathImag As String = ""

            If strImageName = "no_image.jpg" Then
                strPathImag = "images_book/no_book.jpg"
            Else
                strPathImag = PicPath & strImageName.Trim
            End If
            Return strPathImag

        Catch ex As Exception
            Return (PicPath & "no_image.jpg").Trim
        End Try
    End Function
    
    '/////////promptnow/////////
    Public Function GetImagePath_eBook(ByVal strImageName As String) As String
        Try
            Dim strPathImag As String = ""
            strPathImag = PicPath_eBook & strImageName.Trim
            Dim fr As System.Net.HttpWebRequest
            Dim targetURI As New Uri(strPathImag)

            Try
                fr = DirectCast(System.Net.HttpWebRequest.Create(targetURI), System.Net.HttpWebRequest)
                If (fr.GetResponse().ContentLength > 0) Then
                    Dim str As New System.IO.StreamReader(fr.GetResponse().GetResponseStream())
                    'Response.Write(str.ReadToEnd())
                    str.Close()
                Else
                    strPathImag = "~/images_book/no_ebook.jpg"
                End If

            Catch ex As System.Net.WebException
                strPathImag = "~/images_book/no_ebook.jpg"
            End Try

            If strImageName = "no_image.jpg" Then
                strPathImag = "~/images_book/no_ebook.jpg"
            End If
            Return strPathImag

        Catch ex As Exception
            Return (PicPath_eBook & "no_image.jpg").Trim
        End Try
    End Function
End Class
