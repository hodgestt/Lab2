//Nick Patterson
// "import statements"
using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab1Part3.Pages.Plan
{
    public class IndexModel : PageModel
    {

        public List<Plans> PlansTable { get; set; }

        public IndexModel()
        {
            PlansTable = new List<Plans>();
        }

        public void OnGet()
        {
            SqlDataReader TableReader = DBClass.PlansReader();
            while (TableReader.Read())
            {
                PlansTable.Add(new Plans
                {
                    PlanID = Int32.Parse(TableReader["PlanID"].ToString()),
                    PlanName = TableReader["PlanName"].ToString(),
                    PlanConcept = TableReader["PlanConcept"].ToString(),
                    DateCreated = TableReader["DateCreated"].ToString()
                }
                
            );
            }
        
            // Close your connection in DBClass
            DBClass.Lab1DBConnection.Close();
        }
    }
}