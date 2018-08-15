<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testTblPET.aspx.cs" Inherits="COMP214_PetShopGUI.testTblPET" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PET TABLE TEST</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

			<div>
			<p>test table section</p> 
			pet ID: <asp:TextBox ID="petid" runat="server"></asp:TextBox><br />
			<asp:Button ID="check" runat="server" Text="Button" OnClick="check_Click"/><br />
			pet name: <asp:Label ID="pname" runat="server" Text="Label"></asp:Label><br />
			pet birthday: <asp:Label ID="pbirthday" runat="server" Text="Label"></asp:Label><br />
			owner name: <asp:Label ID="oname" runat="server" Text="Label"></asp:Label>





		</div>
        </div>
    </form>
</body>
</html>
