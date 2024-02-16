//Jessica Shamloo & Nick Patterson

// "import statements"
using System.Data.SqlClient;
using System.Numerics;
using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab2.Pages.PlanSteps{
    
    public class IndexModel : PageModel
    {

        public List<PlanStep> PlanStepsTable { get; set; }

        [BindProperty]
        public int PlanID { get; set; }

        [BindProperty]
        public string PlanName { get; set; }

        public IndexModel()
        {
            PlanStepsTable = new List<PlanStep>();
            
        }

        public IActionResult OnGet(int PlanID, string planName)
        {
            if (HttpContext.Session.GetString("UserName") != null) //by now, the UserName parameter and its value has already been validated
            {

                PlanName = planName;

                SqlDataReader TableReader = DBClass.PlanStepReader(PlanID);
                while (TableReader.Read())
                {
                    PlanStepsTable.Add(new PlanStep
                    {
                        PlanID = Int32.Parse(TableReader["PlanID"].ToString()),
                        StepDescription = TableReader["StepDescription"].ToString(),
                        Status = TableReader["Status"].ToString()
                    }
                );
                }

                // Close your connection in DBClass
                DBClass.Lab2DBConnection.Close();

                return Page();
            }
            else
            {
                //creates a String with key of "LoginError" and a vlue of "You must login to access that page"
                HttpContext.Session.SetString("LoginError", "You must login to access that page!");

                return RedirectToPage("/Login/DBLogin");
            }
        }

    }
    
}





