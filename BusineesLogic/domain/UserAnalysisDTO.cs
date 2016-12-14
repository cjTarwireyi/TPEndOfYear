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
            this.description = builder.description;
            this.dateModified = builder.dateModified;
        }
        public int id { get; set; }
        public int userId { get; set; }
        public string description { get; set; }
        public DateTime dateModified { get; set; }
        public class UserAnalysisBuilder
        {
            public int id;
            public int userId;
            public string description;
            public DateTime dateModified;

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
            public UserAnalysisBuilder buildDescription(string desc)
            {
                this.description = desc;
                return this;
            }
            public UserAnalysisBuilder buildDateModified(DateTime date)
            {
                this.dateModified = date;
                return this;

            }
            public UserAnalysisBuilder copy(UserAnalysisDTO userAnalysisDto)
            {
                this.id = userAnalysisDto.id;
                this.userId = userAnalysisDto.userId;
                this.description = userAnalysisDto.description;
                this.dateModified = userAnalysisDto.dateModified;
                return this;
            }
            public UserAnalysisDTO build()
            {
                return new UserAnalysisDTO(this);
            }
        }
    }
}
