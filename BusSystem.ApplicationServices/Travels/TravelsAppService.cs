using AutoMapper;
using BusSystem.ApplicationServices.Shared.DTO.Travels;
using BusSystem.Core.Travels;
using BusSystem.DataAccess.Repositories;
using BusSystem.DataAccess.Repositories.Travels;
using Microsoft.EntityFrameworkCore;

namespace BusSystem.ApplicationServices.Travels;
public class TravelsAppService : ITravelsAppService
{
    private readonly IRepository<int, Travel> _repository;
    private readonly TravelRepository _travelRepository;
    private readonly  IMapper _mapper;

    public TravelsAppService(IRepository<int, Travel> repository,TravelRepository travelRepository,IMapper mapper){
        _repository = repository;
        _travelRepository = travelRepository;
        _mapper = mapper;
    }

    public async Task<int> AddTravelAsync(NewTravelDTO travelDto)
    {
        try
        {
            var newTravel = await _travelRepository.AddAsync(travelDto);
            return newTravel.Id;
        }
        catch(Exception ex)
        {
            throw new Exception($"AddTravelAsync unsuccessful. Error: {ex.Message}");
        }
    }

    public async Task DeleteTravelAsync(int id)
    {
        try
        {
            await _travelRepository.DeleteAsync(id);
        }
        catch(Exception ex)
        {
            throw new Exception($"DeleteTravelAsync unsuccessful. Error: {ex.Message}");    
        }
    }

    public async Task EditTravelAsync(int id, NewTravelDTO travelDto)
    {
        try
        {
            await _travelRepository.UpdateAsync(id, travelDto);
        }
        catch (Exception ex)
        {
            throw new Exception($"EditTravelAsync unsuccessful. Error: {ex.Message}");
        }
    }

    public async Task<TravelsDTO> GetTravelByIdAsync(int id)
    {
        try
        {
            var travel = await _repository.GetAsync(id);
            var travelDTO = _mapper.Map<Travel, TravelsDTO>(travel);
            return travelDTO;
        }
        catch(Exception ex)
        {
            throw new Exception($"GetTravelAsync unsuccessful. Error: {ex.Message}");
        }
    }

    public async Task<List<TravelsDTO>> GetTravelsAsync()
    {
        try
        {
            var travels = await _repository.GetAll().ToListAsync();
            var dtos = _mapper.Map<List<Travel>, List<TravelsDTO>>(travels);
            return dtos;
        }
        catch(Exception ex)
        {
            throw new Exception($"GetTravelAsync unsuccessful. Error: {ex.Message}");
        }
    }
}