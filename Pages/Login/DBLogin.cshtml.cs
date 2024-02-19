using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using System.Security.Claims;
//using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;



namespace Lab2.Pages.Login
{
    public class DBLoginModel : PageModel
    {
        
        [BindProperty] 
        public string UserName { get; set; }

        [BindProperty]
        public int EmployeeID { get; set; } //new 


        [BindProperty]
        public string Password { get; set; }

       
        public IActionResult OnGet(String logout)
        {
            if (logout == "true")
            {
                HttpContext.Session.Clear();
                ViewData["LoginMessage"] = "Successfully Logged Out!";
            }

            return Page();

        }

        public IActionResult OnPost()
        {
            string loginQuery = "SELECT COUNT(*) FROM Employee where UserName = '";
            loginQuery += UserName + "' and Password='" + Password + "'";
            

            if (DBClass.LoginQuery(loginQuery) > 0)
            {
                HttpContext.Session.SetString("UserName", UserName);

                DBClass.Lab2DBConnection.Close();


                string EmployeeQuery = "Select EmployeeID From Employee where UserName = '" + UserName + "'";

                EmployeeID = DBClass.GetEmployeeID(EmployeeQuery);

                HttpContext.Session.SetInt32("EmployeeID", EmployeeID);




                DBClass.Lab2DBConnection.Close();

                return RedirectToPage("SecureLoginLanding");

            }
            else
            {
                ViewData["LoginMessage"] = "UserName and/or Password Incorrect";
                DBClass.Lab2DBConnection.Close();
                return Page();

            }

        }

        public IActionResult OnPostLogoutHandler()
        {
            HttpContext.Session.Clear();
            return Page();
        }
    }
}
