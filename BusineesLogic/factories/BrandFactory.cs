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
        



        public static BrandDTO createBrand(string brandName, string brandDesc, DateTime dateCreated, bool active)
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
