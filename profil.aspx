<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="profil.aspx.cs" Inherits="profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <p>
        <asp:LoginView ID="LoginView2" runat="server" 
            onviewchanged="LoginView2_ViewChanged">
        <LoggedInTemplate>
        <div class="row">
        <div class="col-sm-10 col-sm-offset-1 well">
            <h2><asp:Label ID="Label3" runat="server" Text=""></asp:Label></h2>
        <asp:FormView ID="FormView1" runat="server" 
            onpageindexchanging="FormView1_PageIndexChanging">
            <ItemTemplate>
            <%# Eval("UserName")%>

            </ItemTemplate>
        </asp:FormView>
    </p>
<p>        <asp:Button ID="Button2" runat="server" onclick="Button2_Click1" 
            Text="Trimite cerere" />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <p>
        <asp:TextBox ID="TextBox2" Visible="false" runat="server"></asp:TextBox>
        <asp:Button ID="Button3" Visible="false" runat="server" onclick="Button3_Click" Text="Posteaza" />
        <asp:Label ID="Label2" Visible="false" runat="server" Text=""></asp:Label>
        </p>
        <p>
            
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
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
        <asp:Repeater ID="Repeater3" runat="server" DataSourceID="SqlDataSource4">
                <ItemTemplate>
                <div class="media">
                  <div class="media-body">
                    <h4 class="media-heading"><%# Eval("autor") %><small>La data de:<%# Eval("data") %></small></h4>
                    <p><%# Eval("mesaj") %></p>
                  </div
                </div>
            <asp:LoginView ID="LoginView3" runat="server">
                <RoleGroups>
                    <asp:RoleGroup Roles="Admin/Moderator">
                    <ContentTemplate>
                    <asp:Button runat="server" ValidationGroup='<%# Eval("idpost") %>' ID="stergeCom" Text="Sterge" OnClick="deletePost"
                    CommandName="Select" /> 
                    </ContentTemplate>
                    </asp:RoleGroup>
                    <asp:RoleGroup Roles="Utilizator">
                    <ContentTemplate>
                    <asp:Button runat="server" ValidationGroup='<%# Eval("idpost") %>' ID="stergeCom" Text="Sterge" OnClick="deletePost"
                    Visible='<%# CanDelete((String)Eval("autor")) %>' 
                    CommandName="Select" /> 
                    </ContentTemplate>
                    </asp:RoleGroup>
                </RoleGroups>
            </asp:LoginView>
            <br />
        </ItemTemplate>
        </asp:Repeater>

        </p>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ASPNET %>" 
            SelectCommand="SELECT * FROM [vw_aspnet_Users]" 
            onselecting="SqlDataSource1_Selecting"></asp:SqlDataSource> 
     <p>
                Albume:<br />
        <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource3">
            <ItemTemplate>
               <a href="http://localhost:50922/WebSite1/albume.aspx/?numealbum=<%# Eval("numealbum")%>"><%# Eval("numealbum")%></a><br />
            </ItemTemplate>
        </asp:Repeater>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
            SelectCommand="SELECT * FROM [albume]" onselecting="SqlDataSource3_Selecting"></asp:SqlDataSource>
    </p> 
        </div></div>
        </LoggedInTemplate>
        <AnonymousTemplate>
        Nu sunteti conectat
        </AnonymousTemplate>
        </asp:LoginView>
    </p>
    <p>
    </p>
            
</asp:Content>

