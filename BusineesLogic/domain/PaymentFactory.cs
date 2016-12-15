using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.domain
{
    public class PaymentFactory
    {
        public static PaymentDTO makePayment(decimal paymentAmount,decimal totalAmount)
        {
            return new PaymentDTO.PaymentBuilder()
                    .buildCalculator(totalAmount, paymentAmount)
                    .build();
        }
    }
}
