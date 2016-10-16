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
        UserDTO userDtoUpdate = new UserDTO();
        

 
        UserDTO userDto= new UserDTO();
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("LoginPage.aspx");
        
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        lblUser.Text = userDto.username;
       

        
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
        if (gridView1.SelectedIndex >= 0)
        {
            GridViewRow row = gridView1.SelectedRow;
            string id = row.Cells[1].Text;
            ProductDAO prodConnnection = new ProductDAO();
            SqlConnection con = prodConnnection.connection();
            con.Open();
            String activeProduct = "update Products set Active ='False' where Id ='" + Convert.ToInt32(id) + "'";
            SqlCommand cmd = new SqlCommand(activeProduct, con);
            cmd.ExecuteNonQuery();
            gridView1.DataBind();
            
            //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('"+id+"');", true);
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {

        Session.Abandon();
        Session.Clear();

        Response.Redirect("LoginPage.aspx");
    } 
    //protected void InactiveRecords(object sender, EventArgs e)
    //{

    //}
}