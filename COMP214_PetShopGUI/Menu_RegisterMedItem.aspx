<%@ Page Title="" Language="C#" MasterPageFile="~/petshop18.Master" AutoEventWireup="true" CodeBehind="Menu_RegisterMedItem.aspx.cs" Inherits="COMP214_PetShopGUI.Menu_RegisterMedItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
<strong>	▶ Register New Item  </strong>
<br /><br />
Please fill out the form below
<hr />

<table style="width:60%">
<tr>
<td>Manufacturer ID :  </td>
<td><asp:TextBox ID="NewManuID" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td>Manufacturer Reference # : </td>
<td><asp:TextBox ID="NewManuRF" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td>Medication Name: </td>
<td><asp:TextBox ID="NewMedName" runat="server"></asp:TextBox></td> 
</tr>

<tr>
<td>Medication Price: </td>
<td><asp:TextBox ID="NewMedPrice" runat="server"></asp:TextBox></td> 
</tr>
</table>
<hr />
<asp:Button ID="RegisterNewMed" runat="server" Text="Register" CssClass="Btn"   BorderStyle="None" OnClick="RegisterNewMed_Click" />





</asp:Content>
