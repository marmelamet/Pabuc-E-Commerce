using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class KullaniciDuzenle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetKullanici();
        }
    }
    public void SetKullanici()
    {
        List<SqlParameter> pars = new List<SqlParameter>();
        pars.Add(new SqlParameter("@userId", Request.QueryString["p"]));
        DataTable dt = fiesta.dblayer.ReadSqlData("spSelectKullanici", pars, CommandType.StoredProcedure);
        txtAd.Text = dt.Rows[0]["name"].ToString();
        txtSoyad.Text = dt.Rows[0]["name"].ToString();
        txtKullanici.Text = dt.Rows[0]["username"].ToString();
        txtSifre.Text = dt.Rows[0]["password"].ToString();
        for (int i = 0; i < ddlTip.Items.Count; i++)
            if (ddlTip.Items[i].Value == dt.Rows[0]["roleId"].ToString())
                ddlTip.SelectedIndex = i;

    }
    protected void BTN_Kaydet_Click(object sender, EventArgs e)
    {

        if (txtAd.Text != "")
        {
            try
            {

                List<SqlParameter> pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@userId", Request.QueryString["p"]));
                pars.Add(new SqlParameter("@name", txtAd.Text));
                pars.Add(new SqlParameter("@surname", txtSoyad.Text));
                pars.Add(new SqlParameter("@username", txtKullanici.Text));
                pars.Add(new SqlParameter("@password", txtSifre.Text));
                pars.Add(new SqlParameter("@roleId", Convert.ToInt32(ddlTip.SelectedValue)));
                pars.Add(new SqlParameter("@isDefault", "0"));
                int urunId = fiesta.dblayer.ExecSqlNonQuery("spUpdateKullanici", pars, CommandType.StoredProcedure);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Kullanıcı düzenleme işlemi başarılı.');", true);

            }

            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Kullanıcı düzenleme işlemi sırasında hata oluştu.');", true);
            }
        }
    }
    protected void dbType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}