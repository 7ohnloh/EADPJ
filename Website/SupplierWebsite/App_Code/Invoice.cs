using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Supplier
{
    [DataContract]
    public class Invoice
    {
        [DataMember]
        public int Invoice_Id { get; set; }

        [DataMember]
        public DateTime Invoice_Date { get; set; }

        [DataMember]
        public DateTime Invoice_DueDate { get; set; }

        [DataMember]
        public string Invoice_Status { get; set; }

        [DataMember]
        public float Invoice_Amount { get; set; }

        [DataMember]
        public int Payment_Id { get; set; }
    }

    public class SupplierCatalog
    {
        [DataMember]
        public int Product_Id { get; set; }

        [DataMember]
        public string Product_Name { get; set; }

        [DataMember]
        public string Product_Desc { get; set; }

        [DataMember]
        public float Product_Price { get; set; }

        [DataMember]
        public string Product_Image { get; set; }

        [DataMember]
        public int Product_Stocklevel { get; set; }
    }
}