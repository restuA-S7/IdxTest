using Microsoft.EntityFrameworkCore;
using myappAPI.Models; 

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<User>? Users { get; set; }
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     if (!optionsBuilder.IsConfigured)
    //     {
    //         optionsBuilder.UseSqlite("Data Source=my_database.db");
    //     }
    //     //base.OnConfiguring(optionsBuilder);
    // }
}