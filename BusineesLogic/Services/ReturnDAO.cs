using BusineesLogic.domain;
using BusineesLogic.repositories.Impl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.services
{

    public class ReturnDAO
    {
        private ReturnRepositoryImpl repo = new ReturnRepositoryImpl();
        
        public ReturnDAO()
        {
        }

        public DataTable searchOrder(string orderNumber,string customerNumber)
        {
            return repo.searchOrder(orderNumber,customerNumber);
        }

        public void save(ReturnDTO returns)
        {
            repo.save(returns);
        }
    }
}
