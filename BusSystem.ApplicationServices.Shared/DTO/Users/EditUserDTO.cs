using System.ComponentModel.DataAnnotations;
using BusSystem.Core.Users;

namespace BusSystem.ApplicationServices.Shared.DTO.Users;

public class EditUserDTO
{ 
        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string RoleNameAssignment { get; set; }
        
}