<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="project_frank._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:GridView runat="server" AutoGenerateColumns="False" AllowSorting="True" ID="SongsGrid" CssClass="Songs">
                <Columns>
                    <%--<asp:TemplateField HeaderText="ID"><ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("ID") %>'/>
                    </ItemTemplate></asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="Nummer"><ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Nummer") %>'/>
                    </ItemTemplate></asp:TemplateField>

                    <asp:TemplateField HeaderText="Liedje"><ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Liedje") %>'/>
                    </ItemTemplate></asp:TemplateField>

                    <asp:TemplateField HeaderText="Band"><ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Band") %>'/>
                    </ItemTemplate></asp:TemplateField>

                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
