using Microsoft.EntityFrameworkCore;

namespace Node.Data;

public class AppDbContext : DbContext
{
    public DbSet<Node> Nodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("DataSource=app.db; Cache=Shared"); 
    
}