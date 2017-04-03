<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="albume.aspx.cs" Inherits="albume" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p style="margin-left: 2px">
        <asp:LoginView ID="LoginView2" runat="server" 
            onviewchanged="LoginView2_ViewChanged">
        <LoggedInTemplate>
        <div class="row">
        <div class="col-sm-10 col-sm-offset-1 well">
        <h1><asp:Label ID="Label1" runat="server"></asp:Label></h1>
        <div class="row">
        <div class="form-group well">
        Adauga imagine:<br />
        <asp:FileUpload ID="FileUpload1" runat="server" /><br />
        <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" onclick="Button2_Click" Text="Trimite" />
        <asp:Label ID="Label2" runat="server"></asp:Label>
        </div></div>
        <h3>Poze:</h3><br />
        <div class="row">
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate><a href="/WebSite1/post.aspx/?id=<%# Eval("id")%>"><img alt="imagine" width="200" height="200" class="col-sm-3" src="/WebSite1/image.aspx/?id=<%# Eval("id")%>" /></a><br /></ItemTemplate>
        </asp:Repeater>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
            onselecting="SqlDataSource1_Selecting" 
            SelectCommand="SELECT [id] FROM [poza]" 
            DeleteCommand="DELETE FROM [poza] WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
        </asp:SqlDataSource>
        </div></div>
        </LoggedInTemplate>
        <AnonymousTemplate>
        Nu sunteti conectat
        </AnonymousTemplate>
        </asp:LoginView>
    <br />
    </p>
</asp:Content>

