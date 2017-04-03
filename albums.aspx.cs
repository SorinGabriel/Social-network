using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class albums : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack && User.Identity.IsAuthenticated)
        {
            var username = User.Identity.Name;
            var SqlDataSource3 = (SqlDataSource)LoginView2.FindControl("SqlDataSource3");
            SqlDataSource3.SelectCommand = "SELECT [numealbum] FROM [albume] where username=@param";
            SqlDataSource3.SelectParameters.Add("param", username);
            SqlDataSource3.DataBind();
        }
    }
    protected void LoginView2_ViewChanged(object sender, EventArgs e)
    {
    }
}