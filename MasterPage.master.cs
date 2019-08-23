using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("tr-TR");
    protected void Page_Load(object sender, EventArgs e)
    {

        //List<ObjsiparisUrunler> sepet;//sayfa açılısında var olan sepeti yüklemek için
        //if (Session["SepetUrunler"] != null)
        //{
        //    sepet = Session["SepetUrunler"] as List<ObjsiparisUrunler>;

        //    ((Label)Master.FindControl("lbl_toplam")).Text = sepet.Sum(ss => ss.hesaplanmisFiyat).ToString("N2", culture);
        //    ((Label)Master.FindControl("lbl_adet")).Text = sepet.Sum(ss => ss.adet).ToString();
        //}
            
    }
}
