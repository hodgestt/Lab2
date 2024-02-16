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

        public IndexModel()
        {
            PlanStepsTable = new List<PlanStep>();
            
        }

        public void OnGet(int PlanID)
        {
            SqlDataReader TableReader = DBClass.PlanStepReader(PlanID);
            while (TableReader.Read())
            {
                PlanStepsTable.Add(new PlanStep
                {
                    //StepID = Int32.Parse(TableReader["StepID"].ToString()),
                    PlanID = Int32.Parse(TableReader["PlanID"].ToString()),
                    StepDescription = TableReader["StepDescription"].ToString(),
                    Status = TableReader["Status"].ToString()
                }
            );
            }

            // Close your connection in DBClass
            DBClass.Lab2DBConnection.Close();
        }

    }
    
}





