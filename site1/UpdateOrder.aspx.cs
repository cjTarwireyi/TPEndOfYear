using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class site1_UpdateOrder : System.Web.UI.Page
{
    private OrderLineDAO order = new OrderLineDAO ();
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
        try
        {
            if (Request.QueryString["id"] != null)
            {
                orderID = (Request.QueryString["id"].ToString().Trim());
                order.updateInsertOrder(orderID, txtProductID.Text.ToString(), txtQuantiy.Text.ToString());
                GridView1.DataBind();
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
}