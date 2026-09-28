using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NebulaCloud.Models;

[Table("Node")]
public class Node
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(45)]
    public string Ip { get; set; } = string.Empty;

    [Required]
    [MaxLength(15)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public ENodeStatus Status { get; set; } = ENodeStatus.Offline;
    public double Memory { get; set; }
    public double Storage { get; set; }
    public DateTime CreatedAt { get; set; }
    public TimeSpan SessionDuration { get; set; }

    public Node() { }
    public Node(string name, string ip, DateTime createdAt)
    {
        Name = name;
        Ip = ip;
        CreatedAt = createdAt;
    } 
}

public enum ENodeStatus
{
    Offline = 0,
    Online = 1,
    Maintenance = 2,
    Provisioning = 3,
    Error = 4
}