using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for siparisler
/// </summary>

[Serializable]
public class Objsiparisler
{
    public int siparisId { get; set; }
    public string tc { get; set; }
    public string ad { get; set; }
    public string soyad { get; set; }
    public string telefon { get; set; }
    public int sehirId { get; set; }
    public int ilceId { get; set; }
    public string adres { get; set; }
    public string email { get; set; }
    public decimal toplamFiyat { get; set; }
    public string paraBirimi { get; set; }
    public int isDefault { get; set; }
    public bool odendiMi { get; set; }
    public List<ObjsiparisUrunler> siparisler { get; set; }
}