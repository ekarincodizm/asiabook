<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Update_Data_WebAsiabooks.aspx.vb" Inherits="Update_Data_WebAsiabooks" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Panel ID="Panel2" runat="server" DefaultButton="btnOK">
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td colspan="2" style="width: 100%; height: 15px;" class="header_other">
            </td>
        </tr>
        <tr>
            <td colspan="2" style="width: 100%" class="header_other">
                
                Update data web asiabooks</td>
        </tr>
        <tr>
            <td style="width: 30%; height: 23px">
            </td>
            <td style="width: 70%; height: 23px">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 30%; height: 27px;" class="font_other">
                User Name :&nbsp;&nbsp;
            </td>
            <td align="left" style="width: 70%; height: 27px;">
                <asp:TextBox ID="txtUserName" runat="server" Width="213px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 30%; height: 27px;" class="font_other">
                Password :&nbsp;&nbsp;
            </td>
            <td align="left" style="width: 70%; height: 27px;">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="213px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 30%; height: 28px;">
                </td>
            <td align="left" style="width: 70%; height: 28px;">
                <asp:ImageButton ID="btnOK" runat="server" 
                    ImageUrl="~/images/b_ok.jpg" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 30%">
                &nbsp;</td>
            <td align="left" style="width: 70%">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" colspan="2">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td height="1" class="bg_dot_line"></td>
  </tr>
</table>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 30%">
                &nbsp;</td>
            <td align="left" style="width: 70%">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
            </td>
        </tr>
    </table>
</asp:Panel>

    
<table cellpadding="0" cellspacing="0" style="width: 100%">
         <tr>
             <td style="width: 100%" align="center">
             <asp:Panel ID="Panel1" runat="server" Visible="False" DefaultButton="btnSave">
                <fieldset style="width: 60%"><legend class="labeedit_profile_head">Update data web asiabooks</legend>
                <table cellpadding="0" cellspacing="0" style="width: 100%" align="center">
                    <tr>
                        <td align="right" style="width: 30%" class="font_other">
                            &nbsp;</td>
                        <td align="left" style="width: 70%">
                            &nbsp;</td>
                    </tr>
                     <tr>
                         <td align="right" class="font_other" style="width: 30%">
                             Upload File :&nbsp;
                         </td>
                         <td align="left" style="width: 70%">
                             <asp:FileUpload ID="fuText1" runat="server" style="margin-left: 0px" 
                                 Width="362px" />
                         </td>
                    </tr>
                     <tr>
                        <td align="right" style="width: 30%; height: 18px">
                        </td>
                        <td align="left" style="width: 70%; height: 18px">
                        </td>
                    </tr>
                    <tr>
                    <td align="right" style="width: 30%">
                    </td>
                    <td align="left" style="width: 70%">
                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/b_save.jpg" /></td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 30%">
                            &nbsp;</td>
                        <td align="left" style="width: 70%">
                            &nbsp;</td>
                    </tr>
                </table></fieldset>
                </asp:Panel>
             </td>
         </tr>
    </table>
    
     
</asp:Content>

