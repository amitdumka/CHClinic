<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CHCWebForm.WebForm1" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
    <asp:MultiView ID="MultiView1" runat="server">
    </asp:MultiView>
    <asp:ListBox ID="ListBox1" runat="server" Width="400px">
        <asp:ListItem></asp:ListItem>
        <asp:ListItem></asp:ListItem>
        <asp:ListItem></asp:ListItem>
        <asp:ListItem></asp:ListItem>
        <asp:ListItem></asp:ListItem>
        <asp:ListItem></asp:ListItem>
        <asp:ListItem></asp:ListItem>
    </asp:ListBox>
    <asp:CheckBoxList ID="CheckBoxList1" runat="server" Width="429px">
        <asp:ListItem></asp:ListItem>
        <asp:ListItem></asp:ListItem>
        <asp:ListItem></asp:ListItem>
        <asp:ListItem></asp:ListItem>
        <asp:ListItem></asp:ListItem>
        <asp:ListItem></asp:ListItem>
    </asp:CheckBoxList>
</asp:Content>

