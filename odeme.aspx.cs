using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

public partial class odeme : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //ddl_il.DataSource = SqlDataSource1;
            //ddl_il.DataBind();
            
            List<ObjsiparisUrunler> sepet = new List<ObjsiparisUrunler>();
            if (Session["SepetUrunler"] != null)
            {
                sepet = ((List<ObjsiparisUrunler>)Session["SepetUrunler"]);
                rptBasket.DataSource = sepet;
                rptBasket.DataBind();
            }
        }
    }

    protected void btn_odeme_yap_Click(object sender, EventArgs e)
    {
        if (txt_tc_kimlik_no.Text != "")
        {
            try
            {
                List<SqlParameter> pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@tc", txt_tc_kimlik_no.Text));
                pars.Add(new SqlParameter("@ad", txt_ad.Text));
                pars.Add(new SqlParameter("@soyad", txt_soyad.Text));
                pars.Add(new SqlParameter("@telefon", txt_tel.Text));
                pars.Add(new SqlParameter("@sehirId", Convert.ToInt32(ddl_il.SelectedValue)));
                pars.Add(new SqlParameter("@ilceId", Convert.ToInt32(ddl_ilce.SelectedValue)));
                pars.Add(new SqlParameter("@adres", txt_adres.Text));
                pars.Add(new SqlParameter("@email", txt_email.Text));
                pars.Add(new SqlParameter("@toplamFiyat", ""));
                pars.Add(new SqlParameter("@paraBirimi", ""));
                pars.Add(new SqlParameter("@islemTarihi", DateTime.Now));
                pars.Add(new SqlParameter("@indirmeKod", ""));
                pars.Add(new SqlParameter("@isDefault", "0"));
                int urunId = fiesta.dblayer.ExecSqlNonQuery("spInsertSiparisler", pars, CommandType.StoredProcedure);
               // ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Kullanıcı kaydetme işlemi başarılı.');", true);
            }

            catch
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('İşlemi sırasında hata oluştu.');", true);
            }
        }
    }

    protected void ddl_il_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_ilce.Items.Clear();//il bilgisi seçildiğinde ilçeler tekrar doldurmak için öncekiler siliniyor

        ddl_ilce.Items.Insert(0, new ListItem("İlçe Seçiniz..", "0"));// İlçe seçiniz ibaresi ekleniyor
                                                                              //seçilen il bilgisi alınıyor
        int il = Int32.Parse(ddl_il.SelectedItem.Value);

        if(il == 1)
        { 

            ddl_ilce.Items.Insert(1, new ListItem("Altındağ", "1"));
            ddl_ilce.Items.Insert(2, new ListItem("Çankaya", "2"));
            ddl_ilce.Items.Insert(3, new ListItem("Etimesgut", "3"));
            ddl_ilce.Items.Insert(4, new ListItem("Keçiören", "4"));
            ddl_ilce.Items.Insert(5, new ListItem("Sincan", "5"));
            ddl_ilce.Items.Insert(6, new ListItem("Yenimahalle", "6"));
        }
    }
}
