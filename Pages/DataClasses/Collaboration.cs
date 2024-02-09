using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace Lab1Part3.Pages.DataClasses
{
    public class Collaboration
    {

        //this class is just a "space" for the chat and collaboration to happen? 

        //add [Required] or [BindProperty]? 
        //I dont think soo?? nothings coming from an intake form.
        public int CollabID { get; set; }

        public String? NotesAndInformation { get; set; }


    }
}
