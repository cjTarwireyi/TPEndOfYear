using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_ConfirmSupplier : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Supplier supplier = (Supplier)Session["SupplierDTO"];
        lblSupplierName.Text = supplier.supplierName;
        lblSupplierSurname.Text = supplier.supplierSurname;
        lblCellNumber.Text = supplier.supplierCellNumber;
        lblSurbub.Text = supplier.supplierSuburb;
        lblStreet.Text = supplier.supplierStreetName;
        lblPostalCode.Text = supplier.supplierPostalCode;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Supplier dto = (Supplier)Session["SupplierDTO"];
        SupplierDAO supplier = new SupplierDAO();
        supplier.save(dto);
        Response.Redirect("Suppliers.aspx");
    }
}