using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.factories
{
   public class RoleFactory
    {
       public static RoleDTO createRole(int roleId, string roleDesc)
       {
           return new RoleDTO.RoleBuilder()
           .buildRoleID(roleId)
           .buildroleDescription(roleDesc)
           .build();
       
       }
    }
}
