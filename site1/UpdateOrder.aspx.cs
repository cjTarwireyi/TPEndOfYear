using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class site1_UpdateOrder : System.Web.UI.Page
{
    private OrderLineDAO order = new OrderLineDAO();
    private ProductDAO product = new ProductDAO();
    private UserDTO userDtoUpdate;
    private UserDTO userDto;
    private GridViewRow row;
    private Products prodResult;
    protected void Page_Load(object sender, EventArgs e)
    {
        session();
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Orders.aspx");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string productID = txtProductID.Text;
        string quantity = txtQuantiy.Text;
        string id = txtProductID.Text;
        lblQuantity.Text = "";
        int currentQuan = product.getItemQuantity(id);
        if (Request.QueryString["id"] != null)
        {

            if (currentQuan == 0)
                lblQuantity.Text = "No items available order new STOCK";
            else
                if (Convert.ToInt32(quantity) > currentQuan)
                {
                    quantity = currentQuan.ToString();
                    lblQuantity.Text = "There are only " + currentQuan + " items left";
                    addToGridView(productID, quantity);
                }
                else
                    insertUpdateItem(productID, quantity);
        }
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {

    }
    protected void txtProductID_TextChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(txtProductID.Text);
        prodResult = product.getProduct(id);
        if (prodResult == null)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Product ID does not ');", true);
            txtProductID.Text = string.Empty;
        }
        else if (prodResult.productStatus == false)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Product is no longer active ');", true);
            txtProductID.Text = string.Empty;
        }
    }

    private void ExceptionRedirect(Exception ex)
    {
        Response.Redirect("ErrorPage.aspx?ErrorMessage=" + ex.Message.Replace('\n', ' '), false);
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        lblQuantity.Text = "";
        row = GridView1.SelectedRow;
        string productID = GridView1.Rows[e.RowIndex].Cells[3].Text;
        string orderlineID = GridView1.Rows[e.RowIndex].Cells[2].Text;
        try
        {
            order.removeItem(productID, orderlineID);
        }
        catch (Exception ex)
        {
            ExceptionRedirect(ex);
        }
    }

    private void addToGridView(string productID, string quantity)
    {
        string orderID;
        try
        {
            orderID = (Request.QueryString["id"].ToString().Trim());
            order.updateInsertOrder(orderID, txtProductID.Text.ToString(), txtQuantiy.Text.ToString());
            GridView1.DataBind();
            product.itemBought(productID, quantity, "+");
        }
        catch (Exception ex)
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
            Response.Redirect("LoginPage.aspx");
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        lblUser.Text = userDto.username;
    }
    protected void txtProductID_Disposed(object sender, EventArgs e)
    {

    }

    private void insertUpdateItem(string productID, string quantity)
    {
        bool exist = false;
        DataTable rowCount = order.getAllOrders(Request.QueryString["id"].ToString());
        foreach (GridViewRow row in GridView1.Rows)
        {
            for (int i = 0; i < rowCount.Rows.Count; i++)
            {
                if (productID.Equals(GridView1.Rows[i].Cells[3].Text))
                    exist = true;
                if (exist == true)
                {
                    update(i);
                    break;
                }
            }
            if (exist == false)
                addToGridView(productID, quantity);
            break;
        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    private void update(int rowIndex)
    {
        GridViewRow row = GridView1.Rows[rowIndex];
        List<string> itemDetails = new List<string>();
        int oldQty = Convert.ToInt32(GridView1.Rows[rowIndex].Cells[5].Text);
        string newQty = (oldQty + Convert.ToInt32(txtQuantiy.Text)).ToString();

        itemDetails.Add(GridView1.Rows[rowIndex].Cells[2].Text); //product id
        itemDetails.Add(newQty); // qty
        order.updateQty(itemDetails);

        GridView1.DataBind();
    }


    private void loadOrders()
    {
        if (Request.QueryString["id"].ToString() != null)
        {
            string id = Request.QueryString["id"].ToString();
            GridView1.DataSource = order.getAllOrders(id);
            GridView1.DataBind();
        }
    }
}