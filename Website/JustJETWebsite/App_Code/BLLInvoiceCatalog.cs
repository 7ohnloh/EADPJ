using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Company.DataAccessLayer;

namespace Company.BusinessLogicLayer
{   
    //Calling from Supplier side
    public class BLLInvoiceCatalog
    {
        public DataSet getInvoiceList()
        {
            DALSupplier dal;
            DataSet datasetInvoiceList;
            

            dal = new DALSupplier();
            datasetInvoiceList = dal.GetInvoice();

            return datasetInvoiceList;
        }

        public DataSet getInvoiceCatalogDetails(int Invoice_Id)
        {
            DALSupplier dal;
            DataSet datasetInvoiceList;


            dal = new DALSupplier();
            datasetInvoiceList = dal.GetInvoiceDetails(Invoice_Id);

            return datasetInvoiceList;
        }
    }

    //Calling from Supplier side
    public class BLLSupplierCatalog
    {
        public DataSet getSupplierProductList()
        {
            DALSupplier dal;
            DataSet datasetSupplierCatalogList;


            dal = new DALSupplier();
            datasetSupplierCatalogList = dal.GetAllSupplierCatalog();

            return datasetSupplierCatalogList;
        }

        public DataSet getSupplierProductDetails(int Product_Id)
        {
            DALSupplier dal;
            DataSet datasetSupplierCatalogList;


            dal = new DALSupplier();
            datasetSupplierCatalogList = dal.GetSupplierCatalogDetails(Product_Id);

            return datasetSupplierCatalogList;
        }

        
    }
    public class BLLPaymentCatalog
    {
        public DataSet GetPayment()
        {
            DALPayment dataLayerPayment;

            dataLayerPayment = new DALPayment();
            return dataLayerPayment.GetAllPayment();
        }

        public DataSet GetPaymentDetails(int Payment_Id)
        {
            DALPayment dataLayerPayment;

            dataLayerPayment = new DALPayment();
            return dataLayerPayment.GetPaymentDetails(Payment_Id);
        }
    }
}