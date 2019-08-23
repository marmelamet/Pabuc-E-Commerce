using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Kategoriler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            DataTable dt = fiesta.dblayer.ReadSqlData("select * from kategoriler where isDefault=0", CommandType.Text);
            rptKategori.DataSource = dt;
            rptKategori.DataBind();
        }
    }
    protected void rptKategori_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("KategoriDuzenle"))
        {
            int kategoriId = Convert.ToInt32(e.CommandArgument);

            Response.Redirect("KategoriDuzenle.aspx?p=" + kategoriId);
        }

        else if (e.CommandName.Equals("KategoriSil"))
        {
            methodPanel.DeleteKategoriler(Int32.Parse(((Button)e.Item.FindControl("BTN_KategoriSil")).CommandArgument.ToString()), 1);
            ScriptManager.RegisterClientScriptBlock(Page, this.Page.GetType(), "kl", "alert('Silme işlemi başarılı');", true);

            List<SqlParameter> pars = new List<SqlParameter>();
            DataTable dt = fiesta.dblayer.ReadSqlData("select * from kategoriler where isDefault=0", CommandType.Text);
            rptKategori.DataSource = dt;
            rptKategori.DataBind();
        }
    }
}