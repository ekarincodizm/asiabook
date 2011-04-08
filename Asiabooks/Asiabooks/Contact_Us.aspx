<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="Contact_Us.aspx.vb" Inherits="Contact_Us" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" style="width: 100%">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Template/contact_us.jpg" /></td>
        </tr>
        <tr>
            <td align="left" style="width: 100%; height: 10px">
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 100%; height: 10px">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top" style="width: 9px; height: 7px"><asp:Image ID="Image16" runat="server" ImageUrl="~/images/Template/cart_head_start.jpg" Border="0" /></td>
                        <td valign="top" style="height: 7px; background-image: url('images/Template/cart_head_bg.jpg')"></td>
                        <td valign="top" style="width: 10px; height: 7px"><asp:Image ID="Image17" runat="server" ImageUrl="~/images/Template/cart_head_end.jpg" Border="0"  /></td>
                    </tr>
                    <tr>
                        <td valign="top" style="background-image: url('images/Template/cart_left_bg.jpg'); width: 9px"></td>
                        <td align="center" valign="top">
                        <table cellpadding="0" cellspacing="0" style="width: 90%">
                            <tr>
                                <td align="right" class="font_other" style="width: 200px; height: 17px;">
                                </td>
                                <td align="left" style="height: 17px">
                                </td>
                                <td align="left" style="height: 17px; width: 100px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="header_other" style="height: 17px;" colspan="3">
                                    Customer Information</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px; height: 17px;">
                                    &nbsp;</td>
                                <td align="left" style="height: 17px">
                                    <asp:Label ID="lblMeassge" runat="server" Visible="False"></asp:Label>
                                                                  </td>
                                <td align="left" style="height: 17px; width: 100px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px; height: 27px;">
                                    Name <span style="color: #FF0000">** </span>:&nbsp;&nbsp;
                                </td>
                                <td align="left" style="height: 27px">
                                    <asp:TextBox ID="txtCus_Name" runat="server" Width="230px"></asp:TextBox>
                                </td>
                                <td align="left" style="height: 27px; width: 100px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px" valign="top">
                                    Email <span style="color: #FF0000">**</span> :&nbsp;&nbsp;
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCus_Email" runat="server" TextMode="MultiLine" 
                                        Width="230px"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 100px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 200px">
                                    &nbsp;</td>
                                <td align="left">
                                    (More than 1 email use ;&nbsp; )</td>
                                <td align="left" style="width: 100px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 200px">
                                    &nbsp;</td>
                                <td align="left">
                                    ex <a href="mailto:a@asiabooks.com">a@asiabooks.com</a> ;
                                    <a href="mailto:b@asiabooks.com">b@asiabooks.com</a></td>
                                <td align="left" style="width: 100px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px; height: 27px;">
                                    Mobile / Telephone<span style="color: #FF0000"> **</span> :&nbsp;&nbsp;
                                </td>
                                <td align="left" style="height: 27px">
                                    <asp:TextBox ID="txtCus_Tel" runat="server" Width="230px"></asp:TextBox>
                                </td>
                                <td align="left" style="height: 27px; width: 100px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 200px">
                                    Issue :&nbsp;&nbsp;&nbsp; </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlIssue" runat="server" Width="228px">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" style="width: 100px">
                                    &nbsp;&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 200px">
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left" style="width: 100px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px; height: 27px;">
                                    Subject <span style="color: #FF0000">**</span> :&nbsp;&nbsp;
                                </td>
                                <td align="left" style="height: 27px">
                                    <asp:TextBox ID="txtCus_Subject" runat="server" Width="230px"></asp:TextBox>
                                </td>
                                <td align="left" style="height: 27px; width: 100px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px" valign="top">
                                    Detail <span style="color: #FF0000">** </span>: &nbsp;
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDetail" runat="server" Height="103px" TextMode="MultiLine" 
                                        Width="230px"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 100px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px; height: 17px;" 
                                    valign="top">
                                </td>
                                <td align="left" style="height: 17px">
                                </td>
                                <td align="left" style="height: 17px; width: 100px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="font_other" style="width: 200px; height: 17px;" 
                                    valign="top">
                                    &nbsp;</td>
                                <td align="left" style="height: 17px">
                                    <asp:Button ID="btnSave" runat="server" Text="Submit" Width="64px" />
                                </td>
                                <td align="left" style="height: 17px; width: 100px;">
                                    &nbsp;</td>
                            </tr>
                        </table></td>
                        <td valign="top" style="background-image: url('images/Template/cart_right_bg.jpg'); width: 10px;"></td>
                    </tr>
                    <tr>
                        <td valign="top" style="width: 9px; height: 10px"><asp:Image ID="Image18" runat="server" ImageUrl="~/images/Template/cart_footer_start.jpg" Border="0" /></td>
                        <td valign="top" style="height: 10px; background-image: url('images/Template/cart_footer_bg.jpg')"></td>
                        <td valign="top" style="width: 10px; height: 10px"><asp:Image ID="Image19" runat="server" ImageUrl="~/images/Template/cart_footer_end.jpg" Border="0" /></td>
                    </tr>
               </table></td>
        </tr>
        <tr>
            <td align="left" style="width: 100%; height: 10px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100%; height: 19px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td align="center" style="width: 20px" valign="top">
                         <a href="mailto:ecommerce@asiabooks.com">   
                         <asp:Image ID="Image29" runat="server" 
                                ImageUrl="~/images/e-commerce.gif" /></a></td>
                        <td align="left" class="font_other" valign="top">
                            &nbsp;&nbsp;
                        </td>
                        <td class="font_other" align="left" valign="top">
                            <strong><span style="font-size: 10pt">
                            <span style="color: #0066FF">e-Commerce Customer Service 
                                </span> 
                                <br />
                            </span></strong>
ASIA BOOKS CO., LTD 65/66, 65/70 7th Floor, 
  Chamnan Phenjati Business Center, Rama 9 Road, 
Huaykwang  Bangkok 10320 Thailand
(Monday-Friday 8.30 am.- 5.30 pm.)
                            <br />
                            <b>E-Mail:</b> <a href="mailto:ecommerce@asiabooks.com"> ecommerce@asiabooks.com</a>
                            <br />
                            <b>Tel: </b>(662) 715-9000 ext. 8102, 8103 Fax: (662) 715-9197

                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 26px">
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 10px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td align="center" style="width: 20px" valign="top">
                            <a href="mailto:information@asiabooks.com">   
                         <asp:Image ID="Image2" runat="server" ImageUrl="~/images/information.gif" /></a></td>
                        <td align="left" class="font_other" valign="top">
                            &nbsp;&nbsp;
                        </td>
                        <td class="font_other" align="left" valign="top">
                            <strong><span style="font-size: 10pt">
                            <span style="color: #0066FF">Asia Books Customer Service 
                                </span> 
                                <br />
                            </span></strong>
221 Sukhumvit Road (between soi 15-17) Klongtoey Nua, Wattana, Bangkok 10110 Thailand (Monday-Friday 9.00 am.- 6.00 pm.) 
<br /><b>E-Mail:</b> <a href="mailto:information@asiabooks.com">information@asiabooks.com</a>
                            <br />
                            <b>Tel :</b>( 662) 651-0429-30 Fax: (662) 2251-6042
                            <br /><br /><span style="color: #FF0000">***</span>&nbsp;&nbsp; -&nbsp; Searching Books
                            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;General Information                             
                            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; -&nbsp; Others Comment<br /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 10px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100%;">
            <asp:UpdatePanel ID="Update_panelMore_Service" runat="server"><ContentTemplate>
            <table style="width:100%">
                <tr style="color: #000000">
            <td class="font_other" align="left" valign="top">
               <strong>
               <asp:ImageButton ID="btnMore_Service" runat="server" 
                   ImageUrl="~/images/more_service.gif" />
               </strong>
               <asp:Label ID="lblmore_service" runat="server" Visible="False"></asp:Label>
               <br />

We are delighted to be of service to our valuable customer like you. For your convenience, we offer you the following services:

            </td>
        </tr>
                <tr>
                    <td align="left" class="font_other" valign="top" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td align="left" class="font_other" valign="top" style="height: 10px">
                    
                    <asp:Panel ID="panelMore_Service" runat="server" Visible="false">
                        <table style="width:100%">
                            <tr>
                                <td class="font_other" align="left" valign="top" style="height: 286px">
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/Template/academics_library.jpg" /><br />
                                    <br />
                                    <strong><span style="color: #006633">Asia Books</span></strong> serves academics and librarians around the world. Professional books and reference books are available in various subjects :
                                    <br />
                                    <br />
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 20px">
                                            </td>
                                            <td>
                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/images/Asiabooks/bullet_g.gif"/>
                                                Architecture, Design & Decoration<br />
                       <asp:Image ID="Image5" runat="server" ImageUrl="~/images/Asiabooks/bullet_g.gif"/>
                                                Business & Management<br />
                       <asp:Image ID="Image6" runat="server" ImageUrl="~/images/Asiabooks/bullet_g.gif"/>
                                                Children's Books<br />
                       <asp:Image ID="Image7" runat="server" ImageUrl="~/images/Asiabooks/bullet_g.gif"/>
                                                Graphic Arts & Advertising<br />
                       <asp:Image ID="Image8" runat="server" ImageUrl="~/images/Asiabooks/bullet_g.gif"/>
                                                Oriental and Western Arts<br />
                       <asp:Image ID="Image9" runat="server" ImageUrl="~/images/Asiabooks/bullet_g.gif"/>
                                                Thailand & Southeast Asia<br />
                       <asp:Image ID="Image10" runat="server" ImageUrl="~/images/Asiabooks/bullet_g.gif"/>
                                                and much more…. 
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="width: 100%">
                                                <br />
                                                Special orders for books from worldwide can be placed with Asia Books. To process special order with us, we need the following details: 
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20px">
                                            </td>
                                            <td>
                                                <br />  <asp:Image ID="Image11" runat="server" ImageUrl="~/images/Asiabooks/bullet_g.gif"/> Exact title
                                                <br />
                                                <asp:Image ID="Image12" runat="server" ImageUrl="~/images/Asiabooks/bullet_g.gif"/>
                                                ISBN number 

                                            </td>
                                        </tr>
                                    </table>

                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="font_other" valign="top">
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 50%; background-color: aliceblue">
                                        <tr>
                                            <td align="left" style="width: 2%; height: 10px">
                                            </td>
                                            <td align="left" style="width: 50%; height: 10px">
                                            </td>
                                            <td align="left" style="width: 2%; height: 10px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 2%">
                                            </td>
                                            <td align="left" style="width: 50%">
                                                <strong>For additional information, please contact: 
                                                    <br />
                                                    <br />
                                                    <span style="color: #006600">Ms. Sauvaluck Tongpakdee
                                                        <br />
                                                        Sales Department Manager
                                                        <br />
                                                    </span></strong>Asia Books Co., Ltd. (Head Office) 65/66, 65/70 Chamnan Phenjati
                                                Business Center 7th Floor, Rama 9 Road, Huaykwang, Bangkok 10320
                                                <br />
                                                Tel. : (662) 789-5444 Ext.37 Mobile Phone : 085-980-5518
                                                <br />
                                                E-Mail: <a href="mailto:Sauvaluck_T@asiabooks.com" style="color: #3333FF">Sauvaluck_T@asiabooks.com</a>
                                            </td>
                                            <td align="left" style="width: 2%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 2%; height: 10px">
                                            </td>
                                            <td align="left" style="width: 50%; height: 10px">
                                            </td>
                                            <td align="left" style="width: 2%; height: 10px">
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="font_other" valign="top">
                                    <asp:Image ID="Image13" runat="server" ImageUrl="~/images/Template/books_sellers.jpg" /><br />
                                    We are pleased to inform booksellers that <strong><span style="color: #006600">Asia
                                        Books Co., Ltd.</span></strong> stocks a wide range of titles, including books on Thailand & Southeast Asia as well as international bestsellers.
                                    <br />
                                    <br />

                    Special discount could be offered for bulk quantity purchases.
                                    <br />
                                    <br />

                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="font_other" valign="top">
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 50%; background-color: aliceblue">
                                        <tr>
                                            <td align="left" style="width: 2%; height: 10px">
                                            </td>
                                            <td align="left" style="width: 50%; height: 10px">
                                            </td>
                                            <td align="left" style="width: 2%; height: 10px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 2%">
                                            </td>
                                            <td align="left" style="width: 50%">
                                                <strong>For additional information on conditions, payment, special deals and others,
                                                    please contact :
                                                    <br />
                                                    <br />
                                                    <span style="color: #006600">Ms. Sauvaluck Tongpakdee
                                                        <br />
                                                        Sales Department Manager
                                                        <br />
                                                    </span></strong>Asia Books Co., Ltd. (Head Office) 65/66, 65/70 Chamnan Phenjati
                                                Business Center 7th Floor, Rama 9 Road, Huaykwang, Bangkok 10320
                                                <br />
                                                Tel. : (662) 789-5444 Ext.37 Mobile Phone : 085-980-5518
                                                <br />
                                                E-Mail: <a href="mailto:Sauvaluck_T@asiabooks.com" style="color: #3333FF">Sauvaluck_T@asiabooks.com</a>
                                            </td>
                                            <td align="left" style="width: 2%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 2%; height: 10px">
                                            </td>
                                            <td align="left" style="width: 50%; height: 10px">
                                            </td>
                                            <td align="left" style="width: 2%; height: 10px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="font_other" valign="top">
                                    <asp:Image ID="Image14" runat="server" ImageUrl="~/images/Template/publisher.jpg" /><br />
                                    <strong><span style="color: #006600">
                                        <br />
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        Asia Books Co., Ltd. </span></strong>was founded in 1969 and is the first and the largest English language bookstore chain and distributor in Thailand, offering   varieties of books and magazines.
                                    <br />
                                    <br />
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;

                    Our Retail chain of more than 70 shops under Asia Books and Bookazine brand’s target customers include English-speaking Thais, expatriates and tourists.
                                    <br />
                                    <br />
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;

                    Our distribution network covers over 300 outlets in Thailand. The distribution channels including trade sales to other booksellers, library sales to over 400 libraries and Educational Institutions, direct sales, book exhibitions and other promotional activities, make us the agent of choice for export interest publishers.
                                    <br />
                                    <br />
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;

                    Currently, we represent over 100 leading publishers from worldwide. Asia Books also co-published a large numbers of books on Thailand and SE Asian related.
                                    <br />
                                    <br />

                    If your company is looking for a co-publisher or distributor in Thailand, Asia Books is your answer.
                                    <br />
                                    <br />

                    We have a proven history of sales success. Contact us soon to make your Asian expansion as secure as it will be rewarding.

                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="font_other" valign="top">
                                    <br />
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 50%; background-color: aliceblue">
                                        <tr>
                                            <td align="left" style="width: 2%; height: 10px">
                                            </td>
                                            <td align="left" style="width: 50%; height: 10px">
                                            </td>
                                            <td align="left" style="width: 2%; height: 10px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 2%">
                                            </td>
                                            <td align="left" style="width: 50%">
                                                <strong>Please contact: 
                                                    <br />
                                                    <br />
                                                    <span style="color: #006600">Ms. Charinee Piwong, Book Buying Department Manager, at 
                                                        <br />
                                                    </span></strong>E-Mail: <a href="mailto:Charinee_p@asiabooks.com" style="color: #3333FF">Charinee_p@asiabooks.com</a>
                                                <br />
                                            </td>
                                            <td align="left" style="width: 2%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 2%; height: 10px">
                                            </td>
                                            <td align="left" style="width: 50%; height: 10px">
                                            </td>
                                            <td align="left" style="width: 2%; height: 10px">
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="font_other" valign="top">
                                    

                                </td>
                            </tr>           
                            <tr>
                                <td align="left" class="font_other" valign="top">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" class="font_other" valign="top">
                                    <asp:Image ID="Image15" runat="server" 
                                        ImageUrl="~/images/Template/career_opp.jpg" />
                                    <br />
                                    <br />
                                    <strong>JOIN THE ASIA BOOKS FAMILY
                                    <br />
                                    </strong>
                                    <br />
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <strong><span style="color: #006600">Asia Books Co., Ltd.</span></strong> 
                                    was founded in 1969 and is the first and the largest English language bookstore 
                                    chain and distributor in Thailand, offering varieties of books and magazines.
                                    <br />
                                    <br />
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Our Retail chain of more than 70 shops under Asia Books and Bookazine 
                                    brand’s target customers include English-speaking Thais, expatriates and 
                                    tourists.
                                    <br />
                                    <br />
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Our distribution network covers over 300 outlets in Thailand. The 
                                    distribution channels including trade sales to other booksellers, library sales 
                                    to over 400 libraries and Educational Institutions, direct sales, and book 
                                    exhibitions.
                                    <br />
                                    <br />
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; As service excellence is key success factor of our business, and this 
                                    must be delivered by qualified and service-minded personals. Therefore, at Asia 
                                    Books, staffs will enjoy comprehensive training courses and will be offered 
                                    challenging career opportunities, attractive remuneration package, career 
                                    development, and work under pleasant corporative culture. We proudly invite you 
                                    to be a part of Asia Books team in the following positions.
                                </td>
                            </tr>
                        </table></asp:Panel>
                    </td>
                </tr>
            </table></ContentTemplate></asp:UpdatePanel></td>
        </tr>
        <tr>
            <td align="left" class="font_other" valign="top">
            
            </td>
        </tr>
    </table>
 <asp:Panel ID="panCheckMeassge" runat="server" HorizontalAlign="Center" style="display:none">
      <table border="0" cellpadding="0" cellspacing="0" style="width: 450px; background-color:White;">
           <tr>
               <td valign="top" style="width: 9px; height: 7px"><asp:Image ID="Image25" runat="server" ImageUrl="~/images/Template/cart_head_start.jpg" Border="0" /></td>
               <td valign="top" style="height: 7px; background-image: url('images/Template/cart_head_bg.jpg')"></td>
               <td valign="top" style="width: 10px; height: 7px"><asp:Image ID="Image26" runat="server" ImageUrl="~/images/Template/cart_head_end.jpg" Border="0"  /></td>
           </tr>
           <tr>
               <td valign="top" style="background-image: url('images/Template/cart_left_bg.jpg'); width: 9px"></td>
               <td align="center" valign="top" >
               <table cellpadding="0" cellspacing="0" style="width: 90%">
                        <tr>
                            <td align="right" style="height: 25px"></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="font_about_us" align="center">
                                Thank you for you message.</td>
                        </tr>
                        <tr>
                            <td class="font_other" style="height: 19px"></td>
                        </tr>
                        <tr>
                            <td class="font_other" align="center">
                                <asp:ImageButton ID="img_Msg_OK" runat="server" 
                                    ImageUrl="~/images/b_ok.jpg" />
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="font_other"></td>
                        </tr>
                        <tr>
                            <td class="font_other" style="height: 25px"></td>
                        </tr>
                    </table>
               </td>
               <td valign="top" style="background-image: url('images/Template/cart_right_bg.jpg'); width: 10px;"></td>
           </tr>
           <tr>
               <td valign="top" style="width: 9px; height: 10px"><asp:Image ID="Image27" runat="server" ImageUrl="~/images/Template/cart_footer_start.jpg" Border="0" /></td>
               <td valign="top" style="height: 10px; background-image: url('images/Template/cart_footer_bg.jpg')"></td>
               <td valign="top" style="width: 10px; height: 10px"><asp:Image ID="Image28" runat="server" ImageUrl="~/images/Template/cart_footer_end.jpg" Border="0" /></td>
           </tr>
      </table>
 </asp:Panel>
 <asp:ModalPopupExtender ID="mdlPopUp_Meassge" 
        TargetControlID="linkSave" PopupControlID="panCheckMeassge"
  runat="server" BackgroundCssClass="ModelBackground" >
</asp:ModalPopupExtender>
<asp:LinkButton ID="linkSave" runat="server" style="display:none">LinkButton</asp:LinkButton>

</asp:Content>

