using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace Lab2.Pages.Plan
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
                return RedirectToPage("/Collaborations/Index");
            }
            if (NewPlan.PlanName != null & NewPlan.PlanConcept != null & NewPlan.DateCreated != null) { 
                DBClass.InsertPlan(NewPlan);
                DBClass.Lab2DBConnection.Close();
                return RedirectToPage("/Collaborations/Index");
            }
            return Page();

        }

        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            NewPlan.PlanName = "Test Plan Name";
            NewPlan.PlanConcept = "Test Concept";
            return Page(); //Page method inherited from Page class
        }


    }
}
