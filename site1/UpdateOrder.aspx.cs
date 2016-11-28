using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class site1_UpdateOrder : System.Web.UI.Page
{
    private OrderLineDAO order = new OrderLineDAO();
    private ProductDAO product = new ProductDAO();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Orders.aspx");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string orderID;
        string productID = txtProductID.Text;
        string quantity = txtQuantiy.Text;
        string id = txtProductID.Text;
        lblQuantity.Text = "";
        int currentQuan = product.getItemQuantity(id);
        try
        {
            if (Request.QueryString["id"] != null)
            {
                if (currentQuan == 0)
                {
                    lblQuantity.Text = "No items available order new STOCK";
                }
                else
                    if (Convert.ToInt32(quantity) > currentQuan)
                    {
                        quantity = currentQuan.ToString();
                        lblQuantity.Text = "There are only " + currentQuan + " items left";
                        addToGridView(productID, quantity);
                    }

                    else
                    {
                        addToGridView(productID, quantity);
                    }
            }
        }
        catch (Exception ex) { ExceptionRedirect(ex); }
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {

    }
    protected void txtProductID_TextChanged(object sender, EventArgs e)
    {

    }

    private void ExceptionRedirect(Exception ex)
    {
        Response.Redirect(@"../Webpages/ErrorPage.aspx?ErrorMessage=" + ex.Message.Replace('\n', ' '), false);
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (GridView1.SelectedIndex >= 0)
        {
            lblQuantity.Text = "";
            GridViewRow row = GridView1.SelectedRow;
            string productID = row.Cells[3].Text;
            string orderlineID = row.Cells[2].Text;
            order.removeItem(productID, orderlineID);
        }
    }

    private void addToGridView(string productID, string quantity)
    {
        string orderID;
        orderID = (Request.QueryString["id"].ToString().Trim());
        order.updateInsertOrder(orderID, txtProductID.Text.ToString(), txtQuantiy.Text.ToString());
        GridView1.DataBind();
        product.itemBought(productID, quantity ,"+");
    }
}