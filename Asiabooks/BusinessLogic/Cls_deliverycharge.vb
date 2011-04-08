Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.Net.DNS
Public Class Cls_deliverycharge
    Private strZone_Code As String
    Private strTransport_Type As String
    Private strWeight As String
    Private strCharge_Rate As String
    Private strFuel_Surcharge As String
    Private strTo_Weight As String
    Private strEmpcd As String
    Private strCountry_Code As String
    Public message As String
    Private strPcnm As String
    Property Pcnm()
        Get
            Return strPcnm
        End Get
        Set(ByVal value)
            strPcnm = value
        End Set
    End Property
    Property Transport_Type()
        Get
            Return strTransport_Type
        End Get
        Set(ByVal value)
            strTransport_Type = value
        End Set
    End Property
    Property Zone_Code()
        Get
            Return strZone_Code
        End Get
        Set(ByVal value)
            strZone_Code = value
        End Set
    End Property
    Property Weight()
        Get
            Return strWeight
        End Get
        Set(ByVal value)
            strWeight = value
        End Set
    End Property
    Property Charge_Rate()
        Get
            Return strCharge_Rate
        End Get
        Set(ByVal value)
            strCharge_Rate = value
        End Set
    End Property
    Property Fuel_Surcharge()
        Get
            Return strFuel_Surcharge
        End Get
        Set(ByVal value)
            strFuel_Surcharge = value
        End Set
    End Property
    Property To_Weight()
        Get
            Return strTo_Weight
        End Get
        Set(ByVal value)
            strTo_Weight = value
        End Set
    End Property
    Property Empcd()
        Get
            Return strEmpcd
        End Get
        Set(ByVal value)
            strEmpcd = value
        End Set
    End Property
    Property Country_Code()
        Get
            Return strCountry_Code
        End Get
        Set(ByVal value)
            strCountry_Code = value
        End Set
    End Property
    Public Function Retreive()
        Dim sqlDb As New SqlDb
        Dim dt As DataTable
        Dim sqlCommand As String
        Dim condition As String = ""
        If Transport_Type <> "" Then
            condition = "WHERE Transport_Type='" + Transport_Type + "'"
        End If
        If Zone_Code <> "" Then
            If condition.Length = 0 Then
                condition &= "WHERE tbm_syst_deliverycharge.Zone_Code = '" + Zone_Code + "'"
            Else
                condition &= "AND tbm_syst_deliverycharge.Zone_Code = '" + Zone_Code + "'"
            End If
        End If

        If Weight <> "" Then
            If condition.Length = 0 Then
                condition &= "WHERE Weight = '" + CDbl(Weight).ToString + "'"
            Else
                condition &= "AND Weight = '" + CDbl(Weight).ToString + "'"
            End If
        End If

        If To_Weight <> "" Then
            If condition.Length = 0 Then
                condition &= "WHERE To_Weight = '" + CDbl(To_Weight).ToString + "'"
            Else
                condition &= "AND To_Weight = '" + CDbl(To_Weight).ToString + "'"
            End If
        End If

        If Charge_Rate <> "" Then
            If condition.Length = 0 Then
                condition &= "WHERE Charge_Rate = '" + CDbl(Charge_Rate).ToString + "'"
            Else
                condition &= "AND Charge_Rate = '" + CDbl(Charge_Rate).ToString + "'"
            End If
        End If
        If Country_Code <> 0 Then
            If condition.Length = 0 Then
                condition &= "WHERE Country_Code = '" + Country_Code + "'"
            Else
                condition &= "AND Country_Code = '" + Country_Code + "'"
            End If
        End If

        sqlCommand = "SELECT Transport_Type,tbm_syst_deliverycharge.Zone_Code,"
        sqlCommand &= "Weight,To_Weight,Charge_Rate,"
        sqlCommand &= "Fuel_Surcharge,Country_Code,Country_Name  "
        sqlCommand &= " From tbm_syst_deliverycharge"
        sqlCommand &= " left join tbm_syst_country"
        sqlCommand &= " on tbm_syst_deliverycharge.Zone_Code=tbm_syst_country.Zone_code " + condition
        sqlCommand &= " ORDER BY Country_Name,Weight"
        dt = sqlDb.GetDataTable(sqlCommand)
        Return dt
    End Function
    Public Sub Add()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try

            sqlDb.BeginTrans()
            sqlCommand = "INSERT INTO tbm_syst_deliverycharge "
            sqlCommand &= " (Transport_Type,Zone_Code,Weight,To_Weight,Charge_Rate,Fuel_Surcharge,"
            sqlCommand &= "addempcd,addpcnm,adddt)"
            sqlCommand &= " VALUES('" + Transport_Type + "',"
            sqlCommand &= "'" + Zone_Code + "',"
            sqlCommand &= "'" + CDbl(Weight).ToString + "',"
            sqlCommand &= "'" + CDbl(To_Weight).ToString + "',"
            sqlCommand &= "'" + CDbl(Charge_Rate).ToString + "',"
            sqlCommand &= "'" + CDbl(Fuel_Surcharge).ToString + "',"
            sqlCommand &= "'" + Empcd + "',"
            sqlCommand &= "'" + Pcnm + "',"
            sqlCommand &= "'" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "')"
            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()

            message = "Add Transport Type : " + Transport_Type
            message &= " ZONE : " + Zone_Code
            message &= " Weight : " + Weight
            message &= " Successful"
        Catch ex As Exception
            sqlDb.RollbackTrans()
            message = "Add Transport Type : " + Transport_Type
            message &= " ZONE : " + Zone_Code
            message &= " Weight : " + Weight
            message &= " UnSuccessful"
        End Try
    End Sub
    Public Sub Edit()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try

            sqlDb.BeginTrans()
            sqlCommand = "UPDATE tbm_syst_deliverycharge "
            sqlCommand &= " SET To_Weight ='" + CDbl(To_Weight).ToString + "',"
            sqlCommand &= " Charge_Rate ='" + CDbl(Charge_Rate).ToString + "',"
            sqlCommand &= " Fuel_Surcharge ='" + CDbl(Fuel_Surcharge).ToString + "',"
            sqlCommand &= " updempcd='" + Empcd + "',"
            sqlCommand &= " updpcnm='" + Pcnm + "',"
            sqlCommand &= " upddt='" + sqlDb.GetDataTable("SELECT convert(varchar(30),getdate(),120)").Rows(0)(0).ToString + "'"
            sqlCommand &= " WHERE Transport_Type='" + Transport_Type + "'"
            sqlCommand &= " and Zone_Code='" + Zone_Code + "'"
            sqlCommand &= " and Weight='" + CDbl(Weight).ToString + "'"

            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Update Transport Type : " + Transport_Type
            message &= " ZONE : " + Zone_Code
            message &= " Weight  : " + Weight
            message &= " Successful"

        Catch ex As Exception
            sqlDb.RollbackTrans()
            message = "Update Transport Type : " + Transport_Type
            message &= " ZONE : " + Zone_Code
            message &= " Weight : " + Weight
            message &= " UnSuccessful"
        End Try
    End Sub
    Public Sub Delete()
        Dim sqlDb As New SqlDb
        Dim sqlCommand As String
        Try
            sqlDb.BeginTrans()
            sqlCommand = "DELETE tbm_syst_deliverycharge "
            sqlCommand &= " WHERE Transport_Type='" + Transport_Type + "'"
            sqlCommand &= " and Zone_Code='" + Zone_Code + "'"
            sqlCommand &= " and Weight='" + CDbl(Weight).ToString + "'"


            sqlDb.Exec(sqlCommand)
            sqlDb.CommitTrans()
            message = "Delete Transport Type : " + Transport_Type
            message &= " ZONE : " + Zone_Code
            message &= " Weight : " + Weight
            message &= " Successful"
        Catch ex As Exception
            sqlDb.RollbackTrans()
            message = "Delete Transport Type : " + Transport_Type
            message &= " ZONE : " + Zone_Code
            message &= " Weight : " + Weight
            message &= " UnSuccessful"
        End Try
    End Sub
End Class
