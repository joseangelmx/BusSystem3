using System.ComponentModel.DataAnnotations;

namespace BusSystem.ApplicationServices.Shared.DTO.Buses;

public class BusDTO
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
}