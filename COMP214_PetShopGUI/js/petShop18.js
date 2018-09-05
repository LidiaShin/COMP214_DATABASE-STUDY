function PrintPresc(printpage1,printpage2,printpage3) {

	var printform = "<div class='printPrescForm'> <p>PRESCRIPTION </p><br>";

	var issueDate = new Date();

	var res = "<div class ='printPrescForm content'> Issue Date: " + issueDate.toISOString().slice(0, 10) + "<hr>";



	var content1 = document.all.item(printpage1).innerHTML;

	var content2 = "<div style='border: 1px solid #777f7b; padding:5px'>" + document.all.item(printpage2).innerHTML;

	var content3 =  document.all.item(printpage3).innerHTML + "</div>";

	var oldstr = document.body.innerHTML;

	document.body.innerHTML = printform + res + "<br>" + content1 + "<br>" + content2 + content3+ "</div>" + "</div>";

	window.print();
	document.body.innerHTML = oldstr;

	return false;
}

function PrintRePresc(printpage1) {

	var printform = "<div class='printPrescForm'> <p>PRESCRIPTION </p><br>";

	var issueDate = new Date();

	var res = "<div class ='printPrescForm content'> Issue Date: " + issueDate.toISOString().slice(0, 10) + "<hr>";



	var content1 = document.all.item(printpage1).innerHTML;

	

	var oldstr = document.body.innerHTML;

	document.body.innerHTML = printform + res + "<br>" + content1 + "<br>" + "</div>" + "</div>";

	window.print();
	document.body.innerHTML = oldstr;

	return false;
}

//var x = document.getElementById("printpresc3").value;

function confirmSave() {
	var msg = 'Do you want issue the prescription?';
	var y = "";
	y = document.getElementById('hidden').innerText;
	var result = window.confirm(msg + '\n' + y);

	
	if (result == true)
		return true;
	else
		return false;
}

function confirmReissue() {
	var msg = 'Do you want reissue the prescription?';
	var y = "";
	y = document.getElementById('hidden').innerText;
	var result = window.confirm(msg + '\n' + y);


	if (result == true)
		return true;
	else
		return false;
}


function confirmCancel() {
	var msg = 'Do you want to cancel this appointment?';
	//var y = "";
	//y = document.getElementById('hidden').innerText;
	var result = window.confirm(msg);


	if (result == true)
		return true;
	else
		return false;
}

