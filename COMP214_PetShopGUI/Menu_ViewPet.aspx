<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu_ViewPet.aspx.cs" MasterPageFile="~/petshop18.master" Inherits="COMP214_PetShopGUI.testTblPET" %>
<asp:Content ID="content1" ContentPlaceHolderID="main" runat="server">
	<!DOCTYPE html>

<asp:Image ID="homeImage" runat="server"  ImageUrl="~/images/homeImage.jpg" Width="200px" Height="200px" style="float:left;"/>
<div class="viewBox" style="width:60%; margin-right:100px;">
Customer Name: <asp:TextBox ID="cusName" runat="server" Placeholder="Customer's first or last name"  Width="200px"></asp:TextBox> &nbsp;&nbsp;

<asp:Button ID="check" runat="server" Text="Check"  OnClick ="check_Click"  BorderStyle="None" CssClass="Btn" /> <hr />

<asp:GridView ID="petlisttable" runat="server" HeaderStyle-BackColor="#009999" HeaderStyle-ForeColor="White" HorizontalAlign="Center"></asp:GridView>


</div>
      


</asp:Content>
