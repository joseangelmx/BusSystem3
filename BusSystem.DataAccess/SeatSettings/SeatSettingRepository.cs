using BusSystem.ApplicationServices.Shared.DTO.SeatSettings;
using BusSystem.Core.SeatSettings;
using BusSystem.DataAccess.Repositories;

namespace BusSystem.DataAccess.SeatSettings;

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
}