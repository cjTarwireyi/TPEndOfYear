using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using iTextSharp.text;
using iTextSharp.text.pdf;


public partial class site1_PaymentSlip : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        print();
    }


    private void print()
    {
        try
        {
            if (Request.QueryString["id"] != null)
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('I am here');", true);
                int Id = 0;
                Id = Convert.ToInt32(Request.QueryString["id"].ToString().Trim());
                CustomerDAO accessCustomer = new CustomerDAO();
                CustomerDTO customer = new CustomerDTO();
                customer = accessCustomer.getCustomerID(Id);

                Response.Buffer = true;
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "Application/pdf";
                MemoryStream memoryStream = new MemoryStream();
                Document doc = new Document();
                PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);


                doc.Open();

                string filename = HttpContext.Current.Server.MapPath("../site1/images/images.png");
                System.IO.Stream ImageStream = new System.IO.FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(ImageStream);
                gif.Alignment = iTextSharp.text.Image.MIDDLE_ALIGN;
                gif.ScalePercent(50f);
                doc.Add(gif);

                Font heading = FontFactory.GetFont("Arial", 26, Font.BOLD, BaseColor.BLACK);
                Font heading2 = FontFactory.GetFont("Arial", 15, Font.BOLD, BaseColor.BLACK);
                Font font = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK);
                Font arialB = FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK);
                Font unserline = FontFactory.GetFont("Arial", 10, Font.BOLD | Font.ITALIC);
                Paragraph p = new Paragraph("\n");


                p = new Paragraph("Customer Details\n\n\n", heading);
                p.Alignment = Element.ALIGN_CENTER;
                doc.Add(p);



                p = new Paragraph("Customer Name: " + customer.name + "\nCustomer Surname:" + customer.surname + "\nCell Number: " + customer.cellNumber + "\nEmail Address: " + customer.email + "\nAddress\n" + customer.StreetName + "\n" + customer.Suburb + "\n" + customer.postalCode, heading2);
                p.Alignment = Element.ALIGN_LEFT;
                doc.Add(p);

                p = new Paragraph("\n\nAccount created on:" + customer.dateAccountCreated, heading2);
                p.Alignment = Element.ALIGN_CENTER;
                doc.Add(p);


                doc.Close();
                byte[] content = memoryStream.ToArray();

                Response.Buffer = true;
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "Application/pdf";
                Response.AddHeader("Content-Type", "application/pdf");
                Response.OutputStream.Write(memoryStream.GetBuffer(), 0, memoryStream.GetBuffer().Length);
                Response.OutputStream.Flush();

            }
        }
        catch (Exception ex)
        {
            Response.Write("Error: " + ex.ToString());
        }
    }
}