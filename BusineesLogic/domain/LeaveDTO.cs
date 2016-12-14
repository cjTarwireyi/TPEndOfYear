using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.domain
{
    public class LeaveDTO
    {
        public LeaveDTO(LeaveBuilder leaveBuilder)
        {
            this.Id = leaveBuilder.Id;
            this.leaveTitle = leaveBuilder.leaveTitle;
            this.description = leaveBuilder.description;
            this.dateModified = leaveBuilder.dateModified;
        }
        public int Id{get; set;}
        public string leaveTitle{get;set;}
        public string description{get; set;}
        public DateTime dateModified { get; set; }

        public class LeaveBuilder
        {
            public int Id;
            public string leaveTitle;
            public string description;
            public DateTime dateModified;
            public LeaveBuilder buildId(int id)
            {
                this.Id = id;
                return this;
            }
            public LeaveBuilder buildLeaveTitle(string leaveTitle)
            {
                this.leaveTitle = leaveTitle;
                return this;

            }
            public LeaveBuilder buildDescription(string description)
            {
                this.description = description;
                return this;
            }
            public LeaveBuilder buildDateModified(DateTime dateModified)
            {
                this.dateModified = dateModified;
                return this;
            }
            public LeaveBuilder copy(LeaveDTO leaveDto)
            {
                this.Id = leaveDto.Id;
                this.leaveTitle = leaveDto.leaveTitle;
                this.description = leaveDto.description;
                this.dateModified = leaveDto.dateModified;
                return this;
            }
            public LeaveDTO build()
            {
                return new LeaveDTO(this);
            }
        }
    }
}
