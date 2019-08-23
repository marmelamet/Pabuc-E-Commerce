using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class KategoriEkleme : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
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
                pars.Add(new SqlParameter("@kategoriAd", txtAd.Text));
                pars.Add(new SqlParameter("@isDefault", "0"));
                int urunId = fiesta.dblayer.ExecSqlNonQuery("spInsertKategoriler", pars, CommandType.StoredProcedure);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Kategori kaydetme işlemi başarılı.');", true);
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Kategroi kaydetme işlemi sırasında hata oluştu.');", true);
            }
        }
    }
}