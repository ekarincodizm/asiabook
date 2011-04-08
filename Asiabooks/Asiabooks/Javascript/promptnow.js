function num_only(e) {
    var key = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
    if ((key < 48 || key > 57 || key == 47) && (key != 13)) {
        event.returnValue = false;
		return false;
    }else{
		return true;
	}
} 

function wait() {
    document.getElementById("divWait").style.display = "block";
}

function ads_wait() {
    document.getElementById("div_adsWait").style.display = "block";
}

function onchange_format() {
    var div = document.getElementById("lb1");
    var dropdown = document.getElementById("ddl");
    var i = dropdown.getElementsByTagName("select")[0].selectedIndex;
    var text = dropdown.getElementsByTagName("select")[0].options[i].text;
    
    if (dropdown.getElementsByTagName("select")[0].value != "temp") {
        var split1 = text.split("::");
        var split2 = split1[2].split("(");
        var split3 = split2[1].split(")");
        div.style.display = "block";
        div.getElementsByTagName("label")[0].innerHTML = "Format : " + dropdown.getElementsByTagName("select")[0].value;
        div.getElementsByTagName("label")[1].innerHTML = "Your Price : " + split1[1];
        div.getElementsByTagName("label")[2].innerHTML = split3[0];
    } else {
        div.style.display = "none";
    }
}

function book_display_none() {
    document.getElementById("tab_book").style.display = "none";
}
function ebook_display_none() {
    document.getElementById("tab_ebook").style.display = "none";
}
function date() {
    var a = document.getElementById('ctl00_ContentPlaceHolder1_textbox_startDate');
    var aa = a.value.split("-");
    var b = document.getElementById('ctl00_ContentPlaceHolder1_textbox_endDate');
    var bb = b.value.split("-");
    var startDate = new Date(aa[0], aa[1], aa[2], 0, 0, 0, 0);
    var endDate = new Date(bb[0], bb[1], bb[2], 0, 0, 0, 0);

    if (startDate <= endDate) {
        return true;
    } else {
        alert('เกิดข้อผิดพลาด  วันที่ตั้งต้นมีค่ามากกว่าวันที่เป้าหมาย');
        return false;
    }
}

function noCopyMouse(e) {
    var isRight = (e.button) ? (e.button == 2) : (e.which == 3);
    
    if (isRight) {
        alert('Not allow to copy/paste !!');
        return false;
    }
    return true;
}

function noCopyKey(e) {
    var forbiddenKeys = new Array('c', 'x', 'v');
    var keyCode = (e.keyCode) ? e.keyCode : e.which;
    var isCtrl;

    if (window.event)
        isCtrl = e.ctrlKey
    else
        isCtrl = (window.Event) ? ((e.modifiers & Event.CTRL_MASK) == Event.CTRL_MASK) : false;

    if (isCtrl) {
        for (i = 0; i < forbiddenKeys.length; i++) {
            if (forbiddenKeys[i] == String.fromCharCode(keyCode).toLowerCase()) {
                alert('Not allow to copy/paste !!');
                return false;
            }
        }
    }
    return true;
}