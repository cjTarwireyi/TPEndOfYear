using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_Suppliers : System.Web.UI.Page
{
    private UserDTO userDto = new UserDTO();
    private UserDTO userDtoUpdate = new UserDTO();
    private SupplierDAO supplier = new SupplierDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        loadSession();
        loadSupplies();
    }
    protected void Register_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddSupplier.aspx");
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Response.Redirect("LoginPage.aspx");
    } 
    private void loadSession(){
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("LoginPage.aspx");
        lblUser.Text = userDto.username;
    }

    private void loadSupplies()
    {
        GridView1.DataSource = supplier.populateGrid();
        GridView1.DataBind();
    }

}