using BusSystem.Core.Users;

namespace BusSystem.ApplicationServices.Shared.DTO.Users;

public class EditUserDTO
{ 
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
}