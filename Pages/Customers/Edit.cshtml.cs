using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient; 

namespace mvcproj.Pages.Customers
{
    public class Edit : PageModel
    {
        [BindProperty]        
        public int Id { get; set; } 

    


        [BindProperty, Required(ErrorMessage = "First Name required")]        
        public string FirstName { get; set; } = "";

        [BindProperty, Required(ErrorMessage = "Last Name required")]
        public string LastName { get; set; } = "";

        [BindProperty, Required, EmailAddress]
        public string Email { get; set; } = "";

        [BindProperty, Phone]
        public string? Phone { get; set; }

        [BindProperty]
        public string? Address { get; set; }

        [BindProperty, Required]
        public string Company { get; set; } = "";

        [BindProperty]
        public string? Notes { get; set; }

        public string ErrorMessage { get; set; } = "";

        public void OnGet(int id)
        {
            try{
                string connectionString = "Server=localhost;Database=crmdb;User Id=SA;Password=reallyStrongPwd123;Encrypt=False;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM customer WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Id = reader.GetInt32(0);
                                FirstName = reader.GetString(1); // Fixed property name
                                LastName = reader.GetString(2); // Fixed property name
                                Email = reader.GetString(3);
                                Phone = reader.GetString(4);
                                Address = reader.GetString(5);
                                Company = reader.GetString(6);
                                Notes = reader.GetString(7);
                                
                            }
                            else{
                                Response.Redirect("/Customers/Index");
                            }
                        }
                        }
                }
            }

            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return;
            }
        }

        public void OnPost(){
            if (!ModelState.IsValid)
            {
                return;
            }

            if (Phone == null) Phone = "";
            if (Address == null) Address = "";
            if (Notes == null) Notes = "";

            try
            {
                string connectionString = "Server=localhost;Database=crmdb;User Id=SA;Password=reallyStrongPwd123;Encrypt=False;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "UPDATE customer SET firstname=@firstname, lastname=@lastname, email=@email,   " +
                                 "phone=@phone, address=@address, company=@company, notes=@notes WHERE id=@id;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", Id);
                        command.Parameters.AddWithValue("@firstname", FirstName);
                        command.Parameters.AddWithValue("@lastname", LastName);
                        command.Parameters.AddWithValue("@email", Email);
                        command.Parameters.AddWithValue("@phone", Phone);
                        command.Parameters.AddWithValue("@address", Address);
                        command.Parameters.AddWithValue("@company", Company);
                        command.Parameters.AddWithValue("@notes", Notes);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return;
            }
            Response.Redirect("/Customers/Index");
        }
    }
}