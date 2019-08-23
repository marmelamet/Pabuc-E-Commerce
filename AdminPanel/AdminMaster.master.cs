using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    
        if (!Page.IsPostBack)
        {
            if (Session["AdminUser"] != null)
            {
                fiesta.AdminUser ad = (fiesta.AdminUser)Session["AdminUser"];
                ltOnUser.Text = ad.name + " " + ad.surname;
                ltJobName.Text = ad.roleAd;
            }
            else
                Response.Redirect("Login.aspx");
        }
    }
}
