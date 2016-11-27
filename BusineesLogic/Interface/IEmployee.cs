using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BusineesLogic.Interface
{
   public interface IEmployee
    {
         void saveEmployee(EmployeeDTO emp);
         EmployeeDTO makeTechDTO(SqlDataReader myDR);
         EmployeeDTO getEmployee(int id);
         DataTable populateGrid();

    }
}
