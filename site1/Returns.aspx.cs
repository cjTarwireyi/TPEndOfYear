using BusineesLogic.services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_Returns : System.Web.UI.Page
{

    private ReturnDAO returns = new ReturnDAO();
    private DataTable dtOrders = new DataTable();
    private UserDTO userDto;
    private UserDTO userDtoUpdate;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearchOrder_Click(object sender, EventArgs e)
    {
        lblResult.Visible = false;
        searchOrders();
    }

    private void searchOrders()
    {
        string customerNumber = txtCustomerNumber.Text;
        string orderNumber = txtOrderNumber.Text;
        dtOrders = returns.searchOrder(orderNumber, customerNumber);
        if (dtOrders != null)
        {
            if (dtOrders.Rows.Count > 0)
            {
                GridView1.DataSource = dtOrders;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = "";
                GridView1.DataBind();
                lblResult.Visible = true;
            }


        }
       
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