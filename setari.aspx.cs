using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class setari : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        var Label1 = (Label)LoginView2.FindControl("Label1");
        var RadioButtonList1 = (RadioButtonList)LoginView2.FindControl("RadioButtonList1");

        String uname = User.Identity.Name;
        String nouisan = RadioButtonList1.SelectedValue;
        String query = "UPDATE [vw_aspnet_Users] SET [IsAnonymous]=@nouisan WHERE [UserName]=@uname ";

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\ASPNETDB.MDF;Integrated Security=True;User Instance=True");
        con.Open();
        SqlCommand sql = new SqlCommand(query, con);
        try
        {
            sql.Parameters.AddWithValue("nouisan", nouisan);
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