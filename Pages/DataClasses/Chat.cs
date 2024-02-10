using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab1Part3.Pages.DataClasses
{
    public class Chat
    {
        public int ChatID { get; set; }
        
        public String ChatMessage { get; set; }
        
        public String ChatDateTime { get; set; }
        
        public int CollabID { get; set; }

        public int EmployeeID { get; set; }

    }
}
