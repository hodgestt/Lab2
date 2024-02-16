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
                    KnowledgeDateTime = ((DateTime)TableReader["KnowledgeDateTime"])
                }
            );
            }

            // Close your connection in DBClass
            DBClass.Lab2DBConnection.Close();
        }

        

        
    }
}

