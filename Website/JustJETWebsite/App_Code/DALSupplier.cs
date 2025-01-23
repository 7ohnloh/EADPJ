using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SvcSupplier;
using System.Text;
using System.Data.SqlClient;

namespace Company.DataAccessLayer
{
    //Calling from Supplier side
    public class DALSupplier
    {
        public DataSet GetInvoice()
        {
            SupplierAClient SupplierClient;
            SupplierClient = new SupplierAClient();
            return SupplierClient.GetInvoice();
        }

        public DataSet GetInvoiceDetails(int Invoice_Id)
        {
            SupplierAClient SupplierClient;
            SupplierClient = new SupplierAClient();
            return SupplierClient.GetInvoiceDetails(Invoice_Id);
        }

        public DataSet GetAllSupplierCatalog()
        {
            SupplierAClient SupplierClient;
            SupplierClient = new SupplierAClient();
            return SupplierClient.GetSupplierCatalog();
        }

        public DataSet GetSupplierCatalogDetails(int Product_Id)
        {
            SupplierAClient SupplierClient;
            SupplierClient = new SupplierAClient();
            return SupplierClient.GetSupplierCatalogDetails(Product_Id);
        }
    }

    //supplier call company side
    public class DALPayment
    {
        private String errMsg;
        DALDBConn dbConn = new DALDBConn();

        public DataSet GetPaymentDetails(int Payment_Id)
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet PaymentData;

            SqlConnection conn = dbConn.GetConnection();
            PaymentData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT * ");
            sql.AppendLine("FROM Payment");

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.Fill(PaymentData);
            }

            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return PaymentData;
        }

        public DataSet GetAllPayment()
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet PaymentData;

            SqlConnection conn = dbConn.GetConnection();
            PaymentData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT * ");
            sql.AppendLine("FROM Payment");

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.Fill(PaymentData);
            }

            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return PaymentData;
        }


    }
}