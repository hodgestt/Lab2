using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab1Part3.Pages.DataClasses
{
    public class Chat
    {
        public int ChatID { get; set; }
        [BindProperty]
        [Required]
        public String ChatMessage { get; set; }
        [BindProperty]
        [Required]
        public String ChatLocation { get; set; }
        [BindProperty]
        [Required]
        public String ChatDateTime { get; set; }
        
    }
}
