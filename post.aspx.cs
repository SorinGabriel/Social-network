using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class post : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack && User.Identity.IsAuthenticated)
        {
            if (!string.IsNullOrEmpty(Request.Params["id"]))
            {
                var Label2 = (Label)LoginView2.FindControl("Label2");
                var id = Request.Params["id"];
                var Image1 = (Image)LoginView2.FindControl("Image1");
                var SqlDataSource2 = (SqlDataSource)LoginView2.FindControl("SqlDataSource2");
                var LoginView4 = (LoginView)LoginView2.FindControl("LoginView4");
                var stergepoza = (Button)LoginView4.FindControl("stergePoza");
                SqlDataSource2.SelectCommand = "SELECT * FROM comentarii WHERE poza=@id";
                SqlDataSource2.SelectParameters.Add("id", id);
                SqlDataSource2.DataBind();
                Image1.ImageUrl = "/WebSite1/image.aspx/?id=" + Request.Params["id"];
                //pt butonul sterge poza
                String uname2 = User.Identity.Name;
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
                con.Open();
                SqlCommand sql = new SqlCommand("SELECT [uname] as uname FROM [poza] WHERE [id]=@id", con);
                try
                {
                    sql.Parameters.AddWithValue("id", id);
                    var reader = sql.ExecuteReader();
                    if (reader.Read())
                    {
                        String uname3 = (String)reader["uname"];
                        Label2.Text = uname3;
                        if (uname2.CompareTo(uname3) == 0)
                        {
                            stergepoza.Visible = true;
                        }
                    }
                }
                catch
                {
                    ;
                }
            }
        }
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //var Label1 = (Label)LoginView2.FindControl("Label1");
        //var RadioButtonList1 = (RadioButtonList)LoginView2.FindControl("RadioButtonList1");
        var TextBox2 = (TextBox)LoginView2.FindControl("TextBox2");

        String uname = User.Identity.Name;
        var poza = Request.Params["id"];
        String text = TextBox2.Text;
        String query = "INSERT INTO comentarii (poza,text,username) VALUES(@poza,@text,@uname) ";

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.MDF;Integrated Security=True;User Instance=True");
        con.Open();
        SqlCommand sql = new SqlCommand(query, con);
        try
        {
            sql.Parameters.AddWithValue("text", text);
            sql.Parameters.AddWithValue("uname", uname);
            sql.Parameters.AddWithValue("poza", poza);
            sql.ExecuteNonQuery();
            con.Close();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        catch
        {
            var Label1 = (Label)LoginView2.FindControl("Label1");
            Label1.Text = "Eroare";
        }
    }
    protected void deleteCom(object sender, EventArgs e)
    {
        var Label1 = (Label)LoginView2.FindControl("Label1");
        Button btn = (Button)sender;
        var comId = btn.ValidationGroup;
        String idcom = comId;
        String uname2 = User.Identity.Name;
        String query = "DELETE FROM comentarii WHERE id_comentariu=@idcom ";

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.MDF;Integrated Security=True;User Instance=True");
        con.Open();
        SqlCommand sql = new SqlCommand(query, con);
        try
        {
            sql.Parameters.AddWithValue("idcom", idcom);
            sql.ExecuteNonQuery();
            con.Close();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        catch
        {
            Label1.Text = "Eroare";
        }
    }

    protected void deletePhoto(object sender, EventArgs e)
    {
        var Label1 = (Label)LoginView2.FindControl("Label1");
        String idphoto = Request.Params["id"];
        String uname2 = User.Identity.Name;
        String query = "DELETE FROM poza WHERE id=@idphoto ";

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.MDF;Integrated Security=True;User Instance=True");
        con.Open();
        SqlCommand sql = new SqlCommand(query, con);
        try
        {
            sql.Parameters.AddWithValue("idphoto", idphoto);
            sql.ExecuteNonQuery();
            con.Close();
            Page.Response.Redirect("http://localhost:50922/WebSite1/index.aspx", true);
        }
        catch
        {
            Label1.Text = "Eroare";
        }
    }


    protected Boolean CanDelete(String uname)
    {
        var Label2 = (Label)LoginView2.FindControl("Label2");
        Label2.Text = uname;
        var id = Request.Params["id"];
        String uname2 = User.Identity.Name;
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
        con.Open();
        SqlCommand sql = new SqlCommand("SELECT [uname] as uname FROM [poza] WHERE [id]=@id", con);
        try
        {
            sql.Parameters.AddWithValue("id", id);
            var reader = sql.ExecuteReader();
            if (reader.Read())
            {
                String uname3 = (String)reader["uname"];
                Label2.Text = uname3;
                if (uname.CompareTo(uname2)==0 || uname2.CompareTo(uname3)==0)
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
            return false;
        }
        return uname.CompareTo(uname2)==0;
    }
}