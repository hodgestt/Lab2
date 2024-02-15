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
        
        [BindProperty]//foreign key
        public int PlanID { get; set; }

        [BindProperty]
        [Required]
        public PlanStep NewPlanStep { get; set; }


        public void OnGet(int planid)
        {
            
            SqlDataReader reader = DBClass.PlanStepReader(planid);
            while (reader.Read())
            {

                NewPlanStep.PlanID = planid;
                //NewPlanStep.StepID = Int32.Parse(reader["StepID"].ToString());
                //NewPlanStep.StepDescription = reader["StepDescription"].ToString();
                //NewPlanStep.Status = reader["Status"].ToString();
            }
            DBClass.Lab2DBConnection.Close();
        }

        public IActionResult OnPost()
        {
            if (NewPlanStep.StepDescription == "Test Description")
            {
                return RedirectToPage("Index");
            }
            if (NewPlanStep.StepDescription != null & NewPlanStep.Status != null)
            {
                DBClass.InsertPlanStep(NewPlanStep);

                DBClass.Lab2DBConnection.Close();

                return RedirectToPage("/Plan/Index");
            }
            return Page();
        }

        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            NewPlanStep.StepDescription = "Test Description";
            NewPlanStep.Status = "Test Status";
            return Page(); //will return the plan steps page without anything
        }


    }
}

