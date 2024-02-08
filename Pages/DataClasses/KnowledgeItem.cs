//Jessica Shamloo

using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1Part3.Pages.DataClasses
{
    public class KnowledgeItem
    {
        public int KnowledgeItemId { get; set; }    
        public String? Name { get; set;}
        public String? Subject { get; set;}
        public String? Category { get; set;}
        public String? Information { get; set;}
        public DateTime? KnowledgeDateTime { get; set;}

        [ForeignKey("EmployeeID")]
        public Employee EmployeeID { get; set; }
    }

}
