using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_Suppliers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserDTO userDtoUpdate = new UserDTO();
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
    }
    protected void Register_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddSupplier.aspx");
    }
}