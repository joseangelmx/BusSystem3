using BusSystem.ApplicationServices.Routes;
using BusSystem.ApplicationServices.Shared.DTO.Routes;
using Microsoft.AspNetCore.Mvc;

namespace BusSystem.Controllers.Routes;

[Route("api/[controller]")]
[ApiController]
public class RouteController : ControllerBase
{
    private readonly IRouteAppService _routeAppService;

    public RouteController(IRouteAppService routeAppService)
    {
        _routeAppService = routeAppService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var routes = await _routeAppService.GetRoutesAsync();
            return Ok(routes);
        }
        catch (Exception ex)
        { 
            var errorResponse = new
                {
                    Message = "An error occurred while processing the request.",
                    Details = ex.Message 
                }; 
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var route = await _routeAppService.GetRouteByIdAsync(id);
            return Ok(route);
        }
        catch (Exception ex)
        {
            var errorResponse = new
            {
                Message = "An error occurred while processing the request.",
                Details = ex.Message 
            }; 
            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);   
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, NewRouteDTO routeDto)
    {
        try
        {
            await _routeAppService.EditRouteAsync(id,routeDto);
            return Ok($"The route with {id} has been updated");
        }
        catch (Exception ex)
        {
            var errorResponse = new
            {
                Message = "An error occurred while processing the request.",
                Details = ex.Message 
            }; 
            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);   
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(NewRouteDTO routeDto)
    {
        try
        {
            var newRoute =await _routeAppService.AddRouteAsync(routeDto);
            return Ok($"The route with {newRoute} has been added");
        }
        catch (Exception ex)
        {
            var errorResponse = new
            {
                Message = "An error occurred while processing the request.",
                Details = ex.Message 
            }; 
            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);   
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _routeAppService.DeleteRouteAsync(id);
            return Ok($"The route with {id} has been added");      
        }
        catch (Exception ex)
        {
            var errorResponse = new
            {
                Message = "An error occurred while processing the request.",
                Details = ex.Message 
            }; 
            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);   
        }
    }
}