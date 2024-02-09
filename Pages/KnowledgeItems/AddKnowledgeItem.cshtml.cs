//Jessica Shamloo

using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab1Part3.Pages.KnowledgeItems
{
    public class AddKnowledgeItemModel : PageModel
    {

        [BindProperty]
        public KnowledgeItem? NewKnowledgeItem { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            DBClass.InsertKnowledgeItem(NewKnowledgeItem);
            DBClass.Lab1DBConnection.Close();
            return RedirectToPage("KnowledgeItems");

        }
    }
}
