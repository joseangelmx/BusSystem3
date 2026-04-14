using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BusSystem.Core.Buses;
using BusSystem.Core.Routes;
using BusSystem.Core.Tickets;
using BusSystem.Core.Users;

namespace BusSystem.Core.Travels;

public enum TravelStatus
{
    Active = 1,
    Cancelled = 2
}

public class Travel
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int BusId { get; set; }
    public Bus Bus { get; set; }
    [Required]
    public int RouteId { get; set; }
    public Route Route { get; set; }
    [Required]
    public DateTime DepartureDateTime { get; set; }
    [Required]
    public DateTime ArrivalDateTime { get; set; }
    [Required]
    public int AvailableSeats { get; set; }
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }
    [Required]
    public TravelStatus Status { get; set; }
    
    public ICollection<Ticket> Tickets { get; set; }
}