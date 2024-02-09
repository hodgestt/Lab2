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
            DBClass.InsertKnowledgeItem(NewKnowledgeItem);
            DBClass.Lab1DBConnection.Close();
            return RedirectToPage("Index");

        }
        




    }
}
