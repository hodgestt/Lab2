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

        public IActionResult OnGet(int DataID)
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
            DBClass.Lab2DBConnection.Close();

            if (HttpContext.Session.GetString("UserName") != null) //by now, the UserName parameter and its value has already been validated
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

                return Page();
            }
            else
            {
                //creates a String with key of "LoginError" and a vlue of "You must login to access that page"
                HttpContext.Session.SetString("LoginError", "You must login to access that page!");

                return RedirectToPage("/Login/DBLogin");
            }
            
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

            int selectedDataID = DataID;
            string redirectUrl;

            switch (selectedDataID)
            {
                case 1:
                    redirectUrl = "/GroceryDatas/Index";
                    break;
                case 2:
                    redirectUrl = "/CityDatas/Index";
                    break;
                default:
                    redirectUrl = "/DataFiles/Index";
                    break;
            }
            return RedirectToPage(redirectUrl);
        }
        }
}
    


