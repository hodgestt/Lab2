using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Pages.SWOTs
{
    public class AddSWOTModel : PageModel
    {
        [BindProperty]
        [Required]
        public SWOT NewSWOT { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (NewSWOT.Strengths == "Test Strengths")
            {
                return RedirectToPage("Index");
            }
            if (NewSWOT.Strengths != null & NewSWOT.Weaknesses != null & NewSWOT.Opportunities != null & NewSWOT.Threats != null & NewSWOT.CollabID != null & NewSWOT.KnowledgeId != null)
            {
                DBClass.InsertSWOT(NewSWOT);
                DBClass.Lab2DBConnection.Close();
                return RedirectToPage("Index");
            }
            return Page();

        }

        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            NewSWOT.Strengths = "Test Strengths";
            NewSWOT.Weaknesses = "Test Weaknesses";
            NewSWOT.Opportunities = "Test Opportunities";
            NewSWOT.Threats = "Test Threats";
            NewSWOT.CollabID = 0;
            return Page(); //Page method inherited from Page class
        }
    }


}
