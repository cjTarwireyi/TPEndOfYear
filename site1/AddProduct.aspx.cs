using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_AddProduct : System.Web.UI.Page
{
    private UserDTO userDto = new UserDTO();
    private ProductDAO product = new ProductDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        UserDTO userDtoUpdate = new UserDTO();
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("LoginPage.aspx");
        loadSuppliers();

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Products products = new Products.ProductsBuilder()
        .prodName(txtName.Text)
        .prodDescription(txtDescription.Text)
        .prodQuantity(Int32.Parse(txtQuantity.Text))
        .prodPrice(Int32.Parse(txtPrice.Text))
        .prodStatus(true)
        .prodDateArrived(DateTime.Now.ToString())
        .prodSupplierID(Int32.Parse(txtSupplierID.Text))
        .build();
        Session["ProductsDTO"] = products;
        Server.Transfer("ConfirmProduct.aspx", true);
    }

    private void loadSuppliers()
    {
        SqlDataReader reader = product.loadSuppliers();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                if (reader != null)
                {
                    txtSupplierID.Items.Add(reader["supplierID"].ToString());
                }
                else
                {
                    break;
                }
            }
        }
        product.connectionClosed(); 
    }
}