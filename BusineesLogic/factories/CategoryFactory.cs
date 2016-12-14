using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.domain;


namespace BusineesLogic.factories
{
   public class CategoryFactory
    {
       public static CategoryDTO  create(string name, string brandDesc, DateTime dateCreated)
       {
           return new CategoryDTO.CategoryBuilder()

           .buildBrandName(name)
           .buildDescription(brandDesc)
           .buildDateCreated(dateCreated)
           
           .build();

       }
    }
}
