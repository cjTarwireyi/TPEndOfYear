using BusineesLogic.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.factories
{
    public class BusinessRuleFactory
    {
        public static BusinessRulesDTO createRule(string name,string descrition)
        {
            return new BusinessRulesDTO.BusinessRuleBuilder()
                                    .buildName(name)
                                    .buildDescription(descrition)
                                    .buildDate()
                                    .build();
                        
        }
    }
}
