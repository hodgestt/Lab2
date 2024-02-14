//Thomas Hodges
// "import statements"
using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab2.Pages.DataFiles
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
            DBClass.Lab2DBConnection.Close();
        }
    }
}
    


