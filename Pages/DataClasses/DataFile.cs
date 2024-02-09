//Thomas Hodges

using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1Part3.Pages.DataClasses
{
    public class DataFile
    {
        //? means this data field can contain a blank/null
        public int DataID { get; set; }
        public String DataName { get; set; }
        public String DataLocation { get; set; }
        public String DataDescription { get; set; }

    }
}


