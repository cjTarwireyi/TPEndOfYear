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

        //=======================
        //Get Instance of factory
        //=======================
        public static BrandFactory getInstance
        {
            get
            {
                if (singleton == null)
                {
                    singleton = new BrandFactory();
                    return singleton;
                }
                return singleton;
            }
        }

        //=====================
        //Public static methods
        //=====================
        public static Brand createBrandDTO(int id, List<string> brandDetails)
        {
            Brand brand = new Brand();
            brand.brandId = id;
            brand.brandName = brandDetails[0];
            brand.brandDescription = brandDetails[1];
            brand.dateCreated = DateTime.Now;
            return brand;
        }
    }
}
