using System;
using HRSystems.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace HRSystems
{
    public interface IHRSystemsProcess
    {
        public List<EmployeeInfo> GetAllEmployeesInfo();

        public List<EmployeeInfo> GetManagerEmployeesAssociationInfo(int employeeId);

        public List<EmployeeInfo> AddEmployeeInfo(EmployeeInfo employeeInfo);
    }
}