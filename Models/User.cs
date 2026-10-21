using Dapper.Contrib.Extensions;

namespace Blog.Models;

[Table("[User]")]
public class User
{
    [Key] public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;

    [Write(false)]
    public List<Role> Roles { get; set; } = new();
}