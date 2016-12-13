using BusineesLogic.domain;
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
    private OrderLineDAO orderline = new OrderLineDAO();
    private OrdersDAO order = new OrdersDAO();
    private DataTable dtOrders = new DataTable();
    private UserDTO userDto;
    private UserDTO userDtoUpdate;
    private ReturnDTO itemReturned;
    private GridViewRow row;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        session();
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
        try
        {
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
        catch(Exception ex)
        {
            ExceptionRedirect(ex);
        }
    }
    private void session()
    {
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("Default.aspx");
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");

        if (userDto.userTypeName.Trim() != "Admin")
            AdminLinkPanel.Visible = false;
        else
            userPanel.Visible = false;
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        row = GridView1.SelectedRow;
        int customerID = Convert.ToInt32(txtCustomerNumber.Text);
        string productID = GridView1.Rows[e.RowIndex].Cells[2].Text;
        string orderlineID = GridView1.Rows[e.RowIndex].Cells[4].Text;
        string orderID = GridView1.Rows[e.RowIndex].Cells[1].Text;
        string quantity = GridView1.Rows[e.RowIndex].Cells[5].Text;

        itemReturned = new ReturnDTO.ReturnBuilder()
        .customerNumber(customerID)
        .orderNumber(Convert.ToInt32(orderID))
        .productNumber(Convert.ToInt32(productID))
        .productQuantity(Convert.ToInt32(quantity))
        .build();
        try
        {
            returns.save(itemReturned);
            orderline.removeItem(productID, orderlineID);
            order.calculateOrder(orderID,itemReturned.customerID.ToString());// recalculating order

            searchOrders();
        }
        catch(Exception ex)
        {
            ExceptionRedirect(ex);
        }
    }

    public void reload(string orderNumber, string customerNumber)
    {
        dtOrders = returns.searchOrder(orderNumber, customerNumber);
        if (dtOrders != null)
        {
            if (dtOrders.Rows.Count > 0)
            {
                GridView1.DataSource = dtOrders;
                GridView1.DataBind();
            }
        }
    }

    private void ExceptionRedirect(Exception ex)
    {
        Response.Redirect("ErrorPage.aspx?ErrorMessage=" + ex.Message.Replace('\n', ' '), false);
    }


    protected void Submit_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();

        Response.Redirect("Default.aspx");
    }
}