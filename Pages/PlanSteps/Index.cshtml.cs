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

        public IndexModel()
        {
            PlanStepsTable = new List<PlanStep>();
        }

        public void OnGet()
        {}
    }
}





