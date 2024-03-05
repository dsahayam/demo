using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace HRSystems.Entity
{
    [Keyless]
    public class ManagerEmployeesEntity
    {
        public int ManagerEmployeeId { get; set; }
        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }
        public List<int> EmployeeIds { get; set; } = [];
    }
} 

