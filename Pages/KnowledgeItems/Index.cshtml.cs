// "import statements"
using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

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
                    KnowledgeId = Int32.Parse(TableReader["KnowledgeId"].ToString()),
                    Name = TableReader["Name"].ToString(),
                    Subject = TableReader["Subject"].ToString(),
                    Category = TableReader["Category"].ToString(),
                    Information = TableReader["Information"].ToString(),
                    KnowledgeDateTime = DateTime.Parse(TableReader["KnowledgeDateTime"].ToString())
                }
            );
            }

            // Close your connection in DBClass
            DBClass.Lab1DBConnection.Close();
        }
    }
}
