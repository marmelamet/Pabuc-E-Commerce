using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class KullaniciEkleme : System.Web.UI.Page
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
                pars.Add(new SqlParameter("@name", txtAd.Text));
                pars.Add(new SqlParameter("@surname", txtSoyad.Text));
                pars.Add(new SqlParameter("@username", txtKullanici.Text));
                pars.Add(new SqlParameter("@password",txtSifre.Text));
                pars.Add(new SqlParameter("@roleId", Convert.ToInt32(ddlTip.SelectedValue)));
                pars.Add(new SqlParameter("@isDefault", "0"));
                int urunId = fiesta.dblayer.ExecSqlNonQuery("spInsertKullanici", pars, CommandType.StoredProcedure);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Kullanıcı kaydetme işlemi başarılı.');", true);
                Temizle();
            }

            catch 
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Kullanıcı kaydetme işlemi sırasında hata oluştu.');", true);
            }
        }
    }
    protected void dbType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public void Temizle()
    {
        txtAd.Text = "";
        txtSoyad.Text = "";
        txtKullanici.Text = "";
        txtSifre.Text = "";
        ddlTip.SelectedIndex = -1;
    }
}