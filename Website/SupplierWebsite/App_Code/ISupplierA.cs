using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;


namespace Supplier
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISupplierA" in both code and config file together.
    [ServiceContract]
    public interface ISupplierA
    {
        [OperationContract]
        DataSet GetInvoice();

        [OperationContract]
        DataSet GetInvoiceDetails(int Invoice_Id);

        [OperationContract]
        DataSet GetSupplierCatalog();

        [OperationContract]
        DataSet GetSupplierCatalogDetails(int Product_Id);


    }
}