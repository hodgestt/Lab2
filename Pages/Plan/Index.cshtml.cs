//Nick Patterson
// "import statements"
using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab2.Pages.Plan
{
    public class IndexModel : PageModel
    {

        public List<Plans> PlansTable { get; set; }

        public IndexModel()
        {
            PlansTable = new List<Plans>();
        }

        [BindProperty]
        public int CollabID { get; set; }

        public IActionResult OnGet(int collabid)
        {
            if (HttpContext.Session.GetString("UserName") != null) //by now, the UserName parameter and its value has already been validated
            {

                SqlDataReader TableReader = DBClass.PlansReader(collabid);
                while (TableReader.Read())
                {
                    PlansTable.Add(new Plans
                    {
                        CollabID = collabid,
                        PlanID = Int32.Parse(TableReader["PlanID"].ToString()),
                        PlanName = TableReader["PlanName"].ToString(),
                        PlanConcept = TableReader["PlanConcept"].ToString(),
                        DateCreated = ((DateTime)TableReader["DateCreated"])
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