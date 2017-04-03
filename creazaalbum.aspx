<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="creazaalbum.aspx.cs" Inherits="creazaalbum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:LoginView ID="LoginView2" runat="server">
        <LoggedInTemplate>
            <p>
            <div class="row"><div class="col-sm-10 col-sm-offset-1 well">
        <h3>Creaza un album:</h3>
        <div class="form-group"><p>Nume album:</p>
        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" Height="22px"></asp:TextBox>
        </div>
        <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" onclick="Button2_Click" Text="Creaza" />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
        </div>
    </p>
        </LoggedInTemplate>
        <AnonymousTemplate>
        Nu sunteti conectat!
        </AnonymousTemplate>
        </asp:LoginView>
    </p>

</asp:Content>

