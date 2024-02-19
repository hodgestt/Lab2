using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab2.Pages.GroceryDatas
{
    public class IndexModel : PageModel
    {
        public int GroceryID { get; set; }

        public String Item { get; set; }

        public decimal Price { get; set; }

        public String ExpirationDate { get; set; }

        [BindProperty]
        public int DataID { get; set; }

        [BindProperty]
        public List<GroceryData> NewGroceryData { get; set; }

        public IndexModel()
        {
            NewGroceryData = new List<GroceryData>();

        }

        public IActionResult OnGet()
        {

            if (HttpContext.Session.GetString("UserName") != null) //by now, the UserName parameter and its value has already been validated
            {
                SqlDataReader TableReader = DBClass.GroceryDataReader();
                while (TableReader.Read())
                {
                    NewGroceryData.Add(new GroceryData
                    {
                        GroceryID = Int32.Parse(TableReader["GroceryID"].ToString()),
                        Item = TableReader["Item"].ToString(),
                        Price = Int32.Parse(TableReader["Price"].ToString()),
                        ExpirationDate = TableReader["ExpirationDate"].ToString(),
                        DataID = Int32.Parse(TableReader["DataID"].ToString())
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

                return Page();
            }
        }
    }
}
