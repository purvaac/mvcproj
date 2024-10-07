using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;

namespace mvcproj.Pages.Customers
{
    public class Index : PageModel
    {
        public List<CustomerInfo> CustomersList { get; set; } = new List<CustomerInfo>();

        private readonly ILogger<Index> _logger;

        public Index(ILogger<Index> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            try
            {
                string connectionString = "Server=localhost;Database=crmdb;User Id=SA;Password=reallyStrongPwd123;Encrypt=False;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Add code to retrieve customer data here.
                    string sql = "SELECT * FROM customer ORDER BY id DESC";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerInfo customerInfo = new CustomerInfo();
                                customerInfo.Id = reader.GetInt32(0);
                                customerInfo.FirstName = reader.GetString(1); // Fixed property name
                                customerInfo.LastName = reader.GetString(2); // Fixed property name
                                customerInfo.Email = reader.GetString(3);
                                customerInfo.Phone = reader.GetString(4);
                                customerInfo.Address = reader.GetString(5);
                                customerInfo.Company = reader.GetString(6);
                                customerInfo.Notes = reader.GetString(7);
                                customerInfo.CreatedAt = reader.GetDateTime(8).ToString("MM/dd/yyyy"); // Fixed method name

                                CustomersList.Add(customerInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: {Message}", ex.Message);
            }
        }
    }

    public class CustomerInfo
    {
        public int Id { get; set; }                      // Maps to the 'id' column
        public string FirstName { get; set; } = "";      // Fixed property name
        public string LastName { get; set; } = "";       // Fixed property name
        public string Email { get; set; } = "";          // Maps to the 'email' column
        public string Phone { get; set; } = "";          // Maps to the 'phone' column
        public string Address { get; set; } = "";        // Maps to the 'address' column
        public string Company { get; set; } = "";        // Maps to the 'company' column
        public string Notes { get; set; } = "";          // Maps to the 'notes' column
        public string CreatedAt { get; set; } = "";      // Maps to the 'created_at' column
    }
}
