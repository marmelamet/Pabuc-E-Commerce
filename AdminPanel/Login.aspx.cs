using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";
        Response.Cache.SetNoStore();

        Session.Timeout = 120;

        if (!IsPostBack)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
        }
    }
    protected void cmdLogin_Click(object sender, EventArgs e)
    {
        if (txtPassword.Text != "" && txtUsername.Text != "")
        {
            fiesta.AdminUser ad = fiesta.process.Login(txtUsername.Text, txtPassword.Text);
            if (ad.userId == -1)
                ltError.Text = "<br /><span class='alert-error'>Kullanıcı bulunamadı, bilgileriniz kontrol ediniz.</span>";
            else
            {
                Session["AdminUser"] = ad;
                Response.Redirect("SiparisListesi.aspx");
            }
        }
        else
            ltError.Text = "<br /><span class='alert-error'>Lütfen kullanıcı adı ve parolanızı giriniz.</span>";
    }
}