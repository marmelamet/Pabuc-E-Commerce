using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Net;
using System.Xml;
using fiesta;
/// <summary>
/// Summary description for Bilgiler
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Bilgiler : System.Web.Services.WebService {

    [WebMethod]
    public DataSet Bilgi()
    {
        string baglanti = WebConfigurationManager.ConnectionStrings["yoda"].ConnectionString;
        SqlConnection con = new SqlConnection(baglanti);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.CommandText = "select ad,soyad from siparisler";
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        XmlDocument doc = new XmlDocument();    
    
        
       
        DataSet ds = new DataSet();
        ds.ReadXml(new XmlNodeReader(doc));
        DataTable dt = ds.Tables["NewDataSet "];
        DataTable dt1 = new DataTable();
        dt1.TableName = "NewDataSet ";
        dt1.Columns.Add("ad");
        dt1.Columns.Add("soyad");
      
        DataSet ds1 = new DataSet();
        ds1.DataSetName = "Table ";
        ds1.Tables.Add(dt1);

        string xmlresult = ds1.GetXml();

        da.Fill(ds);
        da.Dispose();
        con.Close();

        return ds;
        
    }
    
}
