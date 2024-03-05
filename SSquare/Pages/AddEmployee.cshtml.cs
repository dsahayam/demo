using HRSystems.DataModel;
using HRSystems.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRSystems.Pages
{
    public class AddEmployeeModel : PageModel
    {
        private readonly IHRSystemsProcess _hrSystemsProcess;
        public List<EmployeeInfo> EmployeesList { get; set; } = new List<EmployeeInfo>();

        public AddEmployeeModel()
        {
            IHRSystemsData hrSystemsData = new HRSystemsData();
            _hrSystemsProcess = new HRSystemsProcess(hrSystemsData);
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            //if ((List<EmployeeInfo>)ViewData["EmployeesList"] != null)
            //{
            //    EmployeesList = (List<EmployeeInfo>)ViewData["EmployeesList"];
            //}

            EmployeeInfo employeeInfo = new EmployeeInfo();
            //Message = "Post used " + Request.Form["EmployeeId"];
            //int emplyeeId = int.Parse(Request.Form["EmployeeId"].ToString());
            //employeeInfo.EmployeeId = emplyeeId;

            employeeInfo.FirstName = Request.Form["FirstName"].ToString();
            employeeInfo.LastName = Request.Form["LastName"].ToString();

            string empRoles = Request.Form["EmployeeRoles"].ToString();
            
            string[] arrRoles = empRoles.Split(',');
            List<Roles> listRoles = new List<Roles>();
            foreach (string role in arrRoles)
            {
                listRoles.Add(new Roles { RoleId = int.Parse(role) });
            }
            employeeInfo.ListRoles = listRoles;

            //EmployeesList.Add(employeeInfo);
            //ViewData["EmployeesList"] = EmployeesList;


            EmployeesList = _hrSystemsProcess.AddEmployeeInfo(employeeInfo);
        }
    }
}
