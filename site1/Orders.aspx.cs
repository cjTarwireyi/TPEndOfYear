﻿using System;
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
    private OrdersDAO order = new OrdersDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.AutoGenerateSelectButton = true;
        string month = DateTime.Now.ToString().Substring(5,2);
        string currentYear = DateTime.Now.Year.ToString();
        //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + month.Substring(5,2) + "');", true);
        if (!Page.IsPostBack)
        {
            if (DropDownList1.Items.FindByValue(month) != null)
            {
                DropDownList1.SelectedValue = month;
                txtYear.Text = currentYear;
            }
            GridView1.DataSource = order.populateGrid(month, currentYear,false);
            GridView1.DataBind();
        }
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("LoginPage.aspx");
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
            
            order.getOrdersDetails(orderTable,Convert.ToInt32(id));
            GridView2.DataSource = orderTable;
            GridView2.DataBind();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
       
    }

    protected void dgrvData_Filter(object sender, EventArgs e)
    {
        string date = txtYear.Text + DropDownList1.SelectedValue;
        string searchID = txtSearch.Text;
        string month = DropDownList1.SelectedValue;
        string currentYear = txtYear.Text;
        
        DataTable searchedOrder = new DataTable();
        bool payed;
        if (RadioButton1.Checked == true)
            payed = true;
        else
            payed = false;

        if (txtSearch.Text.ToString().Trim().Length == 0)
        {
            populateGrid();
        }
        else
        {
            order.searchOrder(searchedOrder, searchID,payed);
            GridView1.DataSource = searchedOrder;
            GridView1.DataBind();
           
        }
    }
    protected void DropDownList1_TextChanged(object sender, EventArgs e)
    {
        populateGrid();
    }

    private void populateGrid()
    {
        bool payed;
        if (RadioButton1.Checked == true)
            payed = true;
        else
            payed = false;
        string month = DropDownList1.SelectedValue;
        string cureentYear = txtYear.Text;
        GridView1.DataSource = order.populateGrid(month, cureentYear, payed);
        GridView1.DataBind();
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
}