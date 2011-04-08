Public Class PageControl
    Public Function ShowingResultSet(ByVal PageIndex As Int64, ByVal PageSize As Int64, ByVal TotalRecordCount As Int64) As String
        Dim result_string As String
        If TotalRecordCount > 999 Then
            If (PageIndex + 1) * PageSize < TotalRecordCount Then
                result_string = "Showing " & ((PageIndex * PageSize) + 1).ToString("#,##0") & "-" & ((PageIndex + 1) * PageSize).ToString("#,##0") & " and more..."
            Else
                result_string = "Showing " & ((PageIndex * PageSize) + 1).ToString("#,##0") & "-" & TotalRecordCount.ToString("#,##0") & " and more..."
            End If
        Else
            If (PageIndex + 1) * PageSize < TotalRecordCount Then
                result_string = "Showing " & ((PageIndex * PageSize) + 1).ToString("#,##0") & "-" & ((PageIndex + 1) * PageSize).ToString("#,##0") & " of " & TotalRecordCount.ToString("#,##0") & " records"
            Else
                result_string = "Showing " & ((PageIndex * PageSize) + 1).ToString("#,##0") & "-" & TotalRecordCount.ToString("#,##0") & " of " & TotalRecordCount.ToString("#,##0") & " records"
            End If
        End If

        Return result_string
    End Function
End Class
