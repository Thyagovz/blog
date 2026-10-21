using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public static class UpdateTagScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Atualizando uma tag");
        Console.WriteLine("-------------");

        Console.WriteLine("Id: ");
        var id = Console.ReadLine();


        Console.WriteLine("Nome: ");
        var name = Console.ReadLine();



        Console.WriteLine("Slug: ");
        var slug = Console.ReadLine();

        if (!int.TryParse(id, out var tagId))
        {
            Console.WriteLine("Id inválido.");
            return;
        }

        Update(new Tag
        {
            Id = tagId,
            Name = name ?? string.Empty,
            Slug = slug ?? string.Empty
        });
        Console.ReadKey();
        MenuTagScreen.Load();
    }
    public static void Update(Tag tag)
    {
        try
        {
            var repository = new Repository<Tag>(Database.Connection
                ?? throw new InvalidOperationException("A conexão com o banco de dados não está disponível."));
            repository.Create(tag);
            Console.WriteLine("Tag atualizada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível atualizar a tag");
            Console.WriteLine(ex.Message);
        }
    }
}