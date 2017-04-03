using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI.HtmlControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack && User.Identity.IsAuthenticated)
        {
            var username = User.Identity.Name;
            var SqlDataSource1 = (SqlDataSource)LoginView2.FindControl("SqlDataSource1");
            var SqlDataSource2 = (SqlDataSource)LoginView2.FindControl("SqlDataSource2");
            var SqlDataSource3 = (SqlDataSource)LoginView2.FindControl("SqlDataSource3");
            var SqlDataSource4 = (SqlDataSource)LoginView2.FindControl("SqlDataSource4");
            var SqlDataSource5 = (SqlDataSource)LoginView2.FindControl("SqlDataSource5");
            SqlDataSource1.SelectCommand = "SELECT [user1] FROM [cereriprietenie] where user2=@param";
            SqlDataSource1.SelectParameters.Add("param", username);
            SqlDataSource1.DataBind();
            SqlDataSource2.SelectCommand = "SELECT [user2],[friendship_id] FROM [prietenii] WHERE user1=@param";
            SqlDataSource2.SelectParameters.Add("param", username);
            SqlDataSource2.DataBind();
            SqlDataSource3.SelectCommand = "SELECT [numealbum] FROM [albume] where username=@param";
            SqlDataSource3.SelectParameters.Add("param", username);
            SqlDataSource3.DataBind();
            SqlDataSource4.SelectCommand = "SELECT [user1],[friendship_id] FROM [prietenii] WHERE user2=@param";
            SqlDataSource4.SelectParameters.Add("param", username);
            SqlDataSource4.DataBind();
            SqlDataSource5.SelectCommand = "SELECT [userul],[mesaj],[id] FROM [notificariadmin] WHERE userul=@param";
            SqlDataSource5.SelectParameters.Add("param", username);
            SqlDataSource5.DataBind();
        }
    }

    protected void acceptClick(object sender, EventArgs e)
    {
        var Label1 = (Label)LoginView2.FindControl("Label1");
        Button btn = (Button)sender;
        var userId = btn.ValidationGroup;
        String uname = userId;
        String uname2 = User.Identity.Name;
        DateTime now = DateTime.Now;
        String query = "DELETE FROM cereriprietenie WHERE user1=@uname1 and user2=@uname2 ";

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.MDF;Integrated Security=True;User Instance=True");
        con.Open();
        SqlCommand sql = new SqlCommand(query, con);
        try
        {
            sql.Parameters.AddWithValue("uname1", uname);
            sql.Parameters.AddWithValue("uname2", uname2);
            sql.ExecuteNonQuery();
            con.Close();
            String query2 = "INSERT INTO prietenii (user1,user2,data) VALUES(@uname1,@uname2,@data)";

            SqlConnection con2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.MDF;Integrated Security=True;User Instance=True");
            con2.Open();
            SqlCommand sql2 = new SqlCommand(query2, con2);
            try
            {
                sql2.Parameters.AddWithValue("uname1", uname);
                sql2.Parameters.AddWithValue("uname2", uname2);
                sql2.Parameters.AddWithValue("data", now);
                sql2.ExecuteNonQuery();
                con2.Close();
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            catch
            {
                Label1.Text = "eroare";
            }

        }
        catch
        {
            Label1.Text = "Eroare";
        }
    }

    protected void rejectClick(object sender, EventArgs e)
    {
        var Label1 = (Label)LoginView2.FindControl("Label1");
        Button btn = (Button)sender;
        var userId = btn.ValidationGroup;
        String uname = userId;
        String uname2 = User.Identity.Name;
        String query = "DELETE FROM cereriprietenie WHERE user1=@uname1 and user2=@uname2 ";

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.MDF;Integrated Security=True;User Instance=True");
        con.Open();
        SqlCommand sql = new SqlCommand(query, con);
        try
        {
            sql.Parameters.AddWithValue("uname1", uname);
            sql.Parameters.AddWithValue("uname2", uname2);
            sql.ExecuteNonQuery();
            con.Close();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        catch
        {
            Label1.Text="Eroare";
        }
    }

    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        var CreateUserWizard1 = (CreateUserWizard)LoginView2.FindControl("CreateUserWizard1");
        Roles.AddUserToRole(CreateUserWizard1.UserName, "Utilizator");
    }
}