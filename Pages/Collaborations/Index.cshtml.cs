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

        public int KnowledgeId { get; set; }

        public int DataCount { get; set; }
        public List<DataFile> DataFileNames { get; set; }

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


                SqlDataReader chatreader = DBClass.ChatReader(); //goal is to remove

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

                SqlDataReader DataReader = DBClass.GeneralReaderQuery("SELECT DataID, DataName FROM DataFile");
                DataList = new List<SelectListItem>();
                while (DataReader.Read())
                {
                    DataList.Add(new SelectListItem
                    {
                        Text = DataReader["DataName"].ToString(),
                        Value = DataReader["DataID"].ToString()
                    });
                }
                DBClass.Lab2DBConnection.Close(); // Close the reader after use


                return Page();
            }
            else
            {
                HttpContext.Session.SetString("LoginError", "You must login to access that page!");

                return RedirectToPage("/Login/DBLogin");
            }
        }

        public IActionResult OnPost()
        {
            
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

            
            SqlDataReader knowledgeItemReader = DBClass.SingleKnowledgeReader(EmployeeID, KnowledgeId);
            KnowledgeNamesCount = 0;
            while (knowledgeItemReader.Read())
            {
                
                KnowledgeNames.Add(new KnowledgeItem
                {
                    KnowledgeId = Int32.Parse(knowledgeItemReader["KnowledgeId"].ToString()),
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

            SqlDataReader DataReader = DBClass.GeneralReaderQuery("SELECT DataID, DataName FROM DataFile");
            DataList = new List<SelectListItem>();
            while (DataReader.Read())
            {
                DataList.Add(new SelectListItem
                {
                    Text = DataReader["DataName"].ToString(),
                    Value = DataReader["DataID"].ToString()
                });
            }
            DBClass.Lab2DBConnection.Close(); // Close the reader after use


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

            SqlDataReader knowledgeItemReader = DBClass.SingleKnowledgeReader(EmployeeID, KnowledgeId);
             
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

            SqlDataReader DataReader = DBClass.GeneralReaderQuery("SELECT DataID, DataName FROM DataFile");
            DataList = new List<SelectListItem>();
            while (DataReader.Read())
            {
                DataList.Add(new SelectListItem
                {
                    Text = DataReader["DataName"].ToString(),
                    Value = DataReader["DataID"].ToString()
                });
            }
            DBClass.Lab2DBConnection.Close(); // Close the reader after use


            return Page();
        }

        public IActionResult OnPostDataPost()
        {
            SqlDataReader DataReader = DBClass.GeneralReaderQuery("SELECT DataID, DataName FROM DataFile");
            DataList = new List<SelectListItem>();
            while (DataReader.Read())
            {
                DataList.Add(new SelectListItem
                {
                    Text = DataReader["DataName"].ToString(),
                    Value = DataReader["DataID"].ToString()
                });
            }
            DBClass.Lab2DBConnection.Close(); // Close the reader after use

            int selectedDataID = DataID;
            string redirectUrl;

            switch (selectedDataID)
            {
                case 1:
                    redirectUrl = "/GroceryDatas/Index";
                    break;
                case 2:
                    redirectUrl = "/CityDatas/Index";
                    break;
                default:
                    redirectUrl = "/DataFiles/Index";
                    break;
            }
            return RedirectToPage(redirectUrl);
        }

    }
}