using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Orders
/// </summary>
public class Orders: InterfaceOder
{
	public Orders()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool AddOrder(OrderDTO model)
    {
        return true;
    }
    bool UpdateOrder(OrderDTO model)
    {
        return true
    }
    bool DeleteOrder(int orderId)
    {
        return true;
    }
}