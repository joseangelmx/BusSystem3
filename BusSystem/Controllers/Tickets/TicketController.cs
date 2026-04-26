using BusSystem.ApplicationServices.Shared.DTO.Tickets;
using BusSystem.ApplicationServices.Tickets;
using Microsoft.AspNetCore.Mvc;

namespace BusSystem.Controllers.Tickets;
[Route("api/[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly ITicketAppService _ticketAppService;

    public TicketController(ITicketAppService ticketAppService)
    {
        _ticketAppService = ticketAppService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            List<TicketDTO> tickets = await _ticketAppService.GetTicketsAsync();
            return Ok(tickets);
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
            TicketDTO ticket = await _ticketAppService.GetTicketByIdAsync(id);
            if (ticket == null)
            {
                return NotFound($"Seat setting with ID {id} not found.");
            }

            return Ok(ticket);
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
    public async Task<IActionResult> Post(NewTicketDTO newTicketDto)
    {
        try
        {
            if (newTicketDto == null)
            {
                return BadRequest("Invalid JSON Model!");
            }

            await _ticketAppService.AddTicketAsync(newTicketDto);
            return Ok(new { Message = "Ticket added sucessfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message}" });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, NewTicketDTO newTicketDto)
    {
        try
        {
            if (id == null || newTicketDto == null)
            {
                return BadRequest("Invalid JSON model ");
            }

            await _ticketAppService.EditTicketAsync(id, newTicketDto);
            return Ok(new { Message = "Ticket edited successfully." });
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

            await _ticketAppService.DeleteTicketAsync(id);
            return Ok(new { Message = "Ticket deleted successfully." });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message}" });
        }
    }
}