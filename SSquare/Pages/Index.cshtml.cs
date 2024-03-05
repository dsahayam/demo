using HRSystems;
//using HRSystems.HRSystemsProcess;
using HRSystems.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRSystems.Pages;

public class IndexModel : PageModel
{
    //1. add the following property
    public IEnumerable<EmployeeInfo> EmployeesList { get; set; } = new List<EmployeeInfo>();

    private readonly ILogger<IndexModel> _logger;
    private readonly IHRSystemsProcess _hrSystemsProcess;
    public string Message { get; set; } = string.Empty;
    public int EmplyeeId { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        IHRSystemsData hrSystemsData = new HRSystemsData();
        _hrSystemsProcess = new HRSystemsProcess(hrSystemsData);
    }

    public void OnGet()
    {
    }
    public void OnPost()
    {
        int emplyeeId = int.Parse(Request.Form["EmployeeId"].ToString());

        if (emplyeeId == 0)
        {
            EmployeesList = _hrSystemsProcess.GetAllEmployeesInfo();
        }
        else
        {
            EmployeesList = _hrSystemsProcess.GetManagerEmployeesAssociationInfo(emplyeeId);
        }
    }
}
