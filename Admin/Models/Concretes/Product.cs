using Admin.Models.Abstract;


namespace Admin.Models.Concretes;

public class Product : BaseEntity
{
    public string? ImagePath { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? Quantity { get; set; }
    public int? CategoryId { get; set; }
    public double? Price { get; set; }
    public bool? IsSpecial { get; set; } = false;
    public Category? Category { get; set; }

    public Product Clone() => new() { Id = Id , ImagePath = ImagePath, Name = Name, Description = Description, Quantity = Quantity, CategoryId = CategoryId, Price = Price, IsSpecial = IsSpecial , Category = Category };

}
