using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class KargoEkleme : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            
        }
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
                pars.Add(new SqlParameter("@kargotutari", Convert.ToDouble(txtFiyat.Text)));
                pars.Add(new SqlParameter("@kdv",Convert.ToDouble(txtKdv.Text)));
                pars.Add(new SqlParameter("@kdvDahil", kdvDahil));
                pars.Add(new SqlParameter("@kargoFirmasi", txtAd.Text));
                fiesta.dblayer.ExecSqlNonQuery("spInsertKargo", pars, CommandType.StoredProcedure);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Kargo kaydetme işlemi başarılı.');", true);
              
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Kargo kaydetme işlemi sırasında hata oluştu.');", true);
            }
        }
    }
}