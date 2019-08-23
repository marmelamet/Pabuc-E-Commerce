using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AdminPanel_OneCikanUrunler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            List<SqlParameter> p = new List<SqlParameter>();
            DataTable dt = fiesta.dblayer.ReadSqlData("spSelectOneCikanUrunGorsel", p, CommandType.StoredProcedure);
            rptGorsel.DataSource = dt;
            rptGorsel.DataBind();
        }
    }
    protected void rptGorsel_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("GorselDuzenle"))
        {
            int urunId = Convert.ToInt32(e.CommandArgument);

            Response.Redirect("OneCikanUrunDuzenleme.aspx?p=" + urunId);
        }

        else if (e.CommandName.Equals("GorselSil"))
        {
            methodPanel.DeleteOneCikanUrunGorsel(Int32.Parse(((Button)e.Item.FindControl("BTN_GorselSil")).CommandArgument.ToString()), 1);
            ScriptManager.RegisterClientScriptBlock(Page, this.Page.GetType(), "kl", "alert('Öne çıkan ürün silme işlemi başarılı');", true);
            List<SqlParameter> p = new List<SqlParameter>();
            DataTable dt = fiesta.dblayer.ReadSqlData("spSelectOneCikanUrunGorsel", p, CommandType.StoredProcedure);
            rptGorsel.DataSource = dt;
            rptGorsel.DataBind();
        }
    }
}