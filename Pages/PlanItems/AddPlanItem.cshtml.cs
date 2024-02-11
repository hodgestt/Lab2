//Jessica Shamloo

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
        [BindProperty]//foreign key
        public int PlanID { get; set; }

        [BindProperty]
        public String PlanItemDescription { get; set; }
        [BindProperty] 
        public String StepsCompleted { get; set; }

        [BindProperty]
        [Required]
        public PlanItem NewPlanItem { get; set; }

        
        public List<SelectListItem> PlanOptions { get; set; }


        //public void OnGet()
        //{
        //    SqlDataReader PlanReader = DBClass.GeneralReaderQuery("SELECT * FROM Plans");

        //    PlanOptions = new List<SelectListItem>();

        //    while (PlanReader.Read())
        //    {
        //        PlanOptions.Add(
        //            new SelectListItem(
        //                PlanReader["PlanID"].ToString()));
        //    }

        //    DBClass.Lab1DBConnection.Close();
        //}

        public IActionResult OnPost()
        {
            if (NewPlanItem.PlanItemDescription == "Test Description")
            {
                return RedirectToPage("Index");
            }
            if (NewPlanItem.PlanItemDescription != null & NewPlanItem.StepsCompleted != null & NewPlanItem.PlanID !=null)
            {

                string insertQuery = "INSERT INTO PlanItem (PlanID, PlanItemDescription, StepsCompleted) VALUES (";
                insertQuery += PlanID + "," + PlanItemDescription + "," + StepsCompleted + ")";
                DBClass.GeneralInsertQuery(insertQuery);
                DBClass.Lab1DBConnection.Close();
                return RedirectToPage("Index");
            }
            return Page();
        }

        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            NewPlanItem.PlanID = 1;
            NewPlanItem.PlanItemDescription = "Test Description";
            NewPlanItem.StepsCompleted = "Test Steps Completed";
            return Page(); //will return the page items page without anything
        }


    }
}

