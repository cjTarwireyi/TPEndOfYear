using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.domain
{
    public class PaymentDTO
    {
        
        public decimal due { get; set; }
        private PaymentDTO() { }
        public PaymentDTO(PaymentBuilder payment)
        {
            
            this.due = payment.due;
           
        }
 
        public class PaymentBuilder
        {
          
            public decimal due;


          

            public PaymentBuilder buildCalculator(decimal totalAmount, decimal paymentAmount)
            {
                this.due = totalAmount - paymentAmount;
                return this;
            }

            public PaymentBuilder copy(PaymentDTO payment)
            {
                this.due = payment.due;
               
                return this;
            }

            public PaymentDTO build()
            {
                return new PaymentDTO(this);
            }
        }
    }
}
