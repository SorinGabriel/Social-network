using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class grup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack && User.Identity.IsAuthenticated)
        {
            var Label1 = (Label)LoginView2.FindControl("Label1");
            var SqlDataSource1 = (SqlDataSource)LoginView2.FindControl("SqlDataSource1");
            Label1.Text = Request.Params["gname"];
            SqlDataSource1.SelectCommand = "SELECT [username] FROM [apartine] where [grup]=@param";
            SqlDataSource1.SelectParameters.Add("param", Request.Params["gid"]);
            SqlDataSource1.DataBind();
            var id = Request.Params["gid"];
            var SqlDataSource2 = (SqlDataSource)LoginView2.FindControl("SqlDataSource2");
            SqlDataSource2.SelectCommand = "SELECT [autor],[mesaj],[data],[idpost],[grup_id] FROM [postari] where [grup_id]=@param ORDER BY [data] desc";
            SqlDataSource2.SelectParameters.Add("param", id);
            SqlDataSource2.DataBind();
            var user = User.Identity.Name;
            var Button2 = (Button)LoginView2.FindControl("Button2");
            var Button1 = (Button)LoginView2.FindControl("Button1");
            var Button3 = (Button)LoginView2.FindControl("Button3");
            var Label4 = (Label)LoginView2.FindControl("Label4");
            var TextBox2 = (TextBox)LoginView2.FindControl("TextBox2");
            if (string.IsNullOrEmpty(id))
            {
                //id lipseste, do something
                Button2.Visible = false;
                Button1.Visible = true;
                return;
            }
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            SqlCommand sql = new SqlCommand("SELECT count(*) as nr FROM [apartine] WHERE [grup]=@id and [username]=@user", con);
            try
            {
                sql.Parameters.AddWithValue("id", id);
                sql.Parameters.AddWithValue("user", user);
                var reader = sql.ExecuteReader();
                if (reader.Read())
                {
                    var number = (int)reader["nr"];
                    if (number > 0)
                    {
                        Button2.Visible = false;
                        Button1.Visible = true;
                        TextBox2.Visible = true;
                        Label4.Visible = true;
                        Button3.Visible = true;
                        return;
                    }
                    else
                    {
                        Button1.Visible = false;
                        TextBox2.Visible = false;
                        Label4.Visible = false;
                        Button3.Visible = false;
                    }
                }
            }
            catch
            {
                Button2.Visible = false;
                Button1.Visible = true;
                TextBox2.Visible = false;
                Label4.Visible = false;
                Button3.Visible = false;
                return;
            }
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        var Label2 = (Label)LoginView2.FindControl("Label2");
        String uname = User.Identity.Name;
        String gid = Request.Params["gid"];
        String query = "INSERT INTO apartine VALUES (@uname,@gid) ";

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.MDF;Integrated Security=True;User Instance=True");
        con.Open();
        SqlCommand sql = new SqlCommand(query, con);
        try
        {
            sql.Parameters.AddWithValue("uname", uname);
            sql.Parameters.AddWithValue("gid", gid);
            sql.ExecuteNonQuery();
            Label2.Text = "Succes";
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
            con.Close();
        }
        catch (SqlException err)
        {
            Label2.Text = "Eroare"+err.Message;
        }
    }
    protected void LoginView2_ViewChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var Label3 = (Label)LoginView2.FindControl("Label3");
        String uname = User.Identity.Name;
        String gid = Request.Params["gid"];
        String query = "DELETE FROM apartine WHERE username=@uname and grup=@gid";

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.MDF;Integrated Security=True;User Instance=True");
        con.Open();
        SqlCommand sql = new SqlCommand(query, con);
        try
        {
            sql.Parameters.AddWithValue("uname", uname);
            sql.Parameters.AddWithValue("gid", gid);
            sql.ExecuteNonQuery();
            Label3.Text = "Succes";
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
            con.Close();
        }
        catch (SqlException err)
        {
            Label3.Text = "Eroare" + err.Message;
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        var Label4 = (Label)LoginView2.FindControl("Label4");
        var TextBox2 = (TextBox)LoginView2.FindControl("TextBox2");
        String uname = User.Identity.Name;
        String gid = Request.Params["gid"];
        String mesaj = TextBox2.Text;
        String query = "INSERT INTO postari (autor,mesaj,data,grup_id) VALUES (@uname,@mesaj,@data,@gid) ";

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.MDF;Integrated Security=True;User Instance=True");
        con.Open();
        SqlCommand sql = new SqlCommand(query, con);
        try
        {
            sql.Parameters.AddWithValue("uname", uname);
            sql.Parameters.AddWithValue("mesaj", mesaj);
            sql.Parameters.AddWithValue("data", now);
            sql.Parameters.AddWithValue("gid", gid);
            sql.ExecuteNonQuery();
            Label4.Text = "Succes";
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
            con.Close();
        }
        catch (SqlException err)
        {
            Label4.Text = "Eroare" + err.Message;
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

            var q = Request.Params["gid"];
            String username = "";
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            SqlCommand sql = new SqlCommand("SELECT [admin] FROM [grupuri] WHERE [grup_id]=@id", con);
            try
            {
                sql.Parameters.AddWithValue("id", q);
                var reader = sql.ExecuteReader();
                if (reader.Read())
                {
                    username = (string)reader["admin"];
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