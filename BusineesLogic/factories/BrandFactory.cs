using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.domain;

namespace BusineesLogic.factories
{
    public class BrandFactory
    {
        private static BrandFactory singleton;
        private BrandFactory() { }

         

         
        public static BrandDTO createRole(string brandName, string brandDesc,DateTime dateCreated, bool active)
        {
            return new BrandDTO.BrandBuilder()

            .buildBrandName(brandName)
            .buildBrandDescription(brandDesc)
            .buildDateCreated(dateCreated)
            .buildActive(active)
            .build();

        }
    }
}
