using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.repositories
{
    public interface Repository<E,ID>
    {
        void save(E entity);
        void update(E entity);
        void delete(int id);
        DataTable findAll();
        E findByID(ID id);

    }
}
