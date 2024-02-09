//Jessica Shamloo & Thomas Hodges

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab1Part3.Pages.DataClasses
{
    public class Employee
    {
        //? means this data field can contain a blank/null
        public int EmployeeID { get; set; }
        [BindProperty]
        [Required]
        public String FirstName { get; set; }
        [BindProperty]
        [Required]
        public String LastName { get; set; }
        [BindProperty]
        [Required]
        public String Email { get; set; }
        [BindProperty]
        [Required]
        public String Phone { get; set; }
        [BindProperty]
        [Required]
        public String Street { get; set; }
        [BindProperty]
        [Required]
        public String City { get; set; }
        [BindProperty]
        [Required]
        public String State { get; set; }
        [BindProperty]
        [Required]
        public String Zip { get; set;}
        [BindProperty]
        [Required]
        public String UserName { get; set; }
        [BindProperty]
        [Required]
        public String Password { get; set; }
       
    }
}
