using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_ConfirmSupplier : System.Web.UI.Page
{
    private UserDTO userDtoUpdate;
    private UserDTO userDto;
    private SupplierDTO supplierDTO;
    private SupplierDAO supplier = new SupplierDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        session();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //try
        //{
            supplierDTO = (SupplierDTO)Session["SupplierDTO"];
            supplier.save(supplierDTO);
            Response.Redirect("Suppliers.aspx");
        //}
        //catch(Exception ex)
        //{
          //  ExceptionRedirect(ex);
        //}
    }

    private void ExceptionRedirect(Exception ex)
    {
        Response.Redirect("ErrorPage.aspx?ErrorMessage=" + ex.Message.Replace('\n', ' '), false);
    }

    private void session()
    {
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        supplierDTO = (SupplierDTO)Session["SupplierDTO"];
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("LoginPage.aspx");
        else
            lblSupplierName.Text = supplierDTO.supplierName;
            lblSupplierSurname.Text = supplierDTO.supplierSurname;
            lblCellNumber.Text = supplierDTO.supplierCellNumber;
            lblSurbub.Text = supplierDTO.supplierSuburb;
            lblStreet.Text = supplierDTO.supplierStreetName;
            lblPostalCode.Text = supplierDTO.supplierPostalCode;
    }
}