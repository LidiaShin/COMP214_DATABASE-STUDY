<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu_ReIssuePresc.aspx.cs" MasterPageFile="~/petshop18.master"  Inherits="COMP214_PetShopGUI.reIssue" %>
<asp:Content ID="content1" ContentPlaceHolderID="main" runat="server">
	<!DOCTYPE html>

<strong> * * ReIssue Prescription * *  </strong> <br /><br />
	1. Please input customer's last name or first name & select prescription to be reissued <br />

	&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="cusNameInput" runat="server" placeholder="Type part of the name"></asp:TextBox>
	<asp:Button ID="searchPresc" runat="server" Text="Search"  CssClass="Btn" OnClick="searchPresc_Click"  /> <br /> <hr />
	<asp:HiddenField ID="hdnText" runat="server" ClientIDMode="Static" Value="" /> 

<asp:ListView ID="PrescListTable" runat="server"  GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging" >

	<LayoutTemplate>

   <div id="apptListTable">
	<table style="border-collapse: collapse; margin:auto; width: 70%;">
		
	 <tr id="apptListHeader">	 
     <th>ID</th>
     <th>PET</th>
     <th>ISSUE DATE</th>
	 <th>REISSUE</th>
	 </tr>
   

    <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>

	<tr><td colspan = "5" style="background-color:#fcf2f6">
    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="PrescListTable" PageSize="5">


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
        <td><%# Eval("PET") %></td>
		<td><%# Eval("ISSUEDATE") %></td>		
        <td><asp:Button ID="rePresc" runat="server" Text="SELECT" CommandArgument='<%# Eval("NO") %>' CssClass="Btn" BorderStyle="None" BackColor="#666699" OnClick="ViewPescription"/></td>

        </ItemTemplate>

	</asp:ListView>
	<hr />
	<div id="printpresc1">
	Prescription No: <asp:Label ID="PrescID" runat="server" Text="ID"></asp:Label><br />
	<asp:GridView ID="SeePresc" runat="server" style="margin:auto;"></asp:GridView> <br />
	</div>


	<asp:Button ID="RePresc" runat="server"  Text="REISSUE"  CssClass="Btn"  OnClientClick="return confirmReissue();" BackColor="#CC0099" ForeColor="#FFCCFF"  /> &nbsp; 
    <input name="printRePresc" type="button" class="Btn" style="background-color:slateblue" onclick="PrintRePresc('printpresc1');" value=" Print "><br />

</asp:Content>
