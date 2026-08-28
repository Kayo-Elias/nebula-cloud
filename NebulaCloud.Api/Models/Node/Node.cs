using System.Net;

namespace Node;

public class Node
{
    public IPAddress? Ip { get; private set; }
    public string? Name { get; private set;}
    public NodeStatus Status { get; private set; }
    public double Memory { get; private set;}
    public double Storage { get; private set; }

    public Node() { }
    public Node (string name, IPAddress ip)
    {
        Name = name;
        Ip = ip;
    } 
}

public enum NodeStatus
{
    Offline,
    Online,
    Maintenance,
    Provisioning,
    Error
}