//Jessica Shamloo

// "import statements"
using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab1Part3.Pages.Employees
{
    public class IndexModel : PageModel
    {

        public List<Employee> EmployeeTable { get; set; }

        public IndexModel()
        {
            EmployeeTable = new List<Employee>();
        }

        public void OnGet()
        {
            SqlDataReader TableReader = DBClass.EmployeeReader();
            while (TableReader.Read())
            {
                EmployeeTable.Add(new Employee
                {

                    EmployeeID = Int32.Parse(TableReader["EmployeeID"].ToString()),
                    FirstName = TableReader["FirstName"].ToString(),
                    LastName = TableReader["LastName"].ToString(),
                    Email = TableReader["Email"].ToString(),
                    Phone = TableReader["Phone"].ToString(),
                    Street = TableReader["Street"].ToString(),
                    City = TableReader["City"].ToString(),
                    State = TableReader["State"].ToString(),
                    Zip = TableReader["Zip"].ToString(),
                    UserName = TableReader["UserName"].ToString(),
                    Password = TableReader["Password"].ToString()
                }
            );
            }

            // Close your connection in DBClass
            DBClass.Lab1DBConnection.Close();
        }
        

    }

}
        

       
