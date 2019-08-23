using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Kargolar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = fiesta.dblayer.ReadSqlData("select * from KargoBilgisi", CommandType.Text);
            rptKargo.DataSource = dt;
            rptKargo.DataBind();
        }
    }
    protected void rptKargo_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("KargoDuzenle"))
        {
            int urunId = Convert.ToInt32(e.CommandArgument);

            Response.Redirect("KargoDuzenle.aspx?p=" + urunId);
        }

        else if (e.CommandName.Equals("KargoSil"))
        {
            methodPanel.DeleteUrunler(Int32.Parse(((Button)e.Item.FindControl("BTN_KargoSil")).CommandArgument.ToString()), 1);
            ScriptManager.RegisterClientScriptBlock(Page, this.Page.GetType(), "kl", "alert('Kargo silme işlemi başarılı');", true);
            DataTable dt = fiesta.dblayer.ReadSqlData("select * from KargoBilgisi", CommandType.Text);
            rptKargo.DataSource = dt;
            rptKargo.DataBind();
        }
    }
}