using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using Supplier.BusinessLogicLayer;

public partial class Payment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            bindgrdPayment();
            CreatePanel.Visible = false;
            bindgrdPaymentDetails();
        }
    }
    private void bindgrdPayment()
    {
        string strConnectionString =
            ConfigurationManager.ConnectionStrings["SupplierConnectionString"].ConnectionString;

        SqlConnection myConnection = new SqlConnection(strConnectionString);
        string command = "SELECT Invoice_Id,Invoice_Date, Invoice_DueDate, Invoice_Amount, Invoice_Subject, Invoice_Description, Company_Name, PaymentStatus FROM Invoice";
        SqlCommand cmd = new SqlCommand(command, myConnection);
        myConnection.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(reader);
        grdPayment.DataSource = dt;
        grdPayment.DataBind();
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        CreatePanel.Visible = true;
        btnCreate.Enabled = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        CreatePanel.Visible = false;
        btnCreate.Enabled = true;
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        try
        {
            string companyname = tbIssueTo.Text;
            DateTime issuedate = Convert.ToDateTime(tbIssueDate.Text);
            DateTime duedate = Convert.ToDateTime(tbDueDate.Text);
            decimal amount = Convert.ToDecimal(tbAmount.Text);
            string subject = tbSubject.Text;
            string description = tbDescription.Text;


            insertProduct(companyname, issuedate, duedate, amount, subject, description);
        }
        catch (Exception ex)
        {
            lbl_Error.Text = ex.Message.ToString();
        }
        finally
        {
            btnCreate.Enabled = true;
            CreatePanel.Visible = false;
        }
    }

    private void insertProduct(string companyname, DateTime issuedate, DateTime duedate, decimal amount, string subject, string description)
    {
        string strConnectionString
            = ConfigurationManager.ConnectionStrings["SupplierConnectionString"].ConnectionString;
        SqlConnection myConnect = new SqlConnection(strConnectionString);
        string strCommandText = "INSERT Invoice (Invoice_Date, Invoice_DueDate, Invoice_Amount, Invoice_Subject, Invoice_Description, Company_Name) VALUES (@issuedate, @duedate, @amount, @subject, @description, @companyname)";
        SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
        cmd.Parameters.AddWithValue("@companyname", companyname);
        cmd.Parameters.AddWithValue("@issuedate", issuedate);
        cmd.Parameters.AddWithValue("@duedate", duedate);
        cmd.Parameters.AddWithValue("@amount", amount);
        cmd.Parameters.AddWithValue("@subject", subject);
        cmd.Parameters.AddWithValue("@description", description);
        myConnect.Open();
        int result = cmd.ExecuteNonQuery();
        if (result > 0)
        {
            lbl_Error.Text = "Record Inserted";
        }
        else
        {
            lbl_Error.Text = "Insert Fail";
        }

        myConnect.Close();
        grdPayment.EditIndex = -1;
        bindgrdPayment();

    }

    protected void grdPayment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdPayment.EditIndex = -1;
        bindgrdPayment();
    }

    protected void grdPayment_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdPayment.EditIndex = e.NewEditIndex;
        bindgrdPayment();
    }

    protected void grdPayment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int selectedRow = e.RowIndex;
        int InvoiceID = (int)grdPayment.DataKeys[selectedRow].Value;
        deletePaymentRecord(InvoiceID);
    }

    private void deletePaymentRecord(int InvoiceID)
    {
        string strConnectionString =
            ConfigurationManager.ConnectionStrings["SupplierConnectionString"].ConnectionString;
        SqlConnection myConnect = new SqlConnection(strConnectionString);
        string strCommandText = "DELETE Invoice WHERE Invoice_Id = @InvoiceID";
        SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
        cmd.Parameters.AddWithValue("@InvoiceID", InvoiceID);

        myConnect.Open();
        int result = cmd.ExecuteNonQuery();

        if (result > 0)
        {
            lblResult.Text = "Record Deleted";
        }
        else
        {
            lblResult.Text = "Delete Fail";
        }

        myConnect.Close();
        bindgrdPayment();
    }
    protected void grdPayment_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int selectedRow = e.RowIndex;
        int InvoiceId = (int)grdPayment.DataKeys[selectedRow].Value;

        GridViewRow row = (GridViewRow)grdPayment.Rows[selectedRow];
        TextBox Duedate = (TextBox)row.FindControl("tbInvoice_DueDate");
        string duedate = Duedate.Text;
        DateTime dd = Convert.ToDateTime(duedate.ToString());

        GridViewRow row1 = (GridViewRow)grdPayment.Rows[selectedRow];
        TextBox Amount = (TextBox)row1.FindControl("tbInvoice_Amount");
        string amount = Amount.Text;
        decimal a = Convert.ToDecimal(amount.ToString());

        GridViewRow row2 = (GridViewRow)grdPayment.Rows[selectedRow];
        TextBox Subject = (TextBox)row2.FindControl("tbInvoice_Subject");
        string s = Subject.Text;

        GridViewRow row3 = (GridViewRow)grdPayment.Rows[selectedRow];
        TextBox Description = (TextBox)row3.FindControl("tbInvoice_Description");
        string d = Description.Text;



        updateInvoice(InvoiceId, dd, a, s, d);

    }
    private void updateInvoice(int InvoiceId, DateTime dd, decimal a, string s, string d)
    {
        string strConnectionString =
            ConfigurationManager.ConnectionStrings["SupplierConnectionString"].ConnectionString;
        SqlConnection myConnect = new SqlConnection(strConnectionString);
        string strCommandText = "UPDATE Invoice SET Invoice_DueDate = @dd, Invoice_Amount = @a, Invoice_Subject = @s, Invoice_Description = @d WHERE Invoice_Id = @InvoiceId";
        SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
        cmd.Parameters.AddWithValue("@InvoiceId", InvoiceId);
        cmd.Parameters.AddWithValue("@dd", dd);
        cmd.Parameters.AddWithValue("@a", a);
        cmd.Parameters.AddWithValue("@s", s);
        cmd.Parameters.AddWithValue("@d", d);

        myConnect.Open();
        int result = cmd.ExecuteNonQuery();

        if (result > 0)
        {
            lblResult.Text = "Record Updated";
        }
        else
        {
            lblResult.Text = "Update Fail";
        }

        myConnect.Close();
        grdPayment.EditIndex = -1;
        bindgrdPayment();
    }

    private void bindgrdPaymentDetails()
    {
        BLLPaymentCatalog cat = new BLLPaymentCatalog();
        DataSet ds;
        ds = cat.getPaymentList();
        grdPaymentStatus.DataSource = ds;
        grdPaymentStatus.DataBind();
    }


    protected void btnDB_Click(object sender, EventArgs e)
    {
        
    }




    protected void grdPayment_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void grdPayment_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grdPayment.Rows[0];
        string id = row.Cells[0].Text;



        if (id == Label1.Text)
        {
            string strConnectionString =
                ConfigurationManager.ConnectionStrings["SupplierConnectionString"].ConnectionString;
            DataTable da = new DataTable();
            SqlConnection con = new SqlConnection(strConnectionString);
            string commandText = "UPDATE Invoice SET PaymentStatus = 'PAID' WHERE Invoice_Id = @id";
            SqlCommand cmd = new SqlCommand(commandText, con);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            bindgrdPayment();

        }
    }

    protected void grdPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedRow = Convert.ToInt32(grdPaymentStatus.SelectedValue);
        BLLPaymentCatalog cat = new BLLPaymentCatalog();
        DataSet ds;
        ds = cat.getPaymentCatalogDetails(selectedRow);
        DVPayment.DataSource = ds;
        DVPayment.DataBind();

        DetailsViewRow row0 = DVPayment.Rows[2];
        Label1.Text = row0.Cells[1].Text;

        DetailsViewRow row1 = DVPayment.Rows[1];
        lblStatus.Text = row0.Cells[1].Text;

        

    }
}

    
