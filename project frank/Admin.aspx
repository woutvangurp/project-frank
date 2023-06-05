<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="project_frank.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:GridView runat="server" ID="allePlaten" 
                          AutoGenerateColumns="False" 
                          AllowSorting="True" 
                          CssClass="songs" 
                          OnRowDataBound="allePlaten_OnRowDataBound" 
                          DataKeyNames="ID">
                <Columns>
                    <asp:TemplateField HeaderText="Nummer"><ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Nummer") %>'/>
                    </ItemTemplate></asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Liedje"><ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Liedje") %>'/>
                    </ItemTemplate></asp:TemplateField>

                    <asp:TemplateField HeaderText="Band"><ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Band") %>'/>
                    </ItemTemplate></asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Jukebox?"><ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("fav") %>'/>
                    </ItemTemplate></asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Delete"><ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnDel" Text="Delete" OnClick="DeleteCLick"/>
                    </ItemTemplate></asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Edit"><ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnEdit" Text="Edit" OnClick="EditClick"/>
                    </ItemTemplate></asp:TemplateField>
                </Columns>
            </asp:GridView>
            
            <asp:LinkButton runat="server" Text="Add" ID="addPlaat" OnClick="addPlaat_OnClick"/>
    
            <div runat="server" id="Overlay" class="overlay" Visible="False"></div>
    
            <asp:Panel runat="server" ID="addPanel" CssClass="addPanel" Visible="False">
                <asp:LinkButton runat="server" Text="X" CssClass="Close" ID="btnClose" OnClick="btnClose_OnClick"/>
                <table>
                    <tr><td>
                        <asp:Label runat="server" Text="Liedje:"/>
                    </td><td>
                        <asp:TextBox runat="server" ID="tbxSong"/>
                    </td></tr><tr><td>
                        <asp:Label runat="server" Text="Band:"/>
                    </td><td>
                        <asp:TextBox runat="server" ID="tbxBand"/>
                    </td></tr><tr><td>
                        <asp:Label runat="server" Text="Nummer:"/>
                    </td><td>
                        <asp:TextBox runat="server" ID="tbxNummer"/>
                    </td></tr><tr><td>
                        <asp:Label runat="server" Text="zit het in de jukebox?:"/>
                    </td><td>
                        <asp:DropDownList runat="server" ID="ddlBool">
                            <asp:ListItem Selected="True" Value="0" Text="Nee"/>
                            <asp:ListItem Value="1" Text="Ja"/>
                        </asp:DropDownList>
                    </td></tr><tr><td colspan="2">
                        <asp:LinkButton runat="server" Visible="False" Enabled="False" OnClick="btnSend_OnClick" ID="btnAddAl"/><br/>
                        <asp:LinkButton runat="server" ID="btnSend" Text="Versturen" OnClick="btnSend_OnClick"/>
                    </td></tr>
                </table>
            </asp:Panel>
            
            <asp:Panel runat="server" ID="pnlAlert" CssClass="addPanel" Visible="False">
                <asp:LinkButton runat="server" Text="X" CssClass="Close" ID="btnCloseAl" OnClick="btnClose_OnClick"/>
                <asp:Label runat="server" ID="lblAlert"/>
            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
