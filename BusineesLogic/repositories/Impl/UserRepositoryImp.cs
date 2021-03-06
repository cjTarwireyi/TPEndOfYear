﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.repositories.Impl
{
    public class UserRepositoryImp : UserRepository
    {
        private SqlConnection con;
        private UserDTO user = new UserDTO();
        private UserTypeDTO usertypeDto = new UserTypeDTO();

        public UserRepositoryImp()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);

        }

        public void save(UserDTO entity)
        {
            throw new NotImplementedException();
        }

        public void update(UserDTO entity)
        {
            throw new NotImplementedException();
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable findAll()
        {
            throw new NotImplementedException();
        }

        public UserDTO findByID(int id)
        {
            throw new NotImplementedException();
        }

        public UserDTO getUser(string username, string password)
        {
            var found = new UserDTO();
            con.Open();
            UserFacade userFacade = new UserFacade();
            string userQuerry = "SELECT * FROM Users a INNER JOIN UserType b ON a.userTypeId = b.userTypeId where userName='" + username + "' AND pass ='" + password + "'";
            SqlCommand cmd = new SqlCommand(userQuerry, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                found = makeDTO(reader);
            }
            con.Close();
            return found;
        }

        public bool ifUserExist(string username)
        {
            con.Open();
            bool found;
            UserFacade userFacade = new UserFacade();
            string checkTechnician = "SELECT * FROM Users  where userName = '" + username + "' ";
            SqlCommand cmd = new SqlCommand(checkTechnician, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                found = true;
            }
            else
            {
                found = false;
            }
            con.Close();
            return found;

        }

        public int getUserTypeId(string username)
        {
            con.Open();

            int userId = 0;

            string select = "SELECT userTypeId  FROM UserType WHERE userTypeName ='" + username.Trim() + "'";
            //string checkTechnician = "SELECT * FROM user_types";
            SqlCommand cmd = new SqlCommand(select, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                userId = reader.GetInt32(0);
            }
            con.Close();
            return userId;


        }
        public bool addUser(UserDTO model)
        {
            con.Open();
            string insertQuery = "INSERT INTO Users (userName,pass,userTypeId) VALUES (@username,@pass,@userTypeId)";
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            cmd.Parameters.AddWithValue("@username", model.username);
            //cmd.Parameters.AddWithValue("@name",FullName.Text);
            cmd.Parameters.AddWithValue("@pass", model.password);
            cmd.Parameters.AddWithValue("@userTypeId", model.userTypeId);

            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }

        }
        public bool UpdateUser(UserDTO model)
        {
            con.Open();
            string updateQuery = "Update Users Set userName= @username,pass=@pass,userTypeId = @userTypeId Where userId =@userId";
            SqlCommand cmd = new SqlCommand(updateQuery, con);
            cmd.Parameters.AddWithValue("@userId", model.Id);
            cmd.Parameters.AddWithValue("@username", model.username);

            cmd.Parameters.AddWithValue("@pass", model.password);
            cmd.Parameters.AddWithValue("@userTypeId", model.userTypeId);
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
        public bool Delete(int id)
        {
            con.Open();
            string deleteQuery = "DELETE FROM Users WHERE  userId ='" + id + "'";
            SqlCommand cmd = new SqlCommand(deleteQuery, con);
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
        public UserDTO makeDTO(SqlDataReader reader)
        {

            // SqlDataReader reader = userDao.getUser(name, username);
            if (reader.HasRows == true)
            {
                user.Id = reader.GetInt32(0);
                user.username = reader.GetString(1);
                user.password = reader.GetString(2);

                usertypeDto.Id = reader.GetInt32(3);
                usertypeDto.name = reader.GetString(5);
                user.userTypeId = usertypeDto.Id;
                user.userTypeName = usertypeDto.name;
            }

            return user;
        }

        public DataTable getLoginDetails(int id)
        {
            DataTable customers = new DataTable();
            string query = "select * from users where userid = '" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(customers);
            da.Dispose();
            con.Close();
            return customers;
        }
        public List<UserDTO> getUsers()
        {
            return null;
        }
    }
}
