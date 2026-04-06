using AutoMapper;
using BusSystem.ApplicationServices.Shared.DTO.Buses;
using BusSystem.ApplicationServices.Shared.DTO.SeatSettings;
using BusSystem.Core.Buses;
using BusSystem.Core.SeatSettings;
using BusSystem.DataAccess.Repositories;
using BusSystem.DataAccess.Repositories.Buses;
using BusSystem.DataAccess.Repositories.SeatSettings;
using Microsoft.EntityFrameworkCore;

namespace BusSystem.ApplicationServices.Buses;

public class BusAppService : IBusAppService
{
    private readonly IRepository<int, Bus> _repository;
    private readonly BusRepository _busRepository;
    private readonly  IMapper _mapper;

    public BusAppService(IRepository<int, Bus> repository,BusRepository busRepository,IMapper mapper){
        _repository = repository;
        _busRepository = busRepository;
        _mapper = mapper;
    }

    public  async Task<List<BusDTO>> GetBusesAsync()
    {
        try
        {
            var buses = await _repository.GetAll().ToListAsync();
            var dtos = _mapper.Map<List<Bus>, List<BusDTO>>(buses);
            return dtos;
        }
        catch(Exception ex)
        {
            throw new Exception($"GetBusesAsync unsuccessful. Error: {ex.Message}");
        }
    }

    public async Task<BusDTO> GetBusByIdAsync(int id)
    {
        try
        {
            var bus = await _repository.GetAsync(id);
            var busDTO = _mapper.Map<Bus, BusDTO>(bus);
            return busDTO;
        }
        catch(Exception ex)
        {
            throw new Exception($"GetBusAsync unsuccessful. Error: {ex.Message}");
        }
    }

    public async Task<int> AddBusAsync(NewBusDTO busDto)
    {
        try
        {
            var newBus = await _busRepository.AddAsync(busDto);
            return newBus.Id;
        }
        catch(Exception ex)
        {
            throw new Exception($"AddBusAsync unsuccessful. Error: {ex.Message}");
        }
    }

    public async Task EditBusAsync(int id, NewBusDTO busDto)
    {
        try
        {
            await _busRepository.UpdateAsync(id, busDto);
        }
        catch (Exception ex)
        {
            throw new Exception($"EditBusAsync unsuccessful. Error: {ex.Message}");
        }
    }

    public async Task DeleteBusAsync(int id)
    {
        try
        {
            await _busRepository.DeleteAsync(id);
        }
        catch(Exception ex)
        {
            throw new Exception($"DeleteBusAsync unsuccessful. Error: {ex.Message}");    
        }
    }
}