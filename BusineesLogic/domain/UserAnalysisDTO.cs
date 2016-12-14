using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.domain
{
    public class UserAnalysisDTO
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string description { get; set; }
        public DateTime dateModified { get; set; }
    }
}
