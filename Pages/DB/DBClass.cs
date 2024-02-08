//Jessica Shamloo & Thomas Hodges

using Lab1Part3.Pages.DataClasses;
using System.Data.SqlClient;

namespace Lab1Part3.Pages.DB
{
    public class DBClass
    {
        // The Connection Object at Data Field Level
        public static SqlConnection LABTHREEDBConnection = new SqlConnection();

        // The Connection String finds and connects to DB
        private static readonly String? LABTHREEDBConnString = "Server=Localhost;Database=LABTHREE;Trusted_Connection=True";
       
        //Basic Table Reader 
        public static SqlDataReader TableReader()
        {
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = LABTHREEDBConnection;
            cmdTableRead.Connection.ConnectionString = LABTHREEDBConnString;
            cmdTableRead.CommandText =
                "SELECT * FROM Employee; SELECT * FROM DataCollab; SELECT * FROM DataFile; SELECT * FROM KnowledgeItem;" +
                "SELECT * FROM Collaboration; SELECT * FROM EmployeeCollab; SELECT * FROM Chat; " +
                "SELECT * Plans; SELECT * FROM PlanItem";

            cmdTableRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdTableRead.ExecuteReader();
            return tempReader;
        }

    }
}


