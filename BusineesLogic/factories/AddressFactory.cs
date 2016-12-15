using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.factories
{
    public class AddressFactory
    {
        public static Address createAddress(List<string> addressDetails)
        {
            return new Address.AddressBuilder()
                   .buildStreet(addressDetails[0])
                   .buildSuburb(addressDetails[0])
                   .buildPostalCode(addressDetails[0])
                   .build();
        }
    }
}
