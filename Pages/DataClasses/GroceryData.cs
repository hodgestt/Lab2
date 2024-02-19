//Nick Patterson
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Pages.DataClasses
{
    public class GroceryData
    {
        public int GroceryID { get; set; }

        public String Item { get; set; }

        public decimal Price { get; set; }

        public String ExpirationDate { get; set; }

        public int DataID { get; set; }
    }
}
