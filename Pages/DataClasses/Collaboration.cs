using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace Lab1Part3.Pages.DataClasses
{
    public class Collaboration
    {

        public int CollabID { get; set; }
        
        public String TeamName { get; set; }

        public String NotesAndInformation { get; set; }


    }
}
