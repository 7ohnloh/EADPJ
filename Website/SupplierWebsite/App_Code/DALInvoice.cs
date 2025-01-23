using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text;
using SvcJustJET;

namespace Supplier.DataAccessLayer
{
    //INVOICE/PAYMENT//INVOICE/PAYMENT//INVOICE/PAYMENT//INVOICE/PAYMENT//INVOICE/PAYMENT//INVOICE/PAYMENT//INVOICE/PAYMENT
    public class DALInvoice
    {
        private String errMsg;
        DALDBConn dbConn = new DALDBConn();

        public DataSet GetInvoiceDetails(int Invoice_Id)
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet InvoiceData;

            SqlConnection conn = dbConn.GetConnection();
            InvoiceData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT * ");
            sql.AppendLine("FROM Invoice");

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.Fill(InvoiceData);
            }

            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return InvoiceData;
        }

        public DataSet GetAll()
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet InvoiceData;

            SqlConnection conn = dbConn.GetConnection();
            InvoiceData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT * ");
            sql.AppendLine("FROM Invoice");

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.Fill(InvoiceData);
            }

            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return InvoiceData;
        }

        public int CreateInvoice(DateTime Invoice_Date, DateTime Invoice_DueDate, float Invoice_Amount, string Invoice_Subject, string Invoice_Description, int Payment_Id)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result;

            result = 0;

            sql = new StringBuilder();
            sql.AppendLine("INSERT INTO Invoice (Invoice_Date, Invoice_DueDate, Invoice_Amount, Invoice_Subject, Invoice_Description, Payment_Id)");
            sql.AppendLine("VALUES (@Invoice_Date, @Invoice_DueDate, @Invoice_Amount, @Invoice_Subject, @Invoice_Description, @Payment_Id )");
            SqlConnection conn = dbConn.GetConnection();

            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@Invoice_Date", Invoice_Date);
                sqlCmd.Parameters.AddWithValue("@Invoice_DueDate", Invoice_DueDate);
                sqlCmd.Parameters.AddWithValue("@publisher", Invoice_Amount);
                sqlCmd.Parameters.AddWithValue("@Invoice_Amount", Invoice_Amount);
                sqlCmd.Parameters.AddWithValue("@Invoice_Subject", Invoice_Subject);
                sqlCmd.Parameters.AddWithValue("@Invoice_Description", Invoice_Description);
                sqlCmd.Parameters.AddWithValue("@Payment_Id", Payment_Id);
                result = sqlCmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public int UpdateInvoice(int Invoice_Id, DateTime Invoice_Date, DateTime Invoice_DueDate, float Invoice_Amount, string Invoice_Subject, string Invoice_Description, int Payment_Id)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result;

            result = 0;

            sql = new StringBuilder();
            sql.AppendLine("UPDATE Invoice (Invoice_Date, Invoice_DueDate, Invoice_Amount, Invoice_Subject, Invoice_Description, Payment_Id)");
            sql.AppendLine("SET Invoice_Date = @Invoice_Date, Invoice_DueDate = @Invoice_DueDate,  Invoice_Amount = @Invoice_Amount, Invoice_Subject = @Invoice_Subject, Invoice_Description = @Invoice_Description, Payment_Id = @Payment_Id");
            sql.AppendLine("WHERE Invoice_Id = @Invoice_Id");
            SqlConnection conn = dbConn.GetConnection();

            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@Invoice_Id", Invoice_Id);
                sqlCmd.Parameters.AddWithValue("@Invoice_Date", Invoice_Date);
                sqlCmd.Parameters.AddWithValue("@Invoice_DueDate", Invoice_DueDate);
                sqlCmd.Parameters.AddWithValue("@Invoice_Amount", Invoice_Amount);
                sqlCmd.Parameters.AddWithValue("@Invoice_Subject", Invoice_Subject);
                sqlCmd.Parameters.AddWithValue("@Invoice_Description", Invoice_Description);
                sqlCmd.Parameters.AddWithValue("@Payment_Id", Payment_Id);
                result = sqlCmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public int DeleteInvoice(int Invoice_Id)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result;

            result = 0;

            sql = new StringBuilder();
            sql.AppendLine("DELETE FROM Invoice ");
            sql.AppendLine("WHERE Invoice_Id = @Invoice_Id");
            SqlConnection conn = dbConn.GetConnection();

            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@Invoice_Id", Invoice_Id);
                result = sqlCmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }



    }


    //SUPPLIER CATALOG//SUPPLIER CATALOG//SUPPLIER CATALOG//SUPPLIER CATALOG//SUPPLIER CATALOG//SUPPLIER CATALOG//SUPPLIER CATALOG//SUPPLIER CATALOG
    public class DALSupplierCatalog
    {
        private String errMsg;
        DALDBConn dbConn = new DALDBConn();

        public DataSet GetSupplierCatalogDetails(int Product_Id)
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet SupplierCatalogData;

            SqlConnection conn = dbConn.GetConnection();
            SupplierCatalogData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT *");
            sql.AppendLine("FROM Product");

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.Fill(SupplierCatalogData);
            }

            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return SupplierCatalogData;
        }

        public DataSet GetAllSupplierCatalog()
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet SupplierCatalogData;

            SqlConnection conn = dbConn.GetConnection();
            SupplierCatalogData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT *");
            sql.AppendLine("FROM Product");

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.Fill(SupplierCatalogData);
            }

            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return SupplierCatalogData;
        }

        public int CreateSupplierCatalog(string Product_Name, string Product_Desc, float Product_Price, string Product_Image, int Product_Stocklevel)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result;

            result = 0;

            sql = new StringBuilder();
            sql.AppendLine("INSERT INTO Product (Product_Name, Product_Desc, Product_Price, Product_Image, Product_Stocklevel)");
            sql.AppendLine("VALUES (@Product_Name, @Product_Desc, @Product_Price, @Product_Image, @Product_Stocklevel)");
            SqlConnection conn = dbConn.GetConnection();

            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@Product_Name", Product_Name);
                sqlCmd.Parameters.AddWithValue("@Product_Desc", Product_Desc);
                sqlCmd.Parameters.AddWithValue("@Product_Price", Product_Price);
                sqlCmd.Parameters.AddWithValue("@Product_Image", Product_Image);
                sqlCmd.Parameters.AddWithValue("@Product_Stocklevel", Product_Stocklevel);
                result = sqlCmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public int UpdateInvoice(int Product_Id, string Product_Name, string Product_Desc, float Product_Price, string Product_Image, int Product_Stocklevel)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result;

            result = 0;

            sql = new StringBuilder();
            sql.AppendLine("UPDATE Invoice (Product_Name, Product_Desc, Product_Price, Product_Image, Product_Stocklevel)");
            sql.AppendLine("SET Product_Name = @Product_Name, Product_Desc = @Product_Desc,  Product_Price = @Product_Price, Product_Image = @Product_Image, Product_Stocklevel = @Product_Stocklevel");
            sql.AppendLine("WHERE Product_Id = @Product_Id");
            SqlConnection conn = dbConn.GetConnection();

            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@Product_Id", Product_Id);
                sqlCmd.Parameters.AddWithValue("@Product_Name", Product_Name);
                sqlCmd.Parameters.AddWithValue("@Product_Desc", Product_Desc);
                sqlCmd.Parameters.AddWithValue("@Product_Price", Product_Price);
                sqlCmd.Parameters.AddWithValue("@Product_Image", Product_Image);
                sqlCmd.Parameters.AddWithValue("@Product_Stocklevel", Product_Stocklevel);
                result = sqlCmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public int DeleteInvoice(int Product_Id)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result;

            result = 0;

            sql = new StringBuilder();
            sql.AppendLine("DELETE FROM Product ");
            sql.AppendLine("WHERE Product_Id = @Product_Id");
            SqlConnection conn = dbConn.GetConnection();

            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@Product_Id", Product_Id);
                result = sqlCmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }



    }

    //Calling from company side
    public class DALCompany
    {
        public DataSet GetPayment()
        {
           
            JustJETClient CompanyClient;
            CompanyClient = new JustJETClient();
            return CompanyClient.GetPayment();
        }

        public DataSet GetPaymentDetails(int Payment_Id)
        {
            JustJETClient CompanyClient;
            CompanyClient = new JustJETClient();
            return CompanyClient.GetPaymentDetails(Payment_Id);
        }

    }
}
