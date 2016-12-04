using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RoleDTO
/// </summary>
public class RoleDTO
{
    public RoleDTO(RoleBuilder roleBuilder)
    {
        this.roleId = roleBuilder.roleId;
        this.roleName = roleBuilder.roleName;
        this.roleDescription = roleBuilder.roleDescription;
    }
    public int roleId { get; set; }
    public string roleName { get; set; }
    public string roleDescription { get; set; }
    public class RoleBuilder
    {
        public int roleId;
        public string roleName;
        public string roleDescription;

        public RoleBuilder buildRoleID(int roleId)
        {
            this.roleId = roleId;
            return this;
        }
        public RoleBuilder buildRoleName(string roleName)
        {
            this.roleName = roleName;
            return this;
        }
        public RoleBuilder buildroleDescription(string roleDescription)
        {
            this.roleDescription = roleDescription;
            return this;
        }
        public RoleBuilder copy(RoleDTO roleDTO)
        {
            this.roleId = roleDTO.roleId;
            this.roleName = roleDTO.roleName;
            this.roleDescription = roleDTO.roleDescription;
            return this;
        }
        public RoleDTO build()
        {
            return new RoleDTO(this);
        }
    }
}
	 