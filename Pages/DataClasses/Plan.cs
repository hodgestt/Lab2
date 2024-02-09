//Nick Patterson
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1Part3.Pages.DataClasses
{
    public class Plan
    {
        public String PlanName { get; set; }
        public String PlanConcept { get; set; }
        public String DateCreated { get; set; }
        public String AnalysisUsed { get; set; }

        // Navigation property for Collaboration
        [ForeignKey("CollabID")]
        public Collaboration Collaboration { get; set; }

        // Foreign key property for Collaboration
        public int CollabID { get; set; }

        
    }
}