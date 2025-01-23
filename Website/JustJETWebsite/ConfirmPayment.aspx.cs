using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

public partial class ConfirmPayment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblCardNumContent.Text = Request.QueryString["Card"];
        lblExpiryDateContent.Text = Request.QueryString["ExpiryDate"];
        lblCardHolderContent.Text = Request.QueryString["NameonCard"];
        lblBillingAddressContent.Text = Request.QueryString["BillingAddress"];
        lblTotalAmountContent.Text = Request.QueryString["FinalTotal"];
        lblConfirmationEmailContent.Text = "triciaalx@gmail.com";

        lblInvoiceId.Text = Request.QueryString["InvoiceId"];
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        DateTime today = DateTime.Today;
        string emailMsg = "Dear Mr/Ms " + lblCardHolderContent.Text + "<br/><br/>";
        emailMsg += "You have made a transaction to Supplier Store" + "<br/>";
        emailMsg += "Date of transfer: " + today + "<br/>";
        emailMsg += "Amount: $" + lblTotalAmountContent.Text + "<br/>";
        emailMsg += "From your account: " + lblCardNumContent.Text + "<br/><br/>";
        emailMsg += "Thank You For Your Payment";

        MailMessage msg = new MailMessage();
        msg.To.Add(lblConfirmationEmailContent.Text);
        msg.From = new MailAddress("triciaa001@gmail.com");
        msg.Subject = "Payment Completed";
        msg.Body = emailMsg;
        msg.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.EnableSsl = true;
        smtp.UseDefaultCredentials = false;
        NetworkCredential nc = new NetworkCredential("triciaa001@gmail.com", "wnmxmxkmxehpotpi");
        smtp.Credentials = nc;
        smtp.Send(msg);


        string status = "PAID";
        int invoiceid = Convert.ToInt32(lblInvoiceId.Text);

        insertPayment(status, invoiceid);

        string strConnectionString =
                 ConfigurationManager.ConnectionStrings["JustJETConnectionString"].ConnectionString;

        SqlConnection myConnection = new SqlConnection(strConnectionString);
        string command = "SELECT OTP (OTP) VALUES (@otp)";
        SqlCommand cmd = new SqlCommand(command, myConnection);
        cmd.Parameters.AddWithValue("@otp", txtOTP.Text);
        myConnection.Open();
        int result = cmd.ExecuteNonQuery();
        if (result > 0)
        {
            Response.Redirect("Payment.aspx");
        }
        else
        {
            lblErr.Text = "Invalid OTP";
        }


        
    }

    private void insertPayment(string status, int invoiceid)
    {
        string strConnectionString =
                 ConfigurationManager.ConnectionStrings["JustJETConnectionString"].ConnectionString;

        SqlConnection myConnection = new SqlConnection(strConnectionString);
        string command = "INSERT Payment (Payment_Status, Invoice_Id) VALUES (@status, @invoiceid)";
        SqlCommand cmd = new SqlCommand(command, myConnection);
        cmd.Parameters.AddWithValue("@status", status);
        cmd.Parameters.AddWithValue("@invoiceid", invoiceid);
        myConnection.Open();
        int result = cmd.ExecuteNonQuery();
        if (result> 0)
        {
            lblErr.Text = "";
        }
        else
        {
            lblErr.Text = "An error has occured";
        }
        myConnection.Close();
    }
}
        