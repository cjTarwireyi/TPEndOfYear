﻿using System;
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
    public DateTime orderDate { set; get; }
    public bool paid { set; get; }
    public float amount { set; get; }

     }