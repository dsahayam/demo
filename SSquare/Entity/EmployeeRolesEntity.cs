using Microsoft.EntityFrameworkCore;

namespace HRSystems.Entity
{
    [Keyless]
    public class EmployeeRolesEntity
    {
        public int EmployeeRoleId { get; set; }
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }
    }
}