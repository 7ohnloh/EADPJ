using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for Payment
/// </summary>
namespace Company
{
    [DataContract]
    public class Payment
    {
        [DataMember]
        public int Payment_Id { get; set; }
        [DataMember]
        public string Payment_Status { get; set; }
        [DataMember]
        public int Invoice_Id { get; set; }
    }
}