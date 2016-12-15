using BusineesLogic.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.factories
{
    public class ReturnFactory
    {
        public static ReturnDTO createReturnRecord(List<int> returnDetails)
        {
            return new ReturnDTO.ReturnBuilder()
                        .customerNumber(returnDetails[0])
                        .orderNumber(returnDetails[1])
                        .productNumber(returnDetails[2])
                        .productQuantity(returnDetails[3])
                        .date(DateTime.Now.ToString())
                        .build();

        }
    }
}
