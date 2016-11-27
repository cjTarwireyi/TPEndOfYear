using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.factories;

namespace BusineesLogic.factories
{
    public class OrderFactory
    {

        public static OrderDTO createOrder(int empId, int custId, Decimal amount, bool payed, List<Products> products)
        {
            return new OrderDTO.OrderBuilder()
            .buildEmpId(empId)
            .buildAmount(amount)
            .buildPayed(payed)
            .buildProducts(products)
            .build();

        }
    }
}

