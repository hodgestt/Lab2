﻿//Nick Patterson & Jessica Shamloo
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Pages.DataClasses
{
    public class Plans
    {
        public int PlanID { get; set; }
        public String PlanName { get; set; }
        public String PlanConcept { get; set; }
        public String DateCreated { get; set; }
        
        public int CollabID { get; set; }

        
    }
}