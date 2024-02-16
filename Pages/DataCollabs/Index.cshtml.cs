// Nick Patterson "import statements"
using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
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


        public IActionResult OnGet()
        {

            if (HttpContext.Session.GetString("UserName") != null) //by now, the UserName parameter and its value has already been validated
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

                return Page();
            }
            else
            {
                //creates a String with key of "LoginError" and a vlue of "You must login to access that page"
                HttpContext.Session.SetString("LoginError", "You must login to access that page!");

                return RedirectToPage("/Login/DBLogin");
            }
        }
    }
}
