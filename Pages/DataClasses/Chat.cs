//Nick Patterson
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Pages.DataClasses
{
    public class Chat
    {
        public int ChatID { get; set; }

        public String ChatMessage { get; set; }
        
        public DateTime ChatDateTime { get; set; }

        public int EmployeeID { get; set; }

    }
}
