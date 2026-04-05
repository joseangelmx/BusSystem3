using System.ComponentModel.DataAnnotations;

namespace BusSystem.ApplicationServices.Shared.DTO.Places;

public class PlaceDTO
{
    [Key]
    public int Id { get; set; }
    [Required] 
    public string City { get; set; } = null!;
    [Required] 
    public string TerminalName { get; set; } = null!;

}