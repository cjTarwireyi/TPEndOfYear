using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BusineesLogic.Interface
{
    public interface IProduct
    {
        void updateQuantity(int prodId, int qty);
        void updateProductStatus(string id, bool state);
    }
}
