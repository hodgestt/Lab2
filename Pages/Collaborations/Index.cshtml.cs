using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
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

        [BindProperty]
        public int EmployeeID { get; set; }

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
                    CollabID = Convert.ToInt32(TableReader["CollabID"]),
                    TeamName = TableReader["TeamName"].ToString(),
                    NotesAndInformation = TableReader["NotesAndInformation"].ToString()
                });
            }
            TableReader.Close(); // Close the reader after use

            SqlDataReader EmployeeReader = DBClass.GeneralReaderQuery("SELECT EmployeeID, CONCAT(FirstName, ' ', LastName) AS Name FROM Employee");
            EmployeeList = new List<SelectListItem>();
            while (EmployeeReader.Read())
            {
                EmployeeList.Add(new SelectListItem
                {
                    Text = EmployeeReader["Name"].ToString(),
                    Value = EmployeeReader["EmployeeID"].ToString()
                });
            }
            EmployeeReader.Close(); // Close the reader after use

            SqlDataReader KnowledgeName = DBClass.KnowledgeItemReader();
            while (KnowledgeName.Read())
            {
                Knowledges.Add(new KnowledgeItem
                {
                    KnowledgeId = Convert.ToInt32(KnowledgeName["KnowledgeId"]),
                    Name = KnowledgeName["Name"].ToString(),
                    EmployeeID = Convert.ToInt32(KnowledgeName["EmployeeID"])
                });
            }
            KnowledgeName.Close(); // Close the reader after use

            SqlDataReader knowledgeItemReader = DBClass.SingleKnowledgeReader(EmployeeID);
            List<string> knowledgeItemNames = new List<string>();

            while (knowledgeItemReader.Read())
            {
                knowledgeItemNames.Add(knowledgeItemReader["Name"].ToString());
            }
            knowledgeItemReader.Close();
        }

        public IActionResult OnPost()
        {
            String sqlreader = "SELECT Name FROM KnowledgeItem INNER JOIN KnowledgeItem.EmployeeID = Employee.EmployeeID";
            DBClass.ViewKnowledge(KnowledgeItemView);
            return RedirectToPage("Index");
        }
    }
}