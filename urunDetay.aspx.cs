using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class urunDetay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            List<SqlParameter> p1 = new List<SqlParameter>();
            p1.Add(new SqlParameter("@urunId", Request.QueryString["p"]));
            DataTable dtkategori = fiesta.dblayer.ReadSqlData("select * from stok where isDefault=0 and urunId=@urunId order by numara", p1, CommandType.Text);
            ddl_ayakkabi_no.Items.Clear();
            ddl_ayakkabi_no.Items.Add(new ListItem("Seçiniz", "0"));
            for (int i = 0; i < dtkategori.Rows.Count; i++)
                ddl_ayakkabi_no.Items.Add(new ListItem(dtkategori.Rows[i]["numara"].ToString(), dtkategori.Rows[i]["stokId"].ToString()));

            List<SqlParameter> p2 = new List<SqlParameter>();
            p2.Add(new SqlParameter("@urunId", Request.QueryString["p"]));
            p2.Add(new SqlParameter("@isDefault", "0"));
            DataTable dtdetay = fiesta.dblayer.ReadSqlData("spSelectUrunDetay1", p2, CommandType.StoredProcedure);
            lblUrunAd1.Text = dtdetay.Rows[0]["urunAd"].ToString();
            lblKdvDahil.Text = dtdetay.Rows[0]["kdvDahil"].ToString();
            lblUrunAd2.Text = dtdetay.Rows[0]["urunAd"].ToString();
         
        }
    }
}