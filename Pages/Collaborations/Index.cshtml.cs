//Jessica Shamloo, Thomas Hodges & Nick Patterson
using Lab2.Pages.DataClasses;
using Lab2.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;

namespace Lab2.Pages.Collaborations
{
    public class IndexModel : PageModel
    {
        public List<Collaboration> CollaborationTable { get; set; }
        public List<KnowledgeItem> Knowledges { get; set; }
        public List<SelectListItem> EmployeeList { get; set; } = new();
        public List<Plans> PlansTable { get; set; }

        [BindProperty]
        public List<KnowledgeItem> KnowledgeNames { get; set; }

        public int KnowledgeNamesCount { get; set; }

        public List<KnowledgeItem> KnowledgeItemsTable { get; set; }

        [BindProperty]
        public KnowledgeItem KnowledgeItemView { get; set; }

        [BindProperty]
        public int EmployeeID { get; set; }

        public List<DataFile> DataTable { get; set; }

        public int ChatID { get; set; }

        public int CollabID { get; set; }

        [BindProperty]
        public String UserName { get; set; }


        [BindProperty]
        [Required]
        public Chat NewChats { get; set; }


        public string ChatMessage { get; set; }

        [BindProperty]
        public List<Chat> NewChat { get; set; }

        public List<SelectListItem> DataList { get; set; } = new();

        [BindProperty]
        public int DataID { get; set; }

        public IndexModel()
        {
            CollaborationTable = new List<Collaboration>();
            Knowledges = new List<KnowledgeItem>();
            KnowledgeItemView = new KnowledgeItem();
            KnowledgeNames = new List<KnowledgeItem>();
            PlansTable = new List<Plans>();
            DataTable = new List<DataFile>();
            NewChat = new List<Chat>();
            KnowledgeItemsTable =new List<KnowledgeItem>();
    }

        public IActionResult OnGet(int EmployeeID)
        {

            if (HttpContext.Session.GetString("UserName") != null) //by now, the UserName parameter and its value has already been validated
            {
                

                SqlDataReader TableReader = DBClass.KnowledgeItemReader();
                while (TableReader.Read())
                {
                    KnowledgeItemsTable.Add(new KnowledgeItem
                    {
                        KnowledgeId = Int32.Parse(TableReader["KnowledgeId"].ToString()),
                        Name = TableReader["Name"].ToString(),
                        Subject = TableReader["Subject"].ToString(),
                        Category = TableReader["Category"].ToString(),
                        Information = TableReader["Information"].ToString(),
                        KnowledgeDateTime = ((DateTime)TableReader["KnowledgeDateTime"])
                    }
                );
                }

                // Close your connection in DBClass
                DBClass.Lab2DBConnection.Close();


                SqlDataReader EmployeeReader = DBClass.GeneralReaderQuery("SELECT EmployeeID, CONCAT(FirstName, ' ', LastName) AS Name FROM Employee");
                EmployeeList = new List<SelectListItem>();
                while (EmployeeReader.Read())
                {
                    EmployeeList.Add(new SelectListItem
                    {
                        Text = EmployeeReader["Name"].ToString(),
                        Value = EmployeeReader["EmployeeID"].ToString()
                    });
                }
                DBClass.Lab2DBConnection.Close(); // Close the reader after use


                SqlDataReader dataReader = DBClass.DataFileReader();
                while (dataReader.Read())
                {
                    DataTable.Add(new DataFile
                    {
                        DataID = Int32.Parse(dataReader["DataID"].ToString()),
                        DataName = dataReader["DataName"].ToString(),
                        DataLocation = dataReader["DataLocation"].ToString(),
                        DataDescription = dataReader["DataDescription"].ToString(),
                    });
                }
                DBClass.Lab2DBConnection.Close();


                SqlDataReader PlansReader = DBClass.PlansReader(); //change to plansreader(CollabID)
                while (PlansReader.Read())
                {
                    PlansTable.Add(new Plans
                    {
                        PlanID = Int32.Parse(PlansReader["PlanID"].ToString()),
                        PlanName = PlansReader["PlanName"].ToString(),
                        PlanConcept = PlansReader["PlanConcept"].ToString(),
                        DateCreated = ((DateTime)PlansReader["DateCreated"])
                    });
                }
                DBClass.Lab2DBConnection.Close();


                SqlDataReader chatreader = DBClass.ChatReader();

                while (chatreader.Read())
                {

                    NewChat.Add(new Chat
                    {
                        ChatID = Int32.Parse(chatreader["ChatID"].ToString()),
                        UserName = chatreader["UserName"].ToString(),
                        ChatMessage = chatreader["ChatMessage"].ToString(),
                        ChatDateTime = ((DateTime)chatreader["ChatDateTime"])
                    }
                );
                }

                DBClass.Lab2DBConnection.Close();


                return Page();
            }
            else
            {
                //creates a String with key of "LoginError" and a vlue of "You must login to access that page"
                HttpContext.Session.SetString("LoginError", "You must login to access that page!");

                return RedirectToPage("/Login/DBLogin");
            }
        }

        public IActionResult OnPost()
        {
            SqlDataReader TableReader = DBClass.KnowledgeItemReader();
            while (TableReader.Read())
            {
                KnowledgeItemsTable.Add(new KnowledgeItem
                {
                    KnowledgeId = Int32.Parse(TableReader["KnowledgeId"].ToString()),
                    Name = TableReader["Name"].ToString(),
                    Subject = TableReader["Subject"].ToString(),
                    Category = TableReader["Category"].ToString(),
                    Information = TableReader["Information"].ToString(),
                    KnowledgeDateTime = ((DateTime)TableReader["KnowledgeDateTime"])
                }
            );
            }

            // Close your connection in DBClass
            DBClass.Lab2DBConnection.Close();


            SqlDataReader EmployeeReader = DBClass.GeneralReaderQuery("SELECT EmployeeID, CONCAT(FirstName, ' ', LastName) AS Name FROM Employee");
            EmployeeList = new List<SelectListItem>();
            while (EmployeeReader.Read())
            {
                EmployeeList.Add(new SelectListItem
                {
                    Text = EmployeeReader["Name"].ToString(),
                    Value = EmployeeReader["EmployeeID"].ToString()
                });
            }
            DBClass.Lab2DBConnection.Close(); 

            SqlDataReader PlanReader = DBClass.PlansReader(); //repeated code from above
            while (PlanReader.Read())
            {
                PlansTable.Add(new Plans
                {

                    PlanName = PlanReader["PlanName"].ToString(),
                    PlanConcept = PlanReader["PlanConcept"].ToString(),
                    DateCreated = ((DateTime)PlanReader["DateCreated"])
                }

            );
            }
            DBClass.Lab2DBConnection.Close();

            SqlDataReader dataReader = DBClass.DataFileReader(); //repeated code from above
            while (dataReader.Read())
            {
                DataTable.Add(new DataFile
                {
                    DataID = Int32.Parse(dataReader["DataID"].ToString()),
                    DataName = dataReader["DataName"].ToString(),
                    DataLocation = dataReader["DataLocation"].ToString(),
                    DataDescription = dataReader["DataDescription"].ToString(),


                }
            );
            }
            DBClass.Lab2DBConnection.Close();

            


            SqlDataReader knowledgeItemReader = DBClass.SingleKnowledgeReader(EmployeeID);
            KnowledgeNamesCount = 0;
            while (knowledgeItemReader.Read())
            {
                
                KnowledgeNames.Add(new KnowledgeItem
                {
                    //KnowledgeId = Int32.Parse(TableReader["KnowledgeId"].ToString()),
                    Name = knowledgeItemReader["Name"].ToString(),
                    Subject = knowledgeItemReader["Subject"].ToString(),
                    Category = knowledgeItemReader["Category"].ToString(),
                    Information = knowledgeItemReader["Information"].ToString(),
                    KnowledgeDateTime = ((DateTime)knowledgeItemReader["KnowledgeDateTime"])
                }
                );
                KnowledgeNamesCount++;
                
            }

            DBClass.Lab2DBConnection.Close();
            
            
            SqlDataReader chatreader = DBClass.ChatReader();
            while (chatreader.Read())
            {

                NewChat.Add(new Chat
                {
                    ChatID = Int32.Parse(chatreader["ChatID"].ToString()),
                    UserName = chatreader["UserName"].ToString(),
                    ChatMessage = chatreader["ChatMessage"].ToString(),
                    ChatDateTime = ((DateTime)chatreader["ChatDateTime"])
                }
            );
            }


            return Page();

        }

        public IActionResult OnPostChatPost()
        {

            SqlDataReader TableReader = DBClass.KnowledgeItemReader();
            while (TableReader.Read())
            {
                KnowledgeItemsTable.Add(new KnowledgeItem
                {
                    KnowledgeId = Int32.Parse(TableReader["KnowledgeId"].ToString()),
                    Name = TableReader["Name"].ToString(),
                    Subject = TableReader["Subject"].ToString(),
                    Category = TableReader["Category"].ToString(),
                    Information = TableReader["Information"].ToString(),
                    KnowledgeDateTime = ((DateTime)TableReader["KnowledgeDateTime"])
                }
            );
            }

            // Close your connection in DBClass
            DBClass.Lab2DBConnection.Close();
            
            SqlDataReader EmployeeReader = DBClass.GeneralReaderQuery("SELECT EmployeeID, CONCAT(FirstName, ' ', LastName) AS Name FROM Employee");
            EmployeeList = new List<SelectListItem>();
            while (EmployeeReader.Read())
            {
                EmployeeList.Add(new SelectListItem
                {
                    Text = EmployeeReader["Name"].ToString(),
                    Value = EmployeeReader["EmployeeID"].ToString()
                });
            }
            DBClass.Lab2DBConnection.Close(); // Close the reader after use

            SqlDataReader PlanReader = DBClass.PlansReader();
            while (PlanReader.Read())
            {
                PlansTable.Add(new Plans
                {

                    PlanName = PlanReader["PlanName"].ToString(),
                    PlanConcept = PlanReader["PlanConcept"].ToString(),
                    DateCreated = ((DateTime)PlanReader["DateCreated"])
                }

            );
            }

            // Close your connection in DBClass
            DBClass.Lab2DBConnection.Close();

            SqlDataReader dataReader = DBClass.DataFileReader();
            while (dataReader.Read())
            {
                DataTable.Add(new DataFile
                {
                    DataID = Int32.Parse(dataReader["DataID"].ToString()),
                    DataName = dataReader["DataName"].ToString(),
                    DataLocation = dataReader["DataLocation"].ToString(),
                    DataDescription = dataReader["DataDescription"].ToString(),


                }
            );
            }
            DBClass.Lab2DBConnection.Close();

            int employeeId = (int)HttpContext.Session.GetInt32("EmployeeID");
            NewChats.EmployeeID = employeeId;

            DBClass.InsertChat(NewChats);
            
            DBClass.Lab2DBConnection.Close();

            SqlDataReader chatreader = DBClass.ChatReader();
            while (chatreader.Read())
            {
                NewChat.Add(new Chat
                {
                    ChatID = Int32.Parse(chatreader["ChatID"].ToString()),
                    ChatMessage = chatreader["ChatMessage"].ToString(),
                    ChatDateTime = ((DateTime)chatreader["ChatDateTime"]),
                    UserName = chatreader["UserName"].ToString(),
                    EmployeeID = employeeId
                }
            );
            }

            DBClass.Lab2DBConnection.Close();

            SqlDataReader knowledgeItemReader = DBClass.SingleKnowledgeReader(EmployeeID);
             
            KnowledgeNamesCount = 0;
            while (knowledgeItemReader.Read())
            {

                KnowledgeNames.Add(new KnowledgeItem
                {
                    Name = knowledgeItemReader["Name"].ToString(),
                    Subject = knowledgeItemReader["Subject"].ToString(),
                    Category = knowledgeItemReader["Category"].ToString(),
                    Information = knowledgeItemReader["Information"].ToString(),
                    KnowledgeDateTime = ((DateTime)knowledgeItemReader["KnowledgeDateTime"])
                }
                );
                KnowledgeNamesCount++;

            }

            DBClass.Lab2DBConnection.Close();

            return Page();
        }
    }
}