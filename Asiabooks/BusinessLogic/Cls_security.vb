Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.Configuration
Public Class Cls_security
    Public Function CheckSecurity(ByVal PageId As String, ByVal EmpId As String) As Boolean
        'If Convert.ToString(ConfigurationSettings.AppSettings("CheckSecurity")).ToString() = "False" Then ' กรณี webconfig ระบุ CheckSecrity = False คือจะไม่เช็ค Security return ค่าเป็น True
        '    Return True
        'End If

        If PageId = "" Or EmpId = "" Then
            Return False
        End If
        Dim sqlString As String = " SELECT formcd, empcd, sctylvl  FROM tbm_syst_scty Where sctylvl = 1 And formcd = '" + PageId + "' And empcd = '" + EmpId + "'"
        Dim sqlDB As New SqlDb
        Dim dt As DataTable = sqlDB.GetDataTable(sqlString)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Return True
    End Function
    Public Function CheckSecurity_Report(ByVal PageId As String, ByVal EmpId As String)
        Dim sqlDB As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        sqlCommand = " SELECT formcd, empcd, sctylvl  FROM tbm_syst_scty  "
        sqlCommand &= " Where sctylvl = 1 And formcd in(" + PageId + ") "
        sqlCommand &= " And empcd = '" + EmpId + "'"
        dt = sqlDB.GetDataTable(sqlCommand)
       
        Return dt
    End Function

End Class
