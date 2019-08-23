using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SepetJson : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string json = "";
        List<ObjsiparisUrunler> sepet = new List<ObjsiparisUrunler>();
        if (Session["SepetUrunler"] != null)
        {
            sepet = ((List<ObjsiparisUrunler>)Session["SepetUrunler"]);
            int itemcount = sepet.Sum(s => s.adet);
            decimal priceTotal = sepet.Sum(s => s.hesaplanmisFiyat);
            json = "{\"itemcount\":" + itemcount + ",\"PriceTotal\":\"" + priceTotal.ToString("N2") + "\"}";

        }
        else
        {
            json = "{\"itemcount\":" + 0 + ",\"PriceTotal\":\"0\"}";
        }
        Response.Clear();
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
        Response.End();
    }
}