using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.domain;
namespace BusineesLogic.factories
{
    public class UserAnalysisFactory
    {
        public static UserAnalysisDTO createLeave(int userId, string Desc, DateTime dateModified)
        {
            return new UserAnalysisDTO.UserAnalysisBuilder()

            .buildUserId(userId)
            .buildDescription(Desc)
            .buildDateModified(dateModified)
            .build();

        }
    }
}
