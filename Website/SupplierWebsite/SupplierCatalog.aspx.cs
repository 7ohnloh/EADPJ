using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class SupplierCatalog : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            bindgrdCatalog();
            CreatePanel.Visible = false;
        }
        
    }

    private void bindgrdCatalog()
    {
        
        string strConnectionString =
            ConfigurationManager.ConnectionStrings["SupplierConnectionString"].ConnectionString;

        SqlConnection myConnection = new SqlConnection(strConnectionString);
        string command = "SELECT * FROM Product";
        SqlCommand cmd = new SqlCommand(command, myConnection);
        myConnection.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(reader);
        grdCatalog.DataSource = dt;
        grdCatalog.DataBind();
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
            string name = tbName.Text;
            string desc = tbDesc.Text;
            decimal price = Convert.ToDecimal(tbPrice.Text);
            int stock = Convert.ToInt32(tbStock.Text);
            string filename = "";

            if (ImageUpload.HasFile)
            {
                filename = ImageUpload.FileName;
                string filePath = "~/Images/" + ImageUpload.FileName;
                ImageUpload.SaveAs(Server.MapPath(filePath));

            }

            insertProduct(name, desc, price, filename, stock);
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

    private void insertProduct (string name, string desc, decimal price, string filename, int stock)
    {
        string strConnectionString
            = ConfigurationManager.ConnectionStrings["SupplierConnectionString"].ConnectionString;
        SqlConnection myConnect = new SqlConnection(strConnectionString);
        string strCommandText = "INSERT Product (Product_Name, Product_Desc, Product_Price, Product_Image, Product_Stocklevel) VALUES (@name, @desc, @price, @filename, @stock)";
        SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@desc", desc);
        cmd.Parameters.AddWithValue("@price", price);
        cmd.Parameters.AddWithValue("@filename", filename);
        cmd.Parameters.AddWithValue("@stock", stock);
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
        grdCatalog.EditIndex = -1;
        bindgrdCatalog();

    }

    protected void grdCatalog_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdCatalog.EditIndex = -1;
        bindgrdCatalog();
    }

    protected void grdCatalog_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdCatalog.EditIndex = e.NewEditIndex;
        bindgrdCatalog();
    }

    protected void grdCatalog_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int selectedRow = e.RowIndex;
        int productID = (int)grdCatalog.DataKeys[selectedRow].Value;
        GridViewRow row = (GridViewRow)grdCatalog.Rows[selectedRow];
        TextBox price = (TextBox)row.FindControl("txtPrice");
        string strPrice = price.Text.Remove(0, 1);
        double decPrice = 0;

        GridViewRow row1 = (GridViewRow)grdCatalog.Rows[selectedRow];
        TextBox name = (TextBox)row1.FindControl("txtName");
        string strName = name.Text;

        GridViewRow row2 = (GridViewRow)grdCatalog.Rows[selectedRow];
        TextBox desc = (TextBox)row2.FindControl("txtDesc");
        string strDesc = desc.Text;

        GridViewRow row3 = (GridViewRow)grdCatalog.Rows[selectedRow];
        TextBox image = (TextBox)row3.FindControl("txtImage");
        string strImage = image.Text;

        GridViewRow row4 = (GridViewRow)grdCatalog.Rows[selectedRow];
        TextBox stock = (TextBox)row4.FindControl("txtStock");
        string strStock = stock.Text;
        int intStock = Convert.ToInt32(strStock.ToString());

        if (Double.TryParse(strPrice, out decPrice))
        {
            updateGridView(productID, decPrice, strName, strDesc, strImage, intStock);
        }
        else
        {
            lbl_Error.Text = "Invalid price";
        }
    }
    private void updateGridView (int productID, double decPrice, string strName, string strDesc, string strImage, int intStock)
    {
        string strConnectionString
            = ConfigurationManager.ConnectionStrings["SupplierConnectionString"].ConnectionString;
        SqlConnection myConnect = new SqlConnection(strConnectionString);
        string strCommandText = "UPDATE Product SET Product_Price = @price, Product_Name = @name, Product_Desc = @desc, Product_Image = @image, Product_Stocklevel = @stock WHERE Product_Id = @productID";
        SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
        cmd.Parameters.AddWithValue("@productID", productID);
        cmd.Parameters.AddWithValue("@price", decPrice);
        cmd.Parameters.AddWithValue("@name", strName);
        cmd.Parameters.AddWithValue("@desc", strDesc);
        cmd.Parameters.AddWithValue("@image", strImage);
        cmd.Parameters.AddWithValue("@stock", intStock);
        myConnect.Open();
        int result = cmd.ExecuteNonQuery();
        if (result > 0)
        {
            lbl_Error.Text = "Record Updated";
        }
        else
        {
            lbl_Error.Text = "Update Fail";
        }

        myConnect.Close();
        grdCatalog.EditIndex = -1;
        bindgrdCatalog();
    }

    protected void grdCatalog_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int selectedRow = e.RowIndex;
        int productID = (int)grdCatalog.DataKeys[selectedRow].Value;
        deleteGridViewRecord(productID);
    }
    private void deleteGridViewRecord (int productID)
    {
        string strConnectionString
           = ConfigurationManager.ConnectionStrings["SupplierConnectionString"].ConnectionString;
        SqlConnection myConnect = new SqlConnection(strConnectionString);
        string strCommandText = "DELETE Product WHERE Product_Id = @productID";
        SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
        cmd.Parameters.AddWithValue("@productID", productID);
        myConnect.Open();
        int result = cmd.ExecuteNonQuery();
        if (result > 0)
        {
            lbl_Error.Text = "Record Deleted";
        }
        else
        {
            lbl_Error.Text = "Delete Fail";
        }
        myConnect.Close();
        bindgrdCatalog();
    }


    protected void grdCatalog_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int newPageIndex = e.NewPageIndex;
        grdCatalog.PageIndex = newPageIndex;
        bindgrdCatalog();
    }
}