using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Group_Project.Models;
using Group_Project.Pages.DatabaseConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group_Project.Pages.User
{
    public class DeleteUsersModel : PageModel
    {
        [BindProperty]
        public List<Users> Users { get; set; } 
        [BindProperty]
        public List<bool> IsSelect { get; set; } 
        public List<Users> UserToDelete { get; set; } 

        public IActionResult OnGet()
        {
            DatabaseConnect dbstring = new DatabaseConnect();
            string DbConnection = dbstring.DatabaseString();
            SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = "SELECT * FROM Users";

                SqlDataReader reader = command.ExecuteReader();

                Users = new List<Users>(); 
                IsSelect = new List<bool>();
                while (reader.Read())
                {
                    Users rec = new Users();
                    rec.Id = reader.GetInt32(0); 
                    rec.UserID = reader.GetString(1);
                    rec.FirstName = reader.GetString(2);
                    rec.LastName = reader.GetString(3);
                    rec.EmailAddress = reader.GetString(4);
                    rec.Password = reader.GetString(5);
                    rec.Role = reader.GetString(6);
                    Users.Add(rec);
                    IsSelect.Add(false);
                    
                }
            }


            return Page();

        }
        public IActionResult OnPost()
        {
            UserToDelete = new List<Users>();
            for (int i = 0; i < Users.Count; i++) 
            {
                if (IsSelect[i] == true) 
                {
                    UserToDelete.Add(Users[i]); 
                }
            }

            Console.WriteLine("Users to be deleted : ");

            for (int i = 0; i < UserToDelete.Count(); i++)
            {
                Console.WriteLine(UserToDelete[i].Id); 
                Console.WriteLine(UserToDelete[i].UserID); 
                Console.WriteLine(UserToDelete[i].FirstName);
                Console.WriteLine(UserToDelete[i].LastName);
                Console.WriteLine(UserToDelete[i].EmailAddress);
                Console.WriteLine(UserToDelete[i].Role);

            }

            DatabaseConnect dbstring = new DatabaseConnect();
            string DbConnection = dbstring.DatabaseString();
            SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();

            for (int i = 0; i < UserToDelete.Count(); i++)
            {

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = @"DELETE FROM Users WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Id", UserToDelete[i].Id);
                    command.ExecuteNonQuery();
                }
            }

            return RedirectToPage("/AdminPages/AdminIndex");


        }
    }
}
