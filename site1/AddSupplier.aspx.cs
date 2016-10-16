using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_AddSupplier : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserDTO userDtoUpdate = new UserDTO();
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        SupplierDTO supplierDTO = new SupplierDTO();
        supplierDTO.supplierName = txtName.Text;
        supplierDTO.supplierSurname = txtSurname.Text;
        supplierDTO.supplierCellNumber = txtCellNumber.Text;
        supplierDTO.supplierStreetName = txtStreetName.Text;
        supplierDTO.supplierSuburb = txtSuburb.Text;
        supplierDTO.supplierPostalCode = txtPostalCode.Text;
        Session["SupplierDTO"] = supplierDTO;

        Response.Redirect("ConfirmSupplier.aspx");
    }
}