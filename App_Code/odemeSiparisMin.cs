using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for odemeSiparisMin
/// </summary>
/// 




    [DataContract]
    public class odemeUrunMin
    {

        [DataMember]
        public int urun_id { get; set; }
        [DataMember]
        public int siparis_id { get; set; }
        [DataMember]
        public string urun_ad { get; set; }
        [DataMember]
        public int adet { get; set; }
        [DataMember]
        public decimal fiyati { get; set; }
        [DataMember]
        public decimal toplam_fiyat { get; set; }
        [DataMember]
        public decimal kargo { get; set; }

    }
