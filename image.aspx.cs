using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class image : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request.Params["id"];
        if (string.IsNullOrEmpty(id))
        {
            //id lipseste, do something 
            return;
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
        con.Open();
        SqlCommand sql = new SqlCommand("SELECT poza FROM poza WHERE id=@id", con);
        try
        {
            sql.Parameters.AddWithValue("id", id);
            var reader = sql.ExecuteReader();
            if (reader.Read())
            {
                Response.ContentType = "image/png";
                Response.BinaryWrite((byte[])reader["poza"]);
            }
        }
        catch
        {
            return;
        }
    }
}