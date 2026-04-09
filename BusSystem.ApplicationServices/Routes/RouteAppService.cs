using AutoMapper;
using BusSystem.ApplicationServices.Shared.DTO.Places;
using BusSystem.ApplicationServices.Shared.DTO.Routes;
using BusSystem.Core.Routes;
using BusSystem.DataAccess.Repositories;
using BusSystem.DataAccess.Repositories.Routes;
using Microsoft.EntityFrameworkCore;

namespace BusSystem.ApplicationServices.Routes;

public class RouteAppService : IRouteAppService
{
    private readonly RouteRepository _routeRepository;
    private readonly IRepository<int, Route> _repository;
    private readonly IMapper _mapper;

    public RouteAppService(RouteRepository routeRepository, IRepository<int, Route> repository, IMapper mapper)
    {
        _routeRepository = routeRepository;
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<List<RouteDTO>> GetRoutesAsync()
    {
        try
        {
            var route = await _repository.GetAll().ToListAsync();
            var routesDto =  _mapper.Map<List<Route>,List<RouteDTO>>(route);
            return routesDto;
        }
        catch (Exception ex)
        {
            throw new Exception("GetRoutesAsync Unsucessful", ex);
        }
    }

    public async Task<RouteDTO> GetRouteByIdAsync(int id)
    {
        try
        {
            var route = await _repository.GetAsync(id);
            var routeDto =  _mapper.Map<Route,RouteDTO>(route);
            return routeDto;
        }
        catch (Exception ex)
        {
            throw new Exception("GetRouteByIdAsync Unsucessful", ex);
        }
    }

    public async Task<int> AddRouteAsync(NewRouteDTO newRouteDto)
    {
        try
        {
            var route = await _routeRepository.AddAsync(newRouteDto);
            return route.Id;
        }
        catch (Exception ex)
        {
            throw new Exception($"AddRouteAsync Unsucessful {ex}");
        }
    }

    public async Task EditRouteAsync(int id, NewRouteDTO newRouteDto)
    {
        try
        {
            await _routeRepository.UpdateAsync(id, newRouteDto);
            
        }
        catch (Exception ex)
        {
            throw new Exception("EditRouteAsync Unsucessful", ex);
        }
    }

    public async Task DeleteRouteAsync(int id)
    {
        try
        {
            await _routeRepository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception("EditRouteAsync Unsucessful", ex);
        }
    }
}