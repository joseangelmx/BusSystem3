using BusSystem.ApplicationServices.Buses;
using BusSystem.ApplicationServices.Shared.DTO.Buses;
using Microsoft.AspNetCore.Mvc;

namespace BusSystem.Controllers.Buses;
[Route("api/[controller]")]
[ApiController]
public class BusController : ControllerBase
{
    private readonly IBusAppService _busAppService;

    public BusController(IBusAppService busAppService)
    {
        _busAppService = busAppService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            List<BusDTO> busDtos = await _busAppService.GetBusesAsync();
            return Ok(busDtos);
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
    
    [HttpGet("{busId}")]
    public async Task<IActionResult> GetById(int busId)
    {
        try
        {
            BusDTO busDto = await _busAppService.GetBusByIdAsync(busId);
            if (busDto == null)
            {
                return NotFound($"Bus with ID {busId} not found.");
            }

            return Ok(busDto);
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
    public async Task<IActionResult> Post(NewBusDTO newBusDto)
    {
        try
        {
            if (newBusDto == null)
            {
                return BadRequest("Invalid JSON Model!");
            }

            await _busAppService.AddBusAsync(newBusDto);
            return Ok(new { Message = $"Bus {newBusDto.BusNumber} added sucessfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message}" });
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, NewBusDTO newBusDto)
    {
        try
        {
            if (id == null || newBusDto == null)
            {
                return BadRequest("Invalid JSON model ");
            }

            await _busAppService.EditBusAsync(id, newBusDto);
            return Ok(new { Message = "Bus edited successfully." });
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
            if (id == 0)
            {
                return BadRequest(new { Success = false, Message = "Id is null!" });
            }

            await _busAppService.DeleteBusAsync(id);
            return Ok(new { Message = $"Bus with {id} deleted successfully." });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message}" });
        }
    }
}