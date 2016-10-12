using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_Products : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Register_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddProduct.aspx");
    }
    protected void InactiveRecords(object sender, EventArgs e)
    {
        Response.Redirect("InactiveProducts.aspx");
    }

    protected void btnDeactivate_Click(object sender, EventArgs e)
    {
        if (GridView1.SelectedIndex >= 0)
        {
            GridViewRow row = GridView1.SelectedRow;
            string id = row.Cells[1].Text;
            ProductDAO prodConnnection = new ProductDAO();
            SqlConnection con = prodConnnection.connection();
            con.Open();
            String activeProduct = "update Products set Active ='False' where Id ='" + Convert.ToInt32(id) + "'";
            SqlCommand cmd = new SqlCommand(activeProduct, con);
            cmd.ExecuteNonQuery();
            GridView1.DataBind();

            //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('"+id+"');", true);
        }
    }
}
   