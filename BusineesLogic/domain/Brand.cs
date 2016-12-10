using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.domain
{
    public class Brand
    {
        //============
        //Constructors
        //============
        public Brand()
        {

        }

        //==========
        //Properties
        //==========
        public long brandId { get; set; }
        public string brandName { set; get; }
        public string brandDescription { set; get; }
        public DateTime dateCreated { get; set; }
        }
}

