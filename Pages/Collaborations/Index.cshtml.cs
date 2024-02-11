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

        public List<KnowledgeItem> Knowledges { get; set; }

        public List<SelectListItem> EmployeeList { get; set; }

        [BindProperty]
        public KnowledgeItem KnowledgeItemView { get; set; }


        public IndexModel()
        {
            CollaborationTable = new List<Collaboration>();
            Knowledges = new List<KnowledgeItem>();
            KnowledgeItemView = new KnowledgeItem();
        }

        public void OnGet(int EmployeeID)
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


            SqlDataReader singleKnowledge = DBClass.SingleKnowledgeReader(EmployeeID);

            while (singleKnowledge.Read())
            {
                KnowledgeItemView.EmployeeID = EmployeeID;
                KnowledgeItemView.Name = singleKnowledge["Name"].ToString();
            }

            DBClass.Lab1DBConnection.Close();


            SqlDataReader KnowledgeName = DBClass.KnowledgeItemReader();
            while (KnowledgeName.Read())
            {
                Knowledges.Add(new KnowledgeItem
                {
                    KnowledgeId = int.Parse(KnowledgeName["KnowledgeId"].ToString()),
                    Name = KnowledgeName["Name"].ToString(),
                    EmployeeID = int.Parse(KnowledgeName["EmployeeID"].ToString())
                }
                );
            }

        }
        public IActionResult OnPost()
        {
            DBClass.ViewKnowledge(KnowledgeItemView);

            DBClass.Lab1DBConnection.Close();

            return RedirectToPage("Index");
        }
    }
}

