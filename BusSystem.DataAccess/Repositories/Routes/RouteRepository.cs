using BusSystem.ApplicationServices.Shared.DTO.Routes;
using BusSystem.Core.Buses;
using BusSystem.Core.Places;
using BusSystem.Core.Routes;

namespace BusSystem.DataAccess.Repositories.Routes;

public class RouteRepository : Repository<int, BusSystem.Core.Routes.Route>
{
    public RouteRepository(BusContext context) : base(context)
    {
        
    }
    public async Task<Route> AddAsync(NewRouteDTO newRouteDto)
    {
        if (newRouteDto.OriginId == newRouteDto.DestinationId)
        {
            throw new Exception("Origin and Destination cannot be the same");
        }
        var places = Context.Places
            .Where(s => s.Id == newRouteDto.OriginId || s.Id == newRouteDto.DestinationId)
            .ToList();

        
        if (places.Count != 2)
        {
            throw new Exception($"Some of the places don't exists");
        }

        var route = new Route
        {
            OriginId = newRouteDto.OriginId,
            DestinationId = newRouteDto.DestinationId,
            Distance = newRouteDto.Distance,
            TimeOfArrival = newRouteDto.TimeOfArrival
        };
        Context.Routes.Add(route);
        await Context.SaveChangesAsync();
        return route;
    }

    public async Task<Route> UpdateAsync(int id, NewRouteDTO routeDto)
    {
        var places = Context.Places
            .Where(s => s.Id == routeDto.OriginId || s.Id == routeDto.DestinationId)
            .ToList();

        if (places.Count != 2)
        {
            throw new Exception($"Some of the places especified don't exists");
        }
        var route = await Context.Routes.FindAsync(id);
        if (route == null)
        {
            throw new Exception($"The Route with id {id} don't exists");
        }

        route.OriginId = routeDto.OriginId;
        route.DestinationId = routeDto.OriginId;
        route.Distance = routeDto.Distance;
        route.TimeOfArrival = routeDto.TimeOfArrival;
        await Context.SaveChangesAsync();
        return route;
    }

    public async Task<Route> DeleteAsync(int id)
    {
        var route = await Context.Routes.FindAsync(id);
        if (route == null)
        {
            throw new Exception($"The route with {id} don't exist");
        }

        Context.Routes.Remove(route);
        await Context.SaveChangesAsync();
        return route;
    }
}