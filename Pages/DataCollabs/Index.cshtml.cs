// Nick Patterson "import statements"
using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab2.Pages.DataCollabs
{
    public class IndexModel : PageModel
    {

        public List<DataCollab> DataCollabsTable { get; set; }

        public IndexModel()
        {
            DataCollabsTable = new List<DataCollab>();
        }

        public void OnGet()
        {
            SqlDataReader TableReader = DBClass.DataCollabReader();
            while (TableReader.Read())
            {
                DataCollabsTable.Add(new DataCollab
                {
                    CollabID = Int32.Parse(TableReader["CollabID"].ToString()),
                    DataID = Int32.Parse(TableReader["DataID"].ToString())
                }
            );
            }
        
            // Close your connection in DBClass
            DBClass.Lab2DBConnection.Close();
        }
    }
}
