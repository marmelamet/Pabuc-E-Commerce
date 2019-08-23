using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
/// <summary>
/// Summary description for resim
/// </summary>
public class method
{
    public method()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static DataTable SelectUrunler(int urunId)
    {
        try
        {
            List<SqlParameter> pcol = new List<SqlParameter>();
            pcol.Add(new SqlParameter("@urunId", urunId));
            return fiesta.dblayer.ReadSqlData("spSelectUrunler", pcol, CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return null;
        }
    }
    public static DataTable SelectResimler(int isDefault)
    {
        try
        {
            List<SqlParameter> pcol = new List<SqlParameter>();
            pcol.Add(new SqlParameter("@isDefault", isDefault));
            return fiesta.dblayer.ReadSqlData("spSelectResimler", pcol, CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return null;
        }
    }
    public static DataTable SelectDosyalar(int isDefault)
    {
        try
        {
            List<SqlParameter> pcol = new List<SqlParameter>();
            pcol.Add(new SqlParameter("@isDefault", isDefault));
            return fiesta.dblayer.ReadSqlData("spSelectDosyalar", pcol, CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return null;
        }
    }
    public static int DeleteUrunler(int urunId,int isDefault)
    {
        try
        {
            List<SqlParameter> pcol = new List<SqlParameter>();
            pcol.Add(new SqlParameter("@urunId", urunId));
            pcol.Add(new SqlParameter("@isDefault", 1));
            return fiesta.dblayer.ExecSqlNonQuery("spDeleteUrunler", pcol, CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return -3;
        }
    }
    public static int DeleteResimler(int resimId,int isDefault)
    {
        try
        {
            List<SqlParameter> pcol = new List<SqlParameter>();
            pcol.Add(new SqlParameter("@resimId", resimId));
            pcol.Add(new SqlParameter("@isDefault", 1));
            return fiesta.dblayer.ExecSqlNonQuery("spDeleteResimler", pcol, CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return -3;
        }
    }
    public static int DeleteDosyalar(int dosyaId,int isDefault)
    {
        try
        {
            List<SqlParameter> pcol = new List<SqlParameter>();
            pcol.Add(new SqlParameter("@dosyaId", dosyaId));
            pcol.Add(new SqlParameter("@isDefault", 1));
            return fiesta.dblayer.ExecSqlNonQuery("spDeleteDosyalar", pcol, CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return -3;
        }
    }
    public static string IsDefault(int Tip)
    {
        switch (Tip)
        {
            case 0: return "Aktif";
            case 1: return "Aktif Değil";
        }
        return "";
    }
    public static int InsertSiparisler(Objsiparisler siparis)
    {
        try
        {
            List<SqlParameter> pcol = new List<SqlParameter>();

            pcol.Add(new SqlParameter("@id", "0"));
            pcol.Add(new SqlParameter("@tc", siparis.tc));
            pcol.Add(new SqlParameter("@ad", siparis.ad));
            pcol.Add(new SqlParameter("@soyad", siparis.soyad));
            pcol.Add(new SqlParameter("@telefon", siparis.telefon));
            pcol.Add(new SqlParameter("@sehirId", Convert.ToInt32(siparis.sehirId)));
            pcol.Add(new SqlParameter("@ilceId", Convert.ToInt32(siparis.ilceId)));
            pcol.Add(new SqlParameter("@adres", siparis.adres));
            pcol.Add(new SqlParameter("@email", siparis.email));
            pcol.Add(new SqlParameter("@isDefault", "0"));
            pcol.Add(new SqlParameter("@odendiMi", false));
            return fiesta.dblayer.ExecSqlNonQuery("spInsertSiparisler", pcol, CommandType.StoredProcedure);


        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return -3;
        }
    }
    public static int InsertSiparisUrunler(ObjsiparisUrunler siparisUrunler)
    {
        try
        {
            List<SqlParameter> pcol = new List<SqlParameter>();

            pcol.Add(new SqlParameter("@siparisId", siparisUrunler.siparisId));
            pcol.Add(new SqlParameter("@urunId", siparisUrunler.urunId));
            pcol.Add(new SqlParameter("@urunAd", siparisUrunler.urunAd));
            pcol.Add(new SqlParameter("@adet", Convert.ToInt32(siparisUrunler.adet)));
            pcol.Add(new SqlParameter("@fiyat", Convert.ToDecimal(siparisUrunler.fiyat)));
            pcol.Add(new SqlParameter("@hesaplanmisFiyat", Convert.ToDecimal(siparisUrunler.hesaplanmisFiyat)));
            pcol.Add(new SqlParameter("@kdv", Convert.ToDecimal(siparisUrunler.kdv)));
            pcol.Add(new SqlParameter("@islemTarihi", siparisUrunler.islemTarihi));
            pcol.Add(new SqlParameter("@isDefault", "0"));
            pcol.Add(new SqlParameter("@isDownloaded", false));
            return fiesta.dblayer.ExecSqlNonQuery("spInsertSiparisUrunler", pcol, CommandType.StoredProcedure);


        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return -3;
        }
    }
    
}
//public class siparisUrunler
//{
//    public int urunId { get; set; }
//    public int siparisId { get; set; }
//    public string urunAd { get; set; }
//    public int adet { get; set; }
//    public decimal fiyat { get; set; }
//    public decimal hesaplanmisFiyat { get; set; }
//    public DateTime islemTarihi { get; set; }
//    public int isDefault { get; set; }
//    public bool isDownloaded { get; set; }
//}
//public class siparisler
//{
//    public string tc { get; set; }
//    public string ad { get; set; }
//    public string soyad { get; set; }
//    public string telefon { get; set; }
//    public int sehirId { get; set; }
//    public int ilceId { get; set; }
//    public string adres { get; set; }
//    public string email { get; set; }
//    public int isDefault { get; set; }
//    public bool odendiMi { get; set; }
//}