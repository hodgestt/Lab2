//Jessica Shamloo

// "import statements"
using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Globalization;

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
            SqlDataReader knowledgeitemsReader = DBClass.KnowledgeItemReader();
            while (knowledgeitemsReader.Read())
            {
                KnowledgeItemsTable.Add(new KnowledgeItem
                {

                    KnowledgeItemId = Int32.Parse(knowledgeitemsReader["KnowledgeItemID"].ToString()),
                    Name = knowledgeitemsReader["Name"].ToString(),
                    Subject = knowledgeitemsReader["Subject"].ToString(),
                    Category = knowledgeitemsReader["Category"].ToString(),
                    Information = knowledgeitemsReader["Information"].ToString(),
                    KnowledgeDateTime = DateTime.Parse(knowledgeitemsReader["KnowledgeDateTime"].ToString())
                }
                );
            }

            // Close your connection in DBClass
            DBClass.LABTHREEDBConnection.Close();
        }
    }
}