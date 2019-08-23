using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Slider : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            List<SqlParameter> p = new List<SqlParameter>();
            DataTable dt = fiesta.dblayer.ReadSqlData("spSelectSlider", p, CommandType.StoredProcedure);
            rptSlider.DataSource = dt;
            rptSlider.DataBind();
        }
    }
    protected void rptSlider_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("SliderDuzenle"))
        {
            int urunId = Convert.ToInt32(e.CommandArgument);

            Response.Redirect("SliderDuzenle.aspx?p=" + urunId);
        }

        else if (e.CommandName.Equals("SliderSil"))
        {
            methodPanel.DeleteSlider(Int32.Parse(((Button)e.Item.FindControl("BTN_SliderSil")).CommandArgument.ToString()), 1);
            ScriptManager.RegisterClientScriptBlock(Page, this.Page.GetType(), "kl", "alert('Slider silme işlemi başarılı');", true);
            List<SqlParameter> p = new List<SqlParameter>();
            DataTable dt = fiesta.dblayer.ReadSqlData("spSelectSlider", p, CommandType.StoredProcedure);
            rptSlider.DataSource = dt;
            rptSlider.DataBind();
        }
    }
}