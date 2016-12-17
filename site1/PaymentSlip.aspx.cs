using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using  iTextSharp.text.pdf;
using BusineesLogic.domain;




public partial class site1_PaymentSlip : System.Web.UI.Page
{
    private UserDTO userDto;
    private UserDTO userDtoUpdate;
    protected void Page_Load(object sender, EventArgs e)
    {
        session();
        print();
    }


    private void session()
    {
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("Default.aspx");
       
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
                Rectangle two = new Rectangle(600,700);
                Document doc = new Document();
                PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);

                doc.SetPageSize(two);
                doc.Open();
                
                string filename = HttpContext.Current.Server.MapPath("~/site1/images/asp pics/white.png");
                string signature = HttpContext.Current.Server.MapPath("~/site1/images/signCottle.png");
                System.IO.Stream ImageStream = new System.IO.FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                
                iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(ImageStream);
                gif.Alignment = iTextSharp.text.Image.MIDDLE_ALIGN;
                gif.ScalePercent(50f);
                doc.Add(gif);

                Font heading = FontFactory.GetFont("Arial", 26, Font.BOLD, BaseColor.BLACK);
                Font heading2 = FontFactory.GetFont("Arial", 15, Font.BOLD, BaseColor.BLACK);
                Font heading3 = FontFactory.GetFont("Arial", 13, BaseColor.BLACK);
                Font font = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK);
                Font arialB = FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK);
                Font unserline = FontFactory.GetFont("Arial", 10, Font.BOLD | Font.ITALIC);
                Font heading2underline = FontFactory.GetFont("Arial", 15, Font.NORMAL + Font.UNDERLINE + Font.BOLD, BaseColor.BLACK);
                Paragraph p = new Paragraph("\n");


                

                //Heading
                p = new Paragraph("Customer Details\n\n", heading);
                p.Alignment = Element.ALIGN_CENTER;
                doc.Add(p);


                //Address
                p = new Paragraph("Address\n", heading2underline);
                p.Alignment = Element.ALIGN_LEFT;
                doc.Add(p);
                p = new Paragraph(customer.StreetName + "\n" + customer.Suburb + "\n" + customer.postalCode + "\n", heading2);
                p.Alignment = Element.ALIGN_LEFT;
                doc.Add(p);

                //Customer Details
                p = new Paragraph("\nCustomer NO: " + customer.customerNumber + "\nCustomer Name: " + customer.name + "\nCustomer Surname:" + customer.surname + "\nCell Number: " + customer.cellNumber + "\nEmail Address: " + customer.email + "\n\n", heading2);
                p.Alignment = Element.ALIGN_LEFT;
                doc.Add(p);


                //Adding signature
                ImageStream = new System.IO.FileStream(signature, FileMode.Open, FileAccess.Read, FileShare.Read);
                iTextSharp.text.Image sign = iTextSharp.text.Image.GetInstance(ImageStream);
                sign.Alignment = iTextSharp.text.Image.RIGHT_ALIGN;
                sign.ScalePercent(50f);
                doc.Add(sign);
                p = new Paragraph("Company Manger", heading3);
                p.Add(new Chunk("\nNawaal Cottle",heading3));
                p.Alignment = Element.ALIGN_RIGHT;
                doc.Add(p);

                //Account Created 
                p = new Paragraph("\n\nAccount created on:\n" + customer.dateCreated , heading2);
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
            ExceptionRedirect(ex);
        }
    }
    private void ExceptionRedirect(Exception ex)
    {
        Response.Redirect("ErrorPage.aspx?ErrorMessage=" + ex.Message.Replace('\n', ' '), false);
    }

}