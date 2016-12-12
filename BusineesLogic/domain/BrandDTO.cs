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
        public int Id { get; set; }
        public string brandName { get; set; }
        public string brandDescription { get; set; }
        public DateTime dateCreated {get; set;}

    }
}