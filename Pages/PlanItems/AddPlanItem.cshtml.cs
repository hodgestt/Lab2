using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Lab1Part3.Pages.PlanItems
{
    public class AddPlanItemModel : PageModel
    {
        [BindProperty]
        [Required]
        public PlanItem NewPlanItem { get; set; }

        [BindProperty]//foreign key
        public int PlanID { get; set; }

        public List<SelectListItem> PlansTable { get; set; }

        public void OnGet()
        {
            // Populate the Plans SELECT control
            SqlDataReader PlansReader = DBClass.GeneralReaderQuery("SELECT * FROM Plans");

            PlansTable = new List<SelectListItem>();

            while (PlansReader.Read())
            {
                PlansTable.Add(
                    new SelectListItem(PlansReader["Name"].ToString()));
            }

            DBClass.Lab1DBConnection.Close();
        }

        public IActionResult OnPost()
        {
            if (NewPlanItem.PlanItemDescription == "Test Description")
            {
                return RedirectToPage("Index");
            }
            if (NewPlanItem.PlanItemDescription != null & NewPlanItem.StepsCompleted != null)
            {
                DBClass.InsertPlanItem(NewPlanItem);
                DBClass.Lab1DBConnection.Close();
                return RedirectToPage("Index");
            }
            return Page();
        }

        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            NewPlanItem.PlanItemDescription = "Test Description";
            NewPlanItem.StepsCompleted = "Test Steps Completed";
            return Page(); //Page method inherited from Page class
        }


    }
}

