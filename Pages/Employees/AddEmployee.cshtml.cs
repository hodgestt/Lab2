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
            return RedirectToPage("Index");

        }
        
        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            NewEmployee.FirstName = "Test FirstName";
            NewEmployee.LastName = "Test LastName";
            NewEmployee.Email = "Test Email";
            NewEmployee.Phone = "Test Phone";
            NewEmployee.Street = "Test Street";
            NewEmployee.City = "Test City";
            NewEmployee.State = "Test State";
            NewEmployee.Zip = "Test Zip";
            NewEmployee.UserName = "Test UserName";
            NewEmployee.Password = "Test Password";
            return Page(); //Page method inherited from Page class
        }


    }
}