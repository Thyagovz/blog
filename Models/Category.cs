using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Category]")]
    public class Category
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
    }
}