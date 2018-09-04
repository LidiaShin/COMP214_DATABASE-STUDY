<%@ Page Title="" Language="C#" MasterPageFile="~/petshop18.Master" AutoEventWireup="true" CodeBehind="Menu_ChangeAppointment.aspx.cs" Inherits="COMP214_PetShopGUI.Menu_ChangeAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">

<strong>* * Change Appointment * * </strong>
	<hr />

	<strong>1. Please Input Customer's Name </strong> <br />
	&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="cusNameInput" runat="server" placeholder="Type part of the name"></asp:TextBox>
	<asp:Button ID="searchAppt" runat="server" Text="Search"  CssClass="Btn" OnClick="searchAppt_Click" /> <br />
	
	
	<hr />

<asp:HiddenField ID="hdnText" runat="server" ClientIDMode="Static" Value="" /> 

<asp:ListView ID="ApptListTable" runat="server"  GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging" >

	<LayoutTemplate>

   <div id="apptListTable">
	<table style="border-collapse: collapse; margin:auto;">
		
	 <tr id="apptListHeader">
		 
     <th id="apptListHeaderItem">ID</th>
     <th style="width:200px;">PET's ID</th>
     <th style="width:200px;">PET's NAME</th>
     <th style="width:200px;">CUSTOMER</th>
     <th style="width:200px;">DATE&TIME</th>
	 <th style="width:120px;">CANCEL</th>
	 <th style="width:120px;">CHANGE</th>
			
		</tr>
   

    <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>

	<tr><td colspan = "7" style="background-color:#fcf2f6">
    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ApptListTable" PageSize="5">


	<Fields>
    <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                            ShowNextPageButton="false" />
    <asp:NumericPagerField ButtonType="Link" />
    <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton = "false" />
    </Fields>

	</asp:DataPager>
	</td></tr>

    </table>
	</div>
	</LayoutTemplate>

		<GroupTemplate>
        <tr>
        <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
        </tr>
        </GroupTemplate>

		<ItemTemplate>

        <td><%# Eval("NO") %></td>
        <td><%# Eval("PET_ID") %></td>
		<td><%# Eval("PET") %></td>
		<td><%# Eval("CUSTOMER") %></td>
		<td><%# Eval("APPOINTMENT") %></td>
        <td><asp:Button ID="Cancel" runat="server" Text="CANCEL" CommandArgument='<%# Eval("NO") %>' CssClass="Btn" BorderStyle="None" OnClientClick="return confirmCancel();" OnClick="CancelAppt"  BackColor="#666699" /></td>
        <td><asp:Button ID="Change" runat="server" Text="CHANGE" CssClass="Btn" CommandArgument='<%# Eval("NO") %>' BorderStyle="None"  OnClick="ChangeAppt"  BackColor="#009900" ForeColor="#CCFFCC" /></td>

        </ItemTemplate>
	</asp:ListView>

	
		<hr />
	<strong>2. Please reschedule time </strong> <br />
	
	
	<table style="margin-left:20px;">
	    <tr>
        <td>Appointment No : </td>
	    <td> <asp:Label ID="ApptNo" runat="server"  Text="Appointment Number"></asp:Label></td>
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

	</table>
	
	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="ConfirmChange" runat="server" Text="Confirm"  CssClass="Btn" BackColor="#CC0099" ForeColor="#FFCCCC" OnClick="ConfirmChange_Click" /><br />

	<asp:Label ID="check" runat="server" Text=""></asp:Label>

</asp:Content>
