Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.Configuration

Public Class gen_nation
    Public ip As String
    Public temp As String

    Property _temp()
        Get
            Return temp
        End Get
        Set(ByVal value)
            temp = temp
        End Set
    End Property

    Property _ip()
        Get
            Return ip
        End Get
        Set(ByVal value)
            ip = ip
        End Set
    End Property

    Function gen_ip_code()
        Dim SqlDb As SqlDb = New SqlDb
        Dim strsql As String = ""
        Dim nation As DataTable
        Dim assign As Int64 = 0
        Dim array() As String = Split(ip, ".")

        For i As Integer = 0 To array.Length - 1
            assign += Convert.ToInt64(array((array.Length - 1) - i)) * (256 ^ i)
        Next

        strsql &= " select distinct shortcode "
        strsql &= " from ip_country "
        strsql &= " where ip_from <= " + assign.ToString + " "
        strsql &= " and ip_to >= " + assign.ToString + " "
        strsql &= " and status = 1 "

        nation = SqlDb.GetDataTable(strsql)
        Dim client_ As String = ""
        client_ = nation.Rows(0).Item("shortcode")
        Return client_
    End Function
End Class

