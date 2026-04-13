using BusSystem.Core.Tickets;

namespace BusSystem.DataAccess.Repositories.Tickets;

public class TicketsRepository : Repository<int, Ticket>
{
    public TicketsRepository(BusContext context) : base(context)
    {
        
    }
}