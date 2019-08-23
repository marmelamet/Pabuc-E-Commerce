using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class UrunEkleme : System.Web.UI.Page
{
    public string filename;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           DataTable dtkategori = fiesta.dblayer.ReadSqlData("select * from kategoriler where isDefault=0 order by kategoriAd", null, CommandType.Text);
            dllKategori.Items.Clear();
            dllKategori.Items.Add(new ListItem("Seçiniz", "0"));
            for (int i = 0; i < dtkategori.Rows.Count; i++)
                dllKategori.Items.Add(new ListItem(dtkategori.Rows[i]["kategoriAd"].ToString(), dtkategori.Rows[i]["kategoriId"].ToString()));
        }
       
    }
    protected void BTN_Kaydet_Click(object sender, EventArgs e)
    {
        if (txtKod.Text != "")
        {
            try
            {
                List<SqlParameter> pars = new List<SqlParameter>();
                decimal kdvDahil = 0;
                kdvDahil = Convert.ToDecimal(txtFiyat.Text) * Convert.ToDecimal(txtKdv.Text) / 100 + Convert.ToDecimal(txtFiyat.Text);
                pars.Add(new SqlParameter("@kategoriId",Convert.ToInt32(dllKategori.SelectedValue)));
                pars.Add(new SqlParameter("@urunKod", txtKod.Text));
                pars.Add(new SqlParameter("@urunAd", txtAd.Text));
                pars.Add(new SqlParameter("@urunOzellik", fckOzellik.Text));
                pars.Add(new SqlParameter("@fiyat", Convert.ToDouble(txtFiyat.Text)));
                pars.Add(new SqlParameter("@kdv", Convert.ToDouble(txtKdv.Text)));
                pars.Add(new SqlParameter("@kdvDahil", kdvDahil));
                pars.Add(new SqlParameter("@oneCikanResim", ""));
                pars.Add(new SqlParameter("@isDefault", "0"));
                int urunId = fiesta.dblayer.ExecSqlNonQuery("spInsertUrunler", pars, CommandType.StoredProcedure);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Ürün kaydetme işlemi başarılı.');", true);
                hidUrunId.Value = urunId.ToString(); 
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Ürün kaydetme işlemi sırasında hata oluştu.');", true);
            }
        }
    }
    protected void uppnl1_PreRender(object sender, EventArgs e)
    {
        ScriptManager sc = ScriptManager.GetCurrent(Page);
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "setItems2", "setItems();", true);
    }
    protected void btnResim_Click(object sender, EventArgs e)
    {
        if (filepicture.HasFile)
        {
            if (filepicture.PostedFile.ContentLength <= 2097512)
            {
                try
                {
                    string fileextension = Path.GetExtension(filepicture.PostedFile.FileName);
                    filename = DateTime.Now.ToString().Replace(".", "").Replace(":", "").Replace(" ", "").Replace("/",
"").Replace("\\", "");
                    filename = "../UrunResim/" + filename + hidUrunId.Value + fileextension;
                    filepicture.SaveAs(Server.MapPath(filename));

                    List<SqlParameter> pars = new List<SqlParameter>();
                    pars.Add(new SqlParameter("@resimAd", txtResim.Text));
                    pars.Add(new SqlParameter("@resim", filename));
                    pars.Add(new SqlParameter("@urunId", Convert.ToInt32(hidUrunId.Value)));
                    pars.Add(new SqlParameter("@isDefault", "0"));
                    int resimId = fiesta.dblayer.ExecSqlNonQuery("spInsertResimler", pars, CommandType.StoredProcedure);
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Resim kaydetme işlemi başarılı.');", true);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Resim kaydetme işlemi başarısız.');", true);
                }

            }
        }
    }
    protected void btnDetay_Click(object sender, EventArgs e)
    {
        if (dllKategori.SelectedItem.Text == "Çanta")
        {
            try
            {
                List<SqlParameter> pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@urunId", Convert.ToInt32(hidUrunId.Value)));
                pars.Add(new SqlParameter("@numara", "-1"));
                pars.Add(new SqlParameter("@adet", Convert.ToInt32(txtAdet.Text)));
                pars.Add(new SqlParameter("@isDefault","0"));
                int urunId = fiesta.dblayer.ExecSqlNonQuery("spInsertStok", pars, CommandType.StoredProcedure);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Ürün detay kaydetme işlemi başarılı.');", true);
                hidUrunId.Value = urunId.ToString();
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Ürün detay kaydetme işlemi sırasında hata oluştu.');", true);
            }
        }
        else
        {
            try
            {
                List<SqlParameter> pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@urunId", Convert.ToInt32(hidUrunId.Value)));
                pars.Add(new SqlParameter("@numara", Convert.ToInt32(txtNumara.Text)));
                pars.Add(new SqlParameter("@adet", Convert.ToInt32(txtAdet.Text)));
                pars.Add(new SqlParameter("@isDefault", "0"));

                int urunId = fiesta.dblayer.ExecSqlNonQuery("spInsertStok", pars, CommandType.StoredProcedure);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Ürün detay kaydetme işlemi başarılı.');", true);
                hidUrunId.Value = urunId.ToString();
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Ürün detay kaydetme işlemi sırasında hata oluştu.');", true);
            }
        }
    }
}