<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="project_frank.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" Text="Wachtwoord"/><br/>
    <asp:TextBox runat="server" ID="Password"/><br/><br/>   
    <asp:Button runat="server" Text="Verstuur"/>
</asp:Content>
