using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class creazaalbum : System.Web.UI.Page
{

    protected void Button2_Click(object sender, EventArgs e)
    {
        var TextBox2 = (TextBox)LoginView2.FindControl("TextBox2");
        var Label1 = (Label)LoginView2.FindControl("Label1");
        String uname = User.Identity.Name;
        String album = TextBox2.Text;
        String query = "INSERT INTO albume VALUES (@uname,@numealbum) ";

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
        con.Open();
        SqlCommand sql = new SqlCommand(query, con);
        try
        {
            sql.Parameters.AddWithValue("numealbum", album);
            sql.Parameters.AddWithValue("uname", uname);
            sql.ExecuteNonQuery();
            Label1.Text = "Succes";
            con.Close();
        }
        catch
        {
            Label1.Text = "Eroare";
        }
    }
    protected void LoginView2_ViewChanged(object sender, EventArgs e)
    {

    }
}