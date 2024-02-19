//Jessica Shamloo, Thomas Hodges & Nick Patterson

using Lab2.Pages.DataClasses;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Lab2.Pages.DB
{
    public class DBClass
    {
        // The Connection Object at Data Field Level
        public static SqlConnection Lab2DBConnection = new SqlConnection();

        // The Connection String finds and connects to DB
        private static readonly String? Lab2DBConnString = "Server=Localhost;Database=Lab2;Trusted_Connection=True";
       
        //Basic Table Reader 
        public static SqlDataReader EmployeeReader()
        {
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab2DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab2DBConnString;
            cmdTableRead.CommandText =
                "SELECT * FROM Employee;";

            cmdTableRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdTableRead.ExecuteReader();
            return tempReader;
        }

        public static SqlDataReader SingleEmployeeReader(int EmployeeID)
        {
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab2DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab2DBConnString;
            cmdTableRead.CommandText = "SELECT * FROM Employee WHERE EmployeeID = " + EmployeeID;
            cmdTableRead.Connection.Open();

            SqlDataReader tempReader = cmdTableRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader EditSingleKnowledge(int KnowledgeId)
        {
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab2DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab2DBConnString;
            cmdTableRead.CommandText = "SELECT * FROM KnowledgeItem WHERE KnowledgeId = " + KnowledgeId;
            cmdTableRead.Connection.Open();

            SqlDataReader tempReader = cmdTableRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader SWOTReader()
        {
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab2DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab2DBConnString;
            cmdTableRead.CommandText =
                "SELECT s.*, k.Name FROM SWOT s INNER JOIN KnowledgeItem k ON s.KnowledgeId = k.KnowledgeId";
            //SELECT c.ChatID, c.ChatMessage, c.ChatDateTime, e.UserName FROM Chat c INNER JOIN Employee e ON c.EmployeeID = e.EmployeeID", connection);

            cmdTableRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdTableRead.ExecuteReader();
            return tempReader;
        }

        public static void InsertSWOT(SWOT s)
        {
            string sqlQuery = "INSERT INTO SWOT(Strengths, Weaknesses, Opportunities, Threats, CollabID, KnowledgeId) VALUES ('";
            sqlQuery += s.Strengths + "','";
            sqlQuery += s.Weaknesses + "','";
            sqlQuery += s.Opportunities + "','";
            sqlQuery += s.Threats + "','";
            sqlQuery += s.CollabID + "','";
            sqlQuery += s.KnowledgeId + "')";

            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab2DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab2DBConnString;
            cmdTableRead.CommandText = sqlQuery;
            cmdTableRead.Connection.Open();

            cmdTableRead.ExecuteNonQuery();

        }

        public static SqlDataReader SingleKnowledgeReader(int EmployeeID, int KnowledgeId)
        {

            SqlConnection connection = new SqlConnection(Lab2DBConnString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM KnowledgeItem WHERE EmployeeID = @EmployeeID", connection);
            cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmd.Parameters.AddWithValue("@KnowledgeId", KnowledgeId);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public static void UpdateKnowledgeItem(KnowledgeItem k)
        {
            String sqlQuery = "UPDATE KnowledgeItem SET ";
            sqlQuery += "Name='" + k.Name + "',";
            sqlQuery += "Subject='" + k.Subject + "',";
            sqlQuery += "Category='" + k.Category + "',";
            sqlQuery += "Information='" + k.Information + "',";
            sqlQuery += "KnowledgeDateTime='" + k.KnowledgeDateTime + "',";
            sqlQuery += "EmployeeID=" + k.EmployeeID + " WHERE EmployeeID=" + k.EmployeeID + "AND KnowledgeId =" + k.KnowledgeId +";";
            
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Lab2DBConnection;
            cmd.Connection.ConnectionString = Lab2DBConnString;
            cmd.CommandText = sqlQuery;
            cmd.Connection.Open();

            cmd.ExecuteNonQuery();
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
            cmd.Connection = Lab2DBConnection;
            cmd.Connection.ConnectionString = Lab2DBConnString;
            cmd.CommandText = sqlQuery;
            cmd.Connection.Open();

            cmd.ExecuteNonQuery();
        }


        public static void InsertPlanStep(PlanStep p)
        {
            string sqlQuery = "INSERT INTO PlanStep(PlanID, StepDescription,Status) VALUES (";
            sqlQuery += p.PlanID + ",'";
            sqlQuery += p.StepDescription + "','";
            sqlQuery += p.Status + "')";

            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab2DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab2DBConnString;
            cmdTableRead.CommandText = sqlQuery;
            cmdTableRead.Connection.Open();

            cmdTableRead.ExecuteNonQuery();

        }

        public static SqlDataReader PlanStepReader(int PlanID)
        {
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab2DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab2DBConnString;
            cmdTableRead.CommandText = "SELECT * FROM PlanStep WHERE PlanID = " + PlanID;
            cmdTableRead.Connection.Open();

            SqlDataReader tempReader = cmdTableRead.ExecuteReader();

            return tempReader;
        }


        public static SqlDataReader DataCollabReader()
        {
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab2DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab2DBConnString;
            cmdTableRead.CommandText =
                "SELECT * FROM DataCollab; ";

            cmdTableRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdTableRead.ExecuteReader();
            return tempReader;
        }

        public static SqlDataReader DataFileReader()
        {
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab2DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab2DBConnString;
            cmdTableRead.CommandText =
                "SELECT * FROM DataFile;";

            cmdTableRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdTableRead.ExecuteReader();
            return tempReader;
         }
        public static SqlDataReader EmployeeCollabReader()
        {
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab2DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab2DBConnString;
            cmdTableRead.CommandText =
                "SELECT * FROM EmployeeCollab;";

            cmdTableRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdTableRead.ExecuteReader();
            return tempReader;
        }

        public static SqlDataReader KnowledgeItemReader()
        {
            SqlConnection connection = new SqlConnection(Lab2DBConnString);
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = connection;
            cmdTableRead.CommandText = "SELECT * FROM KnowledgeItem;";
            connection.Open();
            SqlDataReader tempReader = cmdTableRead.ExecuteReader();
     
            return tempReader;
        }


        public static SqlDataReader PlansReader() //delete eventually if the plansreader below starts to work
        {
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab2DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab2DBConnString;
            cmdTableRead.CommandText =
                "SELECT * FROM Plans;";

            cmdTableRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdTableRead.ExecuteReader();
            return tempReader;
        }

        //public static SqlDataReader PlansReader(int collabid) NOT WORKING
        //{
        //    SqlCommand cmdTableRead = new SqlCommand();
        //    cmdTableRead.Connection = Lab2DBConnection;
        //    cmdTableRead.Connection.ConnectionString = Lab2DBConnString;
        //    cmdTableRead.CommandText =
        //        "SELECT * FROM Plans WHERE CollabID=" +collabid.CollabID;

        //    cmdTableRead.Connection.Open(); // Open connection here, close in Model!

        //    SqlDataReader tempReader = cmdTableRead.ExecuteReader();
        //    return tempReader;
        //}



        public static SqlDataReader CollabReader()
        {
            SqlConnection connection = new SqlConnection(Lab2DBConnString);
            SqlCommand cmdTableRead = new SqlCommand("SELECT * FROM Collaboration", connection);

            connection.Open();
            SqlDataReader tempReader = cmdTableRead.ExecuteReader(CommandBehavior.CloseConnection);

            return tempReader;
        }

        public static SqlDataReader ChatReader()
        {
            SqlConnection connection = new SqlConnection(Lab2DBConnString);
            SqlCommand cmdTableRead = new SqlCommand("SELECT c.ChatID, c.ChatMessage, c.ChatDateTime, e.UserName FROM Chat c INNER JOIN Employee e ON c.EmployeeID = e.EmployeeID", connection);

            connection.Open();
            SqlDataReader tempReader = cmdTableRead.ExecuteReader(CommandBehavior.CloseConnection);

            return tempReader;


        }

        public static SqlDataReader CityDataReader()
        {
            SqlConnection connection = new SqlConnection(Lab2DBConnString);
            SqlCommand cmdTableRead = new SqlCommand("SELECT * FROM CityData INNER JOIN DataFile ON CityData.DataID = DataFile.DataID", connection);

            connection.Open();
            SqlDataReader tempReader = cmdTableRead.ExecuteReader(CommandBehavior.CloseConnection);

            return tempReader;


        }

        public static SqlDataReader GroceryDataReader()
        {
            SqlConnection connection = new SqlConnection(Lab2DBConnString);
            SqlCommand cmdTableRead = new SqlCommand("SELECT * FROM GroceryData INNER JOIN DataFile ON GroceryData.DataID = DataFile.DataID", connection);

            connection.Open();
            SqlDataReader tempReader = cmdTableRead.ExecuteReader(CommandBehavior.CloseConnection);

            return tempReader;


        }

        //General query reader for inner joins + associative tables
        public static SqlDataReader GeneralReaderQuery(string sqlQuery)
        {

            SqlConnection connection = new SqlConnection(Lab2DBConnString);
            SqlCommand cmdRead = new SqlCommand(sqlQuery, connection);
            connection.Open();
            SqlDataReader tempReader = cmdRead.ExecuteReader();

            return tempReader;
        }

        //General Insert Query for associative tables
        public static void GeneralInsertQuery(string sqlQuery)
        {
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = Lab2DBConnection;
            cmdInsert.Connection.ConnectionString = Lab2DBConnString;
            cmdInsert.CommandText = sqlQuery;
            cmdInsert.Connection.Open();
            cmdInsert.ExecuteNonQuery();
        }

        public static SqlDataReader ViewKnowledge(KnowledgeItem k)
        {
            string sqlQuery = "SELECT * FROM KnowledgeItem INNER JOIN Employee ON KnowledgeItem.EmployeeID = Employee.EmployeeID WHERE Employee.EmployeeID = " +k.EmployeeID;
            SqlConnection connection = new SqlConnection(Lab2DBConnString);
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
            cmdTableRead.Connection = Lab2DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab2DBConnString;
            cmdTableRead.CommandText = sqlQuery;
            cmdTableRead.Connection.Open();

            cmdTableRead.ExecuteNonQuery();


        }

        //Inserts one new KnowledgeItem Record into the DB
        public static void InsertKnowledgeItem(KnowledgeItem x)
        {
            String sqlQuery = "INSERT INTO KnowledgeItem(Name,Subject,Category,Information,KnowledgeDateTime,EmployeeID) VALUES ('";
            sqlQuery += x.Name + "','";
            sqlQuery += x.Subject + "','";
            sqlQuery += x.Category + "','";
            sqlQuery += x.Information + "','";
            sqlQuery += x.KnowledgeDateTime + "','";
            sqlQuery += x.EmployeeID + "')";

            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab2DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab2DBConnString;
            cmdTableRead.CommandText = sqlQuery;
            cmdTableRead.Connection.Open();

            cmdTableRead.ExecuteNonQuery();


        }

        //Inserts one new Plan Record into the DB
        public static void InsertPlan(Plans p)
        {
            String sqlQuery = "INSERT INTO Plans(PlanName,PlanConcept,DateCreated) VALUES (@PlanName, @PlanConcept, @DateCreated)";

            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab2DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab2DBConnString;
            cmdTableRead.CommandText = sqlQuery;

            // Add parameters with proper data types
            cmdTableRead.Parameters.AddWithValue("@PlanName", p.PlanName);
            cmdTableRead.Parameters.AddWithValue("@PlanConcept", p.PlanConcept);
            cmdTableRead.Parameters.AddWithValue("@DateCreated", p.DateCreated);

            cmdTableRead.Connection.Open();
            cmdTableRead.ExecuteNonQuery();
            cmdTableRead.Connection.Close();

        }


        //Inserts a data file into the DB
        public static void InsertDataFile(DataFile d)
        {
            String sqlQuery = "INSERT INTO DataFile(DataName,DataLocation,DataDescription) VALUES ('";
            sqlQuery += d.DataName + "','";
            sqlQuery += d.DataLocation + "','";
            sqlQuery += d.DataDescription + "')";

            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab2DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab2DBConnString;
            cmdTableRead.CommandText = sqlQuery;
            cmdTableRead.Connection.Open();

            cmdTableRead.ExecuteNonQuery();


        }
        public static void InsertChat(Chat c)
        {
            string sqlQuery = "INSERT INTO Chat (ChatMessage, ChatDateTime, EmployeeID) VALUES (@ChatMessage, @ChatDateTime, @EmployeeID)";
            SqlCommand cmdTableRead = new SqlCommand();
            cmdTableRead.Connection = Lab2DBConnection;
            cmdTableRead.Connection.ConnectionString = Lab2DBConnString;
            cmdTableRead.CommandText = sqlQuery;

            // Add parameters with proper data types
            cmdTableRead.Parameters.AddWithValue("@ChatMessage", c.ChatMessage);
            cmdTableRead.Parameters.AddWithValue("@ChatDateTime", c.ChatDateTime);
            cmdTableRead.Parameters.AddWithValue("@EmployeeID", c.EmployeeID);

            cmdTableRead.Connection.Open();
            cmdTableRead.ExecuteNonQuery();
            cmdTableRead.Connection.Close();


        }

        //used with DB login
        public static int LoginQuery(string loginQuery)
        {
            // This method expects to receive an SQL SELECT
            // query that uses the COUNT command.

            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = Lab2DBConnection;
            cmdLogin.Connection.ConnectionString = Lab2DBConnString;
            cmdLogin.CommandText = loginQuery;
            cmdLogin.Connection.Open();

            // ExecuteScalar() returns back data type Object
            // Use a typecast to convert this to an int.
            // Method returns first column of first row.
            int rowCount = (int)cmdLogin.ExecuteScalar();

            return rowCount;
        }

        //used with Parameterized Login
        public static int SecureLogin(string UserName, string Password)
        {
            string loginQuery =
                "SELECT COUNT(*) FROM Employee where UserName = @UserName and Password = @Password";

            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = Lab2DBConnection;
            cmdLogin.Connection.ConnectionString = Lab2DBConnString;

            cmdLogin.CommandText = loginQuery;
            cmdLogin.Parameters.AddWithValue("@UserName", UserName);
            cmdLogin.Parameters.AddWithValue("@Password", Password);
            //sends query with the inputted values from the user to compare in the DB

            cmdLogin.Connection.Open();

            // ExecuteScalar() returns back data type Object
            // Use a typecast to convert this to an int.
            // Method returns first column of first row.
            int rowCount = (int)cmdLogin.ExecuteScalar();

            return rowCount;
        }
        
        public static int GetEmployeeID(string query)
        {
            SqlCommand cmd = new SqlCommand(query, Lab2DBConnection);
            Lab2DBConnection.Open();
            int employeeID = (int)cmd.ExecuteScalar();
            Lab2DBConnection.Close();
            return employeeID;
        }


    }
}


