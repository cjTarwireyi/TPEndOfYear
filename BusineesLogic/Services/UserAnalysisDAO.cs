using BusineesLogic.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.repositories;
using BusineesLogic.repositories.Impl;
namespace BusineesLogic.services
{
   public class UserAnalysisDAO
    {
       UserAnalysisRepository repo = new UserAnalysisRepository();

        public void save(domain.UserAnalysisDTO entity)
        {
            repo.save(entity);

        }

        public void update(domain.UserAnalysisDTO entity)
        {
            repo.update(entity);   
        }

        public void delete(int id)
        {
            repo.delete(id);  
        }

        public DataTable findAll()
        {
          return  repo.findAll();  
        }

        public domain.UserAnalysisDTO findByID(int id)
        {
            return repo.findByID(id);
        }
        public UserAnalysisDTO getLastReocrd()
        {
            return repo.getLastReocrd();
        }
    }
}
