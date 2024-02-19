using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab2.Pages.Hub
{
    public class EditSpaceModel : PageModel
    {
        [BindProperty]
        public Collaboration SpaceToUpdate { get; set; }

        public EditSpaceModel()
        {
            SpaceToUpdate = new Collaboration();
        }

        public IActionResult OnGet(int collabid)
        {
            if (HttpContext.Session.GetString("UserName") != null) //by now, the UserName parameter and its value has already been validated
            {
                SqlDataReader singleCollab = DBClass.SingleCollabReader(collabid);
                while (singleCollab.Read())
                {
                    SpaceToUpdate.CollabID = collabid;
                    SpaceToUpdate.TeamName = singleCollab["TeamName"].ToString();
                    SpaceToUpdate.NotesAndInformation = singleCollab["NotesAndInformation"].ToString();
                }
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
            DBClass.UpdateSpace(SpaceToUpdate);
            DBClass.Lab2DBConnection.Close();
            return RedirectToPage("Index");
        }
    }
}
