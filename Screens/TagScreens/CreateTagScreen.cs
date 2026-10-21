using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public static class CreateTagScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Nova tag");
        Console.WriteLine("-------------");
        Console.WriteLine("Nome: ");
        var name = Console.ReadLine();

        Console.WriteLine("Slug: ");
        var slug = Console.ReadLine();

        Create(new Tag
        {
            Name = name ?? string.Empty,
            Slug = slug ?? string.Empty
        });
        Console.ReadKey();
        MenuTagScreen.Load();
    }

    public static void Create(Tag tag)
    {
        try
        {
            var repository = new Repository<Tag>(Database.Connection
                ?? throw new InvalidOperationException("A conexão com o banco de dados não está disponível."));
            repository.Create(tag);
            Console.WriteLine("Tag cadastrada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível salvar a tag");
            Console.WriteLine(ex.Message);
        }
    }
}