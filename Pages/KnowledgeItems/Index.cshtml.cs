// "import statements"
using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

namespace Lab1Part3.Pages.KnowledgeItems
{
    public class IndexModel : PageModel
    {
        public List<KnowledgeItem> KnowledgeItemsTable { get; set; }

        public IndexModel()
        {
            KnowledgeItemsTable = new List<KnowledgeItem>();
        }

        public void OnGet()
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
                    KnowledgeDateTime = TableReader["KnowledgeDateTime"].ToString()
                }
            );
            }

            // Close your connection in DBClass
            DBClass.Lab1DBConnection.Close();
        }

        

        
    }
}

