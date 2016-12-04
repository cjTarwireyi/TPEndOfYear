using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.Interface;
using System.Data.SqlClient;
using System.Configuration;
using BusineesLogic.factories;

namespace BusineesLogic.services
{
    public class RoleDAO : IRoleService
    {
        private SqlConnection con;
        public RoleDAO()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
        }
        public RoleDTO findRole(int roleId)
        {
            con.Open();
            RoleDTO role ;
            string select = "SELECT *  FROM Role WHERE roleID ='" + roleId + "'";
             
            SqlCommand cmd = new SqlCommand(select, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                role = RoleFactory.createRole( reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            }
            else
            {
                role = null;
            }
            con.Close();
            return role;

        }

        public List<RoleDTO> getAllRoles()
        {
            con.Open();
            List<RoleDTO> roleList = new List<RoleDTO>();
            string select = "SELECT * FROM Role ";

            SqlCommand cmd = new SqlCommand(select, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                roleList.Add(RoleFactory.createRole(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                
            }
             
            con.Close();
            return roleList;
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


    }
}
