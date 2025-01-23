using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Delivery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            //call BindGridView
            BindGridView();
            BindDropDownList();
        }
    }
    private void BindGridView()
    {
        string strConnection =
            ConfigurationManager.ConnectionStrings["SupplierConnectionString"].ConnectionString;
        SqlConnection myConnect = new SqlConnection(strConnection);
        string strCommandText = "SELECT DeliveryOrder_Id, Delivery_Date, Delivery_Address, Receive_Status, CompanyOrder_Id FROM ReceiveOrderDetails";
        SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
        myConnect.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        grdDelivery.DataSource = reader;
        grdDelivery.DataBind();
        
    }

    protected void btnAddDelivery_Click(object sender, EventArgs e)
    {
        pnlNewRecord.Visible = true;
    }

    private void BindDropDownList()
    {
        ddlStatusInsert.DataSource = getReader();
        ddlStatusInsert.DataTextField = "Receive_Status";
        ddlStatusInsert.DataValueField = "Id";
        ddlStatusInsert.DataBind();
    }
    private SqlDataReader getReader()
    {
        string strConnection =
            ConfigurationManager.ConnectionStrings["SupplierConnectionString"].ConnectionString;
        SqlConnection myConnect = new SqlConnection(strConnection);
        string strCommandText = "SELECT Id, Receive_Status FROM Delivery";
        SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
        myConnect.Open();
        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        return reader;
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        try
        {
            string StatusId = ddlStatusInsert.SelectedItem.ToString();
            string deliverydate = txtDelivery_Date.Text;
            DateTime date = DateTime.Parse(deliverydate);
            string deliveryaddress = txtDelivery_Address.Text;
            int companyorderid = Convert.ToInt32(txtCompanyOrder_Id.Text);

            insertNewDelivery(StatusId, date, deliveryaddress, companyorderid);
        }
        catch (Exception ex)
        {
            lblResult.Text = ex.Message.ToString();
        }
    }

    private void insertNewDelivery(string StatusId, DateTime date, string deliveryaddress, int companyorderid)
    {
        string strConnection =
            ConfigurationManager.ConnectionStrings["SupplierConnectionString"].ConnectionString;
        SqlConnection myConnect = new SqlConnection(strConnection);
        string strCommandText = "INSERT ReceiveOrderDetails (Delivery_Date, Delivery_Address, Receive_Status, CompanyOrder_Id) VALUES (@deliverydate, @deliveryaddress, @StatusId, @companyorderid)";
        SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
        
        cmd.Parameters.AddWithValue("@deliverydate", date);
        cmd.Parameters.AddWithValue("@deliveryaddress", deliveryaddress);
        cmd.Parameters.AddWithValue("@StatusId", StatusId);
        cmd.Parameters.AddWithValue("@companyorderid", companyorderid);
        myConnect.Open();
       cmd.ExecuteNonQuery();
        
        myConnect.Close();
        grdDelivery.EditIndex = -1;
        BindGridView();
    }
}