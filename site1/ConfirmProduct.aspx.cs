using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_ConfirmProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserDTO userDtoUpdate = new UserDTO();
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        Products product = (Products)Session["ProductsDTO"];
        lblName.Text ="Name: "+ product.productName;
        lblDescription.Text = "Discription: "+product.productDescription;
        lblQuantity.Text = "Quantity: "+product.productQuantity.ToString();
        lblPrice.Text = "Price: "+product.price.ToString();
        lblTime.Text = "Date: "+product.dateArrived.ToString();
        lblSupplierID.Text = "SupplierID: "+product.productSupplierID.ToString();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Products item = (Products)Session["ProductsDTO"];
        ProductDAO product = new ProductDAO();
        product.saveProduct(item);
        Response.Redirect("Products.aspx");
    }
}