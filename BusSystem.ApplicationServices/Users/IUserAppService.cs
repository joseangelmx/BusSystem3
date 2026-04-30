using BusSystem.ApplicationServices.Shared.DTO.Users;
using Microsoft.AspNetCore.Identity;

namespace BusSystem.ApplicationServices.Users;

public interface IUserAppService
{
        Task<List<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserAsync(string id);
        Task AddUserAsync(NewUserDTO userDto);
        Task EditUserAsync(string id, EditUserDTO userDto);
        Task DeleteUserAsync(string id);
        Task<List<RolesNameDTO>> GetRolesAsync();
}