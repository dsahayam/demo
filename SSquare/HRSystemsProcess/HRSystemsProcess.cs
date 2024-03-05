using System;
using HRSystems;
using HRSystems.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;


namespace HRSystems
{
    public class HRSystemsProcess : IHRSystemsProcess
    {
        //(HRSystemsData hrSystemsData)
        private readonly IHRSystemsData _hrSystemsData;
        public HRSystemsProcess(IHRSystemsData hrSystemsData)
        {
            _hrSystemsData = hrSystemsData;
        }

        public List<EmployeeInfo> GetAllEmployeesInfo()
        {
            return _hrSystemsData.GetAllEmployeesInfo();
        }

        public List<EmployeeInfo> GetManagerEmployeesAssociationInfo(int employeeId)
        {
            return _hrSystemsData.GetManagerEmployeesAssociationInfo(employeeId);
        }

        public List<EmployeeInfo> AddEmployeeInfo(EmployeeInfo employeeInfo)
        {
            return _hrSystemsData.AddEmployeeInfo(employeeInfo);
        }
    }
}
