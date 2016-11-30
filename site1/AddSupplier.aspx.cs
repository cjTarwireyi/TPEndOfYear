using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_AddSupplier : System.Web.UI.Page
{
    private UserDTO userDto;
    private UserDTO userDtoUpdate;
    protected void Page_Load(object sender, EventArgs e)
    {
        session();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        SupplierDTO supplierDTO = new SupplierDTO.SupplierBuilder()
        .supName(txtName.Text)
        .supSurname(txtSurname.Text)
        .supCellNumber(txtCellNumber.Text)
        .supAddress(txtStreetName.Text, txtSuburb.Text, txtPostalCode.Text)
        .build();
        Session["SupplierDTO"] = supplierDTO;
        Response.Redirect("ConfirmSupplier.aspx");
    }

    private void ExceptionRedirect(Exception ex)
    {
        Response.Redirect("ErrorPage.aspx?ErrorMessage=" + ex.Message.Replace('\n', ' '), false);
    }

    private void session()
    {
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("LoginPage.aspx");
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
    }
}