using Microsoft.EntityFrameworkCore;

namespace HRSystems.Entity
{
    [Keyless]
    public class RolesEntity
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }
}
