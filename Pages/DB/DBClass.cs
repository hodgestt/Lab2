//Jessica Shamloo & Thomas Hodges

using Lab1Part3.Pages.DataClasses;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Lab1Part3.Pages.DB
{
    public class DBClass
    {
        // The Connection Object at Data Field Level
        public static SqlConnection Lab1DBConnection = new SqlConnection();

        // The Connection String finds and connects to DB
        private static readonly String? Lab1DBConnString = "Server=Localhost;Database=Lab1;Trusted_Connection=True";
       
        //Basic Table Reader 
        public static SqlDataReader TableReader()
        {
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab1DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab1DBConnString;
            cmdTableRead.CommandText =
                "SELECT * FROM Employee; SELECT * FROM DataCollab; SELECT * FROM DataFile; SELECT * FROM KnowledgeItem;" +
                "SELECT * FROM Collaboration; SELECT * FROM EmployeeCollab; SELECT * FROM Chat; " +
                "SELECT * FROM Plans; SELECT * FROM PlanItem;";

            cmdTableRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdTableRead.ExecuteReader();
            return tempReader;
        }


        //Inserts one new Employee Record into the DB
        public static void InsertEmployee(Employee e)
        {
            String sqlQuery = "INSERT INTO Employee(FirstName,LastName,Email,Phone,Street,City,State,Zip,UserName,Password) VALUES ('";
            sqlQuery += e.FirstName + "',";
            sqlQuery += e.LastName + "',";
            sqlQuery += e.Email + "',";
            sqlQuery += e.Phone + "',";
            sqlQuery += e.Street + "',";
            sqlQuery += e.City + "',";
            sqlQuery += e.City + "',";
            sqlQuery += e.State + "',";
            sqlQuery += e.Zip+ "',";
            sqlQuery += e.UserName + "',";
            sqlQuery += e.Password + "')";

            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab1DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab1DBConnString;
            cmdTableRead.CommandText = sqlQuery;
            cmdTableRead.Connection.Open();

            cmdTableRead.ExecuteNonQuery();


        }

        //Inserts one new KnowledgeItem Record into the DB
        public static void InsertKnowledgeItem(KnowledgeItem e)
        {
            String sqlQuery = "INSERT INTO KnowledgeItem(Name,Subject,Category,Information,KnowledgeDateTime) VALUES ('";
            sqlQuery += e.Name + "',";
            sqlQuery += e.Subject + "',";
            sqlQuery += e.Category + "',";
            sqlQuery += e.Information + "',";
            sqlQuery += e.KnowledgeDateTime + "')";

            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab1DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab1DBConnString;
            cmdTableRead.CommandText = sqlQuery;
            cmdTableRead.Connection.Open();

            cmdTableRead.ExecuteNonQuery();


        }

        
    }
}


