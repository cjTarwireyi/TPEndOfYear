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
using BusineesLogic.repositories.Impl;

namespace BusineesLogic.services
{
    public class RoleDAO : IRoleService
    {
        private RoleRepositoryImpl repo = new RoleRepositoryImpl();
        public RoleDAO() { }
        public RoleDTO findRole(int roleId)
        {
            return repo.findByID(roleId);
        }

        public RoleDTO getLastReocrd()
        {
            return repo.getLastReocrd();
        }
        public List<RoleDTO> getAllRoles()
        {
            return repo.getAllRoles();
        }
        public DataTable populateGrid()
        {
            return repo.findAll();
        }
        public bool addRole(RoleDTO role)
        {
            return repo.addRole(role);
        }

        public bool updateRole(RoleDTO role)
        {
            return repo.updateRole(role);
        }

        public bool deleteRole(int roleId)
        {
            return repo.deleteRole(roleId);
        }


    }
}
