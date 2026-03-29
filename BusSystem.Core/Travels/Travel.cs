using System.ComponentModel.DataAnnotations;
using BusSystem.Core.Buses;
using BusSystem.Core.Routes;
using BusSystem.Core.Tickets;
using BusSystem.Core.Users;

namespace BusSystem.Core.Travels;

public class Travel
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int BusId { get; set; }
    public Bus? Bus { get; set; }
    [Required]
    public int RouteId { get; set; }
    public Route? Route { get; set; }
    [Required]
    public TimeSpan DepartureTime { get; set; }
    [Required]
    public TimeSpan ArrivalTime { get; set; }
    
    public ICollection<Ticket> Tickets { get; set; }
}