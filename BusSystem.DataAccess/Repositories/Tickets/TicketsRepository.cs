using BusSystem.ApplicationServices.Shared.DTO.Tickets;
using BusSystem.ApplicationServices.Shared.DTO.Travels;
using BusSystem.Core.Tickets;
using BusSystem.Core.Travels;
using Microsoft.EntityFrameworkCore;
using TravelStatus = BusSystem.Core.Travels.TravelStatus;

namespace BusSystem.DataAccess.Repositories.Tickets;

public class TicketsRepository : Repository<int, Ticket>
{
    public TicketsRepository(BusContext context) : base(context)
    {
        
    }
    
    public async Task<Ticket> AddAsync(NewTicketDTO newTicketDto)
    {
        double discount = 0;
        switch (newTicketDto.FareType)
        {
            case FareType.Normal:
                discount = 1;
                break;
            case FareType.Estudiante:
                discount = 0.5;
                break;
            case FareType.INAPAM:
                discount = 0.6;
                break;
        }
        var user = await Context.Users.FindAsync(newTicketDto.UserId);
        var travel = await Context.Travels.FindAsync(newTicketDto.TravelId);
        if (user == null)
        {
            throw new Exception("This user don´t exist");
        }

        if (travel == null)
        {
            throw new Exception("This route don´t exist");
        }

        var ticket = new Ticket
        {
            UserId = newTicketDto.UserId,
            TravelId = newTicketDto.TravelId,
            SeatNumber = newTicketDto.SeatNumber,
            FareType = newTicketDto.FareType,
            PurchaseDate = newTicketDto.PurchaseDate,
            Price =  (travel.Price * (decimal)discount),
            Status = newTicketDto.Status
        };
        Context.Tickets.Add(ticket);
        await Context.SaveChangesAsync();
        return ticket;
    }

    public async Task<Ticket> UpdateAsync(int id, NewTicketDTO newTicketDto)
    {
        double discount = 0;
        switch (newTicketDto.FareType)
        {
            case FareType.Normal:
                discount = 1;
                break;
            case FareType.Estudiante:
                discount = 0.5;
                break;
            case FareType.INAPAM:
                discount = 0.6;
                break;
        }
        var ticket = await Context.Tickets.FindAsync(id);
        var user = await Context.Users.FindAsync(newTicketDto.UserId);
        var travel = await Context.Travels.FindAsync(newTicketDto.TravelId);
        if (ticket == null)
        {
            throw new Exception($"The ticket with id {id} was not found");
        }
        if (user == null)
        {
            throw new Exception("This user don´t exist");
        }

        if (travel == null)
        {
            throw new Exception("This route don´t exist");
        }

        ticket.UserId = newTicketDto.UserId;
        ticket.TravelId = newTicketDto.TravelId;
        ticket.SeatNumber = newTicketDto.SeatNumber;
        ticket.FareType = newTicketDto.FareType;
        ticket.PurchaseDate = newTicketDto.PurchaseDate;
        ticket.Price = (travel.Price * (decimal)discount);
        ticket.Status = newTicketDto.Status;
        await Context.SaveChangesAsync();
        return ticket;
    }
}