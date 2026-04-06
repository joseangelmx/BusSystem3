using AutoMapper;
using BusSystem.ApplicationServices.Shared.DTO.Places;
using BusSystem.Core.Places;
using BusSystem.DataAccess.Repositories;
using BusSystem.DataAccess.Repositories.Places;
using Microsoft.EntityFrameworkCore;

namespace BusSystem.ApplicationServices.Places;

public class PlaceAppService : IPlaceAppService
{
    private readonly PlaceRepository _placeRepository;
    private readonly IMapper _mapper;
    private readonly IRepository<int, Place> _repository;

    public PlaceAppService(PlaceRepository placeRepository, IMapper mapper, IRepository<int, Place> repository)
    {
        _placeRepository = placeRepository;
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<List<PlaceDTO>> GetPlacesAsync()
    {
        try
        {
            var places = await _repository.GetAll().ToListAsync();
            var dtos = _mapper.Map<List<Place>, List<PlaceDTO>>(places);
            return dtos;
        }
        catch(Exception ex)
        {
            throw new Exception($"GetPlacesAsync Unsucessful. Error {ex.Message}");
        }

        
    }

    public async Task<PlaceDTO> GetPlaceByIdAsync(int id)
    {
        try
        {
            var place = await _repository.GetAsync(id);
            var placesDTO = _mapper.Map<Place, PlaceDTO>(place);
            return placesDTO;
        }
        catch (Exception ex)
        {
            throw new Exception($"GetPlaceByIdAsync Unsucessful. Error {ex.Message}");
        }
    }

    public async Task<int> AddPlaceAsync(NewPlaceDTO placeDto)
    {
        try
        {
            var newPlace = await _placeRepository.AddAsync(placeDto);
            return newPlace.Id;
        }
        catch (Exception ex)
        {
            throw new Exception($"AddPlaceAsync Unsucessful. Error {ex.Message}");
        }
    }

    public async Task EditPlaceAsync(int id, NewPlaceDTO placeDto)
    {
        try
        {
            await _placeRepository.UpdateAsync(id, placeDto);
        }
        catch (Exception ex)
        {
            throw new Exception($"EditPlaceAsync Unsucessful. Error {ex.Message}");
        }
    }

    public async Task DeletePlaceAsync(int id)
    {
        try
        {
            await _placeRepository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"DeletePlaceAsync Unsucessful. Error {ex.Message}");
        }
    }
}