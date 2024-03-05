using Microsoft.EntityFrameworkCore;

namespace HRSystems.Entity
{
    [Keyless]
    public class EmployeeInfoEntity
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool IsManager { get; set; } = false;
        public List<RolesEntity> ListRoles { get; set; } = [];
    }
}