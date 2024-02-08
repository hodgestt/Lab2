//Thomas Hodges
// "import statements"
using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab1Part3.Pages.DataFiles
{
    public class IndexModel : PageModel
    {
        public List<DataFile> DataTable { get; set; }

        public IndexModel()
        {
            DataTable = new List<DataFile>();
        }

        public void OnGet()
        {
            SqlDataReader TableReader = DBClass.TableReader();
            while (TableReader.Read())
            {
                DataTable.Add(new DataFile
                {

                    DataName = TableReader["DataName"].ToString(),
                    DataLocation = TableReader["DataLocation"].ToString(),
                    DataDescription = TableReader["DataDescription"].ToString(),
                    //EmployeeID = TableReader["EmployeeID"].ToString()
                    
                }
            );
            }

            // Close your connection in DBClass
            DBClass.LABTHREEDBConnection.Close();
        }
    }
}
    


