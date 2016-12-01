using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.Interface
{
    interface IDatabaseFunctions
    {
        //void save(dynamic obj);
        void update(string id, List<string> details );
        void delete(string id);
        DataTable populateGrid();
    }
}
