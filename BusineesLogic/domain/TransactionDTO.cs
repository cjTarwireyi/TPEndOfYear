using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.domain
{
    public class TransactionDTO
    {
        public TransactionDTO(TransactionBuilder builder)
        {
            this.id = builder.id;
            this.code = builder.code;
            this.amount = builder.amount;
            this.dateModified = builder.dateModified;
        }
        public int id { get; set; }
        public string code { get; set; }
        public decimal amount { get; set; }
        public DateTime dateModified { get; set; }

        public class TransactionBuilder
        {
            public int id;
            public string code;
            public decimal amount;
            public DateTime dateModified;

            public TransactionBuilder buildId(int id)
            {
                this.id = id;
                return this;
            }
            public TransactionBuilder buildCode(string code)
            {
                this.code = code;
                return this;
            }
            public TransactionBuilder buildAmount(decimal amount)
            {
                this.amount = amount;
                return this;
            }
            public TransactionBuilder buildDateModified(DateTime date)
            {
                this.dateModified = date;
                return this;
            }
            public TransactionBuilder copy(TransactionDTO transDto)
            {
                this.id = transDto.id;
                this.code = transDto.code;
                this.amount = transDto.amount;
                this.dateModified = transDto.dateModified;
                return this;
            }
            public TransactionDTO build()
            {
                return new TransactionDTO(this);
            }
        }
    }
}
