using System.ComponentModel.DataAnnotations;

namespace BusSystem.ApplicationServices.Shared.DTO.Travels;

public enum TravelStatus
{
    Active = 1,
    Cancelled = 2
}
public class NewTravelDTO
{
    [Required]
    public int BusId { get; set; }
    [Required]
    public int RouteId { get; set; }
    [Required]
    public DateTime DepartureDateTime { get; set; }
}