using Admin.Models.Abstract;

namespace Admin.Models.Concretes;

public class Category : BaseEntity
{
    public string? ImagePath { get; set; } = null;
    public string? Name { get; set; }
    public ICollection<Product>? Products { get; set; }
}
