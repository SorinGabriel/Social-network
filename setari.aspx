<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="setari.aspx.cs" Inherits="setari" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:LoginView ID="LoginView2" runat="server" 
            onviewchanged="LoginView2_ViewChanged">
        <LoggedInTemplate><div class="well col-sm-10 col-sm-offset-1">
    <h4>
        Tipul contului:</h4>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem Value="False">Public</asp:ListItem>
            <asp:ListItem Value="True">Privat</asp:ListItem>
        </asp:RadioButtonList>
    <p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button2" runat="server" Text="Salveaza" onclick="Button2_Click" />
    </p>        
        </div>
        </LoggedInTemplate>
        <AnonymousTemplate>
        Nu sunteti conectat
        </AnonymousTemplate>
        </asp:LoginView>
    </p>

</asp:Content>

