using System.ComponentModel.DataAnnotations;
using BusSystem.Core.Buses;
using BusSystem.Core.Routes;

namespace BusSystem.ApplicationServices.Shared.DTO.Travels;

public class TravelsDTO
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int BusId { get; set; }
    [Required]
    public int RouteId { get; set; }
    [Required]
    public TimeSpan DepartureTime { get; set; }
    [Required]
    public TimeSpan ArrivalTime { get; set; }
}
