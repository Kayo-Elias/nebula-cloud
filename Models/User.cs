namespace NebulaCloud.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public EUserRole ERole { get; set; } = EUserRole.Member;
    public ICollection<Node> Nodes { get; set; } = new List<Node>();

    public User() { }

    public User(int id, string name, string password)
    {
        Id = id;
        Name = name;
        Password = password;
    }

    public enum EUserRole
    {
        Member = 0,
        Premium = 1,
        Administrador = 2
    }
}