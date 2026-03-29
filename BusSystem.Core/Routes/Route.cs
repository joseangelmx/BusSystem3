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
    public string OriginId {get; set;}
    public Place Origin { get; set; } = null!;
    [Required] 
    public string DestinationId { get; set; } = null!;
    public Place Destination { get; set; } = null!;
    
    [Column(TypeName = "decimal(8,2)")]
    public decimal Distance { get; set; }
    [Required] 
    public TimeSpan TimeOfArrival { get; set; }
    public ICollection<Travel> Travels { get; set; }
}