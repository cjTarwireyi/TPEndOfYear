using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_Orders : System.Web.UI.Page
{
    private UserDTO userDto;
    private UserDTO userDtoUpdate;
    private OrdersDAO order = new OrdersDAO();
    private OrderDTO result;
    private GridViewRow row;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnPay.Attributes["data-toggle"] = "modal";
        btnPay.Attributes["data-target"] = "#myPaymentModal";
        GridView1.AutoGenerateSelectButton = true;
        session();
        if (!Page.IsPostBack)
            generateCurrentDate();
        populateGrid();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        populateGrid();
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        populateGrid();
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Response.Redirect("Default.aspx");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (GridView1.SelectedIndex >= 0)
        {
            row = GridView1.SelectedRow;
            string id = row.Cells[1].Text;
            string customerID = row.Cells[2].Text;
            Response.Redirect(String.Format("UpdateOrder.aspx?Id={0}&identityCode={1}",id,customerID), false);
        }
    }
    protected void btnViewOrder_Click(object sender, EventArgs e)
    {
        if (GridView1.SelectedIndex >= 0)
        {
            row = GridView1.SelectedRow;
            string id = row.Cells[1].Text;
            DataTable orderTable = new DataTable();
            try
            {
                order.getOrdersDetails(orderTable, Convert.ToInt32(id));
                GridView2.DataSource = orderTable;
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionRedirect(ex);
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }

    protected void dgrvData_Filter(object sender, EventArgs e)
    {
        DataTable searchedOrder = new DataTable();
        string date = txtYear.Text + DropDownList1.SelectedValue;
        string searchID = txtSearch.Text;
        string month = DropDownList1.SelectedValue;
        string currentYear = txtYear.Text;
        bool payed;

        if (RadioButton1.Checked == true)
            payed = true;
        else
            payed = false;

        if (txtSearch.Text.ToString().Trim().Length == 0)
            populateGrid();
        else
        {
            try
            {
                order.searchOrder(searchedOrder, searchID, payed);
                GridView1.DataSource = searchedOrder;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionRedirect(ex);
            }
        }
    }

    protected void DropDownList1_TextChanged(object sender, EventArgs e)
    {
        populateGrid();
    }

    private void populateGrid()
    {
        bool payed;
        try
        {
            if (RadioButton1.Checked == true)
                payed = true;
            else
                payed = false;
            string month = DropDownList1.SelectedValue;
            string cureentYear = txtYear.Text;
            GridView1.DataSource = order.populateGrid(month, cureentYear, payed);
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            ExceptionRedirect(ex);
        }
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        populateGrid();
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        populateGrid();
    }

    protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        populateGrid();
    }

    private void ExceptionRedirect(Exception ex)
    {
        Response.Redirect("ErrorPage.aspx?ErrorMessage=" + ex.Message.Replace('\n', ' '), false);
    }

    private void generateCurrentDate()
    {
        try
        {
            string month = DateTime.Now.ToString().Substring(5, 2);
            string currentYear = DateTime.Now.Year.ToString();
            if (DropDownList1.Items.FindByValue(month) != null)
            {
                DropDownList1.SelectedValue = month;
                txtYear.Text = currentYear;
            }
            /*GridView1.DataSource = order.populateGrid(month, currentYear, false);
            GridView1.DataBind();*/
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
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("Default.aspx");
        lblUser.Text = userDto.username;

        if (userDto.userTypeName.Trim() != "Admin")
            AdminLinkPanel.Visible = false;
        else
            userPanel.Visible = false;
    }

    protected void btnPay_Click(object sender, EventArgs e)
    {
        if (GridView1.SelectedIndex >= 0)
        {
            
            
            row = GridView1.SelectedRow;
            int id = Convert.ToInt32(row.Cells[1].Text);
            result = order.getOrder(id);
            lblCustomerName.Text = result.customerId.ToString();
            lblOrderNo.Text = result.orderId.ToString();
            lblAmountDue.Text = result.amount.ToString();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!txtAmountPayed.Text.Equals(string.Empty))
        {

            int customerPaymentAmt = 0;
            customerPaymentAmt = Convert.ToInt32(txtAmountPayed.Text);
            processPayment(customerPaymentAmt, Convert.ToInt32(lblAmountDue.Text));
            Panel2.Visible = true;
        }
    }

    private void processPayment(int payedAmount, int amountDue)
    {
        int total = 0;
        if (payedAmount >= amountDue)
        {
            total = payedAmount - amountDue;
            lblResult.Text = "You Change: ";
            lblChanges.Text = total.ToString();
            //order.updateAmount(lblOrderNo.Text.ToString(),0);
            order.paid(lblOrderNo.Text.ToString());
        }
        else
            if (payedAmount < amountDue)
            {
                total = amountDue - payedAmount;
                lblResult.Text = "Money Due: ";
                lblChanges.Text = total.ToString();
                order.updateAmount(lblOrderNo.Text.ToString(), total);
            }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (GridView1.SelectedIndex >= 0)
        {
            row = GridView1.SelectedRow;
            string id = row.Cells[1].Text;
            order.cancelOrder(id);
            populateGrid();
        }
    }
}