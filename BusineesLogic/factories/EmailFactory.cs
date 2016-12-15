using BusineesLogic.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.factories
{
    public class EmailFactory
    {
        public static EmailDTO createEmail(List<string> emailDetails)
        {
            return new EmailDTO.EmailBuilder()
                       .buildEmailAddress(emailDetails[0])
                       .buildName(emailDetails[0])
                       .buildMessage(emailDetails[0])
                       .build();
        }
    }
}
