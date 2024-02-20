using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab2.Pages.Plan
{
    public class EditPlanModel : PageModel
    {
        [BindProperty]
        public Plans PlanToUpdate { get; set; }

        public EditPlanModel()
        {
            PlanToUpdate = new Plans();
        }

        public IActionResult OnGet(int planid)
        {
            if (HttpContext.Session.GetString("UserName") != null) //by now, the UserName parameter and its value has already been validated
            {
                SqlDataReader singlePlan = DBClass.SinglePlanReader(planid);
                while (singlePlan.Read())
                {
                    PlanToUpdate.PlanID = planid;
                    PlanToUpdate.PlanName = singlePlan["PlanName"].ToString();
                    PlanToUpdate.PlanConcept = singlePlan["PlanConcept"].ToString();
                    PlanToUpdate.DateCreated = (DateTime)singlePlan["DateCreated"];
                    PlanToUpdate.CollabID = Int32.Parse(singlePlan["CollabID"].ToString());
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
            DBClass.UpdatePlan(PlanToUpdate);
            DBClass.Lab2DBConnection.Close();
            return RedirectToPage("Index");
        }
    }
}
