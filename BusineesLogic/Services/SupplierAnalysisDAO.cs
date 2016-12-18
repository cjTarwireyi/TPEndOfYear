using BusineesLogic.domain;
using BusineesLogic.repositories.Impl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.services
{
   public class SupplierAnalysisDAO
    {
       SupplierAnalysisRepository repo = new SupplierAnalysisRepository();
        public void save(SuplierAnalysisDTO entity)
        {
            repo.save(entity);

        }

        public void update(SuplierAnalysisDTO entity)
        {
            repo.update(entity);
        }

        public void delete(int id)
        {
            repo.delete(id);
        }

        public DataTable findAll()
        {
            return repo.findAll();
        }
        public SuplierAnalysisDTO findByID(int id)
        {
            return repo.findByID(id);
        }
        public SuplierAnalysisDTO getLastReocrd()
        {
            return repo.getLastReocrd();
        }
    }
}
