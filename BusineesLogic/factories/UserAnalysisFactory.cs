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
        public static UserAnalysisDTO createAnalysis(int userId, string pageAccessed,int timesAccessed, DateTime dateModified)
        {
            return new UserAnalysisDTO.UserAnalysisBuilder()

            .buildUserId(userId)
            .buildPageAccessed(pageAccessed)
            .buildTimesAccessed(timesAccessed)
            .buildDateModified(dateModified)
            .build();

        }
    }
}
