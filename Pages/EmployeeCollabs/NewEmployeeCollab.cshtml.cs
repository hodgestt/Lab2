using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab2.Pages.EmployeeCollabs
{
    public class NewEmployeeCollabModel : PageModel
    {
        [BindProperty]
        public int EmployeeID { get; set; }

        [BindProperty]
        public int CollabID { get; set; }

        public List<SelectListItem> Employees { get; set; }

        public List<SelectListItem> CollabTeams { get; set; }

        public void OnGet()
        {
            // Populate the Employee SELECT control
            SqlDataReader EmployeeCollabReader = DBClass.GeneralReaderQuery("SELECT * FROM Employee");

            Employees = new List<SelectListItem>();

            while (EmployeeCollabReader.Read())
            {
                Employees.Add(
                    new SelectListItem(
                        EmployeeCollabReader["UserName"].ToString(),
                        EmployeeCollabReader["EmployeeID"].ToString()));
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
            string insertQuery = "INSERT INTO EmployeeCollab (CollabID, EmployeeID) VALUES (";
            insertQuery += CollabID + "," + EmployeeID + ")";

            DBClass.GeneralInsertQuery(insertQuery);

            DBClass.Lab2DBConnection.Close();

            return Page();
        }
    }
}

