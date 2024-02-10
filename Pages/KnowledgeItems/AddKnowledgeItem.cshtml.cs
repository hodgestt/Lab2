//Jessica Shamloo

using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Lab1Part3.Pages.KnowledgeItems
{
    public class AddKnowledgeItemModel : PageModel
    {

        [BindProperty]
        [Required]
        public KnowledgeItem NewKnowledgeItem { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (NewKnowledgeItem.Name != "Test Name" & NewKnowledgeItem.Subject != null & NewKnowledgeItem.Category != null & NewKnowledgeItem.Information != null & NewKnowledgeItem.KnowledgeDateTime != null )
            {
                DBClass.InsertKnowledgeItem(NewKnowledgeItem);
                DBClass.Lab1DBConnection.Close();
                return RedirectToPage("Index");
            }
            return Page();

        }

        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            NewKnowledgeItem.Name = "Test Name";
            NewKnowledgeItem.Subject = "Test Subject";
            NewKnowledgeItem.Category = "Test Category";
            NewKnowledgeItem.Information = "Test Information";
            NewKnowledgeItem.KnowledgeDateTime = "Test KnowledgeDateTime";
            return Page(); //Page method inherited from Page class
        }





    }
}
