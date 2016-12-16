using iTextSharp.text;

using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site1_Receipt : System.Web.UI.Page
{
    private UserDTO userDto;
    private UserDTO userDtoUpdate;
    private ProductDAO accessProduct = new ProductDAO();
    private Products product;
    private CustomerDTO customer;
    private CustomerDAO accessCustomer = new CustomerDAO();
    private OrderLineDAO accesssOrderLine = new OrderLineDAO();
    private OrderLineDTO orderline;
    private OrderDTO order;
    private OrdersDAO accessOrder = new OrdersDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        session();
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
                Response.Buffer = true;
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "Application/pdf";
                MemoryStream memoryStream = new MemoryStream();
                Document doc = new Document();
                PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
                


                doc.Open();
                string filename = HttpContext.Current.Server.MapPath("~/site1/images/asp pics/white.png");
                System.IO.Stream ImageStream = new System.IO.FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(ImageStream);
                gif.Alignment = iTextSharp.text.Image.MIDDLE_ALIGN;
                gif.ScalePercent(50f);
                doc.Add(gif);

                Font Uderlineheading = FontFactory.GetFont("Arial", 26, Font.BOLD + Font.UNDERLINE, BaseColor.BLACK);
                Font Uderlineheading2 = FontFactory.GetFont("Arial", 18, Font.BOLD + Font.UNDERLINE, BaseColor.BLACK);
                Font heading = FontFactory.GetFont("Arial", 26, Font.BOLD, BaseColor.BLACK);
                Font heading2 = FontFactory.GetFont("Arial", 15, Font.BOLD, BaseColor.BLACK);
                Font heading3 = FontFactory.GetFont("Arial", 13, Font.NORMAL, BaseColor.BLACK);
                Font heading3underline = FontFactory.GetFont("Arial", 13, Font.NORMAL + Font.UNDERLINE, BaseColor.BLACK);
                Font font = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK);
                Font arialB = FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK);
                Font unserline = FontFactory.GetFont("Arial", 10, Font.BOLD | Font.ITALIC);

                Paragraph p = new Paragraph();

                //Heading
                p = new Paragraph("Order Receipt", Uderlineheading);
                p.Alignment = Element.ALIGN_CENTER;
                doc.Add(p);

                //Customer
                order = accessOrder.getOrderByID(Id);
                customer = accessCustomer.getCustomerID(order.customerId);
                p = new Paragraph("\n\n", heading3);
                doc.Add(p);
                p = new Paragraph("Customer Details:", Uderlineheading2);
                p.Alignment = Element.ALIGN_LEFT;
                doc.Add(p);

                p = new Paragraph(null, heading3);
                p.Add("Account Number: " + customer.customerNumber);
                p.Add("\nCustomer Name: " + customer.name);
                p.Add("\nCustomer Surname: " + customer.surname + "\n\n");
                p.Alignment = Element.ALIGN_LEFT;
                doc.Add(p);


                //Items
                p = new Paragraph("Items Purchased", heading3underline);
                p.Alignment = Element.ALIGN_CENTER;
                doc.Add(p);

                p = new Paragraph("\n", heading3);
                p.Alignment = Element.ALIGN_CENTER;
                List<OrderLineDTO> items = accesssOrderLine.getOrderItems(Id);
                p.Add("Product Name" + "                          " + "Price" + "         " + "Quantity" + "\n");
                for (int i = 0; i < items.Count; i++)
                {
                    orderline = (OrderLineDTO)items[i];
                    product = accessProduct.getProduct(orderline.productID);
                    p.Add(product.productName + "         " + product.price + "            " + product.productQuantity + "\n");
                    // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + order.productID+ "');", true);
                }
                p.Add("\n\n\n\n");
                doc.Add(p);

                //totals
                p = new Paragraph("Totals", Uderlineheading2);
                p.Alignment = Element.ALIGN_LEFT;
                doc.Add(p);
                p = new Paragraph(null, heading3);
                p.Add("Total Amount Due: R" + order.amount);
                p.Alignment = Element.ALIGN_LEFT;
                doc.Add(p);

                p = new Paragraph("\n\nDate:\n" + order.orderDate, heading2);
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

    private void session()
    {
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
        userDto = (UserDTO)Session["userDto"];
        if (userDto == null)
            Response.Redirect("Default.aspx");
        userDtoUpdate = (UserDTO)Session["userUpdate"];
        Session.Remove("userUpdate");
    }

    private void ExceptionRedirect(Exception ex)
    {
        Response.Redirect("ErrorPage.aspx?ErrorMessage=" + ex.Message.Replace('\n', ' '), false);
    }

}