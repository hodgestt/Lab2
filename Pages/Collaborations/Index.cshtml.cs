using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace Lab1Part3.Pages.Collaborations
{
    public class IndexModel : PageModel
    {
        public List<Collaboration> CollaborationTable { get; set; }

        public List<SelectListItem> Knowledges { get; set; }

        public List<SelectListItem> EmployeeList { get; set; }

        public int EmployeeID { get; set; }

        public IndexModel()
        {
            CollaborationTable = new List<Collaboration>();
        }

        public void OnGet()
        {
            SqlDataReader TableReader = DBClass.CollabReader();
            while (TableReader.Read())
            {
                CollaborationTable.Add(new Collaboration
                {
                    CollabID = int.Parse(TableReader["CollabID"].ToString()),
                    TeamName = TableReader["TeamName"].ToString(),
                    NotesAndInformation = TableReader["NotesAndInformation"].ToString()
                }
                );
            }

            DBClass.Lab1DBConnection.Close();

          
            // Populate the Knowledge Item SELECT control
            SqlDataReader EmployeeReader = DBClass.GeneralReaderQuery("SELECT EmployeeID, CONCAT(FirstName, ' ', LastName) AS Name FROM Employee");

            EmployeeList = new List<SelectListItem>();

            while (EmployeeReader.Read())
            {
                EmployeeList.Add(
                    new SelectListItem(
                        EmployeeReader["Name"].ToString(),
                        EmployeeReader["EmployeeID"].ToString()));
            }

            DBClass.Lab1DBConnection.Close();



        }
        public IActionResult OnPost()
        {
            SqlDataReader KnowledgesReader = DBClass.GeneralReaderQuery("SELECT * FROM KnowledgeItem");
            
            while (KnowledgesReader.Read())
            {
                Knowledges.Add(
                    new SelectListItem(
                        KnowledgesReader["Name"].ToString(),
                        KnowledgesReader["KnowledgeId"].ToString()));
            }

            DBClass.Lab1DBConnection.Close();

            return RedirectToPage("Index");
        }
    }
}

