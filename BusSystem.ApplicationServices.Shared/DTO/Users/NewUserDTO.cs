using System.ComponentModel.DataAnnotations;
using BusSystem.Core.Users;

namespace BusSystem.ApplicationServices.Shared.DTO.Users;

public class NewUserDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
}