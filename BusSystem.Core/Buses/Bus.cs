using System.ComponentModel.DataAnnotations;
using BusSystem.Core.SeatSettings;
using BusSystem.Core.Travels;

namespace BusSystem.Core.Buses;

public class Bus
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string BusNumber { get; set; }  = null!;
    [Required]
    public string Brand { get; set; }  = null!;
    [Required]
    public string Model { get; set; }  = null!;
    [Required]
    public int SeatSettingId {get; set;}  
    public SeatSetting SeatSetting { get; set; } = null!;
    public ICollection<Travel> Travels { get; set; }
}