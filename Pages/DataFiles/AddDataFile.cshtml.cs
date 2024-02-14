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


        public void OnGet()
        {
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
