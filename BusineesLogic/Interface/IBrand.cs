using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.domain;

namespace BusineesLogic.Interface
{
    public interface IBrand
    {
        List<BrandDTO> getAllBrands();
        BrandDTO save(BrandDTO brand);
        BrandDTO update(BrandDTO brand);
        BrandDTO delete(long id);
        BrandDTO findBrand(long id);
    }
}
