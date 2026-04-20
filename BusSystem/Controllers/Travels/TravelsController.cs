using BusSystem.ApplicationServices.Shared.DTO.Travels;
using BusSystem.ApplicationServices.Travels;
using Microsoft.AspNetCore.Mvc;

namespace BusSystem.Controllers.Travels;
[Route("api/[controller]")]
[ApiController]
public class TravelController : ControllerBase
{
    private readonly ITravelsAppService _travelAppService;

    public TravelController(ITravelsAppService travelAppService)
    {
        _travelAppService = travelAppService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            List<TravelsDTO> travels = await _travelAppService.GetTravelsAsync();
            return Ok(travels);
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

    [HttpGet("{travelId}")]
    public async Task<IActionResult> GetById(int travelId)
    {
        try
        {
            TravelsDTO travel = await _travelAppService.GetTravelByIdAsync(travelId);
            if (travel == null)
            {
                return NotFound($"Seat setting with ID {travel} not found.");
            }

            return Ok(travel);
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
    public async Task<IActionResult> Post(NewTravelDTO newTravelDTO)
    {
        try
        {
            if (newTravelDTO == null)
            {
                return BadRequest("Invalid JSON Model!");
            }

            await _travelAppService.AddTravelAsync(newTravelDTO);
            return Ok(new { Message = "Travel added sucessfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message}" });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, NewTravelDTO newTravelDTO)
    {
        try
        {
            if (id == null || newTravelDTO == null)
            {
                return BadRequest("Invalid JSON model ");
            }

            await _travelAppService.EditTravelAsync(id,newTravelDTO);
            return Ok(new { Message = "Travel edited successfully." });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message}" });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            if (id == null)
            {
                return BadRequest(new { Success = false, Message = "Id is null!" });
            }

            await _travelAppService.DeleteTravelAsync(id);
            return Ok(new { Message = "Travel deleted successfully." });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message}" });
        }
    }
}