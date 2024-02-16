//Thomas Hodges

using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace Lab2.Pages.DataFiles
{
    public class AddDataFileModel : PageModel
    {
        [BindProperty]
        [Required]
        public DataFile NewDataFile { get; set; }


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
            if (NewDataFile.DataName == "Test Data Name"){
                return RedirectToPage("/Collaborations/Index");
            }
            if (NewDataFile.DataName != null & NewDataFile.DataLocation != null & NewDataFile.DataDescription != null)
            {
                DBClass.InsertDataFile(NewDataFile);
                DBClass.Lab2DBConnection.Close();
                return RedirectToPage("/Collaborations/Index");
            }
            return Page();

        }

        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            NewDataFile.DataName = "Test Data Name";
            NewDataFile.DataLocation = "Test Location";
            NewDataFile.DataDescription = "Test Description";
            return Page(); //Page method inherited from Page class
        }


    }
}
