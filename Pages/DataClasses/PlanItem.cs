//Nick Patterson
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1Part3.Pages.DataClasses
{
    public class PlanItem
    {
        public int PlanItemID { get; set; }
        public String PlanItemDescription { get; set; }
        public String StepsCompleted { get; set; }

        // Navigation property for Plan
        [ForeignKey("PlanName")]
        public Plan Plan { get; set; }

        // Foreign Key for Plan
        public String PlanName { get; set; }


    }
}
