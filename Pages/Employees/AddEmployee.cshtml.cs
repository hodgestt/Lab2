//Jessica Shamloo

using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Pages.Employees
{
    public class AddEmployeeModel : PageModel
    {
        [BindProperty]
        [Required]
        public Employee NewEmployee { get; set; }


        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("UserName") != null) //by now, the UserName parameter and its value has already been validated
            {
                return Page();
            }

            else
            {
                //creates a String with key of "LoginError" and a vlue of "You must login to access that page"
                HttpContext.Session.SetString("LoginError", "You must login to access that page!");

                return RedirectToPage("/Login/DBLogin");
            }
        }

        public IActionResult OnPost()
        {
            if (NewEmployee.FirstName == "Test FirstName"){
                return RedirectToPage("Index");
                }
            if (NewEmployee.FirstName != null & NewEmployee.LastName != null & NewEmployee.Email != null & NewEmployee.Phone != null & NewEmployee.Street != null & NewEmployee.City != null & NewEmployee.State != null & NewEmployee.Zip != null & NewEmployee.UserName != null & NewEmployee.Password != null)
            {
                DBClass.InsertEmployee(NewEmployee);
                DBClass.Lab2DBConnection.Close();
                return RedirectToPage("Index");
            }
            return Page();
            
        }

        
        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            NewEmployee.FirstName = "Test FirstName";
            NewEmployee.LastName = "Test LastName";
            NewEmployee.Email = "Test@Email";
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

