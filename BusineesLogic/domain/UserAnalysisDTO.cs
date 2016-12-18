using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.domain
{
    public class UserAnalysisDTO
    {
        public UserAnalysisDTO(UserAnalysisBuilder builder)
        {
            this.id = builder.id;
            this.userId = builder.userId;
            this.pageAccessed = builder.pageAccessed;
            this.dateModified = builder.dateModified;
            this.timesAccessed = builder.timesAccessed;
        }
        public int id { get; set; }
        public int userId { get; set; }
        public string pageAccessed { get; set; }
        public DateTime dateModified { get; set; }
        public int timesAccessed { get; set; }
        public class UserAnalysisBuilder
        {
            public int id;
            public int userId;
            public string pageAccessed;
            public DateTime dateModified;
            public int timesAccessed;

            public UserAnalysisBuilder buildId(int id)
            {
                this.id = id;
                return this;
            }
            public UserAnalysisBuilder buildUserId(int userId)
            {
                this.userId = userId;
                return this;
            }
            public UserAnalysisBuilder buildPageAccessed(string desc)
            {
                this.pageAccessed = desc;
                return this;
            }
            public UserAnalysisBuilder buildDateModified(DateTime date)
            {
                this.dateModified = date;
                return this;

            }
            public UserAnalysisBuilder buildTimesAccessed(int timesAccessed)
            {
                this.timesAccessed = timesAccessed;
                return this;
            }
            public UserAnalysisBuilder copy(UserAnalysisDTO userAnalysisDto)
            {
                this.id = userAnalysisDto.id;
                this.userId = userAnalysisDto.userId;
                this.pageAccessed = userAnalysisDto.pageAccessed;
                this.dateModified = userAnalysisDto.dateModified;
                this.timesAccessed = userAnalysisDto.timesAccessed;
                return this;
            }
            public UserAnalysisDTO build()
            {
                return new UserAnalysisDTO(this);
            }
        }
    }
}
