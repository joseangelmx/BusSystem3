using BusSystem.ApplicationServices.Shared.DTO.Travels;

public interface ITravelsAppService
{
    Task<List<TravelsDTO>> GetTravelsAsync();
    Task<TravelsDTO> GetTravelByIdAsync(int id);
    Task<int> AddTravelAsync(NewTravelDTO travelDto);
    Task EditTravelAsync(int id,NewTravelDTO travelDto);
    Task DeleteTravelAsync(int id);
}