<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="albums.aspx.cs" Inherits="albums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LoginView ID="LoginView2" runat="server" 
        onviewchanged="LoginView2_ViewChanged">
        <LoggedInTemplate>
        <div class="well col-sm-10 col-sm-offset-1">
                <h3>Albume:</h3>
        <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource3">
            <ItemTemplate>
                <a href="albume.aspx/?numealbum=<%# Eval("numealbum")%>"><%# Eval("numealbum")%></a><br />
            </ItemTemplate>
        </asp:Repeater>
        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary" PostBackUrl="creazaalbum.aspx">Creaza un album nou</asp:LinkButton>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
            SelectCommand="SELECT * FROM [albume]"></asp:SqlDataSource>
        </div>
        </LoggedInTemplate>
        <AnonymousTemplate>Nu sunteti conectat!</AnonymousTemplate>
    </asp:LoginView>
</asp:Content>

