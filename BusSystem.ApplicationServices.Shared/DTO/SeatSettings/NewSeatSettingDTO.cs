using System.ComponentModel.DataAnnotations;

namespace BusSystem.ApplicationServices.Shared.DTO.SeatSettings;

public class NewSeatSettingDTO
{
    [Required] 
    public string Name { get; set; } = null!;
    [Required]
    public int NumberOfSeats { get; set; }
}