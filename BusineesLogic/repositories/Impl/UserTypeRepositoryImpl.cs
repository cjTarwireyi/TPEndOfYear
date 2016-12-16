using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BusineesLogic.repositories.Impl
{
    public class UserTypeRepositoryImpl : UserTypeRepository
    {
        private SqlConnection con;
        public UserTypeRepositoryImpl()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
        }

        public void save(UserTypeDTO entity)
        {
            throw new NotImplementedException();
        }

        public void update(UserTypeDTO entity)
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

        public UserTypeDTO findByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<ListItem> getUserTypes()
        {
            con.Open();
            List<ListItem> items = new List<ListItem>();
            // int count = 0;
            string userTypeQuerry = "SELECT userTypeName  FROM UserType  ";
            SqlCommand cmd = new SqlCommand(userTypeQuerry, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                items.Add(new ListItem(reader.GetString(0)));
            }
            con.Close();
            return items;
        }
    }
}
