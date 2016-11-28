using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.Interface
{
   public interface IUser
    {
       UserDTO getUser(string username, string password);
       bool ifUserExist(string username);
       int getUserTypeId(string username);
       bool addUser(UserDTO model);
       bool UpdateUser(UserDTO model);
       bool Delete(int id);
    }
 
}
