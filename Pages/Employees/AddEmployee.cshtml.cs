using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Lab1Part3.Pages.Employees
{
    public class AddEmployeeModel : PageModel
    {
        [BindProperty]
        [Required]
        public Employee NewEmployee { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (NewEmployee.FirstName != null & NewEmployee.LastName != null & NewEmployee.Email != null & NewEmployee.Phone != null & NewEmployee.Street != null & NewEmployee.City != null & NewEmployee.State != null & NewEmployee.Zip != null & NewEmployee.UserName != null & NewEmployee.Password != null)
            {
                DBClass.InsertEmployee(NewEmployee);
                DBClass.Lab1DBConnection.Close();
                return RedirectToPage("Index");
            }
            return Page();
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

//if (Username.Equals("user") && Password.Equals("12345"))
//{
//    return RedirectToPage("/Practice/UserLanding", new { username = Username, loginsuccess = true });
//}

//Message = "Login was unsuccesful";
//return Page();