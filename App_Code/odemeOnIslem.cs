using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for responsePay
/// </summary>
/// 





    [DataContract]
    public class odemeOnIslem
    {
        [DataMember]
        public int reg_id { get; set; }

        [DataMember]
        public string returnCode { get; set; }

        [DataMember]
        public string returnMessage { get; set; }

        [DataMember]
        public bool regSuccess { get; set; }

        [DataMember]
        public DateTime date { get; set; }

    }

