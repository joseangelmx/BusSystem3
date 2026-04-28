using BusSystem.ApplicationServices.Shared.DTO.Users;
using Microsoft.AspNetCore.Identity;

namespace BusSystem.ApplicationServices.Users;

public interface IUserAppService
{
    Task<UserDTO> GetUserByIdAsync(string id);
    Task<List<UserDTO>> GetUsersAsync();
    Task<IdentityResult> CreateUserAsync(NewUserDto dto);
    Task<IdentityResult> UpdateUserAsync(string id, EditUserDTO dto);
}