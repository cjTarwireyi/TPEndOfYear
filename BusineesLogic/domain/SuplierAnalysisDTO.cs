﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.domain
{
    public class SuplierAnalysisDTO
    {
        public SuplierAnalysisDTO(SupplierAnalysisBuilder builder)
        {
            this.id = builder.id;
            this.productId = builder.productId;
            this.description = builder.description;
            this.dateModified = builder.dateModified;
        }
        public int id { get; set; }
        public int productId { get; set; }
        public string description { get; set; }
        public DateTime dateModified { get; set; }
        public class SupplierAnalysisBuilder
        {
            public int id;
            public int productId;
            public string description;
            public DateTime dateModified;

            public SupplierAnalysisBuilder buildId(int id)
            {
                this.id = id;
                return this;
            }
            public SupplierAnalysisBuilder buildProductId(int productId)
            {
                this.productId = productId;
                return this;
            }
            public SupplierAnalysisBuilder buildDescription(string desc)
            {
                this.description = desc;
                return this;
            }
            public SupplierAnalysisBuilder buildDateModified(DateTime date)
            {
                this.dateModified = date;
                return this;

            }
            public SupplierAnalysisBuilder copy(SuplierAnalysisDTO supierAnalysisDto)
            {
                this.id = supierAnalysisDto.id;
                this.productId = supierAnalysisDto.productId;
                this.description = supierAnalysisDto.description;
                this.dateModified = supierAnalysisDto.dateModified;
                return this;
            }
            public SuplierAnalysisDTO build()
            {
                return new SuplierAnalysisDTO(this);
            }
        }
    }
}
