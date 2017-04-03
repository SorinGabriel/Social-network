using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var TextBox1 = (TextBox)LoginView1.FindControl("TextBox1");
        Response.Redirect("/WebSite1/cauta.aspx/?nume=" + TextBox1.Text);
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}
