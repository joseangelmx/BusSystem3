using BusSystem.ApplicationServices.Shared.DTO.PricingSettings;
using BusSystem.Core.PricingSettings;

namespace BusSystem.DataAccess.Repositories.PricingSettings;

public class PricingSettingRepository : Repository<int, PricingSetting>
{
    public PricingSettingRepository(BusContext context) : base(context)
    {
        
    }
    public async Task<PricingSetting> AddAsync(NewPricingSettingDTO newPricingSettingDto)
    {
        var pricing = new PricingSetting
        {
            PricePerKm = newPricingSettingDto.PricePerKm,
            EffectiveFrom = DateTime.Now
        };
        await Context.PricingSettings.AddAsync(pricing);
        await Context.SaveChangesAsync();
        return pricing;
    }

    public async Task<PricingSetting> UpdateAsync(int id, NewPricingSettingDTO seatSettingDto)
    {
        var pricing = await Context.PricingSettings.FindAsync(id);
        if (pricing == null)
        {
            throw new Exception($"Pricing settings with that id {id} doesn't exist.");
        }
        await Context.PricingSettings.AddAsync(pricing);
        await Context.SaveChangesAsync();
        return pricing;
    }
}