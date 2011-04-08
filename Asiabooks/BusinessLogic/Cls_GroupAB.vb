Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data

Public Class Cls_GroupAB
    Private strGroup_Code As String
    Private strGroup_Name As String
    Private strPriority As String

    Property Group_Code()
        Get
            Return strGroup_Code
        End Get
        Set(ByVal value)
            strGroup_Code = value
        End Set
    End Property

    Property Group_Name()
        Get
            Return strGroup_Name
        End Get
        Set(ByVal value)
            strGroup_Name = value
        End Set
    End Property

    Property Priority()
        Get
            Return strPriority
        End Get
        Set(ByVal value)
            strPriority = value
        End Set
    End Property

    Public Function Retreive()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""

        If Group_Code <> "" Then
            condition = " WHERE Group_Code='" + Group_Code + "'"
        End If

        If Group_Name <> "" Then
            If condition.Length = 0 Then
                condition = " WHERE Group_Name='" + Group_Name + "'"
            Else
                condition = condition & " AND Group_Name='" + Group_Name + "'"
            End If
        End If

        If Priority <> "" Then
            If condition.Length = 0 Then
                condition = " WHERE Priority='" + Priority + "'"
            Else
                condition = condition & " AND Priority='" + Priority + "'"
            End If
        End If

        sqlCommand = " SELECT * From tbm_syst_groupab " + condition + " order by priority"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function

    Public Function RetreiveManual(ByVal condition As String)
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String

        sqlCommand = " SELECT * From tbm_syst_groupab " + condition + " order by priority "
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function


End Class
