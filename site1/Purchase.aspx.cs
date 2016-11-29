﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusineesLogic.Interface;
using System.Drawing;
using BusineesLogic.Interface;

public partial class site1_Purchase : System.Web.UI.Page
{
    private DataTable table;
    private UserDTO userDto = new UserDTO();
    private UserDTO userDtoUpdate = new UserDTO();
    private OrderFacade facade = new OrderFacade();
    private OrderDTO order = new OrderDTO();
    private Products product = new Products();
    private IProduct productService = new ProductDAO();
    private ICustomers customerService = new CustomerDAO();
    private string amt;
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.AutoGenerateSelectButton = true;
        GridView1.AutoGenerateDeleteButton = true;

        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("LoginPage.aspx");
        List<CustomerDTO> data = customerService.getAllCustomers();
        List<ListItem> items = new List<ListItem>();
       // items.Add("");
        foreach (var item in data)
        {
            customer.Items.Add(item.name);
        }
        

        lblUser.Text = userDto.username;
        if (!this.IsPostBack)
        {
            table = new DataTable();
            MakeTable();
            GridView1.DataSource = "";
            GridView1.DataBind();
        }
        else
        {
            table = (DataTable)ViewState["DataTable"];
        }
        ViewState["DataTable"] = table;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AddToDataTable();
        BindGrid();
    }

    private void MakeTable()
    {
        table.Columns.Add("ProductCode");
        table.Columns.Add("Product");
        table.Columns.Add("Price");
        table.Columns.Add("Quantity");
    }

    private void AddToDataTable()
    {
        try
        {
            string productCode = txtProductID.Text;
            string quantity = txtQuantiy.Text;
            string custId = txtCustomerID.Text;
            string productName = "";
            string price = "";
            totalAmt.Text = string.Empty;

            if (facade.findProduct(Convert.ToInt32(productCode)) == null)
            {

                lblErrorProd.Visible = false;
            }
            else if (facade.findCustomer(Convert.ToInt32(custId)) == "401")
            {
                custError.Visible = true;
            }
            else
            {
                custError.Visible = false;
                lblErrorProd.Visible = false;
            }
            if (lblErrorProd.Visible == false && custError.Visible == false)
            {
                string ogAmount;
                if (grandTotal.Text == "")
                {
                    ogAmount = "0";
                }
                else
                {
                    ogAmount = grandTotal.Text;
                }
                totalAmt.Text = "Grand Total: R";
                grandTotal.Text = "";
                productName = facade.findProduct(Convert.ToInt32(productCode)).productName;
                price = facade.findProduct(Convert.ToInt32(productCode)).price.ToString();
                if (facade.findProduct(Convert.ToInt32(productCode)).productQuantity < Convert.ToInt32(quantity))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + "The quantity entered is more that the one in stock " + "');", true);
                    txtQuantiy.Text = string.Empty;
                }
                else
                {
                    amt = ((Convert.ToDecimal(price) * Convert.ToInt32(quantity)) + Convert.ToDecimal(ogAmount)).ToString();

                    grandTotal.Text = amt;
                    lblErrorProd.Visible = false;
                    custError.Visible = false;
                    DataRow dr = table.NewRow();
                    dr["ProductCode"] = productCode;
                    dr["Product"] = productName;
                    dr["Price"] = price;
                    dr["Quantity"] = quantity;
                    table.Rows.Add(dr);

                    product.productNumber = Convert.ToInt32(productCode);
                    product.productQuantity = Convert.ToInt32(quantity);
                    order.orderItems = new List<Products>();

                    if (order.orderItems.Contains(product))
                    {
                        Products foundproduct;
                        foundproduct = order.orderItems.Find(t => t.productNumber == product.productNumber);
                        foundproduct.productQuantity += product.productQuantity;
                    }
                    else
                    {


                    }


                    txtProductID.Text = string.Empty;
                    txtQuantiy.Text = string.Empty;
                    custError.Visible = false;
                }
            }
        }
        catch (NotFiniteNumberException ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + "Make sure you entered correct format " + "');", true);
                    
        }
        
    }

    private void BindGrid()
    {
        GridView1.DataSource = table;
        GridView1.DataBind();
    }


    protected void Submit_Click(object sender, EventArgs e)
    {

        generateOrder();
        OrdersDAO accessOrders = new OrdersDAO();
        OrderDTO order = new OrderDTO();
        order = accessOrders.getLastReocrd();
        Response.Redirect("Receipt.aspx?Id=" + order.orderId, false);
    }

    protected void txtProductID_TextChanged(object sender, EventArgs e)
    {
         
    }

    private void generateOrder()
    {
        OrdersDAO accessOrders = new OrdersDAO();
        OrderDTO lastRecord = new OrderDTO();
        CustomerDTO customer = new CustomerDTO();
        CustomerDAO accessCustomer = new CustomerDAO();
        decimal amt = 0;

        
        List<Products> list = new List<Products>();
        lblErrorProd.Visible = false;
        custError.Visible = false;
        foreach (GridViewRow row in GridView1.Rows)
        {

            product.productNumber = Convert.ToInt32(row.Cells[1].Text);
            product.productQuantity = Convert.ToInt32(row.Cells[4].Text);
            amt += facade.findProduct(product.productNumber).price * product.productQuantity;
             
            list.Add(product);
            productService.updateQuantity(product.productNumber, product.productQuantity);

        }
        userDto = (UserDTO)Session["userDto"];
        OrderDTO buliOrder = new OrderDTO.OrderBuilder()
            .buildProducts(list)
            .buildEmpId(userDto.Id)
            .buildAmount(amt)
            .buildPayed(false)
            .buildCustId(Convert.ToInt32(txtCustomerID.Text))
            .build();   
                 
        facade.makeOrder(buliOrder);
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        table = new DataTable();

        GridView1.DataSource = "";
        GridView1.DataBind();
        MakeTable();
        ViewState["DataTable"] = table;
        grandTotal.Text = "";
        amt = "";
    }

}