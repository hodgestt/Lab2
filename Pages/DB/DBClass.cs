//Jessica Shamloo, Thomas Hodges & Nick Patterson

using Lab1Part3.Pages.DataClasses;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Data;
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
        public static SqlDataReader EmployeeReader()
        {
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab1DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab1DBConnString;
            cmdTableRead.CommandText =
                "SELECT * FROM Employee;";

            cmdTableRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdTableRead.ExecuteReader();
            return tempReader;
        }

        public static SqlDataReader SingleEmployeeReader(int EmployeeID)
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = Lab1DBConnection;
            cmdProductRead.Connection.ConnectionString = Lab1DBConnString;
            cmdProductRead.CommandText = "SELECT * FROM Employee WHERE EmployeeID = " + EmployeeID;
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        public static void UpdateEmployee(Employee e)
        {
            String sqlQuery = "UPDATE Employee SET ";
            sqlQuery += "FirstName='" + e.FirstName + "',";
            sqlQuery += "LastName='" + e.LastName + "',";
            sqlQuery += "Email='" + e.Email + "',";
            sqlQuery += "Phone='" + e.Phone + "',";
            sqlQuery += "Street='" + e.Street + "',";
            sqlQuery += "City='" + e.City + "',";
            sqlQuery += "State='" + e.State + "',";
            sqlQuery += "Zip='" + e.Zip + "',";
            sqlQuery += "UserName='" + e.UserName + "',";
            sqlQuery += "Password='" + e.Password + "' WHERE EmployeeID=" + e.EmployeeID;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Lab1DBConnection;
            cmd.Connection.ConnectionString = Lab1DBConnString;
            cmd.CommandText = sqlQuery;
            cmd.Connection.Open();

            cmd.ExecuteNonQuery();
        }


        public static SqlDataReader SingleKnowledgeReader(int EmployeeID)
        {
            
            SqlConnection connection = new SqlConnection(Lab1DBConnString);
            SqlCommand cmd = new SqlCommand("SELECT Name FROM KnowledgeItem WHERE EmployeeID = @EmployeeID", connection);
            cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }


        public static void InsertPlanStep(PlanStep p)
        {
            string sqlQuery = "INSERT INTO PlanStep(PlanID,StepDescription,Status) VALUES (";
            sqlQuery += p.PlanID +  ",'";
            sqlQuery += p.StepDescription + "','";
            sqlQuery += p.Status + "')";

            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab1DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab1DBConnString;
            cmdTableRead.CommandText = sqlQuery;
            cmdTableRead.Connection.Open();

            cmdTableRead.ExecuteNonQuery();

        }

        public static SqlDataReader DataCollabReader()
        {
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab1DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab1DBConnString;
            cmdTableRead.CommandText =
                "SELECT * FROM DataCollab; ";

            cmdTableRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdTableRead.ExecuteReader();
            return tempReader;
        }

        public static SqlDataReader DataFileReader()
        {
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab1DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab1DBConnString;
            cmdTableRead.CommandText =
                "SELECT * FROM DataFile;";

            cmdTableRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdTableRead.ExecuteReader();
            return tempReader;
         }
        public static SqlDataReader EmployeeCollabReader()
        {
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab1DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab1DBConnString;
            cmdTableRead.CommandText =
                "SELECT * FROM EmployeeCollab;";

            cmdTableRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdTableRead.ExecuteReader();
            return tempReader;
        }

        public static SqlDataReader KnowledgeItemReader()
        {
            SqlConnection connection = new SqlConnection(Lab1DBConnString);
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = connection;
            cmdTableRead.CommandText = "SELECT * FROM KnowledgeItem;";
            connection.Open();
            SqlDataReader tempReader = cmdTableRead.ExecuteReader();
     
            return tempReader;
        }


        public static SqlDataReader PlansReader()
        {
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab1DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab1DBConnString;
            cmdTableRead.CommandText =
                "SELECT * FROM Plans;";

            cmdTableRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdTableRead.ExecuteReader();
            return tempReader;
        }

        public static SqlDataReader CollabReader()
        {
            SqlConnection connection = new SqlConnection(Lab1DBConnString);
            SqlCommand cmdTableRead = new SqlCommand("SELECT * FROM Collaboration", connection);

            connection.Open();
            SqlDataReader tempReader = cmdTableRead.ExecuteReader(CommandBehavior.CloseConnection);

            return tempReader;
        }

        public static SqlDataReader ChatReader()
        {
            SqlConnection connection = new SqlConnection(Lab1DBConnString);
            SqlCommand cmdTableRead = new SqlCommand("SELECT * FROM Chat INNER JOIN Employee ON Chat.EmployeeID = Employee.EmployeeID", connection);

            connection.Open();
            SqlDataReader tempReader = cmdTableRead.ExecuteReader(CommandBehavior.CloseConnection);

            return tempReader;


        }

        //General query reader for inner joins + associative tables
        public static SqlDataReader GeneralReaderQuery(string sqlQuery)
        {

            SqlConnection connection = new SqlConnection(Lab1DBConnString);
            SqlCommand cmdRead = new SqlCommand(sqlQuery, connection);
            connection.Open();
            SqlDataReader tempReader = cmdRead.ExecuteReader();

            return tempReader;
        }

        //General Insert Query for associative tables
        public static void GeneralInsertQuery(string sqlQuery)
        {
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = Lab1DBConnection;
            cmdInsert.Connection.ConnectionString = Lab1DBConnString;
            cmdInsert.CommandText = sqlQuery;
            cmdInsert.Connection.Open();
            cmdInsert.ExecuteNonQuery();
        }

        public static SqlDataReader ViewKnowledge(KnowledgeItem k)
        {
            string sqlQuery = "SELECT * FROM KnowledgeItem INNER JOIN Employee ON KnowledgeItem.EmployeeID = Employee.EmployeeID WHERE Employee.EmployeeID = " +k.EmployeeID;
            SqlConnection connection = new SqlConnection(Lab1DBConnString);
            SqlCommand cmdRead = new SqlCommand(sqlQuery, connection);
            connection.Open();
            SqlDataReader tempReader = cmdRead.ExecuteReader();

            return tempReader;
        }



        //Inserts one new Employee Record into the DB
        public static void InsertEmployee(Employee e)
        {
            String sqlQuery = "INSERT INTO Employee(FirstName,LastName,Email,Phone,Street,City,State,Zip,UserName,Password) VALUES ('";
            sqlQuery += e.FirstName + "','";
            sqlQuery += e.LastName + "','";
            sqlQuery += e.Email + "','";
            sqlQuery += e.Phone + "','";
            sqlQuery += e.Street + "','";
            sqlQuery += e.City + "','";
            sqlQuery += e.State + "','";
            sqlQuery += e.Zip+ "','";
            sqlQuery += e.UserName + "','";
            sqlQuery += e.Password + "')";

            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab1DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab1DBConnString;
            cmdTableRead.CommandText = sqlQuery;
            cmdTableRead.Connection.Open();

            cmdTableRead.ExecuteNonQuery();


        }

        //Inserts one new KnowledgeItem Record into the DB
        public static void InsertKnowledgeItem(KnowledgeItem x)
        {
            String sqlQuery = "INSERT INTO KnowledgeItem(Name,Subject,Category,Information,KnowledgeDateTime) VALUES ('";
            sqlQuery += x.Name + "','";
            sqlQuery += x.Subject + "','";
            sqlQuery += x.Category + "','";
            sqlQuery += x.Information + "','";
            sqlQuery += x.KnowledgeDateTime + "')";

            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab1DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab1DBConnString;
            cmdTableRead.CommandText = sqlQuery;
            cmdTableRead.Connection.Open();

            cmdTableRead.ExecuteNonQuery();


        }

        //Inserts one new Plan Record into the DB
        public static void InsertPlan(Plans p)
        {
            String sqlQuery = "INSERT INTO Plans(PlanName,PlanConcept,DateCreated) VALUES ('";
            sqlQuery += p.PlanName + "','";
            sqlQuery += p.PlanConcept + "','";
            sqlQuery += p.DateCreated + "')";
           

            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab1DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab1DBConnString;
            cmdTableRead.CommandText = sqlQuery;
            cmdTableRead.Connection.Open();

            cmdTableRead.ExecuteNonQuery();


        }


        //Inserts a data file into the DB
        public static void InsertDataFile(DataFile d)
        {
            String sqlQuery = "INSERT INTO DataFile(DataName,DataLocation,DataDescription) VALUES ('";
            sqlQuery += d.DataName + "','";
            sqlQuery += d.DataLocation + "','";
            sqlQuery += d.DataDescription + "')";

            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab1DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab1DBConnString;
            cmdTableRead.CommandText = sqlQuery;
            cmdTableRead.Connection.Open();

            cmdTableRead.ExecuteNonQuery();


        }
        public static void InsertChat(Chat c)
        {
            String sqlQuery = "INSERT INTO Chat (ChatMessage,ChatDateTime,EmployeeID) VALUES ('";
            sqlQuery += c.ChatMessage + "','";
            sqlQuery += c.ChatDateTime + "','";
            sqlQuery += c.EmployeeID + "')";
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab1DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab1DBConnString;
            cmdTableRead.CommandText = sqlQuery;
            cmdTableRead.Connection.Open();

            cmdTableRead.ExecuteNonQuery();


        }

    }
}


