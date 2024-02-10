using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace Lab1Part3.Pages.DataFiles
{
    public class AddDataFileModel : PageModel
    {
        [BindProperty]
        [Required]
        public DataFile NewDataFile { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (NewDataFile.DataName != "Test Data Name" & NewDataFile.DataLocation != null & NewDataFile.DataDescription != null)
            {
                DBClass.InsertDataFile(NewDataFile);
                DBClass.Lab1DBConnection.Close();
                return RedirectToPage("Index");
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
