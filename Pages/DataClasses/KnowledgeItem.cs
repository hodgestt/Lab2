//Jessica Shamloo

using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

namespace Lab1Part3.Pages.DataClasses
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

