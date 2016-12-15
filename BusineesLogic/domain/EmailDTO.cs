using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.domain
{
    public class EmailDTO
    {
        public string emailAddress { get; set; }
        public string name { get; set; }
        public string message { get; set; }

        private EmailDTO() { }

        public EmailDTO(EmailBuilder email)
        {
            this.emailAddress = email.emailAddress;
            this.name = email.name;
            this.message = email.message;
            
        }

        public class EmailBuilder
        {
            public string emailAddress;
            public string name;
            public string message;

            public EmailBuilder buildEmailAddress(string emailAddress)
            {
                this.emailAddress = emailAddress;
                return this;
            }

            public EmailBuilder buildName(string name)
            {
                this.name = name;
                return this;
            }

            public EmailBuilder buildMessage(string message)
            {
                this.message = message;
                return this;
            }

            public EmailBuilder copy(EmailDTO email)
            {
                this.emailAddress = email.emailAddress;
                this.name = email.name;
                this.message = email.message;
                return this;
            }

            public EmailDTO build()
            {
                return new EmailDTO(this);
            }

        }
    }
}
