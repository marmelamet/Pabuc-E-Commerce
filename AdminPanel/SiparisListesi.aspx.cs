using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;

public partial class SiparisListesi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            List<SqlParameter> p = new List<SqlParameter>();
            DataTable dt = fiesta.dblayer.ReadSqlData("spSelectSiparisListesi", p, CommandType.StoredProcedure);
            rptSiparislist.DataSource = dt;
            rptSiparislist.DataBind();
        }
    }
    
    //protected void lnk_duzenle_Command(object sender, CommandEventArgs e)
    //{
    //    try
    //    {
    //        int siparis_id = int.Parse(e.CommandName);

    //        List<SqlParameter> p = new List<SqlParameter>();
    //        p.Add(new SqlParameter("@siparisId", siparis_id));
    //        DataTable dt = fiesta.dblayer.ReadSqlData("spSelectSiparisUrunler", p, CommandType.StoredProcedure);
    //        rptSiparisUrunler.DataSource = dt;
    //        rptSiparisUrunler.DataBind();
    //    }
    //    catch (Exception ex)
    //    { }
    //}
}