
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    
        <asp:LoginView ID="LoginView2" runat="server">
            <LoggedInTemplate>
    <p>
        <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
            DeleteCommand="DELETE FROM [notificariadmin] WHERE [id] = @id" 
            InsertCommand="INSERT INTO [notificariadmin] ([userul], [mesaj]) VALUES (@userul, @mesaj)" 
            SelectCommand="SELECT * FROM [notificariadmin]" 
            UpdateCommand="UPDATE [notificariadmin] SET [userul] = @userul, [mesaj] = @mesaj WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="userul" Type="String" />
                <asp:Parameter Name="mesaj" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="userul" Type="String" />
                <asp:Parameter Name="mesaj" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <div class"row" id="notificariadmin"><div class="col-sm-12 alert alert-danger">
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="id" DataSourceID="SqlDataSource5" EmptyDataText="Respectati regulamentul site-ului">
            <Columns>
                <asp:BoundField DataField="mesaj" HeaderText="mesaj" SortExpression="mesaj" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        </div></div>
        <div class="row">
        <div class="col-sm-2 col-sm-offset-1 well">
        <h3>Cereri de prietenie:</h3><asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
            SelectCommand="SELECT [user1] FROM [cereriprietenie]"></asp:SqlDataSource>
        <asp:Label ID="Label1" runat="server"></asp:Label>

        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate>
                <td><%# Eval("user1")%></td><br />
                <asp:Button runat="server" ValidationGroup='<%# Eval("user1") %>' ID="acceptFriendship" CssClass="btn btn-primary" Text="Accept" OnClick="acceptClick"/> 
                <asp:Button runat="server" ValidationGroup='<%# Eval("user1") %>' ID="rejectFriendship" CssClass="btn btn-default" Text="Reject" OnClick="rejectClick"/> 
                <br />
            </ItemTemplate>
        </asp:Repeater>
        </div>
        <div class="col-sm-4 col-sm-offset-1 well">
        <h3>Prieteni:</h3>
        <asp:GridView ID="GridView1" runat="server" ShowHeader="False" AutoGenerateColumns="False" 
            DataKeyNames="friendship_id" DataSourceID="SqlDataSource2" EmptyDataText="">
            <Columns>
                <asp:BoundField DataField="user2" SortExpression="user2" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
            DeleteCommand="DELETE FROM [prietenii] WHERE [friendship_id] = @friendship_id" 
            InsertCommand="INSERT INTO [prietenii] ([user2], [friendship_id]) VALUES (@user2, @friendship_id)" 
            SelectCommand="SELECT [user2], [friendship_id] FROM [prietenii]" 
            UpdateCommand="UPDATE [prietenii] SET [user2] = @user2 WHERE [friendship_id] = @friendship_id">
            <DeleteParameters>
                <asp:Parameter Name="friendship_id" Type="Object" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="user2" Type="String" />
                <asp:Parameter Name="friendship_id" Type="Object" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="user2" Type="String" />
                <asp:Parameter Name="friendship_id" Type="Object" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
            DeleteCommand="DELETE FROM [prietenii] WHERE [friendship_id] = @friendship_id" 
            SelectCommand="SELECT [user1], [friendship_id] FROM [prietenii]">
        </asp:SqlDataSource>
        <asp:GridView ID="GridView2" runat="server" ShowHeader="False" AutoGenerateColumns="False" 
            DataKeyNames="friendship_id" DataSourceID="SqlDataSource4" EmptyDataText="">
            <Columns>
                <asp:BoundField DataField="user1" SortExpression="user1" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        </div>
        <div class="col-sm-2 col-sm-offset-1 well">
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
            </div></div>
            </LoggedInTemplate>
            <AnonymousTemplate>
            <div class="row">
            <div class="col-sm-4 col-sm-offset-1 well"><h1>Text introductiv-Conectati-va cu lumea bla bla</h1></div>
            <div class="col-sm-3 col-sm-offset-2">
                <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" BackColor="#F7F6F3" 
                    BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px" 
                    Font-Names="Verdana" Font-Size="0.8em" Height="307px" Width="370px">
                    <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
                        BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                        ForeColor="#284775" />
                    <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
                        BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                        ForeColor="#284775" />
                    <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <WizardSteps>
                        <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" />
                        <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                            <ContentTemplate>
                                <table style="font-family: Verdana; font-size: 100%; height: 307px; width: 370px;">
                                    <tr>
                                        <td align="center" colspan="2" 
                                            style="color: White; background-color: #5D7B9D; font-weight: bold;">
                                            Complete</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Your account has been successfully created.</td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <asp:Button ID="ContinueButton" runat="server" BackColor="#FFFBFF" 
                                                BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" 
                                                CausesValidation="False" CommandName="Continue" Font-Names="Verdana" 
                                                ForeColor="#284775" PostBackUrl="profil.aspx" Text="Continue" 
                                                ValidationGroup="CreateUserWizard1" />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:CompleteWizardStep>
                    </WizardSteps>
                    <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" 
                        Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
                    <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
                        BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                        ForeColor="#284775" />
                    <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" ForeColor="White" />
                    <SideBarStyle BackColor="#5D7B9D" BorderWidth="0px" Font-Size="0.9em" 
                        VerticalAlign="Top" />
                    <StepStyle BorderWidth="0px" />
                </asp:CreateUserWizard>
                </div></div></AnonymousTemplate>
        </asp:LoginView>

</p>
</asp:Content>