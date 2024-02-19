using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab2.Pages.SWOTs
{
    public class EditSWOTModel : PageModel
    {
        [BindProperty]
        public SWOT SWOTToUpdate { get; set; }

        public EditSWOTModel()
        {
            SWOTToUpdate = new SWOT();
        }


        public IActionResult OnGet(int swotid)
        {
            if (HttpContext.Session.GetString("UserName") != null) //by now, the UserName parameter and its value has already been validated
            {

                SqlDataReader singleSWOT = DBClass.EditSingleSWOT(swotid);
                while (singleSWOT.Read())
                {
                    SWOTToUpdate.SWOTID = swotid;
                    SWOTToUpdate.Strengths = singleSWOT["Strengths"].ToString();
                    SWOTToUpdate.Weaknesses = singleSWOT["Weaknesses"].ToString();
                    SWOTToUpdate.Opportunities = singleSWOT["Opportunities"].ToString();
                    SWOTToUpdate.Threats = singleSWOT["Threats"].ToString();
                    SWOTToUpdate.KnowledgeId = Int32.Parse(singleSWOT["KnowledgeId"].ToString());

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
            DBClass.UpdateSWOT(SWOTToUpdate);
            DBClass.Lab2DBConnection.Close();
            return RedirectToPage("Index");
        }
    }
}
