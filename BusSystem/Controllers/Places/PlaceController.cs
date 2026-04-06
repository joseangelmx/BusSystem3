using BusSystem.ApplicationServices.Places;
using BusSystem.ApplicationServices.Shared.DTO.Places;
using Microsoft.AspNetCore.Mvc;

namespace BusSystem.Controllers.Places;

[Route("api/[controller]")]
[ApiController]
public class PlaceController(IPlaceAppService placeAppService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPlacesAsync()
    {
        try
        {
            var places = await placeAppService.GetPlacesAsync();
            return Ok(places);
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
    [HttpGet("{placeId}")]
    public async Task<IActionResult> GetPlaceAsync(int placeId)
    {
        try
        {
            var places = await placeAppService.GetPlaceByIdAsync(placeId);
            if (places == null)
            {
                return NotFound($"Place with id {placeId} not found");
            }
            return Ok(places);
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
    
    [HttpPost()]
    public async Task<IActionResult> Post(NewPlaceDTO newPlace)
    {
        try
        {
            var places = await placeAppService.AddPlaceAsync(newPlace);
            return Ok($"The place has been added successfully with id {places}.");
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
    public async Task<IActionResult> Put(int id, NewPlaceDTO newPlaceDto)
    {
        try
        {
            await placeAppService.EditPlaceAsync(id, newPlaceDto);
            return Ok("The place has been updated successfully.");
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
            await placeAppService.DeletePlaceAsync(id);
            return Ok("The place has been deleted successfully");
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