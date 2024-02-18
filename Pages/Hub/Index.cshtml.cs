using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab2.Pages.Hub
{
    public class HubModel : PageModel
    {


        public List<Collaboration> CollaborationTable { get; set; }

        public HubModel()
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
                    CollabID = Int32.Parse(TableReader["CollabID"].ToString()),
                    TeamName = TableReader["TeamName"].ToString(),
                    NotesAndInformation = TableReader["NotesAndInformation"].ToString()
                });
            }
            DBClass.Lab2DBConnection.Close(); // Close the reader after use


        }
    }
}
