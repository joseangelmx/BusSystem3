using BusSystem.ApplicationServices.Shared.DTO.Places;
using BusSystem.Core.Places;

namespace BusSystem.DataAccess.Repositories.Places;

public class PlaceRepository : Repository<int, Place>
{
    public PlaceRepository(BusContext context) : base(context)
    {
        
    }

    public async Task<Place> AddAsync(NewPlaceDTO newPlaceDto)
    {
        var place = new Place
        {
            City = newPlaceDto.City,
            TerminalName = newPlaceDto.TerminalName
        };
        Context.Places.Add(place);
        await Context.SaveChangesAsync();
        return place;
    }
    public async Task<Place> UpdateAsync(int id, NewPlaceDTO newPlaceDto)
    {
        var place = await Context.Places.FindAsync(id);
        if (place == null)
        {
            throw new Exception($"Place with {id} don't exist");
        }
        place.City = newPlaceDto.City;
        place.TerminalName = newPlaceDto.TerminalName;
        Context.Places.Update(place);
        await Context.SaveChangesAsync();
        return place;
    }
    public async Task<Place> DeleteByIdAsync(int id)
    {
        var place = await Context.Places.FindAsync(id);
        if (place == null)
        {
            throw new Exception($"The place with {id} don't exist");
        }

        Context.Places.Remove(place);
        await Context.SaveChangesAsync();
        return place;
    }
}