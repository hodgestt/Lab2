//Nick Patterson
// "import statements"
using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Xml.Linq;

namespace Lab2.Pages.Chats
{
    public class IndexModel : PageModel
    {
        
        public int ChatID { get; set; }

        public string UserName { get; set; }
        

        public int? EmployeeId { get; set; }

        [BindProperty]
        public Chat NewChats { get; set; }


        public string ChatMessage { get; set; }
        
        [BindProperty]      
        public List<Chat> NewChat { get; set; }

        public IndexModel()
        {
            NewChat = new List<Chat>();
        }

        public IActionResult OnGet()
        {

            if (HttpContext.Session.GetString("UserName") != null) //by now, the UserName parameter and its value has already been validated
            { 

                SqlDataReader TableReader = DBClass.ChatReader();
                while (TableReader.Read())
                {

                    NewChat.Add(new Chat
                    {
                        ChatID = Int32.Parse(TableReader["ChatID"].ToString()),
                        UserName = TableReader["UserName"].ToString(),
                        ChatMessage = TableReader["ChatMessage"].ToString(),
                        ChatDateTime = ((DateTime)TableReader["ChatDateTime"])
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

        public IActionResult OnPost()
        {

            int? employeeId = HttpContext.Session.GetInt32("EmployeeID");

            NewChats.EmployeeID = employeeId;


            DBClass.InsertChat(NewChats);


            DBClass.Lab2DBConnection.Close();


            SqlDataReader TableReader = DBClass.ChatReader();
            while (TableReader.Read())
            {
                NewChat.Add(new Chat
                {
                    ChatID = Int32.Parse(TableReader["ChatID"].ToString()),
                    ChatMessage = TableReader["ChatMessage"].ToString(),
                    ChatDateTime = ((DateTime)TableReader["ChatDateTime"]),
                    EmployeeID = Int32.Parse(TableReader["EmployeeID"].ToString())
                }
            );
            }
            return Page();
        }
    }
}