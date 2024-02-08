// Nick Patterson "import statements"
using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab1Part3.Pages.DataCollabs
{
    public class IndexModel : PageModel
    {

        public List<DataCollab> DataCollabTable { get; set; }

        public IndexModel()
        {
            DataCollabTable = new List<DataCollab>();
        }

        public void OnGet()
        {
            SqlDataReader TableReader = DBClass.TableReader();
            while (Table.Read())
            {
                DataCollabTable.Add(new DataCollab
                {

                    CollabID = Int32.Parse(DataCollabReader["CollabID"].ToString()),
                    DataName = DataCollabReader["DataName"].ToString(),
                }
            );
            }
        
            // Close your connection in DBClass
            DBClass.LABTHREEDBConnection.Close();
        }
    }
}
