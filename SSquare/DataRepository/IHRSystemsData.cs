using HRSystems.ViewModel;
using System;
using System.Data.SqlClient;

namespace HRSystems
{
    public interface IHRSystemsData
    {
        public List<EmployeeInfo> GetAllEmployeesInfo();

        public List<EmployeeInfo> GetManagerEmployeesAssociationInfo(int employeeId);

        public List<EmployeeInfo> AddEmployeeInfo(EmployeeInfo employeeInfo);
    }
}