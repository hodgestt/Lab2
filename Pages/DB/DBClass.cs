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


        public static SqlDataReader SingleKnowledgeReader(int KnowledgeId)
        {
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = new SqlConnection();
            cmdTableRead.Connection.ConnectionString = Lab1DBConnString;
            cmdTableRead.CommandText = "SELECT Name FROM KnowledgeItem WHERE KnowledgeId = " + KnowledgeId;
            cmdTableRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdTableRead.ExecuteReader();
            return tempReader;
        }

        public static SqlDataReader SinglePlanReader(int PlanID)
        {
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = new SqlConnection();
            cmdTableRead.Connection.ConnectionString = Lab1DBConnString;
            cmdTableRead.CommandText = "SELECT PlanName FROM Plans WHERE PlanID = " + PlanID;
            cmdTableRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdTableRead.ExecuteReader();
            return tempReader;
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
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab1DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab1DBConnString;
            cmdTableRead.CommandText =
                "SELECT * FROM KnowledgeItem;";

            cmdTableRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdTableRead.ExecuteReader();
            return tempReader;
        }

        public static SqlDataReader PlanItemReader()
        {
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab1DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab1DBConnString;
            cmdTableRead.CommandText =
                "SELECT * FROM PlanItem;";

            cmdTableRead.Connection.Open(); // Open connection here, close in Model!

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
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab1DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab1DBConnString;
            cmdTableRead.CommandText =

                "SELECT * FROM Collaboration; ";

            cmdTableRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdTableRead.ExecuteReader();
            return tempReader;
        }

        //General query reader for inner joins + associative tables
        public static SqlDataReader GeneralReaderQuery(string sqlQuery)
        {

            SqlCommand cmdRead = new SqlCommand();
            cmdRead.Connection = Lab1DBConnection;
            cmdRead.Connection.ConnectionString = Lab1DBConnString;
            cmdRead.CommandText = sqlQuery;
            cmdRead.Connection.Open();
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
            String sqlQuery = "INSERT INTO Plans(PlanName,PlanConcept,DateCreated,AnalysisUsed) VALUES ('";
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

        //Inserts one new PlanItem Record into the DB
        public static void InsertPlanItem(PlanItem p)
        {
            String sqlQuery = "INSERT INTO PlanItem(PlanItemDescription,StepsCompleted) VALUES ('";
            sqlQuery += p.PlanItemDescription + "','";
            sqlQuery += p.StepsCompleted + "')";
           

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

    }
}


