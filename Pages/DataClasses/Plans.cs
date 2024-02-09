//Nick Patterson
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1Part3.Pages.DataClasses
{
    public class Plans
    {
        public int PlanID { get; set; }
        public String PlanName { get; set; }
        public String PlanConcept { get; set; }
        public String DateCreated { get; set; }
        public String AnalysisUsed { get; set; }

        
    }
}