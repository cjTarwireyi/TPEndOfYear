using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_Purchase : System.Web.UI.Page
{
    DataTable table;

    protected void Page_Load(object sender, EventArgs e)
    {
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
        DataRow dr = table.NewRow();
        dr["ProductCode"] = txtProductID.Text;
        table.Rows.Add(dr);
    }

    private void BindGrid()
    {
        GridView1.DataSource = table;
        GridView1.DataBind();
    }

    protected void txtProductID_TextChanged(object sender, EventArgs e)
    {
        /*AddToDataTable();
        BindGrid();*/
    }
}