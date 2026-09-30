using Microsoft.EntityFrameworkCore;
using NebulaCloud.Models;

namespace NebulaCloud.Data;

public class AppDbContext : DbContext
{
    public DbSet<Node> Nodes { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=NebulaCloud;User ID=sa;Password=1q2w3e4r@#$");
}