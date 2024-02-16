//Nick Patterson
// "import statements"
using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Lab2.Pages.CityDatas
{
    public class IndexModel : PageModel
    {

        public int CityID { get; set; }

        public string CityName { get; set; }

        public string Name { get; set; }

        public int Population { get; set; }

        public int IncomeTax { get; set; }

        [BindProperty]
        public int DataID { get; set; }

        [BindProperty]
        public List<CityData> NewCityData { get; set; }

        public IndexModel()
        {
            NewCityData = new List<CityData>();

        }

        public IActionResult OnGet()
        {

            if (HttpContext.Session.GetString("UserName") != null) //by now, the UserName parameter and its value has already been validated
            {
                SqlDataReader TableReader = DBClass.CityDataReader();
                while (TableReader.Read())
                {
                    NewCityData.Add(new CityData
                    {
                        CityID = Int32.Parse(TableReader["CityID"].ToString()),
                        CityName = TableReader["CityName"].ToString(),
                        Name = TableReader["Name"].ToString(),
                        Population = Int32.Parse(TableReader["Population"].ToString()),
                        IncomeTax = Int32.Parse(TableReader["IncomeTax"].ToString()),
                        DataID = Int32.Parse(TableReader["DataID"].ToString())
                    }
                );
                }
                // Close your connection in DBClass
                DBClass.Lab2DBConnection.Close();

                return Page();
            }
            else {

                //creates a String with key of "LoginError" and a vlue of "You must login to access that page"
                HttpContext.Session.SetString("LoginError", "You must login to access that page!");

                return Page(); 
            }
        }
    }
}
