Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.IO
Imports System.Text

Public Class clsGenCode_Promotion
    Public Function GenCode_Promotion_Cross(ByVal strOrder_No As String, ByVal strChcek_Promotion As String) As String
        Dim strOrderNO_New As String = ""
        Dim strCode_Promotion As String = ""
        Dim strSubsting_Order As String = ""

        strOrderNO_New = Left(strOrder_No, 6) & Right(strOrder_No, 4)
        strSubsting_Order = strOrderNO_New.Substring(8, 1) & strOrderNO_New.Substring(7, 1) & strOrderNO_New.Substring(6, 1) _
                            & strOrderNO_New.Substring(5, 1) & strOrderNO_New.Substring(4, 1) & strOrderNO_New.Substring(9, 1) _
                            & strOrderNO_New.Substring(3, 1) & strOrderNO_New.Substring(2, 1) & strOrderNO_New.Substring(1, 1) & strOrderNO_New.Substring(0, 1)

        Dim strCheckDigit As String = ""
        strCheckDigit = GetReference1CheckDigit(strSubsting_Order)

        strCode_Promotion = "001" & strOrderNO_New & strCheckDigit & strChcek_Promotion

        Return strCode_Promotion
    End Function

    Public Function CheckDigisCode_Promotion_Cross(ByVal strChcek_Promotion As String, ByVal strCode_Promotion_Cross As String) As Boolean
        Dim strOrderNO_New As String = ""
        Dim strCode_Promotion As String = ""
        Dim strSubsting_Order As String = ""

        strOrderNO_New = strCode_Promotion_Cross.Substring(3, 10)
        strSubsting_Order = strOrderNO_New.Substring(8, 1) & strOrderNO_New.Substring(7, 1) & strOrderNO_New.Substring(6, 1) _
                            & strOrderNO_New.Substring(5, 1) & strOrderNO_New.Substring(4, 1) & strOrderNO_New.Substring(9, 1) _
                            & strOrderNO_New.Substring(3, 1) & strOrderNO_New.Substring(2, 1) & strOrderNO_New.Substring(1, 1) & strOrderNO_New.Substring(0, 1)

        Dim strCheckDigit As String = ""
        strCheckDigit = GetReference1CheckDigit(strSubsting_Order)

        If strCheckDigit = strCode_Promotion_Cross.Substring(13, 2) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function GetReference1CheckDigit(ByVal Reference1String As String) As String
        Const PRIME As String = "7,5,9,3,7,5,9,3,5,7"
        Dim PrimeCount() As String = PRIME.Split(",")
        Dim TotalCheckSumb As Integer = 0
        Dim Result As Integer = -1

        Try
            For iIndex As Integer = 1 To Reference1String.Length

                TotalCheckSumb += Convert.ToInt32(Reference1String.Substring(iIndex - 1, 1)) * Convert.ToInt32(PrimeCount(iIndex - 1))
            Next

            TotalCheckSumb = TotalCheckSumb + 57

            Result = TotalCheckSumb Mod 100

            Return Result.ToString("00")
        Catch ex As Exception
            Throw New Exception("Input invalid,Calcuate Checksum error")
        End Try

    End Function
End Class
