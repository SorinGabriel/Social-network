using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class albume : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var Label1 = (Label) LoginView2.FindControl("Label1");
        var SqlDataSource1 = (SqlDataSource) LoginView2.FindControl("SqlDataSource1");
        Label1.Text = Request.Params["numealbum"];
        SqlDataSource1.SelectCommand = "SELECT [id] FROM [poza] where [album]=@param";
        SqlDataSource1.SelectParameters.Add("param", Request.Params["numealbum"]);
        SqlDataSource1.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        var Label2 = (Label)LoginView2.FindControl("Label2");
        var FileUpload1 = (FileUpload)LoginView2.FindControl("FileUpload1");
        if (!FileUpload1.HasFile)
        {
            Label2.Text = "Please Select Image File";    //checking if file uploader has no file selected
        }
        else
        {
            byte[] pic = FileUpload1.FileBytes;//aici e ok? da da eroare?
            String uname = User.Identity.Name;
            String album = Request.Params["numealbum"];
            String query = "INSERT INTO poza (album, poza, uname) VALUES (@numealbum, @poza,@uname) "; //stai ah dap

            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            SqlCommand sql = new SqlCommand(query, con);
            try
            {
                sql.Parameters.AddWithValue("poza", pic);
                sql.Parameters.AddWithValue("numealbum", album);
                sql.Parameters.AddWithValue("uname", uname);
                sql.ExecuteNonQuery();
                Label2.Text = "Succes";
                con.Close();
            }//pot eu sa iti fac image.aspx daca vrei sau pot sa te las pe tine sa cauti... ce vrei.arata-mi ca ex
                //nu prea e "exemplu" ca o sa folosesti dupa sta ceva de genu
                //image.aspx?id=1 ca image source pt <img>..arata-mi oricum ca eu probabil o sa gasesc greu k
            catch
            {
                Label2.Text = "Eroare";
            }
        }
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void LoginView2_ViewChanged(object sender, EventArgs e)
    {

    }
}