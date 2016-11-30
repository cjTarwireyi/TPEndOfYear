using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_ConfirmProduct : System.Web.UI.Page
{
    private UserDTO userDtoUpdate;
    private UserDTO userDto;
    private Products product;
    ProductDAO prod = new ProductDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        session();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //try
        //{
            product = (Products)Session["ProductsDTO"];
            prod.save(product);
            Response.Redirect("Products.aspx");
       // }
        //catch(Exception ex)
        //{
        //    ExceptionRedirect(ex);
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
        product = (Products)Session["ProductsDTO"];
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("LoginPage.aspx");
        else
        lblName.Text = "Name: " + product.productName;
        lblDescription.Text = "Discription: " + product.productDescription;
        lblQuantity.Text = "Quantity: " + product.productQuantity.ToString();
        lblPrice.Text = "Price: " + product.price.ToString();
        lblTime.Text = "Date: " + product.dateArrived.ToString();
        lblSupplierID.Text = "SupplierID: " + product.productSupplierID.ToString();
    }
}