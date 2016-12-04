using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.factories
{
   public class RoleFactory
    {
       public static RoleDTO createRole(string roleName, string roleDesc)
       {
           return new RoleDTO.RoleBuilder()
           
           .buildRoleName(roleName)
           .buildroleDescription(roleDesc)
           .build();
       
       }
    }
}
