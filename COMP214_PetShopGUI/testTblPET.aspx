<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testTblPET.aspx.cs" MasterPageFile="~/petshop18.master" Inherits="COMP214_PetShopGUI.testTblPET" %>
<asp:Content ID="content1" ContentPlaceHolderID="main" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    

<body>


<asp:Image ID="Image1" runat="server"  ImageUrl="~/images/homeImage.jpg" Width="300px" Height="300px" style="float:left;"/>
<div id="signupBox">
pet ID: <asp:TextBox ID="petid" runat="server"></asp:TextBox> &nbsp;&nbsp;

<asp:Button ID="check" runat="server" Text="Check"  OnClick ="check_Click" CssClass="loginBtn" BorderStyle="None" /> <hr />
pet name: <asp:Label ID="pname" runat="server" Text=""></asp:Label><br />
pet birthday: <asp:Label ID="pbirthday" runat="server" Text=""></asp:Label><br />
owner ID: <asp:Label ID="oid" runat="server" Text=""></asp:Label>
</div>
      

</body>
</html>
</asp:Content>
