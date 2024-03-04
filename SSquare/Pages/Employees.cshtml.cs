using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace SSquare_HRSystem.Pages
{
    public class EmployeesModel : PageModel
    {
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Retrieve the value entered by the user in the TextBox
            //string name = txtName.Text;

            // Display a message using a Label control
            //lblMessage.Text = "Hello, " + name + "! Your name has been submitted.";
        }

        public void OnGet()
        {
        }
    }
}
