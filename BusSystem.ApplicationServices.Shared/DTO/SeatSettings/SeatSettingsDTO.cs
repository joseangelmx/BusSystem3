using System.ComponentModel.DataAnnotations;

namespace BusSystem.ApplicationServices.Shared.DTO.SeatSettings;

public class SeatSettingsDTO
{
    [Key]
    public int Id { get; set; }
    [Required] 
    public string Name { get; set; } = null!;
    [Required]
    public int NumberOfSeats { get; set; }
}