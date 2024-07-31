using Admin.Models.Abstract;

namespace Admin.Models.Concretes;

public class Admin : BaseEntity
{
    public string? FullName { get; set; }
    public string? AccountName { get; set; }
    public string? AccountPassword { get; set; }
}
