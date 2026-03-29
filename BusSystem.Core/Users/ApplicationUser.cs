using System.ComponentModel.DataAnnotations;
using BusSystem.Core.Tickets;
using Microsoft.AspNetCore.Identity;
namespace BusSystem.Core.Users;
public enum Gender
{
    Male,
    Female,
    Other
}
public class ApplicationUser : IdentityUser
{
    [Required] 
    public string FirstName { get; set; } = null!;
    [Required] 
    public string LastName { get; set; } = null!;
    [Required]
    public DateTime DateOfBirth { get; set; }
    [Required]
    public Gender Gender { get; set; }
    
    public ICollection<Ticket> Tickets { get; set; }
    
}