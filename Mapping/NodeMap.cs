using Microsoft.EntityFrameworkCore;
using NebulaCloud.Models;

namespace NebulaCloud.Mapping;

public class NodeMap : IEntityTypeConfiguration<Node>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Node> builder)
    {
        builder.ToTable("Node");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
        .IsRequired()
        .UseIdentityColumn();

        builder.Property(x => x.Name)
        .IsRequired()
        .HasColumnName("Name")
        .HasColumnType("NVARCHAR")
        .HasMaxLength(25);

        builder.Property(x => x.Ip)
        .IsRequired()
        .HasColumnName("Ip")
        .HasMaxLength(45);

        builder.Property(x => x.Status)
        .IsRequired()
        .HasColumnName("Status");

        builder.Property(x => x.Memory)
        .IsRequired()
        .HasColumnName("Memory")
        .HasColumnType("FLOAT");

        builder.Property(x => x.Storage)
        .IsRequired()
        .HasColumnName("Storage")
        .HasColumnType("FLOAT");

        builder.Property(x => x.CreatedAt)
        .IsRequired()
        .HasColumnName("CreatedAt")
        .HasColumnType("DATETIME");

        builder.Property(x => x.SessionDuration)
        .IsRequired()
        .HasColumnName("SessionDuration")
        .HasColumnType("TIME");

        builder.HasIndex(x => x.Name, "IX_Node_Name")
        .IsUnique();

        builder.HasIndex(x => x.Ip, "IX_Node_Ip")
        .IsUnique();
    }
}