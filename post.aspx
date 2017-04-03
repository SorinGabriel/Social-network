<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="post.aspx.cs" Inherits="post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LoginView ID="LoginView2" runat="server" >
    <LoggedInTemplate>
        <div class="row">
        <div class="col-sm-10 col-sm-offset-1 well">
        <div class="row">
        <asp:Image ID="Image1" runat="server" CssClass="col-sm-6 col-sm-offset-3"/>
        Postata de : 
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label><br />
        <asp:LoginView ID="LoginView4" runat="server">
            <RoleGroups>
                <asp:RoleGroup Roles="Admin/Moderator">
                <ContentTemplate>
                    <asp:Button runat="server" ID="stergePoza" CssClass="btn btn-danger" Text="Sterge poza" OnClick="deletePhoto" 
                    CommandName="Select" />                 
                </ContentTemplate>
                </asp:RoleGroup>
                <asp:RoleGroup Roles="Utilizator">
                <ContentTemplate>
                    <asp:Button runat="server" ID="stergePoza" CssClass="btn btn-danger" Text="Sterge poza" OnClick="deletePhoto" Visible="false"
                    CommandName="Select" /> 
                </ContentTemplate>
                </asp:RoleGroup>
            </RoleGroups>
        </asp:LoginView>
   <br />
     <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
        onselecting="SqlDataSource2_Selecting" 
        SelectCommand="SELECT * FROM [comentarii]" 
            DeleteCommand="DELETE FROM [comentarii] WHERE [id_comentariu] = @id_comentariu" 
            InsertCommand="INSERT INTO [comentarii] ([text], [poza], [username]) VALUES (@text, @poza, @username)" 
            UpdateCommand="UPDATE [comentarii] SET [text] = @text, [poza] = @poza, [username] = @username WHERE [id_comentariu] = @id_comentariu">
         <DeleteParameters>
             <asp:Parameter Name="id_comentariu" Type="Int32" />
         </DeleteParameters>
         <InsertParameters>
             <asp:Parameter Name="text" Type="String" />
             <asp:Parameter Name="poza" Type="Int32" />
             <asp:Parameter Name="username" Type="String" />
         </InsertParameters>
         <UpdateParameters>
             <asp:Parameter Name="text" Type="String" />
             <asp:Parameter Name="poza" Type="Int32" />
             <asp:Parameter Name="username" Type="String" />
             <asp:Parameter Name="id_comentariu" Type="Int32" />
         </UpdateParameters>
        </asp:SqlDataSource>
        </div>
        <div class="row">
        <div class="col-sm-6 col-sm-offset-3">
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource2">
        <ItemTemplate>
            <div class="media">
            <div class="media-body">
            <h4><%# Eval("username") %><small>
           <asp:LoginView ID="LoginView3" runat="server">
                <RoleGroups>
                    <asp:RoleGroup Roles="Admin/Moderator">
                    <ContentTemplate>
        <asp:Button runat="server" ValidationGroup='<%# Eval("id_comentariu") %>' ID="stergeCom" CssClass="btn btn-danger" Text="Sterge" OnClick="deleteCom"
        CommandName="Select" /> 
                    </ContentTemplate>
                    </asp:RoleGroup>
                    <asp:RoleGroup Roles="Utilizator">
                    <ContentTemplate>
        <asp:Button runat="server" ValidationGroup='<%# Eval("id_comentariu") %>' ID="stergeCom" CssClass="btn btn-danger" Text="Sterge" OnClick="deleteCom"
        Visible='<%# CanDelete((String)Eval("username")) %>' 
        CommandName="Select" /> 
                    </ContentTemplate>
                    </asp:RoleGroup>
                </RoleGroups>
            </asp:LoginView>            
            </small></h4>
            <p><%# Eval("text") %></p>
            </div></div>
        </ItemTemplate>
    </asp:Repeater><br />
    <div class="form-group">
    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="Scrie un comentariu"></asp:TextBox>
    </div>
    <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Trimite" onclick="Button2_Click" />
    <asp:Label ID="Label1" runat="server"></asp:Label>
    </div></div>
    </LoggedInTemplate>
    <AnonymousTemplate>
        Nu sunteti conectat!
    </AnonymousTemplate>
    </asp:LoginView>
    <br />
    <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
    <br />
    </asp:Content>

