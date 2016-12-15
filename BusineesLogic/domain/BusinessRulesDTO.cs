using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.domain
{
    public class BusinessRulesDTO
    {
        public int id { get; set; }
        public string businessRuleName { get; set; }
        public string businessRuleDescription { get; set; }
        public DateTime dateAdded { get; set; }

        private BusinessRulesDTO() { }
        public BusinessRulesDTO(BusinessRuleBuilder rules)
        {
            this.id = rules.id;
            this.businessRuleName = rules.businessRuleName;
            this.businessRuleDescription = rules.businessRuleDescription;
            this.dateAdded = rules.dateAdded;
            
        }

        public class BusinessRuleBuilder
        {
            public int id;
            public string businessRuleName;
            public string businessRuleDescription;
           public  DateTime dateAdded;

            public BusinessRuleBuilder buildID(int id)
            {
                this.id = id;
                return this;
            }

            public BusinessRuleBuilder buildName(string businessRuleName)
            {
                this.businessRuleName = businessRuleName;
                return this;
            }

            public BusinessRuleBuilder buildDescription(string businessRuleDescription)
            {
                this.businessRuleDescription = businessRuleDescription;
                return this;
            }


            public BusinessRuleBuilder buildDate()
            {
                this.dateAdded = DateTime.Now;
                return this;
            }

            public BusinessRuleBuilder copy(BusinessRulesDTO rules)
            {
                this.id = rules.id;
                this.businessRuleName = rules.businessRuleName;
                this.businessRuleDescription = rules.businessRuleDescription;
                this.dateAdded = rules.dateAdded;
                return this;
            }

            public BusinessRulesDTO build()
            {
                return new BusinessRulesDTO(this);
            }

        }
    }
}
