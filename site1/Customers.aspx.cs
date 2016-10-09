using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_customer_Customers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // GridView1.Columns[1].Visible = false;
    }
    protected void Register_Click(object sender, EventArgs e)
    {
       
        Response.Redirect("AddCustomer.aspx");
    }

}