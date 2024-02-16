//Nick Patterson
// "import statements"
using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab2.Pages.Plan
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
                    DateCreated = ((DateTime)TableReader["DateCreated"])
                }

            );
            }

            // Close your connection in DBClass
            DBClass.Lab2DBConnection.Close();
        }
    }
}