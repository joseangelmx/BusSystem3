using BusSystem.ApplicationServices.Shared.DTO.Buses;

namespace BusSystem.ApplicationServices.Buses;

public interface IBusAppService
{
    Task<List<BusDTO>> GetBusesAsync();
    Task<BusDTO> GetBusByIdAsync(int id);
    Task<int> AddBusAsync(NewBusDTO busDto);
    Task EditBusAsync(int id, NewBusDTO busDto);
    Task DeleteBusAsync(int id);
}