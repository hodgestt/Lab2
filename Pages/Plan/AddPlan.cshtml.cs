using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace Lab1Part3.Pages.Plan
{
    public class AddPlanModel : PageModel
    {
        [BindProperty]
        [Required]
        public Plans NewPlan { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (NewPlan.PlanName == "Test Plan Name")
            {
                return RedirectToPage("Index");
            }
            if (NewPlan.PlanName != null & NewPlan.PlanConcept != null & NewPlan.DateCreated != null) { 
                DBClass.InsertPlan(NewPlan);
                DBClass.Lab1DBConnection.Close();
                return RedirectToPage("Index");
            }
            return Page();

        }

        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            NewPlan.PlanName = "Test Plan Name";
            NewPlan.PlanConcept = "Test Concept";
            NewPlan.DateCreated = "Test Date";
            return Page(); //Page method inherited from Page class
        }


    }
}
