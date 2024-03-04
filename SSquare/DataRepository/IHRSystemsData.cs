using HRSystems.ViewModel;
using System;

namespace HRSystems
{
    public interface IHRSystemsData
    {
        public List<EmployeeInfo> GetEmployeesInfo(int employeeId);

        public List<EmployeeInfo> GetManagerEmployeesAssociationInfo(int employeeId);

        //public EmployeeInfo AddEmployeeInfo(EmployeeInfo employeeInfo);
    }
}