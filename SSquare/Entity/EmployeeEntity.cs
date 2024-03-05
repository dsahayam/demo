using Microsoft.EntityFrameworkCore;

namespace HRSystems.Entity
{
    [Keyless]
    public class EmployeeEntity
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool IsManager { get; set; } = false;
    }
}
