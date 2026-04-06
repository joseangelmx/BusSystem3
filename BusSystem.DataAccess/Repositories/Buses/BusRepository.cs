using BusSystem.ApplicationServices.Shared.DTO.Buses;
using BusSystem.Core.Buses;
using BusSystem.Core.SeatSettings;

namespace BusSystem.DataAccess.Repositories.Buses;

public class BusRepository : Repository<int, Bus>
{
    public BusRepository(BusContext context) : base(context)
    {

    }
    public async Task<Bus> AddAsync(NewBusDTO busDto)
    {
        var seatsetting = await Context.SeatSettings.FindAsync(busDto.SeatSettingId);
        if (seatsetting == null)
        {
            throw new Exception($"The SeatSetting with {busDto.SeatSettingId} does not exist");
        }
        var bus = new Bus
        {
            BusNumber =  busDto.BusNumber,
            Brand = busDto.Brand,
            Model = busDto.Model,
            SeatSettingId = busDto.SeatSettingId,
        };
        await Context.Buses.AddAsync(bus);
        await Context.SaveChangesAsync();
        return bus;
    }

    public async Task<Bus> UpdateAsync(int id, NewBusDTO seatSettingDto)
    {
        var bus = await Context.Buses.FindAsync(id);
        if (bus == null)
        {
            throw new Exception($"The Bus with id {id} does not exist");
        }
        var seatSetting = await Context.SeatSettings.FindAsync(seatSettingDto.SeatSettingId);
        if (seatSetting == null)
        {
            throw new Exception($"The SeatSetting with {seatSettingDto.SeatSettingId} does not exist");
        }
        bus.BusNumber = seatSettingDto.BusNumber;
        bus.Brand = seatSettingDto.Brand;
        bus.Model = seatSettingDto.Model;
        bus.SeatSettingId = seatSettingDto.SeatSettingId;
        await Context.SaveChangesAsync();
        return bus;
    }

    public async Task<Bus> DeleteAsync(int id)
    {
        var bus = await Context.Buses.FindAsync(id);
        if (bus == null)
        {
            throw new Exception($"The bus with id {id} does not exist");
        }

        Context.Buses.Remove(bus);
        await Context.SaveChangesAsync();
        return bus;
    }
}