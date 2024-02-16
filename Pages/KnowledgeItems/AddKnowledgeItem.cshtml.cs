//Jessica Shamloo

using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Lab2.Pages.KnowledgeItems
{
    public class AddKnowledgeItemModel : PageModel
    {

        [BindProperty]
        [Required]
        public KnowledgeItem NewKnowledgeItem { get; set; }


        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("UserName") != null) //by now, the UserName parameter and its value has already been validated
            {
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
            if (NewKnowledgeItem.Name == "Test Name")
            {
                return RedirectToPage("Index");
            }
            if (NewKnowledgeItem.Name != null & NewKnowledgeItem.Subject != null & NewKnowledgeItem.Category != null & NewKnowledgeItem.Information != null & NewKnowledgeItem.KnowledgeDateTime != null )
            {
                DBClass.InsertKnowledgeItem(NewKnowledgeItem);
                DBClass.Lab2DBConnection.Close();
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
            return Page(); //Page method inherited from Page class
        }





    }
}
