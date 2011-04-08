<%@ Page Language="VB" AutoEventWireup="false" CodeFile="video_presentation.aspx.vb" Inherits="video_presentation" %>
<%@ Register Assembly="ASPNetFlashVideo.NET3" Namespace="ASPNetFlashVideo" TagPrefix="ASPNetFlashVideo" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Asiabooks Video Presentation</title>
    <style type="text/css">
        *{
        	margin-top:0px;
        	margin-left:0px;
        	padding-top:0px;
        	padding-left:0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:368px; height:208px; margin:0px;"><ASPNetFlashVideo:FlashVideo ID="FlashVideo1" runat="server" 
        Height="208px" VideoURL="~/video/presentation.flv" Width="368px" AutoPlay="true" 
        StartUpImageURL="~/images/bg_video.jpg" BorderWidth="0px"></ASPNetFlashVideo:FlashVideo>
    </div>
    </form>
</body>
</html>
