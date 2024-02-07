// "import statements"
using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
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
            SqlDataReader employeeReader = DBClass.EmployeeReader();
            while (employeeReader.Read())
            {
                EmployeeTable.Add(new Employee
                {

                    EmployeeID = Int32.Parse(employeeReader["EmployeeID"].ToString()),
                    FirstName = employeeReader["FirstName"].ToString(),
                    LastName = employeeReader["LastName"].ToString(),
                    Email = employeeReader["Email"].ToString(),
                    Phone = employeeReader["Phone"].ToString(),
                    Street = employeeReader["Street"].ToString(),
                    City = employeeReader["City"].ToString(),
                    State = employeeReader["State"].ToString(),
                    Zip = employeeReader["Zip"].ToString(),
                    UserName = employeeReader["UserName"].ToString(),
                    Password = employeeReader["Password"].ToString()
                }
            );
            }
        
            // Close your connection in DBClass
            DBClass.LABTHREEDBConnection.Close();
        }
    }
}