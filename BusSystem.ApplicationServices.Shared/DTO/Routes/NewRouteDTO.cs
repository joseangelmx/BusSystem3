using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusSystem.ApplicationServices.Shared.DTO.Routes;

public class NewRouteDTO
{
    [Required]
    public int OriginId {get; set;}
    [Required] 
    public int DestinationId { get; set; }
    [Required]
    public double Distance { get; set; }

}