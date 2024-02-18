using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;


namespace Lab2.Pages.SWOTs
{
    public class IndexModel : PageModel
    {
        public List<SWOT> SWOTTable { get; set; }


        [BindProperty]
        public int KnowledgeId { get; set; }

        [BindProperty]
        public int CollabID { get; set; }


        public IndexModel()
        {
            SWOTTable = new List<SWOT>();
        }


        public IActionResult OnGet()
        {
            SqlDataReader SWOTReader = DBClass.SWOTReader();
            while (SWOTReader.Read())
            {
                SWOTTable.Add(new SWOT
                {

                    SWOTID = Int32.Parse(SWOTReader["SWOTID"].ToString()),
                    Strengths = SWOTReader["Strengths"].ToString(),
                    Weaknesses = SWOTReader["Weaknesses"].ToString(),
                    Opportunities = SWOTReader["Opportunities"].ToString(),
                    Threats = SWOTReader["Threats"].ToString(),
                    CollabID = Int32.Parse(SWOTReader["COllabID"].ToString()),
                    KnowledgeId = Int32.Parse(SWOTReader["COllabID"].ToString())
                }
                );
            }

            // Close your connection in DBClass
            DBClass.Lab2DBConnection.Close();

            return Page();

        }
    }
}
