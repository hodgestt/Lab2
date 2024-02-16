//Thomas Hodges
// "import statements"
using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace Lab2.Pages.DataFiles
{
    public class IndexModel : PageModel
    {
        public List<DataFile> DataTable { get; set; }

        public List<SelectListItem> DataList { get; set; } = new();

        [BindProperty]
        public int DataID { get; set; }

        public IndexModel()
        {
            DataTable = new List<DataFile>();
        }

        public void OnGet(int DataID)
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

            SqlDataReader DataReader = DBClass.GeneralReaderQuery("SELECT DataID, DataName FROM DataFile");
            DataList = new List<SelectListItem>();
            while (DataReader.Read())
            {
                DataList.Add(new SelectListItem
                {
                    Text = DataReader["DataName"].ToString(),
                    Value = DataReader["DataID"].ToString()
                });
            }
            DBClass.Lab2DBConnection.Close(); // Close the reader after use
        }
        public IActionResult OnPost()
        {
            SqlDataReader DataReader = DBClass.GeneralReaderQuery("SELECT DataID, DataName FROM DataFile");
            DataList = new List<SelectListItem>();
            while (DataReader.Read())
            {
                DataList.Add(new SelectListItem
                {
                    Text = DataReader["DataName"].ToString(),
                    Value = DataReader["DataID"].ToString()
                });
            }
            DBClass.Lab2DBConnection.Close(); // Close the reader after use

            return RedirectToPage("/CityDatas/Index");
        }
        }
}
    


