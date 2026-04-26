using AutoMapper;
using BusSystem.ApplicationServices.Shared.DTO.Tickets;
using BusSystem.Core.Tickets;
using BusSystem.DataAccess.Repositories;
using BusSystem.DataAccess.Repositories.Tickets;
using Microsoft.EntityFrameworkCore;

namespace BusSystem.ApplicationServices.Tickets;

public class TicketAppService : ITicketAppService
{
    private readonly IRepository<int, Ticket> _repository;
    private readonly IMapper _mapper;
    private readonly TicketsRepository _ticketsRepository;

    public TicketAppService(IRepository<int, Ticket> repository, IMapper mapper, TicketsRepository ticketsRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _ticketsRepository = ticketsRepository;
    }
    public async Task<List<TicketDTO>> GetTicketsAsync()
    {
        try
        {
            var tickets = await _repository.GetAll().ToListAsync();
            var dtos = _mapper.Map<List<Ticket>, List<TicketDTO>>(tickets);
            return dtos;
        }
        catch(Exception ex)
        {
            throw new Exception($"GetTicketsAsync unsuccessful. Error: {ex.Message}");
        }
    }

    public async Task<TicketDTO> GetTicketByIdAsync(int id)
    {
        try
        {
            var ticket = await _repository.GetAsync(id);
            var ticketDto = _mapper.Map<Ticket, TicketDTO>(ticket);
            return ticketDto;
        }
        catch(Exception ex)
        {
            throw new Exception($"GetTicketByIdAsync unsuccessful. Error: {ex.Message}");
        }
    }

    public async Task<int> AddTicketAsync(NewTicketDTO newTicketDto)
    {
        try
        {
            var ticket = await _ticketsRepository.AddAsync(newTicketDto);
            return ticket.Id;
        }
        catch (Exception ex)
        {
            throw  new Exception($"AddTicketAsync unsuccessful. Error: {ex.Message}");
        }
    }

    public async Task EditTicketAsync(int id, NewTicketDTO newTicketDto)
    {
        try
        {
            await _ticketsRepository.UpdateAsync(id, newTicketDto);
        }
        catch (Exception ex)
        {
            throw new Exception($"EditTicketAsync unsuccessful. Error: {ex.Message}");
        }
    }

    public async Task DeleteTicketAsync(int id)
    {
        try
        {
            await _ticketsRepository.DeleteAsync(id);
        }
        catch(Exception ex)
        {
            throw new Exception($"DeleteTicketAsync unsuccessful. Error: {ex.Message}");    
        }
    }
}