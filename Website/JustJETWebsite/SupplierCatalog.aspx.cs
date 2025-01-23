using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Company.BusinessLogicLayer;

public partial class SupplierCatalog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void btnRetrieveSupplierCatalog_Click(object sender, EventArgs e)
    {
        bindgrdSupplier();
    }

    private void bindgrdSupplier()
    {
        BLLSupplierCatalog cat = new BLLSupplierCatalog();
        DataSet ds;
        ds = cat.getSupplierProductList();
        grdSupplier.DataSource = ds;
        grdSupplier.DataBind();

    }


}