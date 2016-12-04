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

                role = new RoleDTO.RoleBuilder()
                    .buildRoleID(reader.GetInt32(0))
                    .buildRoleName(reader.GetString(1))
                    .buildroleDescription(reader.GetString(2))
                    .build();
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
                roleList.Add(new RoleDTO.RoleBuilder()
                     .buildRoleID(reader.GetInt32(0))
                     .buildRoleName(reader.GetString(1))
                     .buildroleDescription(reader.GetString(2))
                     .build());
            }
             
            con.Close();
            return roleList;
        }

        public bool addRole(RoleDTO role)
        {
            try
            {
                var Datetime = DateTime.Now;

                con.Open();
                string insertQuery = "INSERT INTO Role (RoleName,RoleDescription,DateAdded) VALUES ('" + role.roleName + "','" + role.roleDescription + "','" + DateTime.Now.ToString() + "')";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.ExecuteNonQuery();

                con.Close();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
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
