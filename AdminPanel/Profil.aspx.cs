using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Profil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pnlSifre.Visible = false;

            if (Session["AdminUser"] != null)
            {
                fiesta.AdminUser ad = (fiesta.AdminUser)Session["AdminUser"];
                txtAd.Text = ad.name;
                txtSoyad.Text = ad.surname;
                txtEPosta.Text = ad.username;
            }
            else
                Response.Redirect("Login.aspx");
        }
    }
    protected void BTN_Kaydet_Click(object sender, EventArgs e)
    {
        fiesta.AdminUser ad = (fiesta.AdminUser)Session["AdminUser"];
        int sonuc = uye.UpdateProfil(ad.userId, txtEPosta.Text, txtAd.Text, txtSoyad.Text);
        if (sonuc > 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.Page.GetType(), "kl", "alert('İşlem başarılı');", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.Page.GetType(), "kl", "alert('İşlem sırasında  hata oluştu');", true);
        }
    }
    protected void btnSifreDegis_Click(object sender, EventArgs e)
    {
        fiesta.AdminUser ad = (fiesta.AdminUser)Session["AdminUser"];
        int sonuc = 0;
        if (txtYeniSifre1.Text != txtYeniSifre2.Text)
            sonuc = -1;
        int sn = uye.SifreDegistir(ad.userId, txtEPosta.Text, txtEskiSifre.Text, txtYeniSifre1.Text);
        if (sn <= 0)
            sonuc = -2;
        else
            sonuc = sn;
        switch (sonuc)
        {
            case 0: ScriptManager.RegisterClientScriptBlock(Page, this.Page.GetType(), "kl", "alert('Bir hata oluştu lütfen tekrar deneyiniz!');", true); break;
            case -1: ScriptManager.RegisterClientScriptBlock(Page, this.Page.GetType(), "kl", "alert('Şifreler uyuşmamakta, lütfen kontrol ediniz!');", true); break;
            case -2: ScriptManager.RegisterClientScriptBlock(Page, this.Page.GetType(), "kl", "alert('Bir hata oluştu lütfen Sistem yöneticinize başvurun!');", true); break;
            default: ScriptManager.RegisterClientScriptBlock(Page, this.Page.GetType(), "kl", "alert('Şifreniz başarı ile değiştirildi.');", true); break;
        }
    }
    protected void lbtnPass_Click(object sender, EventArgs e)
    {
        pnlKullanici.Visible = false;
        pnlSifre.Visible = true;
    }
    protected void lbtnGirisBilgi_Click(object sender, EventArgs e)
    {
        pnlKullanici.Visible = true;
        pnlSifre.Visible = false;
    }
    protected void uppnl1_PreRender(object sender, EventArgs e)
    {
        ScriptManager sc = ScriptManager.GetCurrent(Page);
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "setItems2", "setItems();", true);
    }
}