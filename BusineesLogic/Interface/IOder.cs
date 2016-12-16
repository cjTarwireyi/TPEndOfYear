using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InterfaceOder
/// </summary>
public interface IOder
{
      int AddOrder(OrderDTO model);
      bool UpdateOrder(OrderDTO model);
      bool deleteOrder(int orderId);
      OrderDTO getLastReocrd();
      OrderDTO getOrderByID(int id);
       
} 