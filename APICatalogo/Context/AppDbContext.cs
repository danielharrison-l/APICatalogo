using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base( options )
    {
    }

    public DbSet<Category>? Categorys { get; set; }
    public DbSet<Products>? Products { get; set; }
}
