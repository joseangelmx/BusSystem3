using System.ComponentModel.DataAnnotations;

namespace BusSystem.ApplicationServices.Shared.DTO.Buses;

public class NewBusDTO
{
    [Required]
    public string BusNumber { get; set; }  = null!;
    [Required]
    public string Brand { get; set; }  = null!;
    [Required]
    public string Model { get; set; }  = null!;
    [Required]
    public int SeatSettingId {get; set;}  
}