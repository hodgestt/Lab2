using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab1Part3.Pages.Employees
{
    public class AddEmployeeModel : PageModel
    {
        [BindProperty]
        public Employee NewEmployee { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            DBClass.InsertEmployee(NewEmployee);
            DBClass.Lab1DBConnection.Close();
            return RedirectToPage("AddEmployee");

        }
    }
}