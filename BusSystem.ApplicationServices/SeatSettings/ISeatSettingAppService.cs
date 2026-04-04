namespace BusSystem.ApplicationServices.SeatSettings;

public interface ISeatSettingAppService
{
    Task<List<UserDTO>> GetUsersAsync();
    Task<UserDTO> GetUserAsync(string id);
    Task AddUserAsync(NewUserDTO userDto);
    Task EditUserAsync(string id, EditUserDTO userDto);
    Task DeleteUserAsync(string id);
    Task<List<RolesNameDTO>> GetRolesAsync();
}