using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;

public partial class profil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack && User.Identity.IsAuthenticated)
        {
            string q = Request.Params["uid"];
            var Button2 = (Button)LoginView2.FindControl("Button2");
            var TextBox2 = (TextBox)LoginView2.FindControl("TextBox2");
            var Label2 = (Label)LoginView2.FindControl("Label2");
            var Label3 = (Label)LoginView2.FindControl("Label3");
            var Button3 = (Button)LoginView2.FindControl("Button3");
            var SqlDataSource1 = (SqlDataSource)LoginView2.FindControl("SqlDataSource1");
            SqlDataSource1.SelectCommand = "SELECT [UserName] FROM [vw_aspnet_Users] WHERE [UserId] = @q and [isAnonymous] = 0";
            SqlDataSource1.SelectParameters.Add("q", q);
            SqlDataSource1.DataBind();
            var username="";
            var myuser=User.Identity.Name;

            if (string.IsNullOrEmpty(q))
            {
                return;
            }
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\ASPNETDB.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            SqlCommand sql = new SqlCommand("SELECT [UserName] FROM [vw_aspnet_Users] WHERE [UserId]=@id and [isAnonymous]=0", con);
            try
            {
                sql.Parameters.AddWithValue("id", q);
                var reader = sql.ExecuteReader();
                if (reader.Read())
                {
                    username = (string)reader["UserName"];
                    Label3.Text = username;
                    var SqlDataSource3 = (SqlDataSource)LoginView2.FindControl("SqlDataSource3");
                    SqlDataSource3.SelectCommand = "SELECT [numealbum] FROM [albume] where username=@param";
                    SqlDataSource3.SelectParameters.Add("param", username);
                    SqlDataSource3.DataBind();
                    var SqlDataSource4 = (SqlDataSource)LoginView2.FindControl("SqlDataSource4");
                    SqlDataSource4.SelectCommand = "SELECT [autor],[mesaj],[data],[idpost] FROM [postari] where userul=@param ORDER BY [data] desc";
                    SqlDataSource4.SelectParameters.Add("param", username);
                    SqlDataSource4.DataBind();
                }
            }
            catch
            {
                return;
            }
            object x = new StringBuilder(username).ToString();
            object y = new StringBuilder(myuser).ToString();
            if (x.Equals(y))
            {
                Button2.Visible = false;
                TextBox2.Visible = true;
                Label2.Visible = true;
                Button3.Visible = true;
            }
            else
            {
                con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
                con.Open();
                sql = new SqlCommand("SELECT count(*) as nr FROM [prietenii] WHERE ([User1]=@us1 and [User2]=@us2) or ([User2]=@us1 and [User1]=@us2)", con);
                try
                {
                    sql.Parameters.AddWithValue("us1", myuser);
                    sql.Parameters.AddWithValue("us2", username);
                    var reader = sql.ExecuteReader();
                    if (reader.Read())
                    {
                        var nr = (int)reader["nr"];
                        if (nr > 0)
                        {
                            Button2.Visible = false;
                            TextBox2.Visible = true;
                            Label2.Visible = true;
                            Button3.Visible = true;
                        }
                    }
                }
                catch
                {
                    Button2.Visible = false;
                    TextBox2.Visible = true;
                    Label2.Visible = true;
                    Button3.Visible = true;
                    return;
                }

                con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
                con.Open();
                sql = new SqlCommand("SELECT count(*) as nr FROM [cereriprietenie] WHERE [User1]=@us1 and [User2]=@us2", con);
                try
                {
                    sql.Parameters.AddWithValue("us1", myuser);
                    sql.Parameters.AddWithValue("us2", username);
                    var reader = sql.ExecuteReader();
                    if (reader.Read())
                    {
                        var nr = (int)reader["nr"];
                        if (nr > 0)
                        {
                            Button2.Visible = false;
                        }
                    }
                }
                catch
                {
                    Button2.Visible = false;
                    return;
                }
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {

    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        var Label1 = (Label)LoginView2.FindControl("Label1");
        String uname = User.Identity.Name;
        String uname2 = Request.Params["uname"];
        String query = "INSERT INTO cereriprietenie VALUES (@uname1,@uname2) ";

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.MDF;Integrated Security=True;User Instance=True");
        con.Open();
        SqlCommand sql = new SqlCommand(query, con);
        try
        {
            sql.Parameters.AddWithValue("uname1", uname);
            sql.Parameters.AddWithValue("uname2", uname2);
            sql.ExecuteNonQuery();
            Label1.Text = "Succes";
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
            con.Close();
        }
        catch
        {
            Label1.Text = "Eroare";
        }
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void LoginView2_ViewChanged(object sender, EventArgs e)
    {

    }
    protected void SqlDataSource3_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        var q = Request.Params["uid"];
        String username="";
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\ASPNETDB.mdf;Integrated Security=True;User Instance=True");
        con.Open();
        SqlCommand sql = new SqlCommand("SELECT [UserName] FROM [vw_aspnet_Users] WHERE [UserId]=@id and [isAnonymous]=0", con);
        try
        {
            sql.Parameters.AddWithValue("id", q);
            var reader = sql.ExecuteReader();
            if (reader.Read())
            {
                username = (string)reader["UserName"];
            }
        }
        catch
        {
            return;
        }
        DateTime now = DateTime.Now;
        var Label2 = (Label)LoginView2.FindControl("Label2");
        var TextBox2 = (TextBox)LoginView2.FindControl("TextBox2");
        String uname = User.Identity.Name;
        String mesaj = TextBox2.Text;
        String query = "INSERT INTO postari (autor,mesaj,data,userul) VALUES (@uname,@mesaj,@data,@uid) ";

        con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.MDF;Integrated Security=True;User Instance=True");
        con.Open();
        sql = new SqlCommand(query, con);
        try
        {
            sql.Parameters.AddWithValue("uname", uname);
            sql.Parameters.AddWithValue("mesaj", mesaj);
            sql.Parameters.AddWithValue("data", now);
            sql.Parameters.AddWithValue("uid", username);
            sql.ExecuteNonQuery();
            Label2.Text = "Succes";
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
            con.Close();
        }
        catch (SqlException err)
        {
            Label2.Text = "Eroare" + err.Message;
        }
    }

    protected Boolean CanDelete(String uname)
    {
        String uname2 = User.Identity.Name;
        if (uname2.CompareTo(uname) == 0)
        {
            return true;
        }
        else
        {

            var q = Request.Params["uid"];
            String username = "";
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\ASPNETDB.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            SqlCommand sql = new SqlCommand("SELECT [UserName] FROM [vw_aspnet_Users] WHERE [UserId]=@id and [isAnonymous]=0", con);
            try
            {
                sql.Parameters.AddWithValue("id", q);
                var reader = sql.ExecuteReader();
                if (reader.Read())
                {
                    username = (string)reader["UserName"];
                    if (username.CompareTo(uname2) == 0 || uname2.CompareTo(uname) == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return uname.CompareTo(uname2) == 0;
            }
            return uname.CompareTo(uname2) == 0;
        }
    }

    protected void deletePost(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        var postId = btn.ValidationGroup;
        String idpost = postId;
        String uname2 = User.Identity.Name;
        String query = "DELETE FROM postari WHERE idpost=@idpost ";

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.MDF;Integrated Security=True;User Instance=True");
        con.Open();
        SqlCommand sql = new SqlCommand(query, con);
        try
        {
            sql.Parameters.AddWithValue("idpost", idpost);
            sql.ExecuteNonQuery();
            con.Close();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        catch
        {
            
        }
    }

}