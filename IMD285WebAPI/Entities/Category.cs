using System.ComponentModel.DataAnnotations;

namespace IMD285WebAPI.Entities;

public class Category
{
    [Key] public Guid Id { get; set; }
    [Required, MaxLength(50)] public string Name { get; set; }
    [Required, MaxLength(50)] public string HebrewName { get; set; }
    public ICollection<Product> Products { get; set; }
}
