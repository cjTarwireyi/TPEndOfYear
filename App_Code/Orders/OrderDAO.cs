using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderDAO
/// </summary>
public class OrderDAO :InterfaceOder
{
    DataClassesDataContext db = new DataClassesDataContext();
	public OrderDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public  int AddOrder(OrderDTO model)
    {
        try
        {
            Oder1 order = new Oder1();
            var time = DateTime.Now;
            var orderCode = model.customerId + "-" + time;
            order.custId = model.customerId;
            order.employeeId = model.employeeId;
          //  order.amount = model.amount;
            order.payed = model.payed;
            order.orderDate = time;
            order.orderCode = orderCode;
            db.Oder1s.InsertOnSubmit(order);
            Oder1 orderfound = db.Oder1s.Where(t => t.orderCode == orderCode).Single();
            return orderfound.orderId;
        }
       catch(Exception e) {
            e.GetBaseException();
            return new Int32();
            
        }
    }

    public bool UpdateOrder(OrderDTO model)
    {
        throw new NotImplementedException();
    }

    public bool DeleteOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    
}