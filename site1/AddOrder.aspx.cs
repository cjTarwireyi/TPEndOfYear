using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_AddOrder : System.Web.UI.Page
{
    OrderDTO order = new OrderDTO();
    Products product = new Products();
    protected void Page_Load(object sender, EventArgs e)
    {
        UserDTO userDtoUpdate = new UserDTO();
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
    }
    protected void Register_Click(object sender, EventArgs e)
    {


        product.productNumber = 1;
        product.productQuantity = 2;
        if (order.orderItems.Contains(product))
        {
            Products foundproduct;
            foundproduct = order.orderItems.Find(t => t.productNumber == product.productNumber);
           foundproduct.productQuantity += product.productQuantity;
        }
        else
        {
            order.orderItems.Add(product);
        }
        
    }
    protected void Save(object sender, EventArgs e)
    {
         
    }
    protected void removeItem(object sender, EventArgs e)
    {
         
        Products foundproduct;
        foundproduct = order.orderItems.Find(t => t.productNumber == product.productNumber);
        order.orderItems.Remove(foundproduct);
    }

}