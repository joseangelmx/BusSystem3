using BusSystem.ApplicationServices.Shared.DTO.SeatSettings;
using BusSystem.Core.SeatSettings;

namespace BusSystem.DataAccess.Repositories.SeatSettings;

public class SeatSettingRepository  : Repository<int, SeatSetting>
{
    public SeatSettingRepository(BusContext context) : base(context)
    {
    }

    public async Task<SeatSetting> AddAsync(NewSeatSettingDTO seatSettingDto)
    {
        var seatSetting = new SeatSetting
        {
            Name = seatSettingDto.Name,
            NumberOfSeats = seatSettingDto.NumberOfSeats
        };
        await Context.SeatSettings.AddAsync(seatSetting);
        await Context.SaveChangesAsync();
        return seatSetting;
    }

    public async Task<SeatSetting> UpdateAsync(int id, NewSeatSettingDTO seatSettingDto)
    {
        var entity = await Context.SeatSettings.FindAsync(id);
        if (entity == null)
        {
            throw new Exception("This Seat Setting does not exist");
        }

        entity.Name = seatSettingDto.Name;
        entity.NumberOfSeats = seatSettingDto.NumberOfSeats;

        await Context.SaveChangesAsync();
        return entity;
    }
    public async Task<SeatSetting> DeleteAsync(int id)
    {
        var bus = Context.Buses.FirstOrDefault(bus1 => bus1.SeatSettingId == id);
        var seatsetting = await Context.SeatSettings.FindAsync(id);
        if (bus != null)
        {
            throw new Exception($"The seat setting with id {id} is currently linked to one or more buses."); 
        }
        if (seatsetting == null)
        {
            throw new Exception($"The seat setting with id {id} does not exist");
        }
        Context.SeatSettings.Remove(seatsetting);
        await Context.SaveChangesAsync();
        return seatsetting;
    }
}