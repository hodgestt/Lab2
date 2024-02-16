//Jessica Shamloo, Thomas Hodges & Nick Patterson
using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace Lab2.Pages.DataClasses
{
    public class Collaboration
    {

        public int CollabID { get; set; }
        
        public String TeamName { get; set; }

        public String NotesAndInformation { get; set; }

        public String UserName { get; set; }


    }
}
