Imports Microsoft.VisualBasic
Imports Eordering.BusinessLogic
Imports System
Imports System.Data
Imports System.Configuration

Public Class Cls_Member
   
    Private strBS_V_NAME_PREFIX_ID As String
    Private strNEWS_VIA_EMAIL As String
    Private strNEWS_VIA_SMS As String
    Private strNEWS_VIA_LETTER As String
    Private strNATIONALITY As String
    Private strMEMBER_CODE As String
    Private strNAME_EN As String
    Private strSURNAME_EN As String
    Private strNAME_TH As String
    Private strSURNAME_TH As String
    Private strBIRTHDAY As String
    Private strMOBILE_TEL As String
    Private strTEL As String
    Private strEMAIL_ADDRESS As String
    Private strCITIZEN_NO As String
    Private strPASSPORT_NO As String
    Private strNUM_CHILD As String
    Private strPLACE_NAME_H As String
    Private strROOM_NUMBER_H As String
    Private strPLACE_NUMBER_H As String
    Private strMOO_H As String
    Private strALLEY_H As String
    Private strROAD_H As String
    Private strDISTRICT_H As String
    Private strAMPHUR_H As String
    Private strPROVINCE_H As String
    Private strZIPCODE_H As String
    Private strCOUNTRY_H As String
    Private strPLACE_NAME_O As String
    Private strROOM_NUMBER_O As String
    Private strPLACE_NUMBER_O As String
    Private strMOO_O As String
    Private strALLEY_O As String
    Private strROAD_O As String
    Private strDISTRICT_O As String
    Private strAMPHUR_O As String
    Private strPROVINCE_O As String
    Private strZIPCODE_O As String
    Private strCOUNTRY_O As String
    Private strPLACE_NAME_S As String
    Private strROOM_NUMBER_S As String
    Private strPLACE_NUMBER_S As String
    Private strMOO_S As String
    Private strALLEY_S As String
    Private strROAD_S As String
    Private strDISTRICT_S As String
    Private strAMPHUR_S As String
    Private strPROVINCE_S As String
    Private strZIPCODE_S As String
    Private strCOUNTRY_S As String
    Property BS_V_NAME_PREFIX_ID()
        Get
            Return strBS_V_NAME_PREFIX_ID
        End Get
        Set(ByVal value)
            strBS_V_NAME_PREFIX_ID = value
        End Set
    End Property
    Property NEWS_VIA_EMAIL()
        Get
            Return strNEWS_VIA_EMAIL
        End Get
        Set(ByVal value)
            strNEWS_VIA_EMAIL = value
        End Set
    End Property
    Property NEWS_VIA_SMS()
        Get
            Return strNEWS_VIA_SMS
        End Get
        Set(ByVal value)
            strNEWS_VIA_SMS = value
        End Set
    End Property
    Property NEWS_VIA_LETTER()
        Get
            Return strNEWS_VIA_LETTER
        End Get
        Set(ByVal value)
            strNEWS_VIA_LETTER = value
        End Set
    End Property
    Property NATIONALITY()
        Get
            Return strNATIONALITY
        End Get
        Set(ByVal value)
            strNATIONALITY = value
        End Set
    End Property
    Property MEMBER_CODE()
        Get
            Return strMEMBER_CODE
        End Get
        Set(ByVal value)
            strMEMBER_CODE = value
        End Set
    End Property
    Property NAME_EN()
        Get
            Return strNAME_EN
        End Get
        Set(ByVal value)
            strNAME_EN = value
        End Set
    End Property
    Property SURNAME_EN()
        Get
            Return strSURNAME_EN
        End Get
        Set(ByVal value)
            strSURNAME_EN = value
        End Set
    End Property
    Property NAME_TH()
        Get
            Return strNAME_TH
        End Get
        Set(ByVal value)
            strNAME_TH = value
        End Set
    End Property
    Property SURNAME_TH()
        Get
            Return strSURNAME_TH
        End Get
        Set(ByVal value)
            strSURNAME_TH = value
        End Set
    End Property
    Property BIRTHDAY()
        Get
            Return strBIRTHDAY
        End Get
        Set(ByVal value)
            strBIRTHDAY = value
        End Set
    End Property
    Property MOBILE_TEL()
        Get
            Return strMOBILE_TEL
        End Get
        Set(ByVal value)
            strMOBILE_TEL = value
        End Set
    End Property
    Property TEL()
        Get
            Return strTEL
        End Get
        Set(ByVal value)
            strTEL = value
        End Set
    End Property
    Property EMAIL_ADDRESS()
        Get
            Return strEMAIL_ADDRESS
        End Get
        Set(ByVal value)
            strEMAIL_ADDRESS = value
        End Set
    End Property
    Property CITIZEN_NO()
        Get
            Return strCITIZEN_NO
        End Get
        Set(ByVal value)
            strCITIZEN_NO = value
        End Set
    End Property
    Property PASSPORT_NO()
        Get
            Return strPASSPORT_NO
        End Get
        Set(ByVal value)
            strPASSPORT_NO = value
        End Set
    End Property
    Property NUM_CHILD()
        Get
            Return strNUM_CHILD
        End Get
        Set(ByVal value)
            strNUM_CHILD = value
        End Set
    End Property
    Property PLACE_NAME_H()
        Get
            Return strPLACE_NAME_H
        End Get
        Set(ByVal value)
            strPLACE_NAME_H = value
        End Set
    End Property
    Property ROOM_NUMBER_H()
        Get
            Return strROOM_NUMBER_H
        End Get
        Set(ByVal value)
            strROOM_NUMBER_H = value
        End Set
    End Property
    Property PLACE_NUMBER_H()
        Get
            Return strPLACE_NUMBER_H
        End Get
        Set(ByVal value)
            strPLACE_NUMBER_H = value
        End Set
    End Property
    Property MOO_H()
        Get
            Return strMOO_H
        End Get
        Set(ByVal value)
            strMOO_H = value
        End Set
    End Property
    Property ALLEY_H()
        Get
            Return strALLEY_H
        End Get
        Set(ByVal value)
            strALLEY_H = value
        End Set
    End Property
    Property ROAD_H()
        Get
            Return strROAD_H
        End Get
        Set(ByVal value)
            strROAD_H = value
        End Set
    End Property
    Property DISTRICT_H()
        Get
            Return strDISTRICT_H
        End Get
        Set(ByVal value)
            strDISTRICT_H = value
        End Set
    End Property
    Property AMPHUR_H()
        Get
            Return strAMPHUR_H
        End Get
        Set(ByVal value)
            strAMPHUR_H = value
        End Set
    End Property
    Property PROVINCE_H()
        Get
            Return strPROVINCE_H
        End Get
        Set(ByVal value)
            strPROVINCE_H = value
        End Set
    End Property
    Property ZIPCODE_H()
        Get
            Return strZIPCODE_H
        End Get
        Set(ByVal value)
            strZIPCODE_H = value
        End Set
    End Property
    Property COUNTRY_H()
        Get
            Return strCOUNTRY_H
        End Get
        Set(ByVal value)
            strCOUNTRY_H = value
        End Set
    End Property
    Property PLACE_NAME_O()
        Get
            Return strPLACE_NAME_O
        End Get
        Set(ByVal value)
            strPLACE_NAME_O = value
        End Set
    End Property
    Property ROOM_NUMBER_O()
        Get
            Return strROOM_NUMBER_O
        End Get
        Set(ByVal value)
            strROOM_NUMBER_O = value
        End Set
    End Property
    Property PLACE_NUMBER_O()
        Get
            Return strPLACE_NUMBER_O
        End Get
        Set(ByVal value)
            strPLACE_NUMBER_O = value
        End Set
    End Property
    Property MOO_O()
        Get
            Return strMOO_O
        End Get
        Set(ByVal value)
            strMOO_O = value
        End Set
    End Property
    Property ALLEY_O()
        Get
            Return strALLEY_O
        End Get
        Set(ByVal value)
            strALLEY_O = value
        End Set
    End Property
    Property ROAD_O()
        Get
            Return strROAD_O
        End Get
        Set(ByVal value)
            strROAD_O = value
        End Set
    End Property
    Property DISTRICT_O()
        Get
            Return strDISTRICT_O
        End Get
        Set(ByVal value)
            strDISTRICT_O = value
        End Set
    End Property
    Property AMPHUR_O()
        Get
            Return strAMPHUR_O
        End Get
        Set(ByVal value)
            strAMPHUR_O = value
        End Set
    End Property
    Property PROVINCE_O()
        Get
            Return strPROVINCE_O
        End Get
        Set(ByVal value)
            strPROVINCE_O = value
        End Set
    End Property
    Property ZIPCODE_O()
        Get
            Return strZIPCODE_O
        End Get
        Set(ByVal value)
            strZIPCODE_O = value
        End Set
    End Property
    Property COUNTRY_O()
        Get
            Return strCOUNTRY_O
        End Get
        Set(ByVal value)
            strCOUNTRY_O = value
        End Set
    End Property
    Property PLACE_NAME_S()
        Get
            Return strPLACE_NAME_S
        End Get
        Set(ByVal value)
            strPLACE_NAME_S = value
        End Set
    End Property
    Property ROOM_NUMBER_S()
        Get
            Return strROOM_NUMBER_S
        End Get
        Set(ByVal value)
            strROOM_NUMBER_S = value
        End Set
    End Property
    Property PLACE_NUMBER_S()
        Get
            Return strPLACE_NUMBER_S
        End Get
        Set(ByVal value)
            strPLACE_NUMBER_S = value
        End Set
    End Property
    Property MOO_S()
        Get
            Return strMOO_S
        End Get
        Set(ByVal value)
            strMOO_S = value
        End Set
    End Property
    Property ALLEY_S()
        Get
            Return strALLEY_S
        End Get
        Set(ByVal value)
            strALLEY_S = value
        End Set
    End Property
    Property ROAD_S()
        Get
            Return strROAD_S
        End Get
        Set(ByVal value)
            strROAD_S = value
        End Set
    End Property
    Property DISTRICT_S()
        Get
            Return strDISTRICT_S
        End Get
        Set(ByVal value)
            strDISTRICT_S = value
        End Set
    End Property
    Property AMPHUR_S()
        Get
            Return strAMPHUR_S
        End Get
        Set(ByVal value)
            strAMPHUR_S = value
        End Set
    End Property
    Property PROVINCE_S()
        Get
            Return strPROVINCE_S
        End Get
        Set(ByVal value)
            strPROVINCE_S = value
        End Set
    End Property
    Property ZIPCODE_S()
        Get
            Return strZIPCODE_S
        End Get
        Set(ByVal value)
            strZIPCODE_S = value
        End Set
    End Property
    Property COUNTRY_S()
        Get
            Return strCOUNTRY_S
        End Get
        Set(ByVal value)
            strCOUNTRY_S = value
        End Set
    End Property
    Public Function Post_Member()
        'check_id_card(tbx_id_number.Text)
        Dim ds As New DataSet
        Dim dt_member As New DataTable
        Dim dr_member As DataRow
        Dim sqlDb As New SqlDb

        dt_member.Columns.Add("BS_V_MEMBER_TYPE_ID")
        dt_member.Columns.Add("MB_CONDITIONS_ID")
        dt_member.Columns.Add("MB_STATUS")
        dt_member.Columns.Add("AT_ORG_ID")
        dt_member.Columns.Add("BS_V_NAME_PREFIX_ID")
        dt_member.Columns.Add("MEMBER_CODE")
        dt_member.Columns.Add("DESCRIPTION")
        dt_member.Columns.Add("CREATED")
        dt_member.Columns.Add("NAME_EN") 'Name (Eng):
        dt_member.Columns.Add("SURNAME_EN") 'Surname (Eng) :
        dt_member.Columns.Add("NAME_TH") 'Name (Thai):
        dt_member.Columns.Add("SURNAME_TH") 'Surname (Thai) :
        dt_member.Columns.Add("BIRTHDAY") 'Date of Birth (dd/mm/yyyy) :
        dt_member.Columns.Add("MOBILE_TEL") 'Mobile :
        dt_member.Columns.Add("TEL") 'Telephone :
        dt_member.Columns.Add("EMAIL_ADDRESS") 'E-mail :
        dt_member.Columns.Add("NEWS_VIA_EMAIL") 'รับข่าวทางอีเมล์
        dt_member.Columns.Add("NEWS_VIA_SMS") 'รับข่าวทาง SMS
        dt_member.Columns.Add("NEWS_VIA_LETTER") 'รับข่าวทางจดหมาย
        dt_member.Columns.Add("CITIZEN_NO") 'ID Card Number :
        dt_member.Columns.Add("NATIONALITY") 'สัญชาติ
        dt_member.Columns.Add("PASSPORT_NO") 'ID Card Passport :
        dt_member.Columns.Add("NUM_CHILD") 'Children :
        'addredd1----------------------------------------------------------------------
        dt_member.Columns.Add("PLACE_NAME_H") 'City :
        dt_member.Columns.Add("ROOM_NUMBER_H") 'Street :
        dt_member.Columns.Add("PLACE_NUMBER_H") 'City :
        dt_member.Columns.Add("MOO_H") 'Province :
        dt_member.Columns.Add("ALLEY_H") 'Postal :
        dt_member.Columns.Add("ROAD_H") 'Country :
        dt_member.Columns.Add("DISTRICT_H")
        dt_member.Columns.Add("AMPHUR_H")
        dt_member.Columns.Add("PROVINCE_H")
        dt_member.Columns.Add("ZIPCODE_H")
        dt_member.Columns.Add("COUNTRY_H")
        dt_member.Columns.Add("ADDRESS_TYPE_ID_H")
        'addredd2----------------------------------------------------------------------
        dt_member.Columns.Add("PLACE_NAME_O") 'City :
        dt_member.Columns.Add("ROOM_NUMBER_O") 'Street :
        dt_member.Columns.Add("PLACE_NUMBER_O") 'City :
        dt_member.Columns.Add("MOO_O") 'Province :
        dt_member.Columns.Add("ALLEY_O") 'Postal :
        dt_member.Columns.Add("ROAD_O") 'Country :
        dt_member.Columns.Add("DISTRICT_O")
        dt_member.Columns.Add("AMPHUR_O")
        dt_member.Columns.Add("PROVINCE_O")
        dt_member.Columns.Add("ZIPCODE_O")
        dt_member.Columns.Add("COUNTRY_O")
        dt_member.Columns.Add("ADDRESS_TYPE_ID_O")
        'addredd3----------------------------------------------------------------------
        dt_member.Columns.Add("PLACE_NAME_S") 'City :
        dt_member.Columns.Add("ROOM_NUMBER_S") 'Street :
        dt_member.Columns.Add("PLACE_NUMBER_S") 'City :
        dt_member.Columns.Add("MOO_S") 'Province :
        dt_member.Columns.Add("ALLEY_S") 'Postal :
        dt_member.Columns.Add("ROAD_S") 'Country :
        dt_member.Columns.Add("DISTRICT_S")
        dt_member.Columns.Add("AMPHUR_S")
        dt_member.Columns.Add("PROVINCE_S")
        dt_member.Columns.Add("ZIPCODE_S")
        dt_member.Columns.Add("COUNTRY_S")
        dt_member.Columns.Add("ADDRESS_TYPE_ID_S")

        dr_member = dt_member.NewRow ' add Columns

        dr_member("BS_V_MEMBER_TYPE_ID") = "470011"
        dr_member("MB_CONDITIONS_ID") = "490106"
        dr_member("AT_ORG_ID") = "2"
        dr_member("MB_STATUS") = "Y"
        dr_member("MEMBER_CODE") = MEMBER_CODE
        dr_member("DESCRIPTION") = ""

        Dim CartDateArr(2) As String
        Dim CartDateConvert As String
        Dim date_birth As String
        Dim created As String
        Dim createdArr(2) As String
        Dim createdConvert As String

        created = sqlDb.GetDataTable("SELECT CONVERT(VARCHAR(10),GETDATE(),120)").Rows(0)(0).ToString
        createdArr = created.ToString.Split("-")
        createdConvert = createdArr(0) & "/" & createdArr(1) & "/" & createdArr(2)
        dr_member("CREATED") = createdConvert
        dr_member("BS_V_NAME_PREFIX_ID") = BS_V_NAME_PREFIX_ID 'Title (Eng) :
        dr_member("NAME_EN") = NAME_EN 'Name (Eng):
        dr_member("SURNAME_EN") = SURNAME_EN 'Surname (Eng) :

        'check name and surname(Thai)-------------------------------------------------------------------
        If NAME_TH = "" Then
            dr_member("NAME_TH") = NAME_EN 'Name (Thai):
        Else
            dr_member("NAME_TH") = NAME_TH 'Name (Thai):
        End If

        If SURNAME_TH = "" Then
            dr_member("SURNAME_TH") = SURNAME_EN 'Surname (Thai) :
        Else
            dr_member("SURNAME_TH") = SURNAME_TH 'Surname (Thai) :
        End If
        'check name and surname(Thai)-------------------------------------------------------------------

        date_birth = BIRTHDAY
        If date_birth <> "" Then
            CartDateArr = date_birth.ToString.Split("-")
            CartDateConvert = CartDateArr(0) & "/" & CartDateArr(1) & "/" & CartDateArr(2)
            dr_member("BIRTHDAY") = CartDateConvert
        Else
            dr_member("BIRTHDAY") = createdConvert
        End If
        dr_member("MOBILE_TEL") = MOBILE_TEL 'Mobile :
        dr_member("TEL") = TEL 'Telephone :
        dr_member("EMAIL_ADDRESS") = EMAIL_ADDRESS 'E-mail :
        dr_member("NEWS_VIA_EMAIL") = NEWS_VIA_EMAIL 'รับข่าวทางอีเมล์
        dr_member("NEWS_VIA_SMS") = NEWS_VIA_SMS 'รับข่าวทาง SMS
        dr_member("NEWS_VIA_LETTER") = NEWS_VIA_LETTER 'รับข่าวทางจดหมาย
        dr_member("CITIZEN_NO") = CITIZEN_NO 'ID Card Number :
        dr_member("NATIONALITY") = NATIONALITY 'สัญชาติ
        dr_member("PASSPORT_NO") = PASSPORT_NO 'ID Card Passport :
        If NUM_CHILD <> "" Then
            dr_member("NUM_CHILD") = NUM_CHILD 'Children :
        Else
            dr_member("NUM_CHILD") = 0
        End If
        'addredd1----------------------------------------------------------------------
        dr_member("PLACE_NAME_H") = PLACE_NAME_H 'Address :
        dr_member("ROOM_NUMBER_H") = ROOM_NUMBER_H 'Street :
        dr_member("PLACE_NUMBER_H") = PLACE_NUMBER_H 'City :
        dr_member("MOO_H") = MOO_H 'Province :
        dr_member("ALLEY_H") = ALLEY_H 'Postal :
        dr_member("ROAD_H") = ROAD_H 'Country :
        dr_member("DISTRICT_H") = DISTRICT_H
        dr_member("AMPHUR_H") = AMPHUR_H
        dr_member("PROVINCE_H") = PROVINCE_H
        dr_member("ZIPCODE_H") = ZIPCODE_H
        dr_member("COUNTRY_H") = COUNTRY_H
        dr_member("ADDRESS_TYPE_ID_H") = "470021"
        'addredd2----------------------------------------------------------------------
        dr_member("PLACE_NAME_O") = PLACE_NAME_O 'Address :
        dr_member("ROOM_NUMBER_O") = ROOM_NUMBER_O 'Street :
        dr_member("PLACE_NUMBER_O") = PLACE_NUMBER_O 'City :
        dr_member("MOO_O") = MOO_O 'Province :
        dr_member("ALLEY_O") = ALLEY_O 'Postal :
        dr_member("ROAD_O") = ROAD_O 'Country :
        dr_member("DISTRICT_O") = DISTRICT_O
        dr_member("AMPHUR_O") = AMPHUR_O
        dr_member("PROVINCE_O") = PROVINCE_O
        dr_member("ZIPCODE_O") = ZIPCODE_O
        dr_member("COUNTRY_O") = COUNTRY_O
        dr_member("ADDRESS_TYPE_ID_O") = "470022"
        'addredd3----------------------------------------------------------------------
        dr_member("PLACE_NAME_S") = PLACE_NAME_S 'Address :
        dr_member("ROOM_NUMBER_S") = ROOM_NUMBER_S 'Street :
        dr_member("PLACE_NUMBER_S") = PLACE_NUMBER_S 'City :
        dr_member("MOO_S") = MOO_S 'Province :
        dr_member("ALLEY_S") = ALLEY_S 'Postal :
        dr_member("ROAD_S") = ROAD_S 'Country :
        dr_member("DISTRICT_S") = DISTRICT_S
        dr_member("AMPHUR_S") = AMPHUR_S
        dr_member("PROVINCE_S") = PROVINCE_S
        dr_member("ZIPCODE_S") = ZIPCODE_S
        dr_member("COUNTRY_S") = COUNTRY_S
        dr_member("ADDRESS_TYPE_ID_S") = "470023"
        dt_member.Rows.Add(dr_member) ' add Rows
        ds.Tables.Add(dt_member) 'add dataset

        Return ds
    End Function
End Class
