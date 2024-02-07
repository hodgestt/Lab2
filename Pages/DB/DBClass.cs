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

        //Basic Product Reader
        public static SqlDataReader EmployeeReader()
        {
            SqlCommand cmdEmployeeRead = new SqlCommand();
            cmdEmployeeRead.Connection = LABTHREEDBConnection;
            cmdEmployeeRead.Connection.ConnectionString = LABTHREEDBConnString;
            cmdEmployeeRead.CommandText = "SELECT * FROM Employee";
            cmdEmployeeRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdEmployeeRead.ExecuteReader();

            return tempReader;
        }
    }

}
