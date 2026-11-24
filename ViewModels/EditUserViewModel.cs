using System.ComponentModel.DataAnnotations;
using static NebulaCloud.Models.User;

namespace NebulaCloud.ViewModels;

public class EditUserViewModel
{
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(25, MinimumLength = 5, ErrorMessage = "Esse campo deve conter entre 5 e 25 caracteres")]
    public string Name { get; set; }
    [Required]
    public EUserRole ERole { get; set; }
}