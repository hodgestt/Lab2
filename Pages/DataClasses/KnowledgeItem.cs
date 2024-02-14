//Jessica Shamloo * Thomas Hodges

using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Pages.DataClasses
{
    public class KnowledgeItem
    {
        public int KnowledgeId { get; set; }
        
        public String Name { get; set;}
        
        public String Subject { get; set;}
        
        public String Category { get; set;}
        
        public String Information { get; set;}
        
        public String KnowledgeDateTime { get; set;}

        public int EmployeeID { get; set; }

    }

}

