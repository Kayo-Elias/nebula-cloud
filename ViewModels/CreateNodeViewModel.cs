using System.ComponentModel.DataAnnotations;
using NebulaCloud.Models;

namespace NebulaCloud.ViewModels;

public class CreateNodeViewModel
{
    [Required]
    public string Ip { get; set; } = string.Empty;
    [Required]
    public int UserId { get; set; }
    [Required]
    [StringLength(25, MinimumLength = 5, ErrorMessage = "Esse campo deve conter entre 5 e 15 caracteres")]
    public string Name { get; set; } = string.Empty;
    [Required]    
    public ENodeStatus Status { get; private set; } 
    [Required]
    public DateTime CreatedAt { get; private set; } 
}