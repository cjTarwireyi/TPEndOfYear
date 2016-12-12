using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusineesLogic.domain;

/// <summary>
/// Summary description for BrandDTO
/// </summary>
/// 

namespace BusineesLogic.domain
{
    public class BrandDTO 
    {
        public BrandDTO(BrandBuilder builder)
        {
            this.Id = builder.Id;
            this.brandName = builder.brandName;
            this.brandDescription = builder.brandDescription;
            this.dateCreated = builder.dateCreated;
            this.active = builder.active;
        }
        public int Id { get; set; }
        public string brandName { get; set; }
        public string brandDescription { get; set; }
        public DateTime dateCreated {get; set;}
        public bool active { get; set; }

        public class BrandBuilder
        {
            public int Id;
            public string brandName;
            public string brandDescription;
            public DateTime dateCreated;
            public bool active;

            public BrandBuilder builId(int id)
            {
                this.Id = id;
                return this;
            }
            public BrandBuilder buildBrandName(string brandName)
            {
                this.brandName = brandName;
                return this;
            }
            public BrandBuilder buildBrandDescription(string brandDescription)
            {
                this.brandDescription = brandDescription;
                return this;
            }
            public BrandBuilder buildDateCreated(DateTime dateCreated)
            {
                this.dateCreated = dateCreated;
                return this;
            }

            public BrandBuilder buildActive(bool active)
            {
                this.active = active;
                return this;
            }

            public BrandBuilder copy(BrandDTO brand)
            {
                this.Id = brand.Id;
                this.brandName = brand.brandName;
                this.brandDescription = brand.brandDescription;
                this.dateCreated = brand.dateCreated;
                this.active = brand.active;
                return this;
            }
            public BrandDTO build()
            {
                return new BrandDTO(this);
            }
        }

    }
}