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
    protected void Page_Load(object sender, EventArgs e)
    {
        UserDTO userDtoUpdate = new UserDTO();
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("LoginPage.aspx");

        ProductDAO prodConnnection = new ProductDAO();
        SqlConnection con = prodConnnection.connection();
        con.Open();
        String strCustomers = "Select supplierID from Suppliers";
        SqlCommand cmd = new SqlCommand(strCustomers, con);
        SqlDataReader reader = cmd.ExecuteReader();
   
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
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Products products = new Products();
        products.productName = txtName.Text;
        products.productDescription = txtDescription.Text;
        products.productQuantity = Int32.Parse(txtQuantity.Text);
        products.price = Int32.Parse(txtPrice.Text);
        products.productStatus = true;
        products.dateArrived = DateTime.Now;
        products.productSupplierID = Int32.Parse(txtSupplierID.Text);
        Session["ProductsDTO"] = products;
        Server.Transfer("ConfirmProduct.aspx", true);
    }
}