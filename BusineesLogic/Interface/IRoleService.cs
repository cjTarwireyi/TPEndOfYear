using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.Interface
{
    public interface IRoleService
    {
        bool addRole(RoleDTO role);
        bool updateRole(RoleDTO role);
        bool deleteRole(int roleId);
        RoleDTO findRole(int roleId);
        List<RoleDTO> getAllRoles();
        RoleDTO getLastReocrd();
    
    }
}
