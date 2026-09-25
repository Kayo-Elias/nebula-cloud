using Microsoft.EntityFrameworkCore;
using NebulaCloud.Models;

namespace NebulaCloud.Data;

public class AppDbContext : DbContext
{
    public DbSet<Node> Nodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("DataSource=app.db; Cache=Shared"); 
    
}