<%@ Page Title="" Language="C#" MasterPageFile="~/petshop18.Master" AutoEventWireup="true" CodeBehind="Menu_NewAppointment.aspx.cs" Inherits="COMP214_PetShopGUI.Menu_NewAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
* * New Appointment * * <hr />

<table style="width:60%">
<tr>
<td>VET ID: </td>
<td><asp:DropDownList ID="vetIDList" runat="server"></asp:DropDownList></td>
</tr>

<tr>
<td>Customer Name:</td>
<td><asp:DropDownList ID="cusIDList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="selectcustomer" ></asp:DropDownList></td>
</tr>

<tr>
<td>Pet Name: </td>
<td><asp:DropDownList ID="petIDList" runat="server"></asp:DropDownList></td> 
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
<td><asp:TextBox ID="note" runat="server"></asp:TextBox>  </td> 
</tr>

<tr>
<td>Price: </td>
<td><asp:TextBox ID="price" runat="server"></asp:TextBox>  </td> 
</tr>

</table>

<asp:Button ID="seeDetail" runat="server" Text="See Detail" CssClass="Btn" BorderStyle="None" OnClick="seeDetail_Click" /><br />

<div class="apptdetail">
<asp:Label ID="check" runat="server" Text="New Appointment Detail display here" ></asp:Label>
</div>
<asp:Button ID="saveAppointment" runat="server" Text="Save Appointment"  BorderStyle="None"   CssClass="Btn" BackColor="#009900" OnClick="saveAppointment_Click"/>&nbsp;
<asp:Button ID="sendConfirmEmail" runat="server" Text="Send Email" CssClass="Btn" BorderStyle="None" BackColor="#003399"  /> <br />
<asp:Label ID="check1" runat="server" Text="New Appointment Detail display here" ></asp:Label>

</asp:Content>
