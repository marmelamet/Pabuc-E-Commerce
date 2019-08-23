using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LeftMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            if (Session["AdminUser"] != null)
            {
                if (((fiesta.AdminUser)Session["AdminUser"]).roleAd == "Admin")
                {
                    pnlAdmin.Visible = true;
                }
                else
                {
                    pnlAdmin.Visible = false;
                }
            }
        }
    }
}