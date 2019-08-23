using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for users
/// </summary>
public class uye
{
    public uye()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static int InsertUpdateUye(int uyeId, string tc, string ad, string soyad, string telefon,string email ,string username, string password, int isSocial, string socialMedia, string socialReferal)
    {
        try
        {
            List<SqlParameter> pcol = new List<SqlParameter>();
            pcol.Add(new SqlParameter("@uyeId", uyeId));
            pcol.Add(new SqlParameter("@tc", tc));
            pcol.Add(new SqlParameter("@ad", ad));
            pcol.Add(new SqlParameter("@soyad", soyad));
            pcol.Add(new SqlParameter("@telefon", telefon));
            pcol.Add(new SqlParameter("@email", email));
            pcol.Add(new SqlParameter("@username", username));
            pcol.Add(new SqlParameter("@password", password));
            pcol.Add(new SqlParameter("@isSocial", isSocial));
            pcol.Add(new SqlParameter("@socialMedia", socialMedia));
            pcol.Add(new SqlParameter("@socialReferal", socialReferal));
            pcol.Add(new SqlParameter("@isDefault", 0));
            return fiesta.dblayer.ExecSqlNonQuery("spInsertUpdateUye", pcol, CommandType.StoredProcedure);
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return -3;
        }
    }
    public static DataTable SelectUye(int isDefault)
    {
        try
        {
            List<SqlParameter> pcol = new List<SqlParameter>();
            pcol.Add(new SqlParameter("@isDefault", isDefault));
            return fiesta.dblayer.ReadSqlData("spSelectUye", pcol, CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return null;
        }
    }
    public static int DeleteUye(int uyeId,int isDefault)
    {
        try
        {
            List<SqlParameter> pcol = new List<SqlParameter>();
            pcol.Add(new SqlParameter("@uyeId", uyeId));
            pcol.Add(new SqlParameter("@isDefault", "1"));
            return fiesta.dblayer.ExecSqlNonQuery("spDeleteUye", pcol, CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return -3;
        }
    }
    public static int SifreDegistir(int UserId, string username,string oldPassword, string password)
    {
        try
        {
            List<SqlParameter> pcol = new List<SqlParameter>();

            pcol.Add(new SqlParameter("@userId",UserId));
            pcol.Add(new SqlParameter("@password", password));

            return fiesta.dblayer.ExecSqlNonQuery("spSifreDegistir", pcol, CommandType.StoredProcedure);
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return -3;
        }
    }
    public static int UpdateProfil(int userId, string username, string name, string surname)
    {

        try
        {
            List<SqlParameter> pcol = new List<SqlParameter>();

            pcol.Add(new SqlParameter("@userId", userId));
            pcol.Add(new SqlParameter("@username", username));
            pcol.Add(new SqlParameter("@name", name));
            pcol.Add(new SqlParameter("@surname", surname));

            return fiesta.dblayer.ExecSqlNonQuery("spUpdateProfil", pcol, CommandType.StoredProcedure);
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return -3;
        }
    }
    public static string Job(int Tip)
    {
        switch (Tip)
        {
            case 1: return "Admin";
            case 2: return "Personel";
        }
        return "";
    }
}