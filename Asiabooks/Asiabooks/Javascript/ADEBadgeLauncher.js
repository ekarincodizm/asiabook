/*************************************************************
 *
 * ADOBE SYSTEMS INCORPORATED
 * Copyright 2006-2009 Adobe Systems Incorporated
 * All Rights Reserved
 *
 * NOTICE: Adobe permits you to use, modify, and distribute
 * this file in accordance with the terms of the Adobe license
 * agreement accompanying it. If you have received this file
 * from a source other than Adobe, then your use, modification,
 * or distribution of it requires the prior written permission
 * of Adobe.
 *
 *************************************************************/
 
// ********************
//	ADEBadgeLauncher.js
//
//  This is the single file that provides the support to host the ade_web_library.swf
//  Installer/Launcher SWF for Adobe Digital Editions.  The master documentation for the 
//  SWF parameters are included below. 
//  This script is referenced on HTML pages that need to host instance of the SWF and 
//  contains the helper JS functions to instantiate the SWF object on the HTML page. 
//  This script also hosts the callback JS functions that may be used depending on the
//  parameters that are sent into the SWF. Typically the JS callbacks then call 
//  Stub functions that must be enabled in your implementation to support the operation.
//
//  NOTE: This code and the sample code should be used from a web browser for
//  true test of the environment.  Opening the sample HTML files directly from the
//  file system may produce un-desirable results due to the flash security model
//  To ensure good test results, place the sample code all in a single folder then expose
//  that folder as a virtual directory from your favorite web server.
// ********************

//-----------------------------------------------------------------------------
//  Maintenance Log:
//  
//  01/16/2009	FlashVars documentation update for locale (io_locale)
//  10/20/2008	FlashVars documentation update for ADEVersion.
//				ADEVersion CAN NOT be "1" or "2" anymore
//  04/17/2008	Major update to SWF for look & feel. FlashVars documentation update.
//				ADEVersion CAN NOT be "1" anymore
//				the (3) buttonLabel params were removed
//				buttonLabelNotRequirements, buttonLabelNot, buttonLabelInst
//				ALSO badgeImagePath is removed
//				Make the reference to the swf in variable "swfPath" to make it more obvious to alter the path
//				
//				These functions were re-defined to DROP the (3) buttonLabel params:
//				ADEBadgeLauncherInstance()
//				SetADEBadgeLauncherDefaults()
//				ADEBadgeInstallerInstance()
//				SetADEBadgeInstallerDefaults()
//
//  04/03/2008	SWF update for localization and FlashVars update to detail that all (3)
//				buttonLabel FlashVars parameters must be used to override internal strings
//				Add description of default localized button text
//				ADEVersion moved to "2" by default now (ADE 1.5)
//  04/01/2008	1.3	Move fix_gblink_plus_characters into ADEBadgeLauncher.js (here), commenting update
//				update documentation for io_contentURL, io_doFulfillmentLink
//	02/01/2008  set hc_contentURL = "";	for the ADEBadgeInstallerInstance method
//  01/23/2008	Documentation for (4) new SWF parameters:
//				"locale", "ADEVersion", "sendSWFVersion", "sendButtonPush"
//				update everywhere to use locale, ADEVersion, sendSWFVersion, sendButtonPush
//				New Callbacks setG_strSWFVersion(), send_ADE_SWF_ButtonPush()
//				Stub EXAMPLES stubs ShowSWFVersion_DivLayer(), ADE_SWF_ButtonPush_action()
//				New Helper API for Badge Installer mode of operation:
//				ADEBadgeInstallerInstance(), ADEBadgeInstallerInstanceWithDefs(), SetADEBadgeInstallerDefaults()
//
//-----------------------------------------------------------------------------

// ********************
// Global script variables that can be used to simplify the call convention for the Launcher
// If every instance uses these same basic settings, then a single could be made to
// SetADEBadgeLauncherDefaults, and then separate calls to ADEBadgeLauncherInstanceWithDefs
//
// For Installer mode, make single call to 
// SetADEBadgeInstallerDefaults, and then separate calls to ADEBadgeInstallerInstanceWithDefs
// ********************
var G_someLocale = null;
var G_bAutoInstall = false;
var G_bAutoLaunch = false;

var G_bSendADEInstalled = false;
var G_bSendSWFVersion = false;
var G_bSendButtonPush = false;  // if true, only call the JS function - contentURL would be ignored if used
var G_strBadFlashRedirectURL = null;

// ********************
// Global script variable to indicate installed state for Digital Editions
// 0-NOT installed 1-Installed
// ********************
var G_bSawADEInstalled = false;
var G_nADEInstalled = 0;
var G_bForce_nADEInstalled_zero = false;	// used during debug/demo modes

var G_bTEST_nADEInstalled_control = false;	// used during debug/demo modes

var	GD_at_setG_nADEInstalled = 0;

// ********************
// Global script variable to hold SWF Version
// ********************
var G_strSWFVersion = "";
var G_bUpdateSWFVersion = true;
var	GD_at_setG_strSWFVersion = 0;

// ********************
// Stub function provided to support operation
// independent of DigitalEditionsDetection.js
// ********************
//function ShowADE_DivLayer()
//{
	// Copy and enable this function into your
	// implementations not using DigitalEditionsDetection.js
//}

// ********************
// Stub function provided to support operation for SWF Version
// This is called when sendSWFVersion = "true"
// and the script at setG_strSWFVersion() detects a fresh string
// ********************
//function ShowSWFVersion_DivLayer()
//{
	// Copy and enable this function into your
	// implementations that display the version
	//
	// This is sample. You may or may not do like this
	
/***************************	
	if (G_bUpdateSWFVersion)
	{
		G_bUpdateSWFVersion = false;
		var element = document.getElementById("swfVersionDiv");
	
		if (G_strSWFVersion.length > 0)
		{
			element.innerHTML = "<hr/>Adobe Digital Editions SWF Version:<br/><br/>" + G_strSWFVersion;
			// kick in the pants to be sure to display
			element.style.display = "block";
		}
		else
		{
			element.style.display = "none";
		}
	}
***************************/

//	return;
//}

// ********************
// Stub function provided to support send_ADE_SWF_ButtonPush()
// That anchor function will call the stub
// This way, the anchor function is always defined, and various
// implementations can provide the stub where needed
// ********************
//function ADE_SWF_ButtonPush_action()
//{
	// Copy and enable this function into your
	// implementations where sendButtonPush = "true"
	
	//  NOTE: When sendButtonPush = "true", then even if contentURL is set, it will not
	//  be sent to ADE after it is launched.  When sendButtonPush = "true", all that happens
	//  after ADE is launched is that the JS Callback is made, and that is it.
	
	// return;
//}

// ********************
// setG_nADEInstalled()
//
// Callback function for the ade_web_library.swf
// to indicate the installed state of Digital editions
//
// CONTROLLED BY: io_sendADEInstalled
//
// NOTE:
// if you are using the DigitalEditionsDetection.js file
// then you must disable the stub ShowADE_DivLayer() above
// to allow the Detection function to be called
// ********************
function setG_nADEInstalled(numberAsString)
{
	var nADEInstalled_current = G_nADEInstalled;
	
	GD_at_setG_nADEInstalled++;
	
	// ON MAC firefox, observed that the test control caused the
	// page to enter this function (call the SWF again?)
	// anyway, if control just pushed, ignore this hit
	if (G_bTEST_nADEInstalled_control)
	{
		G_bTEST_nADEInstalled_control = false;
	}
	else  // normal
	{
		var nResult = parseInt(numberAsString);
		if (!(nResult == Number.NaN))
		{
			if (G_bForce_nADEInstalled_zero)
			{
				G_nADEInstalled = 0;
			}
			else // normal case
			{
				G_nADEInstalled = nResult;
			}
			
			// If have not seen first report of installed state
			// OR State has changed, then wiggle the layers
			if (!G_bSawADEInstalled || (nADEInstalled_current != G_nADEInstalled))
			{
				ShowADE_DivLayer();	
			}
			
			G_bSawADEInstalled = true;
		}
	}
}

// ********************
// setG_strSWFVersion()
//
// CONTROLLED BY: io_sendSWFVersion
//
// This is called when sendSWFVersion = "true"
//
// Callback function for the ade_web_library.swf
// to indicate the version of ade_web_library.swf
// ********************
function setG_strSWFVersion(strSWFVersion)
{
	GD_at_setG_strSWFVersion++;
	if (strSWFVersion)
	{
		// If have not seen this, then wiggle the layers and save
		if (strSWFVersion != G_strSWFVersion)
		{
			G_strSWFVersion = strSWFVersion;
			G_bUpdateSWFVersion = true;
			
			// also do this if needed - implement the stub somewhere
			ShowSWFVersion_DivLayer();	
		}
	}
}

// ********************
// send_ADE_SWF_ButtonPush()
//
// CONTROLLED BY: io_sendButtonPush
//
// Callback function for the ade_web_library.swf
// when implementations set sendButtonPush = "true"
//
// NOTE: When io_sendButtonPush is true, then even if io_contentURL is set, it will not
// be sent to ADE after it is launched.  When io_sendButtonPush is true, all that happens
// after ADE is launched is that the JS Callback is made, and that is it.
//
// This callback indicates that ADE is installed, launched, and user pushed the button
// ********************
function send_ADE_SWF_ButtonPush()
{
	// you can add Script code here to call out to 
	// other parts of your script to take action
	// Default is call to this stub API that you can move around where needed
	// and leave this JS file intact
	ADE_SWF_ButtonPush_action();
}

// ********************
//
//  Flash SWF parameters (FlashVars):
//  =========================
//
//  FlashVars Documentation
//
//  The Adobe Digital Editions launcher SWF utilizes built-in Flash mechanisims
//  to detect, install, launch Adobe Digital Editions through the Flash add-in mechanism
//
//  Badge Mode:
//  The SWF for Badge Mode is specified as 315 x 220 Pixels
//  Badge mode is the mode when used with ADEBadgeLauncher.js
//
//  Badge Layout:
//  The badge layout has 3 sections:
//  Upper Badge text
//  Button (middle section)
//  Lower Badge Text
//
//  ------------------------------
//  Localized upper Badge Text area
//  The upper badge area contains this text
//  ------------------------------
//	English = "Adobe® Digital Editions Installer";
//	German = "Adobe® Digital Editions Installateur";
//	French = "Installateur d'Adobe® Digital Editions";
//
//  ------------------------------
//  The button in the center of the SWF has these localized values as default
//  ------------------------------
//  For "Launch/Install" mode (where contentURL is not used)
//  
//  When ADE is Installed
//	English = "Launch";
//	German = "Starten";
//	French = "Lancer";
//  
//  When ADE is NOT Installed
//	English = "Install";
//	German = "Installieren";
//	French = "Installer";
//  
//  ------------------------------
//  For "Read/Download/Fulfill" mode (where contentURL is used)
//  
//  When ADE is Installed
//  English = "Download Item";
//  German = "Element herunterladen";
//  French = "Télécharger l'élément";
//  
//  When ADE is NOT Installed
//  English = "Install and Read";
//  German = "Installieren und lesen";
//  French = "Installer et lire";
//  
//  ------------------------------
//  When the SWF detects that system requirements for ADE Are not met
//  
//  English = "System Requirements";
//  German = "System Anforderungen";
//  French = "Conditions de Système";
//  
//  ------------------------------
//  Localized lower Badge Text area
//  The lower badge area contains this text
//  ------------------------------
//  When ADE is Installed
//  English = "Launch Adobe Digital Editions";
//  German = "Adobe Digital Editions starten";
//  French = "Lancer Adobe Digital Editions";
//
//  When ADE is NOT Installed
//  English = "Click to install Adobe Digital Editions";
//  German = "Klicken Sie, um Adobe Digital Editions zu installieren";
//  French = "Cliquez pour installer Adobe Digital Editions";
//
//  When the SWF detects that system requirements for ADE Are not met
//  English = "Sorry, but your system does not meet the minimum system requirements.";
//  German = "Leider entspricht Ihr System nicht den minimalen System Anforderungen.";
//  French = "Désolé, mais votre système ne satisfait pas les besoins de système minimaux.";
//
//  =========================
//  Here is the documentation for external FlashVars that can be passed into the SWF
//
//  Flash SWF parameters (FlashVars):
//  PLEASE NOTE: the io_ prefix is NOT INCLUDED for the actual parameters that
//  are passed into the SWF.  Example, use "autoLaunch" for "io_autoLaunch"
//  This applies to every parameter described below
//
//  ------------------------------
//  io_userAgent - (string)
//  This is the Browser UserAgent that is needed to help determine if the
//  environment is suitable to install DE.
//  Collected automatically from the Adobe Labs implementation, and the
//  ADEBadgeLauncher.js automatically uses navigator.userAgent property
//  to pass this into the SWF
//
//  ------------------------------
//  io_locale - (string)
//  This parameter is used to specify the language localization option
//  that the  launcher should display.  
//
//  If io_locale is not sent, then the SWF will set the locale according
//  to the flash.system.Capabilities.language setting.  
//
//  IMPORTANT: It should be noted that the flash.system.Capabilities.language setting
//  Is what will be used to automatically provision the SWF with strings for the
//  little white dialog that appears during the INSTALL workflow.
//  This is REGARDLESS and INDEPENDENT of any setting passed in io_locale.
//
//  So if in fact io_locale is set to a different value than the 
//  flash.system.Capabilities.language setting, then the SWF will show strings of different
//  language inside the little white box displayed during the INSTALL workflow
//
//  The valid values for io_locale match the actionscript definitions for Locale as found here:
//  http://livedocs.adobe.com/flash/9.0/ActionScriptLangRefV3/flash/system/Capabilities.html#language
//
//  The language is specified as a lowercase two-letter language code from ISO 639-1. 
//  For Chinese, an additional uppercase two-letter country code from ISO 3166 distinguishes
//  between Simplified and Traditional Chinese. The languages codes are based on the English 
//  names of the language: for example, hu specifies Hungarian. 
//
//	The current supported languages are these:
//
//  Dutch "nl"
//  English "en"
//  French "fr"
//  German "de"
//  Italian "it"
//  Japanese "ja"
//  Korean "ko"
//  Portuguese "pt"
//  Simplified Chinese "zh-CN"
//  Spanish "es"
//  Traditional Chinese "zh-TW"
//
//  THESE ARE NOT SUPPORTED, and if used, default to English
//  Czech "cs"
//  Danish "da"
//  Finnish "fi"
//  Hungarian "hu"
//  Norwegian "no"
//  Other/unknown "xu"
//  Polish "pl"
//  Russian "ru"
//  Swedish "sv"
//  Turkish "tr"
//
//  ------------------------------
//  io_ADEVersion - (string - NUMBER)
//  This controls the Adobe Digital Editions version
//  that will be installed or launched by this SWF
//  Send the string version of a Number to control the version
//
//  '1' - DEPRECATED - ILLEGAL VALUE - System Requirements
//  '2' - Digital Editions 1.5 series - DEPRECATED - ILLEGAL VALUE - System Requirements
//  '3' - Digital Editions 1.7 series and greater BETA INSTALL
//  '4' - Digital Editions 1.7 series and greater
//  
//  sending any other value chooses the 1.7 series (like "4")
//
//  AS of 04/15/2008, using '1' is no longer supported
//  if the value of '1' is supplied, then the badge will enter "system Requirements" state
//
//  AS of 10/20/2008, using '2' is no longer supported
//  if the value of '2' is supplied, then the badge will enter "system Requirements" state
//
//  ------------------------------
//  io_badgeJSLauncher - (true, false)
//  NOT USED by the Adobe Labs Library mode
//  true - if from ADEBadgeLauncher.js
//
//  ------------------------------
//	io_contentURL - (string) 
//  NOT USED by the Adobe Labs Library mode
//  This parameter is used by ADEBadgeLauncher.js
//
//  How the ADE Launcher SWF handles this parameter is based on
//  the setting of io_doFulfillmentLink.
//
//  If io_doFulfillmentLink is false, then io_contentURL is
//  intended to be a URL path to an un-encrypted ePub or PDF Document.
//  io_contentURL will be sent to DE by the Launcher SWF and then
//  DE will download the file, add to the DE library, and open for reading
//
//  If io_doFulfillmentLink is true, then io_contentURL is
//  intended to be a GBLink fulfillment URL for Adobe Content Server DRM fulfillment
//  The launcher SWF will play the io_contentURL into the browser frame to
//  simulate a user clicking a GBLink URL href on a HTML page.  The target
//  ACS server will respond in the normal way with the ETD mime response to 
//  be handed to DE by the browser.  DE will handle the ETD response as usual and
//  fulfill the ACS DRM protected content.
//
//  VERY IMPORTANT:
//  The io_contentURL must be escaped (js escape() function) to retain its integrity
//
//  USE fix_gblink_plus_characters() with ACS GBLink URL
//  There is a helper function named fix_gblink_plus_characters() in the ADE Launcher SDK
//  that is provided to perform the final fix for io_contentURL that is used with 
//  io_doFulfillmentLink = true for GBLink URLs.  Please read the documentation and example
//  at fix_gblink_plus_characters() and in the ADE Launcher SDK examples
//
//  NOTE: When io_sendButtonPush is true, then even if io_contentURL is set, it will not
//  be sent to ADE after it is launched.  When io_sendButtonPush is true, all that happens
//  after ADE is launched is that the JS Callback is made, and that is it.
//
//  ------------------------------
//	io_autoInstall - (true, false)
//  true - If DE is not installed then install it. When installation of DE starts, 
//  the the Adobe EULA always appears.  The user must click through the EULA to complete the install.
//  false - Take no special action to install DE
//
//  ------------------------------
//	io_autoLaunch - (true, false)
//  true - If DE is installed then launch it.  If DE not installed, do nothing special
//  false - Take no special action to launch DE
//
//  ------------------------------
//  io_MMredirectURL - (string)
//  This is a URL that is used if NO Flash Version is detected or the Flash Version
//  is too low to run the Launcher SWF.
//  This URL should go to a warning page that is maintained by the
//  partner that says something like
//
//  Can't see this content? To view this content, JavaScript must be enabled, 
//  and you need the latest version of the Adobe Flash Player. Download the Flash Player now! 
//
//  www.adobe.com/go/getflashplayer is the Adobe GO URL to provide a link for FlashPlayer
//
//  ------------------------------
//  io_doFulfillmentLink - (true, false)
//  true - submit "io_contentURL" parameter into browser (for ACS GBLink DRM fulfillment URL)
//  false - pass "io_contentURL" through LocalConnection into DE. DE will download the 
//  content from the URL, add to the library, and then and open into reading mode
//
//  ------------------------------
//  io_sendADEInstalled - (true, false) 
//  true - SWF performs call back into Jscript function setG_nADEInstalled() to indicate 
//  installed state of DE.
//  false - DO NOT perform any JScript callback
//
//  ------------------------------
//  io_sendSWFVersion - (true, false) 
//  true - SWF performs call back into Jscript function setG_strSWFVersion() to indicate 
//  Version of the Adobe Digital Editions Launcher SWF
//  false - DO NOT perform any JScript callback
//
//  ------------------------------
//  io_sendButtonPush - (true, false) 
//  true - SWF performs call back into Jscript function send_ADE_SWF_ButtonPush() to indicate 
//  ADE is installed and the Button on the SWF is pushed
//  false - DO NOT perform any JScript callback
//
//  NOTE: When io_sendButtonPush is true, then even if io_contentURL is set, it will not
//  be sent to ADE after it is launched.  When io_sendButtonPush is true, all that happens
//  after ADE is launched is that the JS Callback is made, and that is it.
//
//  ------------------------------
//  io_debug_PlayerNotReady - (true, false)
//  Test-DEBUGGING option to simulate Bad Flash Version to run the SWF
//
//  ------------------------------
//  io_debug_BadOperatingSystem - (true, false)
//  Test-DEBUGGING option to simulate invalid Operating System
//
//  ------------------------------


// ********************
//  ADEBadgeLauncherInstance()
//
//  Launcher construction function
//
//  Places an instance of ade_web_library.swf (<object> tag with <embed> element) 
//  into a <div> section on HTML Page.  The id of the <div> section as well as the desired id
//  for the <object> tag are passed in.  
//
//  In addition, the parameters to control the behavior of the SWF are passed in
//
//  HTML Section params:
//  =========================
//	HTMLdivID  - id of the <div> which will hold the SWF
//  HTMLobjectID - desired ID for the HTML <object> that contains the SWF (may be null - default is ADEBadgeLauncherInstance)
//
//  Flash SWF parameters (FlashVars):
//  =========================
//  See the flashvars documentation just above
//
// NOTE: on 04/17/08, the (3) buttonLabel params were removed
// buttonLabelNotRequirements, buttonLabelNot, buttonLabelInst
// ********************
function ADEBadgeLauncherInstance(HTMLdivID, HTMLobjectID, 
contentURL,		    // MUST BE escaped
doFulfillmentLink,	// controls use of contentURL
autoInstall,
autoLaunch,
badFlashRedirectURL,
sendADEInstalled,
sendSWFVersion,
sendButtonPush)
{
//	var debug_PlayerNotReady = true;
//	var debug_BadOperatingSystem = true;

	// allow for NULL to default HTMLobjectID
	if (!HTMLobjectID)
		HTMLobjectID = 'ADEBadgeLauncherInstance';
		
	// These params are script-provided, or finalized by this script
	// See io_ADEVersion documentation, above
	var ADEVersion = "4"; // "4" is ADE 1.7 or greater - "3" is ADE 1.7 Beta or greater
	var badgeJSLauncher = "true";	// ALWAYS true from here
	
	var userAgent = navigator.userAgent;
	
	// NOTES for LOCALE:
	// See documentation above
	// If you try to use any of the HTML Browser navigator Object properties,
	// there is not one that is reliable across Browsers and Operating systems

	// As example on WIN XP and WIN IE7 Found these navigator settings: 
	// navigator.browserLanguage = en-us
	// navigator.userLanguage = fr	(WIN Control panel setting - not affected by Browser request language)
	// navigator.systemLanguage = en-us
	// navigator.language = undefined
	
	// However, navigator.userLanguage is not available in other browsers or on a MAC
	// As of (4/16/08) the SWF now uses flash.system.Capabilities.language internally
	// so it is not really necesary to send in locale, unless you want to take control
	
	// on WINDOWS, using control panel-regional and language settings will alter the locale for Flash
	// on MAC, system preferences-International-Language will alter the locale for Flash
	
	// also please note that if you take control of Locale, but the system locale is different, you will get
	// strange behavior because during an install, the text in the white box that appears is loaded from a
	// localized string resource on the internet that is based on the flash.system.Capabilities.language.  
	// This is part of  the automated install operation and not in programmatic control of the SWF
	
	var locale = ""; 
	if (G_someLocale)
		locale = G_someLocale;
	
	var bEscape = true;
	var finalBadFlashRedirectURL = getFinalBadFlashRedirectURL(badFlashRedirectURL, bEscape);
			
	// sum up the variables to be passed into the SWF
	// NOTE: on 04/17/08, the following (4) params were removed from the SWF
	// badgeImagePath, buttonLabelNotRequirements, buttonLabelNot, buttonLabelInst
	var strFlashVars = 'ADEVersion=' + ADEVersion +
					'&badgeJSLauncher=' + badgeJSLauncher +
//					'&debug_PlayerNotReady=' + debug_PlayerNotReady +
//					'&debug_BadOperatingSystem=' + debug_BadOperatingSystem +
					'&userAgent=' + userAgent +
					'&locale=' + locale +
					'&MMredirectURL=' + finalBadFlashRedirectURL +
					'&contentURL=' + contentURL +	// MUST BE escaped
					'&autoInstall=' + autoInstall +
					'&autoLaunch=' + autoLaunch +
					'&doFulfillmentLink=' + doFulfillmentLink +   // controls use of contentURL
					'&sendADEInstalled=' + sendADEInstalled +
					'&sendSWFVersion=' + sendSWFVersion +
					'&sendButtonPush=' + sendButtonPush;
					
	// size of the SWF.  This size is specified in the .FLA Flash design file
	// NOTE leading & trailing space is required to be built into this string
	//	var swfSize = ' width="225" height="170" ';	// This was the Beta3 Launcher
	var swfSize = ' width="315" height="220" ';		// This is the Ver 1.0 Launcher (june, 2007)
	
	// color, quality - declared 1 place
	var qualityValue = '"high"';
	var bgColorValue = '"#ffffff"';
	
	// path to the SWF just in case its not in same folder/place as this file
	// for example a relatitive path to the swf that is one directory higher might be
	// var swfPath = '"../parentpath/ade_web_library.swf"';
	var swfPath = '"ade_web_library.swf"';
	
	// Create object/embed tag for ade_web_library.swf
	var swf  = '<object id="' + HTMLobjectID + '" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"' + swfSize + 'codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0">';
		swf += '<param name="movie" value=' + swfPath + ' />';
		swf += '<param name="quality" value=' + qualityValue + ' />';
		swf += '<param name="bgcolor" value=' + bgColorValue + ' />';
		swf += '<param name="allowscriptaccess" value="samedomain" />';
		swf += '<param name="flashVars" value="' + strFlashVars + '" />';
		swf += '<embed type="application/x-shockwave-flash" src=' + swfPath + swfSize + 'id="' + HTMLobjectID + '" name="' + HTMLobjectID + '"allowscriptaccess="samedomain" flashVars="' + strFlashVars + '" swLiveConnect="true" quality=' + qualityValue + ' bgcolor=' + bgColorValue + 'align="" pluginspage="http://www.macromedia.com/go/getflashplayer"></embed>';
		swf += '</object>';
		
	// Now place the SWF object/embed tag into the HTML at the divID
	var element = document.getElementById(HTMLdivID);
	element.innerHTML = swf;
	
	// kick in the pants to be sure to display
	element.style.display = "block";
	
}

// *********************************************************
// *
// * Launcher mode helper API
// * For running launcher with default settings
// *
// *********************************************************

// ********************
// SetADEBadgeLauncherLocale()
// hardcode a Locale to use
// ********************
function SetADEBadgeLauncherLocale(theirLocale)
{
	G_someLocale = theirLocale;
}

// ********************
// ADEBadgeLauncherInstanceWithDefs()
//
// Create an instance of the ade_web_library.swf using defaults for most settings
// Set the defaults with SetADEBadgeLauncherDefaults
//
// NOTE:
// contentURL must be escaped
// doFulfillmentLink controls use of contentURL
// ********************
function ADEBadgeLauncherInstanceWithDefs(HTMLdivID, HTMLobjectID, contentURL, doFulfillmentLink)
{
	return ADEBadgeLauncherInstance(HTMLdivID, HTMLobjectID, contentURL, doFulfillmentLink, G_bAutoInstall, G_bAutoLaunch, G_strBadFlashRedirectURL, G_bSendADEInstalled, G_bSendSWFVersion, G_bSendButtonPush);
}

// ********************
// SetADEBadgeLauncherDefaults()
//
// Setup defaults to then use ADEBadgeLauncherInstanceWithDefs()
// NOTE: on 04/17/08, the (3) buttonLabel params were removed
// buttonLabelNotRequirements, buttonLabelNot, buttonLabelInst
// ********************
function SetADEBadgeLauncherDefaults(autoInstall, autoLaunch, badFlashRedirectURL, sendADEInstalled)
{
	G_bAutoInstall = autoInstall;
	G_bAutoLaunch = autoLaunch;
	G_bSendADEInstalled = sendADEInstalled;
	G_strBadFlashRedirectURL = badFlashRedirectURL;
	
	return;
}

// *********************************************************
// *
// * Installer mode helper API
// * For running launcher as Simple Installer
// *
// *********************************************************

// ********************
// ADEBadgeInstallerInstance()
//
// Create an instance of the ade_web_library.swf for Installer mode
//
// Never using contentURL, doFulfillmentLink, sendADEInstalled
// NOTE: on 04/17/08, the (3) buttonLabel params were removed
// buttonLabelNotRequirements, buttonLabelNot, buttonLabelInst
// ********************
function ADEBadgeInstallerInstance(HTMLdivID, HTMLobjectID,
autoInstall,
autoLaunch,
badFlashRedirectURL,
sendSWFVersion,
sendButtonPush)
{
	// installer mode never using these parameters
	// hc_ = hardcode
	var hc_contentURL = "";	
	var hc_doFulfillmentLink = false;
	var hc_sendADEInstalled = false;
	
	return ADEBadgeLauncherInstance(HTMLdivID, HTMLobjectID, hc_contentURL, hc_doFulfillmentLink, autoInstall, autoLaunch, badFlashRedirectURL, hc_sendADEInstalled, sendSWFVersion, sendButtonPush);
}

// ********************
// ADEBadgeInstallerInstanceWithDefs()
//
// Create an instance of the ade_web_library.swf using defaults for most settings
// Set the defaults with SetADEBadgeInstallerDefaults
// ********************
function ADEBadgeInstallerInstanceWithDefs(HTMLdivID, HTMLobjectID)
{
	return ADEBadgeInstallerInstance(HTMLdivID, HTMLobjectID, G_bAutoInstall, G_bAutoLaunch, G_strBadFlashRedirectURL, G_bSendSWFVersion, G_bSendButtonPush);
}

// ********************
// SetADEBadgeInstallerDefaults()
//
// Setup defaults to then use ADEBadgeInstallerInstanceWithDefs()
// NOTE: on 04/17/08, the (3) buttonLabel params were removed
// buttonLabelNotRequirements, buttonLabelNot, buttonLabelInst
// ********************
function SetADEBadgeInstallerDefaults(autoInstall, autoLaunch, badFlashRedirectURL, sendSWFVersion, sendButtonPush)
{
	G_bAutoInstall = autoInstall;
	G_bAutoLaunch = autoLaunch;
	G_strBadFlashRedirectURL = badFlashRedirectURL;
	G_bSendSWFVersion = sendSWFVersion;
	G_bSendButtonPush = sendButtonPush;  // if true, only call the JS function - contentURL would be ignored if used
	
	return;
}

// ********************
// getFinalBadFlashRedirectURL()
//
// Utility function to escape the URL.
// If not provided, use current window with params added (?flash=bad")
// ********************
function getFinalBadFlashRedirectURL(badFlashRedirectURL, bEscape)
{
	var scriptBadFlashRedirectURL = null;
	var finalBadFlashRedirectURL = null;
	if  (badFlashRedirectURL)
	{
		scriptBadFlashRedirectURL = badFlashRedirectURL;
	}
	else	// nothing special provided, use current window.
	{
		scriptBadFlashRedirectURL = window.location;
		
		// Modify to add any special URL parameters here
		scriptBadFlashRedirectURL += "?flash=bad"
	}
	
	if (bEscape)
	{
		finalBadFlashRedirectURL = escape(scriptBadFlashRedirectURL);
	}
	else
	{
		finalBadFlashRedirectURL = scriptBadFlashRedirectURL;
	}
	
	return finalBadFlashRedirectURL;
}

// ********************
// fix_gblink_plus_characters
//
// This function is required from server-side implementations where GBLink URL are
// constructed in the server, and will be passed into the ADEBadgeLauncherInstance functions.  
//
// Somewhere in the server variables scope, you would declare a variable that
// receives the GBLink Signed URL that is built in the server-side code
//
// This variable would be declared outside this client-side script block in the server scope
//
// var server_side_GBLinkURL;   // assign GBLink URL into this somewhere in server code
//
// The server-side code that uses GBlink to build a URL is called
//
// Construct the GBLink object
// var oGBLink = Server.CreateObject("ActiveGBLink.GBLink");
// var strQueryParams = oGBLink.BuildQuery( PARAMS );
// var strSignedQuery = oGBLink.SignQuery(strSignatureKey, strQueryParams);
//
// now append the signed query to the base fulfillment server (note the "?")
// server_side_GBLinkURL = "http://" + strFulfillmentServer  + "/fulfill/ebx.etd?" + strSignedQuery; 
//
// This line would plop the server_side_GBLinkURL as text into the client javascript
// var escapedContentURL = escape("<%=server_side_GBLinkURL%>");
//
// This line will fix the + into %2B for proper operation
// escapedContentURL = fix_gblink_plus_characters(escapedContentURL);
//
// ADEBadgeLauncherInstance(..., escapedContentURL, ...);
//
// ********************
//
// Please see supporting file GBLinkExample_ADE_JS.asp as well
//
// ********************
// fix_gblink_plus_characters
//
// Utility function to CHANGE "+" to escaped plus "%2B"
//
// Gblink URL's contain the + character as a space replacement
// in the gbauthdate parameter.  
//
// We discovered that the javascript escape() method leaves the + symbol
// alone, but that inside the Launcher SWF when the URL is played into the
// browser frame, then the + was converted to %20, and the ACS Server would
// give the Malformed Request message
//
// So, we take the extra step to change the "+" to escaped plus "%2B"
// in the string that is the result of the js escape() function
//
// here is what last part of Original gblink URL looks like
// &gbauthdate=6%2F18%2F2007+11%3A33+UTC
// &dateval=1182166430
// &gblver=3
// &auth=a0abe3dae50755f3e0c8e9ce6d334d4472186e22
//
// ********************
function fix_gblink_plus_characters(escapedContentURL)
{
	// CHANGE "+" to escaped plus "%2B"
	//
	var fixedURL = "";
	
	var strFind = "+";
	var lenFind = strFind.length;
	var strReplace = "%2B";	// ASCII + is 0x2B
	
	var iNext = 0;
	
	// Only start if we see gbauthdate
	var iStart = escapedContentURL.indexOf("gbauthdate", 1);
	if (iStart > 0)
	{
		// Serach for find string after gbauthdate
		iStart = escapedContentURL.indexOf(strFind, iStart);
	}
	
	// Replace all instances of the found string
	// Could also write a regexp to do this if desired
	while (iStart > 0)
	{
		// grab data that is before the found string
		fixedURL += escapedContentURL.substring(iNext, iStart);
		
		// replace the found string with replacement string
		fixedURL += strReplace;
		
		// move after the found string
		iNext = iStart + lenFind;
		
		// Check again
		iStart = escapedContentURL.indexOf(strFind, iNext);
	}
	
	// perform the final concat and update escapedContentURL
	if (iNext > 0)
	{
		fixedURL += escapedContentURL.substring(iNext);
	}
	else // never found anything to replace
	{
		//send back original
		fixedURL = escapedContentURL;
	}
	
	return fixedURL;

}


// END of file ADEBadgeLauncher.js