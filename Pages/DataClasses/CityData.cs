//Nick Patterson
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Pages.DataClasses
{
    public class CityData
    {
        public int CityID { get; set; }

        public String CityName { get; set; }

        public String StateName { get; set; }

        public int CityPopulation { get; set; }

        public decimal CityIncomeTax { get; set; }

        public int DataID { get; set; }
    }
}

