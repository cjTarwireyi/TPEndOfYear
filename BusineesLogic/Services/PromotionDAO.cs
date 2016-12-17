using System;
using System.Collections.Generic;
 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.Interface;
using System.Data.SqlClient;
using System.Configuration;
using BusineesLogic.factories;
using System.Data;
using BusineesLogic.domain;
using BusineesLogic.repositories.Impl;


namespace BusineesLogic.services
{
    public class PromotionDAO:IPromotion
    {
        private PromotionRepositoryImpl repo = new PromotionRepositoryImpl();
        public PromotionDAO() { }

        public PromotionDTO getTimeSheet(System.DateTime date)
        {
            throw new System.NotImplementedException();
        }

        public bool ifExis(string id)
        {
            throw new System.NotImplementedException();
        }

        public int getId(System.DateTime date)
        {
            throw new System.NotImplementedException();
        }

        public bool add(PromotionDTO model)
        {
            return repo.add(model);
        }

        public bool Update(PromotionDTO model)
        {
            return repo.updatePromotion(model);
        }

        public PromotionDTO getLastReocrd()
        {
            return repo.getLastReocrd();
        }

        public bool Delete(int id)
        {
            return repo.deletePromotion(id);
        }
    }
}
