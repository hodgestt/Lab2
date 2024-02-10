//Nick Patterson
// "import statements"
using System.Data.SqlClient;
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
    


