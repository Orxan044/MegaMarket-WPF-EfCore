using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Admin.Data;

public class AdminDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["constrAdmin"].ConnectionString);

    }


    public DbSet<Models.Concretes.Admin> Admins { get; set; }
}
