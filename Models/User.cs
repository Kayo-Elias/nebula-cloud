using System.ComponentModel.DataAnnotations;

namespace NebulaCloud.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [MaxLength(25)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Password { get; set; } = string.Empty;

    [Required]
    public EUserRole ERole { get; set; } = EUserRole.Member;

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