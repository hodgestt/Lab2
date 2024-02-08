//Nick Patterson

using System.ComponentModel.DataAnnotations.Schema;
using Lab1Part3.Pages.DB;
using Lab1Part3.Pages.DataClasses;

namespace Lab1Part3.Pages.DataClasses

{
    public class DataCollab
    {
        
        // Foreign Key for DataCollab
        public int CollabID { get; set; }

        // Navigation property for Collaboration
        [ForeignKey("CollabID")]
        public Collaboration Collaboration { get; set; }

        // Foreign key property for DataFile
        public string DataName { get; set; }

        // Navigation property for DataFile
        [ForeignKey("DataName")]
        public DataFile DataFile { get; set; }

    }
}
