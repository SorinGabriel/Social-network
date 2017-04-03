using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var TextBox1 = (TextBox)LoginView2.FindControl("TextBox1");
        var TextBox2 = (TextBox)LoginView2.FindControl("TextBox2");
        String mesaj = TextBox2.Text;
        String user = TextBox1.Text;
        String query = "INSERT INTO notificariadmin (userul,mesaj) VALUES(@use,@mes) ";

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.MDF;Integrated Security=True;User Instance=True");
        con.Open();
        SqlCommand sql = new SqlCommand(query, con);
        try
        {
            sql.Parameters.AddWithValue("use", user);
            sql.Parameters.AddWithValue("mes", mesaj);
            sql.ExecuteNonQuery();
            con.Close();
            var Label1 = (Label)LoginView2.FindControl("Label1");
            Label1.Text = "Succes";
        }
        catch
        {
            var Label1 = (Label)LoginView2.FindControl("Label1");
            Label1.Text = "Eroare";
        }
    }
}