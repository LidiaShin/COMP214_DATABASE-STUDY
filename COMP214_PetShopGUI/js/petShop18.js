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