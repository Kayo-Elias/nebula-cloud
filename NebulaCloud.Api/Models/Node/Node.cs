using System.Net;

namespace Node;

public class Node
{
    public IPAddress Ip { get; set; }
    public string Name { get; set;}
    public NodeStatus Status { get; set; }
    public double Memory { get; set;}
    public double Storage { get; set; }
}

public enum NodeStatus
{
    Offline,
    Online,
    Maintenance,
    Provisioning,
    Error
}