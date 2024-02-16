using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab2.Pages.KnowledgeItems
{
    public class EditKnowledgeItemModel : PageModel
    {

        [BindProperty]
        public KnowledgeItem KnowledgeItemToUpdate { get; set; }

        public EditKnowledgeItemModel()
        {
            KnowledgeItemToUpdate = new KnowledgeItem();
        }


        public IActionResult OnGet(int knowledgeid)
        {
            if (HttpContext.Session.GetString("UserName") != null) //by now, the UserName parameter and its value has already been validated
            {

                SqlDataReader singleKnowledgeItem = DBClass.EditSingleKnowledge(knowledgeid);
                while (singleKnowledgeItem.Read())
                {
                    KnowledgeItemToUpdate.KnowledgeId = knowledgeid;
                    KnowledgeItemToUpdate.Name = singleKnowledgeItem["Name"].ToString();
                    KnowledgeItemToUpdate.Subject = singleKnowledgeItem["Subject"].ToString();
                    KnowledgeItemToUpdate.Category = singleKnowledgeItem["Category"].ToString();
                    KnowledgeItemToUpdate.Information = singleKnowledgeItem["Information"].ToString();
                    KnowledgeItemToUpdate.KnowledgeDateTime = ((DateTime)singleKnowledgeItem["KnowledgeDateTime"]);
                    KnowledgeItemToUpdate.EmployeeID = Int32.Parse(singleKnowledgeItem["EmployeeID"].ToString());

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
            DBClass.UpdateKnowledgeItem(KnowledgeItemToUpdate);
            DBClass.Lab2DBConnection.Close();
            return RedirectToPage("Index");
        }
    }
}
