//Jessica Shamloo

using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab1Part3.Pages.Employees
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





        }
    }
}