using HRSystems.DataModel;

namespace HRSystems.ViewModel
{
    public class EmployeeInfo
    {
        public EmployeeInfo()
        { }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool IsManager { get; set; } = false;
        public List<Roles> ListRoles { get; set; } = [];
    }
}