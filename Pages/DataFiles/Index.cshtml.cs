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
            SqlDataReader TableReader = DBClass.DataFileReader();
            while (TableReader.Read())
            {
                DataTable.Add(new DataFile
                {
                    DataID = Int32.Parse(TableReader["DataID"].ToString()),
                    DataName = TableReader["DataName"].ToString(),
                    DataLocation = TableReader["DataLocation"].ToString(),
                    DataDescription = TableReader["DataDescription"].ToString(),
                    
                    
                }
            );
            }

            // Close your connection in DBClass
            DBClass.Lab1DBConnection.Close();
        }
    }
}
    


