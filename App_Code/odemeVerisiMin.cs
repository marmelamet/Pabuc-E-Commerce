using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for OdemeVerisi
/// </summary>
/// 




    [DataContract]
    public class OdemeVerisiMin
    {

        [DataMember]
        public string _hash { get; set; }
        [DataMember]
        public string magaza_kod { get; set; }
        [DataMember]
        public string odeme_yeri { get; set; }
        [DataMember]
        public string guvenlik_kodu { get; set; }
        [DataMember]
        public int siparis_id { get; set; }
        [DataMember]
        public string ad { get; set; }
        [DataMember]
        public string soyad { get; set; }
        [DataMember]
        public string tc { get; set; }
        [DataMember]
        public string tel { get; set; }
        // [DataMember]
        // public string cep_tel { get; set; }
        [DataMember]
        public string semt { get; set; }
        [DataMember]
        public string sehir { get; set; }
        [DataMember]
        public string adres { get; set; }
        [DataMember]
        public DateTime islem_tarihi { get; set; }
        [DataMember]
        public decimal toplam_fiyat_dec { get; set; }
        [DataMember]
        public string toplam_fiyat_str { get; set; }
        [DataMember]
        public string para_birimi { get; set; }
        [DataMember]
        public List<odemeUrunMin> urunler { get; set; }
        [DataMember]
        public string backURL { get; set; }

        // public string toplam_fiyat_TL { get; set; }
        // public string toplam_fiyat_KR { get; set; }


    }
