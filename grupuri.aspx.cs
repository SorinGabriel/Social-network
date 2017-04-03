using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class grupuri : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string q = User.Identity.Name;
        //var SqlDataSource1 = (SqlDataSource)LoginView2.FindControl("SqlDataSource1");
        SqlDataSource1.SelectCommand = "SELECT [apartine].[grup] as id, [grupuri].[grupname] as nume FROM [apartine] INNER JOIN [grupuri] ON [apartine].[grup]=[grupuri].[grup_id] WHERE [apartine].[username] = @q";
        SqlDataSource1.SelectParameters.Add("q",q);
        SqlDataSource1.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //var TextBox2 = (TextBox)LoginView2.FindControl("TextBox2");
        //var Label1 = (Label)LoginView2.FindControl("Label1");
        String uname = User.Identity.Name;
        String nume = TextBox2.Text;
        String query = "INSERT INTO grupuri (grupname,admin) VALUES (@nume,@uname) ";

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
        con.Open();
        SqlCommand sql = new SqlCommand(query, con);
        try
        {
            sql.Parameters.AddWithValue("nume", nume);
            sql.Parameters.AddWithValue("uname", uname);
            sql.ExecuteNonQuery();
            Label1.Text = "Grupul a fost creat";
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
}