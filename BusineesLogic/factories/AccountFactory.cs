using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.domain;


namespace BusineesLogic.factories
{
    public class AccountFactory
    {
        public static AccountDTO createAccount(CustomerDTO customer)
        {
            return new AccountDTO.AccountBuilder()
                                .buildCustomer(customer)
                                .build();
        }
    }
}
