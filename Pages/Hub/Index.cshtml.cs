using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab2.Pages.Hub
{
    public class HubModel : PageModel
    {
        public int CollabID { get; set; }

        public List<Collaboration> CollaborationTable { get; set; }

        public HubModel()
        {
            CollaborationTable = new List<Collaboration>();
        }

        public IActionResult OnGet(int planId, string planName)
        {
            if (HttpContext.Session.GetString("UserName") != null) //by now, the UserName parameter and its value has already been validated
            {
                SqlDataReader TableReader = DBClass.CollabReader();

                while (TableReader.Read())
                {
                    CollaborationTable.Add(new Collaboration
                    {
                        CollabID = Int32.Parse(TableReader["CollabID"].ToString()),
                        TeamName = TableReader["TeamName"].ToString(),
                        NotesAndInformation = TableReader["NotesAndInformation"].ToString()
                    });
                }
                DBClass.Lab2DBConnection.Close(); // Close the reader after use
                
                string CollabReader = "Select CollabID From Collaboration where CollabID = '" + CollabID + "'";

                CollabID = DBClass.GetCollabID(CollabReader);

                HttpContext.Session.SetInt32("CollabID", CollabID);

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


        
   

