using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.domain;

namespace BusineesLogic.factories
{
   public class TransactionFactory
    {
       public static TransactionDTO create(string code, decimal amount,string transUser, DateTime dateModified)
       {
           return new TransactionDTO.TransactionBuilder()

           .buildCode(code)
           .buildAmount(amount)
           .buildTransUser(transUser)
           .buildDateModified(dateModified)
           .build();

       }
    }
}
