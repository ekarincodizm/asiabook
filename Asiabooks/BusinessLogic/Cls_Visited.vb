Imports System.IO

Public Class Cls_Visited
    Public Function WriteCouterVisit() As String
        Dim strfile As String = System.AppDomain.CurrentDomain.BaseDirectory() & "visited.txt"
        Dim sr As StreamReader
        Dim sw As StreamWriter
        Dim couter As String = ""

        Try
            sr = New StreamReader(strfile)

            Do While sr.Peek() > -1
                Dim strText() As String = (sr.ReadLine).Split("=")
                If strText(0) = "couter" Then
                    couter = strText(1)
                End If
            Loop
            sr.Close()

            sw = New StreamWriter(strfile, False)
            If couter = "" Then
                couter = "1"
            Else
                couter = (CInt(couter) + 1).ToString
            End If
            sw.Write("couter=" & couter)
            sw.Close()

            Return couter
        Catch ex As Exception
            Return couter
        Finally
            sr = Nothing
            sw = Nothing
            couter = Nothing
        End Try

    End Function
End Class
