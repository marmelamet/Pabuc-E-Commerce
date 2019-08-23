using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Kullanicilar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            DataTable dt = fiesta.dblayer.ReadSqlData("select * from kullanicilar where isDefault=0",CommandType.Text);
            rptKullanici.DataSource = dt;
            rptKullanici.DataBind();
        }
    }
    protected void rptKullanici_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("KullaniciDuzenle"))
        {
            int kullaniciId = Convert.ToInt32(e.CommandArgument);

            Response.Redirect("KullaniciDuzenle.aspx?p=" + kullaniciId);
        }

        else if (e.CommandName.Equals("KullaniciSil"))
        {
            methodPanel.DeleteKullanicilar(Int32.Parse(((Button)e.Item.FindControl("BTN_KullaniciSil")).CommandArgument.ToString()), 1);
            ScriptManager.RegisterClientScriptBlock(Page, this.Page.GetType(), "kl", "alert('Silme işlemi başarılı');", true);

            List<SqlParameter> pars = new List<SqlParameter>();
            DataTable dt = fiesta.dblayer.ReadSqlData("select * from kullanicilar where isDefault=0", CommandType.Text);
            rptKullanici.DataSource = dt;
            rptKullanici.DataBind();
        }
    }
}