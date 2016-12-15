using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.domain;

namespace BusineesLogic.factories
{
   public class LeaveFactory
    {
        public static LeaveDTO createLeave(string title, string Desc,DateTime dateModified)
        {
            return new LeaveDTO.LeaveBuilder()
            .buildLeaveTitle(title)
            .buildDescription(Desc)
            .buildDateModified(dateModified)
            .build();

        }
    }
}
