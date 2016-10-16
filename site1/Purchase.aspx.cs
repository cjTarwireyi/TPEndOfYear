using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        DataRow dr = table.NewRow();
        dr["ProductCode"] = productCode;
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
            order.orderItems.Add(product);
            Session["order"] = order;
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
        order = (OrderDTO)Session["order"];
        facade.makeOrder(order);
         
    } 

    protected void txtProductID_TextChanged(object sender, EventArgs e)
    {
        /*AddToDataTable();
        BindGrid();*/
    }
}