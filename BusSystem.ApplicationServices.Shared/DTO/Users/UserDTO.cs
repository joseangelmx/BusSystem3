using System.ComponentModel.DataAnnotations;
using BusSystem.Core.Tickets;
using BusSystem.Core.Users;

namespace BusSystem.ApplicationServices.Shared.DTO.Users;

public class UserDTO
{
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Role { get; set; }
}