using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using Supplier.BusinessLogicLayer;

namespace Supplier
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SupplierA" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SupplierA.svc or SupplierA.svc.cs at the Solution Explorer and start debugging.
    public class SupplierA : ISupplierA
    {
        public DataSet GetInvoice()
        {
            BLLInvoiceCatalog bizLayerInvoice = new BLLInvoiceCatalog();
            return bizLayerInvoice.GetInvoice();
        }

        public DataSet GetInvoiceDetails(int Invoice_Id)
        {
            BLLInvoiceCatalog bizLayerInvoice = new BLLInvoiceCatalog();
            return bizLayerInvoice.GetInvoiceDetails(Invoice_Id);
        }

        public DataSet GetSupplierCatalog()
        {
            BLLSupplierCatalog bizLayerInvoice = new BLLSupplierCatalog();
            return bizLayerInvoice.GetSupplierCatalog();
        }

        public DataSet GetSupplierCatalogDetails(int Product_Id)
        {
            BLLSupplierCatalog bizLayerInvoice = new BLLSupplierCatalog();
            return bizLayerInvoice.GetSupplierCatalogDetails(Product_Id);
        }
    }
}

