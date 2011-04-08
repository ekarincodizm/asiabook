//	written	by Tan Ling Wee	on 2 Dec 2001
//	last updated 23 June 2002
//	email :	fuushikaden@yahoo.com
//	Modified by Paul Morel on 6 May 2003 -- Condensed and rearranged code
//
// Last Modified by Roid Soft Co., Ltd.  - 10 Nov 2003
//

//You can edit these variables
var fixedX = -1 // x position (-1 if to appear below control)
var fixedY = -1 // y position (-1 if to appear below control)
var startAt = 0 // 0 - sunday ; 1 - monday
var showWeekNumber = 0 // 0 - don't show; 1 - show
var showToday = 1 // 0 - don't show; 1 - show
var imgDir = "images/cal/" // directory for images ... e.g. var imgDir="/img/"
var gotoString = "Go To Current Month"
var todayString = "Today is"
var weekString = "Week"
var scrollLeftMessage = "Click to scroll to previous month. Hold mouse button to scroll automatically."
var scrollRightMessage = "Click to scroll to next month. Hold mouse button to scroll automatically."
var selectMonthMessage = "Click to select a month."
var selectYearMessage = "Click to select a year."
var selectDateMessage = "Select [date] as date." // do not replace [date], it will be replaced by date.
var monthName =	new Array("January","February","March","April","May","June","July","August","September","October","November","December")

var gotoThaiString = "ไปยังเดือนปัจจุบัน"
var todayThaiString = "วันนี้วัน"
var weekThaiString = "สัปดาห์"
var scrollLeftThaiMessage = "กดเพื่อเลื่อนไปเดือนที่แล้ว , กดค้างไว้เพื่อเลื่อนอัตโนมัติ"
var scrollRightThaiMessage = "กดเพื่อเลื่อนไปเดือนถัดไป , กดค้างไว้เพื่อเลื่อนอัตโนมัติ"
var selectMonthThaiMessage = "กดเพื่อเลือกวัน"
var selectYearThaiMessage = "กดเพื่อเลือกปี"
var selectDateThaiMessage = "เลือก [date] " // do not replace [date], it will be replaced by date.
var tmonthName =	new Array("มกราคม","กุมภาพันธ์","มีนาคม","เมษายน","พฤษภาคม","มิถุนายน","กรกฏาคม","สิงหาคม","กันยายน","ตุลาคม","พฤศจิกายน","ธันวาคม")
var tmonthNameSub =	new Array("ม.ค.","ก.พ.","มี.ค.","เม.ย.","พ.ค.","มิ.ย.","ก.ค.","ส.ค.","ก.ย.","ต.ค.","พ.ย.","ธ.ค.")

var styleAnchor="text-decoration:none;color:black;"
var styleLightBorder="border-style:solid;border-width:1px;border-color:#a0a0a0;"
var imgsrc= new Array("drop1.gif","drop2.gif","left1.gif","left2.gif","right1.gif","right2.gif")

//Don't Edit these variables
var crossobj, crossMonthObj, crossYearObj, monthSelected, yearSelected, dateSelected, omonthSelected, oyearSelected, odateSelected, monthConstructed, yearConstructed, intervalID1, intervalID2, timeoutID1, timeoutID2, ctlToPlaceValue, ctlNow, dateFormat, nStartingYear
var bPageLoaded=false
var ie=document.all
var dom=document.getElementById
var ns4=document.layers
var today = new Date()
var dateNow=today.getDate()
var monthNow=today.getMonth()
var yearNow=today.getYear()
var img	= new Array()
var bShow = false;
var HolidaysCounter = 0
var Holidays = new Array()
var nowLang = "E"

if (dom){
	for	(i=0;i<imgsrc.length;i++){
		img[i] = new Image
		img[i].src = imgDir + imgsrc[i]
	}

	//------------ Modify for over listbox -------------//
	document.write("<div id='mask' style='position:absolute;visibility:hidden;'><iframe src='' width='0' height='0' frameborder=0 id='framemask'></iframe></div>");
	document.write("<div id='monthmask' style='position:absolute;visibility:hidden;'><iframe src='' width='0' height='0' frameborder=0 id='framemonthmask'></iframe></div>");
	document.write("<div id='yearmask' style='position:absolute;visibility:hidden;'><iframe src='' width='0' height='0' frameborder=0 id='frameyearmask'></iframe></div>");
	//------------ Modify for over listbox -------------//

	document.write ("<div onclick='bShow=true' id='calendar'style='z-index:+999;position:absolute;visibility:hidden;'><table	width="+((showWeekNumber==1)?250:220)+" style='font-family:arial;font-size:11px;border-width:1;border-style:solid;border-color:#a0a0a0;font-family:arial; font-size:11px}' bgcolor='#ffffff'><tr bgcolor='#0000aa'><td><table width='"+((showWeekNumber==1)?248:218)+"'><tr><td style='padding:2px;font-family:arial; font-size:11px;'><font color='#ffffff'><B><span id='caption'></span></B></font></td><td align=right><a href='javascript:hideCalendar()'><IMG SRC='"+imgDir+"close.gif' WIDTH='15' HEIGHT='13' BORDER='0' ALT='Close'></a></td></tr></table></td></tr><tr><td style='padding:5px' bgcolor=#ffffff><span id='content'></span></td></tr>")
	if (showToday==1){
		document.write ("<tr bgcolor=#f0f0f0><td style='padding:5px' align=center><span id='lblToday'></span></td></tr>")
	}
	document.write ("</table></div><div id='selectMonth' style='z-index:+999;position:absolute;visibility:hidden;'></div><div id='selectYear' style='z-index:+999;position:absolute;visibility:hidden;'></div>");
}
if (startAt==0){
	dayName = new Array ("Sun","Mon","Tue","Wed","Thu","Fri","Sat")
	tdayName = new Array ("อา.","จ.","อ.","พ.","พฤ.","ศ.","ส.")
	fullTName = new Array ("อาทิตย์","จันทร์","อังคาร","พุธ","พฤหัสบดี","ศุกร์","เสาร์")
}
else{
	dayName = new Array ("Mon","Tue","Wed","Thu","Fri","Sat","Sun")
	tdayName = new Array ("จ.","อ.","พ.","พฤ.","ศ.","ส.","อา.")
	fullTName = new Array ("จันทร์","อังคาร","พุธ","พฤหัสบดี","ศุกร์","เสาร์","อาทิตย์")
}
document.onkeypress = function hidecal1 () {
	if (event.keyCode==27){
		hideCalendar()
	}
}
document.onclick = function hidecal2 () {
	if (!bShow){
		hideCalendar()
	}
	bShow = false
}
if(ie){
   init1()
}
else{
  window.onload=init1
}

// hides <select> and <applet> objects (for IE only)
function hideElement( elmID, overDiv ){

//------------ Modify for over listbox -------------//
if( ie ){
    var obj = document.getElementById(elmID);
	if (obj!=null) {
		obj.style.visibility = "";
		obj.style.top = overDiv.offsetTop;
		obj.style.left = overDiv.offsetLeft;
		var frame = document.getElementById("frame"+elmID);
		if (frame!=null) {
			frame.width=overDiv.offsetWidth;
			frame.height=overDiv.offsetHeight;
		}
	}
} // end if check ie
//------------ Modify for over listbox -------------//

/*
	if( ie ){
		for( i = 0; i < document.all.tags( elmID ).length; i++ ){
  			obj = document.all.tags( elmID )[i];
  			if( !obj || !obj.offsetParent ){
    				continue;
  			}
			  // Find the element's offsetTop and offsetLeft relative to the BODY tag.
			  objLeft   = obj.offsetLeft;
			  objTop    = obj.offsetTop;
			  objParent = obj.offsetParent;
			  while( objParent.tagName.toUpperCase() != "BODY" )
			  {
			    objLeft  += objParent.offsetLeft;
			    objTop   += objParent.offsetTop;
			    objParent = objParent.offsetParent;
			  }
			  objHeight = obj.offsetHeight;
			  objWidth = obj.offsetWidth;
			  if(( overDiv.offsetLeft + overDiv.offsetWidth ) <= objLeft );
			  else if(( overDiv.offsetTop + overDiv.offsetHeight ) <= objTop );
	// CHANGE by Charlie Roche for nested TDs
			  else if( overDiv.offsetTop >= ( objTop + objHeight + obj.height ));
	// END CHANGE
			  else if( overDiv.offsetLeft >= ( objLeft + objWidth ));
			  else
			  {
			    obj.style.visibility = "hidden";
			  }
		}
	}
*/
}

//unhides <select> and <applet> objects (for IE only)
function showElement( elmID ){

//------------ Modify for over listbox -------------//
if (ie) {
	var obj = null;
    obj = document.getElementById("mask");
	if (obj!=null) { obj.style.visibility = "hidden"; }
    obj = document.getElementById("monthmask");
	if (obj!=null) { obj.style.visibility = "hidden"; }
    obj = document.getElementById("yearmask");
	if (obj!=null) { obj.style.visibility = "hidden"; }
}
//------------ Modify for over listbox -------------//

/*
	if( ie ){
		for( i = 0; i < document.all.tags( elmID ).length; i++ ){
  			obj = document.all.tags( elmID )[i];
			if( !obj || !obj.offsetParent ){
    				continue;
			}
			obj.style.visibility = "";
		}
	}
*/
}

function HolidayRec (d, m, y, desc){
	this.d = d
	this.m = m
	this.y = y
	this.desc = desc
}

function addHoliday (d, m, y, desc){
	Holidays[HolidaysCounter++] = new HolidayRec ( d, m, y, desc )
}

function swapImage(srcImg, destImg){
	if (ie)	{ document.getElementById(srcImg).setAttribute("src",imgDir + destImg) }
}

function init1()	{
	if (!ns4)
	{
		if (!ie) { yearNow += 1900	}

		crossobj=(dom)?document.getElementById("calendar").style : ie? document.all.calendar : document.calendar
		hideCalendar()
		crossMonthObj=(dom)?document.getElementById("selectMonth").style : ie? document.all.selectMonth	: document.selectMonth
		crossYearObj=(dom)?document.getElementById("selectYear").style : ie? document.all.selectYear : document.selectYear
		monthConstructed=false;
		yearConstructed=false;
/*
		sHTML1="<span id='spanLeft'	style='border-style:solid;border-width:1;border-color:#3366FF;cursor:pointer' onmouseover='swapImage(\"changeLeft\",\"left2.gif\");this.style.borderColor=\"#88AAFF\";window.status=\""+scrollLeftMessage+"\"' onclick='javascript:decMonth()' onmouseout='clearInterval(intervalID1);swapImage(\"changeLeft\",\"left1.gif\");this.style.borderColor=\"#3366FF\";window.status=\"\"' onmousedown='clearTimeout(timeoutID1);timeoutID1=setTimeout(\"StartDecMonth()\",500)'	onmouseup='clearTimeout(timeoutID1);clearInterval(intervalID1)'>&nbsp<IMG id='changeLeft' SRC='"+imgDir+"left1.gif' width=10 height=11 BORDER=0>&nbsp</span>&nbsp;"
		sHTML1+="<span id='spanRight' style='border-style:solid;border-width:1;border-color:#3366FF;cursor:pointer'	onmouseover='swapImage(\"changeRight\",\"right2.gif\");this.style.borderColor=\"#88AAFF\";window.status=\""+scrollRightMessage+"\"' onmouseout='clearInterval(intervalID1);swapImage(\"changeRight\",\"right1.gif\");this.style.borderColor=\"#3366FF\";window.status=\"\"' onclick='incMonth()' onmousedown='clearTimeout(timeoutID1);timeoutID1=setTimeout(\"StartIncMonth()\",500)'	onmouseup='clearTimeout(timeoutID1);clearInterval(intervalID1)'>&nbsp<IMG id='changeRight' SRC='"+imgDir+"right1.gif'	width=10 height=11 BORDER=0>&nbsp</span>&nbsp"
		sHTML1+="<span id='spanMonth' style='border-style:solid;border-width:1;border-color:#3366FF;cursor:pointer'	onmouseover='swapImage(\"changeMonth\",\"drop2.gif\");this.style.borderColor=\"#88AAFF\";window.status=\""+selectMonthMessage+"\"' onmouseout='swapImage(\"changeMonth\",\"drop1.gif\");this.style.borderColor=\"#3366FF\";window.status=\"\"' onclick='popUpMonth()'></span>&nbsp;"
		sHTML1+="<span id='spanYear' style='border-style:solid;border-width:1;border-color:#3366FF;cursor:pointer' onmouseover='swapImage(\"changeYear\",\"drop2.gif\");this.style.borderColor=\"#88AAFF\";window.status=\""+selectYearMessage+"\"'	onmouseout='swapImage(\"changeYear\",\"drop1.gif\");this.style.borderColor=\"#3366FF\";window.status=\"\"'	onclick='popUpYear()'></span>&nbsp;"
		document.getElementById("caption").innerHTML  =	sHTML1
		bPageLoaded=true
*/
	}
}

function init2()	{
	if (!ns4)
	{
		if (!ie) { yearNow += 1900	}
		if (showToday==1)
		{
			if (nowLang=="T") {
  			   document.getElementById("lblToday").innerHTML =	"<a onmousemove='window.status=\""+gotoThaiString+"\"' onmouseout='window.status=\"\"' title='"+gotoThaiString+"' style='"+styleAnchor+"' href='javascript:monthSelected=monthNow;yearSelected=yearNow;constructCalendar();'>" + todayThaiString + fullTName[(today.getDay()-startAt==-1)?6:(today.getDay()-startAt)]+"ที่ " + dateNow + " " + tmonthNameSub[monthNow] + "	" +	(yearNow+543)	+ "</a>"
			} else {
			   document.getElementById("lblToday").innerHTML =	todayString + " <a onmousemove='window.status=\""+gotoString+"\"' onmouseout='window.status=\"\"' title='"+gotoString+"' style='"+styleAnchor+"' href='javascript:monthSelected=monthNow;yearSelected=yearNow;constructCalendar();'>"+dayName[(today.getDay()-startAt==-1)?6:(today.getDay()-startAt)]+", " + dateNow + " " + monthName[monthNow].substring(0,3)	+ "	" +	yearNow	+ "</a>"
			}
		}

		if (nowLang=="T") {
  		  sHTML1="<span id='spanLeft'	style='border-style:solid;border-width:1;border-color:#3366FF;cursor:pointer' onmouseover='swapImage(\"changeLeft\",\"left2.gif\");this.style.borderColor=\"#88AAFF\";window.status=\""+scrollLeftThaiMessage+"\"' onclick='javascript:decMonth()' onmouseout='clearInterval(intervalID1);swapImage(\"changeLeft\",\"left1.gif\");this.style.borderColor=\"#3366FF\";window.status=\"\"' onmousedown='clearTimeout(timeoutID1);timeoutID1=setTimeout(\"StartDecMonth()\",500)'	onmouseup='clearTimeout(timeoutID1);clearInterval(intervalID1)'>&nbsp<IMG id='changeLeft' SRC='"+imgDir+"left1.gif' width=10 height=11 BORDER=0>&nbsp</span>&nbsp;"
		  sHTML1+="<span id='spanRight' style='border-style:solid;border-width:1;border-color:#3366FF;cursor:pointer'	onmouseover='swapImage(\"changeRight\",\"right2.gif\");this.style.borderColor=\"#88AAFF\";window.status=\""+scrollRightThaiMessage+"\"' onmouseout='clearInterval(intervalID1);swapImage(\"changeRight\",\"right1.gif\");this.style.borderColor=\"#3366FF\";window.status=\"\"' onclick='incMonth()' onmousedown='clearTimeout(timeoutID1);timeoutID1=setTimeout(\"StartIncMonth()\",500)'	onmouseup='clearTimeout(timeoutID1);clearInterval(intervalID1)'>&nbsp<IMG id='changeRight' SRC='"+imgDir+"right1.gif'	width=10 height=11 BORDER=0>&nbsp</span>&nbsp"
		  sHTML1+="<span id='spanMonth' style='border-style:solid;border-width:1;border-color:#3366FF;cursor:pointer'	onmouseover='swapImage(\"changeMonth\",\"drop2.gif\");this.style.borderColor=\"#88AAFF\";window.status=\""+selectMonthThaiMessage+"\"' onmouseout='swapImage(\"changeMonth\",\"drop1.gif\");this.style.borderColor=\"#3366FF\";window.status=\"\"' onclick='popUpMonth()'></span>&nbsp;"
		  sHTML1+="<span id='spanYear' style='border-style:solid;border-width:1;border-color:#3366FF;cursor:pointer' onmouseover='swapImage(\"changeYear\",\"drop2.gif\");this.style.borderColor=\"#88AAFF\";window.status=\""+selectYearThaiMessage+"\"'	onmouseout='swapImage(\"changeYear\",\"drop1.gif\");this.style.borderColor=\"#3366FF\";window.status=\"\"'	onclick='popUpYear()'></span>&nbsp;"
		} else {
  		  sHTML1="<span id='spanLeft'	style='border-style:solid;border-width:1;border-color:#3366FF;cursor:pointer' onmouseover='swapImage(\"changeLeft\",\"left2.gif\");this.style.borderColor=\"#88AAFF\";window.status=\""+scrollLeftMessage+"\"' onclick='javascript:decMonth()' onmouseout='clearInterval(intervalID1);swapImage(\"changeLeft\",\"left1.gif\");this.style.borderColor=\"#3366FF\";window.status=\"\"' onmousedown='clearTimeout(timeoutID1);timeoutID1=setTimeout(\"StartDecMonth()\",500)'	onmouseup='clearTimeout(timeoutID1);clearInterval(intervalID1)'>&nbsp<IMG id='changeLeft' SRC='"+imgDir+"left1.gif' width=10 height=11 BORDER=0>&nbsp</span>&nbsp;"
		  sHTML1+="<span id='spanRight' style='border-style:solid;border-width:1;border-color:#3366FF;cursor:pointer'	onmouseover='swapImage(\"changeRight\",\"right2.gif\");this.style.borderColor=\"#88AAFF\";window.status=\""+scrollRightMessage+"\"' onmouseout='clearInterval(intervalID1);swapImage(\"changeRight\",\"right1.gif\");this.style.borderColor=\"#3366FF\";window.status=\"\"' onclick='incMonth()' onmousedown='clearTimeout(timeoutID1);timeoutID1=setTimeout(\"StartIncMonth()\",500)'	onmouseup='clearTimeout(timeoutID1);clearInterval(intervalID1)'>&nbsp<IMG id='changeRight' SRC='"+imgDir+"right1.gif'	width=10 height=11 BORDER=0>&nbsp</span>&nbsp"
		  sHTML1+="<span id='spanMonth' style='border-style:solid;border-width:1;border-color:#3366FF;cursor:pointer'	onmouseover='swapImage(\"changeMonth\",\"drop2.gif\");this.style.borderColor=\"#88AAFF\";window.status=\""+selectMonthMessage+"\"' onmouseout='swapImage(\"changeMonth\",\"drop1.gif\");this.style.borderColor=\"#3366FF\";window.status=\"\"' onclick='popUpMonth()'></span>&nbsp;"
		  sHTML1+="<span id='spanYear' style='border-style:solid;border-width:1;border-color:#3366FF;cursor:pointer' onmouseover='swapImage(\"changeYear\",\"drop2.gif\");this.style.borderColor=\"#88AAFF\";window.status=\""+selectYearMessage+"\"'	onmouseout='swapImage(\"changeYear\",\"drop1.gif\");this.style.borderColor=\"#3366FF\";window.status=\"\"'	onclick='popUpYear()'></span>&nbsp;"
		}
		document.getElementById("caption").innerHTML  =	sHTML1
		bPageLoaded=true
	}
}

function hideCalendar()	{
	crossobj.visibility="hidden"
	if (crossMonthObj != null){crossMonthObj.visibility="hidden"}
	if (crossYearObj != null){crossYearObj.visibility="hidden"}
    	showElement( 'SELECT' );
	showElement( 'APPLET' );
}

function padZero(num) {
	return (num	< 10)? '0' + num : num ;
}

function constructDate(d,m,y)
{
	sTmp = dateFormat
	sTmp = sTmp.replace ("dd","<e>")
	sTmp = sTmp.replace ("d","<d>")
	sTmp = sTmp.replace ("<e>",padZero(d))
	sTmp = sTmp.replace ("<d>",d)
	sTmp = sTmp.replace ("mmm","<o>")
	sTmp = sTmp.replace ("mm","<n>")
	sTmp = sTmp.replace ("m","<m>")
	sTmp = sTmp.replace ("<m>",m+1)
	sTmp = sTmp.replace ("<n>",padZero(m+1))
	sTmp = sTmp.replace ("<o>",monthName[m])
	if (nowLang=="T") {
		y+=543;
	}
	return sTmp.replace ("yyyy",y)
}

function closeCalendar() {
	var sTmp
	hideCalendar();
	var selDate = constructDate(dateSelected,monthSelected,yearSelected)
	if ((yearSelected-0)<2400)	{
		yearSelected = (yearSelected-0) + 543;
	}
	monthSelected++;

	   ctlToPlaceValue.value = selDate;

}

// Month Pulldown
function StartDecMonth()
{
	intervalID1=setInterval("decMonth()",80)
}

function StartIncMonth()
{
	intervalID1=setInterval("incMonth()",80)
}

function incMonth () {
	monthSelected++
	if (monthSelected>11) {
		monthSelected=0
		yearSelected++
	}
	constructCalendar()
	hideElement( 'mask', document.getElementById("calendar") );  //------------ Modify for over listbox -------------//
}

function decMonth () {
	monthSelected--
	if (monthSelected<0) {
		monthSelected=11
		yearSelected--
	}
	constructCalendar()
	hideElement( 'mask', document.getElementById("calendar") );  //------------ Modify for over listbox -------------//
}

function constructMonth() {
	popDownYear()
	if (!monthConstructed) {
		sHTML =	""
		for	(i=0; i<12;	i++) {
			if (nowLang=="T") {
				sName = tmonthName[i];
			} else {
			   sName = monthName[i];
			}
			if (i==monthSelected){
				sName =	"<B>" +	sName +	"</B>"
			}
			sHTML += "<tr><td id='m" + i + "' onmouseover='this.style.backgroundColor=\"#FFCC99\"' onmouseout='this.style.backgroundColor=\"\"' style='cursor:pointer' onclick='monthConstructed=false;monthSelected=" + i + ";constructCalendar();popDownMonth();event.cancelBubble=true'>&nbsp;" + sName + "&nbsp;</td></tr>"
		}

		document.getElementById("selectMonth").innerHTML = "<table width=70	style='font-family:arial; font-size:11px; border-width:1; border-style:solid; border-color:#a0a0a0;' bgcolor='#FFFFDD' cellspacing=0 onmouseover='clearTimeout(timeoutID1)'	onmouseout='clearTimeout(timeoutID1);timeoutID1=setTimeout(\"popDownMonth()\",100);event.cancelBubble=true'>" +	sHTML +	"</table>"
		monthConstructed=true
	}
}

function popUpMonth() {
	constructMonth()
	crossMonthObj.visibility = (dom||ie)? "visible"	: "show"
	crossMonthObj.left = parseInt(crossobj.left) + 50
	crossMonthObj.top =	parseInt(crossobj.top) + 26

	hideElement( 'monthmask', document.getElementById("selectMonth") );  //------------ Modify for over listbox -------------//
	//hideElement( 'SELECT', document.getElementById("selectMonth") );
	//hideElement( 'APPLET', document.getElementById("selectMonth") );
}

function popDownMonth()	{
	crossMonthObj.visibility= "hidden"
	showElement();
	hideElement('mask',document.getElementById("calendar"));  //------------ Modify for over listbox -------------//
}

// Year Pulldown
function incYear() {
	for	(i=0; i<7; i++){
		newYear	= (i+nStartingYear)+1
		if (newYear==yearSelected) {
			if (nowLang=="T") {
				newYear+=543;
			}
			txtYear =	"&nbsp;<B>"	+ newYear +	"</B>&nbsp;"
		} else {
			if (nowLang=="T") {
				newYear+=543;
			}
			txtYear =	"&nbsp;" + newYear + "&nbsp;"
		}
		document.getElementById("y"+i).innerHTML = txtYear
	}
	nStartingYear ++;
	bShow=true
}

function decYear() {
	for	(i=0; i<7; i++){
		newYear	= (i+nStartingYear)-1
		if (newYear==yearSelected) {
			if (nowLang=="T") {
				newYear+=543;
			}
			txtYear =	"&nbsp;<B>"	+ newYear +	"</B>&nbsp;"
		} else	{
			if (nowLang=="T") {
				newYear+=543;
			}
			txtYear =	"&nbsp;" + newYear + "&nbsp;"
		}
		document.getElementById("y"+i).innerHTML = txtYear
	}
	nStartingYear --;
	bShow=true
}

function selectYear(nYear) {
	yearSelected=parseInt(nYear+nStartingYear);
	yearConstructed=false;
	constructCalendar();
	popDownYear();
}

function constructYear() {
	popDownMonth()
	sHTML =	""
	if (!yearConstructed) {
		sHTML =	"<tr><td align='center'	onmouseover='this.style.backgroundColor=\"#FFCC99\"' onmouseout='clearInterval(intervalID1);this.style.backgroundColor=\"\"' style='cursor:pointer'	onmousedown='clearInterval(intervalID1);intervalID1=setInterval(\"decYear()\",30)' onmouseup='clearInterval(intervalID1)'>-</td></tr>"
		j = 0
		nStartingYear =	yearSelected-3
		for	(i=(yearSelected-3); i<=(yearSelected+3); i++) {
			sName =	i;
			if (nowLang=="T") {
				sName+=543;
			}
			if (i==yearSelected){
				sName =	"<B>" +	sName +	"</B>"
			}
			sHTML += "<tr><td id='y" + j + "' onmouseover='this.style.backgroundColor=\"#FFCC99\"' onmouseout='this.style.backgroundColor=\"\"' style='cursor:pointer' onclick='selectYear("+j+");event.cancelBubble=true'>&nbsp;" + sName + "&nbsp;</td></tr>"
			j ++;
		}
		sHTML += "<tr><td align='center' onmouseover='this.style.backgroundColor=\"#FFCC99\"' onmouseout='clearInterval(intervalID2);this.style.backgroundColor=\"\"' style='cursor:pointer' onmousedown='clearInterval(intervalID2);intervalID2=setInterval(\"incYear()\",30)'	onmouseup='clearInterval(intervalID2)'>+</td></tr>"
		document.getElementById("selectYear").innerHTML	= "<table width=44 style='font-family:arial; font-size:11px; border-width:1; border-style:solid; border-color:#a0a0a0;'	bgcolor='#FFFFDD' onmouseover='clearTimeout(timeoutID2)' onmouseout='clearTimeout(timeoutID2);timeoutID2=setTimeout(\"popDownYear()\",100)' cellspacing=0>" + sHTML + "</table>"
		yearConstructed	= true
	}
}

function popDownYear() {
	clearInterval(intervalID1)
	clearTimeout(timeoutID1)
	clearInterval(intervalID2)
	clearTimeout(timeoutID2)
	crossYearObj.visibility= "hidden"

    //------------ Modify for over listbox -------------//
	showElement();
	hideElement('mask',document.getElementById("calendar"));
    //------------ Modify for over listbox -------------//
}

function popUpYear() {
	var leftOffset
	constructYear()
	crossYearObj.visibility	= (dom||ie)? "visible" : "show"
	leftOffset = parseInt(crossobj.left) + document.getElementById("spanYear").offsetLeft
	if (ie){
		leftOffset += 6
	}
	crossYearObj.left =	leftOffset
	crossYearObj.top = parseInt(crossobj.top) +	26

	hideElement('yearmask',document.getElementById("selectYear"));  //------------ Modify for over listbox -------------//
}

function WeekNbr(n) {
	// Algorithm used:
	// From Klaus Tondering's Calendar document (The Authority/Guru)
	// hhtp://www.tondering.dk/claus/calendar.html
	// a = (14-month) / 12
	// y = year + 4800 - a
	// m = month + 12a - 3
	// J = day + (153m + 2) / 5 + 365y + y / 4 - y / 100 + y / 400 - 32045
	// d4 = (J + 31741 - (J mod 7)) mod 146097 mod 36524 mod 1461
	// L = d4 / 1460
	// d1 = ((d4 - L) mod 365) + L
	// WeekNumber = d1 / 7 + 1

	year = n.getFullYear();
	month = n.getMonth() + 1;
	if (startAt == 0) {
		day = n.getDate() + 1;
	}
	else {
		day = n.getDate();
	}
	a = Math.floor((14-month) / 12);
	y = year + 4800 - a;
	m = month + 12 * a - 3;
	b = Math.floor(y/4) - Math.floor(y/100) + Math.floor(y/400);
	J = day + Math.floor((153 * m + 2) / 5) + 365 * y + b - 32045;
	d4 = (((J + 31741 - (J % 7)) % 146097) % 36524) % 1461;
	L = Math.floor(d4 / 1460);
	d1 = ((d4 - L) % 365) + L;
	week = Math.floor(d1/7) + 1;
	return week;
}

function constructCalendar () {
	var aNumDays = Array (31,0,31,30,31,30,31,31,30,31,30,31)
	var dateMessage
	var startDate =	new Date (yearSelected,monthSelected,1)
	var endDate
	if (monthSelected==1){
		endDate	= new Date (yearSelected,monthSelected+1,1);
		endDate	= new Date (endDate	- (24*60*60*1000));
		numDaysInMonth = endDate.getDate()
	}
	else{
		numDaysInMonth = aNumDays[monthSelected];
	}
	datePointer	= 0
	dayPointer = startDate.getDay() - startAt
	if (dayPointer<0){
		dayPointer = 6
	}
	sHTML =	"<table	 border=0 style='font-family:verdana;font-size:10px;'><tr>"
	if (showWeekNumber==1){
		if (nowLang=="T") {
		   sHTML += "<td width=27><b>" + weekThaiString + "</b></td><td width=1 rowspan=7 bgcolor='#d0d0d0' style='padding:0px'><img src='"+imgDir+"divider.gif' width=1></td>"
		} else {
		   sHTML += "<td width=27><b>" + weekString + "</b></td><td width=1 rowspan=7 bgcolor='#d0d0d0' style='padding:0px'><img src='"+imgDir+"divider.gif' width=1></td>"
		}
	}
	for	(i=0; i<7; i++)	{
		if (nowLang=="T") {
		   sHTML += "<td width='27' align='right'><B>"+ tdayName[i]+"</B></td>"
		} else {
		   sHTML += "<td width='27' align='right'><B>"+ dayName[i]+"</B></td>"
		}
	}
	sHTML +="</tr><tr>"
	if (showWeekNumber==1){
		sHTML += "<td align=right>" + WeekNbr(startDate) + "&nbsp;</td>"
	}
	for	( var i=1; i<=dayPointer;i++ ){
		sHTML += "<td>&nbsp;</td>"
	}
	for	( datePointer=1; datePointer<=numDaysInMonth; datePointer++ ){
		dayPointer++;
		sHTML += "<td align=right>"
		sStyle=styleAnchor
		if ((datePointer==odateSelected) &&	(monthSelected==omonthSelected)	&& (yearSelected==oyearSelected))
		{ sStyle+=styleLightBorder }
		sHint = ""
		for (k=0;k<HolidaysCounter;k++){
			if ((parseInt(Holidays[k].d)==datePointer)&&(parseInt(Holidays[k].m)==(monthSelected+1))){
				if ((parseInt(Holidays[k].y)==0)||((parseInt(Holidays[k].y)==yearSelected)&&(parseInt(Holidays[k].y)!=0))){
					sStyle+="background-color:#FFDDDD;"
					sHint+=sHint==""?Holidays[k].desc:"\n"+Holidays[k].desc
				}
			}
		}
		var regexp= /\"/g
		sHint=sHint.replace(regexp,"&quot;")
		dateMessage = "onmousemove='window.status=\""+selectDateMessage.replace("[date]",constructDate(datePointer,monthSelected,yearSelected))+"\"' onmouseout='window.status=\"\"' "
		if ((datePointer==dateNow)&&(monthSelected==monthNow)&&(yearSelected==yearNow))
		{ sHTML += "<b><a "+dateMessage+" title=\"" + sHint + "\" style='"+sStyle+"' href='javascript:dateSelected="+datePointer+";closeCalendar();'><font color=#ff0000>&nbsp;" + datePointer + "</font>&nbsp;</a></b>"}
		else if	(dayPointer % 7 == (startAt * -1)+1)
		{ sHTML += "<a "+dateMessage+" title=\"" + sHint + "\" style='"+sStyle+"' href='javascript:dateSelected="+datePointer + ";closeCalendar();'>&nbsp;<font color=#909090>" + datePointer + "</font>&nbsp;</a>" }
		else
		{ sHTML += "<a "+dateMessage+" title=\"" + sHint + "\" style='"+sStyle+"' href='javascript:dateSelected="+datePointer + ";closeCalendar();'>&nbsp;" + datePointer + "&nbsp;</a>" }

		sHTML += ""
		if ((dayPointer+startAt) % 7 == startAt) {
			sHTML += "</tr><tr>"
			if ((showWeekNumber==1)&&(datePointer<numDaysInMonth)){
				sHTML += "<td align=right>" + (WeekNbr(new Date(yearSelected,monthSelected,datePointer+1))) + "&nbsp;</td>"
			}
		}
	}
	document.getElementById("content").innerHTML   = sHTML
	if (nowLang=="T") {
   	   document.getElementById("spanMonth").innerHTML = "&nbsp;" + tmonthName[monthSelected] + "&nbsp;<IMG id='changeMonth' SRC='"+imgDir+"drop1.gif' WIDTH='12' HEIGHT='10' BORDER=0>"
	   document.getElementById("spanYear").innerHTML =	"&nbsp;" + (yearSelected+543)	+ "&nbsp;<IMG id='changeYear' SRC='"+imgDir+"drop1.gif' WIDTH='12' HEIGHT='10' BORDER=0>"
	} else {
   	   document.getElementById("spanMonth").innerHTML = "&nbsp;" + monthName[monthSelected] + "&nbsp;<IMG id='changeMonth' SRC='"+imgDir+"drop1.gif' WIDTH='12' HEIGHT='10' BORDER=0>"
	   document.getElementById("spanYear").innerHTML =	"&nbsp;" + yearSelected	+ "&nbsp;<IMG id='changeYear' SRC='"+imgDir+"drop1.gif' WIDTH='12' HEIGHT='10' BORDER=0>"
	}
}

function popUpCalendar(ctl,	ctl2, format,lang) {

	var leftpos=0
	var toppos=0

	if (lang!=null && lang=="T") {
	   nowLang="T";
	} else {
		nowLang="E";
	}

	init2();

	if (bPageLoaded){
		if ( crossobj.visibility ==	"hidden" ) {
			ctlToPlaceValue	= ctl2
			dateFormat=format;
			formatChar = " "
			aFormat	= dateFormat.split(formatChar)
			if (aFormat.length<3){
				formatChar = "/"
				aFormat	= dateFormat.split(formatChar)
				if (aFormat.length<3){
					formatChar = "."
					aFormat	= dateFormat.split(formatChar)
					if (aFormat.length<3){
						formatChar = "-"
						aFormat	= dateFormat.split(formatChar)
						if (aFormat.length<3){
							// invalid date	format
							formatChar=""
						}
					}
				}
			}
			tokensChanged =	0
			if ( formatChar	!= "" ){
				// use user's date
				aData =	ctl2.value.split(formatChar)
				for	(i=0;i<3;i++){
					if ((aFormat[i]=="d") || (aFormat[i]=="dd")){
						dateSelected = parseInt(aData[i], 10)
						tokensChanged ++
					}
					else if	((aFormat[i]=="m") || (aFormat[i]=="mm")){
						monthSelected =	parseInt(aData[i], 10) - 1
						tokensChanged ++
					}
					else if	(aFormat[i]=="yyyy"){
						if (nowLang=="T") {
							aData[i]-=543;
						}
						yearSelected = parseInt(aData[i], 10)
						tokensChanged ++
					}
					else if	(aFormat[i]=="mmm"){
						for	(j=0; j<12;	j++){
							if (aData[i]==monthName[j]){
								monthSelected=j
								tokensChanged ++
							}
						}
					}
				}
			}
			if ((tokensChanged!=3)||isNaN(dateSelected)||isNaN(monthSelected)||isNaN(yearSelected)){
				dateSelected = dateNow
				monthSelected =	monthNow
				yearSelected = yearNow
			}
			odateSelected=dateSelected
			omonthSelected=monthSelected
			oyearSelected=yearSelected
			aTag = ctl
			do {
				aTag = aTag.offsetParent;
				leftpos	+= aTag.offsetLeft;
				toppos += aTag.offsetTop;
			} while(aTag.tagName!="BODY");
			crossobj.left =	fixedX==-1 ? ctl.offsetLeft	+ leftpos :	fixedX
			crossobj.top = fixedY==-1 ?	ctl.offsetTop +	toppos + ctl.offsetHeight +	2 :	fixedY
			constructCalendar (1, monthSelected, yearSelected);
			crossobj.visibility=(dom||ie)? "visible" : "show"
			hideElement( 'mask', document.getElementById("calendar") );  //------------ Modify for over listbox -------------//
			//hideElement( 'SELECT', document.getElementById("calendar") );
			//hideElement( 'APPLET', document.getElementById("calendar") );
			bShow = true;
		}
		else{
			hideCalendar()
			if (ctlNow!=ctl) {popUpCalendar(ctl, ctl2, format)}
		}
		ctlNow = ctl
	}
}
