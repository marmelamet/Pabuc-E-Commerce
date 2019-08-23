using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class klasik : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            List<SqlParameter> p2 = new List<SqlParameter>();
            p2.Add(new SqlParameter("@urunId", "0"));
            p2.Add(new SqlParameter("@isDefault", "0"));
            DataTable dtUrunler = fiesta.dblayer.ReadSqlData("spSelectUrunlerByklasik", p2, CommandType.StoredProcedure);
            rptUrunler.DataSource = dtUrunler;
            rptUrunler.DataBind();
        }
    }
    protected void rptUrunler_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        List<ObjsiparisUrunler> sepet;//sepetin var olup olmadığının kontrolü
        if (Session["SepetUrunler"] != null)
        {
            sepet = ((List<ObjsiparisUrunler>)Session["SepetUrunler"]);
        }
        else//sepet yoksa oluştur
        {
            sepet = new List<ObjsiparisUrunler>();
        }
        List<SqlParameter> p = new List<SqlParameter>();
        p.Add(new SqlParameter("@urunId", e.CommandArgument.ToString()));
        DataTable dt = fiesta.dblayer.ReadSqlData("spSelectUrunlerByklasik", p, CommandType.StoredProcedure);
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            int urunId = Convert.ToInt32(dr["urunId"]);
            if (sepet.Where(ss => ss.urunId == urunId).Count() > 0)//gelen ürün sepette var mı kontrolü
            {
                ObjsiparisUrunler s = sepet.Where(sa => sa.urunId == urunId).FirstOrDefault();
                s.adet++;
                // s.hesaplanmisFiyat = Convert.ToDecimal(s.adet * s.fiyat);
                s.hesaplanmisFiyat = Convert.ToDecimal((s.adet * s.fiyat * s.kdv) / 100) + Convert.ToDecimal(s.adet * s.fiyat);
                sepet.Remove(sepet.Where(se => se.urunId == urunId).FirstOrDefault()); //Sepet ten ürün silmek için kullanılacak yöntem
                sepet.Add(s);
            }
            else//yoksa sepete yeni ürün ekle
            {
                ObjsiparisUrunler s = new ObjsiparisUrunler();
                s.adet = 1;
                s.fiyat = Convert.ToDecimal(dr["fiyat"]);
                s.kdv = Convert.ToDecimal(dr["kdv"]);
                s.hesaplanmisFiyat = ((s.fiyat * Convert.ToDecimal(s.adet) * s.kdv) / 100) + Convert.ToDecimal(s.adet * s.fiyat);
                // s.hesaplanmisFiyat = s.fiyat * Convert.ToDecimal(s.adet);
                s.isDefault = 1;
                s.isDownloaded = false;
                s.islemTarihi = DateTime.Now;
                s.urunAd = dr["urunAd"].ToString();
                s.urunId = Convert.ToInt32(dr["urunId"]);
                sepet.Add(s);

            }
            //((Label)Master.FindControl("lbl_toplam")).Text = sepet.Sum(ss => ss.hesaplanmisFiyat).ToString("N2", culture);
            //((Label)Master.FindControl("lbl_adet")).Text = sepet.Sum(ss => ss.adet).ToString();
            //Session["SepetUrunler"] = sepet;
        }
        Session["SepetUrunler"] = sepet;
        ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString() + "_Basket", "<script>UpdateBasket();</script>", false);
    }
}