// JScript File

///////////////////////////////////////////////////////////
// Common
///////////////////////////////////////////////////////////
function CommonFunc() {

    this.Split = function( str, divider ) {
        var outStr = new Array();
        var tmpStr = "";
        var idx = 0;
        for( var i = 0; i < str.length; i++ ) {
            if( divider == str.charAt(i) ) {
                outStr[idx] = tmpStr;
                idx++;
                tmpStr = "";
            }
            else
                tmpStr = tmpStr + str.charAt(i);
        }
        if( tmpStr != "" )
            outStr[idx] = tmpStr;
        
        return outStr;
    }
    
}
var Common = new CommonFunc();

///////////////////////////////////////////////////////////
// Show alert message
///////////////////////////////////////////////////////////
function ShowAlert(msg) {
    var div = document.all["DivShowAlert"];
    if( div == null )
    {
        div = document.createElement("div")
        div.id = "DivShowAlert";
    }
   
  //////Cannot insert duplicate  เช็ค ว่าใช่msg Duplicate ไม๊ ถ้าใช่  แสดง msg อีกแบบ  
  if ( msg.indexOf("Cannot insert duplicate") != -1 )
        msg = "พบข้อผิดพลาด<br>มีการบันทึก ข้อมูลซ้ำกรุณาตรวจสอบ";
  ///////////////////////////////////////////////////// 
  ///////DELETE statement conflicted with COLUMN REFERENCE constraint  เช็คว่าใช่ Reference ไม๊ ถ้าใช่ แสดง msg อีกแบบ
  if (msg.indexOf("DELETE statement conflicted with COLUMN REFERENCE constraint") != -1 )
        msg = "พบข้อผิดพลาด<br>ไม่สามารถลบข้อมูลได้เนื่องจาก มีการนำข้อมูลนี้ไปใช้ยังส่วนงานอื่น<br>กรุณารวจสอบ";
   ///////////////////////////////////////////////////// 
 
    div.style.position = "absolute";
    div.style.zIndex = 10000;
    div.style.width = 400;
    div.style.height = 150;
    div.style.top = 100;
    div.style.left = (document.body.offsetWidth - parseInt(div.style.width) )/2
    div.style.backgroundColor = "SkyBlue";
    div.style.border = "outset 2px SkyBlue";
    var msgTable = "<table width='100%' cellpadding=2 cellspacing=2 >";
    msgTable += "<tr><th bgcolor=Red ><font color='black'>System Alert</font></th></tr>";
    msgTable += "<tr><td><font color='black'>" + msg.replace('\n','<br>') + "</font></d></tr>";
    msgTable += "<tr><td>&nbsp;</td></tr>";
    msgTable += "</table>";
    div.innerHTML = msgTable;
    div.onblur="HideAlert();";
    document.body.appendChild( div );
    div.outerHTML = div.outerHTML
    
	var eoffset = new ElementOffset(DivShowAlert)
    eoffset.HideIntersecTag("SELECT","DivShowAlert");
        
    setTimeout('DivShowAlert.style.display = "";DivShowAlert.focus();',0);
    
}

function HideAlert() {
	var obj = document.activeElement
	while( obj != null ){
		if( obj.id == "DivShowAlert" ) {
			DivShowAlert.focus();
			return;
		}
		obj = obj.parentElement
	}
	var eoffset = new ElementOffset(DivShowAlert)
	eoffset.ShowIntersecTag("DivShowAlert");
	DivShowAlert.style.display = "none"
} 

function ElementOffset( srcObj ) {
    this.IsPointInBox = function ( cx, cy ) {
        return( cx >= this.left && cx <= this.right &&  cy >= this.top && cy <= this.bottom )
    }
    
    this.IsIntersec = function ( obj ) {
        if( this.IsPointInBox(obj.left,obj.top) ) return true
        if( this.IsPointInBox(obj.left,obj.bottom) ) return true
        if( this.IsPointInBox(obj.right,obj.top) ) return true
        if( this.IsPointInBox(obj.right,obj.bottom) ) return true
        
        if( obj.IsPointInBox(this.left,this.top) ) return true
        if( obj.IsPointInBox(this.left,this.bottom) ) return true
        if( obj.IsPointInBox(this.right,this.top) ) return true
        if( obj.IsPointInBox(this.right,this.bottom) ) return true
        
        return false
    }
    
    this.HideIntersecTag = function ( tag, SignalCode ) {
		for( var i = 0; i < document.all.length ; i++ ) {
		    var refObj = document.all(i)
		    if( refObj.tagName == tag ) {
		        var refOffset = new ElementOffset( refObj )
//		        alert( refObj.id + "--" + refOffset.ToString() + "==" + this.ToString() )
		        if( this.IsIntersec(refOffset) ) {
		            refObj.style.display = "none"
		            refObj.ElementOffsetSignalCode = SignalCode;
		        }
		    }
		}
    }

    this.ShowIntersecTag = function ( SignalCode ) {
	    for( var i = 0; i < document.all.length ; i++ ) {
             var refObj = document.all(i)
	        if(  refObj.ElementOffsetSignalCode == SignalCode  ) {
	            refObj.style.display = ""
	            refObj.ElementOffsetSignalCode = null;
	        }
	    }
    }
    
    this.ToString = function(){
        return "(" + this.left + "," + this.top + "," + this.right + "," + this.bottom + ")";
    }

	this.x = 0
	this.y = 0
	var refObj = srcObj
	this.width = refObj.offsetWidth
	this.height = refObj.offsetHeight
	while( refObj ) {
        this.x += refObj.offsetLeft
        this.y += refObj.offsetTop
        refObj = refObj.offsetParent
	}
	
	this.left = this.x
	this.right = this.x + this.width
	this.top = this.y
	this.bottom = this.y + this.height
	
}

///////////////////////////////////////////////////////////
// Convert Data
///////////////////////////////////////////////////////////
function ConvertFunc() 
{
    this.ToInt = function ( str )
    {
	    tempNum = "";
	    for( i=0; i<str.length; i++)
	    {
		    c = str.charAt(i);
		    if( c != "," )
			    tempNum = tempNum + c;
	    }
	    return( parseInt(tempNum,10) );
    }
    
    this.ToInt = function ( str, def ) {
	    tempNum = "";
	    for( i=0; i<str.length; i++)
	    {
		    c = str.charAt(i);
		    if( c != "," )
			    tempNum = tempNum + c;
	    }
	    num = parseInt(tempNum,10);
	    if( isNaN(num) )
		    return(def);
	    else
		    return(num);
    }
    
    this.ToNum = function ( str ) {
	    tempNum = "";
	    for( i=0; i<str.length; i++)
	    {
		    c = str.charAt(i);
		    if( c != "," )
			    tempNum = tempNum + c;
	    }
	    return( parseFloat(tempNum,10) );
    }
    
    this.ToNum = function ( str, def ) {
	    tempNum = "";
	    for( i=0; i<str.length; i++)
	    {
		    c = str.charAt(i);
		    if( c != "," )
			    tempNum = tempNum + c;
	    }
	    num = parseFloat(tempNum,10);
	    if( isNaN(num) )
		    return(def);
	    else
		    return(num);
    }
    
    this.ToNumString = function ( data, DecimalPoint, ZeroLeading, GroupDigit  ) {
        var str = data.toString(10);
        var part = Common.Split( str , '.' );
        var prec = "";
        var scale = "";
        
        if( part.length == 1 ) part[1] = "";
        
        // prec
        if( ZeroLeading ) {
            if( part[0] == "" ) part[0] = "0";
        }
        else {
            if( part[0] == "0" ) part[0] = "";
        }
        if( GroupDigit ) {
            var i3 = 0;
            for( var i = part[0].length-1; i >= 0 ; i--) {
                i3 ++;
                if( i3 == 4 ) {
                    prec = part[0].charAt(i) + "," + prec;
                    i3 = 1;
                }
                else {
                    prec = "" + part[0].charAt(i) + prec;
                }
            }
        }
        else
            prec = part[0];
            
        // scale
        if( DecimalPoint > 0 ) { 
            while( part[1].length < DecimalPoint )
                part[1] = part[1] + "0";
            scale = "." + part[1].substring(0,DecimalPoint);
        }
        else {
            scale = ""
        }
        
        return prec + scale;
    }
    
}
var Convert = new ConvertFunc();


///////////////////////////////////////////////////////////
// Validate Data
///////////////////////////////////////////////////////////
function ValidID() {
    if(window.event.srcElement.value=="")
    {
	    return false;
    }
    var tempNum = "";
    for( i=0; i<window.event.srcElement.value.length; i++)
    {
	    var c = window.event.srcElement.value.charAt(i);
	    if( c != "," )
		    tempNum = tempNum + c;
    }
    var i = parseInt(tempNum,10);
    if( isNaN(i) )
    {
	    alert("ข้อมูลตัวเลขไม่ถูกต้อง");
	    window.event.srcElement.value = "";
	    return false;
    }
    window.event.srcElement.value = Convert.ToNumString(i,0,true,false);
    return true;
}


 // Original JavaScript code by Duncan Crombie: dcrombie@chirp.com.au
 // Please acknowledge use of this code by including this header.

 // CONSTANTS
var separator = ",";  // use comma as 000's separator
var decpoint = ".";  // use period as decimal point
var percent = "%";
var currency = "$";  // use dollar sign for currency

function formatN(number, format, print) {  // use: formatN(number, "format")
  if (print) document.write("formatN(" + number + ", \"" + format + "\")<br>");

  if (number - 0 != number) return null;  // if number is NaN return null
  var useSeparator = format.indexOf(separator) != -1;  // use separators in number
  var usePercent = format.indexOf(percent) != -1;  // convert output to percentage
  var useCurrency = format.indexOf(currency) != -1;  // use currency format
  var isNegative = (number < 0);
  number = Math.abs (number);
  if (usePercent) number *= 100;
  format = strip(format, separator + percent + currency);  // remove key characters
  number = "" + number;  // convert number input to string

   // split input value into LHS and RHS using decpoint as divider
  var dec = number.indexOf(decpoint) != -1;
  var nleftEnd = (dec) ? number.substring(0, number.indexOf(".")) : number;
  var nrightEnd = (dec) ? number.substring(number.indexOf(".") + 1) : "";

   // split format string into LHS and RHS using decpoint as divider
  dec = format.indexOf(decpoint) != -1;
  var sleftEnd = (dec) ? format.substring(0, format.indexOf(".")) : format;
  var srightEnd = (dec) ? format.substring(format.indexOf(".") + 1) : "";

   // adjust decimal places by cropping or adding zeros to LHS of number
  if (srightEnd.length < nrightEnd.length) {
    var nextChar = nrightEnd.charAt(srightEnd.length) - 0;
    nrightEnd = nrightEnd.substring(0, srightEnd.length);
    if (nextChar >= 5) nrightEnd = "" + ((nrightEnd - 0) + 1);  // round up

// patch provided by Patti Marcoux 1999/08/06
    while (srightEnd.length > nrightEnd.length) {
      nrightEnd = "0" + nrightEnd;
    }

    if (srightEnd.length < nrightEnd.length) {
      nrightEnd = nrightEnd.substring(1);
      nleftEnd = (nleftEnd - 0) + 1;
    }
  } else {
    for (var i=nrightEnd.length; srightEnd.length > nrightEnd.length; i++) {
      if (srightEnd.charAt(i) == "0") nrightEnd += "0";  // append zero to RHS of number
      else break;
    }
  }

   // adjust leading zeros
  sleftEnd = strip(sleftEnd, "#");  // remove hashes from LHS of format
  while (sleftEnd.length > nleftEnd.length) {
    nleftEnd = "0" + nleftEnd;  // prepend zero to LHS of number
  }

  if (useSeparator) nleftEnd = separate(nleftEnd, separator);  // add separator
  var output = nleftEnd + ((nrightEnd != "") ? "." + nrightEnd : "");  // combine parts
  output = ((useCurrency) ? currency : "") + output + ((usePercent) ? percent : "");
  if (isNegative) {
    // patch suggested by Tom Denn 25/4/2001
    output = (useCurrency) ? "(" + output + ")" : "-" + output;
  }
  return output;
}

function strip(input, chars) {  // strip all characters in 'chars' from input
  var output = "";  // initialise output string
  for (var i=0; i < input.length; i++)
    if (chars.indexOf(input.charAt(i)) == -1)
      output += input.charAt(i);
  return output;
}

function separate(input, separator) {  // format input using 'separator' to mark 000's
  input = "" + input;
  var output = "";  // initialise output string
  for (var i=0; i < input.length; i++) {
    if (i != 0 && (input.length - i) % 3 == 0) output += separator;
    output += input.charAt(i);
  }
  return output;
}

function Str2Int( str )
{
	tempNum = "";
	for( i=0; i<str.length; i++)
	{
		c = str.charAt(i);
		if( c != "," )
			tempNum = tempNum + c;
	}
	return( parseInt(tempNum,10) );
}
function Str2Int( str, def )
{
	tempNum = "";
	for( i=0; i<str.length; i++)
	{
		c = str.charAt(i);
		if( c != "," )
			tempNum = tempNum + c;
	}
	num = parseInt(tempNum,10);
	if( isNaN(num) )
		return(def);
	else
		return(num);
}
function StrToNum( str )
{
	tempNum = '';
	for( i=0; i<str.length; i++)
	{
		c = str.charAt(i);
		if( c != "," )
			tempNum = tempNum + c;
	}
	//alert(tempNum);
	return( tempNum );
}
function Str2Num( str )
{
	tempNum = "";
	for( i=0; i<str.length; i++)
	{
		c = str.charAt(i);
		if( c != "," )
			tempNum = tempNum + c;
	}
	//return( parseFloat(tempNum,10) );
	return( tempNum );
}
function Str2Num( str, def )
{
	tempNum = "";
	for( i=0; i<str.length; i++)
	{
		c = str.charAt(i);
		if( c != "," )
			tempNum = tempNum + c;
	}
	num = parseFloat(tempNum,10);
	if( isNaN(num) )
		return(def);
	else
		return(num);
}

function ValidInt()
{
	if(window.event.srcElement.value=="")
	{
//        window.event.srcElement.value = formatN(0,"#,##0")
		return false;
	}
	tempNum = "";
	for( i=0; i<window.event.srcElement.value.length; i++)
	{
		c = window.event.srcElement.value.charAt(i);
		if( c != "," )
			tempNum = tempNum + c;
	}
	i = parseInt(tempNum,10);
	if( isNaN(i) )
	{
		alert("ข้อมูลตัวเลขไม่ถูกต้อง");
		window.event.srcElement.value = "";
		return false;
	}
	window.event.srcElement.value = formatN(i,"#,##0");
	return true;
}
function NulltoZero()
{
	if(window.event.srcElement.value=="")
	{
        window.event.srcElement.value = formatN(0,"#,##0")
		return false;
	}
	tempNum = "";
	for( i=0; i<window.event.srcElement.value.length; i++)
	{
		c = window.event.srcElement.value.charAt(i);
		if( c != "," )
			tempNum = tempNum + c;
	}
	i = parseInt(tempNum,10);
	if( isNaN(i) )
	{
		alert("ข้อมูลตัวเลขไม่ถูกต้อง");
		window.event.srcElement.value = "";
		return false;
	}
	window.event.srcElement.value = formatN(i,"#,##0");
	return true;
}
function ValidNum()
{
	if(window.event.srcElement.value=="")
	{
	    window.event.srcElement.value = formatN(0,"#,##0.00")
		return false;
	}
	tempNum = "";
	for( i=0; i<window.event.srcElement.value.length; i++)
	{
		c = window.event.srcElement.value.charAt(i);
		if( c != "," )
			tempNum = tempNum + c;
	}
	i = parseFloat(tempNum,10);
	if( isNaN(i) )
	{
		alert("ข้อมูลตัวเลขไม่ถูกต้อง");
		window.event.srcElement.value = "";
		return false;
	}
	window.event.srcElement.value = formatN(i,"#,##0.00");
	return true;
}
function ValidNum3()
{
	if(window.event.srcElement.value=="")
	{
	    window.event.srcElement.value = formatN(0,"#,##0.000")
		return false;
	}
	tempNum = "";
	for( i=0; i<window.event.srcElement.value.length; i++)
	{
		c = window.event.srcElement.value.charAt(i);
		if( c != "," )
			tempNum = tempNum + c;
	}
	i = parseFloat(tempNum,10);
	if( isNaN(i) )
	{
		alert("ข้อมูลตัวเลขไม่ถูกต้อง");
		window.event.srcElement.value = "";
		return false;
	}
	window.event.srcElement.value = formatN(i,"#,##0.000");
	return true;
}

function ValidDate()
{
	if(window.event.srcElement.value=="")
	{
		return false;
	}
	d = window.event.srcElement.value.split("/")
	if( d.length != 3 )
	{
		alert("ข้อมูลวันที่ไม่ถูกต้อง")
		window.event.srcElement.value = ""
		return false
	}
	dd = parseInt(d[0],10);
	if( isNaN(dd) ) 
	{
		alert("ข้อมูลวันที่ไม่ถูกต้อง")
		window.event.srcElement.value = ""
		return false
	}
	mm = parseInt(d[1],10);
	if( isNaN(mm) ) 
	{
		alert("ข้อมูลวันที่ไม่ถูกต้อง")
		window.event.srcElement.value = ""
		return false
	}
	yy = parseInt(d[2],10);
	if( isNaN(yy) ) 
	{
		alert("ข้อมูลวันที่ไม่ถูกต้อง")
		window.event.srcElement.value = ""
		return false
	}
	if( yy > 2200 )
		yy = yy - 543
	if( yy < 100 )
	{
		yy = yy + 2500 - 543
	}
		
	dt = new Date(yy,mm-1,dd)

	yy = (dt.getFullYear()+543)
	mm = (dt.getMonth()+1)
	dd = (dt.getDate())
	window.event.srcElement.value = formatN(dd,"00") + "/" + formatN(mm,"00") + "/" + formatN(yy,"0000")
	return true
}
function ValidTime()
{
	if(window.event.srcElement.value=="")
	{
	    window.event.srcElement.value = "00:00";
		return false;
	}
	d = window.event.srcElement.value.split(":")
	if( d.length != 2 )
	{
		alert("ข้อมูลเวลาไม่ถูกต้อง")
		window.event.srcElement.value = "00:00"
		return false
	}
	hh = parseInt(d[0],10);
	if( isNaN(hh) ) 
	{
		alert("ข้อมูลชั่วโมงไม่ถูกต้อง")
		window.event.srcElement.value = "00:00"
		return false
	}
	if( hh == 24 ) hh = 0;
	if( hh > 24 || hh < 0 ) 
	{
		alert("ข้อมูลชั่วโมงไม่ถูกต้อง")
		window.event.srcElement.value = "00:00"
		return false
	}	
	nn = parseInt(d[1],10);
	if( isNaN(nn) ) 
	{
		alert("ข้อมูลนาทีไม่ถูกต้อง")
		window.event.srcElement.value = "00:00"
		return false
	}
	if( nn == 60 ) nn = 0;
	if( nn > 60 || nn < 0 ) 
	{
		alert("ข้อมูลนาทีไม่ถูกต้อง")
		window.event.srcElement.value = "00:00"
		return false
	}		
	window.event.srcElement.value = formatN(hh,"00") + ":" + formatN(nn,"00")
	return true
}
function TextSelect()
{
	window.event.srcElement.select();
}
function showitem(itmecode)
{
      
    var s_open = "popupDetail.aspx?itemcode=" +itmecode ;
    window.open(s_open,"","toolbar=no,location=no,status=no,scrollbars =no,menubar=no,resizable=no,dependent=no,titlebar=no,top=0,left=0,width=430,height=380" );

}
function OverPicture(id)
{
    var picName = document.getElementById("img"+id).src.split("_");
    if(picName[picName.length-1] != "actv.gif"){
    document.getElementById("img"+id).src="images/shared/nav/nav0" + id + "_norm.gif";
    }
}
function PictureLost(id)
{
    var picName = document.getElementById("img" + id).src.split("_");
    if(picName[picName.length-1] != "actv.gif"){
    document.getElementById("img" + id).src="images/shared/nav/nav0" + id + "_roll.gif";
    }
}
function ClickPicture(page)
{
  window.location=page;
}
function CheckType(id)
{
    var tmpid = id.split("_");
    if(tmpid[tmpid.length-1] == "chkIs")
        document.getElementById(id.replace("_chkIs","_chkPr")).checked = false;
     else
         document.getElementById(id.replace("_chkPr","_chkIs")).checked = false;
}
function ShowAlert(id)
{
    alert(id);
}