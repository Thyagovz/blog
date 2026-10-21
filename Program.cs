using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using Microsoft.Data.SqlClient;

namespace Blog;

class Program
{
    private static readonly string? _connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
    static void Main(string[] args)
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();

        Load();

        Console.ReadKey();
        connection.Close();
    }

    private static void Load()
    {
        Console.Clear();
        Console.WriteLine("Meu Blog");
        Console.WriteLine(" ------------------");
        Console.WriteLine("0 que deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("1 - Gestão de usuário");
        Console.WriteLine("2 - Gestão de perfil");
        Console.WriteLine("3 - Gestao de categoria");
        Console.WriteLine("4 - Gestão de tag");
        Console.WriteLine("5 - Vincular perfil/usuário");
        Console.WriteLine("6 - Vincular post/tag");
        Console.WriteLine("7 - Relatórios");
        Console.WriteLine();
        Console.WriteLine();
        var option = short.Parse(Console.ReadLine()!);

        switch (option)
        {
            case 4:
                MenuTagScreen.Load();
                break;
            default: Load(); break;
        }
    }
}