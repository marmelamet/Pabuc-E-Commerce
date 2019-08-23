using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for siparisUrunler
/// </summary>

[Serializable]
public class ObjsiparisUrunler
{
    public int urunId { get; set; }
    public int siparisId { get; set; }
    public string urunAd { get; set; }
    public int adet { get; set; }
    public decimal fiyat { get; set; }
    public decimal hesaplanmisFiyat { get; set; }
    public decimal kdv { get; set; }
    public DateTime islemTarihi { get; set; }
    public int isDefault { get; set; }
    public bool isDownloaded { get; set; }

}
