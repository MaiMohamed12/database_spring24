using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Threading.Tasks;
using project_Database.Models;
using System.Data;

namespace project_Database.Pages
{
    public class ResModel : PageModel
    {
        // Define a class representing a restaurant
        public class RestaurantViewModel
        {
            public string Name { get; set; }
            public string Location { get; set; }
            public double Rating { get; set; }
            public string Specialty { get; set; }
        }

        // List to hold the restaurants retrieved from the database
        public List<RestaurantViewModel> Restaurants { get; set; }

        public void OnGet()
        {
            string connectionString = "Data Source=HASAAN\\MSSQLSERVER01;Initial Catalog=Project;Integrated Security=True;";
            string sql = "SELECT Name, Location, Rating, Specialty FROM Restaurants;"; // Adjust query as per your database schema
            Restaurants = new List<RestaurantViewModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // Map data from SqlDataReader to RestaurantViewModel
                    RestaurantViewModel restaurant = new RestaurantViewModel
                    {
                        Name = reader["Name"].ToString(),
                        Location = reader["Location"].ToString(),
                        Rating = double.Parse(reader["Rating"].ToString()), // Assuming Rating is stored as a numeric value
                        Specialty = reader["Specialty"].ToString()
                    };
                    Restaurants.Add(restaurant);
                }

                reader.Close();
            }
        }
    }
}