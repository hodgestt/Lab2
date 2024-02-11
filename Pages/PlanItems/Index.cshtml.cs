//Nick Patterson
// "import statements"
using System.Data.SqlClient;
using System.Numerics;
using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab1Part3.Pages.PlanItems
{
    public class IndexModel : PageModel
    {

        public List<PlanItem> PlanItemsTable { get; set; }


        public IndexModel()
        {
            PlanItemsTable = new List<PlanItem>();
        }

        public void OnGet()
        {}
    }
}





