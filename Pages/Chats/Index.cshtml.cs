//Nick Patterson
// "import statements"
using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Lab1Part3.Pages.Chats
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Chat NewChat { get; set; } = new();

        public List<Chat> ChatsTable { get; set; }

        public IndexModel()
        {
            ChatsTable = new List<Chat>();
        }

        public void OnGet()
        {
            SqlDataReader TableReader = DBClass.ChatReader();
            while (TableReader.Read())
            {
                ChatsTable.Add(new Chat
                {
                    ChatID = Int32.Parse(TableReader["ChatID"].ToString()),
                    ChatMessage = TableReader["ChatMessage"].ToString(),
                    ChatDateTime = TableReader["ChatDateTime"].ToString(),
                    CollabID = Int32.Parse(TableReader["CollabID"].ToString()),
                    EmployeeID = Int32.Parse(TableReader["EmployeeID"].ToString())
                }
            );
            }
            // Close your connection in DBClass
            DBClass.Lab1DBConnection.Close();
        }

        public IActionResult OnPost()
        {
            
                DBClass.InsertChat(NewChat);
                DBClass.Lab1DBConnection.Close();
                
            
            return Page();

        }
    }
}