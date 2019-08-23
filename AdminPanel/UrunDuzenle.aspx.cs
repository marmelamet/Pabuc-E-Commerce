using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class UrunDuzenle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataTable dtkategori = fiesta.dblayer.ReadSqlData("select * from kategoriler where isDefault=0 order by kategoriAd", null, CommandType.Text);
            dllKategori.Items.Clear();
            dllKategori.Items.Add(new ListItem("Seçiniz", "0"));
            for (int i = 0; i < dtkategori.Rows.Count; i++)
                dllKategori.Items.Add(new ListItem(dtkategori.Rows[i]["kategoriAd"].ToString(), dtkategori.Rows[i]["kategoriId"].ToString()));

            List<SqlParameter> pars1 = new List<SqlParameter>();
            pars1.Add(new SqlParameter("@urunId", Request.QueryString["p"]));
            pars1.Add(new SqlParameter("@isDefault", "0"));
            DataTable dtresim = fiesta.dblayer.ReadSqlData("spSelectResimler", pars1, CommandType.StoredProcedure);
            rptResim.DataSource = dtresim;
            rptResim.DataBind();

            List<SqlParameter> pars2 = new List<SqlParameter>();
            pars2.Add(new SqlParameter("@urunId", Request.QueryString["p"]));
            DataTable dtdetay = fiesta.dblayer.ReadSqlData("spSelectStok", pars2, CommandType.StoredProcedure);
            rptDetay.DataSource = dtdetay;
            rptDetay.DataBind();

            SetUrunler();
        }

    }
    public string filename;
    public void SetUrunler()
    {
        List<SqlParameter> pars = new List<SqlParameter>();
        pars.Add(new SqlParameter("@urunId", Request.QueryString["p"]));
        DataTable dt = fiesta.dblayer.ReadSqlData("spSelectUrunler", pars, CommandType.StoredProcedure);
        for (int i = 0; i < dllKategori.Items.Count; i++)
            if (dllKategori.Items[i].Value == dt.Rows[0]["kategoriId"].ToString())
                dllKategori.SelectedIndex = i;
        txtKod.Text = dt.Rows[0]["urunKod"].ToString();
        txtAd.Text = dt.Rows[0]["urunAd"].ToString();
        fckOzellik.Text= dt.Rows[0]["urunOzellik"].ToString();
        txtFiyat.Text = dt.Rows[0]["fiyat"].ToString();
        txtKdv.Text = dt.Rows[0]["kdv"].ToString();

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
                pars.Add(new SqlParameter("@urunId", Request.QueryString["p"]));
                pars.Add(new SqlParameter("@kategoriId", Convert.ToInt32(dllKategori.SelectedValue)));
                pars.Add(new SqlParameter("@urunKod", txtKod.Text));
                pars.Add(new SqlParameter("@urunAd", txtAd.Text));
                pars.Add(new SqlParameter("@urunOzellik", fckOzellik.Text));
                pars.Add(new SqlParameter("@fiyat", Convert.ToDouble(txtFiyat.Text)));
                pars.Add(new SqlParameter("@kdv", Convert.ToDouble(txtKdv.Text)));
                pars.Add(new SqlParameter("@kdvDahil", kdvDahil));
                pars.Add(new SqlParameter("@oneCikanResim", ""));
                pars.Add(new SqlParameter("@isDefault", "0"));
                int urunId = fiesta.dblayer.ExecSqlNonQuery("spUpdateUrunler", pars, CommandType.StoredProcedure);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Ürün düzenleme işlemi başarılı.');", true);

            }

            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Ürün düzenleme işlemi sırasında hata oluştu.');", true);
            }
        }
    }
    protected void rptDetay_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("DetayDuzenle"))
        {
            int detayId = Convert.ToInt32(e.CommandArgument);

            hidDurum.Value = detayId.ToString();

            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@stokId", detayId));
            DataTable dt = fiesta.dblayer.ReadSqlData("spSelectStokById", pars, CommandType.StoredProcedure);
            txtNumara.Text = dt.Rows[0]["numara"].ToString();
            txtAdet.Text = dt.Rows[0]["adet"].ToString();
        }

        else  if (e.CommandName.Equals("DetaySil"))
        {
            methodPanel.DeleteStok(Int32.Parse(((Button)e.Item.FindControl("BTN_DetaySil")).CommandArgument.ToString()),1);
            ScriptManager.RegisterClientScriptBlock(Page, this.Page.GetType(), "kl", "alert('Ürün detay silme işlemi başarılı');", true);
            DataTable dt = methodPanel.SelectStok(0);
            rptDetay.DataSource = dt;
            rptDetay.DataBind();
        }
    }
    protected void btnDetay_Click(object sender, EventArgs e)
    {

        if (dllKategori.SelectedItem.Text == "Çanta")
        {
            try
            {
                List<SqlParameter> pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@stokId", hidDurum.Value));
                pars.Add(new SqlParameter("@urunId", Request.QueryString["p"]));
                pars.Add(new SqlParameter("@numara", "-1"));
                pars.Add(new SqlParameter("@adet", Convert.ToInt32(txtAdet.Text)));
                pars.Add(new SqlParameter("@isDefault", "0"));
                int urunId = fiesta.dblayer.ExecSqlNonQuery("spUpdateStok", pars, CommandType.StoredProcedure);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Ürün detay düzenleme işlemi başarılı.');", true);
                hidUrunId.Value = urunId.ToString();
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Ürün detay düzenleme işlemi sırasında hata oluştu.');", true);
            }
        }
        else
        {
            try
            {
                List<SqlParameter> pars = new List<SqlParameter>();
                pars.Add(new SqlParameter("@stokId", hidDurum.Value));
                pars.Add(new SqlParameter("@urunId", Request.QueryString["p"]));
                pars.Add(new SqlParameter("@numara", Convert.ToInt32(txtNumara.Text)));
                pars.Add(new SqlParameter("@adet", Convert.ToInt32(txtAdet.Text)));
                pars.Add(new SqlParameter("@isDefault", "0"));
                int urunId = fiesta.dblayer.ExecSqlNonQuery("spUpdateStok", pars, CommandType.StoredProcedure);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Ürün detay düzenleme işlemi başarılı.');", true);
                hidUrunId.Value = urunId.ToString();
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Ürün detay düzenleme işlemi sırasında hata oluştu.');", true);
            }
        }
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
                    pars.Add(new SqlParameter("@urunId", Request.QueryString["p"]));
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
    protected void rptResim_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("ResimSil"))
        {
            methodPanel.DeleteResimler(Int32.Parse(((Button)e.Item.FindControl("BTN_ResimSil")).CommandArgument.ToString()), 1);
            ScriptManager.RegisterClientScriptBlock(Page, this.Page.GetType(), "kl", "alert('Resim silme işlemi başarılı');", true);
            DataTable dt = methodPanel.SelectResimler(0);
            rptResim.DataSource = dt;
            rptResim.DataBind();
        }
    }
    protected void uppnl1_PreRender(object sender, EventArgs e)
    {
        ScriptManager sc = ScriptManager.GetCurrent(Page);
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "setItems2", "setItems();", true);
    }

}