using BusSystem.ApplicationServices.Shared.DTO.Travels;
using BusSystem.Core.Travels;

namespace BusSystem.DataAccess.Repositories.Travels;

public class TravelRepository : Repository<int, Travel>
{
    public TravelRepository(BusContext context) : base(context)
    {
        
    }

    public async Task<Travel> AddAsync(NewTravelDTO newTravel)
    {
        var bus = await Context.Buses.FindAsync(newTravel.BusId);
        var route = await Context.Routes.FindAsync(newTravel.RouteId);
        if (bus == null)
        {
            throw new Exception($"The Bus with Id {newTravel.BusId} don't exist");
        }

        if (route == null)
        {
            throw new Exception($"The Route with Id {newTravel.RouteId} don't exist");
        }
        var travel = new Travel
        {
          BusId  = newTravel.BusId,
          RouteId = newTravel.RouteId,
          DepartureTime = newTravel.DepartureTime,
          ArrivalTime = newTravel.ArrivalTime,
        };
        await Context.Travels.AddAsync(travel);
        await Context.SaveChangesAsync();
        return travel;
    }

    public async Task<Travel> UpdateAsync(int id, NewTravelDTO newTravel)
    {
        var bus = await Context.Buses.FindAsync(newTravel.BusId);
        var route = await Context.Routes.FindAsync(newTravel.RouteId);
        var travel = await Context.Travels.FindAsync(id);
        if (bus == null)
        {
            throw new Exception($"The Bus with Id {newTravel.BusId} don't exist");
        }

        if (route == null)
        {
            throw new Exception($"The Route with Id {newTravel.RouteId} don't exist");
        }

        if (travel == null)
        {
            throw new Exception($"The Travel with Id {id} don't exist");
        }
        travel.BusId = newTravel.BusId;
        travel.RouteId = newTravel.RouteId;
        travel.ArrivalTime = newTravel.ArrivalTime;
        travel.DepartureTime = newTravel.DepartureTime;
        await Context.SaveChangesAsync();
        return travel;
    }
}