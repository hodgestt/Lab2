//Nick Patterson
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1Part3.Pages.DataClasses
{
    public class Plan
    {
        public String PlanName { get; set; }
        public String? PlanConcept { get; set; }
        public DateTime? DateCreated { get; set; }
        public String? AnalysisUsed { get; set; }

        [ForiegnKey("CollabID")]
        public Collaboration CollabID { get; set; }
    }
}