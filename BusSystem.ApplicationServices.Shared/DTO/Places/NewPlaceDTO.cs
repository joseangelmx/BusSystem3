using System.ComponentModel.DataAnnotations;

namespace BusSystem.ApplicationServices.Shared.DTO.Places;

public class NewPlaceDTO
{
    [Required] 
    public string City { get; set; } = null!;
    [Required] 
    public string TerminalName { get; set; } = null!;
}