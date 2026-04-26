using BusSystem.ApplicationServices.Shared.DTO.Tickets;
using BusSystem.Core.Tickets;

namespace BusSystem.ApplicationServices.Tickets;

public interface ITicketAppService
{
    Task<List<TicketDTO>> GetTicketsAsync();
    Task<TicketDTO> GetTicketByIdAsync(int id);
    Task<int> AddTicketAsync(NewTicketDTO newTicketDto);
    Task EditTicketAsync(int id, NewTicketDTO newTicketDto);
    Task DeleteTicketAsync(int id);
}