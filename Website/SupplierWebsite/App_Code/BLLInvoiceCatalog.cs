using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Supplier.DataAccessLayer;

namespace Supplier.BusinessLogicLayer
{
    public class BLLInvoiceCatalog
    {
        public DataSet GetInvoice()
        {
            DALInvoice dataLayerInvoice;

            dataLayerInvoice = new DALInvoice();
            return dataLayerInvoice.GetAll();
        }

        public DataSet GetInvoiceDetails(int Invoice_Id)
        {
            DALInvoice dataLayerInvoice;

            dataLayerInvoice = new DALInvoice();
            return dataLayerInvoice.GetInvoiceDetails(Invoice_Id);
        }
    }

    public class BLLSupplierCatalog
    {
        public DataSet GetSupplierCatalog()
        {
            DALSupplierCatalog dataLayerSupplierCatalog;

            dataLayerSupplierCatalog = new DALSupplierCatalog();
            return dataLayerSupplierCatalog.GetAllSupplierCatalog();
        }

        public DataSet GetSupplierCatalogDetails(int Product_Id)
        {
            DALSupplierCatalog dataLayerSupplierCatalog;

            dataLayerSupplierCatalog = new DALSupplierCatalog();
            return dataLayerSupplierCatalog.GetSupplierCatalogDetails(Product_Id);
        }
    }

    //Calling from company side
    public class BLLPaymentCatalog
    {
        public DataSet getPaymentList()
        {
            DALCompany dal;
            DataSet datasetPaymentList;


            dal = new DALCompany();
            datasetPaymentList = dal.GetPayment();

            return datasetPaymentList;
        }

        public DataSet getPaymentCatalogDetails(int Payment_Id)
        {
            DALCompany dal;
            DataSet datasetPaymentList;


            dal = new DALCompany();
            datasetPaymentList = dal.GetPaymentDetails(Payment_Id);

            return datasetPaymentList;
        }
    }
}