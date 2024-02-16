// "import statements"
using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Pages.KnowledgeItems
{
    public class IndexModel : PageModel
    {
        public List<KnowledgeItem> KnowledgeItemsTable { get; set; }

        public IndexModel()
        {
            KnowledgeItemsTable = new List<KnowledgeItem>();
        }

        public IActionResult OnGet()
        {

            if (HttpContext.Session.GetString("UserName") != null) //by now, the UserName parameter and its value has already been validated
            {
                SqlDataReader TableReader = DBClass.KnowledgeItemReader();
                while (TableReader.Read())
                {
                    KnowledgeItemsTable.Add(new KnowledgeItem
                    {
                        KnowledgeId = Int32.Parse(TableReader["KnowledgeId"].ToString()),
                        Name = TableReader["Name"].ToString(),
                        Subject = TableReader["Subject"].ToString(),
                        Category = TableReader["Category"].ToString(),
                        Information = TableReader["Information"].ToString(),
                        KnowledgeDateTime = ((DateTime)TableReader["KnowledgeDateTime"])
                    }
                );
                }

                // Close your connection in DBClass
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
    }
}

