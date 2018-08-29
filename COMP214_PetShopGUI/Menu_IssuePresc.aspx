<%@ Page Language="C#" MasterPageFile="~/petshop18.Master" AutoEventWireup="true" CodeBehind="Menu_IssuePresc.aspx.cs" Inherits="COMP214_PetShopGUI.Menu_IssuePresc" %>




<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">

	* *Start Issue New Prescription * * <hr />

1. Please select Pet's ID &nbsp; &nbsp;
<asp:DropDownList ID="PetIDList" runat="server"></asp:DropDownList>&nbsp;
<asp:Button ID="StartIssue" runat="server" Text="Start Issue" BorderStyle="None" CssClass="Btn" OnClick="StartIssue_Click" /><br />

<div id="printpresc1" style="padding:10px;">
PET ID: <asp:Label ID="displayPetID" runat="server" Text="PET ID" BackColor="#FFFFE8"></asp:Label><br />
PRESCRIPTION NO: <asp:Label ID="displayPrescID" runat="server" Text="PRESCRIPTION NO" BackColor="#FFFFE8"></asp:Label><br />
</div>
<br />

2. Please choose Medication  & Quantity <br />
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

<div id="printpresc2">

<div class="meditem box" style="text-align:center;" runat="server" id="meditemboxheader" visible="False">
NAME
</div>

<div class="medqty box" runat="server" id="medqtyheader" visible="False">
QUANTITY
</div>

</div>

<div id="printpresc3">

<div class="meditem box">
<asp:Literal ID="meditemslist" runat="server"></asp:Literal>
</div>

<div class="medqty box">
<asp:Literal ID="meditemsqty" runat="server"></asp:Literal>

</div>

</div>

<hr />


<asp:Label ID="linkedlisttest" runat="server" Text="linkedlist"  BackColor="#FFCCCC"></asp:Label> <br /><br />

<asp:Button ID="savePresc" runat="server" Text="savetest"  CssClass="Btn" />
<hr />
<div>
3. Confirm <br /> <br />


4. Print <br />
<input name="printPresc" type="button" class="Btn" onclick="PrintPresc('printpresc1','printpresc2','printpresc3');" value=" Print "><br />

4. Issue <br />
</div>






</asp:Content>
