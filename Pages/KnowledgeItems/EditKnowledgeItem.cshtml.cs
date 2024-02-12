using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab1Part3.Pages.KnowledgeItems
{
    public class EditKnowledgeItemModel : PageModel
    {

        [BindProperty]
        public KnowledgeItem KnowledgeItemToUpdate { get; set; }

        public EditKnowledgeItemModel()
        {
            KnowledgeItemToUpdate = new KnowledgeItem();
        }


        public void OnGet(int knowledgeid)
        {
            SqlDataReader singleKnowledgeItem = DBClass.EditSingleKnowledge(knowledgeid);
            while (singleKnowledgeItem.Read())
            {
                KnowledgeItemToUpdate.KnowledgeId = knowledgeid;
                KnowledgeItemToUpdate.Name = singleKnowledgeItem["Name"].ToString();
                KnowledgeItemToUpdate.Subject  = singleKnowledgeItem["Subject"].ToString();
                KnowledgeItemToUpdate.Category = singleKnowledgeItem["Category"].ToString();
                KnowledgeItemToUpdate.Information = singleKnowledgeItem["Information"].ToString();
                KnowledgeItemToUpdate.KnowledgeDateTime = singleKnowledgeItem["KnowledgeDateTime"].ToString();
                KnowledgeItemToUpdate.EmployeeID = Int32.Parse(singleKnowledgeItem["EmployeeID"].ToString());
                
            }
            DBClass.Lab1DBConnection.Close();

        }
    }
}
