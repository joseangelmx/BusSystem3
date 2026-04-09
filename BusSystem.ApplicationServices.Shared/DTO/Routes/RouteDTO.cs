using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusSystem.ApplicationServices.Shared.DTO.Routes;

public class RouteDTO
{
    [Key]
    public int Id {get; set;}
    [Required]
    public int OriginId {get; set;}
    [Required] 
    public int DestinationId { get; set; }
    [Required]
    public double Distance { get; set; }
    [JsonIgnore]
    [Required] 
    public TimeSpan TimeOfArrival { get; set; }
    public string Time =>
        TimeOfArrival.ToString(@"hh\:mm");

}