using AutoMapper;
using BusSystem.ApplicationServices.Shared.DTO.SeatSettings;
using BusSystem.DataAccess.Repositories;
using BusSystem.Core.SeatSettings;
using BusSystem.DataAccess.SeatSettings;
using Microsoft.EntityFrameworkCore;

namespace BusSystem.ApplicationServices.SeatSettings;

    public class SeatSettingAppService: ISeatSettingAppService
    {
        private readonly IRepository<int, SeatSetting> _repository;
        private readonly SeatSettingRepository _seatSettingRepository;
        private readonly  IMapper _mapper;
        public SeatSettingAppService(IRepository<int, SeatSetting> repository, IMapper mapper, SeatSettingRepository seatSettingRepository)
        {
            _repository = repository;
            _seatSettingRepository = seatSettingRepository;
            _mapper = mapper;
        }
        public async Task<List<SeatSettingsDTO>> GetSeatSettingsAsync()
        {
            try
            {
                var seatsettings = await _repository.GetAll().ToListAsync();
                var dtos = _mapper.Map<List<SeatSetting>, List<SeatSettingsDTO>>(seatsettings);
                return dtos;
            }
            catch(Exception ex)
            {
                throw new Exception($"GetSeatSettingsAsync unsuccessful. Error: {ex.Message}");
            }
        }

        public async Task<SeatSettingsDTO> GetSeatSettingByIdAsync(int id)
        {
            try
            {
                var seatsetting = await _repository.GetAsync(id);
                var seasettingdto = _mapper.Map<SeatSetting, SeatSettingsDTO>(seatsetting);
                return seasettingdto;
            }
            catch(Exception ex)
            {
                throw new Exception($"GetSeatSettingAsync unsuccessful. Error: {ex.Message}");
            }
        }

        public async Task<int> AddSeatSettingAsync(NewSeatSettingDTO seatSettingDto)
        {
            try
            {
               var seatsetting = await _seatSettingRepository.AddAsync(seatSettingDto);
                return seatsetting.Id;
            }
            catch (Exception ex)
            {
                throw  new Exception($"AddSeatSettingAsync unsuccessful. Error: {ex.Message}");
            }
        }

        public async Task EditSeatSettingAsync(int id, NewSeatSettingDTO seatSettingDto)
        {
            try
            {
                await _seatSettingRepository.UpdateAsync(id,seatSettingDto);
            }
            catch (Exception ex)
            {
                throw new Exception($"EditSeatSettingAsync unsuccessful. Error: {ex.Message}");
            }
        }

        public async Task DeleteSeatSettingAsync(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
            }
            catch(Exception ex)
            {
                throw new Exception($"DeleteSeatSettingAsync unsuccessful. Error: {ex.Message}");    
            }
        }
    }