//Nick Patterson

using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1Part3.Pages.DataClasses

{
    public class DataCollab
    {
        //? means this data field can contain a blank/null
        [ForeignKey("CollabID")]
        public Collaboration CollabID { get; set; }
        [ForeignKey("DataName")]
        public DataFile DataName { get; set; }
    }
}
