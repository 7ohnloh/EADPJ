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

public partial class PayMethod : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.CreditCardDiv.Visible = false;

        lblTotalContent.Text = Request.QueryString["TotalAmount"];
        lblDiscountContent.Text = Request.QueryString["Discount"];
        lblDeliveryFeeContent.Text = Request.QueryString["DeliveryFee"];
        lblInterestFeeContent.Text = Request.QueryString["InterestFee"];
        lblFinalTotalContent.Text = Request.QueryString["FinalAmount"];
    }

    protected void btnPay_Click(object sender, EventArgs e)
    {
        string cardNumber = txtCreditCardNum.Text;
        string cardholder = txtCardHolder.Text;
        string creditcardnum = txtCreditCardNum.Text;
        string maskcreditcard = string.Format("************{0}", this.txtCreditCardNum.Text.Trim().Substring(12, 4));
        string securitycode = txtSecurityCode.Text;
        string expirydate = ddlMonth.SelectedItem.ToString() + ddlYear.SelectedItem.ToString();
        string ConnectionString =
            ConfigurationManager.ConnectionStrings["JustJETConnectionString"].ConnectionString;
        SqlConnection myConnect = new SqlConnection(ConnectionString);
        string CommandText = "INSERT CreditCard (CardHolder, CreditCardNum, SecurityCode, ExpiryDate) VALUES (@cardholder, @creditcardnum, @securitycode, @expirydate)";
        SqlCommand cmd = new SqlCommand(CommandText, myConnect);
        cmd.Parameters.AddWithValue("@cardholder", cardholder);
        cmd.Parameters.AddWithValue("@creditcardnum", maskcreditcard);
        cmd.Parameters.AddWithValue("@securitycode", securitycode);
        cmd.Parameters.AddWithValue("@expirydate", expirydate);
        myConnect.Open();
        int result = cmd.ExecuteNonQuery();
        if (result > 0)
        {

        }
        else
        {

        }
        myConnect.Close();

        string OTP = lblOTP.Text;
        string ConnectionStringg =
            ConfigurationManager.ConnectionStrings["JustJETConnectionString"].ConnectionString;
        SqlConnection myConnectt = new SqlConnection(ConnectionStringg);
        string CmdText = "INSERT OTP (OTP) VALUES (@OTP)";
        SqlCommand cmd1 = new SqlCommand(CmdText, myConnectt);
        cmd1.Parameters.AddWithValue("@OTP", OTP);
        myConnectt.Open();
        int result1 = cmd1.ExecuteNonQuery();
        if (result1 > 0)
        {

        }
        else
        {

        }
        myConnectt.Close();
        string emailMsgg = "Your One-Time Password (OTP) is " + lblOTP.Text + "<br/>";
        emailMsgg += "Use it to enter your OTP before proceeding with your payment";

        lblOTPEmail.Text = "triciaalx@gmail.com";
        MailMessage msgg = new MailMessage();
        msgg.To.Add(lblOTPEmail.Text);
        msgg.From = new MailAddress("justJET123@gmail.com");
        msgg.Subject = "OTP";
        msgg.Body = emailMsgg;
        msgg.IsBodyHtml = true;
        SmtpClient smtpp = new SmtpClient("smtp.gmail.com", 587);
        smtpp.Host = "smtp.gmail.com";
        smtpp.Port = 587;
        smtpp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpp.EnableSsl = true;
        smtpp.UseDefaultCredentials = false;
        NetworkCredential ncc = new NetworkCredential("justJET123@gmail.com", "wjryjmvcvjrvfhic");
        smtpp.Credentials = ncc;
        smtpp.Send(msgg);

        Response.Redirect("ConfirmPayment.aspx?InvoiceId=" + Request.QueryString["InvoiceId"] + "&FinalTotal=" + lblFinalTotalContent.Text + "&BillingAddress=" + Request.QueryString["DeliveryAddress"] + "&CompanyName=" + Request.QueryString["CompanyName"] + "&Email=" + Request.QueryString["Email"] + "&NameonCard=" + txtCardHolder.Text + "&ExpiryDate=" + expirydate.ToString() + "&Card=" + maskcreditcard.ToString());

    }

    protected void btnCreditCard_Click(object sender, EventArgs e)
    {
       
        this.CreditCardDiv.Visible = true;

        string num = "0123456789";
        int len = num.Length;
        string otp = string.Empty;
        int otpdigit = 6;
        string finaldigit;
        int getindex;
        for (int i = 0; i < otpdigit; i++)
        {
            do
            {
                getindex = new Random().Next(0, len);
                finaldigit = num.ToCharArray()[getindex].ToString();
            } while (otp.IndexOf(finaldigit) != -1);
            {
                otp += finaldigit;
            }
        }
        lblOTP.Text = otp.ToString();
    }

    protected void btnPaypal_Click(object sender, EventArgs e)
    {
        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }

    protected void btnReceiveOTP_Click(object sender, EventArgs e)
    {
       
        

    }

    public static bool IsCardNumberValid(string cardNumber)
    {
        int i, checkSum = 0;

        // Compute checksum of every other digit starting from right-most digit
        for (i = cardNumber.Length - 1; i >= 0; i -= 2)
            checkSum += (cardNumber[i] - '0');

        // Now take digits not included in first checksum, multiple by two,
        // and compute checksum of resulting digits
        for (i = cardNumber.Length - 2; i >= 0; i -= 2)
        {
            int val = ((cardNumber[i] - '0') * 2);
            while (val > 0)
            {
                checkSum += (val % 10);
                val /= 10;
            }
        }

        // Number is valid if sum of both checksums MOD 10 equals 0
        return ((checkSum % 10) == 0);
    }
    public static string NormalizeCardNumber(string cardNumber)
    {
        if (cardNumber == null)
            cardNumber = String.Empty;

        StringBuilder sb = new StringBuilder();

        foreach (char c in cardNumber)
        {
            if (Char.IsDigit(c))
                sb.Append(c);
        }

        return sb.ToString();
    }
    public enum CardType
    {
        Unknown = 0,
        MasterCard = 1,
        VISA = 2,
        Amex = 3,
        Discover = 4,
        DinersClub = 5,
        JCB = 6,
        enRoute = 7
    }

    // Class to hold credit card type information
    private class CardTypeInfo
    {
        public CardTypeInfo(string regEx, int length, CardType type)
        {
            RegEx = regEx;
            Length = length;
            Type = type;
        }

        public string RegEx { get; set; }
        public int Length { get; set; }
        public CardType Type { get; set; }
    }

    // Array of CardTypeInfo objects.
    // Used by GetCardType() to identify credit card types.
    private static CardTypeInfo[] _cardTypeInfo =
    {
      new CardTypeInfo("^(51|52|53|54|55)", 16, CardType.MasterCard),
      new CardTypeInfo("^(4)", 16, CardType.VISA),
      new CardTypeInfo("^(4)", 13, CardType.VISA),
      new CardTypeInfo("^(34|37)", 15, CardType.Amex),
      new CardTypeInfo("^(6011)", 16, CardType.Discover),
      new CardTypeInfo("^(300|301|302|303|304|305|36|38)",
                       14, CardType.DinersClub),
      new CardTypeInfo("^(3)", 16, CardType.JCB),
      new CardTypeInfo("^(2131|1800)", 15, CardType.JCB),
      new CardTypeInfo("^(2014|2149)", 15, CardType.enRoute),
    };

    public static CardType GetCardType(string cardNumber)
    {
        foreach (CardTypeInfo info in _cardTypeInfo)
        {
            if (cardNumber.Length == info.Length &&
                Regex.IsMatch(cardNumber, info.RegEx))
                return info.Type;
        }

        return CardType.Unknown;
    }

    protected void PaymentOption_SelectedIndexChanged(object sender, EventArgs e)
    {



    }





    
}