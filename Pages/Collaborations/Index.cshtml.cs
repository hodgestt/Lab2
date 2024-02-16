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

        [BindProperty]
        public KnowledgeItem KnowledgeItemView { get; set; }

        [BindProperty]
        public int EmployeeID { get; set; }

        public List<DataFile> DataTable { get; set; }

        public int ChatID { get; set; }


        public string ChatDateTime { get; set; }


        [BindProperty]
        [Required]
        public Chat NewChats { get; set; }


        public string ChatMessage { get; set; }

        [BindProperty]
        public List<Chat> NewChat { get; set; }

        public IndexModel()
        {
            CollaborationTable = new List<Collaboration>();
            Knowledges = new List<KnowledgeItem>();
            KnowledgeItemView = new KnowledgeItem();
            KnowledgeNames = new List<KnowledgeItem>();
            PlansTable = new List<Plans>();
            DataTable = new List<DataFile>();
            NewChat = new List<Chat>();
        }

        public void OnGet(int EmployeeID)
        {
            SqlDataReader TableReader = DBClass.CollabReader();
            while (TableReader.Read())
            {
                CollaborationTable.Add(new Collaboration
                {
                    CollabID = Int32.Parse(TableReader["CollabID"].ToString()),
                    TeamName = TableReader["TeamName"].ToString(),
                    NotesAndInformation = TableReader["NotesAndInformation"].ToString()
                });
            }
            DBClass.Lab2DBConnection.Close(); // Close the reader after use

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
                    DateCreated = PlanReader["DateCreated"].ToString()
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

            SqlDataReader chattablereader = DBClass.ChatReader();
            while (chattablereader.Read())
            {
                NewChat.Add(new Chat
                {
                    ChatID = Int32.Parse(chattablereader["ChatID"].ToString()),
                    ChatMessage = chattablereader["ChatMessage"].ToString(),
                    ChatDateTime = chattablereader["ChatDateTime"].ToString(),
                    EmployeeID = Int32.Parse(chattablereader["EmployeeID"].ToString())
                }
            );
            }
            // Close your connection in DBClass
            DBClass.Lab2DBConnection.Close();
        }

        public IActionResult OnPost()
        {
            SqlDataReader TableReader = DBClass.CollabReader();
            while (TableReader.Read())
            {
                CollaborationTable.Add(new Collaboration
                {
                    CollabID = Int32.Parse(TableReader["CollabID"].ToString()),
                    TeamName = TableReader["TeamName"].ToString(),
                    NotesAndInformation = TableReader["NotesAndInformation"].ToString()
                });
            }
            DBClass.Lab2DBConnection.Close(); // Close the reader after use

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
                    DateCreated = PlanReader["DateCreated"].ToString()
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

            

            DBClass.Lab2DBConnection.Close();

            SqlDataReader knowledgeItemReader = DBClass.SingleKnowledgeReader(EmployeeID);
            while (knowledgeItemReader.Read())
            {
                KnowledgeNames.Add(new KnowledgeItem
                {
                    Name = knowledgeItemReader["Name"].ToString()
                }
                );
                
            }

            DBClass.Lab2DBConnection.Close();

            SqlDataReader chatstablereader = DBClass.ChatReader();
            while (TableReader.Read())
            {
                NewChat.Add(new Chat
                {
                    ChatID = Int32.Parse(chatstablereader["ChatID"].ToString()),
                    ChatMessage = chatstablereader["ChatMessage"].ToString(),
                    ChatDateTime = chatstablereader["ChatDateTime"].ToString(),
                    EmployeeID = Int32.Parse(chatstablereader["EmployeeID"].ToString())
                }
            );
            }

            return Page();

        }

        public IActionResult OnPostChatPost()
        {

            DBClass.InsertChat(NewChats);

            DBClass.Lab2DBConnection.Close();

            SqlDataReader TableReader = DBClass.CollabReader();
            while (TableReader.Read())
            {
                CollaborationTable.Add(new Collaboration
                {
                    CollabID = Convert.ToInt32(TableReader["CollabID"]),
                    TeamName = TableReader["TeamName"].ToString(),
                    NotesAndInformation = TableReader["NotesAndInformation"].ToString()
                });
            }
            DBClass.Lab2DBConnection.Close(); // Close the reader after use

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
                    DateCreated = PlanReader["DateCreated"].ToString()
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
            
            SqlDataReader chatstablereader = DBClass.ChatReader();
            while (TableReader.Read())
            {
                NewChat.Add(new Chat
                {
                    ChatID = Int32.Parse(chatstablereader["ChatID"].ToString()),
                    ChatMessage = chatstablereader["ChatMessage"].ToString(),
                    ChatDateTime = chatstablereader["ChatDateTime"].ToString(),
                    EmployeeID = Int32.Parse(chatstablereader["EmployeeID"].ToString())
                }
            );
            }

            DBClass.Lab2DBConnection.Close();

            SqlDataReader knowledgeItemReader = DBClass.SingleKnowledgeReader(EmployeeID);
            while (knowledgeItemReader.Read())
            {
                KnowledgeNames.Add(new KnowledgeItem
                {
                    Name = knowledgeItemReader["Name"].ToString()
                }
                );

            }

            DBClass.Lab2DBConnection.Close();

            return RedirectToPage("/Collaborations/Index");
        }
    }
}