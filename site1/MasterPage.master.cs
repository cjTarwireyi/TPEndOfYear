﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*lblTime.Text = DateTime.Now.ToLongTimeString();

        if (!this.IsPostBack) {
            ModalPopupExtender1.Show();
        }*/
    }
    protected void LogoutMethod(object sender, EventArgs e)
    {
        Session.Abandon();
    }
}
