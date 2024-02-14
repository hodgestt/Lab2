using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab2.Pages.KnowledgeCollabs
{
    public class  NewKnowledgeCollabModel : PageModel
    {
        [BindProperty]
        public int KnowledgeId { get; set; }

        [BindProperty]
        public int CollabID { get; set; }

        public List<SelectListItem> Knowledges { get; set; }

        public List<SelectListItem> CollabTeams { get; set; }

        public void OnGet()
        {
            // Populate the Knowledge Item SELECT control
            SqlDataReader KnowledgeReader = DBClass.GeneralReaderQuery("SELECT * FROM KnowledgeItem");

            Knowledges = new List<SelectListItem>();

            while (KnowledgeReader.Read())
            {
                Knowledges.Add(
                    new SelectListItem(
                        KnowledgeReader["Name"].ToString(),
                        KnowledgeReader["KnowledgeId"].ToString()));
            }

            DBClass.Lab2DBConnection.Close();

            // Populate the Collaboration SELECT control
            SqlDataReader CollabReader = DBClass.GeneralReaderQuery("SELECT * FROM Collaboration");

            CollabTeams = new List<SelectListItem>();

            while (CollabReader.Read())
            {
                CollabTeams.Add(
                    new SelectListItem(
                        CollabReader["TeamName"].ToString(),
                        CollabReader["CollabID"].ToString()));
            }

            DBClass.Lab2DBConnection.Close();

        }

        public IActionResult OnPost()
        {
            string insertQuery = "INSERT INTO KnowledgeCollab (CollabID, KnowledgeId) VALUES (";
            insertQuery += CollabID + "," + KnowledgeId + ")";

            DBClass.GeneralInsertQuery(insertQuery);

            DBClass.Lab2DBConnection.Close();

            return Page();
        }
    }
}
    

