//Nick Patterson
// "import statements"
using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

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
        {
            SqlDataReader TableReader = DBClass.PlanItemReader();
            while (TableReader.Read())
            {
                PlanItemsTable.Add(new PlanItem
                {

                    PlanItemID = Int32.Parse(TableReader["PlanItemID"].ToString()),
                    PlanItemDescription = TableReader["PlanItemDescription"].ToString(),
                    StepsCompleted = TableReader["StepsCompleted"].ToString()

                }
            );
            }

            // Close your connection in DBClass
            DBClass.Lab1DBConnection.Close();
        }
    }
}
    


