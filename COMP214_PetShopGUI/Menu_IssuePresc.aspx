<%@ Page Language="C#" MasterPageFile="~/petshop18.Master" AutoEventWireup="true" CodeBehind="Menu_IssuePresc.aspx.cs" Inherits="COMP214_PetShopGUI.Menu_IssuePresc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
<h3>	* *Start Issue New Prescription * * </h3>

<hr />

<strong>1. Please select Pet's ID </strong>&nbsp; &nbsp;
<asp:DropDownList ID="PetIDList" runat="server"></asp:DropDownList>&nbsp;
<asp:Button ID="StartIssue" runat="server" Text="Start Issue" BorderStyle="None" CssClass="Btn" OnClick="StartIssue_Click" /><br />

<div id="printpresc1" style="padding:10px;">
PET ID: <asp:Label ID="displayPetID" runat="server" Text="PET ID" BackColor="#FFFFE8"></asp:Label><br />
PRESCRIPTION NO: <asp:Label ID="displayPrescID" runat="server" Text="PRESCRIPTION NO" BackColor="#FFFFE8"></asp:Label><br />
</div>
<br />

<strong>2. Please choose Medication  & Quantity </strong><br />


<table style="width:70%; padding:10px;">


<tr>
<td> Name: </td>
<td><asp:DropDownList ID="MedList" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="MedList_SelectedIndexChanged"></asp:DropDownList></td>
</tr>

<tr>
<td>Quantity:</td> 	
<td><asp:TextBox ID="InputQty" runat="server"></asp:TextBox>
<asp:Button ID="AddMed" runat="server" Text="Add" BorderStyle="None" CssClass="Btn" BackColor="Blue" ForeColor="White" OnClick="AddMed_Click" />
<asp:Button ID="DelMed" runat="server" Text="Del" BorderStyle="None" CssClass="Btn"  BackColor="#009999" ForeColor="White" OnClick="DelMed_Click" />
</td>
</tr> 
</table> 

<div id="printpresc2" style="width:80%; margin:auto;">

<hr />

<div class="meditem box" style="text-align:center; font-weight: 700;" runat="server" id="mednameheader" visible="False"  >
NAME
</div>

<div class="medid box" style="font-weight: 700;" runat="server" id="medidheader" visible="False">
MED ID
</div>

<div class="medqty box" style="font-weight: 700;" runat="server" id="medqtyheader" visible="False">
QUANTITY
</div>

<hr />


</div>

<div id="printpresc3" style="width:80%; margin:auto;">

<div class="meditem box" id="mediitems">
<asp:Label ID="lblmedilist" runat="server" Text="linkedlist - item"></asp:Label> 
</div>

<div class="medid box">
<asp:Label ID="lblmediidlist" runat="server" Text="linkedlist - id"></asp:Label>
</div>

<div class="medqty box">
<asp:Label ID="lblmediqtylist" runat="server" Text="linkedlist - qty"></asp:Label>
</div>

</div>


<div id="hidden"  >
	
		<asp:Label ID="mlists" runat="server" Text=""></asp:Label>
</div>



<hr />
<asp:Button ID="savePresc" runat="server" Text="SAVE"  CssClass="Btn" OnClick="save" OnClientClick="return confirmSave();" /> &nbsp; 
<input name="printPresc" type="button" class="Btn" onclick="PrintPresc('printpresc1','printpresc2','printpresc3');" value=" Print "><br />
<asp:Label ID="test" runat="server" Text=""></asp:Label>

<hr />


<div>
3. Confirm <br /> <br />


4. Print <br />


4. Issue <br />
</div>






</asp:Content>
