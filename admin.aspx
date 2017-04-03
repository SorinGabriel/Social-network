<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LoginView ID="LoginView2" runat="server">
          <RoleGroups>
                    <asp:RoleGroup Roles="Admin/Moderator">
                    <ContentTemplate>
                     <div class="row"><div class="col-sm-10 col-sm-offset-1 well">
    <div class="form-group">
    <h4>User:</h4>
    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox><br /><h4>Mesaj:</h4>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox><br />
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Trimite sanctiunea" onclick="Button1_Click" /><asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </div></div>
                    </ContentTemplate>
                    </asp:RoleGroup>
                    <asp:RoleGroup Roles="Utilizator">
                    <ContentTemplate>
                        Nu aveti drepturi pe aceasta pagina
                    </ContentTemplate>
                    </asp:RoleGroup>
            </RoleGroups>
    </asp:LoginView>
    </asp:Content>

