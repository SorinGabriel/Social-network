using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.Params["nume"]))
        {
            var SqlDataSource1 = (SqlDataSource)LoginView1.FindControl("SqlDataSource1");
            string q = Request.Params["nume"];
            SqlDataSource1.SelectCommand = "SELECT [UserId], [UserName], [IsAnonymous] FROM [vw_aspnet_Users] WHERE [UserName] LIKE @q and [IsAnonymous] = 0";
            SqlDataSource1.SelectParameters.Add("q", "%" + q + "%");
            SqlDataSource1.DataBind();
            var SqlDataSource2 = (SqlDataSource)LoginView1.FindControl("SqlDataSource2");
            SqlDataSource2.SelectCommand = "SELECT [grup_id], [grupname] FROM [grupuri] WHERE [grupname] LIKE @q";
            SqlDataSource2.SelectParameters.Add("q", "%" + q + "%");
            SqlDataSource2.DataBind();
        }
        else
        {
            var SqlDataSource1 = (SqlDataSource)LoginView1.FindControl("SqlDataSource1");
            string q = "";
            SqlDataSource1.SelectCommand = "SELECT [UserId], [UserName], [IsAnonymous] FROM [vw_aspnet_Users] WHERE [UserName] LIKE @q and [IsAnonymous] = 0";
            SqlDataSource1.SelectParameters.Add("q", "%" + q + "%");
            SqlDataSource1.DataBind();
            var SqlDataSource2 = (SqlDataSource)LoginView1.FindControl("SqlDataSource2");
            SqlDataSource2.SelectCommand = "SELECT [grup_id], [grupname] FROM [grupuri] WHERE [grupname] LIKE @q";
            SqlDataSource2.SelectParameters.Add("q", "%" + q + "%");
            SqlDataSource2.DataBind();
        }
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void LoginView1_ViewChanged(object sender, EventArgs e)
    {

    }
    protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
}