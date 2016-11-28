using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderLineDTO
/// </summary>
public class OrderLineDTO
{
    public OrderLineDTO()
    {

    }
    public OrderLineDTO(OrderLineBuilder orderLineBuilder)
    {
        this.orderId = orderLineBuilder.orderId;
        this.orderLineID = orderLineBuilder.orderLineId;
        this.productID = orderLineBuilder.productId;
        this.quantity = orderLineBuilder.quantity;
    }
    public int orderLineID { set; get; }
    public int orderId { set; get; }
    public int productID { set; get; }
    public int quantity { set; get; }

    public class OrderLineBuilder
    {
        public int orderLineId;
        public int orderId;
        public int productId;
        public int quantity;

        public OrderLineBuilder buildOderLineId(int orderLineId)
        {
            this.orderLineId = orderLineId;
            return this;
        }
        public OrderLineBuilder buildOrderId(int orderId)
        {
            this.orderId = orderId;
            return this;

        }
        public OrderLineBuilder buildProductId(int productId)
        {
            this.productId = productId;
            return this;
        }
        public OrderLineBuilder buildQuantity(int quantity)
        {
            this.quantity = quantity;
            return this;
        }
        public OrderLineBuilder copy(OrderLineDTO orderLine)
        {
            this.orderLineId = orderLine.orderId;
            this.orderId = orderLine.orderId;
            this.productId = orderLine.productID;
            this.quantity = orderLine.quantity;
            return this;

        }
        public OrderLineDTO build()
        {
            return new OrderLineDTO(this);
        }
    }
    
     
     
}