//Jessica Shamloo

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1Part3.Pages.DataClasses
{
    public class KnowledgeItem
    {
        public int KnowledgeId { get; set; }
        [BindProperty]
        [Required]
        public String? Name { get; set;}
        [BindProperty]
        [Required]
        public String? Subject { get; set;}
        [BindProperty]
        [Required]
        public String? Category { get; set;}
        [BindProperty]
        [Required]
        public String? Information { get; set;}
        [BindProperty]
        [Required]
        public DateTime? KnowledgeDateTime { get; set;} 

    }
}

