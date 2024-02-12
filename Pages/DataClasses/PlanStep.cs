//Jessica Shamloo & Nick Patterson
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1Part3.Pages.DataClasses
{
    public class PlanStep
    {
        public int PlanID { get; set; }
        public int StepID { get; set; }
        public String StepDescription { get; set; }
        public String Status { get; set; }

       
    }
}
