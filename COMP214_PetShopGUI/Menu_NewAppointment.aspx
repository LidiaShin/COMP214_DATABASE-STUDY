<%@ Page Title="" Language="C#" MasterPageFile="~/petshop18.Master" AutoEventWireup="true" CodeBehind="Menu_NewAppointment.aspx.cs" Inherits="COMP214_PetShopGUI.Menu_NewAppointment" UnobtrusiveValidationMode="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
<strong>* * New Appointment * * </strong>

<hr />

<table style="width:60%">
<tr>
<td>VET : </td>
<td><asp:DropDownList ID="vetIDList" runat="server" CausesValidation="True" AppendDataBoundItems="True" >
	<asp:ListItem Text="- Choose VET - " Selected="True" Value=""></asp:ListItem>
    </asp:DropDownList>
	<asp:RequiredFieldValidator ID="reqVetID" runat="server" ErrorMessage=" * Please select VET " ControlToValidate="vetIDList"  CssClass="errorMsg"></asp:RequiredFieldValidator>
</td>
</tr>

<tr>
<td>Customer : </td>
<td><asp:DropDownList ID="cusIDList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="selectcustomer" AppendDataBoundItems="True" >
	<asp:ListItem Text="- Choose Customer - " Selected="True" Value=""></asp:ListItem>
    </asp:DropDownList>
	<asp:RequiredFieldValidator ID="reqCusID" runat="server" ErrorMessage=" * Please select Customer " ControlToValidate="cusIDList"  CssClass="errorMsg"></asp:RequiredFieldValidator>
</td>
</tr>

<tr>
<td>Pet Name : </td>
<td><asp:DropDownList ID="petIDList" runat="server" AppendDataBoundItems="True">
	<asp:ListItem Text="- Choose Pet - " Selected="True" Value=""></asp:ListItem>
    </asp:DropDownList>
	<asp:RequiredFieldValidator ID="reqPetID" runat="server" ErrorMessage=" * Please select Pet " ControlToValidate="petIDList"  CssClass="errorMsg"></asp:RequiredFieldValidator>
</td> 
</tr>

<tr>
<td>Date :</td>
<td>
<asp:DropDownList ID="year" runat="server"></asp:DropDownList>
<asp:DropDownList ID="month" runat="server" AutoPostBack="True" OnSelectedIndexChanged="selectmonth" ></asp:DropDownList>
<asp:DropDownList ID="day" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="selectday" ></asp:DropDownList>
</td>
</tr>

<tr>
<td>Time: </td>
<td><asp:DropDownList ID="time" runat="server" AutoPostBack="True" OnSelectedIndexChanged="selecttime" ></asp:DropDownList></td>
</tr>

<tr>
<td>Note: </td>
<td><asp:TextBox ID="note" runat="server"></asp:TextBox> 
	<asp:RequiredFieldValidator ID="reqNote" runat="server" ErrorMessage=" * Please leave note here " ControlToValidate="note"  CssClass="errorMsg"></asp:RequiredFieldValidator>
</td> 
</tr>

<tr>
<td>Price: </td>
<td><asp:TextBox ID="price" runat="server"></asp:TextBox> 
	<asp:RequiredFieldValidator ID="reqPrice" runat="server" ErrorMessage=" * Please insert price here " ControlToValidate="note"  CssClass="errorMsg"></asp:RequiredFieldValidator>
</td> 
</tr>

</table>

&nbsp; &nbsp;<asp:Button ID="ConfirmDetail" runat="server" Text="Confirm" CssClass="Btn" BorderStyle="None" OnClick="Confirm" /><br />

<div class="apptdetail">
<asp:Label ID="fname" runat="server" Text="first name" Visible="False"></asp:Label><br />
<asp:Label ID="details" runat="server" Text="New Appointment Detail display here" ></asp:Label><br />
<asp:Label ID="email" runat="server" Text="email"  Visible="False" ></asp:Label>
</div>
&nbsp;&nbsp; &nbsp;<asp:Button ID="saveAppointment" runat="server" Text="Save Appointment"  BorderStyle="None"   CssClass="Btn"  OnClick="saveAppointment_Click" BackColor="#660066" ForeColor="#FFCCFF" />&nbsp;
&nbsp;<asp:Button ID="sendConfirmEmail" runat="server" Text="Send Email" CssClass="Btn" BorderStyle="None"  OnClick="sendConfirmEmail_Click"  BackColor="#000099" ForeColor="#99CCFF" /> <br />
<br />


</asp:Content>
