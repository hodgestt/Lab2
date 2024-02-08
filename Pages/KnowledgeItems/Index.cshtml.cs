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
            SqlDataReader TableReader = DBClass.TableReader();
            while (TableReader.Read())
            {
                KnowledgeItemsTable.Add(new KnowledgeItem
                {

                    KnowledgeItemId = Int32.Parse(TableReader["KnowledgeItemID"].ToString()),
                    Name = TableReader["Name"].ToString(),
                    Subject = TableReader["Subject"].ToString(),
                    Category = TableReader["Category"].ToString(),
                    Information = TableReader["Information"].ToString(),
                    KnowledgeDateTime = DateTime.Parse(TableReader["KnowledgeDateTime"].ToString())
                }
                );
            }

            // Close your connection in DBClass
            DBClass.LABTHREEDBConnection.Close();
        }
    }
}