using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.factories
{
    class SupplierFactory
    {
        public static SupplierDTO createSupplier(List<string> supplierDetails)
        {
            return new SupplierDTO.SupplierBuilder()
                .supName(supplierDetails[0])
                .supSurname(supplierDetails[1])
                .supCellNumber(supplierDetails[2])
                .supAddress(supplierDetails[3], supplierDetails[4], supplierDetails[5])
                .build();
        }
    }
}
