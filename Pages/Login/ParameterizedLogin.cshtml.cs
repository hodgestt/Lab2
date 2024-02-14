//Jessica Shamloo

using Microsoft.AspNetCore.Mvc;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab2.Pages.Login
{
    public class ParameterizedLoginModel : PageModel
    {
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
        }


        public IActionResult OnPost()
        {
            if (DBClass.SecureLogin(UserName, Password) > 0)
            {
                HttpContext.Session.SetString("UserName", UserName);
                ViewData["LoginMessage"] = "Login Successful!";
                
            }
            else
            {
                ViewData["LoginMessage"] = "Username and/or Password Incorrect";
            }

            DBClass.Lab2DBConnection.Close();

            return Page();

        }
    }
}
