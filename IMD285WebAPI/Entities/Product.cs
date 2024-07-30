using System.ComponentModel.DataAnnotations;

namespace IMD285WebAPI.Entities;

public class Product
{
    [Key] public Guid Id { get; set; }
    [Required, MaxLength(50)] public string Name { get; set; }
    [Required, MaxLength(50)] public string HebrewName { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}
