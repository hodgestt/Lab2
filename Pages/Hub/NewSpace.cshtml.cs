using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Pages.Hub
{
    public class NewSpaceModel : PageModel
    {
        [BindProperty]
        [Required]
        public Collaboration NewSpace { get; set; }

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
            if (NewSpace.TeamName == "Test TeamName")
            {
                return RedirectToPage("Index");
            }
            if (NewSpace.TeamName != null & NewSpace.NotesAndInformation != null)
            {
                DBClass.InsertSpace(NewSpace);
                DBClass.Lab2DBConnection.Close();
                return RedirectToPage("Index");
            }
            return Page();

        }

        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            NewSpace.TeamName = "Test TeamName";
            NewSpace.NotesAndInformation = "Test NotesAndInformation";
            return Page(); //Page method inherited from Page class
        }
    }
}
