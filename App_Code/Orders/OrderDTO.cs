using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderDTO
/// </summary>
public class OrderDTO
{
    public int orderId { set; get; }
    public int customerId { set; get; }
    public int employeeId { set; get; }
    public int productId { set; get; }
    public DateTime orderDate { set; get; }
    public bool payed { set; get; }
    public decimal amount { set; get; }
    public List<Products> orderItems { set; get; }

 }
