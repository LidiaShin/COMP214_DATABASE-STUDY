<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestConnectionPage.aspx.cs" Inherits="COMP214_PetShopGUI.TestConnectionPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

			<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1">
				<Columns>
					<asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
					<asp:BoundField DataField="ORDER_DATE" HeaderText="ORDER_DATE" SortExpression="ORDER_DATE" />
					<asp:BoundField DataField="DISCOUNT" HeaderText="DISCOUNT" SortExpression="DISCOUNT" />
					<asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" />
					<asp:BoundField DataField="PETID" HeaderText="PETID" SortExpression="PETID" />
					<asp:BoundField DataField="EXTRA" HeaderText="EXTRA" SortExpression="EXTRA" />
					<asp:BoundField DataField="PRE_ID" HeaderText="PRE_ID" SortExpression="PRE_ID" />
				</Columns>
			</asp:GridView>

        	<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM &quot;PRESCRIPTION&quot;"></asp:SqlDataSource>

        </div>


		
    </form>
</body>
</html>
