using AutoMapper;
using BusSystem.ApplicationServices.Shared.DTO.Places;
using BusSystem.ApplicationServices.Shared.DTO.PricingSettings;
using BusSystem.Core.Places;
using BusSystem.Core.PricingSettings;
using BusSystem.DataAccess.Repositories;
using BusSystem.DataAccess.Repositories.Places;
using BusSystem.DataAccess.Repositories.PricingSettings;
using Microsoft.EntityFrameworkCore;

namespace BusSystem.ApplicationServices.PricingSettings;

public class PricingSettingAppService : IPricingSettingAppService
{
    private readonly PricingSettingRepository _pricingSettingRepository;
    private readonly IMapper _mapper;
    private readonly IRepository<int, PricingSetting> _repository;

    public PricingSettingAppService(PricingSettingRepository pricingSettingRepository, IMapper mapper, IRepository<int, PricingSetting> repository)
    {
        _pricingSettingRepository = pricingSettingRepository;
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<List<PricingSettingDTO>> GetPricingSettingsAsync()
    {
        try
        {
            var pricingSettings = await _repository.GetAll().ToListAsync();
            var dtos = _mapper.Map<List<PricingSetting>, List<PricingSettingDTO>>(pricingSettings);
            return dtos;
        }
        catch(Exception ex)
        {
            throw new Exception($"GetPricingSettingsAsync Unsucessful. Error {ex.Message}");
        }
    }

    public async Task<PricingSettingDTO> GetPricingSettingByIdAsync(int id)
    {
        try
        {
            var pricingSetting = await _repository.GetAsync(id);
            var pricingSettingDTO = _mapper.Map<PricingSetting, PricingSettingDTO>(pricingSetting);
            return pricingSettingDTO;
        }
        catch (Exception ex)
        {
            throw new Exception($"GetPricingSettingByIdAsync Unsucessful. Error {ex.Message}");
        }
    }

    public async Task<int> AddPricingSettingAsync(NewPricingSettingDTO pricingSettingDto)
    {
        try
        {
            var newPricing = await _pricingSettingRepository.AddAsync(pricingSettingDto);
            return newPricing.Id;
        }
        catch (Exception ex)
        {
            throw new Exception($"AddPricingSettingAsync Unsucessful. Error {ex.Message}");
        }
    }


}