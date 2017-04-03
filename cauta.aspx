<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cauta.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:LoginView ID="LoginView1" runat="server" 
            onviewchanged="LoginView1_ViewChanged">
        <LoggedInTemplate>
        <div class="row"><div class="col-sm-10 col-sm-offset-1 well">
    <p>
        <div class="row">
        <h3>Persoane:</h3><br />
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
           <ItemTemplate>
                <td><a href="/WebSite1/profil.aspx/?uid=<%# Eval("UserId")%>&uname=<%# Eval("UserName")%>"><%# Eval("UserName")%></a></td><br />
            </ItemTemplate>
        </asp:Repeater>
        <br />
        </div>
    </p>
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ASPNET %>" 
            SelectCommand="SELECT * FROM [vw_aspnet_Applications]" 
            onselecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
    </p>     
        <div class="row">
        <h3>Grupuri:</h3><br />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
            SelectCommand="SELECT * FROM [grupuri]" 
            onselecting="SqlDataSource2_Selecting"></asp:SqlDataSource>
        <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource2">
            <ItemTemplate>
               <td><a href="/WebSite1/grup.aspx/?gid=<%# Eval("grup_id")%>&gname=<%# Eval("grupname")%>"><%# Eval("grupname")%></a></td><br />
            </ItemTemplate>
        </asp:Repeater>  
        </div>
        </div></div> 
        </LoggedInTemplate>
        <AnonymousTemplate>Nu sunteti conectat!</AnonymousTemplate>
        </asp:LoginView>
        <br />

</p>
</asp:Content>

