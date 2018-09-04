<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu_ReIssuePresc.aspx.cs" MasterPageFile="~/petshop18.master"  Inherits="COMP214_PetShopGUI.reIssue" %>
<asp:Content ID="content1" ContentPlaceHolderID="main" runat="server">
	<!DOCTYPE html>



<div id="signupBox2">
ReIsuse Prescription
	<p> Please input prescription number. </p>

	<asp:TextBox ID="preID" runat="server"></asp:TextBox>
	<asp:Button ID="checkPreID" runat="server" Text="input" OnClick="checkPreID_Click" CssClass="Btn" BorderStyle="None" /><br /> <br />
	prescription table
	<asp:Button ID="checkTable" runat="server" Text="check" OnClick="checkTable_Click" CssClass="Btn" BorderStyle="None"  /><hr />
   <asp:GridView ID="prescriptiontable" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" AllowPaging="True">
		
		
		
		<Columns>
			<asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
			<asp:BoundField DataField="ORDER_DATE" HeaderText="ORDER_DATE" SortExpression="ORDER_DATE" />
			
			<asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" />
			
			
			<asp:BoundField DataField="PRE_ID" HeaderText="PRE_ID" SortExpression="PRE_ID" />
		</Columns>
	</asp:GridView>



	<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM &quot;PRESCRIPTION_ISSUELOG&quot;"></asp:SqlDataSource>

</div>

</asp:Content>
