<%@ Page Language="C#" MasterPageFile="~/petshop18.Master" AutoEventWireup="true" CodeBehind="Menu_IssuePresc.aspx.cs" Inherits="COMP214_PetShopGUI.Menu_IssuePresc" %>


<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">

* *Start Isssue New Prescription * * <hr />

1. Please select Pet's ID &nbsp; &nbsp;
<asp:DropDownList ID="PetIDList" runat="server"></asp:DropDownList>&nbsp;
<asp:Button ID="StartIssue" runat="server" Text="Start Issue" BorderStyle="None" CssClass="Btn" OnClick="StartIssue_Click" /><br />
<asp:Label ID="status1" runat="server" Text="status 1" BackColor="#FFFFE8"></asp:Label>
<br /><br />

	


2. Please choose Medication  & Quantity <br />
<table style="width:70%">

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
<!--
<asp:Label ID="med1" runat="server" Text="med1" BackColor="#FFFFE8"></asp:Label>
<asp:Label ID="med1qty" runat="server" Text="qty1" BackColor="#FFFFE8"></asp:Label>
<br />

<asp:Label ID="med2" runat="server" Text="med2" BackColor="#FFFFE8"></asp:Label>
<asp:Label ID="med2qty" runat="server" Text="qty2" BackColor="#FFFFE8"></asp:Label>
<br />

<asp:Label ID="med3" runat="server" Text="med3" BackColor="#FFFFE8"></asp:Label>
<asp:Label ID="med3qty" runat="server" Text="qty3" BackColor="#FFFFE8"></asp:Label>
<br />

<asp:Label ID="med4" runat="server" Text="med4" BackColor="#FFFFE8"></asp:Label>
<asp:Label ID="med4qty" runat="server" Text="qty4" BackColor="#FFFFE8"></asp:Label>
<br />

<asp:Label ID="med5" runat="server" Text="med5" BackColor="#FFFFE8"></asp:Label>
<asp:Label ID="med5qty" runat="server" Text="qty5" BackColor="#FFFFE8"></asp:Label>
<br />
-->
<asp:Literal ID="meditemslist" runat="server"></asp:Literal>

<br />
3. Confirm <br />

4. Issue <br />








</asp:Content>
