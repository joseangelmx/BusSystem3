using System.ComponentModel.DataAnnotations;
using BusSystem.Core.Buses;

namespace BusSystem.Core.SeatSettings;

public class SeatSetting
{
    [Key]
    public int Id { get; set; }
    [Required] 
    public string Name { get; set; } = null!;
    [Required]
    public int NumberOfSeats { get; set; }
    public ICollection<Bus> Buses { get; set; }
}