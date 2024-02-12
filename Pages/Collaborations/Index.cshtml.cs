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
        public List<SelectListItem> EmployeeList { get; set; } = new();
        public List<Plans> PlansTable { get; set; }

        [BindProperty]
        public List<KnowledgeItem> KnowledgeNames { get; set; }

        [BindProperty]
        public KnowledgeItem KnowledgeItemView { get; set; }

        [BindProperty]
        public int EmployeeID { get; set; }

        public IndexModel()
        {
            CollaborationTable = new List<Collaboration>();
            Knowledges = new List<KnowledgeItem>();
            KnowledgeItemView = new KnowledgeItem();
            KnowledgeNames = new List<KnowledgeItem>();
            PlansTable = new List<Plans>();
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
            DBClass.Lab1DBConnection.Close(); // Close the reader after use

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
            DBClass.Lab1DBConnection.Close(); // Close the reader after use

            SqlDataReader PlanReader = DBClass.PlansReader();
            while (PlanReader.Read())
            {
                PlansTable.Add(new Plans
                {
                    PlanID = Int32.Parse(PlanReader["PlanID"].ToString()),
                    PlanName = PlanReader["PlanName"].ToString(),
                    PlanConcept = PlanReader["PlanConcept"].ToString(),
                    DateCreated = PlanReader["DateCreated"].ToString()
                }

            );
            }

            // Close your connection in DBClass
            DBClass.Lab1DBConnection.Close();



        }

        public IActionResult OnPost()
        {

            SqlDataReader knowledgeItemReader = DBClass.SingleKnowledgeReader(EmployeeID);
            while (knowledgeItemReader.Read())
            {
                KnowledgeNames.Add(new KnowledgeItem
                {
                    Name = knowledgeItemReader["Name"].ToString()
                }
                );
                
            }

            DBClass.Lab1DBConnection.Close();
            return Page();
        }
    }
}