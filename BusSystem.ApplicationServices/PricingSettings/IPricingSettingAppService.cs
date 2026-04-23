using BusSystem.ApplicationServices.Shared.DTO.PricingSettings;

namespace BusSystem.ApplicationServices.PricingSettings;

public interface IPricingSettingAppService
{
    Task<List<PricingSettingDTO>> GetPricingSettingsAsync();
    Task<PricingSettingDTO> GetPricingSettingByIdAsync(int id);
    Task<int> AddPricingSettingAsync(NewPricingSettingDTO pricingSettingDto);
}