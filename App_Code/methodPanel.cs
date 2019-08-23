using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for resim
/// </summary>
public class methodPanel
{
    public methodPanel()
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
    public static DataTable SelectStok(int isDefault)
    {
        try
        {
            List<SqlParameter> pcol = new List<SqlParameter>();
            pcol.Add(new SqlParameter("@isDefault", isDefault));
            return fiesta.dblayer.ReadSqlData("spSelectStok", pcol, CommandType.StoredProcedure);

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
    public static int DeleteStok(int stokId, int isDefault)
    {
        try
        {
            List<SqlParameter> pcol = new List<SqlParameter>();
            pcol.Add(new SqlParameter("@stokId", stokId));
            pcol.Add(new SqlParameter("@isDefault", 1));
            return fiesta.dblayer.ExecSqlNonQuery("spDeleteStok", pcol, CommandType.StoredProcedure);

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
    public static int DeleteKullanicilar(int kullaniciId, int isDefault)
    {
        try
        {
            List<SqlParameter> pcol = new List<SqlParameter>();
            pcol.Add(new SqlParameter("@userId", kullaniciId));
            pcol.Add(new SqlParameter("@isDefault", 1));
            return fiesta.dblayer.ExecSqlNonQuery("spDeleteKullanicilar", pcol, CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return -3;
        }
    }
    public static int DeleteKategoriler(int kategoriId, int isDefault)
    {
        try
        {
            List<SqlParameter> pcol = new List<SqlParameter>();
            pcol.Add(new SqlParameter("@kategoriId", kategoriId));
            pcol.Add(new SqlParameter("@isDefault", 1));
            return fiesta.dblayer.ExecSqlNonQuery("spDeleteKategoriler", pcol, CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return -3;
        }
    }
    public static int DeleteSlider(int sliderId, int isDefault)
    {
        try
        {
            List<SqlParameter> pcol = new List<SqlParameter>();
            pcol.Add(new SqlParameter("@sliderId", sliderId));
            pcol.Add(new SqlParameter("@isDefault", 1));
            return fiesta.dblayer.ExecSqlNonQuery("spDeleteSlider", pcol, CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return -3;
        }
    }
    public static int DeleteOneCikanUrunGorsel(int oneCikanUrunId, int isDefault)
    {
        try
        {
            List<SqlParameter> pcol = new List<SqlParameter>();
            pcol.Add(new SqlParameter("@oneCikanUrunId", oneCikanUrunId));
            pcol.Add(new SqlParameter("@isDefault", 1));
            return fiesta.dblayer.ExecSqlNonQuery("spDeleteOneCikanUrunGorsel", pcol, CommandType.StoredProcedure);

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
}