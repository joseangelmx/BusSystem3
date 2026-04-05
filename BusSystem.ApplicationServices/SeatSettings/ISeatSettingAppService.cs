using BusSystem.ApplicationServices.Shared.DTO.SeatSettings;
namespace BusSystem.ApplicationServices.SeatSettings;

public interface ISeatSettingAppService
{
    Task<List<SeatSettingsDTO>> GetSeatSettingsAsync();
    Task<SeatSettingsDTO> GetSeatSettingByIdAsync(int id);
    Task<int> AddSeatSettingAsync(NewSeatSettingDTO seatSettingDto);
    Task EditSeatSettingAsync(int id, NewSeatSettingDTO seatSettingDto);
    Task DeleteSeatSettingAsync(int id);
}