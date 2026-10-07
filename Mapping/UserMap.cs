using Microsoft.EntityFrameworkCore;
using NebulaCloud.Models;

namespace NebulaCloud.Mapping;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
        .UseIdentityColumn()
        .IsRequired();
    
        builder.Property(x => x.Name)
        .IsRequired()
        .HasColumnName("Name")
        .HasColumnType("NVARCHAR")
        .HasMaxLength(25);

         builder.Property(x => x.Password)
        .IsRequired()
        .HasColumnName("Password")
        .HasMaxLength(50);

         builder.Property(x => x.ERole)
        .IsRequired()
        .HasColumnName("Role")
        .HasColumnType("INT")
        .HasMaxLength(20);

        builder.HasIndex(x => x.Name, "IX_User_Name")
        .IsUnique();

        builder.HasMany(x => x.Nodes)
        .WithOne(x => x.User)
        .HasForeignKey(x => x.UserId)
        .HasConstraintName("FK_User_Id")
        .IsRequired();
    }
}