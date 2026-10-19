using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog;

class Program
{
    private static readonly string? _connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
    static void Main(string[] args)
    {
        ReadUsers();
    }

    public static void ReadUsers()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            
            var users = connection.GetAll<User>();

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }
        }
    }
}