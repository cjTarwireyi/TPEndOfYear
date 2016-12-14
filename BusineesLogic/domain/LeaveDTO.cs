using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.domain
{
    public class LeaveDTO
    {
        public int Id{get; set;}
        public string leaveTitle{get;set;}
        public string description{get; set;}
        public DateTime dateModified { get; set; }
    }
}
