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

        [BindProperty]
        public int? CollabID { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("UserName") != null) //by now, the UserName parameter and its value has already been validated
            {
                //NewPlan.CollabID = collabid;
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
            if (NewPlan.PlanName == "Test Plan Name")
            {
                return RedirectToPage("/Hub/Index");
            }
            if (NewPlan.PlanName != null & NewPlan.PlanConcept != null & NewPlan.DateCreated != null) {
                
                DBClass.InsertPlan(NewPlan);
                DBClass.Lab2DBConnection.Close();
                return RedirectToPage("/Hub/Index");
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
