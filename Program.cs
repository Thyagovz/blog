using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog;

class Program
{
    private static readonly string? _connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
    static void Main(string[] args)
    {
        var connection = new SqlConnection(_connectionString);

        connection.Open();
        ReadUsers(connection);
        // ReadUser();
        // CreateUser();
        // UpdateUser();
        // DeleteUser();
        connection.Close();

    }
    public static void ReadUsers(SqlConnection connection)
    {
        var repository = new UserRepository(connection);
        var users = repository.Get();

        foreach (var user in users)
            Console.WriteLine(user.Name);
    }
    public static void ReadUser()
    {
        using (var connection = new SqlConnection())
        {
            connection.Open();

            var user = connection.Get<User>(1);
            Console.WriteLine(user?.Name);
        }
    }
    public static void CreateUser()
    {
        var user = new User()
        {
            Bio = "Equipe thyago.io",
            Email = "hello@thyago.io",
            Image = "http://...",
            Name = "Equipe thyago.io",
            PasswordHash = "HASH",
            Slug = "equipe-thyago"
        };
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            connection.Insert<User>(user);
            Console.WriteLine("Cadastro realizado com sucesso");
        }
    }
    public static void UpdateUser()
    {
        var user = new User()
        {
            Id = 1,
            Bio = "Equipe | thyago.io",
            Email = "hello@thyago.io",
            Image = "http://...",
            Name = "Equipe de suporte thyago.io",
            PasswordHash = "HASH",
            Slug = "equipe-thyago"
        };
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            connection.Update<User>(user);
            Console.WriteLine("Atualização realizado com sucesso");
        }
    }
    public static void DeleteUser()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var user = connection.Get<User>(1);
            connection.Delete<User>(user);
            Console.WriteLine("Exclusão realizada com sucesso!");
        }
    }
}