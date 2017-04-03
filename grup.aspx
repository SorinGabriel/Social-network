<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="grup.aspx.cs" Inherits="grup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:LoginView ID="LoginView2" runat="server" 
        onviewchanged="LoginView2_ViewChanged">
    <LoggedInTemplate>
    <div class="row"><div class="col-sm-10 col-sm-offset-1 well">
    <p>
    <h4><asp:Label ID="Label1" runat="server" Text="Membrii"></asp:Label></h4>
        <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" onclick="Button2_Click" 
            Text="Intra in grup" />
        <asp:Label ID="Label2" runat="server"></asp:Label>
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-danger" Text="Paraseste grupul" 
        onclick="Button1_Click" /><asp:Label ID="Label3" runat="server"></asp:Label>
    </p>
    <p>
        <div class="form-group">
            <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" onclick="Button3_Click" Text="Trimite mesaj" />
        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
    </p>
       <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
            DeleteCommand="DELETE FROM [postari] WHERE [idpost] = @idpost" 
            InsertCommand="INSERT INTO [postari] ([autor], [mesaj], [data], [grup_id], [userul]) VALUES (@autor, @mesaj, @data, @grup_id, @userul)" 
            SelectCommand="SELECT * FROM [postari]" 
            UpdateCommand="UPDATE [postari] SET [autor] = @autor, [mesaj] = @mesaj, [data] = @data, [grup_id] = @grup_id, [userul] = @userul WHERE [idpost] = @idpost">
            <DeleteParameters>
                <asp:Parameter Name="idpost" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="autor" Type="String" />
                <asp:Parameter Name="mesaj" Type="String" />
                <asp:Parameter DbType="Date" Name="data" />
                <asp:Parameter Name="grup_id" Type="Int32" />
                <asp:Parameter Name="userul" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="autor" Type="String" />
                <asp:Parameter Name="mesaj" Type="String" />
                <asp:Parameter DbType="Date" Name="data" />
                <asp:Parameter Name="grup_id" Type="Int32" />
                <asp:Parameter Name="userul" Type="String" />
                <asp:Parameter Name="idpost" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource2">
            <ItemTemplate>
            <div class="media">
            <div class="media-body">
            <h4><%# Eval("autor") %>
            <small><i>La data de:<%# Eval("data") %></i>
            <asp:LoginView ID="LoginView3" runat="server">
                <RoleGroups>
                    <asp:RoleGroup Roles="Admin/Moderator">
                    <ContentTemplate>
                    <asp:Button runat="server" ValidationGroup='<%# Eval("idpost") %>' ID="stergeCom" CssClass="btn btn-danger" Text="Sterge" OnClick="deletePost"
                    CommandName="Select" /> 
                    </ContentTemplate>
                    </asp:RoleGroup>
                    <asp:RoleGroup Roles="Utilizator">
                    <ContentTemplate>
                    <asp:Button runat="server" ValidationGroup='<%# Eval("idpost") %>' ID="stergeCom" CssClass="btn btn-danger" Text="Sterge" OnClick="deletePost"
                    Visible='<%# CanDelete((String)Eval("autor")) %>' 
                    CommandName="Select" /> 
                    </ContentTemplate>
                    </asp:RoleGroup>
                </RoleGroups>
            </asp:LoginView>            
            </small>
            </h4><p>
            <%# Eval("mesaj") %>
            </p>
            </ItemTemplate>
        </asp:Repeater>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="username" HeaderText="Membrii" SortExpression="username" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
        SelectCommand="SELECT * FROM [apartine]"></asp:SqlDataSource>    
    </LoggedInTemplate>
    <AnonymousTemplate>Nu sunteti conectat!<br /></AnonymousTemplate>
    </asp:LoginView><br />
    </asp:Content>

