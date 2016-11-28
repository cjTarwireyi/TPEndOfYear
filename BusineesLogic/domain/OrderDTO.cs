using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderDTO
/// </summary>
public class OrderDTO
{
    //methods
    public OrderDTO()
    {

    }
    public OrderDTO(OrderBuilder orderBuilder)
    {
        this.orderId = orderBuilder.orderId;
        this.customerId = orderBuilder.custId;
        this.employeeId = orderBuilder.employeeId;
        this.productId = orderBuilder.productId;
        this.orderDate = orderBuilder.orderDate;
        this.payed = orderBuilder.payed;
        this.amount = orderBuilder.amount;
        this.orderItems = orderBuilder.orderItems;
    }
    public int orderId { set; get; }
    public int customerId { set; get; }
    public int employeeId { set; get; }
    public int productId { set; get; }
    public DateTime orderDate { set; get; }
    public bool payed { set; get; }
    public decimal amount { set; get; }
    public List<Products> orderItems { set; get; }

    public class OrderBuilder
    {
        public int orderId;
        public int custId;
        public int employeeId;
        public int productId;
        public DateTime orderDate;
        public bool payed;
        public decimal amount;
        public List<Products> orderItems;

        public OrderBuilder buildorderId(int orderId)
        {
            this.orderId = orderId;
            return this;
        }
        public OrderBuilder buildCustId(int custId)
        {
            this.custId = custId;
            return this;
        }
        public OrderBuilder buildEmpId(int employeeId)
        {
            this.employeeId = employeeId;
            return this;
        }
        public OrderBuilder buildProdId(int productId)
        {
            this.productId = productId;
            return this;
        }
        public OrderBuilder buildOrderDate(DateTime orderDate)
        {
            this.orderDate = orderDate;
            return this;
        }
        public OrderBuilder buildPayed(bool payed)
        {
            this.payed = payed;
            return this;
        }
        public OrderBuilder buildAmount(Decimal amount)
        {
            this.amount = amount;
            return this;
        }
        public OrderBuilder buildProducts(List<Products> orderItems)
        {
            this.orderItems = orderItems;
            return this;
        }

        public OrderBuilder copy(OrderDTO order)
        {
            this.custId = order.customerId;
            this.productId = order.productId;
            this.employeeId = order.employeeId;
            this.orderDate = order.orderDate;
            this.payed = order.payed;
            this.amount = order.amount;
            this.orderItems = order.orderItems;
            return this;

        }
        public OrderDTO build()
        {
            return new OrderDTO(this);
        }
    }

 }
