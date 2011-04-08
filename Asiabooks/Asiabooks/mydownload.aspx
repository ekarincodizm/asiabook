<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head id="Head1"><title>
	ClearingHouse
</title>
        <script type="text/javascript" language="javascript" src="Javascript/MSReaderWebShop.js"></script>
        <script type="text/javascript" language="Javascript" src="Javascript/browsercheck.js"></script>
        <script type="text/javascript" language="Javascript" src="Javascript/ADEBadgeLauncher.js"></script>
        
        <script type="text/javascript" language="javascript">    
        
        var isAdeInstalledLocally = 1; //0 - no ADE, 1 - ADE available locally
                
        function ShowADE_DivLayer()
        {
            if(G_nADEInstalled != 1)
            {
                isAdeInstalledLocally = 0;
                var adeComDiv = document.getElementById("AdeCommentDiv");                        
                adeComDiv.innerHTML = 'If you do not have Adobe Digital Editions installed or have an earlier version installed, you will need to install the latest version before you can actually start reading your eBook.<br /><br />'
                //document.write("No ADE");
            }
            else
            {
                isAdeInstalledLocally = 1;
                //document.write("ADE EXISTS");
            }
            return;
        }

        function ShowSWFVersion_DivLayer()
        {
            return;
        }

        function ADE_SWF_ButtonPush_action()
        {
            return;
        }
        
        function doOnLoad()
        {
            var formatCode = 6;
            if(formatCode == 6 || formatCode == 2)
            {          
                document.getElementById('btnDownload').style.visibility = "hidden";
                
                if(isSWFSupported())
                {
                    var HTMLdivID = "AdeInstallerDiv"; 
                    var HTMLobjectID = "ADEBadgeLauncherInstance1";
                    var contentURL = "http://203.170.160.60";
                    var autoInstall = false; 
                    var autoLaunch = false;
                    var badFlashRedirectURL	= null;

                    var doFulfillmentLink = true;
                    var sendADEInstalled = true;
                    var sendSWFVersion = false;
                    var sendButtonPush = false;	

                    var escapedContentURL = escape(contentURL);                    
                    ADEBadgeLauncherInstance(HTMLdivID, HTMLobjectID, escapedContentURL, doFulfillmentLink, autoInstall, autoLaunch, badFlashRedirectURL, sendADEInstalled, sendSWFVersion, sendButtonPush);                    
                }
                else
                {                
                    var flashDiv = document.getElementById("FlashInstallerDiv");
                    flashDiv.innerHTML = 'Please install Adobe Flash Player before proceeding<br/><br/>' + 
                    '<a href="http://www.adobe.com/go/getflashplayer" target="_blank">Get Adobe Flash Player</a>';                    
                }                                
            }
        }        
        
        function isSWFSupported()
        {
            var requiredVersion = 8;
            if(navigator.plugins.length)
            {
                var i;
                for (i=0; i < navigator.plugins.length; i++) 
                { 
                    var pluginIdent = navigator.plugins[i].description.split(" "); 
                    if(pluginIdent[0] == "Shockwave" && pluginIdent[1] == "Flash") 
                    { 
                        //The Flash Player identification string is ([] = the array index) [0]Shockwave [1]Flash [2]6.0 [3]r21 
                        var versionArray = pluginIdent[2].split("."); 
                    
                        if(versionArray[0] >= requiredVersion) 
                        { 
                            return true;
                        }     
                    }            
                }
            }
            else if(navigator.appVersion.indexOf("Mac")==-1 && window.execScript)
            {
                var flashPlayerFound = true;
                var obj = -1;
                try
                {
		        obj = new ActiveXObject("ShockwaveFlash.ShockwaveFlash");
		        }
		        catch(err)
		        {
		            flashPlayerFound = false;
		        }
		        if(flashPlayerFound)
		        {
                    var currentVersion = obj.GetVariable("$version");
                    var versionArray = currentVersion.split(",");
                    if(parseInt(versionArray[0].split(" ")[1], 10) >= requiredVersion)
                    {
                        return true;
                    }
                }
            }
            return false;                
        }
        
        function fnSubmit(frm)
        {
            frm.btnDownload.disabled = true;
            frm.action = "http://gdw.ebookshipping.com/ContentWarehouse/Default.aspx";
            frm.submit();  
        }
        function setCertificateValue()
        {
            document.frmFulfillment.certificate.value=MSReaderWebShop_GetMSReaderActivationCertificate();
            document.frmFulfillment.passport.value = MSReaderWebShop_GetMSReaderActivationID();            
        }
        function validateandsubmit(frm)
        {
            var message="";
            if(frm.txtRegPid.value == "")
            {
                alert("Please enter your Personal ID (PID) to register.");
                return false;
            }
            else if(frm.pid.length >  0) {
                var i;
                for(i=0; i < frm.pid.length; i++)
                {  
                    if(frm.txtRegPid.value == frm.pid[i].value)
                    {
                        alert("The entered PID is already registered!! Provide a different PID");
                        return false;
                    }
                }
            }
            else
            {
                if(window.confirm("Please ensure that you have keyed in the your correct PID , failing which you will be unable to read your book on your device. For further details, visit our Help Centre."))
                {    
                    return true;
                }
                else 
                {
                    return false;
                }                    
            }
     }
    </script>
    <link href="css/style.css" rel="stylesheet" type="text/css" /></head>
    <body id="bodyTag" MarginHeight="0" MarginWidth="0" TopMargin="0" LeftMargin="0" RightMargin="0" BottomMargin="0">    
    <form name="frmFulfillment" method="post" action="Fulfillment.aspx?downloadToken=e9Op67j1PUVTEmg%2bTyXtR%2bSISUauqrqBP9U3rd5qJ6ffyfIDaKkgGoWJaHzykVmhM2o69CfmaXTKG2gcbc2XL%2bsFiG3HqwzZ7ayprq2tPpcG8JDl9kGHWiRi4EfehCAW2%2bYfSGTi2Mo46T7nZ351x0qFVVjSTzj3%2flumJRggmuFbxC3c07ndj%2f3MxqDr%2fEhtLpVEAy0iCiUK8737I6BT%2bSqMbC8vRdk1RhPMfvlbhpDrZhUKLinzC5nTSF7QkN9b&amp;scrres=set&amp;scrwidth=1280&amp;scrheight=800&amp;scrcolordepth=32" id="frmFulfillment">
<div>
<input type="hidden" name="__EVENTTARGET" id="__EVENTTARGET" value="" />
<input type="hidden" name="__EVENTARGUMENT" id="__EVENTARGUMENT" value="" />
<input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="/wEPDwUIOTY0MzAzNzIPZBYCAgMPZBYCZg9kFgICAQ9kFggCBQ8PFgIeBFRleHQFBjExNzUzNGRkAgsPFgIeB1Zpc2libGVnZAIRD2QWAgIDDxBkZBYAZAITDw8WAh8BZ2RkZA==" />
</div>

<script type="text/javascript">
//<![CDATA[
var theForm = document.forms['frmFulfillment'];
if (!theForm) {
    theForm = document.frmFulfillment;
}
function __doPostBack(eventTarget, eventArgument) {
    if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
        theForm.__EVENTTARGET.value = eventTarget;
        theForm.__EVENTARGUMENT.value = eventArgument;
        theForm.submit();
    }
}
//]]>
</script>


<div>

	<input type="hidden" name="__EVENTVALIDATION" id="__EVENTVALIDATION" value="/wEWBQKcvYvUBAKFr++0BQL1vaDECgKKifW1DQL0tsu2BQ==" />
</div>	
    <table style="background-color:White" align="center" cellpadding="0" cellspacing="0" >
    <tr>    
    <td id="mainSection">
    
        <input type="hidden" name="hdndownloadToken" id="hdndownloadToken" value="7lvX0yZT+fVxmA/DAOAZ3g6ihyN02rGUAYQDFv0PckfUC7iTfy88mnYU3QMr/6MRPTFAyrwXDoPVInIfghA9q3RsnourgDe8/cVmVWLi7bJCiWv8j96OsbgwuocYBzdbD8xC+xT55VbFETxBPkVXAhEDnYCTxDl47eHdROTdOsE6hXp8wT55aVbBBkYgo7b22hJpX3dlr/Az5BqMJUMc39cul08zd8sLyvoDC/sXVGHLO89PX7iHMpYie0EdrCIbT5cnFAqDx/2pRg064C9jLCj2sc5uZPZF6JWrUCSyoRFlxrWNe4V5+sd0H7NspDTBwktZXcBaOc4VwnQMvVtO4XOiWp+eDihpnBL+YPixeAfaPi6LjTfbFaJ8oXCvzN9jbjulYkIueuQ7zYKZtbrQ9dH94cVlCBXMWxTKSAY8UPYp4Lwi5atpcL5MvkTs8jWmMnJtItrms0K+B89JHWgV3bFeSmcRG5uv4avtgxCopgSqpD3WBwDpUBaj/u3HqTMwSj2i0BldauA1mE5u25+Abu5CPkM0dVH2wJCW9PteF7B5jWY/JzE52snFW+KGEhOjdqSpleT5qs2nidh7sUKwdyLr1055xpV7zd/Cow2bawx5SInFsSTnAz0yJqp8D4KRz0J0TWIMv9kfbmTMl9PfKX4XKX6nMZ1l+1UcOXbHDoU7ws6j7H/OcZRhJD0G03bLQxVwo5d4Cp8kCvFW0lpnRVRapJNDCgSwn4NfCZFsjFMyXCOo3q9oCzxQnJM2hEjfl5t1WHCIqcn2D5bGTWDZth6PvyMHE2kkReiKo4uVt2Vluztpof++7N/WkyLqvxuOwe0Po2SDGxysdwi18oi+eZfAa8J5VBxKBk4VfGomytIyv+3YaimiaSt/kIsXHQ6YfpTcll2rGVIbqoXCiCPuYw==" />   
        
        <input type="hidden" name="passport" id="passport" />
        <input type="hidden" name="certificate" id="certificate" />
	
            <div id="divAdobe">
				<br />
				<br />
				<table width="590" border="0" cellpadding="0" cellspacing="0" align="center" style="border-collapse:collapse">
					<tr><td>
						<table width="100%" cellpadding="0" cellspacing="0" border="0">
						<tbody>
							<tr>
								<td align="center" style="height:28px"><p class="paracat"><b> Adobe eBook Reader Wizard</b></p></td>
							</tr>
						</tbody>
						</table>
						</td></tr>
                        <tr>
							<td colspan="2">
								<table width="590" border="0" cellpadding="0" cellspacing="0">
								<tbody>                                   
									<tr>
										<td align="center">	
										<br />	 									
										    <div id="AdeCommentDiv" style="font-family:Arial; font-size:smaller;"></div>
											<div id="AdeInstallerDiv"></div>
											<div id="FlashInstallerDiv" style="font-family:Arial; font-size:smaller;"></div>											
										</td>
									</tr>									
									<tr><td colspan="2">&nbsp;</td></tr>									
								</tbody>
								</table>
							</td>
						</tr>
                </table>
            </div>
            
            
            



            




        
                                

             <table align="center">
                <tr>
                    <td align="center" style="height:28px">
                        <input type="button" name="btnDownload" value="Proceed to Download Your eBook" onclick="return fnSubmit(this.form);__doPostBack('btnDownload','')" id="btnDownload" class="formBtn" />
                    </td>
                </tr>
             </table>  
             <br /><br />
       
        
    </td>
    
    </tr>
    </table>
    </form>
    <script type="text/javascript">
        setCertificateValue();
        var checkADE = "True";
        
        if(checkADE == 'True')
        {   
            doOnLoad();
        }
        
    </script>
 </body> 
</html>