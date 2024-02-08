//Nick Patterson
// "import statements"
using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab1Part3.Pages.Plans
{
    public class IndexModel : PageModel
    {

        public List<Plan> PlansTable { get; set; }

        public IndexModel()
        {
            PlansTable = new List<Plan>();
        }

        public void OnGet()
        {
            SqlDataReader TableReader = DBClass.TableReader();
            while (TableReader.Read())
            {
                PlansTable.Add(new Plan
                {

                    PlanName = TableReader["PlanName"].ToString(),
                    PlanConcept = TableReader["PlanConcept"].ToString(),
                    DateCreated = DateTime.Parse(TableReader["DateCreated"].ToString()),
                    AnalysisUsed = TableReader["AnalysisUsed"].ToString(),
                    CollabID = int.Parse(TableReader["CollabID"].ToString()),

                }
            );
            }
        
            // Close your connection in DBClass
            DBClass.Lab1DBConnection.Close();
        }
    }
}