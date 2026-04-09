using BusSystem.ApplicationServices.Shared.DTO.Places;
using BusSystem.ApplicationServices.Shared.DTO.Routes;

namespace BusSystem.ApplicationServices.Routes;

public interface IRouteAppService
{
    Task<List<RouteDTO>> GetRoutesAsync();
    Task<RouteDTO> GetRouteByIdAsync(int id);
    Task<int> AddRouteAsync(NewRouteDTO newRouteDto);
    Task EditRouteAsync(int id, NewRouteDTO newRouteDto);
    Task DeleteRouteAsync(int id);
}