//Jessica Shamloo & Thomas Hodges

// "import statements"
using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab2.Pages.Employees
{
    public class IndexModel : PageModel
    {

        public List<Employee> EmployeeTable { get; set; }

        public IndexModel()
        {
            EmployeeTable = new List<Employee>();
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("UserName") != null) //by now, the UserName parameter and its value has already been validated
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
                DBClass.Lab2DBConnection.Close();

                return Page();

            }
            else
            {
                //creates a String with key of "LoginError" and a vlue of "You must login to access that page"
                HttpContext.Session.SetString("LoginError", "You must login to access that page!");

                return RedirectToPage("/Login/DBLogin");
            }
        }
        

    }

}
        

       
