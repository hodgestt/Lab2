//Nick Patterson
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Pages.DataClasses
{
    public class CityData
    {
        public int CityID { get; set; }

        public String CityName { get; set; }

        public String Name { get; set; }

        public int Population { get; set; }

        public decimal IncomeTax { get; set; }

        public int DataID { get; set; }
    }
}

