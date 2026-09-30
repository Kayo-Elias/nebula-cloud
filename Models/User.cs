using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NebulaCloud.Models;


[Table("User")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(25)]
    public string Name { get; set;}

    [Required]
    [MaxLength(20)]
    public string Password { get; set;}
    
    [Required]
    public EUserRole ERole { get; set;} = EUserRole.Member;

    public User () { }

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