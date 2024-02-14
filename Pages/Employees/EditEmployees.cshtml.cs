//Jessica Shamloo

using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab2.Pages.Employees
{
    public class EditEmployeesModel : PageModel
    {

        [BindProperty]
        public Employee EmployeeToUpdate { get; set; }

        public EditEmployeesModel() 
        { 
            EmployeeToUpdate = new Employee();
        } 


        public void OnGet(int employeeid)
        {
            SqlDataReader singleEmployee = DBClass.SingleEmployeeReader(employeeid);
            while (singleEmployee.Read())
            {
                EmployeeToUpdate.EmployeeID = employeeid;
                EmployeeToUpdate.FirstName = singleEmployee["FirstName"].ToString();
                EmployeeToUpdate.LastName = singleEmployee["LastName"].ToString();
                EmployeeToUpdate.Email = singleEmployee["Email"].ToString();
                EmployeeToUpdate.Phone = singleEmployee["Phone"].ToString();
                EmployeeToUpdate.Street = singleEmployee["Street"].ToString();
                EmployeeToUpdate.City = singleEmployee["City"].ToString();
                EmployeeToUpdate.State = singleEmployee["State"].ToString();
                EmployeeToUpdate.Zip = singleEmployee["Zip"].ToString();
                EmployeeToUpdate.UserName = singleEmployee["UserName"].ToString();
                EmployeeToUpdate.Password = singleEmployee["Password"].ToString();
            }
            DBClass.Lab2DBConnection.Close();
        }

        public IActionResult OnPost()
        {
            DBClass.UpdateEmployee(EmployeeToUpdate);
            DBClass.Lab2DBConnection.Close();
            return RedirectToPage("Index");
        }
    }
}