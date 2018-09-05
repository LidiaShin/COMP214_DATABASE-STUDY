<%@ Page Title="" Language="C#" MasterPageFile="~/petshop18.Master" AutoEventWireup="true" CodeBehind="Menu_Register.aspx.cs" Inherits="COMP214_PetShopGUI.registerCustomer" UnobtrusiveValidationMode="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">

<strong> ▶  Register New Customer</strong>
<hr />

<div>
<table style="width:60%">

<tr>
<td> <span style="color:red;">*</span> First Name : </td> 
<td><asp:TextBox ID="fName" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="reqFname" runat="server" ErrorMessage=" * Please enter the first name "  ControlToValidate="fName" CssClass="errorMsg"></asp:RequiredFieldValidator>
</td>
</tr>



<tr>
<td><span style="color:red;">*</span> Last Name: </td> 
<td><asp:TextBox ID="lName" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="reqLname" runat="server" ErrorMessage=" * Please enter the last name "  ControlToValidate="lName" CssClass="errorMsg"></asp:RequiredFieldValidator>
</td>
</tr>


<tr>
<td><span style="color:red;">*</span> Phone: </td> 
<td><asp:TextBox ID="pNumber" runat="server"></asp:TextBox>
<asp:Label ID="pnumCheck" runat="server" CssClass="errorMsg" Visible="False"></asp:Label>
</td>
</tr>



<tr>
<td><span style="color:red;">*</span> Email: </td>
<td><asp:TextBox ID="eMail" runat="server" ></asp:TextBox>
	<asp:Label ID="emailCheck" runat="server" CssClass="errorMsg" Visible="False"></asp:Label>
</td>
</tr>

</table>

</div>
&nbsp;&nbsp;<asp:Button ID="checkEmail" runat="server" Text="check" CssClass="Btn" OnClick="checkPnumEmail_Click" /> &nbsp;
<asp:Button ID="register" runat="server" Text="Register"  OnClick="register_Click" CssClass="Btn" BorderStyle="None"  Visible="False" BackColor="#CC0099" ForeColor="#FFCCFF" /><br />

<br /><br />

<strong> ▶  Register New Pet </strong>
<hr />

<table style="width:60%">

<tr>
<td> <span style="color:red;">*</span> Owner : </td>
<td><asp:DropDownList ID="OwnerID" runat="server"></asp:DropDownList></td>
</tr>

<tr>
<td> <span style="color:red;">*</span> Pet Name : </td> 
<td><asp:TextBox ID="pname" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td> <span style="color:red;">*</span> BirthDay: </td>
<td>
<asp:DropDownList ID="year" runat="server"></asp:DropDownList>
<asp:DropDownList ID="month" runat="server" AutoPostBack="True" OnSelectedIndexChanged="selectmonth" ></asp:DropDownList>
<asp:DropDownList ID="day" runat="server" AutoPostBack="True" OnSelectedIndexChanged="selectdate"></asp:DropDownList>
</td>
</tr>

</table>
&nbsp; <asp:Button ID="registerPet" runat="server" Text="Add new pet" OnClick="registerPet_Click" CssClass="Btn" BorderStyle="None" CausesValidation="False"/><br />
<asp:Label ID="test" runat="server" Text="" CausesValidation="False"></asp:Label>

</asp:Content>
