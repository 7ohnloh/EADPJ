using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using PayPal.Api;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;

public partial class Pay : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        

        lblOTPEmail.Text = Convert.ToString(Request.QueryString["Email"]);
        lblCompanyName.Text = Convert.ToString(Request.QueryString["CompanyName"]);
        string companyName = lblCompanyName.Text;


        if (Page.IsPostBack == false)
        {


            string strConnectionString =
                        ConfigurationManager.ConnectionStrings["JustJETConnectionString"].ConnectionString;

            SqlConnection myConnection = new SqlConnection(strConnectionString);
            string command = "SELECT Company_Name, Company_Address, Company_Email FROM Company";
            SqlCommand cmd = new SqlCommand(command, myConnection);
            myConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtName.Text = reader["Company_Name"].ToString();
                txtDeliveryAddress.Text = reader["Company_Address"].ToString();
                txtEmail.Text = reader["Company_Email"].ToString();
            }

            reader.Close();
            myConnection.Close();


            //lblTotalContent
            string amount = Server.UrlDecode(Request.QueryString["AmountDue"]);
            lblTotalContent.Text = amount;

            lblInvoiceId.Text = Request.QueryString["InvoiceId"];




            //lblDeliveryFeeContent and lblFinalTotalContent and lblDiscountContent
            decimal decAmount = Convert.ToDecimal(lblTotalContent.Text);
            if (decAmount >= Convert.ToDecimal(300.00))
            {
                lblDeliveryFeeContent.Text = "0.00";
                decimal decDeliveryFee = Convert.ToDecimal(lblDeliveryFeeContent.Text);

                //lblDiscountContent
                DateTime duedate = Convert.ToDateTime(Request.QueryString["DueDate"]);
                DateTime today = DateTime.Today;
                DateTime issuedate = Convert.ToDateTime(Request.QueryString["IssueDate"]);
                DateTime tendays = issuedate.AddDays(10);

                if (today < tendays)
                {
                    lblDiscountContent.Text = Convert.ToString((decAmount / 100) * 2);
                }
                else
                {
                    lblDiscountContent.Text = "0.00";

                }

                //lblInterestFeeContent
                if (today > duedate)
                {
                    TimeSpan days = today.Subtract(duedate);
                    int value = days.Days;
                    decimal interestfee = Math.Round(value * (decAmount / 100) * 2, 2);
                    lblInterestFeeContent.Text = Convert.ToString(interestfee);

                }
                else
                {
                    lblInterestFeeContent.Text = "0.00";
                }

                //lblFinalTotalContent

                decimal decDiscount = Convert.ToDecimal(lblDiscountContent.Text);
                decimal decInterest = Convert.ToDecimal(lblInterestFeeContent.Text);
                lblFinalTotalContent.Text = Convert.ToString(decAmount - decDiscount + decDeliveryFee + decInterest);

            }
            else
            {
                lblDeliveryFeeContent.Text = "10.00";
                decimal decDeliveryFee = Convert.ToDecimal(lblDeliveryFeeContent.Text);


                //lblDiscountContent
                DateTime duedate = Convert.ToDateTime(Request.QueryString["DueDate"]);
                DateTime today = DateTime.Today;
                DateTime issuedate = Convert.ToDateTime(Request.QueryString["IssueDate"]);
                DateTime tendays = issuedate.AddDays(10);

                if (today < tendays)
                {
                    lblDiscountContent.Text = Convert.ToString((decAmount / 100) * 2);
                }
                else
                {
                    lblDiscountContent.Text = "0.00";

                }

                //lblInterestFeeContent
                if (today > duedate)
                {
                    TimeSpan days = today.Subtract(duedate);
                    int value = days.Days;
                    decimal interestfee = Math.Round(value * (decAmount / 100) * 2, 2);
                    lblInterestFeeContent.Text = Convert.ToString(interestfee);

                }
                else
                {
                    lblInterestFeeContent.Text = "0.00";
                }

                //lblFinalTotalContent

                decimal decDiscount = Convert.ToDecimal(lblDiscountContent.Text);
                decimal decInterest = Convert.ToDecimal(lblInterestFeeContent.Text);
                lblFinalTotalContent.Text = Convert.ToString(decAmount - decDiscount + decDeliveryFee + decInterest);
            }


        }


    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        

        string strConnectionString =
                ConfigurationManager.ConnectionStrings["JustJETConnectionString"].ConnectionString;

        SqlConnection myConnection = new SqlConnection(strConnectionString);
        string command = "UPDATE Company SET Company_Name = @companyname, Company_Address = @companyaddress, Company_Email = @companyemail";
        try
        {

            SqlCommand cmd = new SqlCommand(command, myConnection);
            cmd.Parameters.Add("@companyname", SqlDbType.NVarChar, 30);
            cmd.Parameters["@companyname"].Value = txtName.Text;

            cmd.Parameters.Add("@companyaddress", SqlDbType.NVarChar, 100);
            cmd.Parameters["@companyaddress"].Value = txtDeliveryAddress.Text;

            cmd.Parameters.Add("@companyemail", SqlDbType.NVarChar, 100);
            cmd.Parameters["@companyemail"].Value = txtEmail.Text;

            myConnection.Open();
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                lblErr.Text = "Update Successful";
                Response.Redirect("PayMethod.aspx?InvoiceId=" +lblInvoiceId.Text+ "&CompanyName=" +txtName.Text+ "&DeliveryAddress=" +txtDeliveryAddress.Text+ "&Email=" +txtEmail.Text+ "&TotalAmount=" + lblTotalContent.Text+ "&Discount=" +lblDiscountContent.Text+ "&DeliveryFee=" +lblDeliveryFeeContent.Text+ "&InterestFee=" +lblInterestFeeContent.Text+ "&FinalAmount=" +lblFinalTotalContent.Text);

            }
            else
            {
                lblErr.Text = "Update Fail";
            }


        }
        catch (Exception ex)
        {
            lblErr.Text = ex.Message.ToString();
        }
        myConnection.Close();

        
        

    }

    
}