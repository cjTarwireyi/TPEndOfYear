using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.factories
{
    public class UserFactory
    {
        public static UserDTO createUser(string username,string pass, int usertypeId)
        {
            return new UserDTO.UserBuilder()
            .buildUsername(username)
            .buildPassword(pass)
            .buldUsertypeId(usertypeId)
            .build();
        }
    }
}
