using Admin.Models.Abstract;

namespace Admin.Models.Concretes;

public class Category : BaseEntity
{
    //Default Olaraq ImagePath = "White Background"
    public string? ImagePath { get; set; } = "pack://application:,,,/Admin;component/Photos/whiteBackGround.jpg"; 
    public string? Name { get; set; }
    public ICollection<Product>? Products { get; set; }


    public override string ToString() => $"{Name}";

}
