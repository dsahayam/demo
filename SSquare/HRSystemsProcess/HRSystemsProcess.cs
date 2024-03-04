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
            //List<EmployeeInfo> listEmployeeInfo = [];
            return new List<EmployeeInfo>();
        }

        public List<EmployeeInfo> GetManagerEmployeesAssociationInfo(int employeeId)
        {
            //List<EmployeeInfo> listEmployeeInfo = [];
            return new List<EmployeeInfo>();
        }

        List<EmployeeInfo> IHRSystemsProcess.GetAllEmployeesInfo()
        {
            throw new NotImplementedException();
        }

        List<EmployeeInfo> IHRSystemsProcess.GetManagerEmployeesAssociationInfo(int employeeId)
        {
            return _hrSystemsData.GetManagerEmployeesAssociationInfo(employeeId);
        }

        public EmployeeInfo AddEmployeeInfo(EmployeeInfo employeeInfo)
        {
            throw new NotImplementedException();
        }
    }
}
