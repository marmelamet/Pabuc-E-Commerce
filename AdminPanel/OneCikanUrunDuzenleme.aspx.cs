using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class OneCikanUrunDuzenleme : System.Web.UI.Page
{
    string filename;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtkategori = fiesta.dblayer.ReadSqlData("select * from kategoriler where isDefault=0 order by kategoriAd", null, CommandType.Text);
            dllKategori.Items.Clear();
            dllKategori.Items.Add(new ListItem("Seçiniz", "0"));
            for (int i = 0; i < dtkategori.Rows.Count; i++)
                dllKategori.Items.Add(new ListItem(dtkategori.Rows[i]["kategoriAd"].ToString(), dtkategori.Rows[i]["kategoriId"].ToString()));

            DataTable dturun = fiesta.dblayer.ReadSqlData("select * from urunler where isDefault=0 order by urunAd", null, CommandType.Text);
            dllUrun.Items.Clear();
            dllUrun.Items.Add(new ListItem("Seçiniz", "0"));
            for (int i = 0; i < dturun.Rows.Count; i++)
                dllUrun.Items.Add(new ListItem(dturun.Rows[i]["urunAd"].ToString(), dturun.Rows[i]["urunId"].ToString()));

            SetSlider();
        }
    }
    public void SetSlider()
    {
        List<SqlParameter> pars = new List<SqlParameter>();
        pars.Add(new SqlParameter("@oneCikanUrunId", Request.QueryString["p"]));
        DataTable dt = fiesta.dblayer.ReadSqlData("spSelectUpdateOneCikanUrunGorsel", pars, CommandType.StoredProcedure);
        for (int i = 0; i < dllKategori.Items.Count; i++)
            if (dllKategori.Items[i].Value == dt.Rows[0]["katId"].ToString())
                dllKategori.SelectedIndex = i;
        for (int i = 0; i < dllUrun.Items.Count; i++)
            if (dllUrun.Items[i].Value == dt.Rows[0]["urunId"].ToString())
                dllUrun.SelectedIndex = i;
        fckOzellik.Text = dt.Rows[0]["aciklama"].ToString();

    }
    protected void dllKategori_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<SqlParameter> pr = new List<SqlParameter>();
        pr.Add(new SqlParameter("@kategoriId", dllKategori.SelectedValue));
        DataTable dturun = fiesta.dblayer.ReadSqlData("select * from urunler where kategoriId=@kategoriId and isDefault=0 order by urunAd", pr, CommandType.Text);
        dllUrun.Items.Clear();
        dllUrun.Items.Add(new ListItem("Seçiniz", "0"));
        for (int i = 0; i < dturun.Rows.Count; i++)
            dllUrun.Items.Add(new ListItem(dturun.Rows[i]["urunAd"].ToString(), dturun.Rows[i]["urunId"].ToString()));
    }
    protected void BTN_Kaydet_Click(object sender, EventArgs e)
    {
        if (dllKategori.SelectedIndex > 0)
        {
            if (filepicture.HasFile)
            {
                string fileextension = Path.GetExtension(filepicture.PostedFile.FileName);
                filename = DateTime.Now.ToString().Replace(".", "").Replace(":", "").Replace(" ", "").Replace("/",
    "").Replace("\\", "");
                filename = "../OneCikanUrunGorsel/" + filename + fileextension;
                filepicture.SaveAs(Server.MapPath(filename));

                try
                {
                    List<SqlParameter> pars = new List<SqlParameter>();

                    pars.Add(new SqlParameter("@oneCikanUrunId",Request.QueryString["p"]));
                    pars.Add(new SqlParameter("@katId", Convert.ToInt32(dllKategori.SelectedValue)));
                    pars.Add(new SqlParameter("@urunId", Convert.ToInt32(dllUrun.SelectedValue)));
                    pars.Add(new SqlParameter("@aciklama", fckOzellik.Text));
                    pars.Add(new SqlParameter("@resim", filename));
                    pars.Add(new SqlParameter("@isDefault", "0"));
                    fiesta.dblayer.ExecSqlNonQuery("UpdateOneCikanUrunGorsel", pars, CommandType.StoredProcedure);
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Öne çıkan ürün düzenleme işlemi başarılı.');", true);

                }


                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "islemsonu", "alert('Öne çıkan ürün düzenleme işlemi sırasında hata oluştu.');", true);
                }
            }
        }
    }
   
}