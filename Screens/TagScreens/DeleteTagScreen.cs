using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public static class DeleteTagScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Excluir uma tag");
        Console.WriteLine("-------------");

        Console.WriteLine("Qual o id da tag que deseja excluir? ");
        var id = Console.ReadLine();

        if (!int.TryParse(id, out var tagId))
        {
            Console.WriteLine("Id inválido.");
            return;
        }

        Delete(tagId);
        Console.ReadKey();
        MenuTagScreen.Load();
    }
    public static void Delete(int id)
    {
        try
        {
            var repository = new Repository<Tag>(Database.Connection
                ?? throw new InvalidOperationException("A conexão com o banco de dados não está disponível."));
            repository.Delete(id);
            Console.WriteLine("Tag excluída com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível excluir a tag");
            Console.WriteLine(ex.Message);
        }
    }
}