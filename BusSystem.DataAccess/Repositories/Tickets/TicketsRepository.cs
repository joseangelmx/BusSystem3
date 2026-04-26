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
        var user = await Context.Users.FindAsync(newTicketDto.UserId);
        var route = await Context.Travels.FindAsync(newTicketDto.TravelId);
        if (user == null)
        {
            throw new Exception("This user don´t exist");
        }

        if (route == null)
        {
            
        }

    }

    public async Task<Travel> UpdateAsync(int id, NewTravelDTO newTravel)
    {

    }
}