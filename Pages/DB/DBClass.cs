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

        //Basic Employee Reader
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

        //Basic KnowledgeItem Reader
        public static SqlDataReader KnowledgeItemReader()
        {
            SqlCommand cmdKnowledgeItemRead = new SqlCommand();
            cmdKnowledgeItemRead.Connection = LABTHREEDBConnection;
            cmdKnowledgeItemRead.Connection.ConnectionString = LABTHREEDBConnString;
            cmdKnowledgeItemRead.CommandText = "SELECT * FROM KnowledgeItem";
            cmdKnowledgeItemRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdKnowledgeItemRead.ExecuteReader();

            return tempReader;
        }

        //Basic DataFile Reader
        public static SqlDataReader DataFileReader()
        {
            SqlCommand cmdDataFileRead = new SqlCommand();
            cmdDataFileRead.Connection = LABTHREEDBConnection;
            cmdDataFileRead.Connection.ConnectionString = LABTHREEDBConnString;
            cmdDataFileRead.CommandText = "SELECT * FROM DataFile";
            cmdDataFileRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdDataFileRead.ExecuteReader();

            return tempReader;
        }
    }

}
