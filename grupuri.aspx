<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="grupuri.aspx.cs" Inherits="grupuri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    <p>
        <div class="row">
        <div class="col-sm-10 col-sm-offset-1 well">
        <h3>Creaza un grup nou:</h3>
        <div class="form-group">
        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox></div>
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" CssClass="btn btn-primary" Text="Creaza" />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        </div></div>
    </p>
    <p>
        <div class="row">
        <div class="col-sm-10 col-sm-offset-1 well">
        Grupurile mele:<br />
        <br />
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate>
               <td><a href="/WebSite1/grup.aspx/?gid=<%# Eval("id")%>&gname=<%# Eval("nume")%>"><%# Eval("nume")%></a></td><br />
            </ItemTemplate>            
        </asp:Repeater>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
            SelectCommand="SELECT * FROM [apartine]" 
            onselecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
        </div></div>
    </p>
    </asp:Content>

