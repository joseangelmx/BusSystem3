using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusSystem.ApplicationServices.Shared.DTO.Routes;

public class NewRouteDTO
{
    [Required]
    public int OriginId {get; set;}
    [Required] 
    public int DestinationId { get; set; }
    [Column(TypeName = "decimal(8,2)")]
    public decimal Distance { get; set; }
    [Required] 
    public TimeSpan TimeOfArrival { get; set; }
}