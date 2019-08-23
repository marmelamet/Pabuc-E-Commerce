using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class KullaniciSozlesmesi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            List<SqlParameter> p = new List<SqlParameter>();
            p.Add(new SqlParameter("@kullaniciIsdefault","0"));
            DataTable dt = fiesta.dblayer.ReadSqlData("spSelectKullaniciSozlesmesi", p, CommandType.StoredProcedure);
            fckOzellik.Text = dt.Rows[0]["kullaniciSozlemesi"].ToString();
        
        }
    }
    protected void BTN_Kaydet_Click(object sender, EventArgs e)
    {
        if (fckOzellik.Text != "")
        {
            try
            {
                List<SqlParameter> pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@kullaniciSozlemesi", fckOzellik.Text));
                pars.Add(new SqlParameter("@kullaniciIsdefault", "0"));
                fiesta.dblayer.ExecSqlNonQuery("spInsertKullaniciSozlesmesi", pars, CommandType.StoredProcedure);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Kullanıcı Sözleşmesi düzenleme işlemi başarılı.');", true);

            }

            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Kullanıcı Sözleşmesi düzenleme işlemi sırasında hata oluştu.');", true);
            }
        }
    }
}