//Jessica Shamloo

using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Xml.Linq;

namespace Lab2.Pages.PlanSteps
{
    
    public class AddPlanStepModel : PageModel
    {

        [BindProperty(SupportsGet =true)]
        public string? PlanName { get; set; }

        [BindProperty(SupportsGet = true)]//foreign key
        public int PlanID { get; set; }

        [BindProperty]
        [Required]
        public PlanStep NewPlanStep { get; set; }

        public AddPlanStepModel()
        {

            NewPlanStep = new PlanStep();//instantiates the object, car in driveway before you reference. new PlanStep()
        }


        public IActionResult OnGet(int planId, string planName)
        {
            if (HttpContext.Session.GetString("UserName") != null) //by now, the UserName parameter and its value has already been validated
            {
                PlanName = planName;
                //PlanID = planId;
                NewPlanStep.PlanID = planId;

                //SqlDataReader reader = DBClass.PlanStepReader(planId);
                //while (reader.Read())
                //{

                //    NewPlanStep.PlanID = planId;

                //}
                //DBClass.Lab2DBConnection.Close();

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
            if (NewPlanStep.StepDescription == "Test Description")
            {
                return Page();//originally Page() but how can i return to the add step page which still knew the planid
            }
            if (NewPlanStep.StepDescription != null & NewPlanStep.Status != null)
            {
                DBClass.InsertPlanStep(NewPlanStep);

                DBClass.Lab2DBConnection.Close();

                return RedirectToPage("/Plan/Index"); //need it to redirect to the previous page with the plan id in memory
            }
            return Page();
        }

        public IActionResult OnPostPopulateHandler() 
        {
            ModelState.Clear();
            NewPlanStep.StepDescription = "Test Description";
            NewPlanStep.Status = "Test Status";
            return Page(); //will return the plan steps page without anything. Loses the understanding of which planid it needs
        }


    }
}

