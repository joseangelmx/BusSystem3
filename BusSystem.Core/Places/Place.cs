using System.ComponentModel.DataAnnotations;
using BusSystem.Core.Routes;

namespace BusSystem.Core.Places;

public class Place
{
    [Key]
    public int Id { get; set; }
    [Required] 
    public string City { get; set; } = null!;
    [Required] 
    public string TerminalName { get; set; } = null!;
    public ICollection<Route> RoutesAsOrigin { get; set; } = new List<Route>();
    public ICollection<Route> RoutesAsDestination { get; set; } = new List<Route>();
}