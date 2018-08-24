<%@ Page Title="" Language="C#" MasterPageFile="~/petshop18.Master" AutoEventWireup="true" CodeBehind="Menu_Register.aspx.cs" Inherits="COMP214_PetShopGUI.registerCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">

* * Register New Customer * * <hr />
<table style="width:60%">
<tr>
<td>First Name : </td> 
<td><asp:TextBox ID="fName" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td>Last Name: </td> 
<td><asp:TextBox ID="lName" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td>Phone: </td> 
<td><asp:TextBox ID="pNumber" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td>Email: </td>
<td><asp:TextBox ID="eMail" runat="server"></asp:TextBox>
<asp:Label ID="emailCheck" runat="server" Text="" BackColor="#CCCCFF" BorderStyle="None" ForeColor="#CC00CC"></asp:Label></td>
</tr>

</table>
<asp:Button ID="register" runat="server" Text="Register" OnClick="register_Click" CssClass="Btn" BorderStyle="None" /><br />
<br /><br />

* * Register New Pet * * <hr />
<table style="width:60%">

<tr>
<td>Owner ID : </td>
<td><asp:DropDownList ID="OwnerID" runat="server"></asp:DropDownList></td>
</tr>

<tr>
<td>Pet Name: </td> 
<td><asp:TextBox ID="pname" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td>BirthDay: </td>
<td>
<asp:DropDownList ID="year" runat="server"></asp:DropDownList>
<asp:DropDownList ID="month" runat="server" AutoPostBack="True" OnSelectedIndexChanged="selectmonth" ></asp:DropDownList>
<asp:DropDownList ID="day" runat="server" AutoPostBack="True" OnSelectedIndexChanged="selectdate"></asp:DropDownList>
</td>
</tr>
</table>
<asp:Button ID="registerPet" runat="server" Text="Add new pet" OnClick="registerPet_Click" CssClass="Btn" BorderStyle="None" /><br />
<asp:Label ID="checking" runat="server" Text="Label"></asp:Label>

</asp:Content>
