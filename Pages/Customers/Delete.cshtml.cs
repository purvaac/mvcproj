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
    public class Delete : PageModel
    {
        

        public void OnGet(int id)
        {
            deleteCustomer(id);
            Response.Redirect("/Customers/Index");
        }

        public void OnPost(int id)
        {
            deleteCustomer(id);
            Response.Redirect("/Customers/Index");
        }

        private void deleteCustomer(int id){
            try
            {
                string connectionString = "Server=localhost;Database=crmdb;User Id=SA;Password=reallyStrongPwd123;Encrypt=False;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "DELETE FROM customer WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot Delete" + ex.Message);
            }
        }
    }
}