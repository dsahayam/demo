using System.Diagnostics.CodeAnalysis;

namespace HRSystems.DataModel
{
    public class ManagerEmployees
    {
        public int ManagerId { get; set; }
        public List<int> EmployeeIds { get; set; } = [];
    }
} 

