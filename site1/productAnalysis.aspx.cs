using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_productAnalysis : System.Web.UI.Page
{
    private UserDTO userDto;
    private UserDTO userDtoUpdate;
    private ProductDAO accessProduct = new ProductDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }


    public override void VerifyRenderingInServerForm(Control control)
    {
         
    }
   
    protected void Submit_Click(object sender, EventArgs e)
    {

    }
    protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadGrid();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        print("PRODUCT SALES");

    }

    private void print(string reportType)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter swr = new StringWriter();
        HtmlTextWriter htmlwr = new HtmlTextWriter(swr);
        GridView1.AllowPaging = false;
        loadGrid();
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

        p = new Paragraph(DateTime.Now.ToShortDateString()+"\n\n",heading2);
        p.Alignment = Element.ALIGN_CENTER;
        pdfdoc.Add(p);


        htmlparser.Parse(srr);

        pdfdoc.Close();
        Response.Write(pdfdoc);
        Response.End();
    }

    private void loadGrid()
    {
        GridView1.DataSource = accessProduct.mostSoldProducts();
        GridView1.DataBind();
    }

    private void ExceptionRedirect(Exception ex)
    {
        Response.Redirect("ErrorPage.aspx?ErrorMessage=" + ex.Message.Replace('\n', ' '), false);
    }
}