using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BusSystem.Core.Places;
using BusSystem.Core.Travels;

namespace BusSystem.Core.Routes;

public class Route
{
    [Key]
    public int Id {get; set;}
    
    [Required]
    public int OriginId {get; set;}
    public Place Origin { get; set; } = null!;
    [Required] 
    public int DestinationId { get; set; }
    public Place Destination { get; set; } = null!;
    
    [Required]
    public double Distance { get; set; }
    [Required] 
    public TimeSpan TimeOfArrival { get; set; }
    public ICollection<Travel> Travels { get; set; }
}