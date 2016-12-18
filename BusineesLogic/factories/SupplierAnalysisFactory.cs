using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.domain;

namespace BusineesLogic.factories
{
  public  class SupplierAnalysisFactory
    {
      public static SuplierAnalysisDTO create(int supplierId,int productId, string Desc, DateTime dateModified)
      {
          return new SuplierAnalysisDTO.SupplierAnalysisBuilder()

          .buildId(supplierId)
          .buildProductId(productId)
          .buildDescription(Desc)
          .buildDateModified(dateModified)
          .build();

      }
    }
}
