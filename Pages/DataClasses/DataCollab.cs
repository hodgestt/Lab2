namespace Lab1Part3.Pages.DataClasses
//Nick Patterson
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
