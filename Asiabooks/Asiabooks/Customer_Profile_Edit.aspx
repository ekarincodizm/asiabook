<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Customer_Profile_Edit.aspx.vb" Inherits="Customer_Profile_Edit" title="Untitled Page" %>
<%@ Register Src="uc/ucCalendar.ascx" TagName="ucCalendar" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="MycustomDG" Namespace="MycustomDG" TagPrefix="Saifi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

    <table cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="height: 10px; width: 100%;" align="left" colspan="6" 
                class="labeedit_profile_head">
                </td>
        </tr>
        <tr>
            <td style="height: 33px; width: 100%; text-align: left;background-image: url(images/Template/other_by_author_bg.jpg);" class="label_thailand_title" align="left" colspan="6">
                &nbsp;
                &nbsp;Customer Information</td>
        </tr>
        <tr>
            <td style="height: 23px; width: 100%;" align="left" colspan="6" 
                class="labeedit_profile_head">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" class="labeedit_profile_detail">
                Title (Eng) :</td>
            <td style="width: 15%; height: 23px;" align="left">
               
                <asp:DropDownList id="cbo_tilte_eng" runat="server" 
                    OnSelectedIndexChanged="cbo_tilte_eng_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
                
            </td>
            <td style="width: 5%; height: 23px;" align="left" class="labeedit_profile_detail">
                &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left" class="labeedit_profile_detail">
                Title (Thai) :</td>
            <td style="width: 52%; height: 23px;" align="left">
               
                <asp:DropDownList id="cbo_tilte_thai" runat="server">
                </asp:DropDownList>
               
            </td>
        </tr>
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            
            <td style="width: 15%; height: 23px;" align="left" class="labeedit_profile_detail">
                Name (Eng) :</td>
            <td style="width: 15%; height: 23px;" align="left">
                    <asp:TextBox id="tbx_name_eng" runat="server"></asp:TextBox>
            </td>
            <td style="width: 5%; height: 23px;" align="left" class="labeedit_profile_detail">
                &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left" class="labeedit_profile_detail">
                Surname (Eng) :</td>
            <td style="width: 52%; height: 23px;" align="left">
                    <asp:TextBox id="tbx_surname_eng" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" class="labeedit_profile_detail">
                Name (Thai) :</td>
            <td style="width: 15%; height: 23px;" align="left">
                    <asp:TextBox id="tbx_name_thai" runat="server"></asp:TextBox>
            </td>
            <td style="width: 5%; height: 23px;" align="left" class="labeedit_profile_detail">
                &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left" class="labeedit_profile_detail">
                Surname (Thai) :</td>
            <td style="width: 52%; height: 23px;" align="left">
                    <asp:TextBox id="tbx_surname_thai" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" class="labeedit_profile_detail">
                Date of Birth (dd/mm/yyyy) :</td>
            <td style="width: 15%; height: 23px;" align="left">
                    <uc2:ucCalendar ID="Uc_date_birth" runat="server" />
            </td>
            <td style="width: 5%; height: 23px;" align="left" class="labeedit_profile_detail">
                &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left" class="labeedit_profile_detail">
                Telephone : </td>
            <td style="width: 52%; height: 23px;" align="left">
                
                    <asp:TextBox id="tbx_tel" runat="server" Width="124px" 
                    Font-Size="11px" Font-Names="Verdana"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" class="labeedit_profile_detail">
                Mobile :</td>
            <td style="width: 15%; height: 23px;" align="left">
                    <asp:TextBox id="tbx_mobile" runat="server"></asp:TextBox>
                                            </td>
            <td style="width: 5%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 52%; height: 23px;" align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" class="labeedit_profile_detail">
                E-mail :</td>
            <td style="height: 23px;" align="left" colspan="4">
                
                    <asp:TextBox id="tbx_email" runat="server" 
                    Width="357px"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td style="height: 23px;" align="left" colspan="6" 
                class="labeedit_profile_detail">
                Please select the channel you prefer to receive new from Asia book. :
                
                    <asp:CheckBox ID="chk_email" runat="server" Text="E-mail" />
                <asp:CheckBox ID="chk_sms" runat="server" Text="SMS" />
                <asp:CheckBox ID="chk_mail" runat="server" Text="Mail" />
                
            </td>
        </tr>
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" class="labeedit_profile_detail">
                ID Card Number :&nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left">
                
                    <asp:TextBox id="tbx_id_number" runat="server" 
                    MaxLength="13"></asp:TextBox>
                
            </td>
            <td style="width: 5%; height: 23px;" align="left" class="labeedit_profile_detail">
                &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left" class="labeedit_profile_detail">
                Nationality :</td>
            <td style="width: 52%; height: 23px;" align="left">
                
                    <asp:DropDownList id="cbo_nationality" runat="server">
                        <asp:ListItem Value="0">----- Select -----</asp:ListItem>
                        <asp:ListItem Value="470041">THAI
                        </asp:ListItem>
                        <asp:ListItem Value="470042">FOREIGN</asp:ListItem>
                </asp:DropDownList>
                
            </td>
        </tr>
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" class="labeedit_profile_detail">
                ID Card Passport :&nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left">
                
                    <asp:TextBox id="tbx_id_passport" runat="server"></asp:TextBox>
                
            </td>
            <td style="width: 5%; height: 23px;" align="left" class="labeedit_profile_detail">
                &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left" class="labeedit_profile_detail">
                No. of children :</td>
            <td style="width: 52%; height: 23px;" align="left">
                
                    <asp:TextBox onblur="ValidInt();" id="tbx_children" 
                    runat="server"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td style="height: 23px;" align="left" colspan="6">
            </td>
        </tr>
        
        <tr>
            <td style="height: 23px;" align="left" colspan="6" 
                class="labeedit_profile_head">
                Current address</td>
        </tr>
        
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                
                    Place Name :</td>
            <td style="width: 15%; height: 23px;" align="left">
                
                    <asp:TextBox ID="tbx_place_name_1" runat="server"></asp:TextBox>
            </td>
            <td style="width: 5%; height: 23px;" align="left" class="labeedit_profile_detail">
                
                    &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left" class="labeedit_profile_detail">
                
                    Room Number :</td>
            <td style="width: 52%; height: 23px;" align="left">
                
                    <asp:TextBox ID="tbx_room_number_1" runat="server"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                
                    Home Number :</td>
            <td style="width: 15%; height: 23px;" align="left">
                
                    <asp:TextBox ID="tbx_place_number_1" runat="server"></asp:TextBox>
            </td>
            <td style="width: 5%; height: 23px;" align="left" class="labeedit_profile_detail">
                
                    &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left" class="labeedit_profile_detail">
                
                    Moo :</td>
            <td style="width: 52%; height: 23px;" align="left">
                
                    <asp:TextBox ID="tbx_moo_1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                        Soi :</td>
            <td style="width: 15%; height: 23px;" align="left">
                        <asp:TextBox ID="tbx_alley_1" runat="server"></asp:TextBox>
                
            </td>
            <td style="width: 5%; height: 23px;" align="left" class="labeedit_profile_detail">
                        &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left" class="labeedit_profile_detail">
                        Road :</td>
            <td style="width: 52%; height: 23px;" align="left">
                        <asp:TextBox ID="tbx_road_1" runat="server" Height="22px"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                
                    Sub District :</td>
            <td style="width: 15%; height: 23px;" align="left">
                
                    <asp:TextBox ID="tbx_district_1" runat="server"></asp:TextBox>
            </td>
            <td style="width: 5%; height: 23px;" align="left" class="labeedit_profile_detail">
                        &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left" class="labeedit_profile_detail">
                        District :</td>
            <td style="width: 52%; height: 23px;" align="left">
                        <asp:TextBox ID="tbx_amphur_1" runat="server"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                
                    Province :</td>
            <td style="width: 15%; height: 23px;" align="left">
            <asp:TextBox id="tbx_province_1" runat="server"></asp:TextBox></td>
            <td style="width: 5%; height: 23px;" align="left" class="labeedit_profile_detail">
                
                    &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" class="labeedit_profile_detail">
                
                    Zipcode :</td>
            <td style="width: 52%; height: 23px;" align="left">
            <asp:TextBox id="tbx_zipcode_1" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                
                    Country :</td>
            <td style="width: 15%; height: 23px;" align="left">
            <asp:TextBox id="tbx_country_1" runat="server"></asp:TextBox></td>
            <td style="width: 5%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 52%; height: 23px;" align="left">
                &nbsp;</td>
        </tr>
       
        <tr>
            <td style="height: 23px;" align="left" colspan="6">
                &nbsp;</td>
        </tr>
       
        <tr>
            <td style="height: 23px;" align="left" class="labeedit_profile_head" 
                colspan="6">
                Office address</td>
        </tr>
       
        <tr>
            <td style="height: 23px;" align="left" colspan="6">
                <asp:CheckBox ID="chk_add2" runat="server" CssClass="labeedit_profile_detail" 
                    Font-Bold="True" Text="Same as above" AutoPostBack="True" />
            </td>
        </tr>
       
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" class="labeedit_profile_detail">
                
                    Place Name :</td>
            <td style="width: 15%; height: 23px;" align="left">
        <asp:TextBox id="tbx_place_name_2" runat="server"></asp:TextBox></td>
            <td style="width: 5%; height: 23px;" align="left" class="labeedit_profile_detail">
                
                    &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left" class="labeedit_profile_detail">
                
                    Room Nunber :</td>
            <td style="width: 52%; height: 23px;" align="left">
                
                    <asp:TextBox ID="tbx_room_number_2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                        Place Number :</td>
            <td style="width: 15%; height: 23px;" align="left">
                        <asp:TextBox ID="tbx_place_number_2" runat="server"></asp:TextBox>
                
            </td>
            <td style="width: 5%; height: 23px;" align="left" class="labeedit_profile_detail">
                        &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left" class="labeedit_profile_detail">
                        Moo :</td>
            <td style="width: 52%; height: 23px;" align="left">
                        <asp:TextBox ID="tbx_moo_2" runat="server"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                
                    Soi :</td>
            <td style="width: 15%; height: 23px;" align="left">
                
                    <asp:TextBox ID="tbx_alley_2" runat="server"></asp:TextBox>
            </td>
            <td style="width: 5%; height: 23px;" align="left" class="labeedit_profile_detail">
                        &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left" class="labeedit_profile_detail">
                        Road :</td>
            <td style="width: 52%; height: 23px;" align="left">
                        <asp:TextBox ID="tbx_road_2" runat="server"></asp:TextBox>
                
            </td>
        </tr>
      
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                
                    Sub District :</td>
            <td style="width: 15%; height: 23px;" align="left">
                
                    <asp:TextBox ID="tbx_district_2" runat="server"></asp:TextBox>
            </td>
            <td style="width: 5%; height: 23px;" align="left" class="labeedit_profile_detail">
                        &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left" class="labeedit_profile_detail">
                        District :</td>
            <td style="width: 52%; height: 23px;" align="left">
                        <asp:TextBox ID="tbx_amphur_2" runat="server"></asp:TextBox>
                
            </td>
        </tr>
      
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                
                    Province :</td>
            <td style="width: 15%; height: 23px;" align="left">
                
            <asp:TextBox id="tbx_province_2" runat="server"></asp:TextBox>
            </td>
            <td style="width: 5%; height: 23px;" align="left" class="labeedit_profile_detail">
                
                    &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left" class="labeedit_profile_detail">
                
                    Zipcode :</td>
            <td style="width: 52%; height: 23px;" align="left">
            <asp:TextBox id="tbx_zipcode_2" runat="server"></asp:TextBox>
                
            </td>
        </tr>
      
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                
                    Country :</td>
            <td style="width: 15%; height: 23px;" align="left">
                
            <asp:TextBox id="tbx_country_2" runat="server"></asp:TextBox>
            </td>
            <td style="width: 5%; height: 23px;" align="left" class="labeedit_profile_detail">
                        &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left" class="labeedit_profile_detail">
                        &nbsp;</td>
            <td style="width: 52%; height: 23px;" align="left">
                        &nbsp;</td>
        </tr>
      
        <tr>
            <td style="height: 23px;" align="left" colspan="6">
            </td>
        </tr>
      
        <tr>
            <td style="height: 23px;" align="left" colspan="6" 
                class="labeedit_profile_head">
                Postage Address to send Asia Books&#39; Reading Time magazine or newsletter
            </td>
        </tr>
        <tr>
            <td style="height: 23px;" align="left" colspan="6" 
                class="labeedit_profile_detail">
                <asp:RadioButton ID="rdoCurrent" runat="server" AutoPostBack="True" 
                    GroupName="Address" Text="Same as current address" Font-Bold="True" />
            </td>
        </tr>
        <tr>
            <td style="height: 23px;" align="left" colspan="6" 
                class="labeedit_profile_detail">
                <asp:RadioButton ID="rdoOffice" runat="server" AutoPostBack="True" 
                    Text="Same as office address" Font-Bold="True" GroupName="Address" />
            </td>
        </tr>
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                        Place Name :</td>
            <td style="width: 15%; height: 23px;" align="left">
                        <asp:TextBox ID="tbx_place_name_3" runat="server"></asp:TextBox>
                
            </td>
            <td style="width: 5%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                        &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                        Room Number :</td>
            <td style="width: 52%; height: 23px;" align="left">
                        <asp:TextBox ID="tbx_room_number_3" runat="server"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                        Place Number :</td>
            <td style="width: 15%; height: 23px;" align="left">
                        <asp:TextBox ID="tbx_place_number_3" runat="server"></asp:TextBox>
                
            </td>
            <td style="width: 5%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                        &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                        Moo :</td>
            <td style="width: 52%; height: 23px;" align="left">
                        <asp:TextBox ID="tbx_moo_3" runat="server"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                
                    Soi :</td>
            <td style="width: 15%; height: 23px;" align="left">
                
                    <asp:TextBox ID="tbx_alley_3" runat="server"></asp:TextBox>
            </td>
            <td style="width: 5%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                        &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                        Road :</td>
            <td style="width: 52%; height: 23px;" align="left">
                        <asp:TextBox ID="tbx_road_3" runat="server"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                
                    Sub District :</td>
            <td style="width: 15%; height: 23px;" align="left">
                
                    <asp:TextBox ID="tbx_district_3" runat="server"></asp:TextBox>
            </td>
            <td style="width: 5%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                        &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                        District :</td>
            <td style="width: 52%; height: 23px;" align="left">
                        <asp:TextBox ID="tbx_amphur_3" runat="server"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                
                    Province :</td>
            <td style="width: 15%; height: 23px;" align="left">
            <asp:TextBox id="tbx_province_3" runat="server"></asp:TextBox></td>
            <td style="width: 5%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                
                    &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                
                    Zipcode :</td>
            <td style="width: 52%; height: 23px;" align="left">
            <asp:TextBox id="tbx_zipcode_3" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left" 
                class="labeedit_profile_detail">
                
                    Country :</td>
            <td style="width: 15%; height: 23px;" align="left">
            <asp:TextBox id="tbx_country_3" runat="server"></asp:TextBox></td>
            <td style="width: 5%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 52%; height: 23px;" align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 3%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 15%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 5%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 10%; height: 23px;" align="left">
                &nbsp;</td>
            <td style="width: 52%; height: 23px;" align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 23px;" align="center" colspan="6">
                    <asp:ImageButton ID="b_add" runat="server" 
                ImageUrl="~/images/b_save.jpg">
            </asp:ImageButton>
            </td>
        </tr>
    </table>
        
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

