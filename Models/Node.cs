namespace NebulaCloud.Models;

public class Node
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public string Ip { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

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