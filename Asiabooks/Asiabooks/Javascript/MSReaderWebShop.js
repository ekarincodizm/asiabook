var _fMSReaderInstalled = false;
var _fIE = false;
var _ActivationURL = "http://das.microsoft.com/activate/default.asp";

if (-1 != (new String(navigator.appName).indexOf("Internet Explorer")))
{
 _fIE = true;
 document.write("<OBJECT ID=\"_MSReaderWebShop\" CLASSID=\"CLSID:288451AE-BE24-4216-B946-8600E0498584\" height=\"0\" width=\"0\">&nbsp;<\/OBJECT>");

 var version = new String(navigator.appVersion);
 if (-1 != version.indexOf("MSIE 4"))
 {
  if (4 == _MSReaderWebShop.readyState)
   _fMSReaderInstalled = true;
 } else
 {
  if ((-1 != version.indexOf("MSIE 3.02")) && (-1 != version.indexOf("Windows CE")))
  {
   if ("string" == typeof _MSReaderWebShop.GetMSReaderVersion())
    _fMSReaderInstalled = true;
  } else
  {
   if (("undefined" != typeof _MSReaderWebShop.GetMSReaderVersion))
    _fMSReaderInstalled = true;
  }
 }
} else
if (navigator.appName == "Netscape")
{
 __NavMSRWS = navigator.mimeTypes["application/x-npebshp"];
 if (__NavMSRWS &&
     (__NavMSRWS.enabledPlugin.name=="Microsoft® Reader" ||
      __NavMSRWS.enabledPlugin.name=="Microsoft DAS Client Components"))
 {
  document.write("<EMBED type=\"application/x-npebshp\" name=\"MSReaderWebShop\" HIDDEN=\"TRUE\">");
  _fMSReaderInstalled = true;
 }
}


function MSReaderWebShop_IsMSReaderInstalled()
{
  return true;
}


function MSReaderWebShop_IsMSReaderActivated()
{
 if (!_fMSReaderInstalled)
  return false;
 if (_fIE)
 {
  if (0 == _MSReaderWebShop.IsMSReaderActivated())
   return false;
 } else
 {
  if (0 == document.MSReaderWebShop.IsMSReaderActivated())
   return false;
 }
 return true;
}


function MSReaderWebShop_GetMSReaderActivationID()
{
 if (!_fMSReaderInstalled)
  return "";
 if (_fIE)
  return _MSReaderWebShop.GetMSReaderActivationID();
 return document.MSReaderWebShop.GetMSReaderActivationID();
}


function MSReaderWebShop_GetMSReaderActivationCertificate()
{
 if (!_fMSReaderInstalled)
  return "";
 if (_fIE)
  return _MSReaderWebShop.GetMSReaderActivationCertificate();
 return document.MSReaderWebShop.GetMSReaderActivationCertificate();
}


function MSReaderWebShop_ActivateMSReader(ReturnURL, ReturnURLTitle)
{
 if ("undefined" == typeof ReturnURL)
  window.open(_ActivationURL);
 else
 {
  var _URL = _ActivationURL + "?OnFinish=" + escape(ReturnURL);
  if ("undefined" != typeof ReturnURLTitle)
   _URL = _URL + "&OnFinishName=" + escape(ReturnURLTitle);
  window.location = _URL;
 }
 return true;
} 


function MSReaderWebShop_GetMSReaderVersion()
{
 if (!_fMSReaderInstalled)
  return "";
 if (_fIE)
  return _MSReaderWebShop.GetMSReaderVersion();
 return document.MSReaderWebShop.GetMSReaderVersion();
} 