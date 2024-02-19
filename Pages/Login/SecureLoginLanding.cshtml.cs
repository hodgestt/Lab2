using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Lab2.Pages.Login
{
    public class SecureLoginLandingModel : PageModel
    {

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("UserName") != null) //by now, the UserName parameter and its value has already been validated
            {
                ViewData["LoginMessage"] = "Login for "
                    + HttpContext.Session.GetString("UserName")
                    + " successful!";

                
               
                return Page();
            }
            else
            {
                //creates a String with key of "LoginError" and a vlue of "You must login to access that page"
                HttpContext.Session.SetString("LoginError", "You must login to access that page!");
                return RedirectToPage("DBLogin");
            }
        }
    }
}
