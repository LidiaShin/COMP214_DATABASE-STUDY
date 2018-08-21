<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MedicationRegister.aspx.cs" MasterPageFile="~/petshop18.master" Inherits="COMP214_PetShopGUI.MedicationRegister" %>
<asp:Content ID="content1" ContentPlaceHolderID="main" runat="server">
<!DOCTYPE html>

<div id="signupBox2">

<p> Please input prescription number. </p>

<asp:TextBox ID="preID" runat="server"></asp:TextBox>
<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="ID" DataValueField="ID"></asp:DropDownList>
    
      
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" SelectCommand="SELECT &quot;ID&quot;, &quot;NAME&quot; FROM &quot;MEDICATION&quot;"></asp:SqlDataSource>
    
      
<asp:Button ID="Button1" runat="server" Text="Register New Med" OnClick="Button1_Click" />

	<asp:GridView ID="GridView1" runat="server"></asp:GridView><br />
	<asp:GridView ID="GridView2" runat="server"></asp:GridView>

</div>
</asp:Content>
