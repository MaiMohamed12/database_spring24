using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Threading.Tasks;
using project_Database.Models;
using System.Data;

namespace project_Database.Pages
{
    //test commit
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string Role { get; set; }

        [BindProperty]
        public bool IsLogin { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string connectionString = "Data Source=HASAAN\\MSSQLSERVER01;Initial Catalog=Project;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql;
                SqlCommand command;
                SqlDataReader reader;

                if (IsLogin)
                {
                    // Login logic
                    sql = $"SELECT * FROM {Role} WHERE Email = @Email AND Password = @Password AND Name =@Name;";
                    command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@Name", Name);
                    reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        // User credentials are valid.
                        reader.Close();
                        return RedirectToPage("index");
                    }
                    else
                    {
                        // User credentials are invalid.
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        reader.Close();
                        return Page();
                    }
                }
                else
                {
                    // Check if user already exists
                    sql = $"SELECT * FROM {Role} WHERE Email = @Email AND Name =@Name;";
                    command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Email", Email);
                    reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        // User already exists
                        ModelState.AddModelError(string.Empty, "A user with this email already exists.");
                        reader.Close();
                        return Page();
                    }
                    reader.Close();

                    // Sign up logic
                    sql = $"INSERT INTO {Role} (Email, Password,Name) VALUES (@Email, @Password, @Name)";
                    command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.ExecuteNonQuery();
                    return RedirectToPage("index");
                }
            }
        }
    }
}
