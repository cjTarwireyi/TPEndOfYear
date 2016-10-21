using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_Purchase : System.Web.UI.Page
{
    private DataTable table;
    private UserDTO userDto = new UserDTO();
    private UserDTO userDtoUpdate = new UserDTO();
    private OrderFacade facade = new OrderFacade();
    OrderDTO order = new OrderDTO();
    Products product = new Products();
    protected void Page_Load(object sender, EventArgs e)
    {
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("LoginPage.aspx");

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
        
        string  productCode = txtProductID.Text;
        string quantity= txtQuantiy.Text;
        string custId = txtCustomerID.Text;
        string productName="";
        string price = "";

        if (facade.findProduct(Convert.ToInt32(productCode)) == null)
        {
            
            lblErrorProd.Visible = false;
        }
        else if(facade.findCustomer(Convert.ToInt32(custId))=="401"){
            custError.Visible = true;
        }
       if(lblErrorProd.Visible==false && custError.Visible==false)
        {
            string ogAmount = grandTotal.Text;
            
            productName = facade.findProduct(Convert.ToInt32(productCode)).productName;
            price = facade.findProduct(Convert.ToInt32(productCode)).price.ToString();
            string amt = ((Convert.ToDecimal(price) * Convert.ToInt32(quantity))+ogAmount).ToString();
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
        }
    }

    private void BindGrid()
    {
        GridView1.DataSource = table;
        GridView1.DataBind();
    }
    //protected void Submit_Click(object sender, EventArgs e)
    //{

    //    Session.Abandon();
    //    Session.Clear();

    //    Response.Redirect("LoginPage.aspx");
    //}
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
        /*AddToDataTable();
        BindGrid();*/
    }

    private void generateOrder()
    {
        OrdersDAO accessOrders = new OrdersDAO();
        OrderDTO lastRecord  = new OrderDTO();
        CustomerDTO customer = new CustomerDTO();
        CustomerDAO accessCustomer = new CustomerDAO();
        decimal amt = 0;
        order.orderItems = new List<Products>();
        lblErrorProd.Visible = false;
        custError.Visible = false;
        foreach (GridViewRow row in GridView1.Rows)
        {

            product.productNumber = Convert.ToInt32(row.Cells[0].Text);
            product.productQuantity = Convert.ToInt32(row.Cells[3].Text);
            amt += facade.findProduct(product.productNumber).price * product.productQuantity;
            order.orderItems.Add(product);
        }
        //lastRecord = accessOrders.getLastReocrd();
        //customer = accessCustomer.getCustomerID(lastRecord.customerId);
        order.employeeId =3;
        order.amount = amt;
        order.payed = false;
        order.customerId = Convert.ToInt32(txtCustomerID.Text);
        facade.makeOrder(order); 
    }
}