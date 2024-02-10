//Nick Patterson
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1Part3.Pages.DataClasses
{
    public class PlanItem
    {
        public int PlanID { get; set; }
        public int PlanItemID { get; set; }
        public String PlanItemDescription { get; set; }
        public String StepsCompleted { get; set; }


    }
}
