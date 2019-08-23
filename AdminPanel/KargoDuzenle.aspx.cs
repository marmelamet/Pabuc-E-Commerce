using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class KargoDuzenle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetKargolar();
        }
    }
    public void SetKargolar()
    {
        List<SqlParameter> pars = new List<SqlParameter>();
        pars.Add(new SqlParameter("@_id", Request.QueryString["p"]));
        DataTable dt = fiesta.dblayer.ReadSqlData("spSelectKargo", pars, CommandType.StoredProcedure);

        txtAd.Text = dt.Rows[0]["kargoFirmasi"].ToString();
        txtFiyat.Text = dt.Rows[0]["kargotutari"].ToString();
        txtKdv.Text = dt.Rows[0]["kdv"].ToString();
    }
    protected void BTN_Kaydet_Click(object sender, EventArgs e)
    {
        if (txtAd.Text != "")
        {
            try
            {
                List<SqlParameter> pars = new List<SqlParameter>();
                decimal kdvDahil = 0;
                kdvDahil = Convert.ToDecimal(txtFiyat.Text) * Convert.ToDecimal(txtKdv.Text) / 100 + Convert.ToDecimal(txtFiyat.Text);
                pars.Add(new SqlParameter("@_id", Request.QueryString["p"]));
                pars.Add(new SqlParameter("@kargotutari", Convert.ToDouble(txtFiyat.Text)));
                pars.Add(new SqlParameter("@kdv",Convert.ToDouble(txtKdv.Text)));
                pars.Add(new SqlParameter("@kdvDahil", kdvDahil));
                pars.Add(new SqlParameter("@kargoFirmasi", txtAd.Text));
                fiesta.dblayer.ExecSqlNonQuery("spUpdateKargo", pars, CommandType.StoredProcedure);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Kargo düzenleme işlemi başarılı.');", true);

            }

            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Kargo düzenleme işlemi sırasında hata oluştu.');", true);
            }
        }
    }
}