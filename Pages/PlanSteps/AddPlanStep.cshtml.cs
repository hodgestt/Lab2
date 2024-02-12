//Jessica Shamloo

using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Lab1Part3.Pages.PlanSteps
{
    public class AddPlanStepModel : PageModel
    {
        [BindProperty]//foreign key
        public int PlanID { get; set; }

        [BindProperty]
        [Required]
        public PlanStep NewPlanStep { get; set; }

        
        public void OnGet() 
        { }
       

        public IActionResult OnPost()
        {
            if (NewPlanStep.PlanID == 1000)
            {
                return RedirectToPage("Index");
            }
            if (NewPlanStep.PlanID != null & NewPlanStep.StepDescription != null & NewPlanStep.Status != null)
            {
                DBClass.InsertPlanStep(NewPlanStep);

                DBClass.Lab1DBConnection.Close();

                return RedirectToPage("Index");
            }
            return Page();
        }

        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            NewPlanStep.PlanID = 1000;
            NewPlanStep.StepDescription = "Test Description";
            NewPlanStep.Status = "Test Status";
            return Page(); //will return the plan steps page without anything
        }


    }
}

