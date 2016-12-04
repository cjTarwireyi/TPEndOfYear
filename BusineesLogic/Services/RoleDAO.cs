using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.Interface;
using System.Data.SqlClient;
using System.Configuration;

namespace BusineesLogic.services
{
   public class RoleDAO:IRoleService
    {
       private SqlConnection con;
       public RoleDAO()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
    }

        public bool addRole(RoleDTO role)
        {
            throw new NotImplementedException();
        }

        public bool updateRole(RoleDTO role)
        {
            throw new NotImplementedException();
        }

        public bool deleteRole(int roleId)
        {
            throw new NotImplementedException();
        }

        public RoleDTO findRole(int roleId)
        {
            throw new NotImplementedException();
        }

        public List<RoleDTO> getAllRoles()
        {
            throw new NotImplementedException();
        }
    }
}
