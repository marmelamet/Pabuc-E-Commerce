using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace fiesta
{
    /// <summary>
    /// Summary description for process
    /// </summary>
    public class process
    {
        public static AdminUser Login(string username, string password)
        {
            List<SqlParameter> pr = new List<SqlParameter>();
            pr.Add(new SqlParameter("@username", username));
            pr.Add(new SqlParameter("@password", password));
            DataTable dt = fiesta.dblayer.ReadSqlData("select ju.*,jur.roleAd from kullanicilar ju inner join roller jur on ju.roleId=jur.roleId where ju.username=@username " +
                "and ju.password=@password", pr, CommandType.Text);
            if (dt.Rows.Count > 0)
            {
                AdminUser ad = new AdminUser();
                ad.userId = Convert.ToInt32(dt.Rows[0]["userId"].ToString());
                ad.username = dt.Rows[0]["username"].ToString();
                ad.password = dt.Rows[0]["password"].ToString();
                ad.name = dt.Rows[0]["name"].ToString();
                ad.surname = dt.Rows[0]["surname"].ToString();
                ad.roleId = Convert.ToInt32(dt.Rows[0]["roleId"].ToString());
                ad.roleAd = dt.Rows[0]["roleAd"].ToString();
                return ad;
            }
            else
            {
                AdminUser ad = new AdminUser();
                ad.userId = -1;
                ad.username = "Kullanıcı Bulunamadı.";
                return ad;
            }
        }
    }
    public class AdminUser
    {
        public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int roleId { get; set; }
        public string roleAd { get; set; }
    }
}