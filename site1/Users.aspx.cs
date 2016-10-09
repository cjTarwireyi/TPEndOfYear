using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void InactiveRecords(object sender, EventArgs e)
    {

    }
    protected void Register_Click(object sender, EventArgs e)
    {
        UserDTO userDto = new UserDTO();

        if(GridView1.SelectedIndex>-1){
            GridViewRow row = GridView1.SelectedRow;
            userDto.Id = Convert.ToInt32(row.Cells[1].Text);
            userDto.name = row.Cells[2].Text;
            userDto.password = row.Cells[3].Text;


        }

        

    }
}