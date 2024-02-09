using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab1Part3.Pages.Collaborations
{
    public class CollaborationsPageModel : PageModel
    {
        public List<Collaboration> CollaborationTable { get; set; }

        public CollaborationsPageModel()
        {
            CollaborationTable = new List<Collaboration>();
        }

        public void OnGet()
        {
            SqlDataReader TableReader = DBClass.TableReader();
            while (TableReader.Read())
            {
                CollaborationTable.Add(new Collaboration
                {
                    CollabID = int.Parse(TableReader["CollabID"].ToString()),
                    TeamName = TableReader["NotesAndInformation"].ToString(),
                    NotesAndInformation = TableReader["NotesAndInformation"].ToString()
                }
                );
            }

            //add any onPost() or IActionHandler method if needed


            DBClass.Lab1DBConnection.Close();
        }
    }
}

