using Mega_Market.Models.Abstract;

namespace Mega_Market.Models.Concretes;

public class User : BaseEntity
{
    public string? ImagePath {  get; set; } 
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateTime? DateOfBrithday { get; set; }
    public string? Mail { get; set; }
    public string? Password { get; set; }
}
