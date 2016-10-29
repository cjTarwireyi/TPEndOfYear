using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_ErrorPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ErrorMessage"] != null)
            lblErrorDetails.Text = Request.QueryString["ErrorMessage"].Trim();
    }
}