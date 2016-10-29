using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_Orders : System.Web.UI.Page
{
    private UserDTO userDto = new UserDTO();
    private UserDTO userDtoUpdate = new UserDTO();
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.AutoGenerateSelectButton = true;
        string month = DateTime.Now.ToString().Substring(5,2);
        //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + month.Substring(5,2) + "');", true);
        if(DropDownList1.Items.FindByValue(month)!=null)
        {
            DropDownList1.SelectedValue = month;
        }
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("LoginPage.aspx");

        if (!Page.IsPostBack)
        {
            string currentYear = DateTime.Now.Year.ToString();
            TextBox1.Text = currentYear;
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Response.Redirect("LoginPage.aspx");
    }
   protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (GridView1.SelectedIndex >= 0)
        {
            GridViewRow row = GridView1.SelectedRow;
            string id = row.Cells[1].Text;
            Response.Redirect("UpdateOrder.aspx?Id=" + id, false);
        }
    }
    protected void btnViewOrder_Click(object sender, EventArgs e)
    {
        if (GridView1.SelectedIndex >= 0)
        {
            GridViewRow row = GridView1.SelectedRow;
            string id = row.Cells[1].Text;
            DataTable orderTable = new DataTable();
            OrdersDAO order = new OrdersDAO();
            order.getOrdersDetails(orderTable,Convert.ToInt32(id));
            GridView2.DataSource = orderTable;
            GridView2.DataBind();
        }
    }
}