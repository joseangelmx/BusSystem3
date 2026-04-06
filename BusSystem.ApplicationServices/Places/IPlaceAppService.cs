using BusSystem.ApplicationServices.Shared.DTO.Places;
namespace BusSystem.ApplicationServices.Places;

public interface IPlaceAppService
{
    Task<List<PlaceDTO>> GetPlacesAsync();
    Task<PlaceDTO> GetPlaceByIdAsync(int id);
    Task<int> AddPlaceAsync(NewPlaceDTO placeDto);
    Task EditPlaceAsync(int id, NewPlaceDTO placeDto);
    Task DeletePlaceAsync(int id);
}