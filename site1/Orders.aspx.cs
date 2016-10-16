using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_Orders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserDTO userDtoUpdate = new UserDTO();
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
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
}