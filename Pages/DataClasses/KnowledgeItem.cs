//Jessica Shamloo

using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

namespace Lab1Part3.Pages.DataClasses
{
    public class KnowledgeItem
    {
        public int KnowledgeId { get; set; }
        [BindProperty]
        [Required]
        public String? Name { get; set;}
        [BindProperty]
        [Required]
        public String? Subject { get; set;}
        [BindProperty]
        [Required]
        public String? Category { get; set;}
        [BindProperty]
        [Required]
        public String? Information { get; set;}
        [BindProperty]
        [Required]
        public DateTime? KnowledgeDateTime { get; set;} 

    }

    //secondary custom method
    public IActionResult OnPostPopulateHandler()
    {
        ModelState.Clear();
        Name = "Test Name"; //changing property to show on the UI
        Subject = "Test Subject";
        Category = "Test Category";

        return Page();

    }





}

