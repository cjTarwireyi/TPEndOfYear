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
   public class TransactionDAO
    {
        TransactionRepository repo = new TransactionRepository();

        public void save(TransactionDTO entity)
        {
            repo.save(entity);

        }

        public void update(TransactionDTO entity)
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
        public TransactionDTO findByID(int id)
        {
            return repo.findByID(id);
        }
        public TransactionDTO getLastReocrd()
        {
            return repo.getLastReocrd();
        }
    }
}
