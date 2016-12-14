using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_productAnalysis : System.Web.UI.Page
{
    private UserDTO userDto;
    private UserDTO userDtoUpdate;
    private ProductDAO accessProduct = new ProductDAO();
    private DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        session();
    }


    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();

        Response.Redirect("Default.aspx");
    }
    protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlReportType.SelectedValue == "")
        {
            GridView1.DataSource = "";
            GridView1.DataBind();
        }
        else
        {
            txtSearchYear.Visible = false;
            btnSubmit.Visible = false;
            int value = Convert.ToInt32(ddlReportType.SelectedValue);
            loadGrid(value, DateTime.Now.Year.ToString());
        }

    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        if (lblInvalid.Visible != true)
        {
            if (ddlReportType.SelectedValue != "")
            {
                int index = Convert.ToInt32(ddlReportType.SelectedValue);
                if (index == 0)
                    print("PRODUCT SALES REPORT");
                else
                    if (index == 1)
                        print("MOST RETURNED PRODUCTS REPORT");
                    else
                        if (index == 2)
                            print("OUTSTANDING INCOME REPORT ");

                        else
                            if (index == 3)
                                print("YEAR REVENUE MADE FROM REPORT");
                            else
                                if (index == 4)
                                    print("TOP BUYING CUSTOMERS REPORT");
                                else
                                    if (index == 5)
                                        print("TOTAL ORDRES NOT PAID BY CUSTOMERS");
            }
        }

    }

    private void print(string reportType)
    {
        try
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename='" + reportType + "'.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter swr = new StringWriter();
            HtmlTextWriter htmlwr = new HtmlTextWriter(swr);
            GridView1.AllowPaging = false;
            loadGrid(Convert.ToInt32(ddlReportType.SelectedValue), DateTime.Now.Year.ToString());
            GridView1.RenderControl(htmlwr);
            StringReader srr = new StringReader(swr.ToString());
            Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfdoc);
            PdfWriter.GetInstance(pdfdoc, Response.OutputStream);
            Font heading = FontFactory.GetFont("Arial", 26, Font.BOLD, BaseColor.BLACK);
            Font heading2 = FontFactory.GetFont("Arial", 15, Font.NORMAL, BaseColor.BLACK);
            pdfdoc.Open();


            Paragraph p;
            string filename = HttpContext.Current.Server.MapPath("../site1/images/asp pics/white.png");
            System.IO.Stream ImageStream = new System.IO.FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(ImageStream);
            gif.Alignment = iTextSharp.text.Image.LEFT_ALIGN;
            gif.ScalePercent(40f);
            pdfdoc.Add(gif);



            p = new Paragraph(reportType, heading);
            p.Alignment = Element.ALIGN_CENTER;
            pdfdoc.Add(p);

            p = new Paragraph(DateTime.Now.ToShortDateString() + "\n\n", heading2);
            p.Alignment = Element.ALIGN_CENTER;
            pdfdoc.Add(p);


            htmlparser.Parse(srr);

            pdfdoc.Close();
            Response.Write(pdfdoc);
            Response.End();
        }
        catch (ThreadAbortException ex)
        {
            //ExceptionRedirect(ex);
        }
    }

    private void loadGrid(int index, string year)
    {
        lblInvalid.Visible = false;
        if (index == 0)
            GridView1.DataSource = accessProduct.mostSoldProducts();
        else
            if (index == 1)
                GridView1.DataSource = accessProduct.mostReturnedProducts();
            else
                if (index == 2)
                {
                    dt = accessProduct.monthlyAmount(year, true);
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = accessProduct.monthlyAmount(year, true);
                        txtSearchYear.Visible = true;
                        btnSubmit.Visible = true;
                    }
                    else
                        lblInvalid.Visible = true;

                }
                else
                    if (index == 3)
                    {
                        dt = accessProduct.monthlyAmount(year, false);
                        if (dt.Rows.Count > 0)
                        {
                            GridView1.DataSource = accessProduct.monthlyAmount(year, false);
                            txtSearchYear.Visible = true;
                            btnSubmit.Visible = true;
                        }
                        else
                        lblInvalid.Visible = true;
                    }
                    else
                        if (index == 4)
                        {
                            dt = accessProduct.generateCustomersOrderHistory(true);
                            if (dt.Rows.Count > 0)
                                GridView1.DataSource = accessProduct.generateCustomersOrderHistory(true);
                            else
                                lblInvalid.Visible = true;
                        }
                        else
                            if (index == 5)
                            {
                                dt = accessProduct.generateCustomersOrderHistory(false);
                                if (dt.Rows.Count > 0)
                                    GridView1.DataSource = accessProduct.generateCustomersOrderHistory(false);
                                else
                                    lblInvalid.Visible = true;
                            }
        GridView1.DataBind();
    }

    private void ExceptionRedirect(Exception ex)
    {
        Response.Redirect("ErrorPage.aspx?ErrorMessage=" + ex.Message.Replace('\n', ' '), false);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int value = Convert.ToInt32(ddlReportType.SelectedValue);
        loadGrid(value, txtSearchYear.Text);
    }

    private void session()
    {
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("Default.aspx");
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        lblUser.Text = userDto.username;

        if (userDto.userTypeName.Trim() != "Admin")
        {
            AdminLinkPanel.Visible = false;
            Response.Redirect("Home.aspx");
        }
        else
            userPanel.Visible = false;
        // AdminLinkPanel.Visible = false;
    }
}