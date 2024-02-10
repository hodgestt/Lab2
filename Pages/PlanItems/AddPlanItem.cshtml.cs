using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Lab1Part3.Pages.PlanItems
{
    public class AddPlanItemModel : PageModel
    {
        [BindProperty]
        [Required]
        public PlanItem NewPlanItem { get; set; }

        [BindProperty]//foreign key
        public int PlanID { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (NewPlanItem.PlanItemDescription == "Test PlanItem Description")
            {
                return RedirectToPage("Index");
            }
            if (NewPlanItem.PlanItemDescription != null & NewPlanItem.StepsCompleted != null)
            {
                DBClass.InsertPlanItem(NewPlanItem);
                DBClass.Lab1DBConnection.Close();
                return RedirectToPage("Index");
            }
            return Page();

        }

        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            NewPlanItem.PlanItemDescription = "Test PlanItem Description";
            NewPlanItem.StepsCompleted= "Test Steps";
            return Page(); //Page method inherited from Page class
        }


    }
}

