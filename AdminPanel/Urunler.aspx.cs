using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Urunler : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataTable dt = fiesta.dblayer.ReadSqlData("select * from urunler where isDefault=0", CommandType.Text);
            rptUrun.DataSource = dt;
            rptUrun.DataBind();
        }
    }
    protected void rptUrun_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("UrunDuzenle"))
        {
            int urunId = Convert.ToInt32(e.CommandArgument);

            Response.Redirect("UrunDuzenle.aspx?p=" + urunId);
        }

        else if (e.CommandName.Equals("UrunSil"))
        {
            methodPanel.DeleteUrunler(Int32.Parse(((Button)e.Item.FindControl("BTN_UrunSil")).CommandArgument.ToString()), 1);
            ScriptManager.RegisterClientScriptBlock(Page, this.Page.GetType(), "kl", "alert('Ürün silme işlemi başarılı');", true);
            DataTable dt = fiesta.dblayer.ReadSqlData("select * from urunler where isDefault=0", CommandType.Text);
            rptUrun.DataSource = dt;
            rptUrun.DataBind();
        }
    }
    protected void uppnl1_PreRender(object sender, EventArgs e)
    {
        ScriptManager sc = ScriptManager.GetCurrent(Page);
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "setItems2", "setItems();", true);
    }
}