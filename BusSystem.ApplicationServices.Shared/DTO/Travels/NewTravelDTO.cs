using System.ComponentModel.DataAnnotations;

namespace BusSystem.ApplicationServices.Shared.DTO.Travels;

public class NewTravelDTO
{
    [Required]
    public int BusId { get; set; }
    [Required]
    public int RouteId { get; set; }
    [Required]
    public TimeSpan DepartureTime { get; set; }
    [Required]
    public TimeSpan ArrivalTime { get; set; }
}