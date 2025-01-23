using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Company.BusinessLogicLayer;
using System.Net;
using System.IO;
using System.Security.Authentication;
using Newtonsoft.Json;

public partial class Payment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            bindgrdPayment();
        }
    }
    private void bindgrdPayment()
    {
        BLLInvoiceCatalog cat = new BLLInvoiceCatalog();
        DataSet ds;
        ds = cat.getInvoiceList();
        grdPayment.DataSource = ds;
        grdPayment.DataBind();



    }


    protected void grdPayment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            DetailsViewInvoice.Visible = true;

        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        DetailsViewInvoice.Visible = false;

    }

    protected void grdPayment_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedRow = Convert.ToInt32(grdPayment.SelectedValue);
        BLLInvoiceCatalog cat = new BLLInvoiceCatalog();
        DataSet ds;
        ds = cat.getInvoiceCatalogDetails(selectedRow);
        DetailsViewInvoice.DataSource = ds;
        DetailsViewInvoice.DataBind();

        DetailsViewRow row0 = DetailsViewInvoice.Rows[0];
        lblInvoiceId.Text = row0.Cells[1].Text;

        DetailsViewRow row1 = DetailsViewInvoice.Rows[1];
        lblCompanyName.Text = row1.Cells[1].Text;

        DetailsViewRow row2 = DetailsViewInvoice.Rows[2];
        lblInvoiceDate.Text = row2.Cells[1].Text;
        DateTime IssueDate = DateTime.Parse(lblInvoiceDate.Text);
        lblInvoiceDate.Text = IssueDate.ToString("dd/MM/yyyy");

        DetailsViewRow row3 = DetailsViewInvoice.Rows[3];
        lblInvoiceDueDate.Text = row3.Cells[1].Text;
        DateTime DueDate = DateTime.Parse(lblInvoiceDueDate.Text);
        lblInvoiceDueDate.Text = DueDate.ToString("dd/MM/yyyy");

        DetailsViewRow row4 = DetailsViewInvoice.Rows[4];
        lblInvoiceAmount.Text = row4.Cells[1].Text;

        DetailsViewRow row5 = DetailsViewInvoice.Rows[5];
        lblInvoiceSubject.Text = row5.Cells[1].Text;

        DetailsViewRow row6 = DetailsViewInvoice.Rows[6];
        lblInvoiceDescription.Text = row6.Cells[1].Text;

        
    }

    protected void btnPayment_Click(object sender, EventArgs e)
    {
        Response.Redirect("Pay.aspx?AmountDue=" + lblInvoiceAmount.Text +"&Email=" + "triciaalx@gmail.com" + "&IssueDate" + lblInvoiceDate.Text + "&DueDate=" + lblInvoiceDueDate.Text + "&InvoiceId=" + lblInvoiceId.Text + "&CompanyName=" + lblCompanyName.Text);
        //Response.Redirect("Pay.aspx?InvoiceId=" + lblInvoiceId.Text + "CompanyName=" + lblCompanyName.Text + "AmountDue=" + lblInvoiceAmount.Text);

    }

    protected void DetailsViewInvoice_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName == "MakePayment")
        {


        }
    }
}