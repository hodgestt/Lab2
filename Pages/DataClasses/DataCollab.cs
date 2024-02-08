//Nick Patterson

using System.ComponentModel.DataAnnotations.Schema;
using Lab1Part3.Pages.DB;
using Lab1Part3.Pages.DataClasses;

namespace Lab1Part3.Pages.DataClasses

{
    public class DataCollab
    {
        
      
        public int CollabID { get; set; }

        [ForeignKey("CollabID")]
        public Collaboration Collaboration { get; set; }

        public string DataName { get; set; }

        [ForeignKey("DataName")]
        public DataFile DataFile { get; set; }

    }
}
